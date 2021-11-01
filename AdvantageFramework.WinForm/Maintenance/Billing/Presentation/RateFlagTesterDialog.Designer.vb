Namespace Maintenance.Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class RateFlagTesterDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RateFlagTesterDialog))
            Me.ButtonForm_Close = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Process = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Select = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Job = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Function = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EffectiveDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_Job = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_Function = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Taxable = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Commission = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_NonBillable = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Rate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_TaxCommission = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_TaxCommissionOnly = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_FeeTime = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_TaxCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_TaxCodeLevel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_RateLevel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_NonBillableLevel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_CommissionLevel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_CommissionPlaceholder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_TaxCodePlaceholder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_FeeTimePlaceholder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_RateLevelPlaceholder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_NonBillableLevelPlaceholder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_CommissionLevelPlaceholder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_TaxCodeLevelPlaceholder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_FeeTimeLevelPlaceholder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_EffectiveDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_FeeTimeLevel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Reset = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Results = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PictureBoxForm_NonBillable = New System.Windows.Forms.PictureBox()
            Me.PictureBoxForm_Taxable = New System.Windows.Forms.PictureBox()
            Me.PictureBoxForm_TaxCommission = New System.Windows.Forms.PictureBox()
            Me.PictureBoxForm_TaxCommissionOnly = New System.Windows.Forms.PictureBox()
            Me.LabelForm_RatePlaceholder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_BillNet = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PictureBoxForm_BillNet = New System.Windows.Forms.PictureBox()
            CType(Me.DateTimePickerForm_EffectiveDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBoxForm_NonBillable, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBoxForm_Taxable, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBoxForm_TaxCommission, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBoxForm_TaxCommissionOnly, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBoxForm_BillNet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Close
            '
            Me.ButtonForm_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Close.Location = New System.Drawing.Point(609, 376)
            Me.ButtonForm_Close.Name = "ButtonForm_Close"
            Me.ButtonForm_Close.SecurityEnabled = True
            Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Close.TabIndex = 45
            Me.ButtonForm_Close.Text = "Close"
            '
            'ButtonForm_Process
            '
            Me.ButtonForm_Process.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Process.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Process.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Process.Location = New System.Drawing.Point(447, 376)
            Me.ButtonForm_Process.Name = "ButtonForm_Process"
            Me.ButtonForm_Process.SecurityEnabled = True
            Me.ButtonForm_Process.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Process.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Process.TabIndex = 43
            Me.ButtonForm_Process.Text = "Process"
            '
            'LabelForm_Client
            '
            Me.LabelForm_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Client.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Client.Name = "LabelForm_Client"
            Me.LabelForm_Client.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Client.TabIndex = 1
            Me.LabelForm_Client.Text = "Client:"
            '
            'LabelForm_Select
            '
            Me.LabelForm_Select.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Select.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Select.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_Select.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_Select.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Select.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Select.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Select.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Select.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_Select.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_Select.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Select.Name = "LabelForm_Select"
            Me.LabelForm_Select.Size = New System.Drawing.Size(672, 20)
            Me.LabelForm_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Select.TabIndex = 0
            Me.LabelForm_Select.Text = "Select"
            '
            'LabelForm_Division
            '
            Me.LabelForm_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Division.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_Division.Name = "LabelForm_Division"
            Me.LabelForm_Division.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Division.TabIndex = 3
            Me.LabelForm_Division.Text = "Division:"
            '
            'LabelForm_Product
            '
            Me.LabelForm_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Product.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_Product.Name = "LabelForm_Product"
            Me.LabelForm_Product.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Product.TabIndex = 5
            Me.LabelForm_Product.Text = "Product:"
            '
            'LabelForm_Job
            '
            Me.LabelForm_Job.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Job.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Job.Location = New System.Drawing.Point(12, 116)
            Me.LabelForm_Job.Name = "LabelForm_Job"
            Me.LabelForm_Job.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Job.TabIndex = 7
            Me.LabelForm_Job.Text = "Job:"
            '
            'LabelForm_JobComponent
            '
            Me.LabelForm_JobComponent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_JobComponent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_JobComponent.Location = New System.Drawing.Point(12, 142)
            Me.LabelForm_JobComponent.Name = "LabelForm_JobComponent"
            Me.LabelForm_JobComponent.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_JobComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_JobComponent.TabIndex = 9
            Me.LabelForm_JobComponent.Text = "Job Component:"
            '
            'LabelForm_SalesClass
            '
            Me.LabelForm_SalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SalesClass.Location = New System.Drawing.Point(351, 38)
            Me.LabelForm_SalesClass.Name = "LabelForm_SalesClass"
            Me.LabelForm_SalesClass.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SalesClass.TabIndex = 11
            Me.LabelForm_SalesClass.Text = "Sales Class:"
            '
            'LabelForm_Function
            '
            Me.LabelForm_Function.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Function.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Function.Location = New System.Drawing.Point(351, 64)
            Me.LabelForm_Function.Name = "LabelForm_Function"
            Me.LabelForm_Function.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_Function.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Function.TabIndex = 13
            Me.LabelForm_Function.Text = "Function:"
            '
            'LabelForm_Employee
            '
            Me.LabelForm_Employee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Employee.Location = New System.Drawing.Point(351, 90)
            Me.LabelForm_Employee.Name = "LabelForm_Employee"
            Me.LabelForm_Employee.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Employee.TabIndex = 15
            Me.LabelForm_Employee.Text = "Employee:"
            '
            'LabelForm_EffectiveDate
            '
            Me.LabelForm_EffectiveDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EffectiveDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EffectiveDate.Location = New System.Drawing.Point(351, 116)
            Me.LabelForm_EffectiveDate.Name = "LabelForm_EffectiveDate"
            Me.LabelForm_EffectiveDate.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_EffectiveDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EffectiveDate.TabIndex = 17
            Me.LabelForm_EffectiveDate.Text = "Effective Date:"
            '
            'ComboBoxForm_Client
            '
            Me.ComboBoxForm_Client.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Client.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Client.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Client.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Client.BookmarkingEnabled = False
            Me.ComboBoxForm_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Client
            Me.ComboBoxForm_Client.DisableMouseWheel = False
            Me.ComboBoxForm_Client.DisplayMember = "Name"
            Me.ComboBoxForm_Client.DisplayName = ""
            Me.ComboBoxForm_Client.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Client.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Client.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Client.FocusHighlightEnabled = True
            Me.ComboBoxForm_Client.FormattingEnabled = True
            Me.ComboBoxForm_Client.ItemHeight = 14
            Me.ComboBoxForm_Client.Location = New System.Drawing.Point(102, 38)
            Me.ComboBoxForm_Client.Name = "ComboBoxForm_Client"
            Me.ComboBoxForm_Client.PreventEnterBeep = False
            Me.ComboBoxForm_Client.ReadOnly = False
            Me.ComboBoxForm_Client.Size = New System.Drawing.Size(243, 20)
            Me.ComboBoxForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Client.TabIndex = 2
            Me.ComboBoxForm_Client.ValueMember = "Code"
            Me.ComboBoxForm_Client.WatermarkText = "Select Client"
            '
            'ComboBoxForm_Division
            '
            Me.ComboBoxForm_Division.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Division.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Division.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Division.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Division.BookmarkingEnabled = False
            Me.ComboBoxForm_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Division
            Me.ComboBoxForm_Division.DisableMouseWheel = False
            Me.ComboBoxForm_Division.DisplayMember = "Description"
            Me.ComboBoxForm_Division.DisplayName = ""
            Me.ComboBoxForm_Division.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Division.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Division.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Division.FocusHighlightEnabled = True
            Me.ComboBoxForm_Division.FormattingEnabled = True
            Me.ComboBoxForm_Division.ItemHeight = 14
            Me.ComboBoxForm_Division.Location = New System.Drawing.Point(102, 64)
            Me.ComboBoxForm_Division.Name = "ComboBoxForm_Division"
            Me.ComboBoxForm_Division.PreventEnterBeep = False
            Me.ComboBoxForm_Division.ReadOnly = False
            Me.ComboBoxForm_Division.Size = New System.Drawing.Size(243, 20)
            Me.ComboBoxForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Division.TabIndex = 4
            Me.ComboBoxForm_Division.ValueMember = "Code"
            Me.ComboBoxForm_Division.WatermarkText = "Select Division"
            '
            'ComboBoxForm_Product
            '
            Me.ComboBoxForm_Product.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Product.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Product.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Product.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Product.BookmarkingEnabled = False
            Me.ComboBoxForm_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Product
            Me.ComboBoxForm_Product.DisableMouseWheel = False
            Me.ComboBoxForm_Product.DisplayMember = "Name"
            Me.ComboBoxForm_Product.DisplayName = ""
            Me.ComboBoxForm_Product.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Product.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Product.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Product.FocusHighlightEnabled = True
            Me.ComboBoxForm_Product.FormattingEnabled = True
            Me.ComboBoxForm_Product.ItemHeight = 14
            Me.ComboBoxForm_Product.Location = New System.Drawing.Point(102, 90)
            Me.ComboBoxForm_Product.Name = "ComboBoxForm_Product"
            Me.ComboBoxForm_Product.PreventEnterBeep = False
            Me.ComboBoxForm_Product.ReadOnly = False
            Me.ComboBoxForm_Product.Size = New System.Drawing.Size(243, 20)
            Me.ComboBoxForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Product.TabIndex = 6
            Me.ComboBoxForm_Product.ValueMember = "Code"
            Me.ComboBoxForm_Product.WatermarkText = "Select Product"
            '
            'ComboBoxForm_Job
            '
            Me.ComboBoxForm_Job.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Job.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Job.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Job.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Job.BookmarkingEnabled = False
            Me.ComboBoxForm_Job.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Job
            Me.ComboBoxForm_Job.DisableMouseWheel = False
            Me.ComboBoxForm_Job.DisplayMember = "Description"
            Me.ComboBoxForm_Job.DisplayName = ""
            Me.ComboBoxForm_Job.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Job.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Job.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Job.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Job.FocusHighlightEnabled = True
            Me.ComboBoxForm_Job.FormattingEnabled = True
            Me.ComboBoxForm_Job.ItemHeight = 14
            Me.ComboBoxForm_Job.Location = New System.Drawing.Point(102, 116)
            Me.ComboBoxForm_Job.Name = "ComboBoxForm_Job"
            Me.ComboBoxForm_Job.PreventEnterBeep = False
            Me.ComboBoxForm_Job.ReadOnly = False
            Me.ComboBoxForm_Job.Size = New System.Drawing.Size(243, 20)
            Me.ComboBoxForm_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Job.TabIndex = 8
            Me.ComboBoxForm_Job.ValueMember = "Number"
            Me.ComboBoxForm_Job.WatermarkText = "Select Job"
            '
            'ComboBoxForm_JobComponent
            '
            Me.ComboBoxForm_JobComponent.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_JobComponent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_JobComponent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_JobComponent.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_JobComponent.BookmarkingEnabled = False
            Me.ComboBoxForm_JobComponent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.JobComponent
            Me.ComboBoxForm_JobComponent.DisableMouseWheel = False
            Me.ComboBoxForm_JobComponent.DisplayMember = "Description"
            Me.ComboBoxForm_JobComponent.DisplayName = ""
            Me.ComboBoxForm_JobComponent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_JobComponent.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_JobComponent.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_JobComponent.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_JobComponent.FocusHighlightEnabled = True
            Me.ComboBoxForm_JobComponent.FormattingEnabled = True
            Me.ComboBoxForm_JobComponent.ItemHeight = 14
            Me.ComboBoxForm_JobComponent.Location = New System.Drawing.Point(102, 142)
            Me.ComboBoxForm_JobComponent.Name = "ComboBoxForm_JobComponent"
            Me.ComboBoxForm_JobComponent.PreventEnterBeep = False
            Me.ComboBoxForm_JobComponent.ReadOnly = False
            Me.ComboBoxForm_JobComponent.Size = New System.Drawing.Size(243, 20)
            Me.ComboBoxForm_JobComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_JobComponent.TabIndex = 10
            Me.ComboBoxForm_JobComponent.ValueMember = "Number"
            Me.ComboBoxForm_JobComponent.WatermarkText = "Select Job Component"
            '
            'ComboBoxForm_SalesClass
            '
            Me.ComboBoxForm_SalesClass.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_SalesClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_SalesClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_SalesClass.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_SalesClass.BookmarkingEnabled = False
            Me.ComboBoxForm_SalesClass.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.SalesClass
            Me.ComboBoxForm_SalesClass.DisableMouseWheel = False
            Me.ComboBoxForm_SalesClass.DisplayMember = "Description"
            Me.ComboBoxForm_SalesClass.DisplayName = ""
            Me.ComboBoxForm_SalesClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_SalesClass.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_SalesClass.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_SalesClass.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_SalesClass.FocusHighlightEnabled = True
            Me.ComboBoxForm_SalesClass.FormattingEnabled = True
            Me.ComboBoxForm_SalesClass.ItemHeight = 14
            Me.ComboBoxForm_SalesClass.Location = New System.Drawing.Point(441, 38)
            Me.ComboBoxForm_SalesClass.Name = "ComboBoxForm_SalesClass"
            Me.ComboBoxForm_SalesClass.PreventEnterBeep = False
            Me.ComboBoxForm_SalesClass.ReadOnly = False
            Me.ComboBoxForm_SalesClass.Size = New System.Drawing.Size(243, 20)
            Me.ComboBoxForm_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_SalesClass.TabIndex = 12
            Me.ComboBoxForm_SalesClass.ValueMember = "Code"
            Me.ComboBoxForm_SalesClass.WatermarkText = "Select Job"
            '
            'ComboBoxForm_Function
            '
            Me.ComboBoxForm_Function.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Function.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Function.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Function.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Function.BookmarkingEnabled = False
            Me.ComboBoxForm_Function.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Function]
            Me.ComboBoxForm_Function.DisableMouseWheel = False
            Me.ComboBoxForm_Function.DisplayMember = "Description"
            Me.ComboBoxForm_Function.DisplayName = ""
            Me.ComboBoxForm_Function.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Function.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Function.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Function.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Function.FocusHighlightEnabled = True
            Me.ComboBoxForm_Function.FormattingEnabled = True
            Me.ComboBoxForm_Function.ItemHeight = 14
            Me.ComboBoxForm_Function.Location = New System.Drawing.Point(441, 64)
            Me.ComboBoxForm_Function.Name = "ComboBoxForm_Function"
            Me.ComboBoxForm_Function.PreventEnterBeep = False
            Me.ComboBoxForm_Function.ReadOnly = False
            Me.ComboBoxForm_Function.Size = New System.Drawing.Size(243, 20)
            Me.ComboBoxForm_Function.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Function.TabIndex = 14
            Me.ComboBoxForm_Function.ValueMember = "Code"
            Me.ComboBoxForm_Function.WatermarkText = "Select Function"
            '
            'ComboBoxForm_Employee
            '
            Me.ComboBoxForm_Employee.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Employee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Employee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Employee.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Employee.BookmarkingEnabled = False
            Me.ComboBoxForm_Employee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Employee
            Me.ComboBoxForm_Employee.DisableMouseWheel = False
            Me.ComboBoxForm_Employee.DisplayMember = "FullName"
            Me.ComboBoxForm_Employee.DisplayName = ""
            Me.ComboBoxForm_Employee.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Employee.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Employee.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Employee.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Employee.FocusHighlightEnabled = True
            Me.ComboBoxForm_Employee.FormattingEnabled = True
            Me.ComboBoxForm_Employee.ItemHeight = 14
            Me.ComboBoxForm_Employee.Location = New System.Drawing.Point(441, 90)
            Me.ComboBoxForm_Employee.Name = "ComboBoxForm_Employee"
            Me.ComboBoxForm_Employee.PreventEnterBeep = False
            Me.ComboBoxForm_Employee.ReadOnly = False
            Me.ComboBoxForm_Employee.Size = New System.Drawing.Size(243, 20)
            Me.ComboBoxForm_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Employee.TabIndex = 16
            Me.ComboBoxForm_Employee.ValueMember = "Code"
            Me.ComboBoxForm_Employee.WatermarkText = "Select Employee"
            '
            'LabelForm_Taxable
            '
            Me.LabelForm_Taxable.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Taxable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Taxable.Location = New System.Drawing.Point(12, 272)
            Me.LabelForm_Taxable.Name = "LabelForm_Taxable"
            Me.LabelForm_Taxable.Size = New System.Drawing.Size(71, 20)
            Me.LabelForm_Taxable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Taxable.TabIndex = 31
            Me.LabelForm_Taxable.Text = "Taxable:"
            '
            'LabelForm_Commission
            '
            Me.LabelForm_Commission.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Commission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Commission.Location = New System.Drawing.Point(12, 246)
            Me.LabelForm_Commission.Name = "LabelForm_Commission"
            Me.LabelForm_Commission.Size = New System.Drawing.Size(71, 20)
            Me.LabelForm_Commission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Commission.TabIndex = 27
            Me.LabelForm_Commission.Text = "Commission:"
            '
            'LabelForm_NonBillable
            '
            Me.LabelForm_NonBillable.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_NonBillable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_NonBillable.Location = New System.Drawing.Point(12, 220)
            Me.LabelForm_NonBillable.Name = "LabelForm_NonBillable"
            Me.LabelForm_NonBillable.Size = New System.Drawing.Size(71, 20)
            Me.LabelForm_NonBillable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_NonBillable.TabIndex = 24
            Me.LabelForm_NonBillable.Text = "Non Billable:"
            '
            'LabelForm_Rate
            '
            Me.LabelForm_Rate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Rate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Rate.Location = New System.Drawing.Point(12, 194)
            Me.LabelForm_Rate.Name = "LabelForm_Rate"
            Me.LabelForm_Rate.Size = New System.Drawing.Size(71, 20)
            Me.LabelForm_Rate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Rate.TabIndex = 20
            Me.LabelForm_Rate.Text = "Rate:"
            '
            'LabelForm_TaxCommission
            '
            Me.LabelForm_TaxCommission.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TaxCommission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TaxCommission.Location = New System.Drawing.Point(186, 272)
            Me.LabelForm_TaxCommission.Name = "LabelForm_TaxCommission"
            Me.LabelForm_TaxCommission.Size = New System.Drawing.Size(91, 20)
            Me.LabelForm_TaxCommission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TaxCommission.TabIndex = 32
            Me.LabelForm_TaxCommission.Text = "Tax Commission:"
            '
            'LabelForm_TaxCommissionOnly
            '
            Me.LabelForm_TaxCommissionOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TaxCommissionOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TaxCommissionOnly.Location = New System.Drawing.Point(380, 272)
            Me.LabelForm_TaxCommissionOnly.Name = "LabelForm_TaxCommissionOnly"
            Me.LabelForm_TaxCommissionOnly.Size = New System.Drawing.Size(118, 20)
            Me.LabelForm_TaxCommissionOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TaxCommissionOnly.TabIndex = 33
            Me.LabelForm_TaxCommissionOnly.Text = "Tax Commission Only:"
            '
            'LabelForm_FeeTime
            '
            Me.LabelForm_FeeTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FeeTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FeeTime.Location = New System.Drawing.Point(12, 324)
            Me.LabelForm_FeeTime.Name = "LabelForm_FeeTime"
            Me.LabelForm_FeeTime.Size = New System.Drawing.Size(71, 20)
            Me.LabelForm_FeeTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FeeTime.TabIndex = 38
            Me.LabelForm_FeeTime.Text = "Fee Time:"
            '
            'LabelForm_TaxCode
            '
            Me.LabelForm_TaxCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TaxCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TaxCode.Location = New System.Drawing.Point(12, 298)
            Me.LabelForm_TaxCode.Name = "LabelForm_TaxCode"
            Me.LabelForm_TaxCode.Size = New System.Drawing.Size(71, 20)
            Me.LabelForm_TaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TaxCode.TabIndex = 34
            Me.LabelForm_TaxCode.Text = "Tax Code:"
            '
            'LabelForm_TaxCodeLevel
            '
            Me.LabelForm_TaxCodeLevel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TaxCodeLevel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TaxCodeLevel.Location = New System.Drawing.Point(309, 298)
            Me.LabelForm_TaxCodeLevel.Name = "LabelForm_TaxCodeLevel"
            Me.LabelForm_TaxCodeLevel.Size = New System.Drawing.Size(36, 20)
            Me.LabelForm_TaxCodeLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TaxCodeLevel.TabIndex = 36
            Me.LabelForm_TaxCodeLevel.Text = "Level:"
            '
            'LabelForm_RateLevel
            '
            Me.LabelForm_RateLevel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_RateLevel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_RateLevel.Location = New System.Drawing.Point(309, 194)
            Me.LabelForm_RateLevel.Name = "LabelForm_RateLevel"
            Me.LabelForm_RateLevel.Size = New System.Drawing.Size(36, 20)
            Me.LabelForm_RateLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_RateLevel.TabIndex = 22
            Me.LabelForm_RateLevel.Text = "Level:"
            '
            'LabelForm_NonBillableLevel
            '
            Me.LabelForm_NonBillableLevel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_NonBillableLevel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_NonBillableLevel.Location = New System.Drawing.Point(309, 220)
            Me.LabelForm_NonBillableLevel.Name = "LabelForm_NonBillableLevel"
            Me.LabelForm_NonBillableLevel.Size = New System.Drawing.Size(36, 20)
            Me.LabelForm_NonBillableLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_NonBillableLevel.TabIndex = 25
            Me.LabelForm_NonBillableLevel.Text = "Level:"
            '
            'LabelForm_CommissionLevel
            '
            Me.LabelForm_CommissionLevel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CommissionLevel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CommissionLevel.Location = New System.Drawing.Point(309, 246)
            Me.LabelForm_CommissionLevel.Name = "LabelForm_CommissionLevel"
            Me.LabelForm_CommissionLevel.Size = New System.Drawing.Size(36, 20)
            Me.LabelForm_CommissionLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CommissionLevel.TabIndex = 29
            Me.LabelForm_CommissionLevel.Text = "Level:"
            '
            'LabelForm_CommissionPlaceholder
            '
            Me.LabelForm_CommissionPlaceholder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CommissionPlaceholder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CommissionPlaceholder.Location = New System.Drawing.Point(89, 246)
            Me.LabelForm_CommissionPlaceholder.Name = "LabelForm_CommissionPlaceholder"
            Me.LabelForm_CommissionPlaceholder.Size = New System.Drawing.Size(214, 20)
            Me.LabelForm_CommissionPlaceholder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CommissionPlaceholder.TabIndex = 28
            Me.LabelForm_CommissionPlaceholder.Text = "{0}"
            '
            'LabelForm_TaxCodePlaceholder
            '
            Me.LabelForm_TaxCodePlaceholder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TaxCodePlaceholder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TaxCodePlaceholder.Location = New System.Drawing.Point(89, 298)
            Me.LabelForm_TaxCodePlaceholder.Name = "LabelForm_TaxCodePlaceholder"
            Me.LabelForm_TaxCodePlaceholder.Size = New System.Drawing.Size(214, 20)
            Me.LabelForm_TaxCodePlaceholder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TaxCodePlaceholder.TabIndex = 35
            Me.LabelForm_TaxCodePlaceholder.Text = "{0}"
            '
            'LabelForm_FeeTimePlaceholder
            '
            Me.LabelForm_FeeTimePlaceholder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FeeTimePlaceholder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FeeTimePlaceholder.Location = New System.Drawing.Point(89, 324)
            Me.LabelForm_FeeTimePlaceholder.Name = "LabelForm_FeeTimePlaceholder"
            Me.LabelForm_FeeTimePlaceholder.Size = New System.Drawing.Size(214, 20)
            Me.LabelForm_FeeTimePlaceholder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FeeTimePlaceholder.TabIndex = 39
            Me.LabelForm_FeeTimePlaceholder.Text = "{0}"
            '
            'LabelForm_RateLevelPlaceholder
            '
            Me.LabelForm_RateLevelPlaceholder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_RateLevelPlaceholder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_RateLevelPlaceholder.Location = New System.Drawing.Point(351, 194)
            Me.LabelForm_RateLevelPlaceholder.Name = "LabelForm_RateLevelPlaceholder"
            Me.LabelForm_RateLevelPlaceholder.Size = New System.Drawing.Size(333, 20)
            Me.LabelForm_RateLevelPlaceholder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_RateLevelPlaceholder.TabIndex = 23
            Me.LabelForm_RateLevelPlaceholder.Text = "{0}"
            '
            'LabelForm_NonBillableLevelPlaceholder
            '
            Me.LabelForm_NonBillableLevelPlaceholder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_NonBillableLevelPlaceholder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_NonBillableLevelPlaceholder.Location = New System.Drawing.Point(351, 220)
            Me.LabelForm_NonBillableLevelPlaceholder.Name = "LabelForm_NonBillableLevelPlaceholder"
            Me.LabelForm_NonBillableLevelPlaceholder.Size = New System.Drawing.Size(333, 20)
            Me.LabelForm_NonBillableLevelPlaceholder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_NonBillableLevelPlaceholder.TabIndex = 26
            Me.LabelForm_NonBillableLevelPlaceholder.Text = "{0}"
            '
            'LabelForm_CommissionLevelPlaceholder
            '
            Me.LabelForm_CommissionLevelPlaceholder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CommissionLevelPlaceholder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CommissionLevelPlaceholder.Location = New System.Drawing.Point(351, 246)
            Me.LabelForm_CommissionLevelPlaceholder.Name = "LabelForm_CommissionLevelPlaceholder"
            Me.LabelForm_CommissionLevelPlaceholder.Size = New System.Drawing.Size(333, 20)
            Me.LabelForm_CommissionLevelPlaceholder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CommissionLevelPlaceholder.TabIndex = 30
            Me.LabelForm_CommissionLevelPlaceholder.Text = "{0}"
            '
            'LabelForm_TaxCodeLevelPlaceholder
            '
            Me.LabelForm_TaxCodeLevelPlaceholder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TaxCodeLevelPlaceholder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TaxCodeLevelPlaceholder.Location = New System.Drawing.Point(351, 298)
            Me.LabelForm_TaxCodeLevelPlaceholder.Name = "LabelForm_TaxCodeLevelPlaceholder"
            Me.LabelForm_TaxCodeLevelPlaceholder.Size = New System.Drawing.Size(333, 20)
            Me.LabelForm_TaxCodeLevelPlaceholder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TaxCodeLevelPlaceholder.TabIndex = 37
            Me.LabelForm_TaxCodeLevelPlaceholder.Text = "{0}"
            '
            'LabelForm_FeeTimeLevelPlaceholder
            '
            Me.LabelForm_FeeTimeLevelPlaceholder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FeeTimeLevelPlaceholder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FeeTimeLevelPlaceholder.Location = New System.Drawing.Point(351, 324)
            Me.LabelForm_FeeTimeLevelPlaceholder.Name = "LabelForm_FeeTimeLevelPlaceholder"
            Me.LabelForm_FeeTimeLevelPlaceholder.Size = New System.Drawing.Size(333, 20)
            Me.LabelForm_FeeTimeLevelPlaceholder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FeeTimeLevelPlaceholder.TabIndex = 41
            Me.LabelForm_FeeTimeLevelPlaceholder.Text = "{0}"
            '
            'DateTimePickerForm_EffectiveDate
            '
            Me.DateTimePickerForm_EffectiveDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_EffectiveDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_EffectiveDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_EffectiveDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_EffectiveDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_EffectiveDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_EffectiveDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_EffectiveDate.CustomFormat = ""
            Me.DateTimePickerForm_EffectiveDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_EffectiveDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_EffectiveDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_EffectiveDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerForm_EffectiveDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_EffectiveDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_EffectiveDate.Location = New System.Drawing.Point(441, 116)
            Me.DateTimePickerForm_EffectiveDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.DisplayMonth = New Date(2012, 6, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_EffectiveDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_EffectiveDate.Name = "DateTimePickerForm_EffectiveDate"
            Me.DateTimePickerForm_EffectiveDate.ReadOnly = False
            Me.DateTimePickerForm_EffectiveDate.Size = New System.Drawing.Size(243, 20)
            Me.DateTimePickerForm_EffectiveDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_EffectiveDate.TabIndex = 18
            '
            'LabelForm_FeeTimeLevel
            '
            Me.LabelForm_FeeTimeLevel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FeeTimeLevel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FeeTimeLevel.Location = New System.Drawing.Point(309, 324)
            Me.LabelForm_FeeTimeLevel.Name = "LabelForm_FeeTimeLevel"
            Me.LabelForm_FeeTimeLevel.Size = New System.Drawing.Size(36, 20)
            Me.LabelForm_FeeTimeLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FeeTimeLevel.TabIndex = 40
            Me.LabelForm_FeeTimeLevel.Text = "Level:"
            '
            'ButtonForm_Reset
            '
            Me.ButtonForm_Reset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Reset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Reset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Reset.Location = New System.Drawing.Point(528, 376)
            Me.ButtonForm_Reset.Name = "ButtonForm_Reset"
            Me.ButtonForm_Reset.SecurityEnabled = True
            Me.ButtonForm_Reset.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Reset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Reset.TabIndex = 44
            Me.ButtonForm_Reset.Text = "Reset"
            '
            'LabelForm_Results
            '
            Me.LabelForm_Results.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Results.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Results.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_Results.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_Results.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Results.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Results.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Results.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Results.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_Results.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_Results.Location = New System.Drawing.Point(12, 168)
            Me.LabelForm_Results.Name = "LabelForm_Results"
            Me.LabelForm_Results.Size = New System.Drawing.Size(672, 20)
            Me.LabelForm_Results.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Results.TabIndex = 19
            Me.LabelForm_Results.Text = "Results"
            '
            'PictureBoxForm_NonBillable
            '
            Me.PictureBoxForm_NonBillable.Location = New System.Drawing.Point(89, 220)
            Me.PictureBoxForm_NonBillable.Name = "PictureBoxForm_NonBillable"
            Me.PictureBoxForm_NonBillable.Size = New System.Drawing.Size(20, 20)
            Me.PictureBoxForm_NonBillable.TabIndex = 61
            Me.PictureBoxForm_NonBillable.TabStop = False
            '
            'PictureBoxForm_Taxable
            '
            Me.PictureBoxForm_Taxable.Location = New System.Drawing.Point(89, 272)
            Me.PictureBoxForm_Taxable.Name = "PictureBoxForm_Taxable"
            Me.PictureBoxForm_Taxable.Size = New System.Drawing.Size(20, 20)
            Me.PictureBoxForm_Taxable.TabIndex = 62
            Me.PictureBoxForm_Taxable.TabStop = False
            '
            'PictureBoxForm_TaxCommission
            '
            Me.PictureBoxForm_TaxCommission.Location = New System.Drawing.Point(283, 272)
            Me.PictureBoxForm_TaxCommission.Name = "PictureBoxForm_TaxCommission"
            Me.PictureBoxForm_TaxCommission.Size = New System.Drawing.Size(20, 20)
            Me.PictureBoxForm_TaxCommission.TabIndex = 63
            Me.PictureBoxForm_TaxCommission.TabStop = False
            '
            'PictureBoxForm_TaxCommissionOnly
            '
            Me.PictureBoxForm_TaxCommissionOnly.Location = New System.Drawing.Point(504, 272)
            Me.PictureBoxForm_TaxCommissionOnly.Name = "PictureBoxForm_TaxCommissionOnly"
            Me.PictureBoxForm_TaxCommissionOnly.Size = New System.Drawing.Size(20, 20)
            Me.PictureBoxForm_TaxCommissionOnly.TabIndex = 64
            Me.PictureBoxForm_TaxCommissionOnly.TabStop = False
            '
            'LabelForm_RatePlaceholder
            '
            Me.LabelForm_RatePlaceholder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_RatePlaceholder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_RatePlaceholder.Location = New System.Drawing.Point(89, 194)
            Me.LabelForm_RatePlaceholder.Name = "LabelForm_RatePlaceholder"
            Me.LabelForm_RatePlaceholder.Size = New System.Drawing.Size(214, 20)
            Me.LabelForm_RatePlaceholder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_RatePlaceholder.TabIndex = 21
            Me.LabelForm_RatePlaceholder.Text = "{0}"
            '
            'LabelForm_BillNet
            '
            Me.LabelForm_BillNet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_BillNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_BillNet.Location = New System.Drawing.Point(12, 350)
            Me.LabelForm_BillNet.Name = "LabelForm_BillNet"
            Me.LabelForm_BillNet.Size = New System.Drawing.Size(71, 20)
            Me.LabelForm_BillNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_BillNet.TabIndex = 42
            Me.LabelForm_BillNet.Text = "Bill Net:"
            '
            'PictureBoxForm_BillNet
            '
            Me.PictureBoxForm_BillNet.Location = New System.Drawing.Point(89, 350)
            Me.PictureBoxForm_BillNet.Name = "PictureBoxForm_BillNet"
            Me.PictureBoxForm_BillNet.Size = New System.Drawing.Size(20, 20)
            Me.PictureBoxForm_BillNet.TabIndex = 66
            Me.PictureBoxForm_BillNet.TabStop = False
            '
            'RateFlagTesterDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(696, 408)
            Me.Controls.Add(Me.PictureBoxForm_BillNet)
            Me.Controls.Add(Me.LabelForm_BillNet)
            Me.Controls.Add(Me.LabelForm_RatePlaceholder)
            Me.Controls.Add(Me.PictureBoxForm_Taxable)
            Me.Controls.Add(Me.PictureBoxForm_TaxCommissionOnly)
            Me.Controls.Add(Me.PictureBoxForm_TaxCommission)
            Me.Controls.Add(Me.PictureBoxForm_NonBillable)
            Me.Controls.Add(Me.LabelForm_Results)
            Me.Controls.Add(Me.ButtonForm_Reset)
            Me.Controls.Add(Me.LabelForm_FeeTimeLevel)
            Me.Controls.Add(Me.LabelForm_FeeTimeLevelPlaceholder)
            Me.Controls.Add(Me.DateTimePickerForm_EffectiveDate)
            Me.Controls.Add(Me.LabelForm_TaxCodeLevelPlaceholder)
            Me.Controls.Add(Me.LabelForm_CommissionLevelPlaceholder)
            Me.Controls.Add(Me.LabelForm_NonBillableLevelPlaceholder)
            Me.Controls.Add(Me.LabelForm_RateLevelPlaceholder)
            Me.Controls.Add(Me.LabelForm_FeeTimePlaceholder)
            Me.Controls.Add(Me.LabelForm_TaxCodePlaceholder)
            Me.Controls.Add(Me.LabelForm_CommissionPlaceholder)
            Me.Controls.Add(Me.LabelForm_CommissionLevel)
            Me.Controls.Add(Me.LabelForm_NonBillableLevel)
            Me.Controls.Add(Me.LabelForm_RateLevel)
            Me.Controls.Add(Me.LabelForm_TaxCodeLevel)
            Me.Controls.Add(Me.LabelForm_TaxCode)
            Me.Controls.Add(Me.LabelForm_FeeTime)
            Me.Controls.Add(Me.LabelForm_Taxable)
            Me.Controls.Add(Me.LabelForm_TaxCommissionOnly)
            Me.Controls.Add(Me.LabelForm_Commission)
            Me.Controls.Add(Me.LabelForm_TaxCommission)
            Me.Controls.Add(Me.LabelForm_NonBillable)
            Me.Controls.Add(Me.LabelForm_Rate)
            Me.Controls.Add(Me.ComboBoxForm_JobComponent)
            Me.Controls.Add(Me.ComboBoxForm_Employee)
            Me.Controls.Add(Me.ComboBoxForm_Function)
            Me.Controls.Add(Me.ComboBoxForm_Job)
            Me.Controls.Add(Me.ComboBoxForm_Product)
            Me.Controls.Add(Me.ComboBoxForm_SalesClass)
            Me.Controls.Add(Me.ComboBoxForm_Division)
            Me.Controls.Add(Me.ComboBoxForm_Client)
            Me.Controls.Add(Me.LabelForm_JobComponent)
            Me.Controls.Add(Me.LabelForm_EffectiveDate)
            Me.Controls.Add(Me.LabelForm_Employee)
            Me.Controls.Add(Me.LabelForm_Function)
            Me.Controls.Add(Me.LabelForm_Job)
            Me.Controls.Add(Me.LabelForm_SalesClass)
            Me.Controls.Add(Me.LabelForm_Product)
            Me.Controls.Add(Me.LabelForm_Division)
            Me.Controls.Add(Me.LabelForm_Select)
            Me.Controls.Add(Me.LabelForm_Client)
            Me.Controls.Add(Me.ButtonForm_Close)
            Me.Controls.Add(Me.ButtonForm_Process)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "RateFlagTesterDialog"
            Me.Text = "Rate/Flag Tester"
            CType(Me.DateTimePickerForm_EffectiveDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBoxForm_NonBillable, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBoxForm_Taxable, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBoxForm_TaxCommission, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBoxForm_TaxCommissionOnly, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBoxForm_BillNet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Close As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Process As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Select As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Job As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_JobComponent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Function As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_EffectiveDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_RateLevel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_NonBillableLevel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_FeeTime As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TaxCode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Taxable As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Client As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_Division As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_Product As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_Job As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_JobComponent As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_Function As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Commission As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_NonBillable As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Rate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TaxCommission As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TaxCommissionOnly As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TaxCodeLevel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_CommissionLevel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_CommissionPlaceholder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TaxCodePlaceholder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_FeeTimePlaceholder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_RateLevelPlaceholder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_NonBillableLevelPlaceholder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_CommissionLevelPlaceholder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TaxCodeLevelPlaceholder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_FeeTimeLevelPlaceholder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_EffectiveDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_FeeTimeLevel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Reset As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Results As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PictureBoxForm_NonBillable As System.Windows.Forms.PictureBox
        Friend WithEvents PictureBoxForm_Taxable As System.Windows.Forms.PictureBox
        Friend WithEvents PictureBoxForm_TaxCommission As System.Windows.Forms.PictureBox
        Friend WithEvents PictureBoxForm_TaxCommissionOnly As System.Windows.Forms.PictureBox
        Friend WithEvents LabelForm_RatePlaceholder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_BillNet As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PictureBoxForm_BillNet As System.Windows.Forms.PictureBox
    End Class

End Namespace