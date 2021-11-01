Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AccountsPayableInvoiceDetailInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountsPayableInvoiceDetailInitialLoadingDialog))
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
            Me.CheckBoxForm_IncludeOpenAccountsPayableOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxForm_MediaOption = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonMediaOption_IncludeBroadcastByOrderLineMonth = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonMediaOption_SummarizeBroadcastByOrder = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_InvoiceDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_DateToPay = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelForm_AgingOption = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_AgingDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_AgingDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.GroupBoxForm_MediaOption, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_MediaOption.SuspendLayout()
            CType(Me.DateTimePickerForm_AgingDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(331, 237)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 15
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(412, 237)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 16
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
            Me.ComboBoxForm_StartingPostPeriod.Size = New System.Drawing.Size(201, 20)
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
            Me.LabelForm_EndingPostPeriod.TabIndex = 4
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
            Me.ComboBoxForm_EndingPostPeriod.Size = New System.Drawing.Size(201, 20)
            Me.ComboBoxForm_EndingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_EndingPostPeriod.TabIndex = 5
            Me.ComboBoxForm_EndingPostPeriod.ValueMember = "Code"
            Me.ComboBoxForm_EndingPostPeriod.WatermarkText = "Select Post Period"
            '
            'ButtonForm_2Years
            '
            Me.ButtonForm_2Years.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_2Years.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_2Years.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_2Years.Location = New System.Drawing.Point(412, 38)
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
            Me.ButtonForm_1Year.Location = New System.Drawing.Point(412, 12)
            Me.ButtonForm_1Year.Name = "ButtonForm_1Year"
            Me.ButtonForm_1Year.SecurityEnabled = True
            Me.ButtonForm_1Year.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_1Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_1Year.TabIndex = 3
            Me.ButtonForm_1Year.Text = "1 Year"
            '
            'ButtonForm_MTD
            '
            Me.ButtonForm_MTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_MTD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_MTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_MTD.Location = New System.Drawing.Point(331, 38)
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
            Me.ButtonForm_YTD.Location = New System.Drawing.Point(331, 12)
            Me.ButtonForm_YTD.Name = "ButtonForm_YTD"
            Me.ButtonForm_YTD.SecurityEnabled = True
            Me.ButtonForm_YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_YTD.TabIndex = 2
            Me.ButtonForm_YTD.Text = "YTD"
            '
            'CheckBoxForm_IncludeOpenAccountsPayableOnly
            '
            '
            '
            '
            Me.CheckBoxForm_IncludeOpenAccountsPayableOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IncludeOpenAccountsPayableOnly.CheckValue = 0
            Me.CheckBoxForm_IncludeOpenAccountsPayableOnly.CheckValueChecked = 1
            Me.CheckBoxForm_IncludeOpenAccountsPayableOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IncludeOpenAccountsPayableOnly.CheckValueUnchecked = 0
            Me.CheckBoxForm_IncludeOpenAccountsPayableOnly.ChildControls = CType(resources.GetObject("CheckBoxForm_IncludeOpenAccountsPayableOnly.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeOpenAccountsPayableOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IncludeOpenAccountsPayableOnly.Location = New System.Drawing.Point(12, 116)
            Me.CheckBoxForm_IncludeOpenAccountsPayableOnly.Name = "CheckBoxForm_IncludeOpenAccountsPayableOnly"
            Me.CheckBoxForm_IncludeOpenAccountsPayableOnly.OldestSibling = Nothing
            Me.CheckBoxForm_IncludeOpenAccountsPayableOnly.SecurityEnabled = True
            Me.CheckBoxForm_IncludeOpenAccountsPayableOnly.SiblingControls = CType(resources.GetObject("CheckBoxForm_IncludeOpenAccountsPayableOnly.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeOpenAccountsPayableOnly.Size = New System.Drawing.Size(313, 20)
            Me.CheckBoxForm_IncludeOpenAccountsPayableOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IncludeOpenAccountsPayableOnly.TabIndex = 13
            Me.CheckBoxForm_IncludeOpenAccountsPayableOnly.Text = "Include Open Accounts Payable Only"
            '
            'GroupBoxForm_MediaOption
            '
            Me.GroupBoxForm_MediaOption.Controls.Add(Me.RadioButtonMediaOption_IncludeBroadcastByOrderLineMonth)
            Me.GroupBoxForm_MediaOption.Controls.Add(Me.RadioButtonMediaOption_SummarizeBroadcastByOrder)
            Me.GroupBoxForm_MediaOption.Location = New System.Drawing.Point(12, 142)
            Me.GroupBoxForm_MediaOption.Name = "GroupBoxForm_MediaOption"
            Me.GroupBoxForm_MediaOption.Size = New System.Drawing.Size(313, 83)
            Me.GroupBoxForm_MediaOption.TabIndex = 14
            Me.GroupBoxForm_MediaOption.Text = "Media Option"
            '
            'RadioButtonMediaOption_IncludeBroadcastByOrderLineMonth
            '
            Me.RadioButtonMediaOption_IncludeBroadcastByOrderLineMonth.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMediaOption_IncludeBroadcastByOrderLineMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMediaOption_IncludeBroadcastByOrderLineMonth.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMediaOption_IncludeBroadcastByOrderLineMonth.Location = New System.Drawing.Point(5, 50)
            Me.RadioButtonMediaOption_IncludeBroadcastByOrderLineMonth.Name = "RadioButtonMediaOption_IncludeBroadcastByOrderLineMonth"
            Me.RadioButtonMediaOption_IncludeBroadcastByOrderLineMonth.SecurityEnabled = True
            Me.RadioButtonMediaOption_IncludeBroadcastByOrderLineMonth.Size = New System.Drawing.Size(303, 20)
            Me.RadioButtonMediaOption_IncludeBroadcastByOrderLineMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMediaOption_IncludeBroadcastByOrderLineMonth.TabIndex = 1
            Me.RadioButtonMediaOption_IncludeBroadcastByOrderLineMonth.TabStop = False
            Me.RadioButtonMediaOption_IncludeBroadcastByOrderLineMonth.Tag = "2"
            Me.RadioButtonMediaOption_IncludeBroadcastByOrderLineMonth.Text = "Include broadcast by order, line-month"
            '
            'RadioButtonMediaOption_SummarizeBroadcastByOrder
            '
            Me.RadioButtonMediaOption_SummarizeBroadcastByOrder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMediaOption_SummarizeBroadcastByOrder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMediaOption_SummarizeBroadcastByOrder.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMediaOption_SummarizeBroadcastByOrder.Checked = True
            Me.RadioButtonMediaOption_SummarizeBroadcastByOrder.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonMediaOption_SummarizeBroadcastByOrder.CheckValue = "Y"
            Me.RadioButtonMediaOption_SummarizeBroadcastByOrder.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonMediaOption_SummarizeBroadcastByOrder.Name = "RadioButtonMediaOption_SummarizeBroadcastByOrder"
            Me.RadioButtonMediaOption_SummarizeBroadcastByOrder.SecurityEnabled = True
            Me.RadioButtonMediaOption_SummarizeBroadcastByOrder.Size = New System.Drawing.Size(303, 20)
            Me.RadioButtonMediaOption_SummarizeBroadcastByOrder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMediaOption_SummarizeBroadcastByOrder.TabIndex = 0
            Me.RadioButtonMediaOption_SummarizeBroadcastByOrder.Tag = "1"
            Me.RadioButtonMediaOption_SummarizeBroadcastByOrder.Text = "Summarize broadcast by order (exclude order line-month)"
            '
            'RadioButtonForm_InvoiceDate
            '
            Me.RadioButtonForm_InvoiceDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_InvoiceDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_InvoiceDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_InvoiceDate.Checked = True
            Me.RadioButtonForm_InvoiceDate.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_InvoiceDate.CheckValue = "Y"
            Me.RadioButtonForm_InvoiceDate.Location = New System.Drawing.Point(124, 90)
            Me.RadioButtonForm_InvoiceDate.Name = "RadioButtonForm_InvoiceDate"
            Me.RadioButtonForm_InvoiceDate.SecurityEnabled = True
            Me.RadioButtonForm_InvoiceDate.Size = New System.Drawing.Size(91, 20)
            Me.RadioButtonForm_InvoiceDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_InvoiceDate.TabIndex = 11
            Me.RadioButtonForm_InvoiceDate.Text = "Invoice Date"
            '
            'RadioButtonForm_DateToPay
            '
            Me.RadioButtonForm_DateToPay.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_DateToPay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_DateToPay.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_DateToPay.Location = New System.Drawing.Point(221, 90)
            Me.RadioButtonForm_DateToPay.Name = "RadioButtonForm_DateToPay"
            Me.RadioButtonForm_DateToPay.SecurityEnabled = True
            Me.RadioButtonForm_DateToPay.Size = New System.Drawing.Size(104, 20)
            Me.RadioButtonForm_DateToPay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_DateToPay.TabIndex = 12
            Me.RadioButtonForm_DateToPay.TabStop = False
            Me.RadioButtonForm_DateToPay.Text = "Date to Pay"
            '
            'LabelForm_AgingOption
            '
            Me.LabelForm_AgingOption.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AgingOption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AgingOption.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_AgingOption.Name = "LabelForm_AgingOption"
            Me.LabelForm_AgingOption.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_AgingOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AgingOption.TabIndex = 10
            Me.LabelForm_AgingOption.Text = "Aging Option:"
            '
            'DateTimePickerForm_AgingDate
            '
            Me.DateTimePickerForm_AgingDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_AgingDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_AgingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_AgingDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_AgingDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_AgingDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_AgingDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_AgingDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_AgingDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_AgingDate.DisplayName = "Aging Date"
            Me.DateTimePickerForm_AgingDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_AgingDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_AgingDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_AgingDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_AgingDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_AgingDate.Location = New System.Drawing.Point(124, 64)
            Me.DateTimePickerForm_AgingDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_AgingDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_AgingDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_AgingDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerForm_AgingDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_AgingDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_AgingDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_AgingDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_AgingDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_AgingDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_AgingDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_AgingDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_AgingDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_AgingDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_AgingDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_AgingDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_AgingDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_AgingDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_AgingDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_AgingDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_AgingDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_AgingDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_AgingDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_AgingDate.Name = "DateTimePickerForm_AgingDate"
            Me.DateTimePickerForm_AgingDate.ReadOnly = False
            Me.DateTimePickerForm_AgingDate.Size = New System.Drawing.Size(201, 20)
            Me.DateTimePickerForm_AgingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_AgingDate.TabIndex = 9
            Me.DateTimePickerForm_AgingDate.Value = New Date(2014, 8, 6, 13, 14, 29, 960)
            '
            'LabelForm_AgingDate
            '
            Me.LabelForm_AgingDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AgingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AgingDate.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_AgingDate.Name = "LabelForm_AgingDate"
            Me.LabelForm_AgingDate.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_AgingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AgingDate.TabIndex = 8
            Me.LabelForm_AgingDate.Text = "Aging Date:"
            '
            'AccountsPayableInvoiceDetailInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(499, 269)
            Me.Controls.Add(Me.RadioButtonForm_InvoiceDate)
            Me.Controls.Add(Me.RadioButtonForm_DateToPay)
            Me.Controls.Add(Me.LabelForm_AgingOption)
            Me.Controls.Add(Me.DateTimePickerForm_AgingDate)
            Me.Controls.Add(Me.LabelForm_AgingDate)
            Me.Controls.Add(Me.GroupBoxForm_MediaOption)
            Me.Controls.Add(Me.CheckBoxForm_IncludeOpenAccountsPayableOnly)
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
            Me.Name = "AccountsPayableInvoiceDetailInitialLoadingDialog"
            Me.Text = "Accounts Payable Invoice Detail Criteria"
            CType(Me.GroupBoxForm_MediaOption, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_MediaOption.ResumeLayout(False)
            CType(Me.DateTimePickerForm_AgingDate, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents CheckBoxForm_IncludeOpenAccountsPayableOnly As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxForm_MediaOption As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonMediaOption_IncludeBroadcastByOrderLineMonth As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonMediaOption_SummarizeBroadcastByOrder As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_InvoiceDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_DateToPay As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelForm_AgingOption As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_AgingDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_AgingDate As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace