Namespace Employee.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TimesheetSettingsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimesheetSettingsDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TextBoxForm_FunctionCategory = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_Component = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_Job = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_ProductCategory = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_FunctionCategory = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Component = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Job = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ProductCategory = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Labels = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_General = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ShowComments = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonControlForm_Icon = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlForm_Textbox = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.Label2 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_StartWeekOn = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(296, 272)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 20
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(215, 272)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 19
            Me.ButtonForm_Update.Text = "Update"
            '
            'TextBoxForm_FunctionCategory
            '
            '
            '
            '
            Me.TextBoxForm_FunctionCategory.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_FunctionCategory.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_FunctionCategory.CheckSpellingOnValidate = False
            Me.TextBoxForm_FunctionCategory.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_FunctionCategory.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_FunctionCategory.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_FunctionCategory.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_FunctionCategory.FocusHighlightEnabled = True
            Me.TextBoxForm_FunctionCategory.Location = New System.Drawing.Point(120, 246)
            Me.TextBoxForm_FunctionCategory.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_FunctionCategory.Name = "TextBoxForm_FunctionCategory"
            Me.TextBoxForm_FunctionCategory.SecurityEnabled = True
            Me.TextBoxForm_FunctionCategory.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_FunctionCategory.Size = New System.Drawing.Size(251, 20)
            Me.TextBoxForm_FunctionCategory.StartingFolderName = Nothing
            Me.TextBoxForm_FunctionCategory.TabIndex = 18
            Me.TextBoxForm_FunctionCategory.TabOnEnter = True
            '
            'TextBoxForm_Component
            '
            '
            '
            '
            Me.TextBoxForm_Component.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Component.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Component.CheckSpellingOnValidate = False
            Me.TextBoxForm_Component.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Component.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Component.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Component.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Component.FocusHighlightEnabled = True
            Me.TextBoxForm_Component.Location = New System.Drawing.Point(120, 220)
            Me.TextBoxForm_Component.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Component.Name = "TextBoxForm_Component"
            Me.TextBoxForm_Component.SecurityEnabled = True
            Me.TextBoxForm_Component.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Component.Size = New System.Drawing.Size(251, 20)
            Me.TextBoxForm_Component.StartingFolderName = Nothing
            Me.TextBoxForm_Component.TabIndex = 16
            Me.TextBoxForm_Component.TabOnEnter = True
            '
            'TextBoxForm_Job
            '
            '
            '
            '
            Me.TextBoxForm_Job.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Job.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Job.CheckSpellingOnValidate = False
            Me.TextBoxForm_Job.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Job.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Job.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Job.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Job.FocusHighlightEnabled = True
            Me.TextBoxForm_Job.Location = New System.Drawing.Point(120, 194)
            Me.TextBoxForm_Job.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Job.Name = "TextBoxForm_Job"
            Me.TextBoxForm_Job.SecurityEnabled = True
            Me.TextBoxForm_Job.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Job.Size = New System.Drawing.Size(251, 20)
            Me.TextBoxForm_Job.StartingFolderName = Nothing
            Me.TextBoxForm_Job.TabIndex = 14
            Me.TextBoxForm_Job.TabOnEnter = True
            '
            'TextBoxForm_ProductCategory
            '
            '
            '
            '
            Me.TextBoxForm_ProductCategory.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_ProductCategory.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_ProductCategory.CheckSpellingOnValidate = False
            Me.TextBoxForm_ProductCategory.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_ProductCategory.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_ProductCategory.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_ProductCategory.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_ProductCategory.FocusHighlightEnabled = True
            Me.TextBoxForm_ProductCategory.Location = New System.Drawing.Point(120, 168)
            Me.TextBoxForm_ProductCategory.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_ProductCategory.Name = "TextBoxForm_ProductCategory"
            Me.TextBoxForm_ProductCategory.SecurityEnabled = True
            Me.TextBoxForm_ProductCategory.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_ProductCategory.Size = New System.Drawing.Size(251, 20)
            Me.TextBoxForm_ProductCategory.StartingFolderName = Nothing
            Me.TextBoxForm_ProductCategory.TabIndex = 12
            Me.TextBoxForm_ProductCategory.TabOnEnter = True
            '
            'TextBoxForm_Product
            '
            '
            '
            '
            Me.TextBoxForm_Product.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Product.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Product.CheckSpellingOnValidate = False
            Me.TextBoxForm_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Product.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Product.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Product.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Product.FocusHighlightEnabled = True
            Me.TextBoxForm_Product.Location = New System.Drawing.Point(120, 142)
            Me.TextBoxForm_Product.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Product.Name = "TextBoxForm_Product"
            Me.TextBoxForm_Product.SecurityEnabled = True
            Me.TextBoxForm_Product.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Product.Size = New System.Drawing.Size(251, 20)
            Me.TextBoxForm_Product.StartingFolderName = Nothing
            Me.TextBoxForm_Product.TabIndex = 10
            Me.TextBoxForm_Product.TabOnEnter = True
            '
            'TextBoxForm_Division
            '
            '
            '
            '
            Me.TextBoxForm_Division.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Division.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Division.CheckSpellingOnValidate = False
            Me.TextBoxForm_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Division.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Division.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Division.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Division.FocusHighlightEnabled = True
            Me.TextBoxForm_Division.Location = New System.Drawing.Point(120, 116)
            Me.TextBoxForm_Division.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Division.Name = "TextBoxForm_Division"
            Me.TextBoxForm_Division.SecurityEnabled = True
            Me.TextBoxForm_Division.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Division.Size = New System.Drawing.Size(251, 20)
            Me.TextBoxForm_Division.StartingFolderName = Nothing
            Me.TextBoxForm_Division.TabIndex = 8
            Me.TextBoxForm_Division.TabOnEnter = True
            '
            'LabelForm_FunctionCategory
            '
            Me.LabelForm_FunctionCategory.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FunctionCategory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FunctionCategory.Location = New System.Drawing.Point(12, 246)
            Me.LabelForm_FunctionCategory.Name = "LabelForm_FunctionCategory"
            Me.LabelForm_FunctionCategory.Size = New System.Drawing.Size(102, 20)
            Me.LabelForm_FunctionCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FunctionCategory.TabIndex = 17
            Me.LabelForm_FunctionCategory.Text = "Function/Category:"
            '
            'LabelForm_Component
            '
            Me.LabelForm_Component.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Component.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Component.Location = New System.Drawing.Point(12, 220)
            Me.LabelForm_Component.Name = "LabelForm_Component"
            Me.LabelForm_Component.Size = New System.Drawing.Size(102, 20)
            Me.LabelForm_Component.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Component.TabIndex = 15
            Me.LabelForm_Component.Text = "Component:"
            '
            'LabelForm_Job
            '
            Me.LabelForm_Job.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Job.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Job.Location = New System.Drawing.Point(12, 194)
            Me.LabelForm_Job.Name = "LabelForm_Job"
            Me.LabelForm_Job.Size = New System.Drawing.Size(102, 20)
            Me.LabelForm_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Job.TabIndex = 13
            Me.LabelForm_Job.Text = "Job:"
            '
            'LabelForm_ProductCategory
            '
            Me.LabelForm_ProductCategory.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ProductCategory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ProductCategory.Location = New System.Drawing.Point(12, 168)
            Me.LabelForm_ProductCategory.Name = "LabelForm_ProductCategory"
            Me.LabelForm_ProductCategory.Size = New System.Drawing.Size(102, 20)
            Me.LabelForm_ProductCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ProductCategory.TabIndex = 11
            Me.LabelForm_ProductCategory.Text = "Product Category:"
            '
            'LabelForm_Product
            '
            Me.LabelForm_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Product.Location = New System.Drawing.Point(12, 142)
            Me.LabelForm_Product.Name = "LabelForm_Product"
            Me.LabelForm_Product.Size = New System.Drawing.Size(102, 20)
            Me.LabelForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Product.TabIndex = 9
            Me.LabelForm_Product.Text = "Product:"
            '
            'LabelForm_Division
            '
            Me.LabelForm_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Division.Location = New System.Drawing.Point(12, 116)
            Me.LabelForm_Division.Name = "LabelForm_Division"
            Me.LabelForm_Division.Size = New System.Drawing.Size(102, 20)
            Me.LabelForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Division.TabIndex = 7
            Me.LabelForm_Division.Text = "Division:"
            '
            'LabelForm_Labels
            '
            Me.LabelForm_Labels.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Labels.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Labels.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_Labels.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_Labels.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Labels.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_Labels.Name = "LabelForm_Labels"
            Me.LabelForm_Labels.Size = New System.Drawing.Size(359, 20)
            Me.LabelForm_Labels.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Labels.TabIndex = 6
            Me.LabelForm_Labels.Text = "Labels"
            '
            'LabelForm_General
            '
            Me.LabelForm_General.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_General.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_General.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_General.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_General.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_General.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_General.Name = "LabelForm_General"
            Me.LabelForm_General.Size = New System.Drawing.Size(359, 20)
            Me.LabelForm_General.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_General.TabIndex = 0
            Me.LabelForm_General.Text = "General"
            '
            'LabelForm_ShowComments
            '
            Me.LabelForm_ShowComments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ShowComments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ShowComments.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_ShowComments.Name = "LabelForm_ShowComments"
            Me.LabelForm_ShowComments.Size = New System.Drawing.Size(102, 20)
            Me.LabelForm_ShowComments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ShowComments.TabIndex = 1
            Me.LabelForm_ShowComments.Text = "Show Comments:"
            '
            'RadioButtonControlForm_Icon
            '
            Me.RadioButtonControlForm_Icon.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlForm_Icon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_Icon.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_Icon.Location = New System.Drawing.Point(120, 38)
            Me.RadioButtonControlForm_Icon.Name = "RadioButtonControlForm_Icon"
            Me.RadioButtonControlForm_Icon.SecurityEnabled = True
            Me.RadioButtonControlForm_Icon.Size = New System.Drawing.Size(69, 20)
            Me.RadioButtonControlForm_Icon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_Icon.TabIndex = 2
            Me.RadioButtonControlForm_Icon.TabStop = False
            Me.RadioButtonControlForm_Icon.Text = "Icon"
            '
            'RadioButtonControlForm_Textbox
            '
            Me.RadioButtonControlForm_Textbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlForm_Textbox.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlForm_Textbox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_Textbox.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_Textbox.Location = New System.Drawing.Point(195, 38)
            Me.RadioButtonControlForm_Textbox.Name = "RadioButtonControlForm_Textbox"
            Me.RadioButtonControlForm_Textbox.SecurityEnabled = True
            Me.RadioButtonControlForm_Textbox.Size = New System.Drawing.Size(176, 20)
            Me.RadioButtonControlForm_Textbox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_Textbox.TabIndex = 3
            Me.RadioButtonControlForm_Textbox.TabStop = False
            Me.RadioButtonControlForm_Textbox.Text = "Textbox"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label2.Location = New System.Drawing.Point(12, 64)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(102, 20)
            Me.Label2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label2.TabIndex = 4
            Me.Label2.Text = "Start Week On:"
            '
            'ComboBoxForm_StartWeekOn
            '
            Me.ComboBoxForm_StartWeekOn.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_StartWeekOn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_StartWeekOn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_StartWeekOn.AutoFindItemInDataSource = False
            Me.ComboBoxForm_StartWeekOn.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_StartWeekOn.BookmarkingEnabled = False
            Me.ComboBoxForm_StartWeekOn.ClientCode = ""
            Me.ComboBoxForm_StartWeekOn.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxForm_StartWeekOn.DisableMouseWheel = False
            Me.ComboBoxForm_StartWeekOn.DisplayMember = "Description"
            Me.ComboBoxForm_StartWeekOn.DisplayName = ""
            Me.ComboBoxForm_StartWeekOn.DivisionCode = ""
            Me.ComboBoxForm_StartWeekOn.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_StartWeekOn.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_StartWeekOn.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_StartWeekOn.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_StartWeekOn.FocusHighlightEnabled = True
            Me.ComboBoxForm_StartWeekOn.FormattingEnabled = True
            Me.ComboBoxForm_StartWeekOn.ItemHeight = 14
            Me.ComboBoxForm_StartWeekOn.Location = New System.Drawing.Point(120, 64)
            Me.ComboBoxForm_StartWeekOn.Name = "ComboBoxForm_StartWeekOn"
            Me.ComboBoxForm_StartWeekOn.PreventEnterBeep = False
            Me.ComboBoxForm_StartWeekOn.ReadOnly = False
            Me.ComboBoxForm_StartWeekOn.SecurityEnabled = True
            Me.ComboBoxForm_StartWeekOn.Size = New System.Drawing.Size(251, 20)
            Me.ComboBoxForm_StartWeekOn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_StartWeekOn.TabIndex = 5
            Me.ComboBoxForm_StartWeekOn.ValueMember = "Code"
            Me.ComboBoxForm_StartWeekOn.WatermarkText = "Select"
            '
            'TimesheetSettingsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(383, 304)
            Me.Controls.Add(Me.ComboBoxForm_StartWeekOn)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.RadioButtonControlForm_Textbox)
            Me.Controls.Add(Me.RadioButtonControlForm_Icon)
            Me.Controls.Add(Me.LabelForm_ShowComments)
            Me.Controls.Add(Me.LabelForm_General)
            Me.Controls.Add(Me.TextBoxForm_FunctionCategory)
            Me.Controls.Add(Me.TextBoxForm_Component)
            Me.Controls.Add(Me.TextBoxForm_Job)
            Me.Controls.Add(Me.TextBoxForm_ProductCategory)
            Me.Controls.Add(Me.TextBoxForm_Product)
            Me.Controls.Add(Me.TextBoxForm_Division)
            Me.Controls.Add(Me.LabelForm_FunctionCategory)
            Me.Controls.Add(Me.LabelForm_Component)
            Me.Controls.Add(Me.LabelForm_Job)
            Me.Controls.Add(Me.LabelForm_ProductCategory)
            Me.Controls.Add(Me.LabelForm_Product)
            Me.Controls.Add(Me.LabelForm_Division)
            Me.Controls.Add(Me.LabelForm_Labels)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "TimesheetSettingsDialog"
            Me.Text = "Settings"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TextBoxForm_FunctionCategory As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_Component As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_Job As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_ProductCategory As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_Product As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_Division As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_FunctionCategory As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Component As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Job As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ProductCategory As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Labels As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_General As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ShowComments As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonControlForm_Icon As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlForm_Textbox As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents Label2 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_StartWeekOn As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    End Class

End Namespace