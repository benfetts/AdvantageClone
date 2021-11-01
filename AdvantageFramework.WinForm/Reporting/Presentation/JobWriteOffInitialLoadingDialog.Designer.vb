Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class JobWriteOffInitialLoadingDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobWriteOffInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_StartingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_StartingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EndingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_EndingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ButtonForm_2Years = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_1Year = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_MTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.Button2YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_IncomeOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_EmployeeTime = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.Label1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_GroupByOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_Component = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(402, 173)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 9
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(483, 173)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 10
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ComboBoxForm_StartingPostPeriod
            '
            Me.ComboBoxForm_StartingPostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_StartingPostPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_StartingPostPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_StartingPostPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_StartingPostPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxForm_StartingPostPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_StartingPostPeriod.BookmarkingEnabled = False
            Me.ComboBoxForm_StartingPostPeriod.ClientCode = ""
            Me.ComboBoxForm_StartingPostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_StartingPostPeriod.DisableMouseWheel = False
            Me.ComboBoxForm_StartingPostPeriod.DisplayMember = "Description"
            Me.ComboBoxForm_StartingPostPeriod.DisplayName = ""
            Me.ComboBoxForm_StartingPostPeriod.DivisionCode = ""
            Me.ComboBoxForm_StartingPostPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_StartingPostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_StartingPostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_StartingPostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_StartingPostPeriod.FocusHighlightEnabled = True
            Me.ComboBoxForm_StartingPostPeriod.FormattingEnabled = True
            Me.ComboBoxForm_StartingPostPeriod.ItemHeight = 14
            Me.ComboBoxForm_StartingPostPeriod.Location = New System.Drawing.Point(124, 12)
            Me.ComboBoxForm_StartingPostPeriod.Name = "ComboBoxForm_StartingPostPeriod"
            Me.ComboBoxForm_StartingPostPeriod.PreventEnterBeep = False
            Me.ComboBoxForm_StartingPostPeriod.ReadOnly = False
            Me.ComboBoxForm_StartingPostPeriod.SecurityEnabled = True
            Me.ComboBoxForm_StartingPostPeriod.Size = New System.Drawing.Size(191, 20)
            Me.ComboBoxForm_StartingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_StartingPostPeriod.TabIndex = 1
            Me.ComboBoxForm_StartingPostPeriod.ValueMember = "Code"
            Me.ComboBoxForm_StartingPostPeriod.WatermarkText = "Select Post Period"
            '
            'LabelForm_StartingPostPeriod
            '
            Me.LabelForm_StartingPostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartingPostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartingPostPeriod.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_StartingPostPeriod.Name = "LabelForm_StartingPostPeriod"
            Me.LabelForm_StartingPostPeriod.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_StartingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartingPostPeriod.TabIndex = 0
            Me.LabelForm_StartingPostPeriod.Text = "Starting Post Period:"
            '
            'LabelForm_EndingPostPeriod
            '
            Me.LabelForm_EndingPostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EndingPostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EndingPostPeriod.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_EndingPostPeriod.Name = "LabelForm_EndingPostPeriod"
            Me.LabelForm_EndingPostPeriod.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_EndingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EndingPostPeriod.TabIndex = 2
            Me.LabelForm_EndingPostPeriod.Text = "Ending Post Period:"
            '
            'ComboBoxForm_EndingPostPeriod
            '
            Me.ComboBoxForm_EndingPostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_EndingPostPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_EndingPostPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_EndingPostPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_EndingPostPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxForm_EndingPostPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_EndingPostPeriod.BookmarkingEnabled = False
            Me.ComboBoxForm_EndingPostPeriod.ClientCode = ""
            Me.ComboBoxForm_EndingPostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_EndingPostPeriod.DisableMouseWheel = False
            Me.ComboBoxForm_EndingPostPeriod.DisplayMember = "Description"
            Me.ComboBoxForm_EndingPostPeriod.DisplayName = ""
            Me.ComboBoxForm_EndingPostPeriod.DivisionCode = ""
            Me.ComboBoxForm_EndingPostPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_EndingPostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_EndingPostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_EndingPostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_EndingPostPeriod.FocusHighlightEnabled = True
            Me.ComboBoxForm_EndingPostPeriod.FormattingEnabled = True
            Me.ComboBoxForm_EndingPostPeriod.ItemHeight = 14
            Me.ComboBoxForm_EndingPostPeriod.Location = New System.Drawing.Point(124, 38)
            Me.ComboBoxForm_EndingPostPeriod.Name = "ComboBoxForm_EndingPostPeriod"
            Me.ComboBoxForm_EndingPostPeriod.PreventEnterBeep = False
            Me.ComboBoxForm_EndingPostPeriod.ReadOnly = False
            Me.ComboBoxForm_EndingPostPeriod.SecurityEnabled = True
            Me.ComboBoxForm_EndingPostPeriod.Size = New System.Drawing.Size(191, 20)
            Me.ComboBoxForm_EndingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_EndingPostPeriod.TabIndex = 3
            Me.ComboBoxForm_EndingPostPeriod.ValueMember = "Code"
            Me.ComboBoxForm_EndingPostPeriod.WatermarkText = "Select Post Period"
            '
            'ButtonForm_2Years
            '
            Me.ButtonForm_2Years.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_2Years.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_2Years.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_2Years.Location = New System.Drawing.Point(402, 38)
            Me.ButtonForm_2Years.Name = "ButtonForm_2Years"
            Me.ButtonForm_2Years.SecurityEnabled = True
            Me.ButtonForm_2Years.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_2Years.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_2Years.TabIndex = 7
            Me.ButtonForm_2Years.Text = "2 Years"
            '
            'ButtonForm_1Year
            '
            Me.ButtonForm_1Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_1Year.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_1Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_1Year.Location = New System.Drawing.Point(402, 12)
            Me.ButtonForm_1Year.Name = "ButtonForm_1Year"
            Me.ButtonForm_1Year.SecurityEnabled = True
            Me.ButtonForm_1Year.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_1Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_1Year.TabIndex = 5
            Me.ButtonForm_1Year.Text = "1 Year"
            '
            'ButtonForm_MTD
            '
            Me.ButtonForm_MTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_MTD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_MTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_MTD.Location = New System.Drawing.Point(321, 38)
            Me.ButtonForm_MTD.Name = "ButtonForm_MTD"
            Me.ButtonForm_MTD.SecurityEnabled = True
            Me.ButtonForm_MTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_MTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_MTD.TabIndex = 6
            Me.ButtonForm_MTD.Text = "MTD"
            '
            'ButtonForm_YTD
            '
            Me.ButtonForm_YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_YTD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_YTD.Location = New System.Drawing.Point(321, 12)
            Me.ButtonForm_YTD.Name = "ButtonForm_YTD"
            Me.ButtonForm_YTD.SecurityEnabled = True
            Me.ButtonForm_YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_YTD.TabIndex = 4
            Me.ButtonForm_YTD.Text = "YTD"
            '
            'Button2YTD
            '
            Me.Button2YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.Button2YTD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Button2YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.Button2YTD.Location = New System.Drawing.Point(483, 12)
            Me.Button2YTD.Name = "Button2YTD"
            Me.Button2YTD.SecurityEnabled = True
            Me.Button2YTD.Size = New System.Drawing.Size(75, 20)
            Me.Button2YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Button2YTD.TabIndex = 8
            Me.Button2YTD.Text = "2 YTD"
            '
            'CheckBoxForm_IncomeOnly
            '
            '
            '
            '
            Me.CheckBoxForm_IncomeOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IncomeOnly.CheckValue = 0
            Me.CheckBoxForm_IncomeOnly.CheckValueChecked = 1
            Me.CheckBoxForm_IncomeOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IncomeOnly.CheckValueUnchecked = 0
            Me.CheckBoxForm_IncomeOnly.ChildControls = CType(resources.GetObject("CheckBoxForm_IncomeOnly.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncomeOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IncomeOnly.Location = New System.Drawing.Point(222, 92)
            Me.CheckBoxForm_IncomeOnly.Name = "CheckBoxForm_IncomeOnly"
            Me.CheckBoxForm_IncomeOnly.OldestSibling = Nothing
            Me.CheckBoxForm_IncomeOnly.SecurityEnabled = True
            Me.CheckBoxForm_IncomeOnly.SiblingControls = CType(resources.GetObject("CheckBoxForm_IncomeOnly.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncomeOnly.Size = New System.Drawing.Size(154, 20)
            Me.CheckBoxForm_IncomeOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IncomeOnly.TabIndex = 31
            Me.CheckBoxForm_IncomeOnly.Text = "Income Only"
            '
            'CheckBoxForm_Vendor
            '
            '
            '
            '
            Me.CheckBoxForm_Vendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Vendor.CheckValue = 0
            Me.CheckBoxForm_Vendor.CheckValueChecked = 1
            Me.CheckBoxForm_Vendor.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Vendor.CheckValueUnchecked = 0
            Me.CheckBoxForm_Vendor.ChildControls = CType(resources.GetObject("CheckBoxForm_Vendor.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Vendor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Vendor.Location = New System.Drawing.Point(140, 92)
            Me.CheckBoxForm_Vendor.Name = "CheckBoxForm_Vendor"
            Me.CheckBoxForm_Vendor.OldestSibling = Nothing
            Me.CheckBoxForm_Vendor.SecurityEnabled = True
            Me.CheckBoxForm_Vendor.SiblingControls = CType(resources.GetObject("CheckBoxForm_Vendor.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Vendor.Size = New System.Drawing.Size(76, 20)
            Me.CheckBoxForm_Vendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Vendor.TabIndex = 30
            Me.CheckBoxForm_Vendor.Text = "Vendor"
            '
            'CheckBoxForm_EmployeeTime
            '
            '
            '
            '
            Me.CheckBoxForm_EmployeeTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_EmployeeTime.CheckValue = 0
            Me.CheckBoxForm_EmployeeTime.CheckValueChecked = 1
            Me.CheckBoxForm_EmployeeTime.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_EmployeeTime.CheckValueUnchecked = 0
            Me.CheckBoxForm_EmployeeTime.ChildControls = CType(resources.GetObject("CheckBoxForm_EmployeeTime.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_EmployeeTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_EmployeeTime.Location = New System.Drawing.Point(12, 92)
            Me.CheckBoxForm_EmployeeTime.Name = "CheckBoxForm_EmployeeTime"
            Me.CheckBoxForm_EmployeeTime.OldestSibling = Nothing
            Me.CheckBoxForm_EmployeeTime.SecurityEnabled = True
            Me.CheckBoxForm_EmployeeTime.SiblingControls = CType(resources.GetObject("CheckBoxForm_EmployeeTime.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_EmployeeTime.Size = New System.Drawing.Size(106, 20)
            Me.CheckBoxForm_EmployeeTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_EmployeeTime.TabIndex = 29
            Me.CheckBoxForm_EmployeeTime.Text = "Employee Time"
            '
            'Label1
            '
            Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.Label1.BackgroundStyle.BorderBottomWidth = 1
            Me.Label1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(12, 66)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(546, 20)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 28
            Me.Label1.Text = "Include Options"
            '
            'LabelForm_GroupByOptions
            '
            Me.LabelForm_GroupByOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_GroupByOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_GroupByOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_GroupByOptions.Location = New System.Drawing.Point(12, 118)
            Me.LabelForm_GroupByOptions.Name = "LabelForm_GroupByOptions"
            Me.LabelForm_GroupByOptions.Size = New System.Drawing.Size(546, 20)
            Me.LabelForm_GroupByOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_GroupByOptions.TabIndex = 32
            Me.LabelForm_GroupByOptions.Text = "Group By Options"
            '
            'CheckBoxForm_Component
            '
            '
            '
            '
            Me.CheckBoxForm_Component.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Component.CheckValue = 0
            Me.CheckBoxForm_Component.CheckValueChecked = 1
            Me.CheckBoxForm_Component.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Component.CheckValueUnchecked = 0
            Me.CheckBoxForm_Component.ChildControls = CType(resources.GetObject("CheckBoxForm_Component.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Component.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Component.Location = New System.Drawing.Point(12, 144)
            Me.CheckBoxForm_Component.Name = "CheckBoxForm_Component"
            Me.CheckBoxForm_Component.OldestSibling = Nothing
            Me.CheckBoxForm_Component.SecurityEnabled = True
            Me.CheckBoxForm_Component.SiblingControls = CType(resources.GetObject("CheckBoxForm_Component.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Component.Size = New System.Drawing.Size(106, 20)
            Me.CheckBoxForm_Component.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Component.TabIndex = 33
            Me.CheckBoxForm_Component.Text = "Component"
            '
            'JobWriteOffInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(570, 205)
            Me.Controls.Add(Me.LabelForm_GroupByOptions)
            Me.Controls.Add(Me.CheckBoxForm_Component)
            Me.Controls.Add(Me.CheckBoxForm_IncomeOnly)
            Me.Controls.Add(Me.CheckBoxForm_Vendor)
            Me.Controls.Add(Me.CheckBoxForm_EmployeeTime)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.Button2YTD)
            Me.Controls.Add(Me.ButtonForm_2Years)
            Me.Controls.Add(Me.ButtonForm_1Year)
            Me.Controls.Add(Me.ButtonForm_MTD)
            Me.Controls.Add(Me.ButtonForm_YTD)
            Me.Controls.Add(Me.LabelForm_EndingPostPeriod)
            Me.Controls.Add(Me.ComboBoxForm_EndingPostPeriod)
            Me.Controls.Add(Me.LabelForm_StartingPostPeriod)
            Me.Controls.Add(Me.ComboBoxForm_StartingPostPeriod)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "JobWriteOffInitialLoadingDialog"
            Me.Text = "Job Write Off Initial Criteria"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_StartingPostPeriod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_StartingPostPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_EndingPostPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_EndingPostPeriod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ButtonForm_2Years As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_1Year As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_MTD As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_YTD As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents Button2YTD As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxForm_IncomeOnly As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_Vendor As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_EmployeeTime As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents Label1 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_GroupByOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_Component As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace