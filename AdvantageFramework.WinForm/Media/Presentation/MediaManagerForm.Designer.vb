Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaManagerForm
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaManagerForm))
            Me.GroupBoxForm_DateRanges = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelOrderLineDateRange_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerOrderLine_DateFrom = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerOrderLine_DateTo = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelOrderLineDateRange_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxForm_SelectMediaTypes = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxMediaType_PurchaseOrder = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaType_Television = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaType_Radio = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaType_OutOfHome = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaType_Magazine = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaType_Internet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaType_Newspaper = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxSearch_SelectBy = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonSelectBy_Buyer = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TextBoxSelectBy_LastFour = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.RadioButtonSelectBy_LastFour = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectBy_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.NumericInputSelectBy_OrderNumber = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.RadioButtonSelectBy_Order = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectBy_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectBy_ClientDivisionProduct = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectBy_ClientDivision = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectBy_AllOpenOrders = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectBy_Job = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectBy_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectBy_Client = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectBy_OrderStatus = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectBy_AccountExecutiveJob = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectBy_AccountExecutiveDefault = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxForm_Include = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxInclude_ClosedOrders = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonInclude_Both = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonInclude_QuotesOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonInclude_OrdersOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxForm_JobMediaDateToBillDateRange = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelJobMediaDateRange_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerJob_DateFrom = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerJob_DateTo = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelJobMediaDateRange_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ExpandablePanelForm_SearchBy = New DevComponents.DotNetBar.ExpandablePanel()
            Me.SearchableComboBoxForm_FilterBy = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelForm_FilterBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxForm_MediaByMonth = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputMediaByMonth_YearTo = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputMediaByMonth_YearFrom = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ComboBoxMediaByMonth_MonthTo = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxMediaByMonth_MonthFrom = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelMediaByMonth_Range = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewRightSection_Selections = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_MediaTypes = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMediaTypes_CheckAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMediaTypes_UncheckAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_OtherUserSelections = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_ShowDescriptions = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_Review = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            CType(Me.GroupBoxForm_DateRanges, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_DateRanges.SuspendLayout()
            CType(Me.DateTimePickerOrderLine_DateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerOrderLine_DateTo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_SelectMediaTypes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_SelectMediaTypes.SuspendLayout()
            CType(Me.GroupBoxSearch_SelectBy, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxSearch_SelectBy.SuspendLayout()
            CType(Me.NumericInputSelectBy_OrderNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_Include, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_Include.SuspendLayout()
            CType(Me.GroupBoxForm_JobMediaDateToBillDateRange, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_JobMediaDateToBillDateRange.SuspendLayout()
            CType(Me.DateTimePickerJob_DateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerJob_DateTo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ExpandablePanelForm_SearchBy.SuspendLayout()
            CType(Me.SearchableComboBoxForm_FilterBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_MediaByMonth, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_MediaByMonth.SuspendLayout()
            CType(Me.NumericInputMediaByMonth_YearTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputMediaByMonth_YearFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupBoxForm_DateRanges
            '
            Me.GroupBoxForm_DateRanges.Controls.Add(Me.LabelOrderLineDateRange_From)
            Me.GroupBoxForm_DateRanges.Controls.Add(Me.DateTimePickerOrderLine_DateFrom)
            Me.GroupBoxForm_DateRanges.Controls.Add(Me.DateTimePickerOrderLine_DateTo)
            Me.GroupBoxForm_DateRanges.Controls.Add(Me.LabelOrderLineDateRange_To)
            Me.GroupBoxForm_DateRanges.Location = New System.Drawing.Point(3, 246)
            Me.GroupBoxForm_DateRanges.Name = "GroupBoxForm_DateRanges"
            Me.GroupBoxForm_DateRanges.Size = New System.Drawing.Size(360, 56)
            Me.GroupBoxForm_DateRanges.TabIndex = 3
            Me.GroupBoxForm_DateRanges.Text = "Order Line Date Range"
            '
            'LabelOrderLineDateRange_From
            '
            Me.LabelOrderLineDateRange_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOrderLineDateRange_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOrderLineDateRange_From.Location = New System.Drawing.Point(5, 24)
            Me.LabelOrderLineDateRange_From.Name = "LabelOrderLineDateRange_From"
            Me.LabelOrderLineDateRange_From.Size = New System.Drawing.Size(46, 20)
            Me.LabelOrderLineDateRange_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOrderLineDateRange_From.TabIndex = 1
            Me.LabelOrderLineDateRange_From.Text = "From:"
            '
            'DateTimePickerOrderLine_DateFrom
            '
            Me.DateTimePickerOrderLine_DateFrom.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerOrderLine_DateFrom.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerOrderLine_DateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOrderLine_DateFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerOrderLine_DateFrom.ButtonDropDown.Visible = True
            Me.DateTimePickerOrderLine_DateFrom.ButtonFreeText.Checked = True
            Me.DateTimePickerOrderLine_DateFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerOrderLine_DateFrom.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerOrderLine_DateFrom.DisplayName = ""
            Me.DateTimePickerOrderLine_DateFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerOrderLine_DateFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerOrderLine_DateFrom.FocusHighlightEnabled = True
            Me.DateTimePickerOrderLine_DateFrom.FreeTextEntryMode = True
            Me.DateTimePickerOrderLine_DateFrom.IsPopupCalendarOpen = False
            Me.DateTimePickerOrderLine_DateFrom.Location = New System.Drawing.Point(57, 23)
            Me.DateTimePickerOrderLine_DateFrom.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerOrderLine_DateFrom.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerOrderLine_DateFrom.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerOrderLine_DateFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOrderLine_DateFrom.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerOrderLine_DateFrom.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerOrderLine_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerOrderLine_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerOrderLine_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerOrderLine_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerOrderLine_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerOrderLine_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerOrderLine_DateFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOrderLine_DateFrom.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerOrderLine_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerOrderLine_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerOrderLine_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerOrderLine_DateFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOrderLine_DateFrom.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerOrderLine_DateFrom.Name = "DateTimePickerOrderLine_DateFrom"
            Me.DateTimePickerOrderLine_DateFrom.ReadOnly = False
            Me.DateTimePickerOrderLine_DateFrom.Size = New System.Drawing.Size(97, 21)
            Me.DateTimePickerOrderLine_DateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerOrderLine_DateFrom.TabIndex = 2
            Me.DateTimePickerOrderLine_DateFrom.TabOnEnter = True
            Me.DateTimePickerOrderLine_DateFrom.Value = New Date(2013, 7, 23, 13, 58, 57, 0)
            '
            'DateTimePickerOrderLine_DateTo
            '
            Me.DateTimePickerOrderLine_DateTo.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerOrderLine_DateTo.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerOrderLine_DateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOrderLine_DateTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerOrderLine_DateTo.ButtonDropDown.Visible = True
            Me.DateTimePickerOrderLine_DateTo.ButtonFreeText.Checked = True
            Me.DateTimePickerOrderLine_DateTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerOrderLine_DateTo.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerOrderLine_DateTo.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerOrderLine_DateTo.DisplayName = ""
            Me.DateTimePickerOrderLine_DateTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerOrderLine_DateTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerOrderLine_DateTo.FocusHighlightEnabled = True
            Me.DateTimePickerOrderLine_DateTo.FreeTextEntryMode = True
            Me.DateTimePickerOrderLine_DateTo.IsPopupCalendarOpen = False
            Me.DateTimePickerOrderLine_DateTo.Location = New System.Drawing.Point(199, 24)
            Me.DateTimePickerOrderLine_DateTo.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerOrderLine_DateTo.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerOrderLine_DateTo.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerOrderLine_DateTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOrderLine_DateTo.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerOrderLine_DateTo.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerOrderLine_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerOrderLine_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerOrderLine_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerOrderLine_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerOrderLine_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerOrderLine_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerOrderLine_DateTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOrderLine_DateTo.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerOrderLine_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerOrderLine_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerOrderLine_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerOrderLine_DateTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOrderLine_DateTo.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerOrderLine_DateTo.Name = "DateTimePickerOrderLine_DateTo"
            Me.DateTimePickerOrderLine_DateTo.ReadOnly = False
            Me.DateTimePickerOrderLine_DateTo.Size = New System.Drawing.Size(97, 21)
            Me.DateTimePickerOrderLine_DateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerOrderLine_DateTo.TabIndex = 4
            Me.DateTimePickerOrderLine_DateTo.TabOnEnter = True
            Me.DateTimePickerOrderLine_DateTo.Value = New Date(2014, 4, 18, 14, 11, 55, 950)
            '
            'LabelOrderLineDateRange_To
            '
            Me.LabelOrderLineDateRange_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOrderLineDateRange_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOrderLineDateRange_To.Location = New System.Drawing.Point(160, 25)
            Me.LabelOrderLineDateRange_To.Name = "LabelOrderLineDateRange_To"
            Me.LabelOrderLineDateRange_To.Size = New System.Drawing.Size(33, 20)
            Me.LabelOrderLineDateRange_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOrderLineDateRange_To.TabIndex = 3
            Me.LabelOrderLineDateRange_To.Text = "To:"
            '
            'GroupBoxForm_SelectMediaTypes
            '
            Me.GroupBoxForm_SelectMediaTypes.Controls.Add(Me.CheckBoxMediaType_PurchaseOrder)
            Me.GroupBoxForm_SelectMediaTypes.Controls.Add(Me.CheckBoxMediaType_Television)
            Me.GroupBoxForm_SelectMediaTypes.Controls.Add(Me.CheckBoxMediaType_Radio)
            Me.GroupBoxForm_SelectMediaTypes.Controls.Add(Me.CheckBoxMediaType_OutOfHome)
            Me.GroupBoxForm_SelectMediaTypes.Controls.Add(Me.CheckBoxMediaType_Magazine)
            Me.GroupBoxForm_SelectMediaTypes.Controls.Add(Me.CheckBoxMediaType_Internet)
            Me.GroupBoxForm_SelectMediaTypes.Controls.Add(Me.CheckBoxMediaType_Newspaper)
            Me.GroupBoxForm_SelectMediaTypes.Location = New System.Drawing.Point(3, 28)
            Me.GroupBoxForm_SelectMediaTypes.Name = "GroupBoxForm_SelectMediaTypes"
            Me.GroupBoxForm_SelectMediaTypes.Size = New System.Drawing.Size(360, 102)
            Me.GroupBoxForm_SelectMediaTypes.TabIndex = 1
            Me.GroupBoxForm_SelectMediaTypes.Text = "Select Media Types"
            '
            'CheckBoxMediaType_PurchaseOrder
            '
            Me.CheckBoxMediaType_PurchaseOrder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaType_PurchaseOrder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaType_PurchaseOrder.CheckValue = 0
            Me.CheckBoxMediaType_PurchaseOrder.CheckValueChecked = 1
            Me.CheckBoxMediaType_PurchaseOrder.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaType_PurchaseOrder.CheckValueUnchecked = 0
            Me.CheckBoxMediaType_PurchaseOrder.ChildControls = Nothing
            Me.CheckBoxMediaType_PurchaseOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaType_PurchaseOrder.Location = New System.Drawing.Point(5, 76)
            Me.CheckBoxMediaType_PurchaseOrder.Name = "CheckBoxMediaType_PurchaseOrder"
            Me.CheckBoxMediaType_PurchaseOrder.OldestSibling = Nothing
            Me.CheckBoxMediaType_PurchaseOrder.SecurityEnabled = True
            Me.CheckBoxMediaType_PurchaseOrder.SiblingControls = Nothing
            Me.CheckBoxMediaType_PurchaseOrder.Size = New System.Drawing.Size(101, 20)
            Me.CheckBoxMediaType_PurchaseOrder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaType_PurchaseOrder.TabIndex = 6
            Me.CheckBoxMediaType_PurchaseOrder.TabOnEnter = True
            Me.CheckBoxMediaType_PurchaseOrder.Text = "Purchase Order"
            '
            'CheckBoxMediaType_Television
            '
            Me.CheckBoxMediaType_Television.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaType_Television.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaType_Television.CheckValue = 0
            Me.CheckBoxMediaType_Television.CheckValueChecked = 1
            Me.CheckBoxMediaType_Television.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaType_Television.CheckValueUnchecked = 0
            Me.CheckBoxMediaType_Television.ChildControls = Nothing
            Me.CheckBoxMediaType_Television.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaType_Television.Location = New System.Drawing.Point(231, 50)
            Me.CheckBoxMediaType_Television.Name = "CheckBoxMediaType_Television"
            Me.CheckBoxMediaType_Television.OldestSibling = Nothing
            Me.CheckBoxMediaType_Television.SecurityEnabled = True
            Me.CheckBoxMediaType_Television.SiblingControls = Nothing
            Me.CheckBoxMediaType_Television.Size = New System.Drawing.Size(101, 20)
            Me.CheckBoxMediaType_Television.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaType_Television.TabIndex = 5
            Me.CheckBoxMediaType_Television.TabOnEnter = True
            Me.CheckBoxMediaType_Television.Text = "Television"
            '
            'CheckBoxMediaType_Radio
            '
            Me.CheckBoxMediaType_Radio.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaType_Radio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaType_Radio.CheckValue = 0
            Me.CheckBoxMediaType_Radio.CheckValueChecked = 1
            Me.CheckBoxMediaType_Radio.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaType_Radio.CheckValueUnchecked = 0
            Me.CheckBoxMediaType_Radio.ChildControls = Nothing
            Me.CheckBoxMediaType_Radio.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaType_Radio.Location = New System.Drawing.Point(124, 50)
            Me.CheckBoxMediaType_Radio.Name = "CheckBoxMediaType_Radio"
            Me.CheckBoxMediaType_Radio.OldestSibling = Nothing
            Me.CheckBoxMediaType_Radio.SecurityEnabled = True
            Me.CheckBoxMediaType_Radio.SiblingControls = Nothing
            Me.CheckBoxMediaType_Radio.Size = New System.Drawing.Size(101, 20)
            Me.CheckBoxMediaType_Radio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaType_Radio.TabIndex = 4
            Me.CheckBoxMediaType_Radio.TabOnEnter = True
            Me.CheckBoxMediaType_Radio.Text = "Radio"
            '
            'CheckBoxMediaType_OutOfHome
            '
            Me.CheckBoxMediaType_OutOfHome.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaType_OutOfHome.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaType_OutOfHome.CheckValue = 0
            Me.CheckBoxMediaType_OutOfHome.CheckValueChecked = 1
            Me.CheckBoxMediaType_OutOfHome.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaType_OutOfHome.CheckValueUnchecked = 0
            Me.CheckBoxMediaType_OutOfHome.ChildControls = Nothing
            Me.CheckBoxMediaType_OutOfHome.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaType_OutOfHome.Location = New System.Drawing.Point(5, 50)
            Me.CheckBoxMediaType_OutOfHome.Name = "CheckBoxMediaType_OutOfHome"
            Me.CheckBoxMediaType_OutOfHome.OldestSibling = Nothing
            Me.CheckBoxMediaType_OutOfHome.SecurityEnabled = True
            Me.CheckBoxMediaType_OutOfHome.SiblingControls = Nothing
            Me.CheckBoxMediaType_OutOfHome.Size = New System.Drawing.Size(101, 20)
            Me.CheckBoxMediaType_OutOfHome.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaType_OutOfHome.TabIndex = 3
            Me.CheckBoxMediaType_OutOfHome.TabOnEnter = True
            Me.CheckBoxMediaType_OutOfHome.Text = "Out of Home"
            '
            'CheckBoxMediaType_Magazine
            '
            Me.CheckBoxMediaType_Magazine.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaType_Magazine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaType_Magazine.CheckValue = 0
            Me.CheckBoxMediaType_Magazine.CheckValueChecked = 1
            Me.CheckBoxMediaType_Magazine.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaType_Magazine.CheckValueUnchecked = 0
            Me.CheckBoxMediaType_Magazine.ChildControls = Nothing
            Me.CheckBoxMediaType_Magazine.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaType_Magazine.Location = New System.Drawing.Point(231, 24)
            Me.CheckBoxMediaType_Magazine.Name = "CheckBoxMediaType_Magazine"
            Me.CheckBoxMediaType_Magazine.OldestSibling = Nothing
            Me.CheckBoxMediaType_Magazine.SecurityEnabled = True
            Me.CheckBoxMediaType_Magazine.SiblingControls = Nothing
            Me.CheckBoxMediaType_Magazine.Size = New System.Drawing.Size(101, 20)
            Me.CheckBoxMediaType_Magazine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaType_Magazine.TabIndex = 2
            Me.CheckBoxMediaType_Magazine.TabOnEnter = True
            Me.CheckBoxMediaType_Magazine.Text = "Magazine"
            '
            'CheckBoxMediaType_Internet
            '
            Me.CheckBoxMediaType_Internet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaType_Internet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaType_Internet.CheckValue = 0
            Me.CheckBoxMediaType_Internet.CheckValueChecked = 1
            Me.CheckBoxMediaType_Internet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaType_Internet.CheckValueUnchecked = 0
            Me.CheckBoxMediaType_Internet.ChildControls = Nothing
            Me.CheckBoxMediaType_Internet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaType_Internet.Location = New System.Drawing.Point(124, 24)
            Me.CheckBoxMediaType_Internet.Name = "CheckBoxMediaType_Internet"
            Me.CheckBoxMediaType_Internet.OldestSibling = Nothing
            Me.CheckBoxMediaType_Internet.SecurityEnabled = True
            Me.CheckBoxMediaType_Internet.SiblingControls = Nothing
            Me.CheckBoxMediaType_Internet.Size = New System.Drawing.Size(101, 20)
            Me.CheckBoxMediaType_Internet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaType_Internet.TabIndex = 1
            Me.CheckBoxMediaType_Internet.TabOnEnter = True
            Me.CheckBoxMediaType_Internet.Text = "Internet"
            '
            'CheckBoxMediaType_Newspaper
            '
            Me.CheckBoxMediaType_Newspaper.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaType_Newspaper.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaType_Newspaper.CheckValue = 0
            Me.CheckBoxMediaType_Newspaper.CheckValueChecked = 1
            Me.CheckBoxMediaType_Newspaper.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaType_Newspaper.CheckValueUnchecked = 0
            Me.CheckBoxMediaType_Newspaper.ChildControls = Nothing
            Me.CheckBoxMediaType_Newspaper.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaType_Newspaper.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxMediaType_Newspaper.Name = "CheckBoxMediaType_Newspaper"
            Me.CheckBoxMediaType_Newspaper.OldestSibling = Nothing
            Me.CheckBoxMediaType_Newspaper.SecurityEnabled = True
            Me.CheckBoxMediaType_Newspaper.SiblingControls = Nothing
            Me.CheckBoxMediaType_Newspaper.Size = New System.Drawing.Size(101, 20)
            Me.CheckBoxMediaType_Newspaper.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaType_Newspaper.TabIndex = 0
            Me.CheckBoxMediaType_Newspaper.TabOnEnter = True
            Me.CheckBoxMediaType_Newspaper.Text = "Newspaper"
            '
            'GroupBoxSearch_SelectBy
            '
            Me.GroupBoxSearch_SelectBy.Controls.Add(Me.RadioButtonSelectBy_Buyer)
            Me.GroupBoxSearch_SelectBy.Controls.Add(Me.TextBoxSelectBy_LastFour)
            Me.GroupBoxSearch_SelectBy.Controls.Add(Me.RadioButtonSelectBy_LastFour)
            Me.GroupBoxSearch_SelectBy.Controls.Add(Me.RadioButtonSelectBy_Vendor)
            Me.GroupBoxSearch_SelectBy.Controls.Add(Me.NumericInputSelectBy_OrderNumber)
            Me.GroupBoxSearch_SelectBy.Controls.Add(Me.RadioButtonSelectBy_Order)
            Me.GroupBoxSearch_SelectBy.Controls.Add(Me.RadioButtonSelectBy_JobComponent)
            Me.GroupBoxSearch_SelectBy.Controls.Add(Me.RadioButtonSelectBy_ClientDivisionProduct)
            Me.GroupBoxSearch_SelectBy.Controls.Add(Me.RadioButtonSelectBy_ClientDivision)
            Me.GroupBoxSearch_SelectBy.Controls.Add(Me.RadioButtonSelectBy_AllOpenOrders)
            Me.GroupBoxSearch_SelectBy.Controls.Add(Me.RadioButtonSelectBy_Job)
            Me.GroupBoxSearch_SelectBy.Controls.Add(Me.RadioButtonSelectBy_Campaign)
            Me.GroupBoxSearch_SelectBy.Controls.Add(Me.RadioButtonSelectBy_Client)
            Me.GroupBoxSearch_SelectBy.Controls.Add(Me.RadioButtonSelectBy_OrderStatus)
            Me.GroupBoxSearch_SelectBy.Controls.Add(Me.RadioButtonSelectBy_AccountExecutiveJob)
            Me.GroupBoxSearch_SelectBy.Controls.Add(Me.RadioButtonSelectBy_AccountExecutiveDefault)
            Me.GroupBoxSearch_SelectBy.Location = New System.Drawing.Point(2, 308)
            Me.GroupBoxSearch_SelectBy.Name = "GroupBoxSearch_SelectBy"
            Me.GroupBoxSearch_SelectBy.Size = New System.Drawing.Size(361, 206)
            Me.GroupBoxSearch_SelectBy.TabIndex = 0
            Me.GroupBoxSearch_SelectBy.Text = "Select By"
            '
            'RadioButtonSelectBy_Buyer
            '
            Me.RadioButtonSelectBy_Buyer.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectBy_Buyer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectBy_Buyer.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectBy_Buyer.Location = New System.Drawing.Point(5, 179)
            Me.RadioButtonSelectBy_Buyer.Name = "RadioButtonSelectBy_Buyer"
            Me.RadioButtonSelectBy_Buyer.SecurityEnabled = True
            Me.RadioButtonSelectBy_Buyer.Size = New System.Drawing.Size(168, 20)
            Me.RadioButtonSelectBy_Buyer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectBy_Buyer.TabIndex = 12
            Me.RadioButtonSelectBy_Buyer.TabOnEnter = True
            Me.RadioButtonSelectBy_Buyer.TabStop = False
            Me.RadioButtonSelectBy_Buyer.Tag = ""
            Me.RadioButtonSelectBy_Buyer.Text = "Buyer"
            '
            'TextBoxSelectBy_LastFour
            '
            Me.TextBoxSelectBy_LastFour.BackColor = System.Drawing.SystemColors.Control
            '
            '
            '
            Me.TextBoxSelectBy_LastFour.Border.Class = "TextBoxBorder"
            Me.TextBoxSelectBy_LastFour.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSelectBy_LastFour.CheckSpellingOnValidate = False
            Me.TextBoxSelectBy_LastFour.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSelectBy_LastFour.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxSelectBy_LastFour.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSelectBy_LastFour.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSelectBy_LastFour.FocusHighlightEnabled = True
            Me.TextBoxSelectBy_LastFour.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSelectBy_LastFour.Location = New System.Drawing.Point(303, 179)
            Me.TextBoxSelectBy_LastFour.MaxFileSize = CType(0, Long)
            Me.TextBoxSelectBy_LastFour.MaxLength = 4
            Me.TextBoxSelectBy_LastFour.Name = "TextBoxSelectBy_LastFour"
            Me.TextBoxSelectBy_LastFour.SecurityEnabled = True
            Me.TextBoxSelectBy_LastFour.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSelectBy_LastFour.Size = New System.Drawing.Size(46, 21)
            Me.TextBoxSelectBy_LastFour.StartingFolderName = Nothing
            Me.TextBoxSelectBy_LastFour.TabIndex = 14
            Me.TextBoxSelectBy_LastFour.TabOnEnter = True
            Me.TextBoxSelectBy_LastFour.Text = "4848"
            '
            'RadioButtonSelectBy_LastFour
            '
            Me.RadioButtonSelectBy_LastFour.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectBy_LastFour.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectBy_LastFour.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectBy_LastFour.Location = New System.Drawing.Point(179, 179)
            Me.RadioButtonSelectBy_LastFour.Name = "RadioButtonSelectBy_LastFour"
            Me.RadioButtonSelectBy_LastFour.SecurityEnabled = True
            Me.RadioButtonSelectBy_LastFour.Size = New System.Drawing.Size(118, 20)
            Me.RadioButtonSelectBy_LastFour.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectBy_LastFour.TabIndex = 13
            Me.RadioButtonSelectBy_LastFour.TabOnEnter = True
            Me.RadioButtonSelectBy_LastFour.TabStop = False
            Me.RadioButtonSelectBy_LastFour.Tag = ""
            Me.RadioButtonSelectBy_LastFour.Text = "Last 4 CC"
            '
            'RadioButtonSelectBy_Vendor
            '
            Me.RadioButtonSelectBy_Vendor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectBy_Vendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectBy_Vendor.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectBy_Vendor.Location = New System.Drawing.Point(5, 154)
            Me.RadioButtonSelectBy_Vendor.Name = "RadioButtonSelectBy_Vendor"
            Me.RadioButtonSelectBy_Vendor.SecurityEnabled = True
            Me.RadioButtonSelectBy_Vendor.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonSelectBy_Vendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectBy_Vendor.TabIndex = 10
            Me.RadioButtonSelectBy_Vendor.TabOnEnter = True
            Me.RadioButtonSelectBy_Vendor.TabStop = False
            Me.RadioButtonSelectBy_Vendor.Tag = ""
            Me.RadioButtonSelectBy_Vendor.Text = "Vendor"
            '
            'NumericInputSelectBy_OrderNumber
            '
            Me.NumericInputSelectBy_OrderNumber.AllowDrop = True
            Me.NumericInputSelectBy_OrderNumber.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputSelectBy_OrderNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputSelectBy_OrderNumber.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputSelectBy_OrderNumber.EnterMoveNextControl = True
            Me.NumericInputSelectBy_OrderNumber.Location = New System.Drawing.Point(264, 76)
            Me.NumericInputSelectBy_OrderNumber.Name = "NumericInputSelectBy_OrderNumber"
            Me.NumericInputSelectBy_OrderNumber.Properties.AllowMouseWheel = False
            Me.NumericInputSelectBy_OrderNumber.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputSelectBy_OrderNumber.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputSelectBy_OrderNumber.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputSelectBy_OrderNumber.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSelectBy_OrderNumber.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputSelectBy_OrderNumber.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSelectBy_OrderNumber.Properties.IsFloatValue = False
            Me.NumericInputSelectBy_OrderNumber.Properties.Mask.EditMask = "f0"
            Me.NumericInputSelectBy_OrderNumber.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputSelectBy_OrderNumber.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputSelectBy_OrderNumber.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputSelectBy_OrderNumber.SecurityEnabled = True
            Me.NumericInputSelectBy_OrderNumber.Size = New System.Drawing.Size(85, 20)
            Me.NumericInputSelectBy_OrderNumber.TabIndex = 12
            Me.NumericInputSelectBy_OrderNumber.TabStop = False
            '
            'RadioButtonSelectBy_Order
            '
            Me.RadioButtonSelectBy_Order.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectBy_Order.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectBy_Order.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectBy_Order.Location = New System.Drawing.Point(180, 76)
            Me.RadioButtonSelectBy_Order.Name = "RadioButtonSelectBy_Order"
            Me.RadioButtonSelectBy_Order.SecurityEnabled = True
            Me.RadioButtonSelectBy_Order.Size = New System.Drawing.Size(78, 20)
            Me.RadioButtonSelectBy_Order.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectBy_Order.TabIndex = 5
            Me.RadioButtonSelectBy_Order.TabOnEnter = True
            Me.RadioButtonSelectBy_Order.TabStop = False
            Me.RadioButtonSelectBy_Order.Tag = ""
            Me.RadioButtonSelectBy_Order.Text = "Order"
            '
            'RadioButtonSelectBy_JobComponent
            '
            Me.RadioButtonSelectBy_JobComponent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectBy_JobComponent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectBy_JobComponent.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectBy_JobComponent.Location = New System.Drawing.Point(180, 50)
            Me.RadioButtonSelectBy_JobComponent.Name = "RadioButtonSelectBy_JobComponent"
            Me.RadioButtonSelectBy_JobComponent.SecurityEnabled = True
            Me.RadioButtonSelectBy_JobComponent.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonSelectBy_JobComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectBy_JobComponent.TabIndex = 3
            Me.RadioButtonSelectBy_JobComponent.TabOnEnter = True
            Me.RadioButtonSelectBy_JobComponent.TabStop = False
            Me.RadioButtonSelectBy_JobComponent.Tag = ""
            Me.RadioButtonSelectBy_JobComponent.Text = "Job / Component"
            '
            'RadioButtonSelectBy_ClientDivisionProduct
            '
            Me.RadioButtonSelectBy_ClientDivisionProduct.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectBy_ClientDivisionProduct.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectBy_ClientDivisionProduct.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectBy_ClientDivisionProduct.Location = New System.Drawing.Point(5, 102)
            Me.RadioButtonSelectBy_ClientDivisionProduct.Name = "RadioButtonSelectBy_ClientDivisionProduct"
            Me.RadioButtonSelectBy_ClientDivisionProduct.SecurityEnabled = True
            Me.RadioButtonSelectBy_ClientDivisionProduct.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonSelectBy_ClientDivisionProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectBy_ClientDivisionProduct.TabIndex = 6
            Me.RadioButtonSelectBy_ClientDivisionProduct.TabOnEnter = True
            Me.RadioButtonSelectBy_ClientDivisionProduct.TabStop = False
            Me.RadioButtonSelectBy_ClientDivisionProduct.Tag = ""
            Me.RadioButtonSelectBy_ClientDivisionProduct.Text = "Client / Division / Product"
            '
            'RadioButtonSelectBy_ClientDivision
            '
            Me.RadioButtonSelectBy_ClientDivision.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectBy_ClientDivision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectBy_ClientDivision.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectBy_ClientDivision.Location = New System.Drawing.Point(5, 76)
            Me.RadioButtonSelectBy_ClientDivision.Name = "RadioButtonSelectBy_ClientDivision"
            Me.RadioButtonSelectBy_ClientDivision.SecurityEnabled = True
            Me.RadioButtonSelectBy_ClientDivision.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonSelectBy_ClientDivision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectBy_ClientDivision.TabIndex = 4
            Me.RadioButtonSelectBy_ClientDivision.TabOnEnter = True
            Me.RadioButtonSelectBy_ClientDivision.TabStop = False
            Me.RadioButtonSelectBy_ClientDivision.Tag = ""
            Me.RadioButtonSelectBy_ClientDivision.Text = "Client / Division"
            '
            'RadioButtonSelectBy_AllOpenOrders
            '
            Me.RadioButtonSelectBy_AllOpenOrders.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectBy_AllOpenOrders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectBy_AllOpenOrders.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectBy_AllOpenOrders.Checked = True
            Me.RadioButtonSelectBy_AllOpenOrders.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectBy_AllOpenOrders.CheckValue = "Y"
            Me.RadioButtonSelectBy_AllOpenOrders.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonSelectBy_AllOpenOrders.Name = "RadioButtonSelectBy_AllOpenOrders"
            Me.RadioButtonSelectBy_AllOpenOrders.SecurityEnabled = True
            Me.RadioButtonSelectBy_AllOpenOrders.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonSelectBy_AllOpenOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectBy_AllOpenOrders.TabIndex = 0
            Me.RadioButtonSelectBy_AllOpenOrders.TabOnEnter = True
            Me.RadioButtonSelectBy_AllOpenOrders.Tag = ""
            Me.RadioButtonSelectBy_AllOpenOrders.Text = "All Open Orders"
            '
            'RadioButtonSelectBy_Job
            '
            Me.RadioButtonSelectBy_Job.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectBy_Job.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectBy_Job.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectBy_Job.Location = New System.Drawing.Point(180, 24)
            Me.RadioButtonSelectBy_Job.Name = "RadioButtonSelectBy_Job"
            Me.RadioButtonSelectBy_Job.SecurityEnabled = True
            Me.RadioButtonSelectBy_Job.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonSelectBy_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectBy_Job.TabIndex = 1
            Me.RadioButtonSelectBy_Job.TabOnEnter = True
            Me.RadioButtonSelectBy_Job.TabStop = False
            Me.RadioButtonSelectBy_Job.Tag = ""
            Me.RadioButtonSelectBy_Job.Text = "Job"
            '
            'RadioButtonSelectBy_Campaign
            '
            Me.RadioButtonSelectBy_Campaign.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectBy_Campaign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectBy_Campaign.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectBy_Campaign.Location = New System.Drawing.Point(5, 128)
            Me.RadioButtonSelectBy_Campaign.Name = "RadioButtonSelectBy_Campaign"
            Me.RadioButtonSelectBy_Campaign.SecurityEnabled = True
            Me.RadioButtonSelectBy_Campaign.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonSelectBy_Campaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectBy_Campaign.TabIndex = 8
            Me.RadioButtonSelectBy_Campaign.TabOnEnter = True
            Me.RadioButtonSelectBy_Campaign.TabStop = False
            Me.RadioButtonSelectBy_Campaign.Tag = ""
            Me.RadioButtonSelectBy_Campaign.Text = "Campaign"
            '
            'RadioButtonSelectBy_Client
            '
            Me.RadioButtonSelectBy_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectBy_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectBy_Client.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectBy_Client.Location = New System.Drawing.Point(5, 50)
            Me.RadioButtonSelectBy_Client.Name = "RadioButtonSelectBy_Client"
            Me.RadioButtonSelectBy_Client.SecurityEnabled = True
            Me.RadioButtonSelectBy_Client.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonSelectBy_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectBy_Client.TabIndex = 2
            Me.RadioButtonSelectBy_Client.TabOnEnter = True
            Me.RadioButtonSelectBy_Client.TabStop = False
            Me.RadioButtonSelectBy_Client.Tag = ""
            Me.RadioButtonSelectBy_Client.Text = "Client"
            '
            'RadioButtonSelectBy_OrderStatus
            '
            Me.RadioButtonSelectBy_OrderStatus.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectBy_OrderStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectBy_OrderStatus.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectBy_OrderStatus.Location = New System.Drawing.Point(180, 154)
            Me.RadioButtonSelectBy_OrderStatus.Name = "RadioButtonSelectBy_OrderStatus"
            Me.RadioButtonSelectBy_OrderStatus.SecurityEnabled = True
            Me.RadioButtonSelectBy_OrderStatus.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonSelectBy_OrderStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectBy_OrderStatus.TabIndex = 11
            Me.RadioButtonSelectBy_OrderStatus.TabOnEnter = True
            Me.RadioButtonSelectBy_OrderStatus.TabStop = False
            Me.RadioButtonSelectBy_OrderStatus.Tag = ""
            Me.RadioButtonSelectBy_OrderStatus.Text = "Order Status"
            '
            'RadioButtonSelectBy_AccountExecutiveJob
            '
            Me.RadioButtonSelectBy_AccountExecutiveJob.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectBy_AccountExecutiveJob.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectBy_AccountExecutiveJob.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectBy_AccountExecutiveJob.Location = New System.Drawing.Point(180, 128)
            Me.RadioButtonSelectBy_AccountExecutiveJob.Name = "RadioButtonSelectBy_AccountExecutiveJob"
            Me.RadioButtonSelectBy_AccountExecutiveJob.SecurityEnabled = True
            Me.RadioButtonSelectBy_AccountExecutiveJob.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonSelectBy_AccountExecutiveJob.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectBy_AccountExecutiveJob.TabIndex = 9
            Me.RadioButtonSelectBy_AccountExecutiveJob.TabOnEnter = True
            Me.RadioButtonSelectBy_AccountExecutiveJob.TabStop = False
            Me.RadioButtonSelectBy_AccountExecutiveJob.Tag = ""
            Me.RadioButtonSelectBy_AccountExecutiveJob.Text = "Account Executive (Job)"
            '
            'RadioButtonSelectBy_AccountExecutiveDefault
            '
            Me.RadioButtonSelectBy_AccountExecutiveDefault.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectBy_AccountExecutiveDefault.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectBy_AccountExecutiveDefault.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectBy_AccountExecutiveDefault.Location = New System.Drawing.Point(180, 102)
            Me.RadioButtonSelectBy_AccountExecutiveDefault.Name = "RadioButtonSelectBy_AccountExecutiveDefault"
            Me.RadioButtonSelectBy_AccountExecutiveDefault.SecurityEnabled = True
            Me.RadioButtonSelectBy_AccountExecutiveDefault.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonSelectBy_AccountExecutiveDefault.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectBy_AccountExecutiveDefault.TabIndex = 7
            Me.RadioButtonSelectBy_AccountExecutiveDefault.TabOnEnter = True
            Me.RadioButtonSelectBy_AccountExecutiveDefault.TabStop = False
            Me.RadioButtonSelectBy_AccountExecutiveDefault.Tag = ""
            Me.RadioButtonSelectBy_AccountExecutiveDefault.Text = "Account Executive"
            '
            'GroupBoxForm_Include
            '
            Me.GroupBoxForm_Include.Controls.Add(Me.CheckBoxInclude_ClosedOrders)
            Me.GroupBoxForm_Include.Controls.Add(Me.RadioButtonInclude_Both)
            Me.GroupBoxForm_Include.Controls.Add(Me.RadioButtonInclude_QuotesOnly)
            Me.GroupBoxForm_Include.Controls.Add(Me.RadioButtonInclude_OrdersOnly)
            Me.GroupBoxForm_Include.Location = New System.Drawing.Point(3, 136)
            Me.GroupBoxForm_Include.Name = "GroupBoxForm_Include"
            Me.GroupBoxForm_Include.Size = New System.Drawing.Size(360, 77)
            Me.GroupBoxForm_Include.TabIndex = 2
            Me.GroupBoxForm_Include.Text = "Include"
            '
            'CheckBoxInclude_ClosedOrders
            '
            Me.CheckBoxInclude_ClosedOrders.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxInclude_ClosedOrders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInclude_ClosedOrders.CheckValue = 0
            Me.CheckBoxInclude_ClosedOrders.CheckValueChecked = 1
            Me.CheckBoxInclude_ClosedOrders.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInclude_ClosedOrders.CheckValueUnchecked = 0
            Me.CheckBoxInclude_ClosedOrders.ChildControls = Nothing
            Me.CheckBoxInclude_ClosedOrders.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInclude_ClosedOrders.Location = New System.Drawing.Point(9, 50)
            Me.CheckBoxInclude_ClosedOrders.Name = "CheckBoxInclude_ClosedOrders"
            Me.CheckBoxInclude_ClosedOrders.OldestSibling = Nothing
            Me.CheckBoxInclude_ClosedOrders.SecurityEnabled = True
            Me.CheckBoxInclude_ClosedOrders.SiblingControls = Nothing
            Me.CheckBoxInclude_ClosedOrders.Size = New System.Drawing.Size(109, 20)
            Me.CheckBoxInclude_ClosedOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInclude_ClosedOrders.TabIndex = 14
            Me.CheckBoxInclude_ClosedOrders.TabOnEnter = True
            Me.CheckBoxInclude_ClosedOrders.Text = "Closed Orders"
            '
            'RadioButtonInclude_Both
            '
            Me.RadioButtonInclude_Both.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonInclude_Both.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonInclude_Both.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonInclude_Both.Checked = True
            Me.RadioButtonInclude_Both.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonInclude_Both.CheckValue = "Y"
            Me.RadioButtonInclude_Both.Location = New System.Drawing.Point(239, 24)
            Me.RadioButtonInclude_Both.Name = "RadioButtonInclude_Both"
            Me.RadioButtonInclude_Both.SecurityEnabled = True
            Me.RadioButtonInclude_Both.Size = New System.Drawing.Size(109, 20)
            Me.RadioButtonInclude_Both.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonInclude_Both.TabIndex = 13
            Me.RadioButtonInclude_Both.TabOnEnter = True
            Me.RadioButtonInclude_Both.Tag = ""
            Me.RadioButtonInclude_Both.Text = "Both"
            '
            'RadioButtonInclude_QuotesOnly
            '
            Me.RadioButtonInclude_QuotesOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonInclude_QuotesOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonInclude_QuotesOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonInclude_QuotesOnly.Location = New System.Drawing.Point(124, 24)
            Me.RadioButtonInclude_QuotesOnly.Name = "RadioButtonInclude_QuotesOnly"
            Me.RadioButtonInclude_QuotesOnly.SecurityEnabled = True
            Me.RadioButtonInclude_QuotesOnly.Size = New System.Drawing.Size(109, 20)
            Me.RadioButtonInclude_QuotesOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonInclude_QuotesOnly.TabIndex = 12
            Me.RadioButtonInclude_QuotesOnly.TabOnEnter = True
            Me.RadioButtonInclude_QuotesOnly.TabStop = False
            Me.RadioButtonInclude_QuotesOnly.Tag = ""
            Me.RadioButtonInclude_QuotesOnly.Text = "Quotes Only"
            '
            'RadioButtonInclude_OrdersOnly
            '
            Me.RadioButtonInclude_OrdersOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonInclude_OrdersOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonInclude_OrdersOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonInclude_OrdersOnly.Location = New System.Drawing.Point(9, 24)
            Me.RadioButtonInclude_OrdersOnly.Name = "RadioButtonInclude_OrdersOnly"
            Me.RadioButtonInclude_OrdersOnly.SecurityEnabled = True
            Me.RadioButtonInclude_OrdersOnly.Size = New System.Drawing.Size(109, 20)
            Me.RadioButtonInclude_OrdersOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonInclude_OrdersOnly.TabIndex = 11
            Me.RadioButtonInclude_OrdersOnly.TabOnEnter = True
            Me.RadioButtonInclude_OrdersOnly.TabStop = False
            Me.RadioButtonInclude_OrdersOnly.Tag = ""
            Me.RadioButtonInclude_OrdersOnly.Text = "Orders Only"
            '
            'GroupBoxForm_JobMediaDateToBillDateRange
            '
            Me.GroupBoxForm_JobMediaDateToBillDateRange.Controls.Add(Me.LabelJobMediaDateRange_From)
            Me.GroupBoxForm_JobMediaDateToBillDateRange.Controls.Add(Me.DateTimePickerJob_DateFrom)
            Me.GroupBoxForm_JobMediaDateToBillDateRange.Controls.Add(Me.DateTimePickerJob_DateTo)
            Me.GroupBoxForm_JobMediaDateToBillDateRange.Controls.Add(Me.LabelJobMediaDateRange_To)
            Me.GroupBoxForm_JobMediaDateToBillDateRange.Location = New System.Drawing.Point(3, 246)
            Me.GroupBoxForm_JobMediaDateToBillDateRange.Name = "GroupBoxForm_JobMediaDateToBillDateRange"
            Me.GroupBoxForm_JobMediaDateToBillDateRange.Size = New System.Drawing.Size(360, 56)
            Me.GroupBoxForm_JobMediaDateToBillDateRange.TabIndex = 4
            Me.GroupBoxForm_JobMediaDateToBillDateRange.Text = "Job or Media Date to Bill"
            '
            'LabelJobMediaDateRange_From
            '
            Me.LabelJobMediaDateRange_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelJobMediaDateRange_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelJobMediaDateRange_From.Location = New System.Drawing.Point(5, 23)
            Me.LabelJobMediaDateRange_From.Name = "LabelJobMediaDateRange_From"
            Me.LabelJobMediaDateRange_From.Size = New System.Drawing.Size(46, 20)
            Me.LabelJobMediaDateRange_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelJobMediaDateRange_From.TabIndex = 1
            Me.LabelJobMediaDateRange_From.Text = "From:"
            '
            'DateTimePickerJob_DateFrom
            '
            Me.DateTimePickerJob_DateFrom.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerJob_DateFrom.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerJob_DateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerJob_DateFrom.ButtonClear.Visible = True
            Me.DateTimePickerJob_DateFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerJob_DateFrom.ButtonDropDown.Visible = True
            Me.DateTimePickerJob_DateFrom.ButtonFreeText.Checked = True
            Me.DateTimePickerJob_DateFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerJob_DateFrom.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerJob_DateFrom.DisplayName = ""
            Me.DateTimePickerJob_DateFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerJob_DateFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerJob_DateFrom.FocusHighlightEnabled = True
            Me.DateTimePickerJob_DateFrom.FreeTextEntryMode = True
            Me.DateTimePickerJob_DateFrom.IsPopupCalendarOpen = False
            Me.DateTimePickerJob_DateFrom.Location = New System.Drawing.Point(62, 23)
            Me.DateTimePickerJob_DateFrom.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerJob_DateFrom.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerJob_DateFrom.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerJob_DateFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerJob_DateFrom.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerJob_DateFrom.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerJob_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerJob_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerJob_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerJob_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerJob_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerJob_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerJob_DateFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerJob_DateFrom.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerJob_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerJob_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerJob_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerJob_DateFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerJob_DateFrom.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerJob_DateFrom.Name = "DateTimePickerJob_DateFrom"
            Me.DateTimePickerJob_DateFrom.ReadOnly = False
            Me.DateTimePickerJob_DateFrom.Size = New System.Drawing.Size(97, 21)
            Me.DateTimePickerJob_DateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerJob_DateFrom.TabIndex = 2
            Me.DateTimePickerJob_DateFrom.TabOnEnter = True
            Me.DateTimePickerJob_DateFrom.Value = New Date(2013, 7, 23, 13, 58, 57, 366)
            '
            'DateTimePickerJob_DateTo
            '
            Me.DateTimePickerJob_DateTo.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerJob_DateTo.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerJob_DateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerJob_DateTo.ButtonClear.Visible = True
            Me.DateTimePickerJob_DateTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerJob_DateTo.ButtonDropDown.Visible = True
            Me.DateTimePickerJob_DateTo.ButtonFreeText.Checked = True
            Me.DateTimePickerJob_DateTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerJob_DateTo.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerJob_DateTo.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerJob_DateTo.DisplayName = ""
            Me.DateTimePickerJob_DateTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerJob_DateTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerJob_DateTo.FocusHighlightEnabled = True
            Me.DateTimePickerJob_DateTo.FreeTextEntryMode = True
            Me.DateTimePickerJob_DateTo.IsPopupCalendarOpen = False
            Me.DateTimePickerJob_DateTo.Location = New System.Drawing.Point(204, 24)
            Me.DateTimePickerJob_DateTo.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerJob_DateTo.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerJob_DateTo.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerJob_DateTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerJob_DateTo.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerJob_DateTo.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerJob_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerJob_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerJob_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerJob_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerJob_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerJob_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerJob_DateTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerJob_DateTo.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerJob_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerJob_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerJob_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerJob_DateTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerJob_DateTo.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerJob_DateTo.Name = "DateTimePickerJob_DateTo"
            Me.DateTimePickerJob_DateTo.ReadOnly = False
            Me.DateTimePickerJob_DateTo.Size = New System.Drawing.Size(97, 21)
            Me.DateTimePickerJob_DateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerJob_DateTo.TabIndex = 4
            Me.DateTimePickerJob_DateTo.TabOnEnter = True
            Me.DateTimePickerJob_DateTo.Value = New Date(2014, 4, 18, 14, 11, 55, 950)
            '
            'LabelJobMediaDateRange_To
            '
            Me.LabelJobMediaDateRange_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelJobMediaDateRange_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelJobMediaDateRange_To.Location = New System.Drawing.Point(165, 24)
            Me.LabelJobMediaDateRange_To.Name = "LabelJobMediaDateRange_To"
            Me.LabelJobMediaDateRange_To.Size = New System.Drawing.Size(33, 20)
            Me.LabelJobMediaDateRange_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelJobMediaDateRange_To.TabIndex = 3
            Me.LabelJobMediaDateRange_To.Text = "To:"
            '
            'ExpandablePanelForm_SearchBy
            '
            Me.ExpandablePanelForm_SearchBy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.ExpandablePanelForm_SearchBy.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
            Me.ExpandablePanelForm_SearchBy.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ExpandablePanelForm_SearchBy.Controls.Add(Me.SearchableComboBoxForm_FilterBy)
            Me.ExpandablePanelForm_SearchBy.Controls.Add(Me.GroupBoxForm_JobMediaDateToBillDateRange)
            Me.ExpandablePanelForm_SearchBy.Controls.Add(Me.LabelForm_FilterBy)
            Me.ExpandablePanelForm_SearchBy.Controls.Add(Me.GroupBoxForm_SelectMediaTypes)
            Me.ExpandablePanelForm_SearchBy.Controls.Add(Me.GroupBoxForm_Include)
            Me.ExpandablePanelForm_SearchBy.Controls.Add(Me.GroupBoxSearch_SelectBy)
            Me.ExpandablePanelForm_SearchBy.Controls.Add(Me.GroupBoxForm_MediaByMonth)
            Me.ExpandablePanelForm_SearchBy.Controls.Add(Me.GroupBoxForm_DateRanges)
            Me.ExpandablePanelForm_SearchBy.DisabledBackColor = System.Drawing.Color.Empty
            Me.ExpandablePanelForm_SearchBy.Dock = System.Windows.Forms.DockStyle.Left
            Me.ExpandablePanelForm_SearchBy.Location = New System.Drawing.Point(0, 0)
            Me.ExpandablePanelForm_SearchBy.Name = "ExpandablePanelForm_SearchBy"
            Me.ExpandablePanelForm_SearchBy.Size = New System.Drawing.Size(369, 691)
            Me.ExpandablePanelForm_SearchBy.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.ExpandablePanelForm_SearchBy.Style.BackColor1.Color = System.Drawing.Color.White
            Me.ExpandablePanelForm_SearchBy.Style.BackColor2.Color = System.Drawing.Color.White
            Me.ExpandablePanelForm_SearchBy.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.ExpandablePanelForm_SearchBy.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.ExpandablePanelForm_SearchBy.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandablePanelForm_SearchBy.Style.GradientAngle = 90
            Me.ExpandablePanelForm_SearchBy.TabIndex = 0
            Me.ExpandablePanelForm_SearchBy.TextDockConstrained = False
            Me.ExpandablePanelForm_SearchBy.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
            Me.ExpandablePanelForm_SearchBy.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandablePanelForm_SearchBy.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
            Me.ExpandablePanelForm_SearchBy.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandablePanelForm_SearchBy.TitleStyle.ForeColor.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.ExpandablePanelForm_SearchBy.TitleStyle.GradientAngle = 90
            Me.ExpandablePanelForm_SearchBy.TitleText = "Search By"
            '
            'SearchableComboBoxForm_FilterBy
            '
            Me.SearchableComboBoxForm_FilterBy.ActiveFilterString = ""
            Me.SearchableComboBoxForm_FilterBy.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_FilterBy.AutoFillMode = False
            Me.SearchableComboBoxForm_FilterBy.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_FilterBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.EnumObjects
            Me.SearchableComboBoxForm_FilterBy.DataSource = Nothing
            Me.SearchableComboBoxForm_FilterBy.DisableMouseWheel = True
            Me.SearchableComboBoxForm_FilterBy.DisplayName = "Filter By"
            Me.SearchableComboBoxForm_FilterBy.EditValue = ""
            Me.SearchableComboBoxForm_FilterBy.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_FilterBy.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_FilterBy.Location = New System.Drawing.Point(68, 219)
            Me.SearchableComboBoxForm_FilterBy.Name = "SearchableComboBoxForm_FilterBy"
            Me.SearchableComboBoxForm_FilterBy.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_FilterBy.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_FilterBy.Properties.NullText = "Select"
            Me.SearchableComboBoxForm_FilterBy.Properties.PopupView = Me.GridView2
            Me.SearchableComboBoxForm_FilterBy.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_FilterBy.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_FilterBy.SecurityEnabled = True
            Me.SearchableComboBoxForm_FilterBy.SelectedValue = ""
            Me.SearchableComboBoxForm_FilterBy.Size = New System.Drawing.Size(295, 20)
            Me.SearchableComboBoxForm_FilterBy.TabIndex = 104
            Me.SearchableComboBoxForm_FilterBy.TabStop = False
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
            'LabelForm_FilterBy
            '
            Me.LabelForm_FilterBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FilterBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FilterBy.Location = New System.Drawing.Point(3, 219)
            Me.LabelForm_FilterBy.Name = "LabelForm_FilterBy"
            Me.LabelForm_FilterBy.Size = New System.Drawing.Size(59, 20)
            Me.LabelForm_FilterBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FilterBy.TabIndex = 7
            Me.LabelForm_FilterBy.Text = "Filter By:"
            '
            'GroupBoxForm_MediaByMonth
            '
            Me.GroupBoxForm_MediaByMonth.Controls.Add(Me.NumericInputMediaByMonth_YearTo)
            Me.GroupBoxForm_MediaByMonth.Controls.Add(Me.NumericInputMediaByMonth_YearFrom)
            Me.GroupBoxForm_MediaByMonth.Controls.Add(Me.ComboBoxMediaByMonth_MonthTo)
            Me.GroupBoxForm_MediaByMonth.Controls.Add(Me.ComboBoxMediaByMonth_MonthFrom)
            Me.GroupBoxForm_MediaByMonth.Controls.Add(Me.LabelMediaByMonth_Range)
            Me.GroupBoxForm_MediaByMonth.Location = New System.Drawing.Point(3, 246)
            Me.GroupBoxForm_MediaByMonth.Name = "GroupBoxForm_MediaByMonth"
            Me.GroupBoxForm_MediaByMonth.Size = New System.Drawing.Size(360, 56)
            Me.GroupBoxForm_MediaByMonth.TabIndex = 5
            Me.GroupBoxForm_MediaByMonth.Text = "Media By Month"
            '
            'NumericInputMediaByMonth_YearTo
            '
            Me.NumericInputMediaByMonth_YearTo.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputMediaByMonth_YearTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputMediaByMonth_YearTo.EditValue = New Decimal(New Integer() {1980, 0, 0, 0})
            Me.NumericInputMediaByMonth_YearTo.EnterMoveNextControl = True
            Me.NumericInputMediaByMonth_YearTo.Location = New System.Drawing.Point(265, 24)
            Me.NumericInputMediaByMonth_YearTo.Name = "NumericInputMediaByMonth_YearTo"
            Me.NumericInputMediaByMonth_YearTo.Properties.AllowMouseWheel = False
            Me.NumericInputMediaByMonth_YearTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputMediaByMonth_YearTo.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputMediaByMonth_YearTo.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputMediaByMonth_YearTo.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputMediaByMonth_YearTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMediaByMonth_YearTo.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputMediaByMonth_YearTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMediaByMonth_YearTo.Properties.IsFloatValue = False
            Me.NumericInputMediaByMonth_YearTo.Properties.Mask.EditMask = "f0"
            Me.NumericInputMediaByMonth_YearTo.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputMediaByMonth_YearTo.Properties.MaxValue = New Decimal(New Integer() {2079, 0, 0, 0})
            Me.NumericInputMediaByMonth_YearTo.Properties.MinValue = New Decimal(New Integer() {1980, 0, 0, 0})
            Me.NumericInputMediaByMonth_YearTo.SecurityEnabled = True
            Me.NumericInputMediaByMonth_YearTo.Size = New System.Drawing.Size(44, 20)
            Me.NumericInputMediaByMonth_YearTo.TabIndex = 6
            '
            'NumericInputMediaByMonth_YearFrom
            '
            Me.NumericInputMediaByMonth_YearFrom.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputMediaByMonth_YearFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputMediaByMonth_YearFrom.EditValue = New Decimal(New Integer() {1980, 0, 0, 0})
            Me.NumericInputMediaByMonth_YearFrom.EnterMoveNextControl = True
            Me.NumericInputMediaByMonth_YearFrom.Location = New System.Drawing.Point(130, 24)
            Me.NumericInputMediaByMonth_YearFrom.Name = "NumericInputMediaByMonth_YearFrom"
            Me.NumericInputMediaByMonth_YearFrom.Properties.AllowMouseWheel = False
            Me.NumericInputMediaByMonth_YearFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputMediaByMonth_YearFrom.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputMediaByMonth_YearFrom.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputMediaByMonth_YearFrom.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputMediaByMonth_YearFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMediaByMonth_YearFrom.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputMediaByMonth_YearFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMediaByMonth_YearFrom.Properties.IsFloatValue = False
            Me.NumericInputMediaByMonth_YearFrom.Properties.Mask.EditMask = "f0"
            Me.NumericInputMediaByMonth_YearFrom.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputMediaByMonth_YearFrom.Properties.MaxValue = New Decimal(New Integer() {2079, 0, 0, 0})
            Me.NumericInputMediaByMonth_YearFrom.Properties.MinValue = New Decimal(New Integer() {1980, 0, 0, 0})
            Me.NumericInputMediaByMonth_YearFrom.SecurityEnabled = True
            Me.NumericInputMediaByMonth_YearFrom.Size = New System.Drawing.Size(44, 20)
            Me.NumericInputMediaByMonth_YearFrom.TabIndex = 4
            '
            'ComboBoxMediaByMonth_MonthTo
            '
            Me.ComboBoxMediaByMonth_MonthTo.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMediaByMonth_MonthTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxMediaByMonth_MonthTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMediaByMonth_MonthTo.AutoFindItemInDataSource = True
            Me.ComboBoxMediaByMonth_MonthTo.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMediaByMonth_MonthTo.BookmarkingEnabled = False
            Me.ComboBoxMediaByMonth_MonthTo.ClientCode = ""
            Me.ComboBoxMediaByMonth_MonthTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Month
            Me.ComboBoxMediaByMonth_MonthTo.DisableMouseWheel = True
            Me.ComboBoxMediaByMonth_MonthTo.DisplayMember = "Value"
            Me.ComboBoxMediaByMonth_MonthTo.DisplayName = ""
            Me.ComboBoxMediaByMonth_MonthTo.DivisionCode = ""
            Me.ComboBoxMediaByMonth_MonthTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMediaByMonth_MonthTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMediaByMonth_MonthTo.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxMediaByMonth_MonthTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMediaByMonth_MonthTo.FocusHighlightEnabled = True
            Me.ComboBoxMediaByMonth_MonthTo.FormattingEnabled = True
            Me.ComboBoxMediaByMonth_MonthTo.ItemHeight = 16
            Me.ComboBoxMediaByMonth_MonthTo.Location = New System.Drawing.Point(184, 24)
            Me.ComboBoxMediaByMonth_MonthTo.Name = "ComboBoxMediaByMonth_MonthTo"
            Me.ComboBoxMediaByMonth_MonthTo.ReadOnly = False
            Me.ComboBoxMediaByMonth_MonthTo.SecurityEnabled = True
            Me.ComboBoxMediaByMonth_MonthTo.Size = New System.Drawing.Size(75, 22)
            Me.ComboBoxMediaByMonth_MonthTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMediaByMonth_MonthTo.TabIndex = 5
            Me.ComboBoxMediaByMonth_MonthTo.TabOnEnter = True
            Me.ComboBoxMediaByMonth_MonthTo.ValueMember = "Key"
            Me.ComboBoxMediaByMonth_MonthTo.WatermarkText = "Select Month"
            '
            'ComboBoxMediaByMonth_MonthFrom
            '
            Me.ComboBoxMediaByMonth_MonthFrom.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMediaByMonth_MonthFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxMediaByMonth_MonthFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMediaByMonth_MonthFrom.AutoFindItemInDataSource = True
            Me.ComboBoxMediaByMonth_MonthFrom.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMediaByMonth_MonthFrom.BookmarkingEnabled = False
            Me.ComboBoxMediaByMonth_MonthFrom.ClientCode = ""
            Me.ComboBoxMediaByMonth_MonthFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Month
            Me.ComboBoxMediaByMonth_MonthFrom.DisableMouseWheel = True
            Me.ComboBoxMediaByMonth_MonthFrom.DisplayMember = "Value"
            Me.ComboBoxMediaByMonth_MonthFrom.DisplayName = ""
            Me.ComboBoxMediaByMonth_MonthFrom.DivisionCode = ""
            Me.ComboBoxMediaByMonth_MonthFrom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMediaByMonth_MonthFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMediaByMonth_MonthFrom.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxMediaByMonth_MonthFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMediaByMonth_MonthFrom.FocusHighlightEnabled = True
            Me.ComboBoxMediaByMonth_MonthFrom.FormattingEnabled = True
            Me.ComboBoxMediaByMonth_MonthFrom.ItemHeight = 16
            Me.ComboBoxMediaByMonth_MonthFrom.Location = New System.Drawing.Point(49, 24)
            Me.ComboBoxMediaByMonth_MonthFrom.Name = "ComboBoxMediaByMonth_MonthFrom"
            Me.ComboBoxMediaByMonth_MonthFrom.ReadOnly = False
            Me.ComboBoxMediaByMonth_MonthFrom.SecurityEnabled = True
            Me.ComboBoxMediaByMonth_MonthFrom.Size = New System.Drawing.Size(75, 22)
            Me.ComboBoxMediaByMonth_MonthFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMediaByMonth_MonthFrom.TabIndex = 3
            Me.ComboBoxMediaByMonth_MonthFrom.TabOnEnter = True
            Me.ComboBoxMediaByMonth_MonthFrom.ValueMember = "Key"
            Me.ComboBoxMediaByMonth_MonthFrom.WatermarkText = "Select Month"
            '
            'LabelMediaByMonth_Range
            '
            Me.LabelMediaByMonth_Range.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaByMonth_Range.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaByMonth_Range.Location = New System.Drawing.Point(5, 24)
            Me.LabelMediaByMonth_Range.Name = "LabelMediaByMonth_Range"
            Me.LabelMediaByMonth_Range.Size = New System.Drawing.Size(38, 20)
            Me.LabelMediaByMonth_Range.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaByMonth_Range.TabIndex = 2
            Me.LabelMediaByMonth_Range.Text = "Range:"
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.DataGridViewRightSection_Selections)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(369, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(868, 691)
            Me.PanelForm_RightSection.TabIndex = 1
            '
            'DataGridViewRightSection_Selections
            '
            Me.DataGridViewRightSection_Selections.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightSection_Selections.AllowDragAndDrop = False
            Me.DataGridViewRightSection_Selections.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_Selections.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_Selections.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_Selections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_Selections.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_Selections.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_Selections.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_Selections.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_Selections.DataSource = Nothing
            Me.DataGridViewRightSection_Selections.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_Selections.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_Selections.ItemDescription = ""
            Me.DataGridViewRightSection_Selections.Location = New System.Drawing.Point(7, 6)
            Me.DataGridViewRightSection_Selections.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewRightSection_Selections.MultiSelect = True
            Me.DataGridViewRightSection_Selections.Name = "DataGridViewRightSection_Selections"
            Me.DataGridViewRightSection_Selections.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_Selections.RunStandardValidation = True
            Me.DataGridViewRightSection_Selections.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightSection_Selections.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_Selections.Size = New System.Drawing.Size(848, 679)
            Me.DataGridViewRightSection_Selections.TabIndex = 0
            Me.DataGridViewRightSection_Selections.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_Selections.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_MediaTypes)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(377, 296)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(689, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 8
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_MediaTypes
            '
            Me.RibbonBarOptions_MediaTypes.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_MediaTypes.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_MediaTypes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_MediaTypes.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_MediaTypes.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_MediaTypes.DragDropSupport = True
            Me.RibbonBarOptions_MediaTypes.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMediaTypes_CheckAll, Me.ButtonItemMediaTypes_UncheckAll})
            Me.RibbonBarOptions_MediaTypes.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_MediaTypes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_MediaTypes.Location = New System.Drawing.Point(462, 0)
            Me.RibbonBarOptions_MediaTypes.Name = "RibbonBarOptions_MediaTypes"
            Me.RibbonBarOptions_MediaTypes.SecurityEnabled = True
            Me.RibbonBarOptions_MediaTypes.Size = New System.Drawing.Size(76, 98)
            Me.RibbonBarOptions_MediaTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_MediaTypes.TabIndex = 38
            Me.RibbonBarOptions_MediaTypes.Text = "Media Types"
            '
            '
            '
            Me.RibbonBarOptions_MediaTypes.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_MediaTypes.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_MediaTypes.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemMediaTypes_CheckAll
            '
            Me.ButtonItemMediaTypes_CheckAll.Name = "ButtonItemMediaTypes_CheckAll"
            Me.ButtonItemMediaTypes_CheckAll.SecurityEnabled = True
            Me.ButtonItemMediaTypes_CheckAll.Stretch = True
            Me.ButtonItemMediaTypes_CheckAll.SubItemsExpandWidth = 14
            Me.ButtonItemMediaTypes_CheckAll.Text = "Check All"
            '
            'ButtonItemMediaTypes_UncheckAll
            '
            Me.ButtonItemMediaTypes_UncheckAll.BeginGroup = True
            Me.ButtonItemMediaTypes_UncheckAll.Name = "ButtonItemMediaTypes_UncheckAll"
            Me.ButtonItemMediaTypes_UncheckAll.SecurityEnabled = True
            Me.ButtonItemMediaTypes_UncheckAll.SubItemsExpandWidth = 14
            Me.ButtonItemMediaTypes_UncheckAll.Text = "Uncheck All"
            '
            'RibbonBarOptions_View
            '
            Me.RibbonBarOptions_View.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_View.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_View.DragDropSupport = True
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_OtherUserSelections, Me.ButtonItemView_ShowDescriptions, Me.ButtonItemView_Review})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(110, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(352, 98)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 36
            Me.RibbonBarOptions_View.Text = "View"
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemView_OtherUserSelections
            '
            Me.ButtonItemView_OtherUserSelections.BeginGroup = True
            Me.ButtonItemView_OtherUserSelections.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_OtherUserSelections.Name = "ButtonItemView_OtherUserSelections"
            Me.ButtonItemView_OtherUserSelections.RibbonWordWrap = False
            Me.ButtonItemView_OtherUserSelections.SecurityEnabled = True
            Me.ButtonItemView_OtherUserSelections.SubItemsExpandWidth = 14
            Me.ButtonItemView_OtherUserSelections.Text = "Other User's Selections"
            '
            'ButtonItemView_ShowDescriptions
            '
            Me.ButtonItemView_ShowDescriptions.AutoCheckOnClick = True
            Me.ButtonItemView_ShowDescriptions.BeginGroup = True
            Me.ButtonItemView_ShowDescriptions.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_ShowDescriptions.Name = "ButtonItemView_ShowDescriptions"
            Me.ButtonItemView_ShowDescriptions.RibbonWordWrap = False
            Me.ButtonItemView_ShowDescriptions.SecurityEnabled = True
            Me.ButtonItemView_ShowDescriptions.SubItemsExpandWidth = 14
            Me.ButtonItemView_ShowDescriptions.Text = "Show Descriptions"
            '
            'ButtonItemView_Review
            '
            Me.ButtonItemView_Review.BeginGroup = True
            Me.ButtonItemView_Review.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_Review.Name = "ButtonItemView_Review"
            Me.ButtonItemView_Review.RibbonWordWrap = False
            Me.ButtonItemView_Review.SecurityEnabled = True
            Me.ButtonItemView_Review.SubItemsExpandWidth = 14
            Me.ButtonItemView_Review.Text = "Review"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(110, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 37
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SecurityEnabled = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SecurityEnabled = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'MediaManagerForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1237, 691)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandablePanelForm_SearchBy)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaManagerForm"
            Me.Text = "Media Manager"
            CType(Me.GroupBoxForm_DateRanges, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_DateRanges.ResumeLayout(False)
            CType(Me.DateTimePickerOrderLine_DateFrom, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerOrderLine_DateTo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_SelectMediaTypes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_SelectMediaTypes.ResumeLayout(False)
            CType(Me.GroupBoxSearch_SelectBy, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxSearch_SelectBy.ResumeLayout(False)
            CType(Me.NumericInputSelectBy_OrderNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_Include, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_Include.ResumeLayout(False)
            CType(Me.GroupBoxForm_JobMediaDateToBillDateRange, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_JobMediaDateToBillDateRange.ResumeLayout(False)
            CType(Me.DateTimePickerJob_DateFrom, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerJob_DateTo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ExpandablePanelForm_SearchBy.ResumeLayout(False)
            CType(Me.SearchableComboBoxForm_FilterBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_MediaByMonth, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_MediaByMonth.ResumeLayout(False)
            CType(Me.NumericInputMediaByMonth_YearTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputMediaByMonth_YearFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents GroupBoxForm_DateRanges As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxForm_SelectMediaTypes As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxSearch_SelectBy As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxForm_Include As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxForm_JobMediaDateToBillDateRange As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewRightSection_Selections As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents NumericInputSelectBy_OrderNumber As WinForm.Presentation.Controls.NumericInput
        Private WithEvents CheckBoxMediaType_Television As WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxMediaType_Radio As WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxMediaType_OutOfHome As WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxMediaType_Magazine As WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxMediaType_Internet As WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxMediaType_Newspaper As WinForm.Presentation.Controls.CheckBox
        Private WithEvents DateTimePickerOrderLine_DateFrom As WinForm.Presentation.Controls.DateTimePicker
        Private WithEvents DateTimePickerOrderLine_DateTo As WinForm.Presentation.Controls.DateTimePicker
        Private WithEvents LabelOrderLineDateRange_To As WinForm.Presentation.Controls.Label
        Private WithEvents RadioButtonSelectBy_AllOpenOrders As WinForm.Presentation.Controls.RadioButtonControl
        Private WithEvents RadioButtonSelectBy_Job As WinForm.Presentation.Controls.RadioButtonControl
        Private WithEvents RadioButtonSelectBy_Campaign As WinForm.Presentation.Controls.RadioButtonControl
        Private WithEvents RadioButtonSelectBy_Client As WinForm.Presentation.Controls.RadioButtonControl
        Private WithEvents RadioButtonSelectBy_OrderStatus As WinForm.Presentation.Controls.RadioButtonControl
        Private WithEvents RadioButtonSelectBy_AccountExecutiveJob As WinForm.Presentation.Controls.RadioButtonControl
        Private WithEvents RadioButtonSelectBy_AccountExecutiveDefault As WinForm.Presentation.Controls.RadioButtonControl
        Private WithEvents DateTimePickerJob_DateFrom As WinForm.Presentation.Controls.DateTimePicker
        Private WithEvents DateTimePickerJob_DateTo As WinForm.Presentation.Controls.DateTimePicker
        Private WithEvents LabelJobMediaDateRange_To As WinForm.Presentation.Controls.Label
        Private WithEvents ExpandablePanelForm_SearchBy As DevComponents.DotNetBar.ExpandablePanel
        Private WithEvents RadioButtonSelectBy_ClientDivisionProduct As WinForm.Presentation.Controls.RadioButtonControl
        Private WithEvents RadioButtonSelectBy_ClientDivision As WinForm.Presentation.Controls.RadioButtonControl
        Private WithEvents LabelOrderLineDateRange_From As WinForm.Presentation.Controls.Label
        Private WithEvents RadioButtonSelectBy_Order As WinForm.Presentation.Controls.RadioButtonControl
        Private WithEvents RadioButtonSelectBy_JobComponent As WinForm.Presentation.Controls.RadioButtonControl
        Private WithEvents LabelJobMediaDateRange_From As WinForm.Presentation.Controls.Label
        Private WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Private WithEvents RibbonBarOptions_View As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemView_ShowDescriptions As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemView_Review As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Save As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RadioButtonInclude_Both As WinForm.Presentation.Controls.RadioButtonControl
        Private WithEvents RadioButtonInclude_QuotesOnly As WinForm.Presentation.Controls.RadioButtonControl
        Private WithEvents RadioButtonInclude_OrdersOnly As WinForm.Presentation.Controls.RadioButtonControl
        Private WithEvents ButtonItemActions_Delete As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemView_OtherUserSelections As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RadioButtonSelectBy_Vendor As WinForm.Presentation.Controls.RadioButtonControl
        Private WithEvents CheckBoxInclude_ClosedOrders As WinForm.Presentation.Controls.CheckBox
        Private WithEvents RibbonBarOptions_MediaTypes As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemMediaTypes_CheckAll As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemMediaTypes_UncheckAll As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RadioButtonSelectBy_LastFour As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TextBoxSelectBy_LastFour As WinForm.Presentation.Controls.TextBox
        Private WithEvents RadioButtonSelectBy_Buyer As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxForm_MediaByMonth As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents NumericInputMediaByMonth_YearTo As WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputMediaByMonth_YearFrom As WinForm.Presentation.Controls.NumericInput
        Friend WithEvents ComboBoxMediaByMonth_MonthTo As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxMediaByMonth_MonthFrom As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelMediaByMonth_Range As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_FilterBy As WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_FilterBy As WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As WinForm.Presentation.Controls.GridView
        Private WithEvents CheckBoxMediaType_PurchaseOrder As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace

