Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ServiceFeeInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServiceFeeInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_StartingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_StartingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_EndingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_EndingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_GroupByOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_FeeType = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_FunctionCode = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_FunctionHeading = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ButtonForm_2Years = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_1Year = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_MTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_2YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_JobNumber = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_FunctionConsolidation = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_Date = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonForm_EmployeeDefaultDept = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_EmployeeTimeEntryDept = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelForm_Option = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonForm_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxForm_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(477, 199)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 16
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(558, 199)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 17
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
            Me.ComboBoxForm_StartingPostPeriod.Size = New System.Drawing.Size(266, 20)
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
            'CheckBoxForm_Campaign
            '
            '
            '
            '
            Me.CheckBoxForm_Campaign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Campaign.CheckValue = 0
            Me.CheckBoxForm_Campaign.CheckValueChecked = 1
            Me.CheckBoxForm_Campaign.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Campaign.CheckValueUnchecked = 0
            Me.CheckBoxForm_Campaign.ChildControls = CType(resources.GetObject("CheckBoxForm_Campaign.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Campaign.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Campaign.Location = New System.Drawing.Point(270, 120)
            Me.CheckBoxForm_Campaign.Name = "CheckBoxForm_Campaign"
            Me.CheckBoxForm_Campaign.OldestSibling = Nothing
            Me.CheckBoxForm_Campaign.SecurityEnabled = True
            Me.CheckBoxForm_Campaign.SiblingControls = CType(resources.GetObject("CheckBoxForm_Campaign.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Campaign.Size = New System.Drawing.Size(75, 20)
            Me.CheckBoxForm_Campaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Campaign.TabIndex = 8
            Me.CheckBoxForm_Campaign.Text = "Campaign"
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
            Me.ComboBoxForm_EndingPostPeriod.Size = New System.Drawing.Size(266, 20)
            Me.ComboBoxForm_EndingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_EndingPostPeriod.TabIndex = 3
            Me.ComboBoxForm_EndingPostPeriod.ValueMember = "Code"
            Me.ComboBoxForm_EndingPostPeriod.WatermarkText = "Select Post Period"
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
            Me.LabelForm_GroupByOptions.Location = New System.Drawing.Point(12, 92)
            Me.LabelForm_GroupByOptions.Name = "LabelForm_GroupByOptions"
            Me.LabelForm_GroupByOptions.Size = New System.Drawing.Size(621, 20)
            Me.LabelForm_GroupByOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_GroupByOptions.TabIndex = 7
            Me.LabelForm_GroupByOptions.Text = "Group By Options"
            '
            'CheckBoxForm_Client
            '
            '
            '
            '
            Me.CheckBoxForm_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Client.CheckValue = 0
            Me.CheckBoxForm_Client.CheckValueChecked = 1
            Me.CheckBoxForm_Client.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Client.CheckValueUnchecked = 0
            Me.CheckBoxForm_Client.ChildControls = CType(resources.GetObject("CheckBoxForm_Client.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Client.Location = New System.Drawing.Point(12, 120)
            Me.CheckBoxForm_Client.Name = "CheckBoxForm_Client"
            Me.CheckBoxForm_Client.OldestSibling = Nothing
            Me.CheckBoxForm_Client.SecurityEnabled = True
            Me.CheckBoxForm_Client.SiblingControls = CType(resources.GetObject("CheckBoxForm_Client.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Client.Size = New System.Drawing.Size(85, 20)
            Me.CheckBoxForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Client.TabIndex = 9
            Me.CheckBoxForm_Client.Text = "Client"
            '
            'CheckBoxForm_Division
            '
            '
            '
            '
            Me.CheckBoxForm_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Division.CheckValue = 0
            Me.CheckBoxForm_Division.CheckValueChecked = 1
            Me.CheckBoxForm_Division.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Division.CheckValueUnchecked = 0
            Me.CheckBoxForm_Division.ChildControls = CType(resources.GetObject("CheckBoxForm_Division.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Division.Location = New System.Drawing.Point(93, 120)
            Me.CheckBoxForm_Division.Name = "CheckBoxForm_Division"
            Me.CheckBoxForm_Division.OldestSibling = Nothing
            Me.CheckBoxForm_Division.SecurityEnabled = True
            Me.CheckBoxForm_Division.SiblingControls = CType(resources.GetObject("CheckBoxForm_Division.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Division.Size = New System.Drawing.Size(80, 20)
            Me.CheckBoxForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Division.TabIndex = 10
            Me.CheckBoxForm_Division.Text = "Division"
            '
            'CheckBoxForm_Product
            '
            '
            '
            '
            Me.CheckBoxForm_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Product.CheckValue = 0
            Me.CheckBoxForm_Product.CheckValueChecked = 1
            Me.CheckBoxForm_Product.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Product.CheckValueUnchecked = 0
            Me.CheckBoxForm_Product.ChildControls = CType(resources.GetObject("CheckBoxForm_Product.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Product.Location = New System.Drawing.Point(184, 120)
            Me.CheckBoxForm_Product.Name = "CheckBoxForm_Product"
            Me.CheckBoxForm_Product.OldestSibling = Nothing
            Me.CheckBoxForm_Product.SecurityEnabled = True
            Me.CheckBoxForm_Product.SiblingControls = CType(resources.GetObject("CheckBoxForm_Product.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Product.Size = New System.Drawing.Size(62, 20)
            Me.CheckBoxForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Product.TabIndex = 11
            Me.CheckBoxForm_Product.Text = "Product"
            '
            'CheckBoxForm_FeeType
            '
            '
            '
            '
            Me.CheckBoxForm_FeeType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_FeeType.CheckValue = 0
            Me.CheckBoxForm_FeeType.CheckValueChecked = 1
            Me.CheckBoxForm_FeeType.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_FeeType.CheckValueUnchecked = 0
            Me.CheckBoxForm_FeeType.ChildControls = CType(resources.GetObject("CheckBoxForm_FeeType.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_FeeType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_FeeType.Location = New System.Drawing.Point(12, 146)
            Me.CheckBoxForm_FeeType.Name = "CheckBoxForm_FeeType"
            Me.CheckBoxForm_FeeType.OldestSibling = Nothing
            Me.CheckBoxForm_FeeType.SecurityEnabled = True
            Me.CheckBoxForm_FeeType.SiblingControls = CType(resources.GetObject("CheckBoxForm_FeeType.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_FeeType.Size = New System.Drawing.Size(75, 20)
            Me.CheckBoxForm_FeeType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_FeeType.TabIndex = 12
            Me.CheckBoxForm_FeeType.Text = "Fee Type"
            '
            'CheckBoxForm_SalesClass
            '
            '
            '
            '
            Me.CheckBoxForm_SalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_SalesClass.CheckValue = 0
            Me.CheckBoxForm_SalesClass.CheckValueChecked = 1
            Me.CheckBoxForm_SalesClass.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_SalesClass.CheckValueUnchecked = 0
            Me.CheckBoxForm_SalesClass.ChildControls = CType(resources.GetObject("CheckBoxForm_SalesClass.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_SalesClass.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_SalesClass.Location = New System.Drawing.Point(351, 120)
            Me.CheckBoxForm_SalesClass.Name = "CheckBoxForm_SalesClass"
            Me.CheckBoxForm_SalesClass.OldestSibling = Nothing
            Me.CheckBoxForm_SalesClass.SecurityEnabled = True
            Me.CheckBoxForm_SalesClass.SiblingControls = CType(resources.GetObject("CheckBoxForm_SalesClass.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_SalesClass.Size = New System.Drawing.Size(85, 20)
            Me.CheckBoxForm_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_SalesClass.TabIndex = 13
            Me.CheckBoxForm_SalesClass.Text = "Sales Class"
            '
            'CheckBoxForm_FunctionCode
            '
            '
            '
            '
            Me.CheckBoxForm_FunctionCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_FunctionCode.CheckValue = 0
            Me.CheckBoxForm_FunctionCode.CheckValueChecked = 1
            Me.CheckBoxForm_FunctionCode.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_FunctionCode.CheckValueUnchecked = 0
            Me.CheckBoxForm_FunctionCode.ChildControls = CType(resources.GetObject("CheckBoxForm_FunctionCode.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_FunctionCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_FunctionCode.Location = New System.Drawing.Point(93, 146)
            Me.CheckBoxForm_FunctionCode.Name = "CheckBoxForm_FunctionCode"
            Me.CheckBoxForm_FunctionCode.OldestSibling = Nothing
            Me.CheckBoxForm_FunctionCode.SecurityEnabled = True
            Me.CheckBoxForm_FunctionCode.SiblingControls = CType(resources.GetObject("CheckBoxForm_FunctionCode.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_FunctionCode.Size = New System.Drawing.Size(80, 20)
            Me.CheckBoxForm_FunctionCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_FunctionCode.TabIndex = 14
            Me.CheckBoxForm_FunctionCode.Text = "Function"
            '
            'CheckBoxForm_FunctionHeading
            '
            '
            '
            '
            Me.CheckBoxForm_FunctionHeading.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_FunctionHeading.CheckValue = 0
            Me.CheckBoxForm_FunctionHeading.CheckValueChecked = 1
            Me.CheckBoxForm_FunctionHeading.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_FunctionHeading.CheckValueUnchecked = 0
            Me.CheckBoxForm_FunctionHeading.ChildControls = CType(resources.GetObject("CheckBoxForm_FunctionHeading.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_FunctionHeading.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_FunctionHeading.Location = New System.Drawing.Point(184, 146)
            Me.CheckBoxForm_FunctionHeading.Name = "CheckBoxForm_FunctionHeading"
            Me.CheckBoxForm_FunctionHeading.OldestSibling = Nothing
            Me.CheckBoxForm_FunctionHeading.SecurityEnabled = True
            Me.CheckBoxForm_FunctionHeading.SiblingControls = CType(resources.GetObject("CheckBoxForm_FunctionHeading.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_FunctionHeading.Size = New System.Drawing.Size(113, 20)
            Me.CheckBoxForm_FunctionHeading.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_FunctionHeading.TabIndex = 15
            Me.CheckBoxForm_FunctionHeading.Text = "Function Heading"
            '
            'ButtonForm_2Years
            '
            Me.ButtonForm_2Years.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_2Years.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_2Years.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_2Years.Location = New System.Drawing.Point(477, 38)
            Me.ButtonForm_2Years.Name = "ButtonForm_2Years"
            Me.ButtonForm_2Years.SecurityEnabled = True
            Me.ButtonForm_2Years.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_2Years.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_2Years.TabIndex = 21
            Me.ButtonForm_2Years.Text = "2 Years"
            '
            'ButtonForm_1Year
            '
            Me.ButtonForm_1Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_1Year.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_1Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_1Year.Location = New System.Drawing.Point(477, 12)
            Me.ButtonForm_1Year.Name = "ButtonForm_1Year"
            Me.ButtonForm_1Year.SecurityEnabled = True
            Me.ButtonForm_1Year.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_1Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_1Year.TabIndex = 19
            Me.ButtonForm_1Year.Text = "1 Year"
            '
            'ButtonForm_MTD
            '
            Me.ButtonForm_MTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_MTD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_MTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_MTD.Location = New System.Drawing.Point(396, 38)
            Me.ButtonForm_MTD.Name = "ButtonForm_MTD"
            Me.ButtonForm_MTD.SecurityEnabled = True
            Me.ButtonForm_MTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_MTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_MTD.TabIndex = 20
            Me.ButtonForm_MTD.Text = "MTD"
            '
            'ButtonForm_YTD
            '
            Me.ButtonForm_YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_YTD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_YTD.Location = New System.Drawing.Point(396, 12)
            Me.ButtonForm_YTD.Name = "ButtonForm_YTD"
            Me.ButtonForm_YTD.SecurityEnabled = True
            Me.ButtonForm_YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_YTD.TabIndex = 18
            Me.ButtonForm_YTD.Text = "YTD"
            '
            'ButtonForm_2YTD
            '
            Me.ButtonForm_2YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_2YTD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_2YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_2YTD.Location = New System.Drawing.Point(558, 12)
            Me.ButtonForm_2YTD.Name = "ButtonForm_2YTD"
            Me.ButtonForm_2YTD.SecurityEnabled = True
            Me.ButtonForm_2YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_2YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_2YTD.TabIndex = 22
            Me.ButtonForm_2YTD.Text = "2 YTD"
            '
            'CheckBoxForm_JobNumber
            '
            '
            '
            '
            Me.CheckBoxForm_JobNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_JobNumber.CheckValue = 0
            Me.CheckBoxForm_JobNumber.CheckValueChecked = 1
            Me.CheckBoxForm_JobNumber.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_JobNumber.CheckValueUnchecked = 0
            Me.CheckBoxForm_JobNumber.ChildControls = CType(resources.GetObject("CheckBoxForm_JobNumber.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_JobNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_JobNumber.Location = New System.Drawing.Point(442, 120)
            Me.CheckBoxForm_JobNumber.Name = "CheckBoxForm_JobNumber"
            Me.CheckBoxForm_JobNumber.OldestSibling = Nothing
            Me.CheckBoxForm_JobNumber.SecurityEnabled = True
            Me.CheckBoxForm_JobNumber.SiblingControls = CType(resources.GetObject("CheckBoxForm_JobNumber.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_JobNumber.Size = New System.Drawing.Size(85, 20)
            Me.CheckBoxForm_JobNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_JobNumber.TabIndex = 23
            Me.CheckBoxForm_JobNumber.Text = "Job Number"
            '
            'CheckBoxForm_FunctionConsolidation
            '
            '
            '
            '
            Me.CheckBoxForm_FunctionConsolidation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_FunctionConsolidation.CheckValue = 0
            Me.CheckBoxForm_FunctionConsolidation.CheckValueChecked = 1
            Me.CheckBoxForm_FunctionConsolidation.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_FunctionConsolidation.CheckValueUnchecked = 0
            Me.CheckBoxForm_FunctionConsolidation.ChildControls = CType(resources.GetObject("CheckBoxForm_FunctionConsolidation.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_FunctionConsolidation.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_FunctionConsolidation.Location = New System.Drawing.Point(303, 146)
            Me.CheckBoxForm_FunctionConsolidation.Name = "CheckBoxForm_FunctionConsolidation"
            Me.CheckBoxForm_FunctionConsolidation.OldestSibling = Nothing
            Me.CheckBoxForm_FunctionConsolidation.SecurityEnabled = True
            Me.CheckBoxForm_FunctionConsolidation.SiblingControls = CType(resources.GetObject("CheckBoxForm_FunctionConsolidation.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_FunctionConsolidation.Size = New System.Drawing.Size(93, 20)
            Me.CheckBoxForm_FunctionConsolidation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_FunctionConsolidation.TabIndex = 24
            Me.CheckBoxForm_FunctionConsolidation.Text = "Consolidation"
            '
            'CheckBoxForm_Employee
            '
            '
            '
            '
            Me.CheckBoxForm_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Employee.CheckValue = 0
            Me.CheckBoxForm_Employee.CheckValueChecked = 1
            Me.CheckBoxForm_Employee.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Employee.CheckValueUnchecked = 0
            Me.CheckBoxForm_Employee.ChildControls = CType(resources.GetObject("CheckBoxForm_Employee.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Employee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Employee.Location = New System.Drawing.Point(402, 146)
            Me.CheckBoxForm_Employee.Name = "CheckBoxForm_Employee"
            Me.CheckBoxForm_Employee.OldestSibling = Nothing
            Me.CheckBoxForm_Employee.SecurityEnabled = True
            Me.CheckBoxForm_Employee.SiblingControls = CType(resources.GetObject("CheckBoxForm_Employee.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Employee.Size = New System.Drawing.Size(75, 20)
            Me.CheckBoxForm_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Employee.TabIndex = 25
            Me.CheckBoxForm_Employee.Text = "Employee"
            '
            'CheckBoxForm_Date
            '
            '
            '
            '
            Me.CheckBoxForm_Date.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Date.CheckValue = 0
            Me.CheckBoxForm_Date.CheckValueChecked = 1
            Me.CheckBoxForm_Date.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Date.CheckValueUnchecked = 0
            Me.CheckBoxForm_Date.ChildControls = CType(resources.GetObject("CheckBoxForm_Date.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Date.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Date.Location = New System.Drawing.Point(483, 146)
            Me.CheckBoxForm_Date.Name = "CheckBoxForm_Date"
            Me.CheckBoxForm_Date.OldestSibling = Nothing
            Me.CheckBoxForm_Date.SecurityEnabled = True
            Me.CheckBoxForm_Date.SiblingControls = CType(resources.GetObject("CheckBoxForm_Date.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Date.Size = New System.Drawing.Size(75, 20)
            Me.CheckBoxForm_Date.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Date.TabIndex = 26
            Me.CheckBoxForm_Date.Text = "Date"
            '
            'RadioButtonForm_EmployeeDefaultDept
            '
            Me.RadioButtonForm_EmployeeDefaultDept.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_EmployeeDefaultDept.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_EmployeeDefaultDept.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_EmployeeDefaultDept.Checked = True
            Me.RadioButtonForm_EmployeeDefaultDept.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_EmployeeDefaultDept.CheckValue = "Y"
            Me.RadioButtonForm_EmployeeDefaultDept.Location = New System.Drawing.Point(124, 66)
            Me.RadioButtonForm_EmployeeDefaultDept.Name = "RadioButtonForm_EmployeeDefaultDept"
            Me.RadioButtonForm_EmployeeDefaultDept.SecurityEnabled = True
            Me.RadioButtonForm_EmployeeDefaultDept.Size = New System.Drawing.Size(180, 20)
            Me.RadioButtonForm_EmployeeDefaultDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_EmployeeDefaultDept.TabIndex = 28
            Me.RadioButtonForm_EmployeeDefaultDept.Text = "Employee Default Department"
            '
            'RadioButtonForm_EmployeeTimeEntryDept
            '
            Me.RadioButtonForm_EmployeeTimeEntryDept.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_EmployeeTimeEntryDept.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_EmployeeTimeEntryDept.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_EmployeeTimeEntryDept.Location = New System.Drawing.Point(310, 66)
            Me.RadioButtonForm_EmployeeTimeEntryDept.Name = "RadioButtonForm_EmployeeTimeEntryDept"
            Me.RadioButtonForm_EmployeeTimeEntryDept.SecurityEnabled = True
            Me.RadioButtonForm_EmployeeTimeEntryDept.Size = New System.Drawing.Size(200, 20)
            Me.RadioButtonForm_EmployeeTimeEntryDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_EmployeeTimeEntryDept.TabIndex = 29
            Me.RadioButtonForm_EmployeeTimeEntryDept.TabStop = False
            Me.RadioButtonForm_EmployeeTimeEntryDept.Text = "Employee Time Entry Department"
            '
            'LabelForm_Option
            '
            Me.LabelForm_Option.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Option.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Option.Location = New System.Drawing.Point(12, 66)
            Me.LabelForm_Option.Name = "LabelForm_Option"
            Me.LabelForm_Option.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_Option.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Option.TabIndex = 27
            Me.LabelForm_Option.Text = "Option for Fee Time:"
            '
            'RadioButtonForm_JobComponent
            '
            Me.RadioButtonForm_JobComponent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_JobComponent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_JobComponent.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_JobComponent.Location = New System.Drawing.Point(516, 66)
            Me.RadioButtonForm_JobComponent.Name = "RadioButtonForm_JobComponent"
            Me.RadioButtonForm_JobComponent.SecurityEnabled = True
            Me.RadioButtonForm_JobComponent.Size = New System.Drawing.Size(117, 20)
            Me.RadioButtonForm_JobComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_JobComponent.TabIndex = 30
            Me.RadioButtonForm_JobComponent.TabStop = False
            Me.RadioButtonForm_JobComponent.Text = "Job/Component"
            '
            'CheckBoxForm_PostPeriod
            '
            '
            '
            '
            Me.CheckBoxForm_PostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_PostPeriod.CheckValue = 0
            Me.CheckBoxForm_PostPeriod.CheckValueChecked = 1
            Me.CheckBoxForm_PostPeriod.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_PostPeriod.CheckValueUnchecked = 0
            Me.CheckBoxForm_PostPeriod.ChildControls = CType(resources.GetObject("CheckBoxForm_PostPeriod.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_PostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_PostPeriod.Location = New System.Drawing.Point(12, 172)
            Me.CheckBoxForm_PostPeriod.Name = "CheckBoxForm_PostPeriod"
            Me.CheckBoxForm_PostPeriod.OldestSibling = Nothing
            Me.CheckBoxForm_PostPeriod.SecurityEnabled = True
            Me.CheckBoxForm_PostPeriod.SiblingControls = CType(resources.GetObject("CheckBoxForm_PostPeriod.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_PostPeriod.Size = New System.Drawing.Size(85, 20)
            Me.CheckBoxForm_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_PostPeriod.TabIndex = 31
            Me.CheckBoxForm_PostPeriod.Text = "Post Period"
            '
            'ServiceFeeInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(645, 231)
            Me.Controls.Add(Me.CheckBoxForm_PostPeriod)
            Me.Controls.Add(Me.RadioButtonForm_JobComponent)
            Me.Controls.Add(Me.RadioButtonForm_EmployeeDefaultDept)
            Me.Controls.Add(Me.RadioButtonForm_EmployeeTimeEntryDept)
            Me.Controls.Add(Me.LabelForm_Option)
            Me.Controls.Add(Me.CheckBoxForm_Date)
            Me.Controls.Add(Me.CheckBoxForm_Employee)
            Me.Controls.Add(Me.CheckBoxForm_FunctionConsolidation)
            Me.Controls.Add(Me.CheckBoxForm_JobNumber)
            Me.Controls.Add(Me.ButtonForm_2YTD)
            Me.Controls.Add(Me.ButtonForm_2Years)
            Me.Controls.Add(Me.ButtonForm_1Year)
            Me.Controls.Add(Me.ButtonForm_MTD)
            Me.Controls.Add(Me.ButtonForm_YTD)
            Me.Controls.Add(Me.CheckBoxForm_FunctionHeading)
            Me.Controls.Add(Me.CheckBoxForm_FunctionCode)
            Me.Controls.Add(Me.CheckBoxForm_SalesClass)
            Me.Controls.Add(Me.CheckBoxForm_FeeType)
            Me.Controls.Add(Me.CheckBoxForm_Product)
            Me.Controls.Add(Me.CheckBoxForm_Division)
            Me.Controls.Add(Me.CheckBoxForm_Client)
            Me.Controls.Add(Me.LabelForm_GroupByOptions)
            Me.Controls.Add(Me.LabelForm_EndingPostPeriod)
            Me.Controls.Add(Me.ComboBoxForm_EndingPostPeriod)
            Me.Controls.Add(Me.CheckBoxForm_Campaign)
            Me.Controls.Add(Me.LabelForm_StartingPostPeriod)
            Me.Controls.Add(Me.ComboBoxForm_StartingPostPeriod)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ServiceFeeInitialLoadingDialog"
            Me.Text = "Service Fee Initial Criteria"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_StartingPostPeriod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_StartingPostPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_Campaign As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_EndingPostPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_EndingPostPeriod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_GroupByOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_Client As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_Division As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_Product As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_FeeType As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_FunctionCode As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_FunctionHeading As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ButtonForm_2Years As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_1Year As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_MTD As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_YTD As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_2YTD As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxForm_JobNumber As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_FunctionConsolidation As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_Date As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonForm_EmployeeDefaultDept As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_EmployeeTimeEntryDept As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelForm_Option As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonForm_JobComponent As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxForm_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace