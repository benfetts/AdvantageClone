Namespace ProjectManagement.Reports.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EstimatePrintingSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstimatePrintingSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Comments = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemComments_Job = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemComments_Function = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBar1 = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.DateTimePickerOverrides_EstimateDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ItemContainerOverrides_OverridesInvoiceDate = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemOverrides_InvoiceDate = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemOverrides_InvoiceDate = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemOverrides_EstimateDate = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_PrintOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxFormatType_FormatType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ControlContainerItemPrintOptions_FormatType = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemPrintOptions_Setup = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Search = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.DateTimePickerDates_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerDates_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
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
            Me.ButtonItemSearch_Search = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBar_GroupBy = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxSearch_GroupBy = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ControlContainerItem2 = New DevComponents.DotNetBar.ControlContainerItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxActions_SelectBy = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ControlContainerItem3 = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_PrintPreview = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemPrint_ToFiles = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPrint_SendEmails = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_ShowDescriptions = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemAction_Refresh = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewForm_Estimates = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_EstimateFormatSettings = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemEstimateFormatSettings_Client = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEstimateFormatSettings_Product = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEstimateFormatSettings_User = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEstimateFormatSettings_Agency = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEstimateFormatSettings_OneTime = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEstimateFormatSettings_CustomizeTemplates = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBar1.SuspendLayout()
            CType(Me.DateTimePickerOverrides_EstimateDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarOptions_PrintOptions.SuspendLayout()
            Me.RibbonBarOptions_Search.SuspendLayout()
            CType(Me.DateTimePickerDates_From, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerDates_To, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBar_GroupBy.SuspendLayout()
            Me.RibbonBarOptions_Actions.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Comments)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBar1)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_EstimateFormatSettings)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_PrintOptions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Search)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBar_GroupBy)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(-3, 126)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1376, 98)
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
            Me.RibbonBarOptions_Comments.Location = New System.Drawing.Point(1232, 0)
            Me.RibbonBarOptions_Comments.MinimumSize = New System.Drawing.Size(75, 0)
            Me.RibbonBarOptions_Comments.Name = "RibbonBarOptions_Comments"
            Me.RibbonBarOptions_Comments.SecurityEnabled = True
            Me.RibbonBarOptions_Comments.Size = New System.Drawing.Size(75, 98)
            Me.RibbonBarOptions_Comments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Comments.TabIndex = 5
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
            Me.ButtonItemComments_Job.Text = "Estimate"
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
            'RibbonBar1
            '
            Me.RibbonBar1.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar1.ContainerControlProcessDialogKey = True
            Me.RibbonBar1.Controls.Add(Me.DateTimePickerOverrides_EstimateDate)
            Me.RibbonBar1.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBar1.DragDropSupport = True
            Me.RibbonBar1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerOverrides_OverridesInvoiceDate})
            Me.RibbonBar1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar1.Location = New System.Drawing.Point(1036, 0)
            Me.RibbonBar1.MinimumSize = New System.Drawing.Size(75, 0)
            Me.RibbonBar1.Name = "RibbonBar1"
            Me.RibbonBar1.SecurityEnabled = True
            Me.RibbonBar1.Size = New System.Drawing.Size(196, 98)
            Me.RibbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBar1.TabIndex = 7
            Me.RibbonBar1.Text = "Date"
            '
            '
            '
            Me.RibbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar1.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'DateTimePickerOverrides_EstimateDate
            '
            Me.DateTimePickerOverrides_EstimateDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerOverrides_EstimateDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerOverrides_EstimateDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOverrides_EstimateDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerOverrides_EstimateDate.ButtonDropDown.Visible = True
            Me.DateTimePickerOverrides_EstimateDate.ButtonFreeText.Checked = True
            Me.DateTimePickerOverrides_EstimateDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerOverrides_EstimateDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerOverrides_EstimateDate.DisplayName = ""
            Me.DateTimePickerOverrides_EstimateDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerOverrides_EstimateDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerOverrides_EstimateDate.FocusHighlightEnabled = True
            Me.DateTimePickerOverrides_EstimateDate.FreeTextEntryMode = True
            Me.DateTimePickerOverrides_EstimateDate.IsPopupCalendarOpen = False
            Me.DateTimePickerOverrides_EstimateDate.Location = New System.Drawing.Point(83, 31)
            Me.DateTimePickerOverrides_EstimateDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerOverrides_EstimateDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.DisplayMonth = New Date(2015, 7, 1, 0, 0, 0, 0)
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerOverrides_EstimateDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerOverrides_EstimateDate.Name = "DateTimePickerOverrides_EstimateDate"
            Me.DateTimePickerOverrides_EstimateDate.ReadOnly = False
            Me.DateTimePickerOverrides_EstimateDate.Size = New System.Drawing.Size(80, 20)
            Me.DateTimePickerOverrides_EstimateDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerOverrides_EstimateDate.TabIndex = 7
            Me.DateTimePickerOverrides_EstimateDate.TabOnEnter = True
            Me.DateTimePickerOverrides_EstimateDate.Value = New Date(2015, 7, 20, 10, 44, 42, 532)
            '
            'ItemContainerOverrides_OverridesInvoiceDate
            '
            '
            '
            '
            Me.ItemContainerOverrides_OverridesInvoiceDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerOverrides_OverridesInvoiceDate.Name = "ItemContainerOverrides_OverridesInvoiceDate"
            Me.ItemContainerOverrides_OverridesInvoiceDate.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemOverrides_InvoiceDate, Me.ControlContainerItemOverrides_InvoiceDate, Me.ButtonItemOverrides_EstimateDate})
            '
            '
            '
            Me.ItemContainerOverrides_OverridesInvoiceDate.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemOverrides_InvoiceDate
            '
            Me.LabelItemOverrides_InvoiceDate.Name = "LabelItemOverrides_InvoiceDate"
            Me.LabelItemOverrides_InvoiceDate.Text = "Estimate Date:"
            '
            'ControlContainerItemOverrides_InvoiceDate
            '
            Me.ControlContainerItemOverrides_InvoiceDate.AllowItemResize = True
            Me.ControlContainerItemOverrides_InvoiceDate.Control = Me.DateTimePickerOverrides_EstimateDate
            Me.ControlContainerItemOverrides_InvoiceDate.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemOverrides_InvoiceDate.Name = "ControlContainerItemOverrides_InvoiceDate"
            '
            'ButtonItemOverrides_EstimateDate
            '
            Me.ButtonItemOverrides_EstimateDate.BeginGroup = True
            Me.ButtonItemOverrides_EstimateDate.Icon = CType(resources.GetObject("ButtonItemOverrides_EstimateDate.Icon"), System.Drawing.Icon)
            Me.ButtonItemOverrides_EstimateDate.Name = "ButtonItemOverrides_EstimateDate"
            Me.ButtonItemOverrides_EstimateDate.Tooltip = "Click to replace the estimate date with the date selected for printing."
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
            Me.RibbonBarOptions_PrintOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItemPrintOptions_FormatType, Me.ButtonItemPrintOptions_Setup})
            Me.RibbonBarOptions_PrintOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_PrintOptions.Location = New System.Drawing.Point(833, 0)
            Me.RibbonBarOptions_PrintOptions.MinimumSize = New System.Drawing.Size(75, 0)
            Me.RibbonBarOptions_PrintOptions.Name = "RibbonBarOptions_PrintOptions"
            Me.RibbonBarOptions_PrintOptions.SecurityEnabled = True
            Me.RibbonBarOptions_PrintOptions.Size = New System.Drawing.Size(203, 98)
            Me.RibbonBarOptions_PrintOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_PrintOptions.TabIndex = 4
            Me.RibbonBarOptions_PrintOptions.Text = "Print Options"
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
            Me.ComboBoxFormatType_FormatType.Location = New System.Drawing.Point(7, 31)
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
            'ButtonItemPrintOptions_Setup
            '
            Me.ButtonItemPrintOptions_Setup.BeginGroup = True
            Me.ButtonItemPrintOptions_Setup.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPrintOptions_Setup.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPrintOptions_Setup.Name = "ButtonItemPrintOptions_Setup"
            Me.ButtonItemPrintOptions_Setup.RibbonWordWrap = False
            Me.ButtonItemPrintOptions_Setup.SecurityEnabled = True
            Me.ButtonItemPrintOptions_Setup.Stretch = True
            Me.ButtonItemPrintOptions_Setup.SubItemsExpandWidth = 14
            Me.ButtonItemPrintOptions_Setup.Text = "Setup"
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
            Me.RibbonBarOptions_Search.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Search.DragDropSupport = True
            Me.RibbonBarOptions_Search.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerDates_Dates, Me.ButtonItemSearch_Search})
            Me.RibbonBarOptions_Search.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Search.Location = New System.Drawing.Point(569, 0)
            Me.RibbonBarOptions_Search.Name = "RibbonBarOptions_Search"
            Me.RibbonBarOptions_Search.SecurityEnabled = True
            Me.RibbonBarOptions_Search.Size = New System.Drawing.Size(264, 98)
            Me.RibbonBarOptions_Search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Search.TabIndex = 3
            Me.RibbonBarOptions_Search.Text = "Search"
            '
            '
            '
            Me.RibbonBarOptions_Search.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Search.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Search.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'DateTimePickerDates_From
            '
            Me.DateTimePickerDates_From.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerDates_From.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerDates_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_From.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
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
            Me.DateTimePickerDates_From.Location = New System.Drawing.Point(57, 37)
            Me.DateTimePickerDates_From.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerDates_From.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerDates_From.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDates_From.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_From.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerDates_From.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerDates_From.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerDates_From.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDates_From.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerDates_From.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerDates_From.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerDates_From.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerDates_From.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_From.MonthCalendar.DisplayMonth = New Date(2013, 9, 1, 0, 0, 0, 0)
            Me.DateTimePickerDates_From.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerDates_From.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDates_From.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerDates_From.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDates_From.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerDates_From.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_From.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerDates_From.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerDates_From.Name = "DateTimePickerDates_From"
            Me.DateTimePickerDates_From.ReadOnly = False
            Me.DateTimePickerDates_From.Size = New System.Drawing.Size(80, 20)
            Me.DateTimePickerDates_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDates_From.TabIndex = 3
            Me.DateTimePickerDates_From.TabOnEnter = True
            Me.DateTimePickerDates_From.Value = New Date(2013, 9, 10, 16, 52, 5, 0)
            '
            'DateTimePickerDates_To
            '
            Me.DateTimePickerDates_To.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerDates_To.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerDates_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_To.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
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
            Me.DateTimePickerDates_To.Location = New System.Drawing.Point(57, 60)
            Me.DateTimePickerDates_To.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerDates_To.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerDates_To.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDates_To.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_To.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerDates_To.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerDates_To.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerDates_To.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDates_To.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerDates_To.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerDates_To.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerDates_To.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerDates_To.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_To.MonthCalendar.DisplayMonth = New Date(2013, 9, 1, 0, 0, 0, 0)
            Me.DateTimePickerDates_To.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerDates_To.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDates_To.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerDates_To.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDates_To.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerDates_To.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_To.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerDates_To.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerDates_To.Name = "DateTimePickerDates_To"
            Me.DateTimePickerDates_To.ReadOnly = False
            Me.DateTimePickerDates_To.Size = New System.Drawing.Size(80, 20)
            Me.DateTimePickerDates_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDates_To.TabIndex = 4
            Me.DateTimePickerDates_To.TabOnEnter = True
            Me.DateTimePickerDates_To.Value = New Date(2013, 9, 10, 16, 52, 5, 0)
            '
            'ItemContainerDates_Dates
            '
            '
            '
            '
            Me.ItemContainerDates_Dates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerDates_Dates.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerDates_Dates.Name = "ItemContainerDates_Dates"
            Me.ItemContainerDates_Dates.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerDates_Top, Me.ItemContainerDates_Bottom})
            '
            '
            '
            Me.ItemContainerDates_Dates.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerDates_Dates.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
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
            Me.ItemContainerDates_Top.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemDates_From
            '
            Me.LabelItemDates_From.Name = "LabelItemDates_From"
            Me.LabelItemDates_From.Text = "From:"
            Me.LabelItemDates_From.Width = 50
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
            Me.ItemContainerDates_Bottom.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemDates_To
            '
            Me.LabelItemDates_To.Name = "LabelItemDates_To"
            Me.LabelItemDates_To.Text = "To:"
            Me.LabelItemDates_To.Width = 50
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
            'RibbonBar_GroupBy
            '
            Me.RibbonBar_GroupBy.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBar_GroupBy.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar_GroupBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar_GroupBy.ContainerControlProcessDialogKey = True
            Me.RibbonBar_GroupBy.Controls.Add(Me.ComboBoxSearch_GroupBy)
            Me.RibbonBar_GroupBy.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBar_GroupBy.DragDropSupport = True
            Me.RibbonBar_GroupBy.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBar_GroupBy.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItem2})
            Me.RibbonBar_GroupBy.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBar_GroupBy.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar_GroupBy.Location = New System.Drawing.Point(434, 0)
            Me.RibbonBar_GroupBy.MinimumSize = New System.Drawing.Size(75, 0)
            Me.RibbonBar_GroupBy.Name = "RibbonBar_GroupBy"
            Me.RibbonBar_GroupBy.SecurityEnabled = True
            Me.RibbonBar_GroupBy.Size = New System.Drawing.Size(135, 98)
            Me.RibbonBar_GroupBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBar_GroupBy.TabIndex = 2
            Me.RibbonBar_GroupBy.Text = "Group By"
            '
            '
            '
            Me.RibbonBar_GroupBy.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar_GroupBy.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar_GroupBy.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ComboBoxSearch_GroupBy
            '
            Me.ComboBoxSearch_GroupBy.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSearch_GroupBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxSearch_GroupBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSearch_GroupBy.AutoFindItemInDataSource = False
            Me.ComboBoxSearch_GroupBy.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSearch_GroupBy.BookmarkingEnabled = False
            Me.ComboBoxSearch_GroupBy.ClientCode = ""
            Me.ComboBoxSearch_GroupBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxSearch_GroupBy.DisableMouseWheel = False
            Me.ComboBoxSearch_GroupBy.DisplayMember = "Description"
            Me.ComboBoxSearch_GroupBy.DisplayName = ""
            Me.ComboBoxSearch_GroupBy.DivisionCode = ""
            Me.ComboBoxSearch_GroupBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSearch_GroupBy.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxSearch_GroupBy.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxSearch_GroupBy.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSearch_GroupBy.FocusHighlightEnabled = True
            Me.ComboBoxSearch_GroupBy.FormattingEnabled = True
            Me.ComboBoxSearch_GroupBy.ItemHeight = 14
            Me.ComboBoxSearch_GroupBy.Location = New System.Drawing.Point(7, 31)
            Me.ComboBoxSearch_GroupBy.Name = "ComboBoxSearch_GroupBy"
            Me.ComboBoxSearch_GroupBy.ReadOnly = False
            Me.ComboBoxSearch_GroupBy.SecurityEnabled = True
            Me.ComboBoxSearch_GroupBy.Size = New System.Drawing.Size(121, 20)
            Me.ComboBoxSearch_GroupBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSearch_GroupBy.TabIndex = 7
            Me.ComboBoxSearch_GroupBy.TabOnEnter = True
            Me.ComboBoxSearch_GroupBy.ValueMember = "Code"
            Me.ComboBoxSearch_GroupBy.WatermarkText = "Select"
            '
            'ControlContainerItem2
            '
            Me.ControlContainerItem2.AllowItemResize = False
            Me.ControlContainerItem2.Control = Me.ComboBoxSearch_GroupBy
            Me.ControlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItem2.Name = "ControlContainerItem2"
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
            Me.RibbonBarOptions_Actions.Controls.Add(Me.ComboBoxActions_SelectBy)
            Me.RibbonBarOptions_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItem3, Me.ButtonItemActions_Save, Me.ButtonItemActions_PrintPreview, Me.ButtonItemActions_Print, Me.ButtonItem_ShowDescriptions, Me.ButtonItemAction_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(434, 98)
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
            'ComboBoxActions_SelectBy
            '
            Me.ComboBoxActions_SelectBy.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxActions_SelectBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxActions_SelectBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxActions_SelectBy.AutoFindItemInDataSource = False
            Me.ComboBoxActions_SelectBy.AutoSelectSingleItemDatasource = False
            Me.ComboBoxActions_SelectBy.BookmarkingEnabled = False
            Me.ComboBoxActions_SelectBy.ClientCode = ""
            Me.ComboBoxActions_SelectBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxActions_SelectBy.DisableMouseWheel = False
            Me.ComboBoxActions_SelectBy.DisplayMember = "Description"
            Me.ComboBoxActions_SelectBy.DisplayName = ""
            Me.ComboBoxActions_SelectBy.DivisionCode = ""
            Me.ComboBoxActions_SelectBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxActions_SelectBy.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxActions_SelectBy.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxActions_SelectBy.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxActions_SelectBy.FocusHighlightEnabled = True
            Me.ComboBoxActions_SelectBy.FormattingEnabled = True
            Me.ComboBoxActions_SelectBy.ItemHeight = 14
            Me.ComboBoxActions_SelectBy.Location = New System.Drawing.Point(6, 31)
            Me.ComboBoxActions_SelectBy.Name = "ComboBoxActions_SelectBy"
            Me.ComboBoxActions_SelectBy.ReadOnly = False
            Me.ComboBoxActions_SelectBy.SecurityEnabled = True
            Me.ComboBoxActions_SelectBy.Size = New System.Drawing.Size(121, 20)
            Me.ComboBoxActions_SelectBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxActions_SelectBy.TabIndex = 8
            Me.ComboBoxActions_SelectBy.TabOnEnter = True
            Me.ComboBoxActions_SelectBy.ValueMember = "Code"
            Me.ComboBoxActions_SelectBy.WatermarkText = "Select"
            '
            'ControlContainerItem3
            '
            Me.ControlContainerItem3.AllowItemResize = False
            Me.ControlContainerItem3.Control = Me.ComboBoxActions_SelectBy
            Me.ControlContainerItem3.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItem3.Name = "ControlContainerItem3"
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
            Me.ButtonItemActions_Print.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPrint_ToFiles, Me.ButtonItemPrint_SendEmails})
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
            '
            'ButtonItemPrint_ToFiles
            '
            Me.ButtonItemPrint_ToFiles.Name = "ButtonItemPrint_ToFiles"
            Me.ButtonItemPrint_ToFiles.Text = "To File(s)"
            '
            'ButtonItemPrint_SendEmails
            '
            Me.ButtonItemPrint_SendEmails.Name = "ButtonItemPrint_SendEmails"
            Me.ButtonItemPrint_SendEmails.Text = "Send Email(s)"
            '
            'ButtonItem_ShowDescriptions
            '
            Me.ButtonItem_ShowDescriptions.AutoCheckOnClick = True
            Me.ButtonItem_ShowDescriptions.BeginGroup = True
            Me.ButtonItem_ShowDescriptions.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem_ShowDescriptions.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem_ShowDescriptions.Name = "ButtonItem_ShowDescriptions"
            Me.ButtonItem_ShowDescriptions.RibbonWordWrap = False
            Me.ButtonItem_ShowDescriptions.Stretch = True
            Me.ButtonItem_ShowDescriptions.SubItemsExpandWidth = 14
            Me.ButtonItem_ShowDescriptions.Text = "Show Descriptions"
            '
            'ButtonItemAction_Refresh
            '
            Me.ButtonItemAction_Refresh.BeginGroup = True
            Me.ButtonItemAction_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemAction_Refresh.Name = "ButtonItemAction_Refresh"
            Me.ButtonItemAction_Refresh.RibbonWordWrap = False
            Me.ButtonItemAction_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemAction_Refresh.Text = "Refresh"
            '
            'DataGridViewForm_Estimates
            '
            Me.DataGridViewForm_Estimates.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_Estimates.AllowDragAndDrop = False
            Me.DataGridViewForm_Estimates.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Estimates.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Estimates.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Estimates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Estimates.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Estimates.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Estimates.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Estimates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_Estimates.DataSource = Nothing
            Me.DataGridViewForm_Estimates.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Estimates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
            Me.DataGridViewForm_Estimates.ItemDescription = "Estimate(s)"
            Me.DataGridViewForm_Estimates.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_Estimates.MultiSelect = True
            Me.DataGridViewForm_Estimates.Name = "DataGridViewForm_Estimates"
            Me.DataGridViewForm_Estimates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Estimates.RunStandardValidation = True
            Me.DataGridViewForm_Estimates.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Estimates.ShowSelectDeselectAllButtons = True
            Me.DataGridViewForm_Estimates.Size = New System.Drawing.Size(1365, 397)
            Me.DataGridViewForm_Estimates.TabIndex = 4
            Me.DataGridViewForm_Estimates.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Estimates.ViewCaptionHeight = -1
            '
            'RibbonBarOptions_EstimateFormatSettings
            '
            Me.RibbonBarOptions_EstimateFormatSettings.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_EstimateFormatSettings.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_EstimateFormatSettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_EstimateFormatSettings.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_EstimateFormatSettings.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_EstimateFormatSettings.DragDropSupport = True
            Me.RibbonBarOptions_EstimateFormatSettings.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_EstimateFormatSettings.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemEstimateFormatSettings_Client, Me.ButtonItemEstimateFormatSettings_Product, Me.ButtonItemEstimateFormatSettings_User, Me.ButtonItemEstimateFormatSettings_Agency, Me.ButtonItemEstimateFormatSettings_OneTime, Me.ButtonItemEstimateFormatSettings_CustomizeTemplates})
            Me.RibbonBarOptions_EstimateFormatSettings.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_EstimateFormatSettings.Location = New System.Drawing.Point(842, 0)
            Me.RibbonBarOptions_EstimateFormatSettings.MinimumSize = New System.Drawing.Size(75, 0)
            Me.RibbonBarOptions_EstimateFormatSettings.Name = "RibbonBarOptions_EstimateFormatSettings"
            Me.RibbonBarOptions_EstimateFormatSettings.SecurityEnabled = True
            Me.RibbonBarOptions_EstimateFormatSettings.Size = New System.Drawing.Size(230, 98)
            Me.RibbonBarOptions_EstimateFormatSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_EstimateFormatSettings.TabIndex = 8
            Me.RibbonBarOptions_EstimateFormatSettings.Text = "Estimate Format Settings"
            '
            '
            '
            Me.RibbonBarOptions_EstimateFormatSettings.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_EstimateFormatSettings.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_EstimateFormatSettings.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemEstimateFormatSettings_Client
            '
            Me.ButtonItemEstimateFormatSettings_Client.BeginGroup = True
            Me.ButtonItemEstimateFormatSettings_Client.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEstimateFormatSettings_Client.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEstimateFormatSettings_Client.Name = "ButtonItemEstimateFormatSettings_Client"
            Me.ButtonItemEstimateFormatSettings_Client.RibbonWordWrap = False
            Me.ButtonItemEstimateFormatSettings_Client.SecurityEnabled = True
            Me.ButtonItemEstimateFormatSettings_Client.Stretch = True
            Me.ButtonItemEstimateFormatSettings_Client.SubItemsExpandWidth = 14
            Me.ButtonItemEstimateFormatSettings_Client.Text = "Client"
            '
            'ButtonItemEstimateFormatSettings_Product
            '
            Me.ButtonItemEstimateFormatSettings_Product.BeginGroup = True
            Me.ButtonItemEstimateFormatSettings_Product.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEstimateFormatSettings_Product.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEstimateFormatSettings_Product.Name = "ButtonItemEstimateFormatSettings_Product"
            Me.ButtonItemEstimateFormatSettings_Product.RibbonWordWrap = False
            Me.ButtonItemEstimateFormatSettings_Product.SecurityEnabled = True
            Me.ButtonItemEstimateFormatSettings_Product.Stretch = True
            Me.ButtonItemEstimateFormatSettings_Product.SubItemsExpandWidth = 14
            Me.ButtonItemEstimateFormatSettings_Product.Text = "Product"
            '
            'ButtonItemEstimateFormatSettings_User
            '
            Me.ButtonItemEstimateFormatSettings_User.BeginGroup = True
            Me.ButtonItemEstimateFormatSettings_User.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEstimateFormatSettings_User.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEstimateFormatSettings_User.Name = "ButtonItemEstimateFormatSettings_User"
            Me.ButtonItemEstimateFormatSettings_User.RibbonWordWrap = False
            Me.ButtonItemEstimateFormatSettings_User.SecurityEnabled = True
            Me.ButtonItemEstimateFormatSettings_User.Stretch = True
            Me.ButtonItemEstimateFormatSettings_User.SubItemsExpandWidth = 14
            Me.ButtonItemEstimateFormatSettings_User.Text = "User"
            '
            'ButtonItemEstimateFormatSettings_Agency
            '
            Me.ButtonItemEstimateFormatSettings_Agency.BeginGroup = True
            Me.ButtonItemEstimateFormatSettings_Agency.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEstimateFormatSettings_Agency.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEstimateFormatSettings_Agency.Name = "ButtonItemEstimateFormatSettings_Agency"
            Me.ButtonItemEstimateFormatSettings_Agency.RibbonWordWrap = False
            Me.ButtonItemEstimateFormatSettings_Agency.SecurityEnabled = True
            Me.ButtonItemEstimateFormatSettings_Agency.Stretch = True
            Me.ButtonItemEstimateFormatSettings_Agency.SubItemsExpandWidth = 14
            Me.ButtonItemEstimateFormatSettings_Agency.Text = "Agency"
            '
            'ButtonItemEstimateFormatSettings_OneTime
            '
            Me.ButtonItemEstimateFormatSettings_OneTime.BeginGroup = True
            Me.ButtonItemEstimateFormatSettings_OneTime.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEstimateFormatSettings_OneTime.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEstimateFormatSettings_OneTime.Name = "ButtonItemEstimateFormatSettings_OneTime"
            Me.ButtonItemEstimateFormatSettings_OneTime.RibbonWordWrap = False
            Me.ButtonItemEstimateFormatSettings_OneTime.SecurityEnabled = True
            Me.ButtonItemEstimateFormatSettings_OneTime.Stretch = True
            Me.ButtonItemEstimateFormatSettings_OneTime.SubItemsExpandWidth = 14
            Me.ButtonItemEstimateFormatSettings_OneTime.Text = "One Time"
            '
            'ButtonItemEstimateFormatSettings_CustomizeTemplates
            '
            Me.ButtonItemEstimateFormatSettings_CustomizeTemplates.BeginGroup = True
            Me.ButtonItemEstimateFormatSettings_CustomizeTemplates.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEstimateFormatSettings_CustomizeTemplates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEstimateFormatSettings_CustomizeTemplates.Name = "ButtonItemEstimateFormatSettings_CustomizeTemplates"
            Me.ButtonItemEstimateFormatSettings_CustomizeTemplates.RibbonWordWrap = False
            Me.ButtonItemEstimateFormatSettings_CustomizeTemplates.SubItemsExpandWidth = 14
            Me.ButtonItemEstimateFormatSettings_CustomizeTemplates.Text = "Customize<br></br>Templates"
            '
            'EstimatePrintingSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1380, 421)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_Estimates)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EstimatePrintingSetupForm"
            Me.Text = "Estimate Printing"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBar1.ResumeLayout(False)
            CType(Me.DateTimePickerOverrides_EstimateDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarOptions_PrintOptions.ResumeLayout(False)
            Me.RibbonBarOptions_Search.ResumeLayout(False)
            CType(Me.DateTimePickerDates_From, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerDates_To, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBar_GroupBy.ResumeLayout(False)
            Me.RibbonBarOptions_Actions.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents DataGridViewForm_Estimates As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
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
        Friend WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDates_YTD As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDates_1Year As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDates_MTD As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDates_2Years As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_PrintOptions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemPrintOptions_Setup As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_PrintPreview As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemPrint_ToFiles As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPrint_SendEmails As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Comments As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemComments_Job As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemComments_Function As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ControlContainerItemPrintOptions_FormatType As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ComboBoxFormatType_FormatType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ButtonItem_ShowDescriptions As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ComboBoxSearch_GroupBy As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents RibbonBar_GroupBy As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ControlContainerItem2 As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ComboBoxActions_SelectBy As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ControlContainerItem3 As DevComponents.DotNetBar.ControlContainerItem
        Private WithEvents ButtonItemAction_Refresh As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBar1 As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerOverrides_OverridesInvoiceDate As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemOverrides_InvoiceDate As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemOverrides_InvoiceDate As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemOverrides_EstimateDate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DateTimePickerOverrides_EstimateDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents RibbonBarOptions_EstimateFormatSettings As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemEstimateFormatSettings_Client As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEstimateFormatSettings_Product As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEstimateFormatSettings_User As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEstimateFormatSettings_Agency As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEstimateFormatSettings_OneTime As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEstimateFormatSettings_CustomizeTemplates As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace

