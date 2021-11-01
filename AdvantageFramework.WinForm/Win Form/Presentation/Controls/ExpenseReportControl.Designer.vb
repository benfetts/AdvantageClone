Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ExpenseReportControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.components = New System.ComponentModel.Container()
            Me.TabControlControl_ExpenseReportDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelGeneralTab_General = New DevComponents.DotNetBar.TabControlPanel()
            Me.PictureBoxGeneral_StatusInformation = New System.Windows.Forms.PictureBox()
            Me.SearchableComboBoxGeneral_Employee = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBox1View = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.DateTimePickerGeneral_CreatedDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerGeneral_ReportDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelGeneral_CreatedDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxGeneral_Status = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelGeneral_InvoiceNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneral_Details = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxGeneral_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxGeneral_InvoiceNumber = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelGeneral_Employee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Status = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_ReportDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Details = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemExpenseReportDetails_GeneralTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelLineItemsTab_LineItems = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxLineItems_Summary = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TableLayoutPanelSummary_TableLayout = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelTableLayout_RightColumn = New System.Windows.Forms.Panel()
            Me.LabelLineItems_TotalDueLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelLineItems_TotalDue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelTableLayout_MiddleColumn = New System.Windows.Forms.Panel()
            Me.LabelLineItems_LessCreditCardLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelLineItems_LessCorporateCreditCard = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelTableLayout_LeftColumn = New System.Windows.Forms.Panel()
            Me.LabelLineItems_TotalExpensesLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelLineItems_TotalExpenses = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewLineItems_LineItems = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemExpenseReportDetails_LineItemsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelReceiptsTab_Receipts = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlReceipts_Receipts = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemExpenseReportDetails_ReceiptsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewPaymentHistory_Payments = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemExpenseReportDetails_PaymentHistoryTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.SuperTooltip = New DevComponents.DotNetBar.SuperTooltip()
            CType(Me.TabControlControl_ExpenseReportDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_ExpenseReportDetails.SuspendLayout()
            Me.TabControlPanelGeneralTab_General.SuspendLayout()
            CType(Me.PictureBoxGeneral_StatusInformation, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneral_Employee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerGeneral_CreatedDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerGeneral_ReportDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelLineItemsTab_LineItems.SuspendLayout()
            CType(Me.GroupBoxLineItems_Summary, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxLineItems_Summary.SuspendLayout()
            Me.TableLayoutPanelSummary_TableLayout.SuspendLayout()
            Me.PanelTableLayout_RightColumn.SuspendLayout()
            Me.PanelTableLayout_MiddleColumn.SuspendLayout()
            Me.PanelTableLayout_LeftColumn.SuspendLayout()
            Me.TabControlPanelReceiptsTab_Receipts.SuspendLayout()
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControlControl_ExpenseReportDetails
            '
            Me.TabControlControl_ExpenseReportDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlControl_ExpenseReportDetails.CanReorderTabs = False
            Me.TabControlControl_ExpenseReportDetails.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlControl_ExpenseReportDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlControl_ExpenseReportDetails.Controls.Add(Me.TabControlPanelGeneralTab_General)
            Me.TabControlControl_ExpenseReportDetails.Controls.Add(Me.TabControlPanelLineItemsTab_LineItems)
            Me.TabControlControl_ExpenseReportDetails.Controls.Add(Me.TabControlPanelReceiptsTab_Receipts)
            Me.TabControlControl_ExpenseReportDetails.Controls.Add(Me.TabControlPanelPaymentHistoryTab_PaymentHistory)
            Me.TabControlControl_ExpenseReportDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_ExpenseReportDetails.Location = New System.Drawing.Point(0, 0)
            Me.TabControlControl_ExpenseReportDetails.Name = "TabControlControl_ExpenseReportDetails"
            Me.TabControlControl_ExpenseReportDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_ExpenseReportDetails.SelectedTabIndex = 0
            Me.TabControlControl_ExpenseReportDetails.Size = New System.Drawing.Size(603, 435)
            Me.TabControlControl_ExpenseReportDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_ExpenseReportDetails.TabIndex = 14
            Me.TabControlControl_ExpenseReportDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_ExpenseReportDetails.Tabs.Add(Me.TabItemExpenseReportDetails_GeneralTab)
            Me.TabControlControl_ExpenseReportDetails.Tabs.Add(Me.TabItemExpenseReportDetails_LineItemsTab)
            Me.TabControlControl_ExpenseReportDetails.Tabs.Add(Me.TabItemExpenseReportDetails_ReceiptsTab)
            Me.TabControlControl_ExpenseReportDetails.Tabs.Add(Me.TabItemExpenseReportDetails_PaymentHistoryTab)
            Me.TabControlControl_ExpenseReportDetails.TabStripTabStop = True
            Me.TabControlControl_ExpenseReportDetails.Text = "TabControl1"
            '
            'TabControlPanelGeneralTab_General
            '
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.PictureBoxGeneral_StatusInformation)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.SearchableComboBoxGeneral_Employee)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.DateTimePickerGeneral_CreatedDate)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.DateTimePickerGeneral_ReportDate)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_CreatedDate)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.ComboBoxGeneral_Status)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_InvoiceNumber)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_Details)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_Description)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_InvoiceNumber)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Employee)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Status)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_ReportDate)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Description)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Details)
            Me.TabControlPanelGeneralTab_General.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelGeneralTab_General.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGeneralTab_General.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGeneralTab_General.Name = "TabControlPanelGeneralTab_General"
            Me.TabControlPanelGeneralTab_General.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGeneralTab_General.Size = New System.Drawing.Size(603, 408)
            Me.TabControlPanelGeneralTab_General.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelGeneralTab_General.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneralTab_General.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGeneralTab_General.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGeneralTab_General.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGeneralTab_General.Style.GradientAngle = 90
            Me.TabControlPanelGeneralTab_General.TabIndex = 0
            Me.TabControlPanelGeneralTab_General.TabItem = Me.TabItemExpenseReportDetails_GeneralTab
            '
            'PictureBoxGeneral_StatusInformation
            '
            Me.PictureBoxGeneral_StatusInformation.BackColor = System.Drawing.Color.White
            Me.PictureBoxGeneral_StatusInformation.Location = New System.Drawing.Point(71, 56)
            Me.PictureBoxGeneral_StatusInformation.Name = "PictureBoxGeneral_StatusInformation"
            Me.PictureBoxGeneral_StatusInformation.Size = New System.Drawing.Size(20, 20)
            Me.PictureBoxGeneral_StatusInformation.TabIndex = 14
            Me.PictureBoxGeneral_StatusInformation.TabStop = False
            '
            'SearchableComboBoxGeneral_Employee
            '
            Me.SearchableComboBoxGeneral_Employee.ActiveFilterString = ""
            Me.SearchableComboBoxGeneral_Employee.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneral_Employee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneral_Employee.AutoFillMode = False
            Me.SearchableComboBoxGeneral_Employee.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneral_Employee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxGeneral_Employee.DataSource = Nothing
            Me.SearchableComboBoxGeneral_Employee.DisableMouseWheel = False
            Me.SearchableComboBoxGeneral_Employee.DisplayName = ""
            Me.SearchableComboBoxGeneral_Employee.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneral_Employee.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxGeneral_Employee.Location = New System.Drawing.Point(97, 30)
            Me.SearchableComboBoxGeneral_Employee.Name = "SearchableComboBoxGeneral_Employee"
            Me.SearchableComboBoxGeneral_Employee.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneral_Employee.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneral_Employee.Properties.NullText = "Select Employee"
            Me.SearchableComboBoxGeneral_Employee.Properties.ShowClearButton = False
            Me.SearchableComboBoxGeneral_Employee.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneral_Employee.Properties.View = Me.SearchableComboBox1View
            Me.SearchableComboBoxGeneral_Employee.SecurityEnabled = True
            Me.SearchableComboBoxGeneral_Employee.SelectedValue = Nothing
            Me.SearchableComboBoxGeneral_Employee.Size = New System.Drawing.Size(502, 20)
            Me.SearchableComboBoxGeneral_Employee.TabIndex = 3
            '
            'SearchableComboBox1View
            '
            Me.SearchableComboBox1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBox1View.Name = "SearchableComboBox1View"
            Me.SearchableComboBox1View.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBox1View.OptionsView.ShowGroupPanel = False
            '
            'DateTimePickerGeneral_CreatedDate
            '
            Me.DateTimePickerGeneral_CreatedDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateTimePickerGeneral_CreatedDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerGeneral_CreatedDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerGeneral_CreatedDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_CreatedDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerGeneral_CreatedDate.ButtonDropDown.Visible = True
            Me.DateTimePickerGeneral_CreatedDate.ButtonFreeText.Checked = True
            Me.DateTimePickerGeneral_CreatedDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerGeneral_CreatedDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerGeneral_CreatedDate.DisplayName = ""
            Me.DateTimePickerGeneral_CreatedDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerGeneral_CreatedDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerGeneral_CreatedDate.FocusHighlightEnabled = True
            Me.DateTimePickerGeneral_CreatedDate.FreeTextEntryMode = True
            Me.DateTimePickerGeneral_CreatedDate.IsPopupCalendarOpen = False
            Me.DateTimePickerGeneral_CreatedDate.Location = New System.Drawing.Point(97, 108)
            Me.DateTimePickerGeneral_CreatedDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerGeneral_CreatedDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerGeneral_CreatedDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerGeneral_CreatedDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_CreatedDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerGeneral_CreatedDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerGeneral_CreatedDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerGeneral_CreatedDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_CreatedDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerGeneral_CreatedDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerGeneral_CreatedDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerGeneral_CreatedDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerGeneral_CreatedDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_CreatedDate.MonthCalendar.DisplayMonth = New Date(2013, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerGeneral_CreatedDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerGeneral_CreatedDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_CreatedDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerGeneral_CreatedDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_CreatedDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerGeneral_CreatedDate.Name = "DateTimePickerGeneral_CreatedDate"
            Me.DateTimePickerGeneral_CreatedDate.ReadOnly = False
            Me.DateTimePickerGeneral_CreatedDate.Size = New System.Drawing.Size(502, 20)
            Me.DateTimePickerGeneral_CreatedDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerGeneral_CreatedDate.TabIndex = 9
            Me.DateTimePickerGeneral_CreatedDate.TabOnEnter = True
            Me.DateTimePickerGeneral_CreatedDate.Value = New Date(2017, 9, 7, 14, 59, 17, 951)
            '
            'DateTimePickerGeneral_ReportDate
            '
            Me.DateTimePickerGeneral_ReportDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateTimePickerGeneral_ReportDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerGeneral_ReportDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerGeneral_ReportDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_ReportDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerGeneral_ReportDate.ButtonDropDown.Visible = True
            Me.DateTimePickerGeneral_ReportDate.ButtonFreeText.Checked = True
            Me.DateTimePickerGeneral_ReportDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerGeneral_ReportDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerGeneral_ReportDate.DisplayName = ""
            Me.DateTimePickerGeneral_ReportDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerGeneral_ReportDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerGeneral_ReportDate.FocusHighlightEnabled = True
            Me.DateTimePickerGeneral_ReportDate.FreeTextEntryMode = True
            Me.DateTimePickerGeneral_ReportDate.IsPopupCalendarOpen = False
            Me.DateTimePickerGeneral_ReportDate.Location = New System.Drawing.Point(97, 82)
            Me.DateTimePickerGeneral_ReportDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerGeneral_ReportDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerGeneral_ReportDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerGeneral_ReportDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_ReportDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerGeneral_ReportDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerGeneral_ReportDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerGeneral_ReportDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_ReportDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerGeneral_ReportDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerGeneral_ReportDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerGeneral_ReportDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerGeneral_ReportDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_ReportDate.MonthCalendar.DisplayMonth = New Date(2013, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerGeneral_ReportDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerGeneral_ReportDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_ReportDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerGeneral_ReportDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_ReportDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerGeneral_ReportDate.Name = "DateTimePickerGeneral_ReportDate"
            Me.DateTimePickerGeneral_ReportDate.ReadOnly = False
            Me.DateTimePickerGeneral_ReportDate.Size = New System.Drawing.Size(502, 20)
            Me.DateTimePickerGeneral_ReportDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerGeneral_ReportDate.TabIndex = 7
            Me.DateTimePickerGeneral_ReportDate.TabOnEnter = True
            Me.DateTimePickerGeneral_ReportDate.Value = New Date(2017, 9, 7, 14, 59, 17, 990)
            '
            'LabelGeneral_CreatedDate
            '
            Me.LabelGeneral_CreatedDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_CreatedDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_CreatedDate.Location = New System.Drawing.Point(4, 108)
            Me.LabelGeneral_CreatedDate.Name = "LabelGeneral_CreatedDate"
            Me.LabelGeneral_CreatedDate.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_CreatedDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_CreatedDate.TabIndex = 8
            Me.LabelGeneral_CreatedDate.Text = "Created Date:"
            '
            'ComboBoxGeneral_Status
            '
            Me.ComboBoxGeneral_Status.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneral_Status.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxGeneral_Status.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneral_Status.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneral_Status.AutoFindItemInDataSource = False
            Me.ComboBoxGeneral_Status.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneral_Status.BookmarkingEnabled = False
            Me.ComboBoxGeneral_Status.ClientCode = ""
            Me.ComboBoxGeneral_Status.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Month
            Me.ComboBoxGeneral_Status.DisableMouseWheel = False
            Me.ComboBoxGeneral_Status.DisplayMember = "Value"
            Me.ComboBoxGeneral_Status.DisplayName = ""
            Me.ComboBoxGeneral_Status.DivisionCode = ""
            Me.ComboBoxGeneral_Status.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneral_Status.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxGeneral_Status.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxGeneral_Status.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneral_Status.FocusHighlightEnabled = True
            Me.ComboBoxGeneral_Status.FormattingEnabled = True
            Me.ComboBoxGeneral_Status.ItemHeight = 14
            Me.ComboBoxGeneral_Status.Location = New System.Drawing.Point(97, 56)
            Me.ComboBoxGeneral_Status.Name = "ComboBoxGeneral_Status"
            Me.ComboBoxGeneral_Status.ReadOnly = False
            Me.ComboBoxGeneral_Status.SecurityEnabled = True
            Me.ComboBoxGeneral_Status.Size = New System.Drawing.Size(502, 20)
            Me.ComboBoxGeneral_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneral_Status.TabIndex = 5
            Me.ComboBoxGeneral_Status.TabOnEnter = True
            Me.ComboBoxGeneral_Status.ValueMember = "Key"
            Me.ComboBoxGeneral_Status.WatermarkText = "Select Month"
            '
            'LabelGeneral_InvoiceNumber
            '
            Me.LabelGeneral_InvoiceNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_InvoiceNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_InvoiceNumber.Location = New System.Drawing.Point(4, 4)
            Me.LabelGeneral_InvoiceNumber.Name = "LabelGeneral_InvoiceNumber"
            Me.LabelGeneral_InvoiceNumber.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_InvoiceNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_InvoiceNumber.TabIndex = 0
            Me.LabelGeneral_InvoiceNumber.Text = "Invoice Number:"
            '
            'TextBoxGeneral_Details
            '
            Me.TextBoxGeneral_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxGeneral_Details.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_Details.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_Details.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_Details.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxGeneral_Details.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Details.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Details.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Details.Location = New System.Drawing.Point(97, 160)
            Me.TextBoxGeneral_Details.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Details.Multiline = True
            Me.TextBoxGeneral_Details.Name = "TextBoxGeneral_Details"
            Me.TextBoxGeneral_Details.SecurityEnabled = True
            Me.TextBoxGeneral_Details.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Details.Size = New System.Drawing.Size(502, 244)
            Me.TextBoxGeneral_Details.StartingFolderName = Nothing
            Me.TextBoxGeneral_Details.TabIndex = 13
            Me.TextBoxGeneral_Details.TabOnEnter = True
            '
            'TextBoxGeneral_Description
            '
            Me.TextBoxGeneral_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxGeneral_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_Description.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxGeneral_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Description.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Description.Location = New System.Drawing.Point(97, 134)
            Me.TextBoxGeneral_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Description.Name = "TextBoxGeneral_Description"
            Me.TextBoxGeneral_Description.SecurityEnabled = True
            Me.TextBoxGeneral_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Description.Size = New System.Drawing.Size(502, 20)
            Me.TextBoxGeneral_Description.StartingFolderName = Nothing
            Me.TextBoxGeneral_Description.TabIndex = 11
            Me.TextBoxGeneral_Description.TabOnEnter = True
            '
            'TextBoxGeneral_InvoiceNumber
            '
            Me.TextBoxGeneral_InvoiceNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxGeneral_InvoiceNumber.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_InvoiceNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_InvoiceNumber.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_InvoiceNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_InvoiceNumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxGeneral_InvoiceNumber.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_InvoiceNumber.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_InvoiceNumber.FocusHighlightEnabled = True
            Me.TextBoxGeneral_InvoiceNumber.Location = New System.Drawing.Point(97, 4)
            Me.TextBoxGeneral_InvoiceNumber.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_InvoiceNumber.Name = "TextBoxGeneral_InvoiceNumber"
            Me.TextBoxGeneral_InvoiceNumber.ReadOnly = True
            Me.TextBoxGeneral_InvoiceNumber.SecurityEnabled = True
            Me.TextBoxGeneral_InvoiceNumber.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_InvoiceNumber.Size = New System.Drawing.Size(502, 20)
            Me.TextBoxGeneral_InvoiceNumber.StartingFolderName = Nothing
            Me.TextBoxGeneral_InvoiceNumber.TabIndex = 1
            Me.TextBoxGeneral_InvoiceNumber.TabOnEnter = True
            '
            'LabelGeneral_Employee
            '
            Me.LabelGeneral_Employee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Employee.Location = New System.Drawing.Point(4, 30)
            Me.LabelGeneral_Employee.Name = "LabelGeneral_Employee"
            Me.LabelGeneral_Employee.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Employee.TabIndex = 2
            Me.LabelGeneral_Employee.Text = "Employee:"
            '
            'LabelGeneral_Status
            '
            Me.LabelGeneral_Status.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Status.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Status.Location = New System.Drawing.Point(4, 56)
            Me.LabelGeneral_Status.Name = "LabelGeneral_Status"
            Me.LabelGeneral_Status.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Status.TabIndex = 4
            Me.LabelGeneral_Status.Text = "Status:"
            '
            'LabelGeneral_ReportDate
            '
            Me.LabelGeneral_ReportDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_ReportDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_ReportDate.Location = New System.Drawing.Point(4, 82)
            Me.LabelGeneral_ReportDate.Name = "LabelGeneral_ReportDate"
            Me.LabelGeneral_ReportDate.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_ReportDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_ReportDate.TabIndex = 6
            Me.LabelGeneral_ReportDate.Text = "Report Date:"
            '
            'LabelGeneral_Description
            '
            Me.LabelGeneral_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Description.Location = New System.Drawing.Point(4, 134)
            Me.LabelGeneral_Description.Name = "LabelGeneral_Description"
            Me.LabelGeneral_Description.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Description.TabIndex = 10
            Me.LabelGeneral_Description.Text = "Description:"
            '
            'LabelGeneral_Details
            '
            Me.LabelGeneral_Details.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Details.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Details.Location = New System.Drawing.Point(4, 160)
            Me.LabelGeneral_Details.Name = "LabelGeneral_Details"
            Me.LabelGeneral_Details.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_Details.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Details.TabIndex = 12
            Me.LabelGeneral_Details.Text = "Details:"
            '
            'TabItemExpenseReportDetails_GeneralTab
            '
            Me.TabItemExpenseReportDetails_GeneralTab.AttachedControl = Me.TabControlPanelGeneralTab_General
            Me.TabItemExpenseReportDetails_GeneralTab.Name = "TabItemExpenseReportDetails_GeneralTab"
            Me.TabItemExpenseReportDetails_GeneralTab.Text = "General"
            '
            'TabControlPanelLineItemsTab_LineItems
            '
            Me.TabControlPanelLineItemsTab_LineItems.Controls.Add(Me.GroupBoxLineItems_Summary)
            Me.TabControlPanelLineItemsTab_LineItems.Controls.Add(Me.DataGridViewLineItems_LineItems)
            Me.TabControlPanelLineItemsTab_LineItems.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelLineItemsTab_LineItems.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelLineItemsTab_LineItems.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelLineItemsTab_LineItems.Name = "TabControlPanelLineItemsTab_LineItems"
            Me.TabControlPanelLineItemsTab_LineItems.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelLineItemsTab_LineItems.Size = New System.Drawing.Size(603, 408)
            Me.TabControlPanelLineItemsTab_LineItems.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelLineItemsTab_LineItems.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelLineItemsTab_LineItems.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelLineItemsTab_LineItems.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelLineItemsTab_LineItems.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelLineItemsTab_LineItems.Style.GradientAngle = 90
            Me.TabControlPanelLineItemsTab_LineItems.TabIndex = 1
            Me.TabControlPanelLineItemsTab_LineItems.TabItem = Me.TabItemExpenseReportDetails_LineItemsTab
            '
            'GroupBoxLineItems_Summary
            '
            Me.GroupBoxLineItems_Summary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxLineItems_Summary.Controls.Add(Me.TableLayoutPanelSummary_TableLayout)
            Me.GroupBoxLineItems_Summary.Location = New System.Drawing.Point(4, 4)
            Me.GroupBoxLineItems_Summary.Name = "GroupBoxLineItems_Summary"
            Me.GroupBoxLineItems_Summary.Size = New System.Drawing.Size(595, 52)
            Me.GroupBoxLineItems_Summary.TabIndex = 13
            Me.GroupBoxLineItems_Summary.Text = "Summary"
            '
            'TableLayoutPanelSummary_TableLayout
            '
            Me.TableLayoutPanelSummary_TableLayout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelSummary_TableLayout.ColumnCount = 3
            Me.TableLayoutPanelSummary_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.63683!))
            Me.TableLayoutPanelSummary_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.07057!))
            Me.TableLayoutPanelSummary_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.12048!))
            Me.TableLayoutPanelSummary_TableLayout.Controls.Add(Me.PanelTableLayout_RightColumn, 2, 0)
            Me.TableLayoutPanelSummary_TableLayout.Controls.Add(Me.PanelTableLayout_MiddleColumn, 1, 0)
            Me.TableLayoutPanelSummary_TableLayout.Controls.Add(Me.PanelTableLayout_LeftColumn, 0, 0)
            Me.TableLayoutPanelSummary_TableLayout.Location = New System.Drawing.Point(5, 25)
            Me.TableLayoutPanelSummary_TableLayout.Name = "TableLayoutPanelSummary_TableLayout"
            Me.TableLayoutPanelSummary_TableLayout.RowCount = 1
            Me.TableLayoutPanelSummary_TableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanelSummary_TableLayout.Size = New System.Drawing.Size(585, 20)
            Me.TableLayoutPanelSummary_TableLayout.TabIndex = 0
            '
            'PanelTableLayout_RightColumn
            '
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelLineItems_TotalDueLbl)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelLineItems_TotalDue)
            Me.PanelTableLayout_RightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelTableLayout_RightColumn.Location = New System.Drawing.Point(407, 0)
            Me.PanelTableLayout_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTableLayout_RightColumn.Name = "PanelTableLayout_RightColumn"
            Me.PanelTableLayout_RightColumn.Size = New System.Drawing.Size(178, 20)
            Me.PanelTableLayout_RightColumn.TabIndex = 2
            '
            'LabelLineItems_TotalDueLbl
            '
            Me.LabelLineItems_TotalDueLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLineItems_TotalDueLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLineItems_TotalDueLbl.Location = New System.Drawing.Point(4, 0)
            Me.LabelLineItems_TotalDueLbl.Name = "LabelLineItems_TotalDueLbl"
            Me.LabelLineItems_TotalDueLbl.Size = New System.Drawing.Size(56, 20)
            Me.LabelLineItems_TotalDueLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLineItems_TotalDueLbl.TabIndex = 9
            Me.LabelLineItems_TotalDueLbl.Text = "Total Due:"
            '
            'LabelLineItems_TotalDue
            '
            Me.LabelLineItems_TotalDue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelLineItems_TotalDue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLineItems_TotalDue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLineItems_TotalDue.Location = New System.Drawing.Point(66, 0)
            Me.LabelLineItems_TotalDue.Name = "LabelLineItems_TotalDue"
            Me.LabelLineItems_TotalDue.Size = New System.Drawing.Size(112, 20)
            Me.LabelLineItems_TotalDue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLineItems_TotalDue.TabIndex = 12
            Me.LabelLineItems_TotalDue.Text = "{0}"
            '
            'PanelTableLayout_MiddleColumn
            '
            Me.PanelTableLayout_MiddleColumn.Controls.Add(Me.LabelLineItems_LessCreditCardLbl)
            Me.PanelTableLayout_MiddleColumn.Controls.Add(Me.LabelLineItems_LessCorporateCreditCard)
            Me.PanelTableLayout_MiddleColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelTableLayout_MiddleColumn.Location = New System.Drawing.Point(179, 0)
            Me.PanelTableLayout_MiddleColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTableLayout_MiddleColumn.Name = "PanelTableLayout_MiddleColumn"
            Me.PanelTableLayout_MiddleColumn.Size = New System.Drawing.Size(228, 20)
            Me.PanelTableLayout_MiddleColumn.TabIndex = 1
            '
            'LabelLineItems_LessCreditCardLbl
            '
            Me.LabelLineItems_LessCreditCardLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLineItems_LessCreditCardLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLineItems_LessCreditCardLbl.Location = New System.Drawing.Point(2, 0)
            Me.LabelLineItems_LessCreditCardLbl.Name = "LabelLineItems_LessCreditCardLbl"
            Me.LabelLineItems_LessCreditCardLbl.Size = New System.Drawing.Size(143, 20)
            Me.LabelLineItems_LessCreditCardLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLineItems_LessCreditCardLbl.TabIndex = 8
            Me.LabelLineItems_LessCreditCardLbl.Text = "Less Corporate Credit Card:"
            '
            'LabelLineItems_LessCorporateCreditCard
            '
            Me.LabelLineItems_LessCorporateCreditCard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelLineItems_LessCorporateCreditCard.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLineItems_LessCorporateCreditCard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLineItems_LessCorporateCreditCard.Location = New System.Drawing.Point(151, 0)
            Me.LabelLineItems_LessCorporateCreditCard.Name = "LabelLineItems_LessCorporateCreditCard"
            Me.LabelLineItems_LessCorporateCreditCard.Size = New System.Drawing.Size(75, 20)
            Me.LabelLineItems_LessCorporateCreditCard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLineItems_LessCorporateCreditCard.TabIndex = 11
            Me.LabelLineItems_LessCorporateCreditCard.Text = "{0}"
            '
            'PanelTableLayout_LeftColumn
            '
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelLineItems_TotalExpensesLbl)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelLineItems_TotalExpenses)
            Me.PanelTableLayout_LeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelTableLayout_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelTableLayout_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTableLayout_LeftColumn.Name = "PanelTableLayout_LeftColumn"
            Me.PanelTableLayout_LeftColumn.Size = New System.Drawing.Size(179, 20)
            Me.PanelTableLayout_LeftColumn.TabIndex = 0
            '
            'LabelLineItems_TotalExpensesLbl
            '
            Me.LabelLineItems_TotalExpensesLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLineItems_TotalExpensesLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLineItems_TotalExpensesLbl.Location = New System.Drawing.Point(3, 0)
            Me.LabelLineItems_TotalExpensesLbl.Name = "LabelLineItems_TotalExpensesLbl"
            Me.LabelLineItems_TotalExpensesLbl.Size = New System.Drawing.Size(85, 20)
            Me.LabelLineItems_TotalExpensesLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLineItems_TotalExpensesLbl.TabIndex = 7
            Me.LabelLineItems_TotalExpensesLbl.Text = "Total Expenses:"
            '
            'LabelLineItems_TotalExpenses
            '
            Me.LabelLineItems_TotalExpenses.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelLineItems_TotalExpenses.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLineItems_TotalExpenses.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLineItems_TotalExpenses.Location = New System.Drawing.Point(94, 0)
            Me.LabelLineItems_TotalExpenses.Name = "LabelLineItems_TotalExpenses"
            Me.LabelLineItems_TotalExpenses.Size = New System.Drawing.Size(81, 20)
            Me.LabelLineItems_TotalExpenses.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLineItems_TotalExpenses.TabIndex = 10
            Me.LabelLineItems_TotalExpenses.Text = "{0}"
            '
            'DataGridViewLineItems_LineItems
            '
            Me.DataGridViewLineItems_LineItems.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLineItems_LineItems.AllowDragAndDrop = False
            Me.DataGridViewLineItems_LineItems.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLineItems_LineItems.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLineItems_LineItems.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLineItems_LineItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLineItems_LineItems.AutoFilterLookupColumns = False
            Me.DataGridViewLineItems_LineItems.AutoloadRepositoryDatasource = True
            Me.DataGridViewLineItems_LineItems.AutoUpdateViewCaption = True
            Me.DataGridViewLineItems_LineItems.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewLineItems_LineItems.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLineItems_LineItems.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLineItems_LineItems.ItemDescription = ""
            Me.DataGridViewLineItems_LineItems.Location = New System.Drawing.Point(4, 62)
            Me.DataGridViewLineItems_LineItems.MultiSelect = True
            Me.DataGridViewLineItems_LineItems.Name = "DataGridViewLineItems_LineItems"
            Me.DataGridViewLineItems_LineItems.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewLineItems_LineItems.RunStandardValidation = True
            Me.DataGridViewLineItems_LineItems.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLineItems_LineItems.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLineItems_LineItems.Size = New System.Drawing.Size(595, 342)
            Me.DataGridViewLineItems_LineItems.TabIndex = 0
            Me.DataGridViewLineItems_LineItems.UseEmbeddedNavigator = False
            Me.DataGridViewLineItems_LineItems.ViewCaptionHeight = -1
            '
            'TabItemExpenseReportDetails_LineItemsTab
            '
            Me.TabItemExpenseReportDetails_LineItemsTab.AttachedControl = Me.TabControlPanelLineItemsTab_LineItems
            Me.TabItemExpenseReportDetails_LineItemsTab.Name = "TabItemExpenseReportDetails_LineItemsTab"
            Me.TabItemExpenseReportDetails_LineItemsTab.Text = "Line Items"
            '
            'TabControlPanelReceiptsTab_Receipts
            '
            Me.TabControlPanelReceiptsTab_Receipts.Controls.Add(Me.DocumentManagerControlReceipts_Receipts)
            Me.TabControlPanelReceiptsTab_Receipts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelReceiptsTab_Receipts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelReceiptsTab_Receipts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelReceiptsTab_Receipts.Name = "TabControlPanelReceiptsTab_Receipts"
            Me.TabControlPanelReceiptsTab_Receipts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelReceiptsTab_Receipts.Size = New System.Drawing.Size(603, 408)
            Me.TabControlPanelReceiptsTab_Receipts.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelReceiptsTab_Receipts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelReceiptsTab_Receipts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelReceiptsTab_Receipts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelReceiptsTab_Receipts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelReceiptsTab_Receipts.Style.GradientAngle = 90
            Me.TabControlPanelReceiptsTab_Receipts.TabIndex = 2
            Me.TabControlPanelReceiptsTab_Receipts.TabItem = Me.TabItemExpenseReportDetails_ReceiptsTab
            '
            'DocumentManagerControlReceipts_Receipts
            '
            Me.DocumentManagerControlReceipts_Receipts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlReceipts_Receipts.Location = New System.Drawing.Point(4, 4)
            Me.DocumentManagerControlReceipts_Receipts.Name = "DocumentManagerControlReceipts_Receipts"
            Me.DocumentManagerControlReceipts_Receipts.Size = New System.Drawing.Size(595, 400)
            Me.DocumentManagerControlReceipts_Receipts.TabIndex = 0
            '
            'TabItemExpenseReportDetails_ReceiptsTab
            '
            Me.TabItemExpenseReportDetails_ReceiptsTab.AttachedControl = Me.TabControlPanelReceiptsTab_Receipts
            Me.TabItemExpenseReportDetails_ReceiptsTab.Name = "TabItemExpenseReportDetails_ReceiptsTab"
            Me.TabItemExpenseReportDetails_ReceiptsTab.Text = "Receipts"
            '
            'TabControlPanelPaymentHistoryTab_PaymentHistory
            '
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory.Controls.Add(Me.DataGridViewPaymentHistory_Payments)
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory.Name = "TabControlPanelPaymentHistoryTab_PaymentHistory"
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory.Size = New System.Drawing.Size(603, 408)
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory.Style.GradientAngle = 90
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory.TabIndex = 3
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory.TabItem = Me.TabItemExpenseReportDetails_PaymentHistoryTab
            '
            'DataGridViewPaymentHistory_Payments
            '
            Me.DataGridViewPaymentHistory_Payments.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewPaymentHistory_Payments.AllowDragAndDrop = False
            Me.DataGridViewPaymentHistory_Payments.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewPaymentHistory_Payments.AllowSelectGroupHeaderRow = True
            Me.DataGridViewPaymentHistory_Payments.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewPaymentHistory_Payments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewPaymentHistory_Payments.AutoFilterLookupColumns = False
            Me.DataGridViewPaymentHistory_Payments.AutoloadRepositoryDatasource = True
            Me.DataGridViewPaymentHistory_Payments.AutoUpdateViewCaption = True
            Me.DataGridViewPaymentHistory_Payments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewPaymentHistory_Payments.DataSource = Nothing
            Me.DataGridViewPaymentHistory_Payments.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewPaymentHistory_Payments.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewPaymentHistory_Payments.ItemDescription = "Payment(s)"
            Me.DataGridViewPaymentHistory_Payments.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewPaymentHistory_Payments.MultiSelect = True
            Me.DataGridViewPaymentHistory_Payments.Name = "DataGridViewPaymentHistory_Payments"
            Me.DataGridViewPaymentHistory_Payments.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewPaymentHistory_Payments.RunStandardValidation = True
            Me.DataGridViewPaymentHistory_Payments.ShowColumnMenuOnRightClick = False
            Me.DataGridViewPaymentHistory_Payments.ShowSelectDeselectAllButtons = False
            Me.DataGridViewPaymentHistory_Payments.Size = New System.Drawing.Size(595, 400)
            Me.DataGridViewPaymentHistory_Payments.TabIndex = 0
            Me.DataGridViewPaymentHistory_Payments.UseEmbeddedNavigator = False
            Me.DataGridViewPaymentHistory_Payments.ViewCaptionHeight = -1
            '
            'TabItemExpenseReportDetails_PaymentHistoryTab
            '
            Me.TabItemExpenseReportDetails_PaymentHistoryTab.AttachedControl = Me.TabControlPanelPaymentHistoryTab_PaymentHistory
            Me.TabItemExpenseReportDetails_PaymentHistoryTab.Name = "TabItemExpenseReportDetails_PaymentHistoryTab"
            Me.TabItemExpenseReportDetails_PaymentHistoryTab.Text = "Payment History"
            '
            'SuperTooltip
            '
            Me.SuperTooltip.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
            Me.SuperTooltip.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.SuperTooltip.MaximumWidth = 500
            '
            'ExpenseReportControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlControl_ExpenseReportDetails)
            Me.Name = "ExpenseReportControl"
            Me.Size = New System.Drawing.Size(603, 435)
            CType(Me.TabControlControl_ExpenseReportDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_ExpenseReportDetails.ResumeLayout(False)
            Me.TabControlPanelGeneralTab_General.ResumeLayout(False)
            CType(Me.PictureBoxGeneral_StatusInformation, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneral_Employee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerGeneral_CreatedDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerGeneral_ReportDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelLineItemsTab_LineItems.ResumeLayout(False)
            CType(Me.GroupBoxLineItems_Summary, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxLineItems_Summary.ResumeLayout(False)
            Me.TableLayoutPanelSummary_TableLayout.ResumeLayout(False)
            Me.PanelTableLayout_RightColumn.ResumeLayout(False)
            Me.PanelTableLayout_MiddleColumn.ResumeLayout(False)
            Me.PanelTableLayout_LeftColumn.ResumeLayout(False)
            Me.TabControlPanelReceiptsTab_Receipts.ResumeLayout(False)
            Me.TabControlPanelPaymentHistoryTab_PaymentHistory.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlControl_ExpenseReportDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelGeneralTab_General As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelGeneral_InvoiceNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneral_Details As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxGeneral_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxGeneral_InvoiceNumber As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelGeneral_Employee As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Status As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxGeneral_Status As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelGeneral_ReportDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Details As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemExpenseReportDetails_GeneralTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelLineItemsTab_LineItems As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewLineItems_LineItems As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemExpenseReportDetails_LineItemsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelReceiptsTab_Receipts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemExpenseReportDetails_ReceiptsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelLineItems_TotalDue As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelLineItems_LessCorporateCreditCard As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelLineItems_TotalExpenses As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelLineItems_TotalDueLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelLineItems_LessCreditCardLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelLineItems_TotalExpensesLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxLineItems_Summary As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TableLayoutPanelSummary_TableLayout As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelTableLayout_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelTableLayout_MiddleColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelTableLayout_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents DocumentManagerControlReceipts_Receipts As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents TabControlPanelPaymentHistoryTab_PaymentHistory As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewPaymentHistory_Payments As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemExpenseReportDetails_PaymentHistoryTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelGeneral_CreatedDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerGeneral_ReportDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerGeneral_CreatedDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents SearchableComboBoxGeneral_Employee As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBox1View As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents PictureBoxGeneral_StatusInformation As System.Windows.Forms.PictureBox
        Friend WithEvents SuperTooltip As DevComponents.DotNetBar.SuperTooltip

    End Class

End Namespace
