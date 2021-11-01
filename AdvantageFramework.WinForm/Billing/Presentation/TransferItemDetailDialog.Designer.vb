Namespace Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class TransferItemDetailDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TransferItemDetailDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelTransferFrom_Job = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxForm_TransferFrom = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelTransferFrom_Billable = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferFrom_RateFrom = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxTransferFrom_Billable = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputTransferFrom_Rate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelTransferFrom_Rate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputTransferFrom_Total = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTransferFrom_MarkupAmount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelTransferFrom_Total = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputTransferFrom_ResaleTax = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelTransferFrom_MarkupAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputTransferFrom_VendorTax = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelTransferFrom_ResaleTax = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputTransferFrom_Amount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelTransferFrom_VendorTax = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputTransferFrom_QtyHours = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelTransferFrom_Amount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferFrom_QuantityHours = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxTransferFrom_Invoice = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelTransferFrom_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferFrom_Invoice = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferFrom_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferFrom_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxTransferFrom_Division = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView13 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxTransferFrom_Item = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView10 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxTransferFrom_Product = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView14 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxTransferFrom_Client = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView15 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.NumericInputTransferFrom_Approved = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.TextBoxTransferFrom_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.NumericInputTransferFrom_Unbilled = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelTransferFrom_Item = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxTransferFrom_Function = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxTransferFrom_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxTransferFrom_Job = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_Client = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelTransferFrom_Approved = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferFrom_Unbilled = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferFrom_Function = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferFrom_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxFrom_TransferTo = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxTransferTo_Task = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView16 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelTransferTo_TaskCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferTo_Billable = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxTransferTo_Billable = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelTransferTo_RateFrom = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputTransferTo_Rate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelTransferTo_Rate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputTransferTo_QtyHours = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelTransferTo_QtyHours = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferTo_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferTo_GLAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxTransferTo_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView12 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxTransferTo_GLAccount = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView11 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.NumericInputTransferTo_MarkupPercent = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelTransferTo_MarkupPercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputTransferTo_Total = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelTransferTo_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputTransferTo_MarkupAmount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelTransferTo_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferTo_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxTransferTo_Division = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView7 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxTransferTo_Product = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView8 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxTransferTo_Client = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView6 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.NumericInputTransferTo_ResaleTax = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTransferTo_VendorTax = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTransferTo_Amount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelTransferTo_MarkupAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferTo_ResaleTax = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferTo_VendorTax = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferTo_Total = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferTo_Amount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxTransferTo_Tax = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView9 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelTransferTo_TaxCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxTransferTo_Function = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView3 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxTransferTo_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView4 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxTransferTo_Job = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView5 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelTransferTo_Function = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferTo_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTransferTo_Job = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Comments = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Comments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.GroupBoxForm_EmployeeTimeBillingRate = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonTime_TransferAsIs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonTime_RecalculateFromHierarchy = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxForm_MarkupPercent = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonMarkup_TransferAsIs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonMarkup_RecalculateFromHierarchy = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            CType(Me.GroupBoxForm_TransferFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_TransferFrom.SuspendLayout()
            CType(Me.NumericInputTransferFrom_Rate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTransferFrom_Total.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTransferFrom_MarkupAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTransferFrom_ResaleTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTransferFrom_VendorTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTransferFrom_Amount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTransferFrom_QtyHours.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTransferFrom_Division.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView13, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTransferFrom_Item.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView10, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTransferFrom_Product.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView14, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTransferFrom_Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView15, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTransferFrom_Approved.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTransferFrom_Unbilled.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTransferFrom_Function.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTransferFrom_JobComponent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTransferFrom_Job.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_Client, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxFrom_TransferTo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxFrom_TransferTo.SuspendLayout()
            CType(Me.SearchableComboBoxTransferTo_Task.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView16, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTransferTo_Rate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTransferTo_QtyHours.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTransferTo_PostPeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView12, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTransferTo_GLAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView11, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTransferTo_MarkupPercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTransferTo_Total.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTransferTo_MarkupAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTransferTo_Division.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTransferTo_Product.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTransferTo_Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTransferTo_ResaleTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTransferTo_VendorTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTransferTo_Amount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTransferTo_Tax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView9, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTransferTo_Function.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTransferTo_JobComponent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTransferTo_Job.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_EmployeeTimeBillingRate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_EmployeeTimeBillingRate.SuspendLayout()
            CType(Me.GroupBoxForm_MarkupPercent, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_MarkupPercent.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(654, 626)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 6
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(735, 626)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 7
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelTransferFrom_Job
            '
            Me.LabelTransferFrom_Job.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_Job.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_Job.Location = New System.Drawing.Point(5, 102)
            Me.LabelTransferFrom_Job.Name = "LabelTransferFrom_Job"
            Me.LabelTransferFrom_Job.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferFrom_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_Job.TabIndex = 6
            Me.LabelTransferFrom_Job.Text = "Job:"
            '
            'GroupBoxForm_TransferFrom
            '
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_Billable)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_RateFrom)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.CheckBoxTransferFrom_Billable)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.NumericInputTransferFrom_Rate)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_Rate)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.NumericInputTransferFrom_Total)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.NumericInputTransferFrom_MarkupAmount)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_Total)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.NumericInputTransferFrom_ResaleTax)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_MarkupAmount)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.NumericInputTransferFrom_VendorTax)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_ResaleTax)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.NumericInputTransferFrom_Amount)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_VendorTax)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.NumericInputTransferFrom_QtyHours)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_Amount)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_QuantityHours)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.TextBoxTransferFrom_Invoice)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_Product)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_Invoice)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_Division)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_Client)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.SearchableComboBoxTransferFrom_Division)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.SearchableComboBoxTransferFrom_Item)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.SearchableComboBoxTransferFrom_Product)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.SearchableComboBoxTransferFrom_Client)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.NumericInputTransferFrom_Approved)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.TextBoxTransferFrom_Description)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.NumericInputTransferFrom_Unbilled)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_Item)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.SearchableComboBoxTransferFrom_Function)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.SearchableComboBoxTransferFrom_JobComponent)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.SearchableComboBoxTransferFrom_Job)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_Approved)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_Unbilled)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_Function)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_JobComponent)
            Me.GroupBoxForm_TransferFrom.Controls.Add(Me.LabelTransferFrom_Job)
            Me.GroupBoxForm_TransferFrom.Location = New System.Drawing.Point(12, 12)
            Me.GroupBoxForm_TransferFrom.Name = "GroupBoxForm_TransferFrom"
            Me.GroupBoxForm_TransferFrom.Size = New System.Drawing.Size(396, 477)
            Me.GroupBoxForm_TransferFrom.TabIndex = 0
            Me.GroupBoxForm_TransferFrom.Text = "Transfer From"
            '
            'LabelTransferFrom_Billable
            '
            Me.LabelTransferFrom_Billable.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_Billable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_Billable.Location = New System.Drawing.Point(5, 440)
            Me.LabelTransferFrom_Billable.Name = "LabelTransferFrom_Billable"
            Me.LabelTransferFrom_Billable.Size = New System.Drawing.Size(42, 20)
            Me.LabelTransferFrom_Billable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_Billable.TabIndex = 37
            Me.LabelTransferFrom_Billable.Text = "Billable:"
            '
            'LabelTransferFrom_RateFrom
            '
            Me.LabelTransferFrom_RateFrom.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_RateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_RateFrom.Location = New System.Drawing.Point(101, 284)
            Me.LabelTransferFrom_RateFrom.Name = "LabelTransferFrom_RateFrom"
            Me.LabelTransferFrom_RateFrom.Size = New System.Drawing.Size(190, 20)
            Me.LabelTransferFrom_RateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_RateFrom.TabIndex = 36
            '
            'CheckBoxTransferFrom_Billable
            '
            Me.CheckBoxTransferFrom_Billable.AutoCheck = False
            '
            '
            '
            Me.CheckBoxTransferFrom_Billable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTransferFrom_Billable.CheckValue = 1
            Me.CheckBoxTransferFrom_Billable.CheckValueChecked = 0
            Me.CheckBoxTransferFrom_Billable.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTransferFrom_Billable.CheckValueUnchecked = 1
            Me.CheckBoxTransferFrom_Billable.ChildControls = CType(resources.GetObject("CheckBoxTransferFrom_Billable.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTransferFrom_Billable.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked0Unchecked1
            Me.CheckBoxTransferFrom_Billable.Location = New System.Drawing.Point(53, 442)
            Me.CheckBoxTransferFrom_Billable.Name = "CheckBoxTransferFrom_Billable"
            Me.CheckBoxTransferFrom_Billable.OldestSibling = Nothing
            Me.CheckBoxTransferFrom_Billable.SecurityEnabled = True
            Me.CheckBoxTransferFrom_Billable.SiblingControls = CType(resources.GetObject("CheckBoxTransferFrom_Billable.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTransferFrom_Billable.Size = New System.Drawing.Size(29, 23)
            Me.CheckBoxTransferFrom_Billable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTransferFrom_Billable.TabIndex = 34
            Me.CheckBoxTransferFrom_Billable.TabOnEnter = True
            Me.CheckBoxTransferFrom_Billable.TabStop = False
            '
            'NumericInputTransferFrom_Rate
            '
            Me.NumericInputTransferFrom_Rate.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTransferFrom_Rate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTransferFrom_Rate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTransferFrom_Rate.EnterMoveNextControl = True
            Me.NumericInputTransferFrom_Rate.Location = New System.Drawing.Point(297, 285)
            Me.NumericInputTransferFrom_Rate.Name = "NumericInputTransferFrom_Rate"
            Me.NumericInputTransferFrom_Rate.Properties.AllowMouseWheel = False
            Me.NumericInputTransferFrom_Rate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputTransferFrom_Rate.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTransferFrom_Rate.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_Rate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_Rate.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_Rate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_Rate.Properties.Mask.EditMask = "f"
            Me.NumericInputTransferFrom_Rate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTransferFrom_Rate.Properties.MaxLength = 6
            Me.NumericInputTransferFrom_Rate.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputTransferFrom_Rate.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputTransferFrom_Rate.Properties.ReadOnly = True
            Me.NumericInputTransferFrom_Rate.SecurityEnabled = True
            Me.NumericInputTransferFrom_Rate.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputTransferFrom_Rate.TabIndex = 23
            Me.NumericInputTransferFrom_Rate.TabStop = False
            '
            'LabelTransferFrom_Rate
            '
            Me.LabelTransferFrom_Rate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_Rate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_Rate.Location = New System.Drawing.Point(5, 284)
            Me.LabelTransferFrom_Rate.Name = "LabelTransferFrom_Rate"
            Me.LabelTransferFrom_Rate.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferFrom_Rate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_Rate.TabIndex = 22
            Me.LabelTransferFrom_Rate.Text = "From / Rate:"
            '
            'NumericInputTransferFrom_Total
            '
            Me.NumericInputTransferFrom_Total.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTransferFrom_Total.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTransferFrom_Total.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTransferFrom_Total.EnterMoveNextControl = True
            Me.NumericInputTransferFrom_Total.Location = New System.Drawing.Point(297, 415)
            Me.NumericInputTransferFrom_Total.Name = "NumericInputTransferFrom_Total"
            Me.NumericInputTransferFrom_Total.Properties.AllowMouseWheel = False
            Me.NumericInputTransferFrom_Total.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputTransferFrom_Total.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTransferFrom_Total.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_Total.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_Total.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_Total.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_Total.Properties.Mask.EditMask = "f"
            Me.NumericInputTransferFrom_Total.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTransferFrom_Total.Properties.MaxLength = 6
            Me.NumericInputTransferFrom_Total.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputTransferFrom_Total.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputTransferFrom_Total.Properties.ReadOnly = True
            Me.NumericInputTransferFrom_Total.SecurityEnabled = True
            Me.NumericInputTransferFrom_Total.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputTransferFrom_Total.TabIndex = 33
            Me.NumericInputTransferFrom_Total.TabStop = False
            '
            'NumericInputTransferFrom_MarkupAmount
            '
            Me.NumericInputTransferFrom_MarkupAmount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTransferFrom_MarkupAmount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTransferFrom_MarkupAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTransferFrom_MarkupAmount.EnterMoveNextControl = True
            Me.NumericInputTransferFrom_MarkupAmount.Location = New System.Drawing.Point(297, 337)
            Me.NumericInputTransferFrom_MarkupAmount.Name = "NumericInputTransferFrom_MarkupAmount"
            Me.NumericInputTransferFrom_MarkupAmount.Properties.AllowMouseWheel = False
            Me.NumericInputTransferFrom_MarkupAmount.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputTransferFrom_MarkupAmount.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTransferFrom_MarkupAmount.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_MarkupAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_MarkupAmount.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_MarkupAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_MarkupAmount.Properties.Mask.EditMask = "f"
            Me.NumericInputTransferFrom_MarkupAmount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTransferFrom_MarkupAmount.Properties.MaxLength = 6
            Me.NumericInputTransferFrom_MarkupAmount.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputTransferFrom_MarkupAmount.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputTransferFrom_MarkupAmount.Properties.ReadOnly = True
            Me.NumericInputTransferFrom_MarkupAmount.SecurityEnabled = True
            Me.NumericInputTransferFrom_MarkupAmount.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputTransferFrom_MarkupAmount.TabIndex = 27
            Me.NumericInputTransferFrom_MarkupAmount.TabStop = False
            '
            'LabelTransferFrom_Total
            '
            Me.LabelTransferFrom_Total.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_Total.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_Total.Location = New System.Drawing.Point(5, 414)
            Me.LabelTransferFrom_Total.Name = "LabelTransferFrom_Total"
            Me.LabelTransferFrom_Total.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferFrom_Total.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_Total.TabIndex = 32
            Me.LabelTransferFrom_Total.Text = "Total:"
            '
            'NumericInputTransferFrom_ResaleTax
            '
            Me.NumericInputTransferFrom_ResaleTax.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTransferFrom_ResaleTax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTransferFrom_ResaleTax.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTransferFrom_ResaleTax.EnterMoveNextControl = True
            Me.NumericInputTransferFrom_ResaleTax.Location = New System.Drawing.Point(297, 389)
            Me.NumericInputTransferFrom_ResaleTax.Name = "NumericInputTransferFrom_ResaleTax"
            Me.NumericInputTransferFrom_ResaleTax.Properties.AllowMouseWheel = False
            Me.NumericInputTransferFrom_ResaleTax.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputTransferFrom_ResaleTax.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTransferFrom_ResaleTax.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_ResaleTax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_ResaleTax.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_ResaleTax.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_ResaleTax.Properties.Mask.EditMask = "f"
            Me.NumericInputTransferFrom_ResaleTax.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTransferFrom_ResaleTax.Properties.MaxLength = 6
            Me.NumericInputTransferFrom_ResaleTax.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputTransferFrom_ResaleTax.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputTransferFrom_ResaleTax.Properties.ReadOnly = True
            Me.NumericInputTransferFrom_ResaleTax.SecurityEnabled = True
            Me.NumericInputTransferFrom_ResaleTax.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputTransferFrom_ResaleTax.TabIndex = 31
            Me.NumericInputTransferFrom_ResaleTax.TabStop = False
            '
            'LabelTransferFrom_MarkupAmount
            '
            Me.LabelTransferFrom_MarkupAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_MarkupAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_MarkupAmount.Location = New System.Drawing.Point(5, 336)
            Me.LabelTransferFrom_MarkupAmount.Name = "LabelTransferFrom_MarkupAmount"
            Me.LabelTransferFrom_MarkupAmount.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferFrom_MarkupAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_MarkupAmount.TabIndex = 26
            Me.LabelTransferFrom_MarkupAmount.Text = "Markup Amount:"
            '
            'NumericInputTransferFrom_VendorTax
            '
            Me.NumericInputTransferFrom_VendorTax.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTransferFrom_VendorTax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTransferFrom_VendorTax.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTransferFrom_VendorTax.EnterMoveNextControl = True
            Me.NumericInputTransferFrom_VendorTax.Location = New System.Drawing.Point(297, 363)
            Me.NumericInputTransferFrom_VendorTax.Name = "NumericInputTransferFrom_VendorTax"
            Me.NumericInputTransferFrom_VendorTax.Properties.AllowMouseWheel = False
            Me.NumericInputTransferFrom_VendorTax.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputTransferFrom_VendorTax.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTransferFrom_VendorTax.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_VendorTax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_VendorTax.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_VendorTax.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_VendorTax.Properties.Mask.EditMask = "f"
            Me.NumericInputTransferFrom_VendorTax.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTransferFrom_VendorTax.Properties.MaxLength = 6
            Me.NumericInputTransferFrom_VendorTax.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputTransferFrom_VendorTax.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputTransferFrom_VendorTax.Properties.ReadOnly = True
            Me.NumericInputTransferFrom_VendorTax.SecurityEnabled = True
            Me.NumericInputTransferFrom_VendorTax.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputTransferFrom_VendorTax.TabIndex = 29
            Me.NumericInputTransferFrom_VendorTax.TabStop = False
            '
            'LabelTransferFrom_ResaleTax
            '
            Me.LabelTransferFrom_ResaleTax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_ResaleTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_ResaleTax.Location = New System.Drawing.Point(5, 388)
            Me.LabelTransferFrom_ResaleTax.Name = "LabelTransferFrom_ResaleTax"
            Me.LabelTransferFrom_ResaleTax.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferFrom_ResaleTax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_ResaleTax.TabIndex = 30
            Me.LabelTransferFrom_ResaleTax.Text = "Resale Tax:"
            '
            'NumericInputTransferFrom_Amount
            '
            Me.NumericInputTransferFrom_Amount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTransferFrom_Amount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTransferFrom_Amount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTransferFrom_Amount.EnterMoveNextControl = True
            Me.NumericInputTransferFrom_Amount.Location = New System.Drawing.Point(297, 311)
            Me.NumericInputTransferFrom_Amount.Name = "NumericInputTransferFrom_Amount"
            Me.NumericInputTransferFrom_Amount.Properties.AllowMouseWheel = False
            Me.NumericInputTransferFrom_Amount.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputTransferFrom_Amount.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTransferFrom_Amount.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_Amount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_Amount.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_Amount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_Amount.Properties.Mask.EditMask = "f"
            Me.NumericInputTransferFrom_Amount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTransferFrom_Amount.Properties.MaxLength = 6
            Me.NumericInputTransferFrom_Amount.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputTransferFrom_Amount.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputTransferFrom_Amount.Properties.ReadOnly = True
            Me.NumericInputTransferFrom_Amount.SecurityEnabled = True
            Me.NumericInputTransferFrom_Amount.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputTransferFrom_Amount.TabIndex = 25
            Me.NumericInputTransferFrom_Amount.TabStop = False
            '
            'LabelTransferFrom_VendorTax
            '
            Me.LabelTransferFrom_VendorTax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_VendorTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_VendorTax.Location = New System.Drawing.Point(5, 362)
            Me.LabelTransferFrom_VendorTax.Name = "LabelTransferFrom_VendorTax"
            Me.LabelTransferFrom_VendorTax.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferFrom_VendorTax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_VendorTax.TabIndex = 28
            Me.LabelTransferFrom_VendorTax.Text = "Vendor Tax:"
            '
            'NumericInputTransferFrom_QtyHours
            '
            Me.NumericInputTransferFrom_QtyHours.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTransferFrom_QtyHours.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTransferFrom_QtyHours.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTransferFrom_QtyHours.EnterMoveNextControl = True
            Me.NumericInputTransferFrom_QtyHours.Location = New System.Drawing.Point(297, 259)
            Me.NumericInputTransferFrom_QtyHours.Name = "NumericInputTransferFrom_QtyHours"
            Me.NumericInputTransferFrom_QtyHours.Properties.AllowMouseWheel = False
            Me.NumericInputTransferFrom_QtyHours.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputTransferFrom_QtyHours.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTransferFrom_QtyHours.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_QtyHours.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_QtyHours.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_QtyHours.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_QtyHours.Properties.Mask.EditMask = "f"
            Me.NumericInputTransferFrom_QtyHours.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTransferFrom_QtyHours.Properties.MaxLength = 6
            Me.NumericInputTransferFrom_QtyHours.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputTransferFrom_QtyHours.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputTransferFrom_QtyHours.Properties.ReadOnly = True
            Me.NumericInputTransferFrom_QtyHours.SecurityEnabled = True
            Me.NumericInputTransferFrom_QtyHours.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputTransferFrom_QtyHours.TabIndex = 21
            Me.NumericInputTransferFrom_QtyHours.TabStop = False
            '
            'LabelTransferFrom_Amount
            '
            Me.LabelTransferFrom_Amount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_Amount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_Amount.Location = New System.Drawing.Point(5, 310)
            Me.LabelTransferFrom_Amount.Name = "LabelTransferFrom_Amount"
            Me.LabelTransferFrom_Amount.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferFrom_Amount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_Amount.TabIndex = 24
            Me.LabelTransferFrom_Amount.Text = "Amount:"
            '
            'LabelTransferFrom_QuantityHours
            '
            Me.LabelTransferFrom_QuantityHours.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_QuantityHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_QuantityHours.Location = New System.Drawing.Point(5, 258)
            Me.LabelTransferFrom_QuantityHours.Name = "LabelTransferFrom_QuantityHours"
            Me.LabelTransferFrom_QuantityHours.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferFrom_QuantityHours.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_QuantityHours.TabIndex = 20
            Me.LabelTransferFrom_QuantityHours.Text = "Qty / Hours:"
            '
            'TextBoxTransferFrom_Invoice
            '
            Me.TextBoxTransferFrom_Invoice.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxTransferFrom_Invoice.BackColor = System.Drawing.SystemColors.Window
            '
            '
            '
            Me.TextBoxTransferFrom_Invoice.Border.Class = "TextBoxBorder"
            Me.TextBoxTransferFrom_Invoice.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTransferFrom_Invoice.CheckSpellingOnValidate = False
            Me.TextBoxTransferFrom_Invoice.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTransferFrom_Invoice.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxTransferFrom_Invoice.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxTransferFrom_Invoice.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTransferFrom_Invoice.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTransferFrom_Invoice.FocusHighlightEnabled = True
            Me.TextBoxTransferFrom_Invoice.ForeColor = System.Drawing.Color.Black
            Me.TextBoxTransferFrom_Invoice.Location = New System.Drawing.Point(101, 232)
            Me.TextBoxTransferFrom_Invoice.MaxFileSize = CType(0, Long)
            Me.TextBoxTransferFrom_Invoice.Name = "TextBoxTransferFrom_Invoice"
            Me.TextBoxTransferFrom_Invoice.ReadOnly = True
            Me.TextBoxTransferFrom_Invoice.SecurityEnabled = True
            Me.TextBoxTransferFrom_Invoice.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTransferFrom_Invoice.Size = New System.Drawing.Size(290, 21)
            Me.TextBoxTransferFrom_Invoice.StartingFolderName = Nothing
            Me.TextBoxTransferFrom_Invoice.TabIndex = 19
            Me.TextBoxTransferFrom_Invoice.TabOnEnter = True
            Me.TextBoxTransferFrom_Invoice.TabStop = False
            Me.TextBoxTransferFrom_Invoice.Tag = ""
            Me.TextBoxTransferFrom_Invoice.Visible = False
            '
            'LabelTransferFrom_Product
            '
            Me.LabelTransferFrom_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_Product.Location = New System.Drawing.Point(5, 76)
            Me.LabelTransferFrom_Product.Name = "LabelTransferFrom_Product"
            Me.LabelTransferFrom_Product.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferFrom_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_Product.TabIndex = 4
            Me.LabelTransferFrom_Product.Text = "Product:"
            '
            'LabelTransferFrom_Invoice
            '
            Me.LabelTransferFrom_Invoice.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_Invoice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_Invoice.Location = New System.Drawing.Point(5, 232)
            Me.LabelTransferFrom_Invoice.Name = "LabelTransferFrom_Invoice"
            Me.LabelTransferFrom_Invoice.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferFrom_Invoice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_Invoice.TabIndex = 18
            Me.LabelTransferFrom_Invoice.Text = "Invoice:"
            Me.LabelTransferFrom_Invoice.Visible = False
            '
            'LabelTransferFrom_Division
            '
            Me.LabelTransferFrom_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_Division.Location = New System.Drawing.Point(5, 50)
            Me.LabelTransferFrom_Division.Name = "LabelTransferFrom_Division"
            Me.LabelTransferFrom_Division.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferFrom_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_Division.TabIndex = 2
            Me.LabelTransferFrom_Division.Text = "Division:"
            '
            'LabelTransferFrom_Client
            '
            Me.LabelTransferFrom_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_Client.Location = New System.Drawing.Point(5, 24)
            Me.LabelTransferFrom_Client.Name = "LabelTransferFrom_Client"
            Me.LabelTransferFrom_Client.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferFrom_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_Client.TabIndex = 0
            Me.LabelTransferFrom_Client.Text = "Client:"
            '
            'SearchableComboBoxTransferFrom_Division
            '
            Me.SearchableComboBoxTransferFrom_Division.ActiveFilterString = ""
            Me.SearchableComboBoxTransferFrom_Division.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTransferFrom_Division.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxTransferFrom_Division.AutoFillMode = False
            Me.SearchableComboBoxTransferFrom_Division.BookmarkingEnabled = False
            Me.SearchableComboBoxTransferFrom_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Division
            Me.SearchableComboBoxTransferFrom_Division.DataSource = Nothing
            Me.SearchableComboBoxTransferFrom_Division.DisableMouseWheel = True
            Me.SearchableComboBoxTransferFrom_Division.DisplayName = ""
            Me.SearchableComboBoxTransferFrom_Division.EnterMoveNextControl = True
            Me.SearchableComboBoxTransferFrom_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxTransferFrom_Division.Location = New System.Drawing.Point(101, 50)
            Me.SearchableComboBoxTransferFrom_Division.Name = "SearchableComboBoxTransferFrom_Division"
            Me.SearchableComboBoxTransferFrom_Division.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTransferFrom_Division.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxTransferFrom_Division.Properties.NullText = "Select Division"
            Me.SearchableComboBoxTransferFrom_Division.Properties.ReadOnly = True
            Me.SearchableComboBoxTransferFrom_Division.Properties.ShowClearButton = False
            Me.SearchableComboBoxTransferFrom_Division.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTransferFrom_Division.Properties.View = Me.GridView13
            Me.SearchableComboBoxTransferFrom_Division.SecurityEnabled = True
            Me.SearchableComboBoxTransferFrom_Division.SelectedValue = Nothing
            Me.SearchableComboBoxTransferFrom_Division.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxTransferFrom_Division.TabIndex = 3
            Me.SearchableComboBoxTransferFrom_Division.TabStop = False
            '
            'GridView13
            '
            Me.GridView13.AFActiveFilterString = ""
            Me.GridView13.AllowExtraItemsInGridLookupEdits = True
            Me.GridView13.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AutoFilterLookupColumns = False
            Me.GridView13.AutoloadRepositoryDatasource = True
            Me.GridView13.DataSourceClearing = False
            Me.GridView13.EnableDisabledRows = False
            Me.GridView13.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView13.Name = "GridView13"
            Me.GridView13.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView13.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView13.OptionsBehavior.Editable = False
            Me.GridView13.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView13.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView13.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView13.OptionsSelection.MultiSelect = True
            Me.GridView13.OptionsView.ColumnAutoWidth = False
            Me.GridView13.OptionsView.ShowGroupPanel = False
            Me.GridView13.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView13.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView13.RunStandardValidation = True
            '
            'SearchableComboBoxTransferFrom_Item
            '
            Me.SearchableComboBoxTransferFrom_Item.ActiveFilterString = ""
            Me.SearchableComboBoxTransferFrom_Item.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTransferFrom_Item.AutoFillMode = False
            Me.SearchableComboBoxTransferFrom_Item.BookmarkingEnabled = False
            Me.SearchableComboBoxTransferFrom_Item.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Client
            Me.SearchableComboBoxTransferFrom_Item.DataSource = Nothing
            Me.SearchableComboBoxTransferFrom_Item.DisableMouseWheel = True
            Me.SearchableComboBoxTransferFrom_Item.DisplayName = ""
            Me.SearchableComboBoxTransferFrom_Item.EnterMoveNextControl = True
            Me.SearchableComboBoxTransferFrom_Item.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxTransferFrom_Item.Location = New System.Drawing.Point(101, 205)
            Me.SearchableComboBoxTransferFrom_Item.Name = "SearchableComboBoxTransferFrom_Item"
            Me.SearchableComboBoxTransferFrom_Item.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTransferFrom_Item.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxTransferFrom_Item.Properties.NullText = "Select Client"
            Me.SearchableComboBoxTransferFrom_Item.Properties.ReadOnly = True
            Me.SearchableComboBoxTransferFrom_Item.Properties.ShowClearButton = False
            Me.SearchableComboBoxTransferFrom_Item.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTransferFrom_Item.Properties.View = Me.GridView10
            Me.SearchableComboBoxTransferFrom_Item.SecurityEnabled = True
            Me.SearchableComboBoxTransferFrom_Item.SelectedValue = Nothing
            Me.SearchableComboBoxTransferFrom_Item.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxTransferFrom_Item.TabIndex = 17
            Me.SearchableComboBoxTransferFrom_Item.TabStop = False
            '
            'GridView10
            '
            Me.GridView10.AFActiveFilterString = ""
            Me.GridView10.AllowExtraItemsInGridLookupEdits = True
            Me.GridView10.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView10.AutoFilterLookupColumns = False
            Me.GridView10.AutoloadRepositoryDatasource = True
            Me.GridView10.DataSourceClearing = False
            Me.GridView10.EnableDisabledRows = False
            Me.GridView10.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView10.Name = "GridView10"
            Me.GridView10.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView10.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView10.OptionsBehavior.Editable = False
            Me.GridView10.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView10.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView10.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView10.OptionsSelection.MultiSelect = True
            Me.GridView10.OptionsView.ColumnAutoWidth = False
            Me.GridView10.OptionsView.ShowGroupPanel = False
            Me.GridView10.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView10.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView10.RunStandardValidation = True
            '
            'SearchableComboBoxTransferFrom_Product
            '
            Me.SearchableComboBoxTransferFrom_Product.ActiveFilterString = ""
            Me.SearchableComboBoxTransferFrom_Product.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTransferFrom_Product.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxTransferFrom_Product.AutoFillMode = False
            Me.SearchableComboBoxTransferFrom_Product.BookmarkingEnabled = False
            Me.SearchableComboBoxTransferFrom_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Product
            Me.SearchableComboBoxTransferFrom_Product.DataSource = Nothing
            Me.SearchableComboBoxTransferFrom_Product.DisableMouseWheel = True
            Me.SearchableComboBoxTransferFrom_Product.DisplayName = ""
            Me.SearchableComboBoxTransferFrom_Product.EnterMoveNextControl = True
            Me.SearchableComboBoxTransferFrom_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxTransferFrom_Product.Location = New System.Drawing.Point(101, 76)
            Me.SearchableComboBoxTransferFrom_Product.Name = "SearchableComboBoxTransferFrom_Product"
            Me.SearchableComboBoxTransferFrom_Product.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTransferFrom_Product.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxTransferFrom_Product.Properties.NullText = "Select Product"
            Me.SearchableComboBoxTransferFrom_Product.Properties.ReadOnly = True
            Me.SearchableComboBoxTransferFrom_Product.Properties.ShowClearButton = False
            Me.SearchableComboBoxTransferFrom_Product.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTransferFrom_Product.Properties.View = Me.GridView14
            Me.SearchableComboBoxTransferFrom_Product.SecurityEnabled = True
            Me.SearchableComboBoxTransferFrom_Product.SelectedValue = Nothing
            Me.SearchableComboBoxTransferFrom_Product.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxTransferFrom_Product.TabIndex = 5
            Me.SearchableComboBoxTransferFrom_Product.TabStop = False
            '
            'GridView14
            '
            Me.GridView14.AFActiveFilterString = ""
            Me.GridView14.AllowExtraItemsInGridLookupEdits = True
            Me.GridView14.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView14.AutoFilterLookupColumns = False
            Me.GridView14.AutoloadRepositoryDatasource = True
            Me.GridView14.DataSourceClearing = False
            Me.GridView14.EnableDisabledRows = False
            Me.GridView14.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView14.Name = "GridView14"
            Me.GridView14.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView14.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView14.OptionsBehavior.Editable = False
            Me.GridView14.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView14.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView14.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView14.OptionsSelection.MultiSelect = True
            Me.GridView14.OptionsView.ColumnAutoWidth = False
            Me.GridView14.OptionsView.ShowGroupPanel = False
            Me.GridView14.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView14.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView14.RunStandardValidation = True
            '
            'SearchableComboBoxTransferFrom_Client
            '
            Me.SearchableComboBoxTransferFrom_Client.ActiveFilterString = ""
            Me.SearchableComboBoxTransferFrom_Client.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTransferFrom_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxTransferFrom_Client.AutoFillMode = False
            Me.SearchableComboBoxTransferFrom_Client.BookmarkingEnabled = False
            Me.SearchableComboBoxTransferFrom_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Client
            Me.SearchableComboBoxTransferFrom_Client.DataSource = Nothing
            Me.SearchableComboBoxTransferFrom_Client.DisableMouseWheel = True
            Me.SearchableComboBoxTransferFrom_Client.DisplayName = ""
            Me.SearchableComboBoxTransferFrom_Client.EnterMoveNextControl = True
            Me.SearchableComboBoxTransferFrom_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxTransferFrom_Client.Location = New System.Drawing.Point(101, 24)
            Me.SearchableComboBoxTransferFrom_Client.Name = "SearchableComboBoxTransferFrom_Client"
            Me.SearchableComboBoxTransferFrom_Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTransferFrom_Client.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxTransferFrom_Client.Properties.NullText = "Select Client"
            Me.SearchableComboBoxTransferFrom_Client.Properties.ReadOnly = True
            Me.SearchableComboBoxTransferFrom_Client.Properties.ShowClearButton = False
            Me.SearchableComboBoxTransferFrom_Client.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTransferFrom_Client.Properties.View = Me.GridView15
            Me.SearchableComboBoxTransferFrom_Client.SecurityEnabled = True
            Me.SearchableComboBoxTransferFrom_Client.SelectedValue = Nothing
            Me.SearchableComboBoxTransferFrom_Client.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxTransferFrom_Client.TabIndex = 1
            Me.SearchableComboBoxTransferFrom_Client.TabStop = False
            '
            'GridView15
            '
            Me.GridView15.AFActiveFilterString = ""
            Me.GridView15.AllowExtraItemsInGridLookupEdits = True
            Me.GridView15.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView15.AutoFilterLookupColumns = False
            Me.GridView15.AutoloadRepositoryDatasource = True
            Me.GridView15.DataSourceClearing = False
            Me.GridView15.EnableDisabledRows = False
            Me.GridView15.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView15.Name = "GridView15"
            Me.GridView15.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView15.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView15.OptionsBehavior.Editable = False
            Me.GridView15.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView15.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView15.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView15.OptionsSelection.MultiSelect = True
            Me.GridView15.OptionsView.ColumnAutoWidth = False
            Me.GridView15.OptionsView.ShowGroupPanel = False
            Me.GridView15.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView15.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView15.RunStandardValidation = True
            '
            'NumericInputTransferFrom_Approved
            '
            Me.NumericInputTransferFrom_Approved.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTransferFrom_Approved.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTransferFrom_Approved.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTransferFrom_Approved.EnterMoveNextControl = True
            Me.NumericInputTransferFrom_Approved.Location = New System.Drawing.Point(297, 180)
            Me.NumericInputTransferFrom_Approved.Name = "NumericInputTransferFrom_Approved"
            Me.NumericInputTransferFrom_Approved.Properties.AllowMouseWheel = False
            Me.NumericInputTransferFrom_Approved.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputTransferFrom_Approved.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTransferFrom_Approved.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_Approved.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_Approved.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_Approved.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_Approved.Properties.Mask.EditMask = "f"
            Me.NumericInputTransferFrom_Approved.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTransferFrom_Approved.Properties.MaxLength = 6
            Me.NumericInputTransferFrom_Approved.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputTransferFrom_Approved.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputTransferFrom_Approved.Properties.ReadOnly = True
            Me.NumericInputTransferFrom_Approved.SecurityEnabled = True
            Me.NumericInputTransferFrom_Approved.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputTransferFrom_Approved.TabIndex = 15
            Me.NumericInputTransferFrom_Approved.TabStop = False
            '
            'TextBoxTransferFrom_Description
            '
            Me.TextBoxTransferFrom_Description.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxTransferFrom_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxTransferFrom_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxTransferFrom_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTransferFrom_Description.CheckSpellingOnValidate = False
            Me.TextBoxTransferFrom_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTransferFrom_Description.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxTransferFrom_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxTransferFrom_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTransferFrom_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTransferFrom_Description.FocusHighlightEnabled = True
            Me.TextBoxTransferFrom_Description.ForeColor = System.Drawing.Color.Black
            Me.TextBoxTransferFrom_Description.Location = New System.Drawing.Point(101, 205)
            Me.TextBoxTransferFrom_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxTransferFrom_Description.Name = "TextBoxTransferFrom_Description"
            Me.TextBoxTransferFrom_Description.ReadOnly = True
            Me.TextBoxTransferFrom_Description.SecurityEnabled = True
            Me.TextBoxTransferFrom_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTransferFrom_Description.Size = New System.Drawing.Size(290, 21)
            Me.TextBoxTransferFrom_Description.StartingFolderName = Nothing
            Me.TextBoxTransferFrom_Description.TabIndex = 12
            Me.TextBoxTransferFrom_Description.TabOnEnter = True
            Me.TextBoxTransferFrom_Description.TabStop = False
            Me.TextBoxTransferFrom_Description.Tag = ""
            '
            'NumericInputTransferFrom_Unbilled
            '
            Me.NumericInputTransferFrom_Unbilled.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTransferFrom_Unbilled.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTransferFrom_Unbilled.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTransferFrom_Unbilled.EnterMoveNextControl = True
            Me.NumericInputTransferFrom_Unbilled.Location = New System.Drawing.Point(101, 180)
            Me.NumericInputTransferFrom_Unbilled.Name = "NumericInputTransferFrom_Unbilled"
            Me.NumericInputTransferFrom_Unbilled.Properties.AllowMouseWheel = False
            Me.NumericInputTransferFrom_Unbilled.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputTransferFrom_Unbilled.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTransferFrom_Unbilled.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_Unbilled.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_Unbilled.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputTransferFrom_Unbilled.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferFrom_Unbilled.Properties.Mask.EditMask = "f"
            Me.NumericInputTransferFrom_Unbilled.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTransferFrom_Unbilled.Properties.MaxLength = 6
            Me.NumericInputTransferFrom_Unbilled.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputTransferFrom_Unbilled.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputTransferFrom_Unbilled.Properties.ReadOnly = True
            Me.NumericInputTransferFrom_Unbilled.SecurityEnabled = True
            Me.NumericInputTransferFrom_Unbilled.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputTransferFrom_Unbilled.TabIndex = 13
            Me.NumericInputTransferFrom_Unbilled.TabStop = False
            '
            'LabelTransferFrom_Item
            '
            Me.LabelTransferFrom_Item.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_Item.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_Item.Location = New System.Drawing.Point(5, 206)
            Me.LabelTransferFrom_Item.Name = "LabelTransferFrom_Item"
            Me.LabelTransferFrom_Item.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferFrom_Item.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_Item.TabIndex = 16
            Me.LabelTransferFrom_Item.Text = "Item:"
            '
            'SearchableComboBoxTransferFrom_Function
            '
            Me.SearchableComboBoxTransferFrom_Function.ActiveFilterString = ""
            Me.SearchableComboBoxTransferFrom_Function.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTransferFrom_Function.AutoFillMode = False
            Me.SearchableComboBoxTransferFrom_Function.BookmarkingEnabled = False
            Me.SearchableComboBoxTransferFrom_Function.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.[Function]
            Me.SearchableComboBoxTransferFrom_Function.DataSource = Nothing
            Me.SearchableComboBoxTransferFrom_Function.DisableMouseWheel = True
            Me.SearchableComboBoxTransferFrom_Function.DisplayName = ""
            Me.SearchableComboBoxTransferFrom_Function.EnterMoveNextControl = True
            Me.SearchableComboBoxTransferFrom_Function.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxTransferFrom_Function.Location = New System.Drawing.Point(101, 154)
            Me.SearchableComboBoxTransferFrom_Function.Name = "SearchableComboBoxTransferFrom_Function"
            Me.SearchableComboBoxTransferFrom_Function.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTransferFrom_Function.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxTransferFrom_Function.Properties.NullText = "Select Function"
            Me.SearchableComboBoxTransferFrom_Function.Properties.ReadOnly = True
            Me.SearchableComboBoxTransferFrom_Function.Properties.ShowClearButton = False
            Me.SearchableComboBoxTransferFrom_Function.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTransferFrom_Function.Properties.View = Me.GridView2
            Me.SearchableComboBoxTransferFrom_Function.SecurityEnabled = True
            Me.SearchableComboBoxTransferFrom_Function.SelectedValue = Nothing
            Me.SearchableComboBoxTransferFrom_Function.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxTransferFrom_Function.TabIndex = 11
            Me.SearchableComboBoxTransferFrom_Function.TabStop = False
            '
            'GridView2
            '
            Me.GridView2.AFActiveFilterString = ""
            Me.GridView2.AllowExtraItemsInGridLookupEdits = True
            Me.GridView2.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AutoFilterLookupColumns = False
            Me.GridView2.AutoloadRepositoryDatasource = True
            Me.GridView2.DataSourceClearing = False
            Me.GridView2.EnableDisabledRows = False
            Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView2.Name = "GridView2"
            Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView2.OptionsBehavior.Editable = False
            Me.GridView2.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView2.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView2.OptionsSelection.MultiSelect = True
            Me.GridView2.OptionsView.ColumnAutoWidth = False
            Me.GridView2.OptionsView.ShowGroupPanel = False
            Me.GridView2.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView2.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView2.RunStandardValidation = True
            '
            'SearchableComboBoxTransferFrom_JobComponent
            '
            Me.SearchableComboBoxTransferFrom_JobComponent.ActiveFilterString = ""
            Me.SearchableComboBoxTransferFrom_JobComponent.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTransferFrom_JobComponent.AutoFillMode = False
            Me.SearchableComboBoxTransferFrom_JobComponent.BookmarkingEnabled = False
            Me.SearchableComboBoxTransferFrom_JobComponent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.JobComponent
            Me.SearchableComboBoxTransferFrom_JobComponent.DataSource = Nothing
            Me.SearchableComboBoxTransferFrom_JobComponent.DisableMouseWheel = True
            Me.SearchableComboBoxTransferFrom_JobComponent.DisplayName = ""
            Me.SearchableComboBoxTransferFrom_JobComponent.EnterMoveNextControl = True
            Me.SearchableComboBoxTransferFrom_JobComponent.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxTransferFrom_JobComponent.Location = New System.Drawing.Point(101, 128)
            Me.SearchableComboBoxTransferFrom_JobComponent.Name = "SearchableComboBoxTransferFrom_JobComponent"
            Me.SearchableComboBoxTransferFrom_JobComponent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTransferFrom_JobComponent.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxTransferFrom_JobComponent.Properties.NullText = "Select Job Component"
            Me.SearchableComboBoxTransferFrom_JobComponent.Properties.ReadOnly = True
            Me.SearchableComboBoxTransferFrom_JobComponent.Properties.ShowClearButton = False
            Me.SearchableComboBoxTransferFrom_JobComponent.Properties.ValueMember = "Number"
            Me.SearchableComboBoxTransferFrom_JobComponent.Properties.View = Me.GridView1
            Me.SearchableComboBoxTransferFrom_JobComponent.SecurityEnabled = True
            Me.SearchableComboBoxTransferFrom_JobComponent.SelectedValue = Nothing
            Me.SearchableComboBoxTransferFrom_JobComponent.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxTransferFrom_JobComponent.TabIndex = 9
            Me.SearchableComboBoxTransferFrom_JobComponent.TabStop = False
            '
            'GridView1
            '
            Me.GridView1.AFActiveFilterString = ""
            Me.GridView1.AllowExtraItemsInGridLookupEdits = True
            Me.GridView1.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AutoFilterLookupColumns = False
            Me.GridView1.AutoloadRepositoryDatasource = True
            Me.GridView1.DataSourceClearing = False
            Me.GridView1.EnableDisabledRows = False
            Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView1.OptionsBehavior.Editable = False
            Me.GridView1.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView1.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView1.OptionsSelection.MultiSelect = True
            Me.GridView1.OptionsView.ColumnAutoWidth = False
            Me.GridView1.OptionsView.ShowGroupPanel = False
            Me.GridView1.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView1.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView1.RunStandardValidation = True
            '
            'SearchableComboBoxTransferFrom_Job
            '
            Me.SearchableComboBoxTransferFrom_Job.ActiveFilterString = ""
            Me.SearchableComboBoxTransferFrom_Job.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTransferFrom_Job.AutoFillMode = False
            Me.SearchableComboBoxTransferFrom_Job.BookmarkingEnabled = False
            Me.SearchableComboBoxTransferFrom_Job.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Job
            Me.SearchableComboBoxTransferFrom_Job.DataSource = Nothing
            Me.SearchableComboBoxTransferFrom_Job.DisableMouseWheel = True
            Me.SearchableComboBoxTransferFrom_Job.DisplayName = ""
            Me.SearchableComboBoxTransferFrom_Job.EnterMoveNextControl = True
            Me.SearchableComboBoxTransferFrom_Job.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxTransferFrom_Job.Location = New System.Drawing.Point(101, 102)
            Me.SearchableComboBoxTransferFrom_Job.Name = "SearchableComboBoxTransferFrom_Job"
            Me.SearchableComboBoxTransferFrom_Job.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTransferFrom_Job.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxTransferFrom_Job.Properties.NullText = "Select Job"
            Me.SearchableComboBoxTransferFrom_Job.Properties.ReadOnly = True
            Me.SearchableComboBoxTransferFrom_Job.Properties.ShowClearButton = False
            Me.SearchableComboBoxTransferFrom_Job.Properties.ValueMember = "Number"
            Me.SearchableComboBoxTransferFrom_Job.Properties.View = Me.SearchableComboBoxView_Client
            Me.SearchableComboBoxTransferFrom_Job.SecurityEnabled = True
            Me.SearchableComboBoxTransferFrom_Job.SelectedValue = Nothing
            Me.SearchableComboBoxTransferFrom_Job.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxTransferFrom_Job.TabIndex = 7
            Me.SearchableComboBoxTransferFrom_Job.TabStop = False
            '
            'SearchableComboBoxView_Client
            '
            Me.SearchableComboBoxView_Client.AFActiveFilterString = ""
            Me.SearchableComboBoxView_Client.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_Client.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_Client.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_Client.DataSourceClearing = False
            Me.SearchableComboBoxView_Client.EnableDisabledRows = False
            Me.SearchableComboBoxView_Client.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_Client.Name = "SearchableComboBoxView_Client"
            Me.SearchableComboBoxView_Client.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Client.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Client.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_Client.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_Client.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_Client.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_Client.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_Client.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_Client.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_Client.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_Client.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_Client.RunStandardValidation = True
            '
            'LabelTransferFrom_Approved
            '
            Me.LabelTransferFrom_Approved.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_Approved.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_Approved.Location = New System.Drawing.Point(201, 180)
            Me.LabelTransferFrom_Approved.Name = "LabelTransferFrom_Approved"
            Me.LabelTransferFrom_Approved.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferFrom_Approved.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_Approved.TabIndex = 14
            Me.LabelTransferFrom_Approved.Text = "Approved:"
            '
            'LabelTransferFrom_Unbilled
            '
            Me.LabelTransferFrom_Unbilled.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_Unbilled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_Unbilled.Location = New System.Drawing.Point(5, 180)
            Me.LabelTransferFrom_Unbilled.Name = "LabelTransferFrom_Unbilled"
            Me.LabelTransferFrom_Unbilled.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferFrom_Unbilled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_Unbilled.TabIndex = 12
            Me.LabelTransferFrom_Unbilled.Text = "Unbilled:"
            '
            'LabelTransferFrom_Function
            '
            Me.LabelTransferFrom_Function.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_Function.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_Function.Location = New System.Drawing.Point(5, 154)
            Me.LabelTransferFrom_Function.Name = "LabelTransferFrom_Function"
            Me.LabelTransferFrom_Function.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferFrom_Function.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_Function.TabIndex = 10
            Me.LabelTransferFrom_Function.Text = "Function:"
            '
            'LabelTransferFrom_JobComponent
            '
            Me.LabelTransferFrom_JobComponent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferFrom_JobComponent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferFrom_JobComponent.Location = New System.Drawing.Point(5, 128)
            Me.LabelTransferFrom_JobComponent.Name = "LabelTransferFrom_JobComponent"
            Me.LabelTransferFrom_JobComponent.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferFrom_JobComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferFrom_JobComponent.TabIndex = 8
            Me.LabelTransferFrom_JobComponent.Text = "Job Component:"
            '
            'GroupBoxFrom_TransferTo
            '
            Me.GroupBoxFrom_TransferTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.SearchableComboBoxTransferTo_Task)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_TaskCode)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_Billable)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.CheckBoxTransferTo_Billable)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_RateFrom)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.NumericInputTransferTo_Rate)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_Rate)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.NumericInputTransferTo_QtyHours)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_QtyHours)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_PostPeriod)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_GLAccount)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.SearchableComboBoxTransferTo_PostPeriod)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.SearchableComboBoxTransferTo_GLAccount)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.NumericInputTransferTo_MarkupPercent)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_MarkupPercent)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.NumericInputTransferTo_Total)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_Product)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.NumericInputTransferTo_MarkupAmount)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_Division)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_Client)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.SearchableComboBoxTransferTo_Division)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.SearchableComboBoxTransferTo_Product)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.SearchableComboBoxTransferTo_Client)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.NumericInputTransferTo_ResaleTax)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.NumericInputTransferTo_VendorTax)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.NumericInputTransferTo_Amount)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_MarkupAmount)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_ResaleTax)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_VendorTax)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_Total)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_Amount)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.SearchableComboBoxTransferTo_Tax)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_TaxCode)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.SearchableComboBoxTransferTo_Function)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.SearchableComboBoxTransferTo_JobComponent)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.SearchableComboBoxTransferTo_Job)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_Function)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_JobComponent)
            Me.GroupBoxFrom_TransferTo.Controls.Add(Me.LabelTransferTo_Job)
            Me.GroupBoxFrom_TransferTo.Location = New System.Drawing.Point(414, 12)
            Me.GroupBoxFrom_TransferTo.Name = "GroupBoxFrom_TransferTo"
            Me.GroupBoxFrom_TransferTo.Size = New System.Drawing.Size(396, 477)
            Me.GroupBoxFrom_TransferTo.TabIndex = 1
            Me.GroupBoxFrom_TransferTo.Text = "Transfer To"
            '
            'SearchableComboBoxTransferTo_Task
            '
            Me.SearchableComboBoxTransferTo_Task.ActiveFilterString = ""
            Me.SearchableComboBoxTransferTo_Task.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTransferTo_Task.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxTransferTo_Task.AutoFillMode = False
            Me.SearchableComboBoxTransferTo_Task.BookmarkingEnabled = False
            Me.SearchableComboBoxTransferTo_Task.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Task
            Me.SearchableComboBoxTransferTo_Task.DataSource = Nothing
            Me.SearchableComboBoxTransferTo_Task.DisableMouseWheel = True
            Me.SearchableComboBoxTransferTo_Task.DisplayName = ""
            Me.SearchableComboBoxTransferTo_Task.EnterMoveNextControl = True
            Me.SearchableComboBoxTransferTo_Task.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxTransferTo_Task.Location = New System.Drawing.Point(101, 207)
            Me.SearchableComboBoxTransferTo_Task.Name = "SearchableComboBoxTransferTo_Task"
            Me.SearchableComboBoxTransferTo_Task.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTransferTo_Task.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxTransferTo_Task.Properties.NullText = "Select Task"
            Me.SearchableComboBoxTransferTo_Task.Properties.ShowClearButton = False
            Me.SearchableComboBoxTransferTo_Task.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTransferTo_Task.Properties.View = Me.GridView16
            Me.SearchableComboBoxTransferTo_Task.SecurityEnabled = True
            Me.SearchableComboBoxTransferTo_Task.SelectedValue = Nothing
            Me.SearchableComboBoxTransferTo_Task.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxTransferTo_Task.TabIndex = 15
            Me.SearchableComboBoxTransferTo_Task.Visible = False
            '
            'GridView16
            '
            Me.GridView16.AFActiveFilterString = ""
            Me.GridView16.AllowExtraItemsInGridLookupEdits = True
            Me.GridView16.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView16.AutoFilterLookupColumns = False
            Me.GridView16.AutoloadRepositoryDatasource = True
            Me.GridView16.DataSourceClearing = False
            Me.GridView16.EnableDisabledRows = False
            Me.GridView16.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView16.Name = "GridView16"
            Me.GridView16.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView16.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView16.OptionsBehavior.Editable = False
            Me.GridView16.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView16.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView16.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView16.OptionsSelection.MultiSelect = True
            Me.GridView16.OptionsView.ColumnAutoWidth = False
            Me.GridView16.OptionsView.ShowGroupPanel = False
            Me.GridView16.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView16.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView16.RunStandardValidation = True
            '
            'LabelTransferTo_TaskCode
            '
            Me.LabelTransferTo_TaskCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_TaskCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_TaskCode.Location = New System.Drawing.Point(5, 206)
            Me.LabelTransferTo_TaskCode.Name = "LabelTransferTo_TaskCode"
            Me.LabelTransferTo_TaskCode.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_TaskCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_TaskCode.TabIndex = 14
            Me.LabelTransferTo_TaskCode.Text = "Task:"
            Me.LabelTransferTo_TaskCode.Visible = False
            '
            'LabelTransferTo_Billable
            '
            Me.LabelTransferTo_Billable.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_Billable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_Billable.Location = New System.Drawing.Point(5, 440)
            Me.LabelTransferTo_Billable.Name = "LabelTransferTo_Billable"
            Me.LabelTransferTo_Billable.Size = New System.Drawing.Size(42, 20)
            Me.LabelTransferTo_Billable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_Billable.TabIndex = 39
            Me.LabelTransferTo_Billable.Text = "Billable:"
            '
            'CheckBoxTransferTo_Billable
            '
            Me.CheckBoxTransferTo_Billable.AutoCheck = False
            '
            '
            '
            Me.CheckBoxTransferTo_Billable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTransferTo_Billable.CheckValue = 1
            Me.CheckBoxTransferTo_Billable.CheckValueChecked = 0
            Me.CheckBoxTransferTo_Billable.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTransferTo_Billable.CheckValueUnchecked = 1
            Me.CheckBoxTransferTo_Billable.ChildControls = CType(resources.GetObject("CheckBoxTransferTo_Billable.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTransferTo_Billable.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked0Unchecked1
            Me.CheckBoxTransferTo_Billable.Location = New System.Drawing.Point(53, 442)
            Me.CheckBoxTransferTo_Billable.Name = "CheckBoxTransferTo_Billable"
            Me.CheckBoxTransferTo_Billable.OldestSibling = Nothing
            Me.CheckBoxTransferTo_Billable.SecurityEnabled = True
            Me.CheckBoxTransferTo_Billable.SiblingControls = CType(resources.GetObject("CheckBoxTransferTo_Billable.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTransferTo_Billable.Size = New System.Drawing.Size(29, 23)
            Me.CheckBoxTransferTo_Billable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTransferTo_Billable.TabIndex = 38
            Me.CheckBoxTransferTo_Billable.TabOnEnter = True
            Me.CheckBoxTransferTo_Billable.TabStop = False
            '
            'LabelTransferTo_RateFrom
            '
            Me.LabelTransferTo_RateFrom.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_RateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_RateFrom.Location = New System.Drawing.Point(101, 284)
            Me.LabelTransferTo_RateFrom.Name = "LabelTransferTo_RateFrom"
            Me.LabelTransferTo_RateFrom.Size = New System.Drawing.Size(190, 20)
            Me.LabelTransferTo_RateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_RateFrom.TabIndex = 35
            '
            'NumericInputTransferTo_Rate
            '
            Me.NumericInputTransferTo_Rate.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTransferTo_Rate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputTransferTo_Rate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTransferTo_Rate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTransferTo_Rate.Enabled = False
            Me.NumericInputTransferTo_Rate.EnterMoveNextControl = True
            Me.NumericInputTransferTo_Rate.Location = New System.Drawing.Point(297, 284)
            Me.NumericInputTransferTo_Rate.Name = "NumericInputTransferTo_Rate"
            Me.NumericInputTransferTo_Rate.Properties.AllowMouseWheel = False
            Me.NumericInputTransferTo_Rate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputTransferTo_Rate.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTransferTo_Rate.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputTransferTo_Rate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferTo_Rate.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputTransferTo_Rate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferTo_Rate.Properties.Mask.EditMask = "f"
            Me.NumericInputTransferTo_Rate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTransferTo_Rate.Properties.MaxLength = 6
            Me.NumericInputTransferTo_Rate.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputTransferTo_Rate.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputTransferTo_Rate.Properties.ReadOnly = True
            Me.NumericInputTransferTo_Rate.SecurityEnabled = True
            Me.NumericInputTransferTo_Rate.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputTransferTo_Rate.TabIndex = 21
            Me.NumericInputTransferTo_Rate.TabStop = False
            '
            'LabelTransferTo_Rate
            '
            Me.LabelTransferTo_Rate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_Rate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_Rate.Location = New System.Drawing.Point(5, 284)
            Me.LabelTransferTo_Rate.Name = "LabelTransferTo_Rate"
            Me.LabelTransferTo_Rate.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_Rate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_Rate.TabIndex = 20
            Me.LabelTransferTo_Rate.Text = "From / Rate:"
            '
            'NumericInputTransferTo_QtyHours
            '
            Me.NumericInputTransferTo_QtyHours.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTransferTo_QtyHours.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputTransferTo_QtyHours.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTransferTo_QtyHours.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTransferTo_QtyHours.EnterMoveNextControl = True
            Me.NumericInputTransferTo_QtyHours.Location = New System.Drawing.Point(297, 258)
            Me.NumericInputTransferTo_QtyHours.Name = "NumericInputTransferTo_QtyHours"
            Me.NumericInputTransferTo_QtyHours.Properties.AllowMouseWheel = False
            Me.NumericInputTransferTo_QtyHours.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputTransferTo_QtyHours.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTransferTo_QtyHours.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputTransferTo_QtyHours.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferTo_QtyHours.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputTransferTo_QtyHours.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferTo_QtyHours.Properties.Mask.EditMask = "f"
            Me.NumericInputTransferTo_QtyHours.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTransferTo_QtyHours.Properties.MaxLength = 6
            Me.NumericInputTransferTo_QtyHours.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputTransferTo_QtyHours.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputTransferTo_QtyHours.Properties.ReadOnly = True
            Me.NumericInputTransferTo_QtyHours.SecurityEnabled = True
            Me.NumericInputTransferTo_QtyHours.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputTransferTo_QtyHours.TabIndex = 19
            '
            'LabelTransferTo_QtyHours
            '
            Me.LabelTransferTo_QtyHours.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_QtyHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_QtyHours.Location = New System.Drawing.Point(5, 258)
            Me.LabelTransferTo_QtyHours.Name = "LabelTransferTo_QtyHours"
            Me.LabelTransferTo_QtyHours.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_QtyHours.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_QtyHours.TabIndex = 18
            Me.LabelTransferTo_QtyHours.Text = "Qty / Hours:"
            '
            'LabelTransferTo_PostPeriod
            '
            Me.LabelTransferTo_PostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_PostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_PostPeriod.Location = New System.Drawing.Point(5, 232)
            Me.LabelTransferTo_PostPeriod.Name = "LabelTransferTo_PostPeriod"
            Me.LabelTransferTo_PostPeriod.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_PostPeriod.TabIndex = 16
            Me.LabelTransferTo_PostPeriod.Text = "Post Period:"
            Me.LabelTransferTo_PostPeriod.Visible = False
            '
            'LabelTransferTo_GLAccount
            '
            Me.LabelTransferTo_GLAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_GLAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_GLAccount.Location = New System.Drawing.Point(5, 206)
            Me.LabelTransferTo_GLAccount.Name = "LabelTransferTo_GLAccount"
            Me.LabelTransferTo_GLAccount.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_GLAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_GLAccount.TabIndex = 14
            Me.LabelTransferTo_GLAccount.Text = "GL Account:"
            Me.LabelTransferTo_GLAccount.Visible = False
            '
            'SearchableComboBoxTransferTo_PostPeriod
            '
            Me.SearchableComboBoxTransferTo_PostPeriod.ActiveFilterString = ""
            Me.SearchableComboBoxTransferTo_PostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTransferTo_PostPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxTransferTo_PostPeriod.AutoFillMode = False
            Me.SearchableComboBoxTransferTo_PostPeriod.BookmarkingEnabled = False
            Me.SearchableComboBoxTransferTo_PostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.PostPeriod
            Me.SearchableComboBoxTransferTo_PostPeriod.DataSource = Nothing
            Me.SearchableComboBoxTransferTo_PostPeriod.DisableMouseWheel = True
            Me.SearchableComboBoxTransferTo_PostPeriod.DisplayName = ""
            Me.SearchableComboBoxTransferTo_PostPeriod.EnterMoveNextControl = True
            Me.SearchableComboBoxTransferTo_PostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxTransferTo_PostPeriod.Location = New System.Drawing.Point(101, 232)
            Me.SearchableComboBoxTransferTo_PostPeriod.Name = "SearchableComboBoxTransferTo_PostPeriod"
            Me.SearchableComboBoxTransferTo_PostPeriod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTransferTo_PostPeriod.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxTransferTo_PostPeriod.Properties.NullText = "Select Post Period"
            Me.SearchableComboBoxTransferTo_PostPeriod.Properties.ShowClearButton = False
            Me.SearchableComboBoxTransferTo_PostPeriod.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTransferTo_PostPeriod.Properties.View = Me.GridView12
            Me.SearchableComboBoxTransferTo_PostPeriod.SecurityEnabled = True
            Me.SearchableComboBoxTransferTo_PostPeriod.SelectedValue = Nothing
            Me.SearchableComboBoxTransferTo_PostPeriod.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxTransferTo_PostPeriod.TabIndex = 17
            Me.SearchableComboBoxTransferTo_PostPeriod.Visible = False
            '
            'GridView12
            '
            Me.GridView12.AFActiveFilterString = ""
            Me.GridView12.AllowExtraItemsInGridLookupEdits = True
            Me.GridView12.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView12.AutoFilterLookupColumns = False
            Me.GridView12.AutoloadRepositoryDatasource = True
            Me.GridView12.DataSourceClearing = False
            Me.GridView12.EnableDisabledRows = False
            Me.GridView12.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView12.Name = "GridView12"
            Me.GridView12.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView12.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView12.OptionsBehavior.Editable = False
            Me.GridView12.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView12.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView12.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView12.OptionsSelection.MultiSelect = True
            Me.GridView12.OptionsView.ColumnAutoWidth = False
            Me.GridView12.OptionsView.ShowGroupPanel = False
            Me.GridView12.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView12.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView12.RunStandardValidation = True
            '
            'SearchableComboBoxTransferTo_GLAccount
            '
            Me.SearchableComboBoxTransferTo_GLAccount.ActiveFilterString = ""
            Me.SearchableComboBoxTransferTo_GLAccount.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTransferTo_GLAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxTransferTo_GLAccount.AutoFillMode = False
            Me.SearchableComboBoxTransferTo_GLAccount.BookmarkingEnabled = False
            Me.SearchableComboBoxTransferTo_GLAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxTransferTo_GLAccount.DataSource = Nothing
            Me.SearchableComboBoxTransferTo_GLAccount.DisableMouseWheel = True
            Me.SearchableComboBoxTransferTo_GLAccount.DisplayName = ""
            Me.SearchableComboBoxTransferTo_GLAccount.EnterMoveNextControl = True
            Me.SearchableComboBoxTransferTo_GLAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxTransferTo_GLAccount.Location = New System.Drawing.Point(101, 206)
            Me.SearchableComboBoxTransferTo_GLAccount.Name = "SearchableComboBoxTransferTo_GLAccount"
            Me.SearchableComboBoxTransferTo_GLAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTransferTo_GLAccount.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxTransferTo_GLAccount.Properties.NullText = "Select General Ledger Account"
            Me.SearchableComboBoxTransferTo_GLAccount.Properties.ShowClearButton = False
            Me.SearchableComboBoxTransferTo_GLAccount.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTransferTo_GLAccount.Properties.View = Me.GridView11
            Me.SearchableComboBoxTransferTo_GLAccount.SecurityEnabled = True
            Me.SearchableComboBoxTransferTo_GLAccount.SelectedValue = Nothing
            Me.SearchableComboBoxTransferTo_GLAccount.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxTransferTo_GLAccount.TabIndex = 15
            Me.SearchableComboBoxTransferTo_GLAccount.Visible = False
            '
            'GridView11
            '
            Me.GridView11.AFActiveFilterString = ""
            Me.GridView11.AllowExtraItemsInGridLookupEdits = True
            Me.GridView11.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView11.AutoFilterLookupColumns = False
            Me.GridView11.AutoloadRepositoryDatasource = True
            Me.GridView11.DataSourceClearing = False
            Me.GridView11.EnableDisabledRows = False
            Me.GridView11.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView11.Name = "GridView11"
            Me.GridView11.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView11.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView11.OptionsBehavior.Editable = False
            Me.GridView11.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView11.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView11.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView11.OptionsSelection.MultiSelect = True
            Me.GridView11.OptionsView.ColumnAutoWidth = False
            Me.GridView11.OptionsView.ShowGroupPanel = False
            Me.GridView11.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView11.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView11.RunStandardValidation = True
            '
            'NumericInputTransferTo_MarkupPercent
            '
            Me.NumericInputTransferTo_MarkupPercent.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTransferTo_MarkupPercent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTransferTo_MarkupPercent.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTransferTo_MarkupPercent.EnterMoveNextControl = True
            Me.NumericInputTransferTo_MarkupPercent.Location = New System.Drawing.Point(101, 336)
            Me.NumericInputTransferTo_MarkupPercent.Name = "NumericInputTransferTo_MarkupPercent"
            Me.NumericInputTransferTo_MarkupPercent.Properties.AllowMouseWheel = False
            Me.NumericInputTransferTo_MarkupPercent.Properties.Appearance.BackColor = System.Drawing.Color.White
            Me.NumericInputTransferTo_MarkupPercent.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTransferTo_MarkupPercent.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputTransferTo_MarkupPercent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferTo_MarkupPercent.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputTransferTo_MarkupPercent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferTo_MarkupPercent.Properties.Mask.EditMask = "f"
            Me.NumericInputTransferTo_MarkupPercent.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTransferTo_MarkupPercent.Properties.MaxLength = 6
            Me.NumericInputTransferTo_MarkupPercent.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputTransferTo_MarkupPercent.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputTransferTo_MarkupPercent.SecurityEnabled = True
            Me.NumericInputTransferTo_MarkupPercent.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputTransferTo_MarkupPercent.TabIndex = 26
            '
            'LabelTransferTo_MarkupPercent
            '
            Me.LabelTransferTo_MarkupPercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_MarkupPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_MarkupPercent.Location = New System.Drawing.Point(5, 336)
            Me.LabelTransferTo_MarkupPercent.Name = "LabelTransferTo_MarkupPercent"
            Me.LabelTransferTo_MarkupPercent.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_MarkupPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_MarkupPercent.TabIndex = 25
            Me.LabelTransferTo_MarkupPercent.Text = "Markup %:"
            '
            'NumericInputTransferTo_Total
            '
            Me.NumericInputTransferTo_Total.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTransferTo_Total.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputTransferTo_Total.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTransferTo_Total.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTransferTo_Total.Enabled = False
            Me.NumericInputTransferTo_Total.EnterMoveNextControl = True
            Me.NumericInputTransferTo_Total.Location = New System.Drawing.Point(297, 414)
            Me.NumericInputTransferTo_Total.Name = "NumericInputTransferTo_Total"
            Me.NumericInputTransferTo_Total.Properties.AllowMouseWheel = False
            Me.NumericInputTransferTo_Total.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputTransferTo_Total.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTransferTo_Total.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputTransferTo_Total.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferTo_Total.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputTransferTo_Total.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferTo_Total.Properties.Mask.EditMask = "f"
            Me.NumericInputTransferTo_Total.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTransferTo_Total.Properties.MaxLength = 6
            Me.NumericInputTransferTo_Total.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputTransferTo_Total.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputTransferTo_Total.Properties.ReadOnly = True
            Me.NumericInputTransferTo_Total.SecurityEnabled = True
            Me.NumericInputTransferTo_Total.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputTransferTo_Total.TabIndex = 33
            Me.NumericInputTransferTo_Total.TabStop = False
            '
            'LabelTransferTo_Product
            '
            Me.LabelTransferTo_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_Product.Location = New System.Drawing.Point(5, 76)
            Me.LabelTransferTo_Product.Name = "LabelTransferTo_Product"
            Me.LabelTransferTo_Product.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_Product.TabIndex = 4
            Me.LabelTransferTo_Product.Text = "Product:"
            '
            'NumericInputTransferTo_MarkupAmount
            '
            Me.NumericInputTransferTo_MarkupAmount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTransferTo_MarkupAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputTransferTo_MarkupAmount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTransferTo_MarkupAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTransferTo_MarkupAmount.Enabled = False
            Me.NumericInputTransferTo_MarkupAmount.EnterMoveNextControl = True
            Me.NumericInputTransferTo_MarkupAmount.Location = New System.Drawing.Point(297, 336)
            Me.NumericInputTransferTo_MarkupAmount.Name = "NumericInputTransferTo_MarkupAmount"
            Me.NumericInputTransferTo_MarkupAmount.Properties.AllowMouseWheel = False
            Me.NumericInputTransferTo_MarkupAmount.Properties.Appearance.BackColor = System.Drawing.Color.White
            Me.NumericInputTransferTo_MarkupAmount.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTransferTo_MarkupAmount.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputTransferTo_MarkupAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferTo_MarkupAmount.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputTransferTo_MarkupAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferTo_MarkupAmount.Properties.Mask.EditMask = "f"
            Me.NumericInputTransferTo_MarkupAmount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTransferTo_MarkupAmount.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputTransferTo_MarkupAmount.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputTransferTo_MarkupAmount.SecurityEnabled = True
            Me.NumericInputTransferTo_MarkupAmount.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputTransferTo_MarkupAmount.TabIndex = 27
            '
            'LabelTransferTo_Division
            '
            Me.LabelTransferTo_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_Division.Location = New System.Drawing.Point(5, 50)
            Me.LabelTransferTo_Division.Name = "LabelTransferTo_Division"
            Me.LabelTransferTo_Division.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_Division.TabIndex = 2
            Me.LabelTransferTo_Division.Text = "Division:"
            '
            'LabelTransferTo_Client
            '
            Me.LabelTransferTo_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_Client.Location = New System.Drawing.Point(5, 24)
            Me.LabelTransferTo_Client.Name = "LabelTransferTo_Client"
            Me.LabelTransferTo_Client.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_Client.TabIndex = 0
            Me.LabelTransferTo_Client.Text = "Client:"
            '
            'SearchableComboBoxTransferTo_Division
            '
            Me.SearchableComboBoxTransferTo_Division.ActiveFilterString = ""
            Me.SearchableComboBoxTransferTo_Division.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTransferTo_Division.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxTransferTo_Division.AutoFillMode = False
            Me.SearchableComboBoxTransferTo_Division.BookmarkingEnabled = False
            Me.SearchableComboBoxTransferTo_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Division
            Me.SearchableComboBoxTransferTo_Division.DataSource = Nothing
            Me.SearchableComboBoxTransferTo_Division.DisableMouseWheel = True
            Me.SearchableComboBoxTransferTo_Division.DisplayName = ""
            Me.SearchableComboBoxTransferTo_Division.EnterMoveNextControl = True
            Me.SearchableComboBoxTransferTo_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxTransferTo_Division.Location = New System.Drawing.Point(101, 50)
            Me.SearchableComboBoxTransferTo_Division.Name = "SearchableComboBoxTransferTo_Division"
            Me.SearchableComboBoxTransferTo_Division.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTransferTo_Division.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxTransferTo_Division.Properties.NullText = "Select Division"
            Me.SearchableComboBoxTransferTo_Division.Properties.ShowClearButton = False
            Me.SearchableComboBoxTransferTo_Division.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTransferTo_Division.Properties.View = Me.GridView7
            Me.SearchableComboBoxTransferTo_Division.SecurityEnabled = True
            Me.SearchableComboBoxTransferTo_Division.SelectedValue = Nothing
            Me.SearchableComboBoxTransferTo_Division.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxTransferTo_Division.TabIndex = 3
            '
            'GridView7
            '
            Me.GridView7.AFActiveFilterString = ""
            Me.GridView7.AllowExtraItemsInGridLookupEdits = True
            Me.GridView7.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AutoFilterLookupColumns = False
            Me.GridView7.AutoloadRepositoryDatasource = True
            Me.GridView7.DataSourceClearing = False
            Me.GridView7.EnableDisabledRows = False
            Me.GridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView7.Name = "GridView7"
            Me.GridView7.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView7.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView7.OptionsBehavior.Editable = False
            Me.GridView7.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView7.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView7.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView7.OptionsSelection.MultiSelect = True
            Me.GridView7.OptionsView.ColumnAutoWidth = False
            Me.GridView7.OptionsView.ShowGroupPanel = False
            Me.GridView7.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView7.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView7.RunStandardValidation = True
            '
            'SearchableComboBoxTransferTo_Product
            '
            Me.SearchableComboBoxTransferTo_Product.ActiveFilterString = ""
            Me.SearchableComboBoxTransferTo_Product.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTransferTo_Product.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxTransferTo_Product.AutoFillMode = False
            Me.SearchableComboBoxTransferTo_Product.BookmarkingEnabled = False
            Me.SearchableComboBoxTransferTo_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Product
            Me.SearchableComboBoxTransferTo_Product.DataSource = Nothing
            Me.SearchableComboBoxTransferTo_Product.DisableMouseWheel = True
            Me.SearchableComboBoxTransferTo_Product.DisplayName = ""
            Me.SearchableComboBoxTransferTo_Product.EnterMoveNextControl = True
            Me.SearchableComboBoxTransferTo_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxTransferTo_Product.Location = New System.Drawing.Point(101, 76)
            Me.SearchableComboBoxTransferTo_Product.Name = "SearchableComboBoxTransferTo_Product"
            Me.SearchableComboBoxTransferTo_Product.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTransferTo_Product.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxTransferTo_Product.Properties.NullText = "Select Product"
            Me.SearchableComboBoxTransferTo_Product.Properties.ShowClearButton = False
            Me.SearchableComboBoxTransferTo_Product.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTransferTo_Product.Properties.View = Me.GridView8
            Me.SearchableComboBoxTransferTo_Product.SecurityEnabled = True
            Me.SearchableComboBoxTransferTo_Product.SelectedValue = Nothing
            Me.SearchableComboBoxTransferTo_Product.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxTransferTo_Product.TabIndex = 5
            '
            'GridView8
            '
            Me.GridView8.AFActiveFilterString = ""
            Me.GridView8.AllowExtraItemsInGridLookupEdits = True
            Me.GridView8.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AutoFilterLookupColumns = False
            Me.GridView8.AutoloadRepositoryDatasource = True
            Me.GridView8.DataSourceClearing = False
            Me.GridView8.EnableDisabledRows = False
            Me.GridView8.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView8.Name = "GridView8"
            Me.GridView8.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView8.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView8.OptionsBehavior.Editable = False
            Me.GridView8.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView8.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView8.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView8.OptionsSelection.MultiSelect = True
            Me.GridView8.OptionsView.ColumnAutoWidth = False
            Me.GridView8.OptionsView.ShowGroupPanel = False
            Me.GridView8.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView8.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView8.RunStandardValidation = True
            '
            'SearchableComboBoxTransferTo_Client
            '
            Me.SearchableComboBoxTransferTo_Client.ActiveFilterString = ""
            Me.SearchableComboBoxTransferTo_Client.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTransferTo_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxTransferTo_Client.AutoFillMode = False
            Me.SearchableComboBoxTransferTo_Client.BookmarkingEnabled = False
            Me.SearchableComboBoxTransferTo_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Client
            Me.SearchableComboBoxTransferTo_Client.DataSource = Nothing
            Me.SearchableComboBoxTransferTo_Client.DisableMouseWheel = True
            Me.SearchableComboBoxTransferTo_Client.DisplayName = ""
            Me.SearchableComboBoxTransferTo_Client.EnterMoveNextControl = True
            Me.SearchableComboBoxTransferTo_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxTransferTo_Client.Location = New System.Drawing.Point(101, 24)
            Me.SearchableComboBoxTransferTo_Client.Name = "SearchableComboBoxTransferTo_Client"
            Me.SearchableComboBoxTransferTo_Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTransferTo_Client.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxTransferTo_Client.Properties.NullText = "Select Client"
            Me.SearchableComboBoxTransferTo_Client.Properties.ShowClearButton = False
            Me.SearchableComboBoxTransferTo_Client.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTransferTo_Client.Properties.View = Me.GridView6
            Me.SearchableComboBoxTransferTo_Client.SecurityEnabled = True
            Me.SearchableComboBoxTransferTo_Client.SelectedValue = Nothing
            Me.SearchableComboBoxTransferTo_Client.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxTransferTo_Client.TabIndex = 1
            '
            'GridView6
            '
            Me.GridView6.AFActiveFilterString = ""
            Me.GridView6.AllowExtraItemsInGridLookupEdits = True
            Me.GridView6.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AutoFilterLookupColumns = False
            Me.GridView6.AutoloadRepositoryDatasource = True
            Me.GridView6.DataSourceClearing = False
            Me.GridView6.EnableDisabledRows = False
            Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView6.Name = "GridView6"
            Me.GridView6.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView6.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView6.OptionsBehavior.Editable = False
            Me.GridView6.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView6.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView6.OptionsSelection.MultiSelect = True
            Me.GridView6.OptionsView.ColumnAutoWidth = False
            Me.GridView6.OptionsView.ShowGroupPanel = False
            Me.GridView6.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView6.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView6.RunStandardValidation = True
            '
            'NumericInputTransferTo_ResaleTax
            '
            Me.NumericInputTransferTo_ResaleTax.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTransferTo_ResaleTax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputTransferTo_ResaleTax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTransferTo_ResaleTax.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTransferTo_ResaleTax.Enabled = False
            Me.NumericInputTransferTo_ResaleTax.EnterMoveNextControl = True
            Me.NumericInputTransferTo_ResaleTax.Location = New System.Drawing.Point(297, 388)
            Me.NumericInputTransferTo_ResaleTax.Name = "NumericInputTransferTo_ResaleTax"
            Me.NumericInputTransferTo_ResaleTax.Properties.AllowMouseWheel = False
            Me.NumericInputTransferTo_ResaleTax.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputTransferTo_ResaleTax.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTransferTo_ResaleTax.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputTransferTo_ResaleTax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferTo_ResaleTax.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputTransferTo_ResaleTax.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferTo_ResaleTax.Properties.Mask.EditMask = "f"
            Me.NumericInputTransferTo_ResaleTax.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTransferTo_ResaleTax.Properties.MaxLength = 6
            Me.NumericInputTransferTo_ResaleTax.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputTransferTo_ResaleTax.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputTransferTo_ResaleTax.Properties.ReadOnly = True
            Me.NumericInputTransferTo_ResaleTax.SecurityEnabled = True
            Me.NumericInputTransferTo_ResaleTax.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputTransferTo_ResaleTax.TabIndex = 31
            Me.NumericInputTransferTo_ResaleTax.TabStop = False
            '
            'NumericInputTransferTo_VendorTax
            '
            Me.NumericInputTransferTo_VendorTax.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTransferTo_VendorTax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputTransferTo_VendorTax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTransferTo_VendorTax.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTransferTo_VendorTax.Enabled = False
            Me.NumericInputTransferTo_VendorTax.EnterMoveNextControl = True
            Me.NumericInputTransferTo_VendorTax.Location = New System.Drawing.Point(297, 362)
            Me.NumericInputTransferTo_VendorTax.Name = "NumericInputTransferTo_VendorTax"
            Me.NumericInputTransferTo_VendorTax.Properties.AllowMouseWheel = False
            Me.NumericInputTransferTo_VendorTax.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputTransferTo_VendorTax.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTransferTo_VendorTax.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputTransferTo_VendorTax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferTo_VendorTax.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputTransferTo_VendorTax.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferTo_VendorTax.Properties.Mask.EditMask = "f"
            Me.NumericInputTransferTo_VendorTax.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTransferTo_VendorTax.Properties.MaxLength = 6
            Me.NumericInputTransferTo_VendorTax.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputTransferTo_VendorTax.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputTransferTo_VendorTax.Properties.ReadOnly = True
            Me.NumericInputTransferTo_VendorTax.SecurityEnabled = True
            Me.NumericInputTransferTo_VendorTax.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputTransferTo_VendorTax.TabIndex = 29
            Me.NumericInputTransferTo_VendorTax.TabStop = False
            '
            'NumericInputTransferTo_Amount
            '
            Me.NumericInputTransferTo_Amount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTransferTo_Amount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputTransferTo_Amount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTransferTo_Amount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTransferTo_Amount.EnterMoveNextControl = True
            Me.NumericInputTransferTo_Amount.Location = New System.Drawing.Point(297, 310)
            Me.NumericInputTransferTo_Amount.Name = "NumericInputTransferTo_Amount"
            Me.NumericInputTransferTo_Amount.Properties.AllowMouseWheel = False
            Me.NumericInputTransferTo_Amount.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputTransferTo_Amount.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTransferTo_Amount.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputTransferTo_Amount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferTo_Amount.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputTransferTo_Amount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTransferTo_Amount.Properties.Mask.EditMask = "f"
            Me.NumericInputTransferTo_Amount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTransferTo_Amount.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputTransferTo_Amount.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputTransferTo_Amount.SecurityEnabled = True
            Me.NumericInputTransferTo_Amount.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputTransferTo_Amount.TabIndex = 23
            '
            'LabelTransferTo_MarkupAmount
            '
            Me.LabelTransferTo_MarkupAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_MarkupAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_MarkupAmount.Location = New System.Drawing.Point(201, 336)
            Me.LabelTransferTo_MarkupAmount.Name = "LabelTransferTo_MarkupAmount"
            Me.LabelTransferTo_MarkupAmount.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_MarkupAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_MarkupAmount.TabIndex = 24
            Me.LabelTransferTo_MarkupAmount.Text = "Markup Amount:"
            '
            'LabelTransferTo_ResaleTax
            '
            Me.LabelTransferTo_ResaleTax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_ResaleTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_ResaleTax.Location = New System.Drawing.Point(5, 388)
            Me.LabelTransferTo_ResaleTax.Name = "LabelTransferTo_ResaleTax"
            Me.LabelTransferTo_ResaleTax.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_ResaleTax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_ResaleTax.TabIndex = 30
            Me.LabelTransferTo_ResaleTax.Text = "Resale Tax:"
            '
            'LabelTransferTo_VendorTax
            '
            Me.LabelTransferTo_VendorTax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_VendorTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_VendorTax.Location = New System.Drawing.Point(5, 362)
            Me.LabelTransferTo_VendorTax.Name = "LabelTransferTo_VendorTax"
            Me.LabelTransferTo_VendorTax.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_VendorTax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_VendorTax.TabIndex = 28
            Me.LabelTransferTo_VendorTax.Text = "Vendor Tax:"
            '
            'LabelTransferTo_Total
            '
            Me.LabelTransferTo_Total.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_Total.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_Total.Location = New System.Drawing.Point(5, 414)
            Me.LabelTransferTo_Total.Name = "LabelTransferTo_Total"
            Me.LabelTransferTo_Total.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_Total.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_Total.TabIndex = 32
            Me.LabelTransferTo_Total.Text = "Total:"
            '
            'LabelTransferTo_Amount
            '
            Me.LabelTransferTo_Amount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_Amount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_Amount.Location = New System.Drawing.Point(5, 310)
            Me.LabelTransferTo_Amount.Name = "LabelTransferTo_Amount"
            Me.LabelTransferTo_Amount.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_Amount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_Amount.TabIndex = 22
            Me.LabelTransferTo_Amount.Text = "Amount:"
            '
            'SearchableComboBoxTransferTo_Tax
            '
            Me.SearchableComboBoxTransferTo_Tax.ActiveFilterString = ""
            Me.SearchableComboBoxTransferTo_Tax.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTransferTo_Tax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxTransferTo_Tax.AutoFillMode = False
            Me.SearchableComboBoxTransferTo_Tax.BookmarkingEnabled = False
            Me.SearchableComboBoxTransferTo_Tax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.TaxCode
            Me.SearchableComboBoxTransferTo_Tax.DataSource = Nothing
            Me.SearchableComboBoxTransferTo_Tax.DisableMouseWheel = True
            Me.SearchableComboBoxTransferTo_Tax.DisplayName = ""
            Me.SearchableComboBoxTransferTo_Tax.EnterMoveNextControl = True
            Me.SearchableComboBoxTransferTo_Tax.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxTransferTo_Tax.Location = New System.Drawing.Point(101, 180)
            Me.SearchableComboBoxTransferTo_Tax.Name = "SearchableComboBoxTransferTo_Tax"
            Me.SearchableComboBoxTransferTo_Tax.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTransferTo_Tax.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxTransferTo_Tax.Properties.NullText = "Select Tax Code"
            Me.SearchableComboBoxTransferTo_Tax.Properties.ShowClearButton = False
            Me.SearchableComboBoxTransferTo_Tax.Properties.ValueMember = "TaxCode"
            Me.SearchableComboBoxTransferTo_Tax.Properties.View = Me.GridView9
            Me.SearchableComboBoxTransferTo_Tax.SecurityEnabled = True
            Me.SearchableComboBoxTransferTo_Tax.SelectedValue = Nothing
            Me.SearchableComboBoxTransferTo_Tax.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxTransferTo_Tax.TabIndex = 13
            '
            'GridView9
            '
            Me.GridView9.AFActiveFilterString = ""
            Me.GridView9.AllowExtraItemsInGridLookupEdits = True
            Me.GridView9.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView9.AutoFilterLookupColumns = False
            Me.GridView9.AutoloadRepositoryDatasource = True
            Me.GridView9.DataSourceClearing = False
            Me.GridView9.EnableDisabledRows = False
            Me.GridView9.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView9.Name = "GridView9"
            Me.GridView9.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView9.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView9.OptionsBehavior.Editable = False
            Me.GridView9.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView9.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView9.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView9.OptionsSelection.MultiSelect = True
            Me.GridView9.OptionsView.ColumnAutoWidth = False
            Me.GridView9.OptionsView.ShowGroupPanel = False
            Me.GridView9.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView9.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView9.RunStandardValidation = True
            '
            'LabelTransferTo_TaxCode
            '
            Me.LabelTransferTo_TaxCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_TaxCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_TaxCode.Location = New System.Drawing.Point(5, 180)
            Me.LabelTransferTo_TaxCode.Name = "LabelTransferTo_TaxCode"
            Me.LabelTransferTo_TaxCode.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_TaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_TaxCode.TabIndex = 12
            Me.LabelTransferTo_TaxCode.Text = "Tax Code:"
            '
            'SearchableComboBoxTransferTo_Function
            '
            Me.SearchableComboBoxTransferTo_Function.ActiveFilterString = ""
            Me.SearchableComboBoxTransferTo_Function.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTransferTo_Function.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxTransferTo_Function.AutoFillMode = False
            Me.SearchableComboBoxTransferTo_Function.BookmarkingEnabled = False
            Me.SearchableComboBoxTransferTo_Function.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.[Function]
            Me.SearchableComboBoxTransferTo_Function.DataSource = Nothing
            Me.SearchableComboBoxTransferTo_Function.DisableMouseWheel = True
            Me.SearchableComboBoxTransferTo_Function.DisplayName = ""
            Me.SearchableComboBoxTransferTo_Function.EnterMoveNextControl = True
            Me.SearchableComboBoxTransferTo_Function.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxTransferTo_Function.Location = New System.Drawing.Point(101, 154)
            Me.SearchableComboBoxTransferTo_Function.Name = "SearchableComboBoxTransferTo_Function"
            Me.SearchableComboBoxTransferTo_Function.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTransferTo_Function.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxTransferTo_Function.Properties.NullText = "Select Function"
            Me.SearchableComboBoxTransferTo_Function.Properties.ShowClearButton = False
            Me.SearchableComboBoxTransferTo_Function.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTransferTo_Function.Properties.View = Me.GridView3
            Me.SearchableComboBoxTransferTo_Function.SecurityEnabled = True
            Me.SearchableComboBoxTransferTo_Function.SelectedValue = Nothing
            Me.SearchableComboBoxTransferTo_Function.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxTransferTo_Function.TabIndex = 11
            '
            'GridView3
            '
            Me.GridView3.AFActiveFilterString = ""
            Me.GridView3.AllowExtraItemsInGridLookupEdits = True
            Me.GridView3.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AutoFilterLookupColumns = False
            Me.GridView3.AutoloadRepositoryDatasource = True
            Me.GridView3.DataSourceClearing = False
            Me.GridView3.EnableDisabledRows = False
            Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView3.Name = "GridView3"
            Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView3.OptionsBehavior.Editable = False
            Me.GridView3.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView3.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView3.OptionsSelection.MultiSelect = True
            Me.GridView3.OptionsView.ColumnAutoWidth = False
            Me.GridView3.OptionsView.ShowGroupPanel = False
            Me.GridView3.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView3.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView3.RunStandardValidation = True
            '
            'SearchableComboBoxTransferTo_JobComponent
            '
            Me.SearchableComboBoxTransferTo_JobComponent.ActiveFilterString = ""
            Me.SearchableComboBoxTransferTo_JobComponent.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTransferTo_JobComponent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxTransferTo_JobComponent.AutoFillMode = False
            Me.SearchableComboBoxTransferTo_JobComponent.BookmarkingEnabled = False
            Me.SearchableComboBoxTransferTo_JobComponent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.JobComponent
            Me.SearchableComboBoxTransferTo_JobComponent.DataSource = Nothing
            Me.SearchableComboBoxTransferTo_JobComponent.DisableMouseWheel = True
            Me.SearchableComboBoxTransferTo_JobComponent.DisplayName = ""
            Me.SearchableComboBoxTransferTo_JobComponent.EnterMoveNextControl = True
            Me.SearchableComboBoxTransferTo_JobComponent.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxTransferTo_JobComponent.Location = New System.Drawing.Point(101, 128)
            Me.SearchableComboBoxTransferTo_JobComponent.Name = "SearchableComboBoxTransferTo_JobComponent"
            Me.SearchableComboBoxTransferTo_JobComponent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTransferTo_JobComponent.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxTransferTo_JobComponent.Properties.NullText = "Select Job Component"
            Me.SearchableComboBoxTransferTo_JobComponent.Properties.ShowClearButton = False
            Me.SearchableComboBoxTransferTo_JobComponent.Properties.ValueMember = "Number"
            Me.SearchableComboBoxTransferTo_JobComponent.Properties.View = Me.GridView4
            Me.SearchableComboBoxTransferTo_JobComponent.SecurityEnabled = True
            Me.SearchableComboBoxTransferTo_JobComponent.SelectedValue = Nothing
            Me.SearchableComboBoxTransferTo_JobComponent.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxTransferTo_JobComponent.TabIndex = 9
            '
            'GridView4
            '
            Me.GridView4.AFActiveFilterString = ""
            Me.GridView4.AllowExtraItemsInGridLookupEdits = True
            Me.GridView4.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AutoFilterLookupColumns = False
            Me.GridView4.AutoloadRepositoryDatasource = True
            Me.GridView4.DataSourceClearing = False
            Me.GridView4.EnableDisabledRows = False
            Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView4.Name = "GridView4"
            Me.GridView4.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView4.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView4.OptionsBehavior.Editable = False
            Me.GridView4.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView4.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView4.OptionsSelection.MultiSelect = True
            Me.GridView4.OptionsView.ColumnAutoWidth = False
            Me.GridView4.OptionsView.ShowGroupPanel = False
            Me.GridView4.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView4.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView4.RunStandardValidation = True
            '
            'SearchableComboBoxTransferTo_Job
            '
            Me.SearchableComboBoxTransferTo_Job.ActiveFilterString = ""
            Me.SearchableComboBoxTransferTo_Job.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTransferTo_Job.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxTransferTo_Job.AutoFillMode = False
            Me.SearchableComboBoxTransferTo_Job.BookmarkingEnabled = False
            Me.SearchableComboBoxTransferTo_Job.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Job
            Me.SearchableComboBoxTransferTo_Job.DataSource = Nothing
            Me.SearchableComboBoxTransferTo_Job.DisableMouseWheel = True
            Me.SearchableComboBoxTransferTo_Job.DisplayName = ""
            Me.SearchableComboBoxTransferTo_Job.EnterMoveNextControl = True
            Me.SearchableComboBoxTransferTo_Job.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxTransferTo_Job.Location = New System.Drawing.Point(101, 102)
            Me.SearchableComboBoxTransferTo_Job.Name = "SearchableComboBoxTransferTo_Job"
            Me.SearchableComboBoxTransferTo_Job.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTransferTo_Job.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxTransferTo_Job.Properties.NullText = "Select Job"
            Me.SearchableComboBoxTransferTo_Job.Properties.ShowClearButton = False
            Me.SearchableComboBoxTransferTo_Job.Properties.ValueMember = "Number"
            Me.SearchableComboBoxTransferTo_Job.Properties.View = Me.GridView5
            Me.SearchableComboBoxTransferTo_Job.SecurityEnabled = True
            Me.SearchableComboBoxTransferTo_Job.SelectedValue = Nothing
            Me.SearchableComboBoxTransferTo_Job.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxTransferTo_Job.TabIndex = 7
            '
            'GridView5
            '
            Me.GridView5.AFActiveFilterString = ""
            Me.GridView5.AllowExtraItemsInGridLookupEdits = True
            Me.GridView5.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AutoFilterLookupColumns = False
            Me.GridView5.AutoloadRepositoryDatasource = True
            Me.GridView5.DataSourceClearing = False
            Me.GridView5.EnableDisabledRows = False
            Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView5.Name = "GridView5"
            Me.GridView5.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView5.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView5.OptionsBehavior.Editable = False
            Me.GridView5.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView5.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView5.OptionsSelection.MultiSelect = True
            Me.GridView5.OptionsView.ColumnAutoWidth = False
            Me.GridView5.OptionsView.ShowGroupPanel = False
            Me.GridView5.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView5.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView5.RunStandardValidation = True
            '
            'LabelTransferTo_Function
            '
            Me.LabelTransferTo_Function.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_Function.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_Function.Location = New System.Drawing.Point(5, 154)
            Me.LabelTransferTo_Function.Name = "LabelTransferTo_Function"
            Me.LabelTransferTo_Function.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_Function.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_Function.TabIndex = 10
            Me.LabelTransferTo_Function.Text = "Function:"
            '
            'LabelTransferTo_JobComponent
            '
            Me.LabelTransferTo_JobComponent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_JobComponent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_JobComponent.Location = New System.Drawing.Point(5, 128)
            Me.LabelTransferTo_JobComponent.Name = "LabelTransferTo_JobComponent"
            Me.LabelTransferTo_JobComponent.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_JobComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_JobComponent.TabIndex = 8
            Me.LabelTransferTo_JobComponent.Text = "Job Component:"
            '
            'LabelTransferTo_Job
            '
            Me.LabelTransferTo_Job.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTransferTo_Job.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTransferTo_Job.Location = New System.Drawing.Point(5, 102)
            Me.LabelTransferTo_Job.Name = "LabelTransferTo_Job"
            Me.LabelTransferTo_Job.Size = New System.Drawing.Size(90, 20)
            Me.LabelTransferTo_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTransferTo_Job.TabIndex = 6
            Me.LabelTransferTo_Job.Text = "Job:"
            '
            'LabelForm_Comments
            '
            Me.LabelForm_Comments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Comments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Comments.Location = New System.Drawing.Point(414, 583)
            Me.LabelForm_Comments.Name = "LabelForm_Comments"
            Me.LabelForm_Comments.Size = New System.Drawing.Size(62, 20)
            Me.LabelForm_Comments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Comments.TabIndex = 4
            Me.LabelForm_Comments.Text = "Comments:"
            '
            'TextBoxForm_Comments
            '
            Me.TextBoxForm_Comments.BackColor = System.Drawing.SystemColors.Window
            '
            '
            '
            Me.TextBoxForm_Comments.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Comments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Comments.CheckSpellingOnValidate = False
            Me.TextBoxForm_Comments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Comments.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Comments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Comments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Comments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Comments.FocusHighlightEnabled = True
            Me.TextBoxForm_Comments.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Comments.Location = New System.Drawing.Point(482, 584)
            Me.TextBoxForm_Comments.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Comments.Multiline = True
            Me.TextBoxForm_Comments.Name = "TextBoxForm_Comments"
            Me.TextBoxForm_Comments.SecurityEnabled = True
            Me.TextBoxForm_Comments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Comments.Size = New System.Drawing.Size(328, 36)
            Me.TextBoxForm_Comments.StartingFolderName = Nothing
            Me.TextBoxForm_Comments.TabIndex = 5
            Me.TextBoxForm_Comments.TabOnEnter = True
            Me.TextBoxForm_Comments.Tag = ""
            '
            'GroupBoxForm_EmployeeTimeBillingRate
            '
            Me.GroupBoxForm_EmployeeTimeBillingRate.Controls.Add(Me.RadioButtonTime_TransferAsIs)
            Me.GroupBoxForm_EmployeeTimeBillingRate.Controls.Add(Me.RadioButtonTime_RecalculateFromHierarchy)
            Me.GroupBoxForm_EmployeeTimeBillingRate.Location = New System.Drawing.Point(414, 495)
            Me.GroupBoxForm_EmployeeTimeBillingRate.Name = "GroupBoxForm_EmployeeTimeBillingRate"
            Me.GroupBoxForm_EmployeeTimeBillingRate.Size = New System.Drawing.Size(195, 82)
            Me.GroupBoxForm_EmployeeTimeBillingRate.TabIndex = 2
            Me.GroupBoxForm_EmployeeTimeBillingRate.Text = "Employee Time - Billing Rate"
            '
            'RadioButtonTime_TransferAsIs
            '
            Me.RadioButtonTime_TransferAsIs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonTime_TransferAsIs.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonTime_TransferAsIs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonTime_TransferAsIs.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonTime_TransferAsIs.Location = New System.Drawing.Point(5, 50)
            Me.RadioButtonTime_TransferAsIs.Name = "RadioButtonTime_TransferAsIs"
            Me.RadioButtonTime_TransferAsIs.SecurityEnabled = True
            Me.RadioButtonTime_TransferAsIs.Size = New System.Drawing.Size(185, 20)
            Me.RadioButtonTime_TransferAsIs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonTime_TransferAsIs.TabIndex = 1
            Me.RadioButtonTime_TransferAsIs.TabOnEnter = True
            Me.RadioButtonTime_TransferAsIs.TabStop = False
            Me.RadioButtonTime_TransferAsIs.Text = "Transfer As Is"
            '
            'RadioButtonTime_RecalculateFromHierarchy
            '
            Me.RadioButtonTime_RecalculateFromHierarchy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonTime_RecalculateFromHierarchy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonTime_RecalculateFromHierarchy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonTime_RecalculateFromHierarchy.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonTime_RecalculateFromHierarchy.Checked = True
            Me.RadioButtonTime_RecalculateFromHierarchy.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonTime_RecalculateFromHierarchy.CheckValue = "Y"
            Me.RadioButtonTime_RecalculateFromHierarchy.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonTime_RecalculateFromHierarchy.Name = "RadioButtonTime_RecalculateFromHierarchy"
            Me.RadioButtonTime_RecalculateFromHierarchy.SecurityEnabled = True
            Me.RadioButtonTime_RecalculateFromHierarchy.Size = New System.Drawing.Size(185, 20)
            Me.RadioButtonTime_RecalculateFromHierarchy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonTime_RecalculateFromHierarchy.TabIndex = 0
            Me.RadioButtonTime_RecalculateFromHierarchy.TabOnEnter = True
            Me.RadioButtonTime_RecalculateFromHierarchy.Text = "Recalculate From Hierarchy"
            '
            'GroupBoxForm_MarkupPercent
            '
            Me.GroupBoxForm_MarkupPercent.Controls.Add(Me.RadioButtonMarkup_TransferAsIs)
            Me.GroupBoxForm_MarkupPercent.Controls.Add(Me.RadioButtonMarkup_RecalculateFromHierarchy)
            Me.GroupBoxForm_MarkupPercent.Location = New System.Drawing.Point(615, 495)
            Me.GroupBoxForm_MarkupPercent.Name = "GroupBoxForm_MarkupPercent"
            Me.GroupBoxForm_MarkupPercent.Size = New System.Drawing.Size(195, 82)
            Me.GroupBoxForm_MarkupPercent.TabIndex = 3
            Me.GroupBoxForm_MarkupPercent.Text = "Markup Percent"
            '
            'RadioButtonMarkup_TransferAsIs
            '
            Me.RadioButtonMarkup_TransferAsIs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonMarkup_TransferAsIs.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMarkup_TransferAsIs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMarkup_TransferAsIs.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMarkup_TransferAsIs.Location = New System.Drawing.Point(5, 50)
            Me.RadioButtonMarkup_TransferAsIs.Name = "RadioButtonMarkup_TransferAsIs"
            Me.RadioButtonMarkup_TransferAsIs.SecurityEnabled = True
            Me.RadioButtonMarkup_TransferAsIs.Size = New System.Drawing.Size(185, 20)
            Me.RadioButtonMarkup_TransferAsIs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMarkup_TransferAsIs.TabIndex = 1
            Me.RadioButtonMarkup_TransferAsIs.TabOnEnter = True
            Me.RadioButtonMarkup_TransferAsIs.TabStop = False
            Me.RadioButtonMarkup_TransferAsIs.Text = "Transfer As Is"
            '
            'RadioButtonMarkup_RecalculateFromHierarchy
            '
            Me.RadioButtonMarkup_RecalculateFromHierarchy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonMarkup_RecalculateFromHierarchy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMarkup_RecalculateFromHierarchy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMarkup_RecalculateFromHierarchy.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMarkup_RecalculateFromHierarchy.Checked = True
            Me.RadioButtonMarkup_RecalculateFromHierarchy.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonMarkup_RecalculateFromHierarchy.CheckValue = "Y"
            Me.RadioButtonMarkup_RecalculateFromHierarchy.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonMarkup_RecalculateFromHierarchy.Name = "RadioButtonMarkup_RecalculateFromHierarchy"
            Me.RadioButtonMarkup_RecalculateFromHierarchy.SecurityEnabled = True
            Me.RadioButtonMarkup_RecalculateFromHierarchy.Size = New System.Drawing.Size(185, 20)
            Me.RadioButtonMarkup_RecalculateFromHierarchy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMarkup_RecalculateFromHierarchy.TabIndex = 0
            Me.RadioButtonMarkup_RecalculateFromHierarchy.TabOnEnter = True
            Me.RadioButtonMarkup_RecalculateFromHierarchy.Text = "Recalculate From Hierarchy"
            '
            'TransferItemDetailDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(822, 658)
            Me.Controls.Add(Me.GroupBoxForm_MarkupPercent)
            Me.Controls.Add(Me.GroupBoxForm_EmployeeTimeBillingRate)
            Me.Controls.Add(Me.LabelForm_Comments)
            Me.Controls.Add(Me.GroupBoxFrom_TransferTo)
            Me.Controls.Add(Me.GroupBoxForm_TransferFrom)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.TextBoxForm_Comments)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "TransferItemDetailDialog"
            Me.Text = "Transfer Item Detail"
            CType(Me.GroupBoxForm_TransferFrom, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_TransferFrom.ResumeLayout(False)
            CType(Me.NumericInputTransferFrom_Rate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTransferFrom_Total.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTransferFrom_MarkupAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTransferFrom_ResaleTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTransferFrom_VendorTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTransferFrom_Amount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTransferFrom_QtyHours.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTransferFrom_Division.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView13, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTransferFrom_Item.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView10, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTransferFrom_Product.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView14, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTransferFrom_Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView15, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTransferFrom_Approved.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTransferFrom_Unbilled.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTransferFrom_Function.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTransferFrom_JobComponent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTransferFrom_Job.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_Client, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxFrom_TransferTo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxFrom_TransferTo.ResumeLayout(False)
            CType(Me.SearchableComboBoxTransferTo_Task.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView16, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTransferTo_Rate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTransferTo_QtyHours.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTransferTo_PostPeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView12, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTransferTo_GLAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView11, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTransferTo_MarkupPercent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTransferTo_Total.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTransferTo_MarkupAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTransferTo_Division.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTransferTo_Product.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTransferTo_Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTransferTo_ResaleTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTransferTo_VendorTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTransferTo_Amount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTransferTo_Tax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView9, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTransferTo_Function.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTransferTo_JobComponent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTransferTo_Job.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_EmployeeTimeBillingRate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_EmployeeTimeBillingRate.ResumeLayout(False)
            CType(Me.GroupBoxForm_MarkupPercent, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_MarkupPercent.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelTransferFrom_Job As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxForm_TransferFrom As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelTransferFrom_Approved As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferFrom_Unbilled As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferFrom_Function As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferFrom_JobComponent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxTransferFrom_Function As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxTransferFrom_JobComponent As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxTransferFrom_Job As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_Client As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents NumericInputTransferFrom_Approved As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTransferFrom_Unbilled As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelTransferTo_JobComponent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferTo_Function As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferTo_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxFrom_TransferTo As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents SearchableComboBoxTransferTo_Function As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView3 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxTransferTo_JobComponent As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView4 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxTransferTo_Job As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView5 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelTransferTo_Job As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferTo_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxTransferTo_Product As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView8 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxTransferTo_Division As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView7 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxTransferTo_Client As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView6 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelTransferTo_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxTransferTo_Tax As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView9 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelTransferTo_TaxCode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferFrom_Item As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxTransferFrom_Item As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView10 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelTransferTo_Total As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferTo_VendorTax As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferTo_ResaleTax As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferTo_MarkupAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferTo_Amount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputTransferTo_MarkupPercent As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelTransferTo_MarkupPercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputTransferTo_Total As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTransferTo_MarkupAmount As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTransferTo_ResaleTax As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTransferTo_VendorTax As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTransferTo_Amount As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelTransferTo_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferTo_GLAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxTransferTo_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView12 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxTransferTo_GLAccount As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView11 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelForm_Comments As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Comments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputTransferTo_QtyHours As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelTransferTo_QtyHours As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxTransferFrom_Invoice As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelTransferFrom_Invoice As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxTransferFrom_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputTransferFrom_Total As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTransferFrom_MarkupAmount As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTransferFrom_ResaleTax As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTransferFrom_VendorTax As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTransferFrom_Amount As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTransferFrom_QtyHours As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelTransferFrom_Total As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferFrom_MarkupAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferFrom_ResaleTax As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferFrom_VendorTax As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferFrom_Amount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferFrom_QuantityHours As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferFrom_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferFrom_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferFrom_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxTransferFrom_Division As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView13 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxTransferFrom_Product As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView14 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxTransferFrom_Client As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView15 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelTransferFrom_Rate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputTransferFrom_Rate As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxTransferFrom_Billable As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputTransferTo_Rate As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelTransferTo_Rate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxForm_EmployeeTimeBillingRate As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonTime_TransferAsIs As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonTime_RecalculateFromHierarchy As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxForm_MarkupPercent As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonMarkup_TransferAsIs As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonMarkup_RecalculateFromHierarchy As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelTransferTo_RateFrom As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferFrom_RateFrom As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferFrom_Billable As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTransferTo_Billable As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxTransferTo_Billable As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents SearchableComboBoxTransferTo_Task As WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView16 As WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelTransferTo_TaskCode As WinForm.Presentation.Controls.Label
    End Class

End Namespace