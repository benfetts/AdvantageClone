Namespace Billing.Reports.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class InvoicePrintingSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvoicePrintingSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Overrides = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.DateTimePickerOverrides_InvoiceDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerOverrides_DueDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ItemContainerOverrides_OverridesInvoiceDate = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemOverrides_InvoiceDate = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemOverrides_InvoiceDate = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemOverrides_InvoiceDate = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerOverrides_OverridesDueDate = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemOverrides_DueDate = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemOverrides_DueDate = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemOverrides_DueDate = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Comments = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemComments_Job = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemComments_Function = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_InvoiceFormatSettings = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemInvoiceFormatSettings_Client = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemInvoiceFormatSettings_Agency = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemInvoiceFormatSettings_OneTime = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemInvoiceFormatSettings_CustomizeTemplates = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_PrintOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxFormatType_FormatType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ControlContainerItemPrintOptions_FormatType = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerPrintOption_SelectedFormat = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemPrintOption_Spacer = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemPrintOption_SelectedFormat = New DevComponents.DotNetBar.LabelItem()
            Me.RibbonBarOptions_Search = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.DateTimePickerDates_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerDates_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.NumericInputDates_InvoiceNumber = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ItemContainerSeach_Production = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemSearch_Production = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerSeach_MediaGroup1 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemSearch_Magazine = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSearch_Newspaper = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSearch_Internet = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerSeach_MediaGroup2 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemSearch_OutOfHome = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSearch_Radio = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSearch_TV = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerSearch_Spacer = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemSpacer_Spacer = New DevComponents.DotNetBar.LabelItem()
            Me.ItemContainerDates_Dates = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerDates_Top = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemDates_From = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemDates_From = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemDates_YTD = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDates_1Year = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerDates_Bottom = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemDates_To = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemDates_To = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemDates_MTD = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDates_2Years = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemDates_InvoiceNumber = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemDates_InvoiceNumber = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemSearch_Search = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemSearch_DraftInvoices = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_PrintPreview = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemPrint_Print = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPrint_QuickPrint = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPrint_ToFiles = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemToFile_SingleFile = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSingleFile_PDF = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSingleFile_RTF = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSingleFile_XLS = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSingleFile_XLSX = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSingleFile_Image = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSingleFile_SendToDocumentManager = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemToFile_SeparateFiles = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSeparateFiles_PDF = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSeparateFiles_RTF = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSeparateFiles_XLS = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSeparateFiles_XLSX = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSeparateFiles_Image = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSeparateFiles_SendToDocumentManager = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPrint_SendEmails = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPrint_AutoEmail = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerActions_Actions = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemActions_ShowSequenceNumber = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_ShowDivisionProductJobComp = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_CombineCoopInvoices = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DataGridViewForm_Invoices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ContextMenuBarForm_Invoices = New DevComponents.DotNetBar.ContextMenuBar()
            Me.ButtonItemCM_Invoices = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemInovices_SetInvoiceCategory = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Coversheet = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarCoversheet_Options = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemOptions_Settings = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_AutoFill = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBarOptions_Overrides.SuspendLayout()
            CType(Me.DateTimePickerOverrides_InvoiceDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerOverrides_DueDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarOptions_PrintOptions.SuspendLayout()
            Me.RibbonBarOptions_Search.SuspendLayout()
            CType(Me.DateTimePickerDates_From, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerDates_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputDates_InvoiceNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ContextMenuBarForm_Invoices, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarMergeContainerForm_Coversheet.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Overrides)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Comments)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_InvoiceFormatSettings)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_PrintOptions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Search)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(-3, 126)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(970, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 3
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_Overrides
            '
            Me.RibbonBarOptions_Overrides.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Overrides.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Overrides.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Overrides.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Overrides.Controls.Add(Me.DateTimePickerOverrides_InvoiceDate)
            Me.RibbonBarOptions_Overrides.Controls.Add(Me.DateTimePickerOverrides_DueDate)
            Me.RibbonBarOptions_Overrides.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Overrides.DragDropSupport = True
            Me.RibbonBarOptions_Overrides.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Overrides.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerOverrides_OverridesInvoiceDate, Me.ItemContainerOverrides_OverridesDueDate})
            Me.RibbonBarOptions_Overrides.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_Overrides.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Overrides.Location = New System.Drawing.Point(767, 0)
            Me.RibbonBarOptions_Overrides.MinimumSize = New System.Drawing.Size(75, 0)
            Me.RibbonBarOptions_Overrides.Name = "RibbonBarOptions_Overrides"
            Me.RibbonBarOptions_Overrides.SecurityEnabled = True
            Me.RibbonBarOptions_Overrides.Size = New System.Drawing.Size(189, 98)
            Me.RibbonBarOptions_Overrides.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Overrides.TabIndex = 7
            Me.RibbonBarOptions_Overrides.Text = "Overrides"
            '
            '
            '
            Me.RibbonBarOptions_Overrides.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Overrides.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Overrides.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'DateTimePickerOverrides_InvoiceDate
            '
            Me.DateTimePickerOverrides_InvoiceDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerOverrides_InvoiceDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOverrides_InvoiceDate.ButtonDropDown.Visible = True
            Me.DateTimePickerOverrides_InvoiceDate.ButtonFreeText.Checked = True
            Me.DateTimePickerOverrides_InvoiceDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerOverrides_InvoiceDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerOverrides_InvoiceDate.DisplayName = ""
            Me.DateTimePickerOverrides_InvoiceDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerOverrides_InvoiceDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerOverrides_InvoiceDate.FocusHighlightEnabled = True
            Me.DateTimePickerOverrides_InvoiceDate.FreeTextEntryMode = True
            Me.DateTimePickerOverrides_InvoiceDate.IsPopupCalendarOpen = False
            Me.DateTimePickerOverrides_InvoiceDate.Location = New System.Drawing.Point(74, 20)
            Me.DateTimePickerOverrides_InvoiceDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerOverrides_InvoiceDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerOverrides_InvoiceDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.DateTimePickerOverrides_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOverrides_InvoiceDate.MonthCalendar.DisplayMonth = New Date(2015, 8, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerOverrides_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOverrides_InvoiceDate.Name = "DateTimePickerOverrides_InvoiceDate"
            Me.DateTimePickerOverrides_InvoiceDate.ReadOnly = False
            Me.DateTimePickerOverrides_InvoiceDate.Size = New System.Drawing.Size(85, 20)
            Me.DateTimePickerOverrides_InvoiceDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerOverrides_InvoiceDate.TabIndex = 0
            Me.DateTimePickerOverrides_InvoiceDate.TabOnEnter = True
            Me.DateTimePickerOverrides_InvoiceDate.Value = New Date(2015, 9, 23, 15, 26, 52, 987)
            '
            'DateTimePickerOverrides_DueDate
            '
            Me.DateTimePickerOverrides_DueDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerOverrides_DueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOverrides_DueDate.ButtonDropDown.Visible = True
            Me.DateTimePickerOverrides_DueDate.ButtonFreeText.Checked = True
            Me.DateTimePickerOverrides_DueDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerOverrides_DueDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerOverrides_DueDate.DisplayName = ""
            Me.DateTimePickerOverrides_DueDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerOverrides_DueDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerOverrides_DueDate.FocusHighlightEnabled = True
            Me.DateTimePickerOverrides_DueDate.FreeTextEntryMode = True
            Me.DateTimePickerOverrides_DueDate.IsPopupCalendarOpen = False
            Me.DateTimePickerOverrides_DueDate.Location = New System.Drawing.Point(74, 43)
            Me.DateTimePickerOverrides_DueDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerOverrides_DueDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerOverrides_DueDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.DateTimePickerOverrides_DueDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOverrides_DueDate.MonthCalendar.DisplayMonth = New Date(2015, 8, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerOverrides_DueDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOverrides_DueDate.Name = "DateTimePickerOverrides_DueDate"
            Me.DateTimePickerOverrides_DueDate.ReadOnly = False
            Me.DateTimePickerOverrides_DueDate.Size = New System.Drawing.Size(85, 20)
            Me.DateTimePickerOverrides_DueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerOverrides_DueDate.TabIndex = 1
            Me.DateTimePickerOverrides_DueDate.TabOnEnter = True
            Me.DateTimePickerOverrides_DueDate.Value = New Date(2015, 9, 23, 15, 26, 53, 19)
            '
            'ItemContainerOverrides_OverridesInvoiceDate
            '
            '
            '
            '
            Me.ItemContainerOverrides_OverridesInvoiceDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerOverrides_OverridesInvoiceDate.Name = "ItemContainerOverrides_OverridesInvoiceDate"
            Me.ItemContainerOverrides_OverridesInvoiceDate.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemOverrides_InvoiceDate, Me.ControlContainerItemOverrides_InvoiceDate, Me.ButtonItemOverrides_InvoiceDate})
            '
            '
            '
            Me.ItemContainerOverrides_OverridesInvoiceDate.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerOverrides_OverridesInvoiceDate.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemOverrides_InvoiceDate
            '
            Me.LabelItemOverrides_InvoiceDate.Name = "LabelItemOverrides_InvoiceDate"
            Me.LabelItemOverrides_InvoiceDate.PaddingBottom = 4
            Me.LabelItemOverrides_InvoiceDate.PaddingTop = 4
            Me.LabelItemOverrides_InvoiceDate.Text = "Invoice Date:"
            '
            'ControlContainerItemOverrides_InvoiceDate
            '
            Me.ControlContainerItemOverrides_InvoiceDate.AllowItemResize = True
            Me.ControlContainerItemOverrides_InvoiceDate.Control = Me.DateTimePickerOverrides_InvoiceDate
            Me.ControlContainerItemOverrides_InvoiceDate.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemOverrides_InvoiceDate.Name = "ControlContainerItemOverrides_InvoiceDate"
            '
            'ButtonItemOverrides_InvoiceDate
            '
            Me.ButtonItemOverrides_InvoiceDate.BeginGroup = True
            Me.ButtonItemOverrides_InvoiceDate.Icon = CType(resources.GetObject("ButtonItemOverrides_InvoiceDate.Icon"), System.Drawing.Icon)
            Me.ButtonItemOverrides_InvoiceDate.Name = "ButtonItemOverrides_InvoiceDate"
            Me.ButtonItemOverrides_InvoiceDate.Tooltip = "Click to temporarily replace the invoice date with the date selected for printing" &
    "."
            '
            'ItemContainerOverrides_OverridesDueDate
            '
            '
            '
            '
            Me.ItemContainerOverrides_OverridesDueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerOverrides_OverridesDueDate.Name = "ItemContainerOverrides_OverridesDueDate"
            Me.ItemContainerOverrides_OverridesDueDate.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemOverrides_DueDate, Me.ControlContainerItemOverrides_DueDate, Me.ButtonItemOverrides_DueDate})
            '
            '
            '
            Me.ItemContainerOverrides_OverridesDueDate.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerOverrides_OverridesDueDate.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemOverrides_DueDate
            '
            Me.LabelItemOverrides_DueDate.Name = "LabelItemOverrides_DueDate"
            Me.LabelItemOverrides_DueDate.PaddingBottom = 4
            Me.LabelItemOverrides_DueDate.PaddingTop = 4
            Me.LabelItemOverrides_DueDate.Text = "Due Date:    "
            '
            'ControlContainerItemOverrides_DueDate
            '
            Me.ControlContainerItemOverrides_DueDate.AllowItemResize = True
            Me.ControlContainerItemOverrides_DueDate.Control = Me.DateTimePickerOverrides_DueDate
            Me.ControlContainerItemOverrides_DueDate.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemOverrides_DueDate.Name = "ControlContainerItemOverrides_DueDate"
            '
            'ButtonItemOverrides_DueDate
            '
            Me.ButtonItemOverrides_DueDate.BeginGroup = True
            Me.ButtonItemOverrides_DueDate.Icon = CType(resources.GetObject("ButtonItemOverrides_DueDate.Icon"), System.Drawing.Icon)
            Me.ButtonItemOverrides_DueDate.Name = "ButtonItemOverrides_DueDate"
            Me.ButtonItemOverrides_DueDate.Tooltip = "Click to permanently replace the due date with the date selected."
            '
            'RibbonBarOptions_Comments
            '
            Me.RibbonBarOptions_Comments.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Comments.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Comments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Comments.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Comments.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Comments.DragDropSupport = True
            Me.RibbonBarOptions_Comments.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Comments.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemComments_Job, Me.ButtonItemComments_Function})
            Me.RibbonBarOptions_Comments.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_Comments.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Comments.Location = New System.Drawing.Point(685, 0)
            Me.RibbonBarOptions_Comments.MinimumSize = New System.Drawing.Size(75, 0)
            Me.RibbonBarOptions_Comments.Name = "RibbonBarOptions_Comments"
            Me.RibbonBarOptions_Comments.SecurityEnabled = True
            Me.RibbonBarOptions_Comments.Size = New System.Drawing.Size(82, 98)
            Me.RibbonBarOptions_Comments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Comments.TabIndex = 4
            Me.RibbonBarOptions_Comments.Text = "Comments"
            '
            '
            '
            Me.RibbonBarOptions_Comments.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Comments.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Comments.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemComments_Job
            '
            Me.ButtonItemComments_Job.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemComments_Job.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemComments_Job.Name = "ButtonItemComments_Job"
            Me.ButtonItemComments_Job.RibbonWordWrap = False
            Me.ButtonItemComments_Job.SecurityEnabled = True
            Me.ButtonItemComments_Job.Stretch = True
            Me.ButtonItemComments_Job.SubItemsExpandWidth = 14
            Me.ButtonItemComments_Job.Text = "Job"
            '
            'ButtonItemComments_Function
            '
            Me.ButtonItemComments_Function.BeginGroup = True
            Me.ButtonItemComments_Function.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemComments_Function.Name = "ButtonItemComments_Function"
            Me.ButtonItemComments_Function.RibbonWordWrap = False
            Me.ButtonItemComments_Function.SecurityEnabled = True
            Me.ButtonItemComments_Function.Stretch = True
            Me.ButtonItemComments_Function.SubItemsExpandWidth = 14
            Me.ButtonItemComments_Function.Text = "Function"
            '
            'RibbonBarOptions_InvoiceFormatSettings
            '
            Me.RibbonBarOptions_InvoiceFormatSettings.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_InvoiceFormatSettings.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_InvoiceFormatSettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_InvoiceFormatSettings.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_InvoiceFormatSettings.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_InvoiceFormatSettings.DragDropSupport = True
            Me.RibbonBarOptions_InvoiceFormatSettings.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_InvoiceFormatSettings.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemInvoiceFormatSettings_Client, Me.ButtonItemInvoiceFormatSettings_Agency, Me.ButtonItemInvoiceFormatSettings_OneTime, Me.ButtonItemInvoiceFormatSettings_CustomizeTemplates})
            Me.RibbonBarOptions_InvoiceFormatSettings.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_InvoiceFormatSettings.Location = New System.Drawing.Point(610, 0)
            Me.RibbonBarOptions_InvoiceFormatSettings.MinimumSize = New System.Drawing.Size(75, 0)
            Me.RibbonBarOptions_InvoiceFormatSettings.Name = "RibbonBarOptions_InvoiceFormatSettings"
            Me.RibbonBarOptions_InvoiceFormatSettings.SecurityEnabled = True
            Me.RibbonBarOptions_InvoiceFormatSettings.Size = New System.Drawing.Size(75, 98)
            Me.RibbonBarOptions_InvoiceFormatSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_InvoiceFormatSettings.TabIndex = 8
            Me.RibbonBarOptions_InvoiceFormatSettings.Text = "Invoice Format Settings"
            '
            '
            '
            Me.RibbonBarOptions_InvoiceFormatSettings.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_InvoiceFormatSettings.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_InvoiceFormatSettings.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemInvoiceFormatSettings_Client
            '
            Me.ButtonItemInvoiceFormatSettings_Client.BeginGroup = True
            Me.ButtonItemInvoiceFormatSettings_Client.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemInvoiceFormatSettings_Client.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInvoiceFormatSettings_Client.Name = "ButtonItemInvoiceFormatSettings_Client"
            Me.ButtonItemInvoiceFormatSettings_Client.RibbonWordWrap = False
            Me.ButtonItemInvoiceFormatSettings_Client.SecurityEnabled = True
            Me.ButtonItemInvoiceFormatSettings_Client.Stretch = True
            Me.ButtonItemInvoiceFormatSettings_Client.SubItemsExpandWidth = 14
            Me.ButtonItemInvoiceFormatSettings_Client.Text = "Client"
            '
            'ButtonItemInvoiceFormatSettings_Agency
            '
            Me.ButtonItemInvoiceFormatSettings_Agency.BeginGroup = True
            Me.ButtonItemInvoiceFormatSettings_Agency.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemInvoiceFormatSettings_Agency.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInvoiceFormatSettings_Agency.Name = "ButtonItemInvoiceFormatSettings_Agency"
            Me.ButtonItemInvoiceFormatSettings_Agency.RibbonWordWrap = False
            Me.ButtonItemInvoiceFormatSettings_Agency.SecurityEnabled = True
            Me.ButtonItemInvoiceFormatSettings_Agency.Stretch = True
            Me.ButtonItemInvoiceFormatSettings_Agency.SubItemsExpandWidth = 14
            Me.ButtonItemInvoiceFormatSettings_Agency.Text = "Agency"
            '
            'ButtonItemInvoiceFormatSettings_OneTime
            '
            Me.ButtonItemInvoiceFormatSettings_OneTime.BeginGroup = True
            Me.ButtonItemInvoiceFormatSettings_OneTime.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemInvoiceFormatSettings_OneTime.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInvoiceFormatSettings_OneTime.Name = "ButtonItemInvoiceFormatSettings_OneTime"
            Me.ButtonItemInvoiceFormatSettings_OneTime.RibbonWordWrap = False
            Me.ButtonItemInvoiceFormatSettings_OneTime.SecurityEnabled = True
            Me.ButtonItemInvoiceFormatSettings_OneTime.Stretch = True
            Me.ButtonItemInvoiceFormatSettings_OneTime.SubItemsExpandWidth = 14
            Me.ButtonItemInvoiceFormatSettings_OneTime.Text = "One Time"
            '
            'ButtonItemInvoiceFormatSettings_CustomizeTemplates
            '
            Me.ButtonItemInvoiceFormatSettings_CustomizeTemplates.BeginGroup = True
            Me.ButtonItemInvoiceFormatSettings_CustomizeTemplates.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemInvoiceFormatSettings_CustomizeTemplates.ImageFixedSize = New System.Drawing.Size(32, 32)
            Me.ButtonItemInvoiceFormatSettings_CustomizeTemplates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInvoiceFormatSettings_CustomizeTemplates.Name = "ButtonItemInvoiceFormatSettings_CustomizeTemplates"
            Me.ButtonItemInvoiceFormatSettings_CustomizeTemplates.RibbonWordWrap = False
            Me.ButtonItemInvoiceFormatSettings_CustomizeTemplates.SubItemsExpandWidth = 14
            Me.ButtonItemInvoiceFormatSettings_CustomizeTemplates.Text = "Customize<br></br>Templates"
            '
            'RibbonBarOptions_PrintOptions
            '
            Me.RibbonBarOptions_PrintOptions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_PrintOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_PrintOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_PrintOptions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_PrintOptions.Controls.Add(Me.ComboBoxFormatType_FormatType)
            Me.RibbonBarOptions_PrintOptions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_PrintOptions.DragDropSupport = True
            Me.RibbonBarOptions_PrintOptions.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_PrintOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItemPrintOptions_FormatType, Me.ItemContainerPrintOption_SelectedFormat})
            Me.RibbonBarOptions_PrintOptions.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_PrintOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_PrintOptions.Location = New System.Drawing.Point(442, 0)
            Me.RibbonBarOptions_PrintOptions.MinimumSize = New System.Drawing.Size(75, 0)
            Me.RibbonBarOptions_PrintOptions.Name = "RibbonBarOptions_PrintOptions"
            Me.RibbonBarOptions_PrintOptions.SecurityEnabled = True
            Me.RibbonBarOptions_PrintOptions.Size = New System.Drawing.Size(168, 98)
            Me.RibbonBarOptions_PrintOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_PrintOptions.TabIndex = 3
            Me.RibbonBarOptions_PrintOptions.Text = "Print Option"
            '
            '
            '
            Me.RibbonBarOptions_PrintOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_PrintOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_PrintOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ComboBoxFormatType_FormatType
            '
            Me.ComboBoxFormatType_FormatType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxFormatType_FormatType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxFormatType_FormatType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxFormatType_FormatType.AutoFindItemInDataSource = False
            Me.ComboBoxFormatType_FormatType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxFormatType_FormatType.BookmarkingEnabled = False
            Me.ComboBoxFormatType_FormatType.ClientCode = ""
            Me.ComboBoxFormatType_FormatType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxFormatType_FormatType.DisableMouseWheel = False
            Me.ComboBoxFormatType_FormatType.DisplayMember = "Description"
            Me.ComboBoxFormatType_FormatType.DisplayName = ""
            Me.ComboBoxFormatType_FormatType.DivisionCode = ""
            Me.ComboBoxFormatType_FormatType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxFormatType_FormatType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxFormatType_FormatType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxFormatType_FormatType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxFormatType_FormatType.FocusHighlightEnabled = True
            Me.ComboBoxFormatType_FormatType.FormattingEnabled = True
            Me.ComboBoxFormatType_FormatType.ItemHeight = 14
            Me.ComboBoxFormatType_FormatType.Location = New System.Drawing.Point(9, 18)
            Me.ComboBoxFormatType_FormatType.Name = "ComboBoxFormatType_FormatType"
            Me.ComboBoxFormatType_FormatType.ReadOnly = False
            Me.ComboBoxFormatType_FormatType.SecurityEnabled = True
            Me.ComboBoxFormatType_FormatType.Size = New System.Drawing.Size(150, 20)
            Me.ComboBoxFormatType_FormatType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxFormatType_FormatType.TabIndex = 5
            Me.ComboBoxFormatType_FormatType.TabOnEnter = True
            Me.ComboBoxFormatType_FormatType.ValueMember = "Code"
            Me.ComboBoxFormatType_FormatType.WatermarkText = "Select"
            '
            'ControlContainerItemPrintOptions_FormatType
            '
            Me.ControlContainerItemPrintOptions_FormatType.AllowItemResize = False
            Me.ControlContainerItemPrintOptions_FormatType.Control = Me.ComboBoxFormatType_FormatType
            Me.ControlContainerItemPrintOptions_FormatType.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemPrintOptions_FormatType.Name = "ControlContainerItemPrintOptions_FormatType"
            '
            'ItemContainerPrintOption_SelectedFormat
            '
            '
            '
            '
            Me.ItemContainerPrintOption_SelectedFormat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerPrintOption_SelectedFormat.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerPrintOption_SelectedFormat.Name = "ItemContainerPrintOption_SelectedFormat"
            Me.ItemContainerPrintOption_SelectedFormat.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemPrintOption_Spacer, Me.LabelItemPrintOption_SelectedFormat})
            '
            '
            '
            Me.ItemContainerPrintOption_SelectedFormat.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerPrintOption_SelectedFormat.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemPrintOption_Spacer
            '
            Me.LabelItemPrintOption_Spacer.Height = 20
            Me.LabelItemPrintOption_Spacer.Name = "LabelItemPrintOption_Spacer"
            Me.LabelItemPrintOption_Spacer.Text = "   "
            '
            'LabelItemPrintOption_SelectedFormat
            '
            Me.LabelItemPrintOption_SelectedFormat.ForeColor = System.Drawing.Color.Red
            Me.LabelItemPrintOption_SelectedFormat.Height = 20
            Me.LabelItemPrintOption_SelectedFormat.Name = "LabelItemPrintOption_SelectedFormat"
            Me.LabelItemPrintOption_SelectedFormat.Text = " "
            Me.LabelItemPrintOption_SelectedFormat.TextAlignment = System.Drawing.StringAlignment.Center
            '
            'RibbonBarOptions_Search
            '
            Me.RibbonBarOptions_Search.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Search.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Search.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Search.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Search.Controls.Add(Me.DateTimePickerDates_From)
            Me.RibbonBarOptions_Search.Controls.Add(Me.DateTimePickerDates_To)
            Me.RibbonBarOptions_Search.Controls.Add(Me.NumericInputDates_InvoiceNumber)
            Me.RibbonBarOptions_Search.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Search.DragDropSupport = True
            Me.RibbonBarOptions_Search.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSeach_Production, Me.ItemContainerSeach_MediaGroup1, Me.ItemContainerSeach_MediaGroup2, Me.ItemContainerSearch_Spacer, Me.ItemContainerDates_Dates, Me.ButtonItemSearch_Search, Me.ButtonItemSearch_DraftInvoices})
            Me.RibbonBarOptions_Search.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Search.Location = New System.Drawing.Point(304, 0)
            Me.RibbonBarOptions_Search.Name = "RibbonBarOptions_Search"
            Me.RibbonBarOptions_Search.SecurityEnabled = True
            Me.RibbonBarOptions_Search.Size = New System.Drawing.Size(138, 98)
            Me.RibbonBarOptions_Search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Search.TabIndex = 2
            Me.RibbonBarOptions_Search.Text = "Search"
            '
            '
            '
            Me.RibbonBarOptions_Search.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Search.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'DateTimePickerDates_From
            '
            Me.DateTimePickerDates_From.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerDates_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_From.ButtonClear.Tooltip = "Click to clear date"
            Me.DateTimePickerDates_From.ButtonClear.Visible = True
            Me.DateTimePickerDates_From.ButtonDropDown.Visible = True
            Me.DateTimePickerDates_From.ButtonFreeText.Checked = True
            Me.DateTimePickerDates_From.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerDates_From.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerDates_From.DisplayName = ""
            Me.DateTimePickerDates_From.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerDates_From.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerDates_From.FocusHighlightEnabled = True
            Me.DateTimePickerDates_From.FreeTextEntryMode = True
            Me.DateTimePickerDates_From.IsPopupCalendarOpen = False
            Me.DateTimePickerDates_From.Location = New System.Drawing.Point(254, 4)
            Me.DateTimePickerDates_From.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerDates_From.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerDates_From.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.DateTimePickerDates_From.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_From.MonthCalendar.DisplayMonth = New Date(2015, 8, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerDates_From.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_From.Name = "DateTimePickerDates_From"
            Me.DateTimePickerDates_From.ReadOnly = False
            Me.DateTimePickerDates_From.Size = New System.Drawing.Size(105, 20)
            Me.DateTimePickerDates_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDates_From.TabIndex = 0
            Me.DateTimePickerDates_From.TabOnEnter = True
            Me.DateTimePickerDates_From.Value = New Date(2016, 8, 3, 9, 1, 22, 875)
            '
            'DateTimePickerDates_To
            '
            Me.DateTimePickerDates_To.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerDates_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_To.ButtonClear.Tooltip = "Click to clear date"
            Me.DateTimePickerDates_To.ButtonClear.Visible = True
            Me.DateTimePickerDates_To.ButtonDropDown.Visible = True
            Me.DateTimePickerDates_To.ButtonFreeText.Checked = True
            Me.DateTimePickerDates_To.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerDates_To.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerDates_To.DisplayName = ""
            Me.DateTimePickerDates_To.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerDates_To.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerDates_To.FocusHighlightEnabled = True
            Me.DateTimePickerDates_To.FreeTextEntryMode = True
            Me.DateTimePickerDates_To.IsPopupCalendarOpen = False
            Me.DateTimePickerDates_To.Location = New System.Drawing.Point(254, 27)
            Me.DateTimePickerDates_To.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerDates_To.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerDates_To.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.DateTimePickerDates_To.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_To.MonthCalendar.DisplayMonth = New Date(2015, 8, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerDates_To.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_To.Name = "DateTimePickerDates_To"
            Me.DateTimePickerDates_To.ReadOnly = False
            Me.DateTimePickerDates_To.Size = New System.Drawing.Size(105, 20)
            Me.DateTimePickerDates_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDates_To.TabIndex = 1
            Me.DateTimePickerDates_To.TabOnEnter = True
            Me.DateTimePickerDates_To.Value = New Date(2016, 8, 3, 9, 1, 22, 876)
            '
            'NumericInputDates_InvoiceNumber
            '
            Me.NumericInputDates_InvoiceNumber.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDates_InvoiceNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDates_InvoiceNumber.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDates_InvoiceNumber.EnterMoveNextControl = True
            Me.NumericInputDates_InvoiceNumber.Location = New System.Drawing.Point(309, 50)
            Me.NumericInputDates_InvoiceNumber.Name = "NumericInputDates_InvoiceNumber"
            Me.NumericInputDates_InvoiceNumber.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputDates_InvoiceNumber.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputDates_InvoiceNumber.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDates_InvoiceNumber.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputDates_InvoiceNumber.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDates_InvoiceNumber.Properties.IsFloatValue = False
            Me.NumericInputDates_InvoiceNumber.Properties.Mask.EditMask = "f0"
            Me.NumericInputDates_InvoiceNumber.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDates_InvoiceNumber.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDates_InvoiceNumber.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDates_InvoiceNumber.SecurityEnabled = True
            Me.NumericInputDates_InvoiceNumber.Size = New System.Drawing.Size(125, 20)
            Me.NumericInputDates_InvoiceNumber.TabIndex = 6
            '
            'ItemContainerSeach_Production
            '
            '
            '
            '
            Me.ItemContainerSeach_Production.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSeach_Production.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSeach_Production.Name = "ItemContainerSeach_Production"
            Me.ItemContainerSeach_Production.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSearch_Production})
            '
            '
            '
            Me.ItemContainerSeach_Production.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSeach_Production.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSearch_Production
            '
            Me.ButtonItemSearch_Production.AutoCheckOnClick = True
            Me.ButtonItemSearch_Production.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_Production.Checked = True
            Me.ButtonItemSearch_Production.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSearch_Production.Name = "ButtonItemSearch_Production"
            Me.ButtonItemSearch_Production.RibbonWordWrap = False
            Me.ButtonItemSearch_Production.Stretch = True
            Me.ButtonItemSearch_Production.SubItemsExpandWidth = 14
            Me.ButtonItemSearch_Production.Text = "Production"
            '
            'ItemContainerSeach_MediaGroup1
            '
            '
            '
            '
            Me.ItemContainerSeach_MediaGroup1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSeach_MediaGroup1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSeach_MediaGroup1.Name = "ItemContainerSeach_MediaGroup1"
            Me.ItemContainerSeach_MediaGroup1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSearch_Magazine, Me.ButtonItemSearch_Newspaper, Me.ButtonItemSearch_Internet})
            '
            '
            '
            Me.ItemContainerSeach_MediaGroup1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSeach_MediaGroup1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSearch_Magazine
            '
            Me.ButtonItemSearch_Magazine.AutoCheckOnClick = True
            Me.ButtonItemSearch_Magazine.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_Magazine.Checked = True
            Me.ButtonItemSearch_Magazine.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemSearch_Magazine.Name = "ButtonItemSearch_Magazine"
            Me.ButtonItemSearch_Magazine.RibbonWordWrap = False
            Me.ButtonItemSearch_Magazine.Stretch = True
            Me.ButtonItemSearch_Magazine.SubItemsExpandWidth = 14
            Me.ButtonItemSearch_Magazine.Text = "Magazine"
            '
            'ButtonItemSearch_Newspaper
            '
            Me.ButtonItemSearch_Newspaper.AutoCheckOnClick = True
            Me.ButtonItemSearch_Newspaper.BeginGroup = True
            Me.ButtonItemSearch_Newspaper.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_Newspaper.Checked = True
            Me.ButtonItemSearch_Newspaper.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemSearch_Newspaper.Name = "ButtonItemSearch_Newspaper"
            Me.ButtonItemSearch_Newspaper.RibbonWordWrap = False
            Me.ButtonItemSearch_Newspaper.Stretch = True
            Me.ButtonItemSearch_Newspaper.SubItemsExpandWidth = 14
            Me.ButtonItemSearch_Newspaper.Text = "Newspaper"
            '
            'ButtonItemSearch_Internet
            '
            Me.ButtonItemSearch_Internet.AutoCheckOnClick = True
            Me.ButtonItemSearch_Internet.BeginGroup = True
            Me.ButtonItemSearch_Internet.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_Internet.Checked = True
            Me.ButtonItemSearch_Internet.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemSearch_Internet.Name = "ButtonItemSearch_Internet"
            Me.ButtonItemSearch_Internet.RibbonWordWrap = False
            Me.ButtonItemSearch_Internet.Stretch = True
            Me.ButtonItemSearch_Internet.SubItemsExpandWidth = 14
            Me.ButtonItemSearch_Internet.Text = "Internet"
            '
            'ItemContainerSeach_MediaGroup2
            '
            '
            '
            '
            Me.ItemContainerSeach_MediaGroup2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSeach_MediaGroup2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSeach_MediaGroup2.Name = "ItemContainerSeach_MediaGroup2"
            Me.ItemContainerSeach_MediaGroup2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSearch_OutOfHome, Me.ButtonItemSearch_Radio, Me.ButtonItemSearch_TV})
            '
            '
            '
            Me.ItemContainerSeach_MediaGroup2.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSeach_MediaGroup2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSearch_OutOfHome
            '
            Me.ButtonItemSearch_OutOfHome.AutoCheckOnClick = True
            Me.ButtonItemSearch_OutOfHome.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_OutOfHome.Checked = True
            Me.ButtonItemSearch_OutOfHome.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemSearch_OutOfHome.Name = "ButtonItemSearch_OutOfHome"
            Me.ButtonItemSearch_OutOfHome.RibbonWordWrap = False
            Me.ButtonItemSearch_OutOfHome.Stretch = True
            Me.ButtonItemSearch_OutOfHome.SubItemsExpandWidth = 14
            Me.ButtonItemSearch_OutOfHome.Text = "Out Of Home"
            '
            'ButtonItemSearch_Radio
            '
            Me.ButtonItemSearch_Radio.AutoCheckOnClick = True
            Me.ButtonItemSearch_Radio.BeginGroup = True
            Me.ButtonItemSearch_Radio.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_Radio.Checked = True
            Me.ButtonItemSearch_Radio.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemSearch_Radio.Name = "ButtonItemSearch_Radio"
            Me.ButtonItemSearch_Radio.RibbonWordWrap = False
            Me.ButtonItemSearch_Radio.Stretch = True
            Me.ButtonItemSearch_Radio.SubItemsExpandWidth = 14
            Me.ButtonItemSearch_Radio.Text = "Radio"
            '
            'ButtonItemSearch_TV
            '
            Me.ButtonItemSearch_TV.AutoCheckOnClick = True
            Me.ButtonItemSearch_TV.BeginGroup = True
            Me.ButtonItemSearch_TV.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_TV.Checked = True
            Me.ButtonItemSearch_TV.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemSearch_TV.Name = "ButtonItemSearch_TV"
            Me.ButtonItemSearch_TV.RibbonWordWrap = False
            Me.ButtonItemSearch_TV.Stretch = True
            Me.ButtonItemSearch_TV.SubItemsExpandWidth = 14
            Me.ButtonItemSearch_TV.Text = "TV"
            '
            'ItemContainerSearch_Spacer
            '
            '
            '
            '
            Me.ItemContainerSearch_Spacer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_Spacer.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSearch_Spacer.Name = "ItemContainerSearch_Spacer"
            Me.ItemContainerSearch_Spacer.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemSpacer_Spacer})
            '
            '
            '
            Me.ItemContainerSearch_Spacer.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSearch_Spacer.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemSpacer_Spacer
            '
            Me.LabelItemSpacer_Spacer.Name = "LabelItemSpacer_Spacer"
            Me.LabelItemSpacer_Spacer.Text = "   "
            '
            'ItemContainerDates_Dates
            '
            '
            '
            '
            Me.ItemContainerDates_Dates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerDates_Dates.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerDates_Dates.Name = "ItemContainerDates_Dates"
            Me.ItemContainerDates_Dates.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerDates_Top, Me.ItemContainerDates_Bottom, Me.ItemContainer1})
            '
            '
            '
            Me.ItemContainerDates_Dates.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerDates_Dates.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerDates_Top
            '
            '
            '
            '
            Me.ItemContainerDates_Top.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerDates_Top.Name = "ItemContainerDates_Top"
            Me.ItemContainerDates_Top.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemDates_From, Me.ControlContainerItemDates_From, Me.ButtonItemDates_YTD, Me.ButtonItemDates_1Year})
            '
            '
            '
            Me.ItemContainerDates_Top.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerDates_Top.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemDates_From
            '
            Me.LabelItemDates_From.Name = "LabelItemDates_From"
            Me.LabelItemDates_From.PaddingBottom = 4
            Me.LabelItemDates_From.PaddingTop = 4
            Me.LabelItemDates_From.Text = "From:"
            Me.LabelItemDates_From.Width = 35
            '
            'ControlContainerItemDates_From
            '
            Me.ControlContainerItemDates_From.AllowItemResize = True
            Me.ControlContainerItemDates_From.Control = Me.DateTimePickerDates_From
            Me.ControlContainerItemDates_From.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemDates_From.Name = "ControlContainerItemDates_From"
            Me.ControlContainerItemDates_From.Text = "ControlContainerItem1"
            '
            'ButtonItemDates_YTD
            '
            Me.ButtonItemDates_YTD.BeginGroup = True
            Me.ButtonItemDates_YTD.Name = "ButtonItemDates_YTD"
            Me.ButtonItemDates_YTD.Text = "YTD"
            '
            'ButtonItemDates_1Year
            '
            Me.ButtonItemDates_1Year.BeginGroup = True
            Me.ButtonItemDates_1Year.Name = "ButtonItemDates_1Year"
            Me.ButtonItemDates_1Year.Text = "1 Year"
            '
            'ItemContainerDates_Bottom
            '
            '
            '
            '
            Me.ItemContainerDates_Bottom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerDates_Bottom.Name = "ItemContainerDates_Bottom"
            Me.ItemContainerDates_Bottom.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemDates_To, Me.ControlContainerItemDates_To, Me.ButtonItemDates_MTD, Me.ButtonItemDates_2Years})
            '
            '
            '
            Me.ItemContainerDates_Bottom.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerDates_Bottom.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemDates_To
            '
            Me.LabelItemDates_To.Name = "LabelItemDates_To"
            Me.LabelItemDates_To.PaddingBottom = 4
            Me.LabelItemDates_To.PaddingTop = 4
            Me.LabelItemDates_To.Text = "To:"
            Me.LabelItemDates_To.Width = 35
            '
            'ControlContainerItemDates_To
            '
            Me.ControlContainerItemDates_To.AllowItemResize = True
            Me.ControlContainerItemDates_To.Control = Me.DateTimePickerDates_To
            Me.ControlContainerItemDates_To.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemDates_To.Name = "ControlContainerItemDates_To"
            Me.ControlContainerItemDates_To.Text = "ControlContainerItem2"
            '
            'ButtonItemDates_MTD
            '
            Me.ButtonItemDates_MTD.BeginGroup = True
            Me.ButtonItemDates_MTD.Name = "ButtonItemDates_MTD"
            Me.ButtonItemDates_MTD.Text = "MTD"
            '
            'ButtonItemDates_2Years
            '
            Me.ButtonItemDates_2Years.BeginGroup = True
            Me.ButtonItemDates_2Years.Name = "ButtonItemDates_2Years"
            Me.ButtonItemDates_2Years.Text = "2 Years"
            '
            'ItemContainer1
            '
            '
            '
            '
            Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer1.Name = "ItemContainer1"
            Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemDates_InvoiceNumber, Me.ControlContainerItemDates_InvoiceNumber})
            '
            '
            '
            Me.ItemContainer1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemDates_InvoiceNumber
            '
            Me.LabelItemDates_InvoiceNumber.Name = "LabelItemDates_InvoiceNumber"
            Me.LabelItemDates_InvoiceNumber.PaddingTop = 4
            Me.LabelItemDates_InvoiceNumber.Text = "Invoice Number:"
            Me.LabelItemDates_InvoiceNumber.Width = 90
            '
            'ControlContainerItemDates_InvoiceNumber
            '
            Me.ControlContainerItemDates_InvoiceNumber.AllowItemResize = True
            Me.ControlContainerItemDates_InvoiceNumber.Control = Me.NumericInputDates_InvoiceNumber
            Me.ControlContainerItemDates_InvoiceNumber.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemDates_InvoiceNumber.Name = "ControlContainerItemDates_InvoiceNumber"
            Me.ControlContainerItemDates_InvoiceNumber.Text = "ControlContainerItem1"
            '
            'ButtonItemSearch_Search
            '
            Me.ButtonItemSearch_Search.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSearch_Search.Name = "ButtonItemSearch_Search"
            Me.ButtonItemSearch_Search.RibbonWordWrap = False
            Me.ButtonItemSearch_Search.SecurityEnabled = True
            Me.ButtonItemSearch_Search.Stretch = True
            Me.ButtonItemSearch_Search.SubItemsExpandWidth = 14
            Me.ButtonItemSearch_Search.Text = "Search"
            '
            'ButtonItemSearch_DraftInvoices
            '
            Me.ButtonItemSearch_DraftInvoices.AutoCheckOnClick = True
            Me.ButtonItemSearch_DraftInvoices.BeginGroup = True
            Me.ButtonItemSearch_DraftInvoices.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_DraftInvoices.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSearch_DraftInvoices.Name = "ButtonItemSearch_DraftInvoices"
            Me.ButtonItemSearch_DraftInvoices.RibbonWordWrap = False
            Me.ButtonItemSearch_DraftInvoices.SecurityEnabled = True
            Me.ButtonItemSearch_DraftInvoices.Stretch = True
            Me.ButtonItemSearch_DraftInvoices.SubItemsExpandWidth = 14
            Me.ButtonItemSearch_DraftInvoices.Text = "<span width=""12""></span>Draft<br></br> Invoices"
            '
            'RibbonBarOptions_Actions
            '
            Me.RibbonBarOptions_Actions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_PrintPreview, Me.ButtonItemActions_Print, Me.ItemContainerActions_Actions, Me.ButtonItemActions_AutoFill})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(304, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 0
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_PrintPreview
            '
            Me.ButtonItemActions_PrintPreview.BeginGroup = True
            Me.ButtonItemActions_PrintPreview.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_PrintPreview.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_PrintPreview.Name = "ButtonItemActions_PrintPreview"
            Me.ButtonItemActions_PrintPreview.RibbonWordWrap = False
            Me.ButtonItemActions_PrintPreview.SecurityEnabled = True
            Me.ButtonItemActions_PrintPreview.Stretch = True
            Me.ButtonItemActions_PrintPreview.SubItemsExpandWidth = 14
            Me.ButtonItemActions_PrintPreview.Text = "Print Preview"
            '
            'ButtonItemActions_Print
            '
            Me.ButtonItemActions_Print.AutoExpandOnClick = True
            Me.ButtonItemActions_Print.BeginGroup = True
            Me.ButtonItemActions_Print.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
            Me.ButtonItemActions_Print.RibbonWordWrap = False
            Me.ButtonItemActions_Print.SecurityEnabled = True
            Me.ButtonItemActions_Print.Stretch = True
            Me.ButtonItemActions_Print.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPrint_Print, Me.ButtonItemPrint_QuickPrint, Me.ButtonItemPrint_ToFiles, Me.ButtonItemPrint_SendEmails, Me.ButtonItemPrint_AutoEmail})
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
            '
            'ButtonItemPrint_Print
            '
            Me.ButtonItemPrint_Print.Name = "ButtonItemPrint_Print"
            Me.ButtonItemPrint_Print.Text = "Print"
            '
            'ButtonItemPrint_QuickPrint
            '
            Me.ButtonItemPrint_QuickPrint.Name = "ButtonItemPrint_QuickPrint"
            Me.ButtonItemPrint_QuickPrint.Text = "Quick Print"
            '
            'ButtonItemPrint_ToFiles
            '
            Me.ButtonItemPrint_ToFiles.AutoExpandOnClick = True
            Me.ButtonItemPrint_ToFiles.BeginGroup = True
            Me.ButtonItemPrint_ToFiles.Name = "ButtonItemPrint_ToFiles"
            Me.ButtonItemPrint_ToFiles.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemToFile_SingleFile, Me.ButtonItemToFile_SeparateFiles})
            Me.ButtonItemPrint_ToFiles.Text = "To File(s)"
            '
            'ButtonItemToFile_SingleFile
            '
            Me.ButtonItemToFile_SingleFile.AutoExpandOnClick = True
            Me.ButtonItemToFile_SingleFile.Name = "ButtonItemToFile_SingleFile"
            Me.ButtonItemToFile_SingleFile.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSingleFile_PDF, Me.ButtonItemSingleFile_RTF, Me.ButtonItemSingleFile_XLS, Me.ButtonItemSingleFile_XLSX, Me.ButtonItemSingleFile_Image, Me.ButtonItemSingleFile_SendToDocumentManager})
            Me.ButtonItemToFile_SingleFile.Text = "Single File"
            '
            'ButtonItemSingleFile_PDF
            '
            Me.ButtonItemSingleFile_PDF.Name = "ButtonItemSingleFile_PDF"
            Me.ButtonItemSingleFile_PDF.Text = "PDF"
            '
            'ButtonItemSingleFile_RTF
            '
            Me.ButtonItemSingleFile_RTF.Name = "ButtonItemSingleFile_RTF"
            Me.ButtonItemSingleFile_RTF.Text = "RTF"
            '
            'ButtonItemSingleFile_XLS
            '
            Me.ButtonItemSingleFile_XLS.Name = "ButtonItemSingleFile_XLS"
            Me.ButtonItemSingleFile_XLS.Text = "XLS"
            '
            'ButtonItemSingleFile_XLSX
            '
            Me.ButtonItemSingleFile_XLSX.Name = "ButtonItemSingleFile_XLSX"
            Me.ButtonItemSingleFile_XLSX.Text = "XLSX"
            '
            'ButtonItemSingleFile_Image
            '
            Me.ButtonItemSingleFile_Image.Name = "ButtonItemSingleFile_Image"
            Me.ButtonItemSingleFile_Image.Text = "Image"
            '
            'ButtonItemSingleFile_SendToDocumentManager
            '
            Me.ButtonItemSingleFile_SendToDocumentManager.BeginGroup = True
            Me.ButtonItemSingleFile_SendToDocumentManager.Name = "ButtonItemSingleFile_SendToDocumentManager"
            Me.ButtonItemSingleFile_SendToDocumentManager.Text = "Send To Document Manager"
            '
            'ButtonItemToFile_SeparateFiles
            '
            Me.ButtonItemToFile_SeparateFiles.AutoExpandOnClick = True
            Me.ButtonItemToFile_SeparateFiles.Name = "ButtonItemToFile_SeparateFiles"
            Me.ButtonItemToFile_SeparateFiles.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSeparateFiles_PDF, Me.ButtonItemSeparateFiles_RTF, Me.ButtonItemSeparateFiles_XLS, Me.ButtonItemSeparateFiles_XLSX, Me.ButtonItemSeparateFiles_Image, Me.ButtonItemSeparateFiles_SendToDocumentManager})
            Me.ButtonItemToFile_SeparateFiles.Text = "Separate Files"
            '
            'ButtonItemSeparateFiles_PDF
            '
            Me.ButtonItemSeparateFiles_PDF.Name = "ButtonItemSeparateFiles_PDF"
            Me.ButtonItemSeparateFiles_PDF.Text = "PDF"
            '
            'ButtonItemSeparateFiles_RTF
            '
            Me.ButtonItemSeparateFiles_RTF.Name = "ButtonItemSeparateFiles_RTF"
            Me.ButtonItemSeparateFiles_RTF.Text = "RTF"
            '
            'ButtonItemSeparateFiles_XLS
            '
            Me.ButtonItemSeparateFiles_XLS.Name = "ButtonItemSeparateFiles_XLS"
            Me.ButtonItemSeparateFiles_XLS.Text = "XLS"
            '
            'ButtonItemSeparateFiles_XLSX
            '
            Me.ButtonItemSeparateFiles_XLSX.Name = "ButtonItemSeparateFiles_XLSX"
            Me.ButtonItemSeparateFiles_XLSX.Text = "XLSX"
            '
            'ButtonItemSeparateFiles_Image
            '
            Me.ButtonItemSeparateFiles_Image.Name = "ButtonItemSeparateFiles_Image"
            Me.ButtonItemSeparateFiles_Image.Text = "Image"
            '
            'ButtonItemSeparateFiles_SendToDocumentManager
            '
            Me.ButtonItemSeparateFiles_SendToDocumentManager.BeginGroup = True
            Me.ButtonItemSeparateFiles_SendToDocumentManager.Name = "ButtonItemSeparateFiles_SendToDocumentManager"
            Me.ButtonItemSeparateFiles_SendToDocumentManager.Text = "Send To Document Manager"
            '
            'ButtonItemPrint_SendEmails
            '
            Me.ButtonItemPrint_SendEmails.BeginGroup = True
            Me.ButtonItemPrint_SendEmails.Name = "ButtonItemPrint_SendEmails"
            Me.ButtonItemPrint_SendEmails.Text = "Send E-mail(s)"
            '
            'ButtonItemPrint_AutoEmail
            '
            Me.ButtonItemPrint_AutoEmail.Name = "ButtonItemPrint_AutoEmail"
            Me.ButtonItemPrint_AutoEmail.Text = "Auto E-mail"
            '
            'ItemContainerActions_Actions
            '
            '
            '
            '
            Me.ItemContainerActions_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerActions_Actions.BeginGroup = True
            Me.ItemContainerActions_Actions.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerActions_Actions.Name = "ItemContainerActions_Actions"
            Me.ItemContainerActions_Actions.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_ShowSequenceNumber, Me.ButtonItemActions_ShowDivisionProductJobComp, Me.ButtonItemActions_CombineCoopInvoices})
            '
            '
            '
            Me.ItemContainerActions_Actions.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerActions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemActions_ShowSequenceNumber
            '
            Me.ButtonItemActions_ShowSequenceNumber.BeginGroup = True
            Me.ButtonItemActions_ShowSequenceNumber.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_ShowSequenceNumber.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemActions_ShowSequenceNumber.Name = "ButtonItemActions_ShowSequenceNumber"
            Me.ButtonItemActions_ShowSequenceNumber.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ShowSequenceNumber.Text = "Show Sequence Number"
            '
            'ButtonItemActions_ShowDivisionProductJobComp
            '
            Me.ButtonItemActions_ShowDivisionProductJobComp.BeginGroup = True
            Me.ButtonItemActions_ShowDivisionProductJobComp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_ShowDivisionProductJobComp.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemActions_ShowDivisionProductJobComp.Name = "ButtonItemActions_ShowDivisionProductJobComp"
            Me.ButtonItemActions_ShowDivisionProductJobComp.SecurityEnabled = True
            Me.ButtonItemActions_ShowDivisionProductJobComp.Stretch = True
            Me.ButtonItemActions_ShowDivisionProductJobComp.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ShowDivisionProductJobComp.Text = "Show Div, Prd, Job/Comp"
            '
            'ButtonItemActions_CombineCoopInvoices
            '
            Me.ButtonItemActions_CombineCoopInvoices.BeginGroup = True
            Me.ButtonItemActions_CombineCoopInvoices.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_CombineCoopInvoices.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemActions_CombineCoopInvoices.Name = "ButtonItemActions_CombineCoopInvoices"
            Me.ButtonItemActions_CombineCoopInvoices.SecurityEnabled = True
            Me.ButtonItemActions_CombineCoopInvoices.Stretch = True
            Me.ButtonItemActions_CombineCoopInvoices.SubItemsExpandWidth = 14
            Me.ButtonItemActions_CombineCoopInvoices.Text = "Combine Coop Invoices"
            '
            'DataGridViewForm_Invoices
            '
            Me.DataGridViewForm_Invoices.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_Invoices.AllowDragAndDrop = False
            Me.DataGridViewForm_Invoices.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Invoices.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Invoices.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Invoices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Invoices.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Invoices.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Invoices.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Invoices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_Invoices.DataSource = Nothing
            Me.DataGridViewForm_Invoices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Invoices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
            Me.DataGridViewForm_Invoices.ItemDescription = "Invoice(s)"
            Me.DataGridViewForm_Invoices.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_Invoices.MultiSelect = True
            Me.DataGridViewForm_Invoices.Name = "DataGridViewForm_Invoices"
            Me.DataGridViewForm_Invoices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Invoices.RunStandardValidation = True
            Me.DataGridViewForm_Invoices.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Invoices.ShowSelectDeselectAllButtons = True
            Me.DataGridViewForm_Invoices.Size = New System.Drawing.Size(966, 397)
            Me.DataGridViewForm_Invoices.TabIndex = 4
            Me.DataGridViewForm_Invoices.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Invoices.ViewCaptionHeight = -1
            '
            'ContextMenuBarForm_Invoices
            '
            Me.ContextMenuBarForm_Invoices.AntiAlias = True
            Me.ContextMenuBarForm_Invoices.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.ContextMenuBarForm_Invoices.IsMaximized = False
            Me.ContextMenuBarForm_Invoices.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCM_Invoices})
            Me.ContextMenuBarForm_Invoices.Location = New System.Drawing.Point(585, 368)
            Me.ContextMenuBarForm_Invoices.Name = "ContextMenuBarForm_Invoices"
            Me.ContextMenuBarForm_Invoices.Size = New System.Drawing.Size(75, 25)
            Me.ContextMenuBarForm_Invoices.Stretch = True
            Me.ContextMenuBarForm_Invoices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ContextMenuBarForm_Invoices.TabIndex = 5
            Me.ContextMenuBarForm_Invoices.TabStop = False
            Me.ContextMenuBarForm_Invoices.Text = "ContextMenuBar1"
            '
            'ButtonItemCM_Invoices
            '
            Me.ButtonItemCM_Invoices.AutoExpandOnClick = True
            Me.ButtonItemCM_Invoices.Name = "ButtonItemCM_Invoices"
            Me.ButtonItemCM_Invoices.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemInovices_SetInvoiceCategory})
            Me.ButtonItemCM_Invoices.Text = "CM"
            '
            'ButtonItemInovices_SetInvoiceCategory
            '
            Me.ButtonItemInovices_SetInvoiceCategory.Name = "ButtonItemInovices_SetInvoiceCategory"
            Me.ButtonItemInovices_SetInvoiceCategory.Text = "Set Invoice Category"
            '
            'RibbonBarMergeContainerForm_Coversheet
            '
            Me.RibbonBarMergeContainerForm_Coversheet.AutoActivateTab = False
            Me.RibbonBarMergeContainerForm_Coversheet.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Coversheet.Controls.Add(Me.RibbonBarCoversheet_Options)
            Me.RibbonBarMergeContainerForm_Coversheet.Location = New System.Drawing.Point(262, 254)
            Me.RibbonBarMergeContainerForm_Coversheet.Name = "RibbonBarMergeContainerForm_Coversheet"
            Me.RibbonBarMergeContainerForm_Coversheet.RibbonTabText = "Coversheet"
            Me.RibbonBarMergeContainerForm_Coversheet.Size = New System.Drawing.Size(691, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Coversheet.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Coversheet.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Coversheet.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Coversheet.TabIndex = 7
            Me.RibbonBarMergeContainerForm_Coversheet.Visible = False
            '
            'RibbonBarCoversheet_Options
            '
            Me.RibbonBarCoversheet_Options.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarCoversheet_Options.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarCoversheet_Options.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarCoversheet_Options.ContainerControlProcessDialogKey = True
            Me.RibbonBarCoversheet_Options.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarCoversheet_Options.DragDropSupport = True
            Me.RibbonBarCoversheet_Options.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarCoversheet_Options.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptions_Settings})
            Me.RibbonBarCoversheet_Options.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarCoversheet_Options.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarCoversheet_Options.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarCoversheet_Options.Name = "RibbonBarCoversheet_Options"
            Me.RibbonBarCoversheet_Options.SecurityEnabled = True
            Me.RibbonBarCoversheet_Options.Size = New System.Drawing.Size(79, 98)
            Me.RibbonBarCoversheet_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarCoversheet_Options.TabIndex = 5
            Me.RibbonBarCoversheet_Options.Text = "Options"
            '
            '
            '
            Me.RibbonBarCoversheet_Options.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarCoversheet_Options.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarCoversheet_Options.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemOptions_Settings
            '
            Me.ButtonItemOptions_Settings.BeginGroup = True
            Me.ButtonItemOptions_Settings.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemOptions_Settings.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_Settings.Name = "ButtonItemOptions_Settings"
            Me.ButtonItemOptions_Settings.RibbonWordWrap = False
            Me.ButtonItemOptions_Settings.SecurityEnabled = True
            Me.ButtonItemOptions_Settings.Stretch = True
            Me.ButtonItemOptions_Settings.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_Settings.Text = "Settings"
            '
            'ButtonItemActions_AutoFill
            '
            Me.ButtonItemActions_AutoFill.BeginGroup = True
            Me.ButtonItemActions_AutoFill.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_AutoFill.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_AutoFill.Name = "ButtonItemActions_AutoFill"
            Me.ButtonItemActions_AutoFill.RibbonWordWrap = False
            Me.ButtonItemActions_AutoFill.SecurityEnabled = True
            Me.ButtonItemActions_AutoFill.Stretch = True
            Me.ButtonItemActions_AutoFill.SubItemsExpandWidth = 14
            Me.ButtonItemActions_AutoFill.Text = "Auto Fill"
            '
            'InvoicePrintingSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(990, 421)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Coversheet)
            Me.Controls.Add(Me.ContextMenuBarForm_Invoices)
            Me.Controls.Add(Me.DataGridViewForm_Invoices)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "InvoicePrintingSetupForm"
            Me.Text = "Invoice Printing"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBarOptions_Overrides.ResumeLayout(False)
            CType(Me.DateTimePickerOverrides_InvoiceDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerOverrides_DueDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarOptions_PrintOptions.ResumeLayout(False)
            Me.RibbonBarOptions_Search.ResumeLayout(False)
            CType(Me.DateTimePickerDates_From, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerDates_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputDates_InvoiceNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ContextMenuBarForm_Invoices, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarMergeContainerForm_Coversheet.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents DataGridViewForm_Invoices As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Search As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents DateTimePickerDates_From As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerDates_To As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents ItemContainerDates_Dates As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerDates_Top As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemDates_From As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemDates_From As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ItemContainerDates_Bottom As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemDates_To As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemDates_To As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemSearch_Search As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSearch_Production As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSearch_Magazine As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSearch_Newspaper As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSearch_Internet As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSearch_OutOfHome As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSearch_Radio As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSearch_TV As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDates_YTD As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDates_1Year As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDates_MTD As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDates_2Years As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_PrintOptions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_PrintPreview As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemPrint_ToFiles As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPrint_SendEmails As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Comments As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemComments_Job As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemComments_Function As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerSeach_MediaGroup1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerSeach_MediaGroup2 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ControlContainerItemPrintOptions_FormatType As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ComboBoxFormatType_FormatType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ContextMenuBarForm_Invoices As DevComponents.DotNetBar.ContextMenuBar
        Friend WithEvents ButtonItemCM_Invoices As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemInovices_SetInvoiceCategory As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerSearch_Spacer As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerSeach_Production As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSpacer_Spacer As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ButtonItemToFile_SingleFile As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSingleFile_PDF As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSingleFile_RTF As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSingleFile_XLS As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSingleFile_XLSX As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSingleFile_Image As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemToFile_SeparateFiles As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSeparateFiles_PDF As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSeparateFiles_RTF As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSeparateFiles_XLS As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSeparateFiles_XLSX As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSeparateFiles_Image As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPrint_AutoEmail As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSingleFile_SendToDocumentManager As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSeparateFiles_SendToDocumentManager As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPrint_QuickPrint As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Overrides As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerOverrides_OverridesInvoiceDate As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemOverrides_InvoiceDate As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemOverrides_InvoiceDate As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemOverrides_InvoiceDate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DateTimePickerOverrides_DueDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerOverrides_InvoiceDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents ItemContainerOverrides_OverridesDueDate As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemOverrides_DueDate As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemOverrides_DueDate As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemOverrides_DueDate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_ShowSequenceNumber As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSearch_DraftInvoices As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_InvoiceFormatSettings As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemInvoiceFormatSettings_Client As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemInvoiceFormatSettings_Agency As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemInvoiceFormatSettings_OneTime As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemInvoiceFormatSettings_CustomizeTemplates As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelItemPrintOption_SelectedFormat As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ItemContainerPrintOption_SelectedFormat As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemPrintOption_Spacer As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ButtonItemPrint_Print As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents NumericInputDates_InvoiceNumber As WinForm.Presentation.Controls.NumericInput
        Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemDates_InvoiceNumber As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemDates_InvoiceNumber As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ItemContainerActions_Actions As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemActions_ShowDivisionProductJobComp As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_CombineCoopInvoices As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_Coversheet As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarCoversheet_Options As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemOptions_Settings As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_AutoFill As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace

