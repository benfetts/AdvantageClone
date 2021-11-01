Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeTimeForecastNewDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeTimeForecastNewDialog))
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TextBoxForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_AssignedEmployee = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_AssignedEmployee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_UpdateRevenueAmounts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_UpdateEmployeeRates = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxForm_EmployeeTimeForecasts = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.SuspendLayout()
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(363, 220)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 13
            Me.ButtonForm_Add.Text = "Add"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(444, 220)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 14
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ComboBoxForm_Office
            '
            Me.ComboBoxForm_Office.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Office.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Office.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Office.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Office.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Office.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Office.BookmarkingEnabled = False
            Me.ComboBoxForm_Office.ClientCode = ""
            Me.ComboBoxForm_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Office
            Me.ComboBoxForm_Office.DisableMouseWheel = False
            Me.ComboBoxForm_Office.DisplayMember = "Name"
            Me.ComboBoxForm_Office.DisplayName = ""
            Me.ComboBoxForm_Office.DivisionCode = ""
            Me.ComboBoxForm_Office.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Office.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Office.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Office.FocusHighlightEnabled = True
            Me.ComboBoxForm_Office.FormattingEnabled = True
            Me.ComboBoxForm_Office.ItemHeight = 14
            Me.ComboBoxForm_Office.Location = New System.Drawing.Point(121, 38)
            Me.ComboBoxForm_Office.Name = "ComboBoxForm_Office"
            Me.ComboBoxForm_Office.ReadOnly = False
            Me.ComboBoxForm_Office.SecurityEnabled = True
            Me.ComboBoxForm_Office.Size = New System.Drawing.Size(398, 20)
            Me.ComboBoxForm_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Office.TabIndex = 3
            Me.ComboBoxForm_Office.TabOnEnter = True
            Me.ComboBoxForm_Office.ValueMember = "Code"
            Me.ComboBoxForm_Office.WatermarkText = "Select Office"
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
            Me.TextBoxForm_Description.Location = New System.Drawing.Point(121, 12)
            Me.TextBoxForm_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Description.Name = "TextBoxForm_Description"
            Me.TextBoxForm_Description.SecurityEnabled = True
            Me.TextBoxForm_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Description.Size = New System.Drawing.Size(398, 20)
            Me.TextBoxForm_Description.StartingFolderName = Nothing
            Me.TextBoxForm_Description.TabIndex = 1
            Me.TextBoxForm_Description.TabOnEnter = True
            '
            'LabelForm_Description
            '
            Me.LabelForm_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Description.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Description.Name = "LabelForm_Description"
            Me.LabelForm_Description.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Description.TabIndex = 0
            Me.LabelForm_Description.Text = "Description:"
            '
            'LabelForm_Office
            '
            Me.LabelForm_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Office.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Office.Name = "LabelForm_Office"
            Me.LabelForm_Office.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Office.TabIndex = 2
            Me.LabelForm_Office.Text = "Office:"
            '
            'ComboBoxForm_AssignedEmployee
            '
            Me.ComboBoxForm_AssignedEmployee.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_AssignedEmployee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_AssignedEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_AssignedEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_AssignedEmployee.AutoFindItemInDataSource = False
            Me.ComboBoxForm_AssignedEmployee.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_AssignedEmployee.BookmarkingEnabled = False
            Me.ComboBoxForm_AssignedEmployee.ClientCode = ""
            Me.ComboBoxForm_AssignedEmployee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Employee
            Me.ComboBoxForm_AssignedEmployee.DisableMouseWheel = False
            Me.ComboBoxForm_AssignedEmployee.DisplayMember = "FullName"
            Me.ComboBoxForm_AssignedEmployee.DisplayName = ""
            Me.ComboBoxForm_AssignedEmployee.DivisionCode = ""
            Me.ComboBoxForm_AssignedEmployee.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_AssignedEmployee.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_AssignedEmployee.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_AssignedEmployee.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_AssignedEmployee.FocusHighlightEnabled = True
            Me.ComboBoxForm_AssignedEmployee.FormattingEnabled = True
            Me.ComboBoxForm_AssignedEmployee.ItemHeight = 14
            Me.ComboBoxForm_AssignedEmployee.Location = New System.Drawing.Point(121, 90)
            Me.ComboBoxForm_AssignedEmployee.Name = "ComboBoxForm_AssignedEmployee"
            Me.ComboBoxForm_AssignedEmployee.ReadOnly = False
            Me.ComboBoxForm_AssignedEmployee.SecurityEnabled = True
            Me.ComboBoxForm_AssignedEmployee.Size = New System.Drawing.Size(398, 20)
            Me.ComboBoxForm_AssignedEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_AssignedEmployee.TabIndex = 7
            Me.ComboBoxForm_AssignedEmployee.TabOnEnter = True
            Me.ComboBoxForm_AssignedEmployee.ValueMember = "Code"
            Me.ComboBoxForm_AssignedEmployee.WatermarkText = "Select Employee"
            '
            'LabelForm_AssignedEmployee
            '
            Me.LabelForm_AssignedEmployee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AssignedEmployee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AssignedEmployee.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_AssignedEmployee.Name = "LabelForm_AssignedEmployee"
            Me.LabelForm_AssignedEmployee.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_AssignedEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AssignedEmployee.TabIndex = 6
            Me.LabelForm_AssignedEmployee.Text = "Assigned Employee:"
            '
            'ComboBoxForm_PostPeriod
            '
            Me.ComboBoxForm_PostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_PostPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_PostPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_PostPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_PostPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxForm_PostPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_PostPeriod.BookmarkingEnabled = False
            Me.ComboBoxForm_PostPeriod.ClientCode = ""
            Me.ComboBoxForm_PostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_PostPeriod.DisableMouseWheel = False
            Me.ComboBoxForm_PostPeriod.DisplayMember = "Description"
            Me.ComboBoxForm_PostPeriod.DisplayName = ""
            Me.ComboBoxForm_PostPeriod.DivisionCode = ""
            Me.ComboBoxForm_PostPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_PostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_PostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_PostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_PostPeriod.FocusHighlightEnabled = True
            Me.ComboBoxForm_PostPeriod.FormattingEnabled = True
            Me.ComboBoxForm_PostPeriod.ItemHeight = 14
            Me.ComboBoxForm_PostPeriod.Location = New System.Drawing.Point(121, 64)
            Me.ComboBoxForm_PostPeriod.Name = "ComboBoxForm_PostPeriod"
            Me.ComboBoxForm_PostPeriod.ReadOnly = False
            Me.ComboBoxForm_PostPeriod.SecurityEnabled = True
            Me.ComboBoxForm_PostPeriod.Size = New System.Drawing.Size(398, 20)
            Me.ComboBoxForm_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_PostPeriod.TabIndex = 5
            Me.ComboBoxForm_PostPeriod.TabOnEnter = True
            Me.ComboBoxForm_PostPeriod.ValueMember = "Code"
            Me.ComboBoxForm_PostPeriod.WatermarkText = "Select Post Period"
            '
            'LabelForm_PostPeriod
            '
            Me.LabelForm_PostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostPeriod.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_PostPeriod.Name = "LabelForm_PostPeriod"
            Me.LabelForm_PostPeriod.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostPeriod.TabIndex = 4
            Me.LabelForm_PostPeriod.Text = "Post Period:"
            '
            'CheckBoxForm_ExcludeHoursEnteredInCopy
            '
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.CheckValue = 0
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.CheckValueChecked = 1
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.CheckValueUnchecked = 0
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.ChildControls = CType(resources.GetObject("CheckBoxForm_ExcludeHoursEnteredInCopy.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.Enabled = False
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.Location = New System.Drawing.Point(121, 194)
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.Name = "CheckBoxForm_ExcludeHoursEnteredInCopy"
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.OldestSibling = Nothing
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.SecurityEnabled = True
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.SiblingControls = CType(resources.GetObject("CheckBoxForm_ExcludeHoursEnteredInCopy.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.Size = New System.Drawing.Size(398, 20)
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.TabIndex = 12
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.TabOnEnter = True
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.TabStop = False
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.Text = "Exclude hours entered in copy"
            '
            'CheckBoxForm_UpdateRevenueAmounts
            '
            Me.CheckBoxForm_UpdateRevenueAmounts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_UpdateRevenueAmounts.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_UpdateRevenueAmounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_UpdateRevenueAmounts.CheckValue = 0
            Me.CheckBoxForm_UpdateRevenueAmounts.CheckValueChecked = 1
            Me.CheckBoxForm_UpdateRevenueAmounts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_UpdateRevenueAmounts.CheckValueUnchecked = 0
            Me.CheckBoxForm_UpdateRevenueAmounts.ChildControls = CType(resources.GetObject("CheckBoxForm_UpdateRevenueAmounts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UpdateRevenueAmounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_UpdateRevenueAmounts.Enabled = False
            Me.CheckBoxForm_UpdateRevenueAmounts.Location = New System.Drawing.Point(121, 168)
            Me.CheckBoxForm_UpdateRevenueAmounts.Name = "CheckBoxForm_UpdateRevenueAmounts"
            Me.CheckBoxForm_UpdateRevenueAmounts.OldestSibling = Nothing
            Me.CheckBoxForm_UpdateRevenueAmounts.SecurityEnabled = True
            Me.CheckBoxForm_UpdateRevenueAmounts.SiblingControls = CType(resources.GetObject("CheckBoxForm_UpdateRevenueAmounts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UpdateRevenueAmounts.Size = New System.Drawing.Size(398, 20)
            Me.CheckBoxForm_UpdateRevenueAmounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_UpdateRevenueAmounts.TabIndex = 11
            Me.CheckBoxForm_UpdateRevenueAmounts.TabOnEnter = True
            Me.CheckBoxForm_UpdateRevenueAmounts.TabStop = False
            Me.CheckBoxForm_UpdateRevenueAmounts.Text = "Update Forecast with current revenue amounts based on approved estimates"
            '
            'CheckBoxForm_UpdateEmployeeRates
            '
            Me.CheckBoxForm_UpdateEmployeeRates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_UpdateEmployeeRates.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_UpdateEmployeeRates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_UpdateEmployeeRates.CheckValue = 0
            Me.CheckBoxForm_UpdateEmployeeRates.CheckValueChecked = 1
            Me.CheckBoxForm_UpdateEmployeeRates.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_UpdateEmployeeRates.CheckValueUnchecked = 0
            Me.CheckBoxForm_UpdateEmployeeRates.ChildControls = CType(resources.GetObject("CheckBoxForm_UpdateEmployeeRates.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UpdateEmployeeRates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_UpdateEmployeeRates.Enabled = False
            Me.CheckBoxForm_UpdateEmployeeRates.Location = New System.Drawing.Point(121, 142)
            Me.CheckBoxForm_UpdateEmployeeRates.Name = "CheckBoxForm_UpdateEmployeeRates"
            Me.CheckBoxForm_UpdateEmployeeRates.OldestSibling = Nothing
            Me.CheckBoxForm_UpdateEmployeeRates.SecurityEnabled = True
            Me.CheckBoxForm_UpdateEmployeeRates.SiblingControls = CType(resources.GetObject("CheckBoxForm_UpdateEmployeeRates.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UpdateEmployeeRates.Size = New System.Drawing.Size(398, 20)
            Me.CheckBoxForm_UpdateEmployeeRates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_UpdateEmployeeRates.TabIndex = 10
            Me.CheckBoxForm_UpdateEmployeeRates.TabOnEnter = True
            Me.CheckBoxForm_UpdateEmployeeRates.TabStop = False
            Me.CheckBoxForm_UpdateEmployeeRates.Text = "Update Forecast with current employee rates and recalculate totals"
            '
            'CheckBoxForm_CopyFrom
            '
            Me.CheckBoxForm_CopyFrom.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_CopyFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_CopyFrom.CheckValue = 0
            Me.CheckBoxForm_CopyFrom.CheckValueChecked = 1
            Me.CheckBoxForm_CopyFrom.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_CopyFrom.CheckValueUnchecked = 0
            Me.CheckBoxForm_CopyFrom.ChildControls = CType(resources.GetObject("CheckBoxForm_CopyFrom.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_CopyFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_CopyFrom.Location = New System.Drawing.Point(12, 116)
            Me.CheckBoxForm_CopyFrom.Name = "CheckBoxForm_CopyFrom"
            Me.CheckBoxForm_CopyFrom.OldestSibling = Nothing
            Me.CheckBoxForm_CopyFrom.SecurityEnabled = True
            Me.CheckBoxForm_CopyFrom.SiblingControls = CType(resources.GetObject("CheckBoxForm_CopyFrom.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_CopyFrom.Size = New System.Drawing.Size(103, 20)
            Me.CheckBoxForm_CopyFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_CopyFrom.TabIndex = 8
            Me.CheckBoxForm_CopyFrom.TabOnEnter = True
            Me.CheckBoxForm_CopyFrom.TabStop = False
            Me.CheckBoxForm_CopyFrom.Text = "Copy From:"
            '
            'ComboBoxForm_EmployeeTimeForecasts
            '
            Me.ComboBoxForm_EmployeeTimeForecasts.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_EmployeeTimeForecasts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_EmployeeTimeForecasts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_EmployeeTimeForecasts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_EmployeeTimeForecasts.AutoFindItemInDataSource = False
            Me.ComboBoxForm_EmployeeTimeForecasts.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_EmployeeTimeForecasts.BookmarkingEnabled = False
            Me.ComboBoxForm_EmployeeTimeForecasts.ClientCode = ""
            Me.ComboBoxForm_EmployeeTimeForecasts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EmployeeTimeForecast
            Me.ComboBoxForm_EmployeeTimeForecasts.DisableMouseWheel = False
            Me.ComboBoxForm_EmployeeTimeForecasts.DisplayMember = "Description"
            Me.ComboBoxForm_EmployeeTimeForecasts.DisplayName = ""
            Me.ComboBoxForm_EmployeeTimeForecasts.DivisionCode = ""
            Me.ComboBoxForm_EmployeeTimeForecasts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_EmployeeTimeForecasts.Enabled = False
            Me.ComboBoxForm_EmployeeTimeForecasts.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_EmployeeTimeForecasts.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_EmployeeTimeForecasts.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_EmployeeTimeForecasts.FocusHighlightEnabled = True
            Me.ComboBoxForm_EmployeeTimeForecasts.FormattingEnabled = True
            Me.ComboBoxForm_EmployeeTimeForecasts.ItemHeight = 14
            Me.ComboBoxForm_EmployeeTimeForecasts.Location = New System.Drawing.Point(121, 116)
            Me.ComboBoxForm_EmployeeTimeForecasts.Name = "ComboBoxForm_EmployeeTimeForecasts"
            Me.ComboBoxForm_EmployeeTimeForecasts.ReadOnly = False
            Me.ComboBoxForm_EmployeeTimeForecasts.SecurityEnabled = True
            Me.ComboBoxForm_EmployeeTimeForecasts.Size = New System.Drawing.Size(398, 20)
            Me.ComboBoxForm_EmployeeTimeForecasts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_EmployeeTimeForecasts.TabIndex = 9
            Me.ComboBoxForm_EmployeeTimeForecasts.TabOnEnter = True
            Me.ComboBoxForm_EmployeeTimeForecasts.ValueMember = "ID"
            Me.ComboBoxForm_EmployeeTimeForecasts.WatermarkText = "Select Employee Time Forecast"
            '
            'EmployeeTimeForecastNewDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(531, 252)
            Me.Controls.Add(Me.ComboBoxForm_EmployeeTimeForecasts)
            Me.Controls.Add(Me.CheckBoxForm_CopyFrom)
            Me.Controls.Add(Me.CheckBoxForm_ExcludeHoursEnteredInCopy)
            Me.Controls.Add(Me.CheckBoxForm_UpdateRevenueAmounts)
            Me.Controls.Add(Me.ComboBoxForm_PostPeriod)
            Me.Controls.Add(Me.LabelForm_PostPeriod)
            Me.Controls.Add(Me.ComboBoxForm_AssignedEmployee)
            Me.Controls.Add(Me.CheckBoxForm_UpdateEmployeeRates)
            Me.Controls.Add(Me.LabelForm_AssignedEmployee)
            Me.Controls.Add(Me.ComboBoxForm_Office)
            Me.Controls.Add(Me.TextBoxForm_Description)
            Me.Controls.Add(Me.LabelForm_Description)
            Me.Controls.Add(Me.LabelForm_Office)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeTimeForecastNewDialog"
            Me.Text = "Add New Employee Time Forecast"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_Office As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TextBoxForm_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Office As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_AssignedEmployee As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_AssignedEmployee As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_ExcludeHoursEnteredInCopy As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_UpdateRevenueAmounts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_UpdateEmployeeRates As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_CopyFrom As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxForm_EmployeeTimeForecasts As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    End Class

End Namespace