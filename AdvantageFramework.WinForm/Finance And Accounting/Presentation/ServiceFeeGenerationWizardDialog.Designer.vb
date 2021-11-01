Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ServiceFeeGenerationWizardDialog
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServiceFeeGenerationWizardDialog))
            Me.DataGridViewSelectClients_Clients = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.WizardControlForm_Wizard = New DevExpress.XtraWizard.WizardControl()
            Me.WizardPageWizard_SelectClients = New DevExpress.XtraWizard.WizardPage()
            Me.WizardPageWizard_SelectFeeTypes = New DevExpress.XtraWizard.WizardPage()
            Me.DataGridViewSelectFeeTypes_FeeTypes = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.WizardPageWizard_SelectFunctions = New DevExpress.XtraWizard.WizardPage()
            Me.DataGridViewSelectFunctions_Functions = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.WizardPageWizard_SetDateRange = New DevExpress.XtraWizard.WizardPage()
            Me.ButtonSetDateRange_2Years = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonSetDateRange_1Year = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonSetDateRange_MTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonSetDateRange_YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DateTimePickerSetDateRange_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerSetDateRange_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelSetDateRange_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetDateRange_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.WizardPageWizard_GeneratingFees = New DevExpress.XtraWizard.WizardPage()
            Me.ProgressBarGeneratingFees_OverallProgress = New AdvantageFramework.WinForm.Presentation.Controls.ProgressBar()
            Me.LabelGeneratingFees_OverallProgress = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneratingFees_GeneratingFees = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ProgressBarGeneratingFees_FeeProgress = New AdvantageFramework.WinForm.Presentation.Controls.ProgressBar()
            Me.CompletionWizardPageWizard_Complete = New DevExpress.XtraWizard.CompletionWizardPage()
            Me.WizardPageWizard_Review = New DevExpress.XtraWizard.WizardPage()
            Me.LabelReview_NextToContinue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelReview_Header = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TreeListControlReview_ClientsFunctionsServiceFeeTypes = New AdvantageFramework.WinForm.Presentation.Controls.TreeListControl()
            Me.LabelReview_DateRange = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.WizardControlForm_Wizard, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.WizardControlForm_Wizard.SuspendLayout()
            Me.WizardPageWizard_SelectClients.SuspendLayout()
            Me.WizardPageWizard_SelectFeeTypes.SuspendLayout()
            Me.WizardPageWizard_SelectFunctions.SuspendLayout()
            Me.WizardPageWizard_SetDateRange.SuspendLayout()
            CType(Me.DateTimePickerSetDateRange_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerSetDateRange_From, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.WizardPageWizard_GeneratingFees.SuspendLayout()
            Me.WizardPageWizard_Review.SuspendLayout()
            CType(Me.TreeListControlReview_ClientsFunctionsServiceFeeTypes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DataGridViewSelectClients_Clients
            '
            Me.DataGridViewSelectClients_Clients.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectClients_Clients.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectClients_Clients.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectClients_Clients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectClients_Clients.AutoFilterLookupColumns = False
            Me.DataGridViewSelectClients_Clients.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectClients_Clients.AutoUpdateViewCaption = True
            Me.DataGridViewSelectClients_Clients.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectClients_Clients.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectClients_Clients.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectClients_Clients.ItemDescription = "Item(s)"
            Me.DataGridViewSelectClients_Clients.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewSelectClients_Clients.MultiSelect = True
            Me.DataGridViewSelectClients_Clients.Name = "DataGridViewSelectClients_Clients"
            Me.DataGridViewSelectClients_Clients.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectClients_Clients.RunStandardValidation = True
            Me.DataGridViewSelectClients_Clients.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectClients_Clients.Size = New System.Drawing.Size(551, 284)
            Me.DataGridViewSelectClients_Clients.TabIndex = 0
            Me.DataGridViewSelectClients_Clients.UseEmbeddedNavigator = False
            Me.DataGridViewSelectClients_Clients.ViewCaptionHeight = -1
            '
            'WizardControlForm_Wizard
            '
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectClients)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectFeeTypes)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectFunctions)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SetDateRange)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_GeneratingFees)
            Me.WizardControlForm_Wizard.Controls.Add(Me.CompletionWizardPageWizard_Complete)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_Review)
            Me.WizardControlForm_Wizard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.WizardControlForm_Wizard.ImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.WizardControlForm_Wizard.ImageWidth = 200
            Me.WizardControlForm_Wizard.Location = New System.Drawing.Point(0, 0)
            Me.WizardControlForm_Wizard.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.WizardControlForm_Wizard.LookAndFeel.UseDefaultLookAndFeel = False
            Me.WizardControlForm_Wizard.Name = "WizardControlForm_Wizard"
            Me.WizardControlForm_Wizard.NavigationMode = DevExpress.XtraWizard.NavigationMode.Stacked
            Me.WizardControlForm_Wizard.Pages.AddRange(New DevExpress.XtraWizard.BaseWizardPage() {Me.WizardPageWizard_SelectClients, Me.WizardPageWizard_SelectFeeTypes, Me.WizardPageWizard_SelectFunctions, Me.WizardPageWizard_SetDateRange, Me.WizardPageWizard_Review, Me.WizardPageWizard_GeneratingFees, Me.CompletionWizardPageWizard_Complete})
            Me.WizardControlForm_Wizard.ShowHeaderImage = True
            Me.WizardControlForm_Wizard.Size = New System.Drawing.Size(589, 433)
            Me.WizardControlForm_Wizard.Text = ""
            '
            'WizardPageWizard_SelectClients
            '
            Me.WizardPageWizard_SelectClients.Controls.Add(Me.DataGridViewSelectClients_Clients)
            Me.WizardPageWizard_SelectClients.DescriptionText = ""
            Me.WizardPageWizard_SelectClients.Name = "WizardPageWizard_SelectClients"
            Me.WizardPageWizard_SelectClients.Size = New System.Drawing.Size(557, 290)
            Me.WizardPageWizard_SelectClients.Text = "Select Client(s)"
            '
            'WizardPageWizard_SelectFeeTypes
            '
            Me.WizardPageWizard_SelectFeeTypes.AllowDrop = True
            Me.WizardPageWizard_SelectFeeTypes.Controls.Add(Me.DataGridViewSelectFeeTypes_FeeTypes)
            Me.WizardPageWizard_SelectFeeTypes.DescriptionText = ""
            Me.WizardPageWizard_SelectFeeTypes.Name = "WizardPageWizard_SelectFeeTypes"
            Me.WizardPageWizard_SelectFeeTypes.Size = New System.Drawing.Size(557, 290)
            Me.WizardPageWizard_SelectFeeTypes.Text = "Select Fee Type(s)"
            '
            'DataGridViewSelectFeeTypes_FeeTypes
            '
            Me.DataGridViewSelectFeeTypes_FeeTypes.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectFeeTypes_FeeTypes.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectFeeTypes_FeeTypes.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectFeeTypes_FeeTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectFeeTypes_FeeTypes.AutoFilterLookupColumns = False
            Me.DataGridViewSelectFeeTypes_FeeTypes.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectFeeTypes_FeeTypes.AutoUpdateViewCaption = True
            Me.DataGridViewSelectFeeTypes_FeeTypes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectFeeTypes_FeeTypes.DataSource = Nothing
            Me.DataGridViewSelectFeeTypes_FeeTypes.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectFeeTypes_FeeTypes.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectFeeTypes_FeeTypes.ItemDescription = "Item(s)"
            Me.DataGridViewSelectFeeTypes_FeeTypes.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewSelectFeeTypes_FeeTypes.MultiSelect = True
            Me.DataGridViewSelectFeeTypes_FeeTypes.Name = "DataGridViewSelectFeeTypes_FeeTypes"
            Me.DataGridViewSelectFeeTypes_FeeTypes.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectFeeTypes_FeeTypes.RunStandardValidation = True
            Me.DataGridViewSelectFeeTypes_FeeTypes.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectFeeTypes_FeeTypes.Size = New System.Drawing.Size(551, 284)
            Me.DataGridViewSelectFeeTypes_FeeTypes.TabIndex = 1
            Me.DataGridViewSelectFeeTypes_FeeTypes.UseEmbeddedNavigator = False
            Me.DataGridViewSelectFeeTypes_FeeTypes.ViewCaptionHeight = -1
            '
            'WizardPageWizard_SelectFunctions
            '
            Me.WizardPageWizard_SelectFunctions.Controls.Add(Me.DataGridViewSelectFunctions_Functions)
            Me.WizardPageWizard_SelectFunctions.DescriptionText = ""
            Me.WizardPageWizard_SelectFunctions.Name = "WizardPageWizard_SelectFunctions"
            Me.WizardPageWizard_SelectFunctions.Size = New System.Drawing.Size(557, 290)
            Me.WizardPageWizard_SelectFunctions.Text = "Select Function(s)"
            '
            'DataGridViewSelectFunctions_Functions
            '
            Me.DataGridViewSelectFunctions_Functions.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectFunctions_Functions.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectFunctions_Functions.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectFunctions_Functions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectFunctions_Functions.AutoFilterLookupColumns = False
            Me.DataGridViewSelectFunctions_Functions.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectFunctions_Functions.AutoUpdateViewCaption = True
            Me.DataGridViewSelectFunctions_Functions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectFunctions_Functions.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectFunctions_Functions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectFunctions_Functions.ItemDescription = "Item(s)"
            Me.DataGridViewSelectFunctions_Functions.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewSelectFunctions_Functions.MultiSelect = True
            Me.DataGridViewSelectFunctions_Functions.Name = "DataGridViewSelectFunctions_Functions"
            Me.DataGridViewSelectFunctions_Functions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectFunctions_Functions.RunStandardValidation = True
            Me.DataGridViewSelectFunctions_Functions.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectFunctions_Functions.Size = New System.Drawing.Size(551, 284)
            Me.DataGridViewSelectFunctions_Functions.TabIndex = 2
            Me.DataGridViewSelectFunctions_Functions.UseEmbeddedNavigator = False
            Me.DataGridViewSelectFunctions_Functions.ViewCaptionHeight = -1
            '
            'WizardPageWizard_SetDateRange
            '
            Me.WizardPageWizard_SetDateRange.Controls.Add(Me.ButtonSetDateRange_2Years)
            Me.WizardPageWizard_SetDateRange.Controls.Add(Me.ButtonSetDateRange_1Year)
            Me.WizardPageWizard_SetDateRange.Controls.Add(Me.ButtonSetDateRange_MTD)
            Me.WizardPageWizard_SetDateRange.Controls.Add(Me.ButtonSetDateRange_YTD)
            Me.WizardPageWizard_SetDateRange.Controls.Add(Me.DateTimePickerSetDateRange_To)
            Me.WizardPageWizard_SetDateRange.Controls.Add(Me.DateTimePickerSetDateRange_From)
            Me.WizardPageWizard_SetDateRange.Controls.Add(Me.LabelSetDateRange_To)
            Me.WizardPageWizard_SetDateRange.Controls.Add(Me.LabelSetDateRange_From)
            Me.WizardPageWizard_SetDateRange.DescriptionText = ""
            Me.WizardPageWizard_SetDateRange.Name = "WizardPageWizard_SetDateRange"
            Me.WizardPageWizard_SetDateRange.Size = New System.Drawing.Size(557, 290)
            Me.WizardPageWizard_SetDateRange.Text = "Set Date Range"
            '
            'ButtonSetDateRange_2Years
            '
            Me.ButtonSetDateRange_2Years.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSetDateRange_2Years.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSetDateRange_2Years.Location = New System.Drawing.Point(253, 29)
            Me.ButtonSetDateRange_2Years.Name = "ButtonSetDateRange_2Years"
            Me.ButtonSetDateRange_2Years.SecurityEnabled = True
            Me.ButtonSetDateRange_2Years.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSetDateRange_2Years.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSetDateRange_2Years.TabIndex = 7
            Me.ButtonSetDateRange_2Years.Text = "2 Years"
            '
            'ButtonSetDateRange_1Year
            '
            Me.ButtonSetDateRange_1Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSetDateRange_1Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSetDateRange_1Year.Location = New System.Drawing.Point(253, 3)
            Me.ButtonSetDateRange_1Year.Name = "ButtonSetDateRange_1Year"
            Me.ButtonSetDateRange_1Year.SecurityEnabled = True
            Me.ButtonSetDateRange_1Year.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSetDateRange_1Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSetDateRange_1Year.TabIndex = 5
            Me.ButtonSetDateRange_1Year.Text = "1 Year"
            '
            'ButtonSetDateRange_MTD
            '
            Me.ButtonSetDateRange_MTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSetDateRange_MTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSetDateRange_MTD.Location = New System.Drawing.Point(172, 29)
            Me.ButtonSetDateRange_MTD.Name = "ButtonSetDateRange_MTD"
            Me.ButtonSetDateRange_MTD.SecurityEnabled = True
            Me.ButtonSetDateRange_MTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSetDateRange_MTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSetDateRange_MTD.TabIndex = 6
            Me.ButtonSetDateRange_MTD.Text = "MTD"
            '
            'ButtonSetDateRange_YTD
            '
            Me.ButtonSetDateRange_YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSetDateRange_YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSetDateRange_YTD.Location = New System.Drawing.Point(172, 3)
            Me.ButtonSetDateRange_YTD.Name = "ButtonSetDateRange_YTD"
            Me.ButtonSetDateRange_YTD.SecurityEnabled = True
            Me.ButtonSetDateRange_YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSetDateRange_YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSetDateRange_YTD.TabIndex = 4
            Me.ButtonSetDateRange_YTD.Text = "YTD"
            '
            'DateTimePickerSetDateRange_To
            '
            Me.DateTimePickerSetDateRange_To.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerSetDateRange_To.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerSetDateRange_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSetDateRange_To.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerSetDateRange_To.ButtonDropDown.Visible = True
            Me.DateTimePickerSetDateRange_To.ButtonFreeText.Checked = True
            Me.DateTimePickerSetDateRange_To.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerSetDateRange_To.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerSetDateRange_To.DisplayName = ""
            Me.DateTimePickerSetDateRange_To.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerSetDateRange_To.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerSetDateRange_To.FocusHighlightEnabled = True
            Me.DateTimePickerSetDateRange_To.FreeTextEntryMode = True
            Me.DateTimePickerSetDateRange_To.IsPopupCalendarOpen = False
            Me.DateTimePickerSetDateRange_To.Location = New System.Drawing.Point(49, 29)
            Me.DateTimePickerSetDateRange_To.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerSetDateRange_To.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerSetDateRange_To.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerSetDateRange_To.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSetDateRange_To.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerSetDateRange_To.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerSetDateRange_To.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerSetDateRange_To.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerSetDateRange_To.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerSetDateRange_To.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerSetDateRange_To.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerSetDateRange_To.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerSetDateRange_To.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSetDateRange_To.MonthCalendar.DisplayMonth = New Date(2014, 12, 1, 0, 0, 0, 0)
            Me.DateTimePickerSetDateRange_To.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerSetDateRange_To.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerSetDateRange_To.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerSetDateRange_To.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerSetDateRange_To.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerSetDateRange_To.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSetDateRange_To.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerSetDateRange_To.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerSetDateRange_To.Name = "DateTimePickerSetDateRange_To"
            Me.DateTimePickerSetDateRange_To.ReadOnly = False
            Me.DateTimePickerSetDateRange_To.Size = New System.Drawing.Size(117, 20)
            Me.DateTimePickerSetDateRange_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerSetDateRange_To.TabIndex = 3
            Me.DateTimePickerSetDateRange_To.Value = New Date(2014, 12, 2, 10, 1, 54, 427)
            '
            'DateTimePickerSetDateRange_From
            '
            Me.DateTimePickerSetDateRange_From.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerSetDateRange_From.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerSetDateRange_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSetDateRange_From.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerSetDateRange_From.ButtonDropDown.Visible = True
            Me.DateTimePickerSetDateRange_From.ButtonFreeText.Checked = True
            Me.DateTimePickerSetDateRange_From.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerSetDateRange_From.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerSetDateRange_From.DisplayName = ""
            Me.DateTimePickerSetDateRange_From.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerSetDateRange_From.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerSetDateRange_From.FocusHighlightEnabled = True
            Me.DateTimePickerSetDateRange_From.FreeTextEntryMode = True
            Me.DateTimePickerSetDateRange_From.IsPopupCalendarOpen = False
            Me.DateTimePickerSetDateRange_From.Location = New System.Drawing.Point(49, 3)
            Me.DateTimePickerSetDateRange_From.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerSetDateRange_From.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerSetDateRange_From.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerSetDateRange_From.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSetDateRange_From.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerSetDateRange_From.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerSetDateRange_From.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerSetDateRange_From.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerSetDateRange_From.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerSetDateRange_From.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerSetDateRange_From.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerSetDateRange_From.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerSetDateRange_From.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSetDateRange_From.MonthCalendar.DisplayMonth = New Date(2014, 12, 1, 0, 0, 0, 0)
            Me.DateTimePickerSetDateRange_From.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerSetDateRange_From.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerSetDateRange_From.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerSetDateRange_From.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerSetDateRange_From.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerSetDateRange_From.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSetDateRange_From.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerSetDateRange_From.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerSetDateRange_From.Name = "DateTimePickerSetDateRange_From"
            Me.DateTimePickerSetDateRange_From.ReadOnly = False
            Me.DateTimePickerSetDateRange_From.Size = New System.Drawing.Size(117, 20)
            Me.DateTimePickerSetDateRange_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerSetDateRange_From.TabIndex = 1
            Me.DateTimePickerSetDateRange_From.Value = New Date(2014, 12, 2, 10, 1, 54, 443)
            '
            'LabelSetDateRange_To
            '
            Me.LabelSetDateRange_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetDateRange_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetDateRange_To.Location = New System.Drawing.Point(3, 29)
            Me.LabelSetDateRange_To.Name = "LabelSetDateRange_To"
            Me.LabelSetDateRange_To.Size = New System.Drawing.Size(40, 20)
            Me.LabelSetDateRange_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetDateRange_To.TabIndex = 2
            Me.LabelSetDateRange_To.Text = "To:"
            '
            'LabelSetDateRange_From
            '
            Me.LabelSetDateRange_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetDateRange_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetDateRange_From.Location = New System.Drawing.Point(3, 3)
            Me.LabelSetDateRange_From.Name = "LabelSetDateRange_From"
            Me.LabelSetDateRange_From.Size = New System.Drawing.Size(40, 20)
            Me.LabelSetDateRange_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetDateRange_From.TabIndex = 0
            Me.LabelSetDateRange_From.Text = "From:"
            '
            'WizardPageWizard_GeneratingFees
            '
            Me.WizardPageWizard_GeneratingFees.AllowBack = False
            Me.WizardPageWizard_GeneratingFees.AllowCancel = False
            Me.WizardPageWizard_GeneratingFees.Controls.Add(Me.ProgressBarGeneratingFees_OverallProgress)
            Me.WizardPageWizard_GeneratingFees.Controls.Add(Me.LabelGeneratingFees_OverallProgress)
            Me.WizardPageWizard_GeneratingFees.Controls.Add(Me.LabelGeneratingFees_GeneratingFees)
            Me.WizardPageWizard_GeneratingFees.Controls.Add(Me.ProgressBarGeneratingFees_FeeProgress)
            Me.WizardPageWizard_GeneratingFees.DescriptionText = ""
            Me.WizardPageWizard_GeneratingFees.Name = "WizardPageWizard_GeneratingFees"
            Me.WizardPageWizard_GeneratingFees.Size = New System.Drawing.Size(557, 290)
            Me.WizardPageWizard_GeneratingFees.Text = "Generating Fees..."
            '
            'ProgressBarGeneratingFees_OverallProgress
            '
            Me.ProgressBarGeneratingFees_OverallProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.ProgressBarGeneratingFees_OverallProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ProgressBarGeneratingFees_OverallProgress.Location = New System.Drawing.Point(3, 156)
            Me.ProgressBarGeneratingFees_OverallProgress.Name = "ProgressBarGeneratingFees_OverallProgress"
            Me.ProgressBarGeneratingFees_OverallProgress.Size = New System.Drawing.Size(551, 23)
            Me.ProgressBarGeneratingFees_OverallProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ProgressBarGeneratingFees_OverallProgress.TabIndex = 4
            Me.ProgressBarGeneratingFees_OverallProgress.Text = "ProgressBar2"
            '
            'LabelGeneratingFees_OverallProgress
            '
            Me.LabelGeneratingFees_OverallProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneratingFees_OverallProgress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneratingFees_OverallProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneratingFees_OverallProgress.Location = New System.Drawing.Point(3, 130)
            Me.LabelGeneratingFees_OverallProgress.Name = "LabelGeneratingFees_OverallProgress"
            Me.LabelGeneratingFees_OverallProgress.Size = New System.Drawing.Size(551, 20)
            Me.LabelGeneratingFees_OverallProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneratingFees_OverallProgress.TabIndex = 3
            Me.LabelGeneratingFees_OverallProgress.Text = "Overall Progress"
            '
            'LabelGeneratingFees_GeneratingFees
            '
            Me.LabelGeneratingFees_GeneratingFees.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneratingFees_GeneratingFees.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneratingFees_GeneratingFees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneratingFees_GeneratingFees.Location = New System.Drawing.Point(3, 75)
            Me.LabelGeneratingFees_GeneratingFees.Name = "LabelGeneratingFees_GeneratingFees"
            Me.LabelGeneratingFees_GeneratingFees.Size = New System.Drawing.Size(551, 20)
            Me.LabelGeneratingFees_GeneratingFees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneratingFees_GeneratingFees.TabIndex = 2
            Me.LabelGeneratingFees_GeneratingFees.Text = "Generating Fees..."
            '
            'ProgressBarGeneratingFees_FeeProgress
            '
            Me.ProgressBarGeneratingFees_FeeProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.ProgressBarGeneratingFees_FeeProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ProgressBarGeneratingFees_FeeProgress.Location = New System.Drawing.Point(3, 101)
            Me.ProgressBarGeneratingFees_FeeProgress.Name = "ProgressBarGeneratingFees_FeeProgress"
            Me.ProgressBarGeneratingFees_FeeProgress.Size = New System.Drawing.Size(551, 23)
            Me.ProgressBarGeneratingFees_FeeProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ProgressBarGeneratingFees_FeeProgress.TabIndex = 0
            Me.ProgressBarGeneratingFees_FeeProgress.Text = "ProgressBar1"
            '
            'CompletionWizardPageWizard_Complete
            '
            Me.CompletionWizardPageWizard_Complete.AllowBack = False
            Me.CompletionWizardPageWizard_Complete.AllowCancel = False
            Me.CompletionWizardPageWizard_Complete.Name = "CompletionWizardPageWizard_Complete"
            Me.CompletionWizardPageWizard_Complete.Size = New System.Drawing.Size(357, 278)
            Me.CompletionWizardPageWizard_Complete.Text = "Service Fee Generation Wizard Complete"
            '
            'WizardPageWizard_Review
            '
            Me.WizardPageWizard_Review.Controls.Add(Me.LabelReview_NextToContinue)
            Me.WizardPageWizard_Review.Controls.Add(Me.LabelReview_Header)
            Me.WizardPageWizard_Review.Controls.Add(Me.TreeListControlReview_ClientsFunctionsServiceFeeTypes)
            Me.WizardPageWizard_Review.Controls.Add(Me.LabelReview_DateRange)
            Me.WizardPageWizard_Review.DescriptionText = "Please review & confirm your selections."
            Me.WizardPageWizard_Review.Name = "WizardPageWizard_Review"
            Me.WizardPageWizard_Review.Size = New System.Drawing.Size(557, 290)
            Me.WizardPageWizard_Review.Text = "Confirmation"
            '
            'LabelReview_NextToContinue
            '
            Me.LabelReview_NextToContinue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelReview_NextToContinue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelReview_NextToContinue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelReview_NextToContinue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelReview_NextToContinue.Location = New System.Drawing.Point(3, 267)
            Me.LabelReview_NextToContinue.Name = "LabelReview_NextToContinue"
            Me.LabelReview_NextToContinue.Size = New System.Drawing.Size(551, 20)
            Me.LabelReview_NextToContinue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelReview_NextToContinue.TabIndex = 3
            Me.LabelReview_NextToContinue.Text = "Click next to continue..."
            '
            'LabelReview_Header
            '
            Me.LabelReview_Header.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelReview_Header.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelReview_Header.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelReview_Header.Location = New System.Drawing.Point(3, 3)
            Me.LabelReview_Header.Name = "LabelReview_Header"
            Me.LabelReview_Header.Size = New System.Drawing.Size(551, 20)
            Me.LabelReview_Header.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelReview_Header.TabIndex = 0
            Me.LabelReview_Header.Text = "You are about to generate fees for:"
            '
            'TreeListControlReview_ClientsFunctionsServiceFeeTypes
            '
            Me.TreeListControlReview_ClientsFunctionsServiceFeeTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TreeListControlReview_ClientsFunctionsServiceFeeTypes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TreeListControl.Type.[Default]
            Me.TreeListControlReview_ClientsFunctionsServiceFeeTypes.Location = New System.Drawing.Point(3, 29)
            Me.TreeListControlReview_ClientsFunctionsServiceFeeTypes.Name = "TreeListControlReview_ClientsFunctionsServiceFeeTypes"
            Me.TreeListControlReview_ClientsFunctionsServiceFeeTypes.OptionsNavigation.AutoMoveRowFocus = True
            Me.TreeListControlReview_ClientsFunctionsServiceFeeTypes.OptionsBehavior.Editable = False
            Me.TreeListControlReview_ClientsFunctionsServiceFeeTypes.OptionsNavigation.UseTabKey = True
            Me.TreeListControlReview_ClientsFunctionsServiceFeeTypes.Size = New System.Drawing.Size(551, 206)
            Me.TreeListControlReview_ClientsFunctionsServiceFeeTypes.TabIndex = 1
            '
            'LabelReview_DateRange
            '
            Me.LabelReview_DateRange.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelReview_DateRange.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelReview_DateRange.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelReview_DateRange.Location = New System.Drawing.Point(3, 241)
            Me.LabelReview_DateRange.Name = "LabelReview_DateRange"
            Me.LabelReview_DateRange.Size = New System.Drawing.Size(551, 20)
            Me.LabelReview_DateRange.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelReview_DateRange.TabIndex = 2
            Me.LabelReview_DateRange.Text = "From {0} to {1}"
            '
            'ServiceFeeGenerationWizardDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(589, 433)
            Me.Controls.Add(Me.WizardControlForm_Wizard)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ServiceFeeGenerationWizardDialog"
            Me.Text = "Service Fee Generation"
            CType(Me.WizardControlForm_Wizard, System.ComponentModel.ISupportInitialize).EndInit()
            Me.WizardControlForm_Wizard.ResumeLayout(False)
            Me.WizardPageWizard_SelectClients.ResumeLayout(False)
            Me.WizardPageWizard_SelectFeeTypes.ResumeLayout(False)
            Me.WizardPageWizard_SelectFunctions.ResumeLayout(False)
            Me.WizardPageWizard_SetDateRange.ResumeLayout(False)
            CType(Me.DateTimePickerSetDateRange_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerSetDateRange_From, System.ComponentModel.ISupportInitialize).EndInit()
            Me.WizardPageWizard_GeneratingFees.ResumeLayout(False)
            Me.WizardPageWizard_Review.ResumeLayout(False)
            CType(Me.TreeListControlReview_ClientsFunctionsServiceFeeTypes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewSelectClients_Clients As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Protected WithEvents WizardControlForm_Wizard As DevExpress.XtraWizard.WizardControl
        Friend WithEvents WizardPageWizard_SelectClients As DevExpress.XtraWizard.WizardPage
        Friend WithEvents WizardPageWizard_SelectFeeTypes As DevExpress.XtraWizard.WizardPage
        Friend WithEvents DataGridViewSelectFeeTypes_FeeTypes As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents WizardPageWizard_SelectFunctions As DevExpress.XtraWizard.WizardPage
        Friend WithEvents DataGridViewSelectFunctions_Functions As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents WizardPageWizard_SetDateRange As DevExpress.XtraWizard.WizardPage
        Friend WithEvents LabelSetDateRange_To As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetDateRange_From As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerSetDateRange_To As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerSetDateRange_From As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents WizardPageWizard_GeneratingFees As DevExpress.XtraWizard.WizardPage
        Friend WithEvents ProgressBarGeneratingFees_FeeProgress As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar
        Friend WithEvents LabelGeneratingFees_GeneratingFees As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ProgressBarGeneratingFees_OverallProgress As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar
        Friend WithEvents LabelGeneratingFees_OverallProgress As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonSetDateRange_2Years As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonSetDateRange_1Year As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonSetDateRange_MTD As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonSetDateRange_YTD As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CompletionWizardPageWizard_Complete As DevExpress.XtraWizard.CompletionWizardPage
        Friend WithEvents WizardPageWizard_Review As DevExpress.XtraWizard.WizardPage
        Friend WithEvents LabelReview_DateRange As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TreeListControlReview_ClientsFunctionsServiceFeeTypes As AdvantageFramework.WinForm.Presentation.Controls.TreeListControl
        Friend WithEvents LabelReview_NextToContinue As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelReview_Header As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace
