Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeTimeForecastAlternateEmployeesDialog
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
            Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeTimeForecastAlternateEmployeesDialog))
            Me.TextBoxForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_CostRate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_BillRate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_EmployeeTitle = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_EmployeeTitle = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.NumericInputForm_BillRate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputForm_CostRate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelForm_AlternateEmployeeDetails = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_CurrentAlternateEmployees = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewForm_CurrentAlternateEmployees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_RemoveAlternateEmployee = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_BillRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_CostRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'TextBoxForm_Description
            '
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
            Me.TextBoxForm_Description.Location = New System.Drawing.Point(98, 64)
            Me.TextBoxForm_Description.Name = "TextBoxForm_Description"
            Me.TextBoxForm_Description.Size = New System.Drawing.Size(231, 20)
            Me.TextBoxForm_Description.TabIndex = 4
            Me.TextBoxForm_Description.TabOnEnter = True
            '
            'LabelForm_Description
            '
            Me.LabelForm_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Description.BackgroundStyle.Class = ""
            Me.LabelForm_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Description.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_Description.Name = "LabelForm_Description"
            Me.LabelForm_Description.Size = New System.Drawing.Size(80, 20)
            Me.LabelForm_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Description.TabIndex = 3
            Me.LabelForm_Description.Text = "Description:"
            '
            'LabelForm_CostRate
            '
            Me.LabelForm_CostRate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CostRate.BackgroundStyle.Class = ""
            Me.LabelForm_CostRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CostRate.Location = New System.Drawing.Point(12, 142)
            Me.LabelForm_CostRate.Name = "LabelForm_CostRate"
            Me.LabelForm_CostRate.Size = New System.Drawing.Size(69, 20)
            Me.LabelForm_CostRate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CostRate.TabIndex = 9
            Me.LabelForm_CostRate.Text = "Cost Rate:"
            '
            'LabelForm_BillRate
            '
            Me.LabelForm_BillRate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_BillRate.BackgroundStyle.Class = ""
            Me.LabelForm_BillRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_BillRate.Location = New System.Drawing.Point(12, 116)
            Me.LabelForm_BillRate.Name = "LabelForm_BillRate"
            Me.LabelForm_BillRate.Size = New System.Drawing.Size(69, 20)
            Me.LabelForm_BillRate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_BillRate.TabIndex = 7
            Me.LabelForm_BillRate.Text = "Bill Rate:"
            '
            'LabelForm_Office
            '
            Me.LabelForm_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Office.BackgroundStyle.Class = ""
            Me.LabelForm_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Office.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_Office.Name = "LabelForm_Office"
            Me.LabelForm_Office.Size = New System.Drawing.Size(80, 20)
            Me.LabelForm_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Office.TabIndex = 5
            Me.LabelForm_Office.Text = "Office:"
            '
            'ComboBoxForm_Office
            '
            Me.ComboBoxForm_Office.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Office.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Office.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Office.BookmarkingEnabled = False
            Me.ComboBoxForm_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Office
            Me.ComboBoxForm_Office.DisableMouseWheel = False
            Me.ComboBoxForm_Office.DisplayMember = "Name"
            Me.ComboBoxForm_Office.DisplayName = ""
            Me.ComboBoxForm_Office.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Office.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Office.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Office.FocusHighlightEnabled = True
            Me.ComboBoxForm_Office.FormattingEnabled = True
            Me.ComboBoxForm_Office.ItemHeight = 14
            Me.ComboBoxForm_Office.Location = New System.Drawing.Point(98, 90)
            Me.ComboBoxForm_Office.Name = "ComboBoxForm_Office"
            Me.ComboBoxForm_Office.PreventEnterBeep = False
            Me.ComboBoxForm_Office.Size = New System.Drawing.Size(231, 20)
            Me.ComboBoxForm_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Office.TabIndex = 6
            Me.ComboBoxForm_Office.ValueMember = "Code"
            Me.ComboBoxForm_Office.WatermarkText = "Select Office"
            '
            'LabelForm_EmployeeTitle
            '
            Me.LabelForm_EmployeeTitle.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EmployeeTitle.BackgroundStyle.Class = ""
            Me.LabelForm_EmployeeTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EmployeeTitle.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_EmployeeTitle.Name = "LabelForm_EmployeeTitle"
            Me.LabelForm_EmployeeTitle.Size = New System.Drawing.Size(80, 20)
            Me.LabelForm_EmployeeTitle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EmployeeTitle.TabIndex = 1
            Me.LabelForm_EmployeeTitle.Text = "Employee Title:"
            '
            'ComboBoxForm_EmployeeTitle
            '
            Me.ComboBoxForm_EmployeeTitle.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_EmployeeTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_EmployeeTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_EmployeeTitle.BookmarkingEnabled = False
            Me.ComboBoxForm_EmployeeTitle.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EmployeeTitle
            Me.ComboBoxForm_EmployeeTitle.DisableMouseWheel = False
            Me.ComboBoxForm_EmployeeTitle.DisplayMember = "Description"
            Me.ComboBoxForm_EmployeeTitle.DisplayName = ""
            Me.ComboBoxForm_EmployeeTitle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_EmployeeTitle.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_EmployeeTitle.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_EmployeeTitle.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_EmployeeTitle.FocusHighlightEnabled = True
            Me.ComboBoxForm_EmployeeTitle.FormattingEnabled = True
            Me.ComboBoxForm_EmployeeTitle.ItemHeight = 14
            Me.ComboBoxForm_EmployeeTitle.Location = New System.Drawing.Point(98, 38)
            Me.ComboBoxForm_EmployeeTitle.Name = "ComboBoxForm_EmployeeTitle"
            Me.ComboBoxForm_EmployeeTitle.PreventEnterBeep = False
            Me.ComboBoxForm_EmployeeTitle.Size = New System.Drawing.Size(231, 20)
            Me.ComboBoxForm_EmployeeTitle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_EmployeeTitle.TabIndex = 2
            Me.ComboBoxForm_EmployeeTitle.ValueMember = "ID"
            Me.ComboBoxForm_EmployeeTitle.WatermarkText = "Select Employee Title"
            '
            'NumericInputForm_BillRate
            '
            Me.NumericInputForm_BillRate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Currency
            Me.NumericInputForm_BillRate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_BillRate.Location = New System.Drawing.Point(98, 116)
            Me.NumericInputForm_BillRate.Name = "NumericInputForm_BillRate"
            Me.NumericInputForm_BillRate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
            Me.NumericInputForm_BillRate.Properties.DisplayFormat.FormatString = "c2"
            Me.NumericInputForm_BillRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_BillRate.Properties.EditFormat.FormatString = "c2"
            Me.NumericInputForm_BillRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_BillRate.Properties.IsFloatValue = False
            Me.NumericInputForm_BillRate.Properties.Mask.EditMask = "c2"
            Me.NumericInputForm_BillRate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_BillRate.Size = New System.Drawing.Size(75, 20)
            Me.NumericInputForm_BillRate.TabIndex = 8
            '
            'NumericInputForm_CostRate
            '
            Me.NumericInputForm_CostRate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Currency
            Me.NumericInputForm_CostRate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_CostRate.Location = New System.Drawing.Point(98, 142)
            Me.NumericInputForm_CostRate.Name = "NumericInputForm_CostRate"
            Me.NumericInputForm_CostRate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
            Me.NumericInputForm_CostRate.Properties.DisplayFormat.FormatString = "c2"
            Me.NumericInputForm_CostRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_CostRate.Properties.EditFormat.FormatString = "c2"
            Me.NumericInputForm_CostRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_CostRate.Properties.IsFloatValue = False
            Me.NumericInputForm_CostRate.Properties.Mask.EditMask = "c2"
            Me.NumericInputForm_CostRate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_CostRate.Size = New System.Drawing.Size(75, 20)
            Me.NumericInputForm_CostRate.TabIndex = 10
            '
            'LabelForm_AlternateEmployeeDetails
            '
            Me.LabelForm_AlternateEmployeeDetails.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AlternateEmployeeDetails.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_AlternateEmployeeDetails.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_AlternateEmployeeDetails.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_AlternateEmployeeDetails.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_AlternateEmployeeDetails.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_AlternateEmployeeDetails.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_AlternateEmployeeDetails.BackgroundStyle.Class = ""
            Me.LabelForm_AlternateEmployeeDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AlternateEmployeeDetails.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_AlternateEmployeeDetails.Name = "LabelForm_AlternateEmployeeDetails"
            Me.LabelForm_AlternateEmployeeDetails.Size = New System.Drawing.Size(317, 20)
            Me.LabelForm_AlternateEmployeeDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AlternateEmployeeDetails.TabIndex = 0
            Me.LabelForm_AlternateEmployeeDetails.Text = "Alternate Employee Details"
            '
            'LabelForm_CurrentAlternateEmployees
            '
            Me.LabelForm_CurrentAlternateEmployees.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CurrentAlternateEmployees.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_CurrentAlternateEmployees.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_CurrentAlternateEmployees.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_CurrentAlternateEmployees.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_CurrentAlternateEmployees.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_CurrentAlternateEmployees.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_CurrentAlternateEmployees.BackgroundStyle.Class = ""
            Me.LabelForm_CurrentAlternateEmployees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CurrentAlternateEmployees.Location = New System.Drawing.Point(335, 12)
            Me.LabelForm_CurrentAlternateEmployees.Name = "LabelForm_CurrentAlternateEmployees"
            Me.LabelForm_CurrentAlternateEmployees.Size = New System.Drawing.Size(337, 20)
            Me.LabelForm_CurrentAlternateEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CurrentAlternateEmployees.TabIndex = 12
            Me.LabelForm_CurrentAlternateEmployees.Text = "Current Alternate Employees"
            '
            'DataGridViewForm_CurrentAlternateEmployees
            '
            Me.DataGridViewForm_CurrentAlternateEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_CurrentAlternateEmployees.ItemDescription = ""
            Me.DataGridViewForm_CurrentAlternateEmployees.Location = New System.Drawing.Point(335, 38)
            Me.DataGridViewForm_CurrentAlternateEmployees.MultiSelect = True
            Me.DataGridViewForm_CurrentAlternateEmployees.Name = "DataGridViewForm_CurrentAlternateEmployees"
            Me.DataGridViewForm_CurrentAlternateEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_CurrentAlternateEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_CurrentAlternateEmployees.Size = New System.Drawing.Size(256, 223)
            Me.DataGridViewForm_CurrentAlternateEmployees.TabIndex = 13
            Me.DataGridViewForm_CurrentAlternateEmployees.UseEmbeddedNavigator = False
            Me.DataGridViewForm_CurrentAlternateEmployees.ViewCaptionHeight = -1
            '
            'ButtonForm_RemoveAlternateEmployee
            '
            Me.ButtonForm_RemoveAlternateEmployee.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_RemoveAlternateEmployee.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_RemoveAlternateEmployee.Location = New System.Drawing.Point(597, 38)
            Me.ButtonForm_RemoveAlternateEmployee.Name = "ButtonForm_RemoveAlternateEmployee"
            Me.ButtonForm_RemoveAlternateEmployee.SecurityEnabled = True
            Me.ButtonForm_RemoveAlternateEmployee.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_RemoveAlternateEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_RemoveAlternateEmployee.TabIndex = 14
            Me.ButtonForm_RemoveAlternateEmployee.Text = "X"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(597, 267)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 15
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(254, 241)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 11
            Me.ButtonForm_Add.Text = "Add"
            '
            'EmployeeTimeForecastAlternateEmployeesDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(684, 299)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.ButtonForm_RemoveAlternateEmployee)
            Me.Controls.Add(Me.LabelForm_CurrentAlternateEmployees)
            Me.Controls.Add(Me.DataGridViewForm_CurrentAlternateEmployees)
            Me.Controls.Add(Me.LabelForm_AlternateEmployeeDetails)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.LabelForm_EmployeeTitle)
            Me.Controls.Add(Me.NumericInputForm_CostRate)
            Me.Controls.Add(Me.NumericInputForm_BillRate)
            Me.Controls.Add(Me.ComboBoxForm_EmployeeTitle)
            Me.Controls.Add(Me.ComboBoxForm_Office)
            Me.Controls.Add(Me.LabelForm_CostRate)
            Me.Controls.Add(Me.LabelForm_Office)
            Me.Controls.Add(Me.TextBoxForm_Description)
            Me.Controls.Add(Me.LabelForm_BillRate)
            Me.Controls.Add(Me.LabelForm_Description)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeTimeForecastAlternateEmployeesDialog"
            Me.Text = "Add Employee Time Forecast Alternate Employees"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_BillRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_CostRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TextBoxForm_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_CostRate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_BillRate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Office As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Office As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_EmployeeTitle As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_EmployeeTitle As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents NumericInputForm_BillRate As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputForm_CostRate As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelForm_AlternateEmployeeDetails As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_CurrentAlternateEmployees As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_CurrentAlternateEmployees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_RemoveAlternateEmployee As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
    End Class

End Namespace