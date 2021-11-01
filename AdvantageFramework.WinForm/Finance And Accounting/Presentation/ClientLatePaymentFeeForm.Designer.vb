Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ClientLatePaymentFeeForm
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientLatePaymentFeeForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_CreateInvoice = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemCreateInvoice_CheckAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemCreateInvoice_UncheckAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_ShowDescriptions = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Post = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DateTimePickerForm_FeeInvoiceDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_FeeInvoiceDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_AgingDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_PostPeriodCutoff = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DataGridViewForm_LateFees = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.DateTimePickerForm_AgingDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.SearchableComboBoxForm_PostPeriodCutoff = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewControl_InvoiceNumber = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxForm_FeePostPeriod = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelForm_FeePostPeriod = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.DateTimePickerForm_FeeInvoiceDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_AgingDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_PostPeriodCutoff.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewControl_InvoiceNumber, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_FeePostPeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_CreateInvoice)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(93, 397)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(915, 98)
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
            'RibbonBarOptions_CreateInvoice
            '
            Me.RibbonBarOptions_CreateInvoice.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_CreateInvoice.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_CreateInvoice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_CreateInvoice.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_CreateInvoice.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_CreateInvoice.DragDropSupport = True
            Me.RibbonBarOptions_CreateInvoice.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCreateInvoice_CheckAll, Me.ButtonItemCreateInvoice_UncheckAll})
            Me.RibbonBarOptions_CreateInvoice.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_CreateInvoice.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_CreateInvoice.Location = New System.Drawing.Point(223, 0)
            Me.RibbonBarOptions_CreateInvoice.Name = "RibbonBarOptions_CreateInvoice"
            Me.RibbonBarOptions_CreateInvoice.SecurityEnabled = True
            Me.RibbonBarOptions_CreateInvoice.Size = New System.Drawing.Size(103, 98)
            Me.RibbonBarOptions_CreateInvoice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_CreateInvoice.TabIndex = 36
            Me.RibbonBarOptions_CreateInvoice.Text = "Create"
            '
            '
            '
            Me.RibbonBarOptions_CreateInvoice.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_CreateInvoice.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_CreateInvoice.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemCreateInvoice_CheckAll
            '
            Me.ButtonItemCreateInvoice_CheckAll.Name = "ButtonItemCreateInvoice_CheckAll"
            Me.ButtonItemCreateInvoice_CheckAll.SecurityEnabled = True
            Me.ButtonItemCreateInvoice_CheckAll.Stretch = True
            Me.ButtonItemCreateInvoice_CheckAll.SubItemsExpandWidth = 14
            Me.ButtonItemCreateInvoice_CheckAll.Text = "Check All"
            '
            'ButtonItemCreateInvoice_UncheckAll
            '
            Me.ButtonItemCreateInvoice_UncheckAll.BeginGroup = True
            Me.ButtonItemCreateInvoice_UncheckAll.Name = "ButtonItemCreateInvoice_UncheckAll"
            Me.ButtonItemCreateInvoice_UncheckAll.SecurityEnabled = True
            Me.ButtonItemCreateInvoice_UncheckAll.SubItemsExpandWidth = 14
            Me.ButtonItemCreateInvoice_UncheckAll.Text = "Uncheck All"
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
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_ShowDescriptions})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(89, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(134, 98)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 1
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Post})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(89, 98)
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
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActions_Post
            '
            Me.ButtonItemActions_Post.BeginGroup = True
            Me.ButtonItemActions_Post.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Post.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Post.Name = "ButtonItemActions_Post"
            Me.ButtonItemActions_Post.SecurityEnabled = True
            Me.ButtonItemActions_Post.Stretch = True
            Me.ButtonItemActions_Post.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Post.Text = "Post"
            '
            'DateTimePickerForm_FeeInvoiceDate
            '
            Me.DateTimePickerForm_FeeInvoiceDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_FeeInvoiceDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_FeeInvoiceDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_FeeInvoiceDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_FeeInvoiceDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_FeeInvoiceDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_FeeInvoiceDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_FeeInvoiceDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_FeeInvoiceDate.DisplayName = ""
            Me.DateTimePickerForm_FeeInvoiceDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_FeeInvoiceDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_FeeInvoiceDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_FeeInvoiceDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_FeeInvoiceDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_FeeInvoiceDate.Location = New System.Drawing.Point(638, 12)
            Me.DateTimePickerForm_FeeInvoiceDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_FeeInvoiceDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerForm_FeeInvoiceDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerForm_FeeInvoiceDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_FeeInvoiceDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_FeeInvoiceDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_FeeInvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_FeeInvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_FeeInvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_FeeInvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_FeeInvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_FeeInvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_FeeInvoiceDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_FeeInvoiceDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_FeeInvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_FeeInvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_FeeInvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_FeeInvoiceDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_FeeInvoiceDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_FeeInvoiceDate.Name = "DateTimePickerForm_FeeInvoiceDate"
            Me.DateTimePickerForm_FeeInvoiceDate.ReadOnly = False
            Me.DateTimePickerForm_FeeInvoiceDate.Size = New System.Drawing.Size(97, 20)
            Me.DateTimePickerForm_FeeInvoiceDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_FeeInvoiceDate.TabIndex = 8
            Me.DateTimePickerForm_FeeInvoiceDate.TabOnEnter = True
            Me.DateTimePickerForm_FeeInvoiceDate.Value = New Date(2013, 10, 1, 10, 10, 25, 377)
            '
            'LabelForm_FeeInvoiceDate
            '
            Me.LabelForm_FeeInvoiceDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FeeInvoiceDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FeeInvoiceDate.Location = New System.Drawing.Point(538, 12)
            Me.LabelForm_FeeInvoiceDate.Name = "LabelForm_FeeInvoiceDate"
            Me.LabelForm_FeeInvoiceDate.Size = New System.Drawing.Size(94, 20)
            Me.LabelForm_FeeInvoiceDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FeeInvoiceDate.TabIndex = 7
            Me.LabelForm_FeeInvoiceDate.Text = "Fee Invoice Date:"
            '
            'LabelForm_AgingDate
            '
            Me.LabelForm_AgingDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AgingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AgingDate.Location = New System.Drawing.Point(249, 12)
            Me.LabelForm_AgingDate.Name = "LabelForm_AgingDate"
            Me.LabelForm_AgingDate.Size = New System.Drawing.Size(67, 20)
            Me.LabelForm_AgingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AgingDate.TabIndex = 2
            Me.LabelForm_AgingDate.Text = "Aging Date:"
            '
            'LabelForm_PostPeriodCutoff
            '
            Me.LabelForm_PostPeriodCutoff.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostPeriodCutoff.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostPeriodCutoff.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_PostPeriodCutoff.Name = "LabelForm_PostPeriodCutoff"
            Me.LabelForm_PostPeriodCutoff.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_PostPeriodCutoff.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostPeriodCutoff.TabIndex = 0
            Me.LabelForm_PostPeriodCutoff.Text = "Post Period Cutoff:"
            '
            'DataGridViewForm_LateFees
            '
            Me.DataGridViewForm_LateFees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_LateFees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_LateFees.AutoUpdateViewCaption = True
            Me.DataGridViewForm_LateFees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_LateFees.ItemDescription = ""
            Me.DataGridViewForm_LateFees.Location = New System.Drawing.Point(12, 38)
            Me.DataGridViewForm_LateFees.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_LateFees.ModifyGridRowHeight = False
            Me.DataGridViewForm_LateFees.MultiSelect = False
            Me.DataGridViewForm_LateFees.Name = "DataGridViewForm_LateFees"
            Me.DataGridViewForm_LateFees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_LateFees.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_LateFees.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_LateFees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_LateFees.Size = New System.Drawing.Size(1030, 574)
            Me.DataGridViewForm_LateFees.TabIndex = 9
            Me.DataGridViewForm_LateFees.UseEmbeddedNavigator = False
            Me.DataGridViewForm_LateFees.ViewCaptionHeight = -1
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
            Me.DateTimePickerForm_AgingDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_AgingDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_AgingDate.DisplayName = ""
            Me.DateTimePickerForm_AgingDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_AgingDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_AgingDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_AgingDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_AgingDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_AgingDate.Location = New System.Drawing.Point(322, 12)
            Me.DateTimePickerForm_AgingDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_AgingDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
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
            '
            '
            '
            Me.DateTimePickerForm_AgingDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_AgingDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_AgingDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_AgingDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_AgingDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_AgingDate.Name = "DateTimePickerForm_AgingDate"
            Me.DateTimePickerForm_AgingDate.ReadOnly = False
            Me.DateTimePickerForm_AgingDate.Size = New System.Drawing.Size(97, 20)
            Me.DateTimePickerForm_AgingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_AgingDate.TabIndex = 3
            Me.DateTimePickerForm_AgingDate.TabOnEnter = True
            Me.DateTimePickerForm_AgingDate.Value = New Date(2013, 10, 1, 10, 10, 25, 377)
            '
            'SearchableComboBoxForm_PostPeriodCutoff
            '
            Me.SearchableComboBoxForm_PostPeriodCutoff.ActiveFilterString = ""
            Me.SearchableComboBoxForm_PostPeriodCutoff.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_PostPeriodCutoff.AutoFillMode = False
            Me.SearchableComboBoxForm_PostPeriodCutoff.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_PostPeriodCutoff.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.PostPeriod
            Me.SearchableComboBoxForm_PostPeriodCutoff.DataSource = Nothing
            Me.SearchableComboBoxForm_PostPeriodCutoff.DisableMouseWheel = True
            Me.SearchableComboBoxForm_PostPeriodCutoff.DisplayName = ""
            Me.SearchableComboBoxForm_PostPeriodCutoff.EditValue = ""
            Me.SearchableComboBoxForm_PostPeriodCutoff.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_PostPeriodCutoff.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_PostPeriodCutoff.Location = New System.Drawing.Point(124, 12)
            Me.SearchableComboBoxForm_PostPeriodCutoff.Name = "SearchableComboBoxForm_PostPeriodCutoff"
            Me.SearchableComboBoxForm_PostPeriodCutoff.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_PostPeriodCutoff.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_PostPeriodCutoff.Properties.NullText = "Select Post Period"
            Me.SearchableComboBoxForm_PostPeriodCutoff.Properties.PopupView = Me.SearchableComboBoxViewControl_InvoiceNumber
            Me.SearchableComboBoxForm_PostPeriodCutoff.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_PostPeriodCutoff.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_PostPeriodCutoff.SecurityEnabled = True
            Me.SearchableComboBoxForm_PostPeriodCutoff.SelectedValue = ""
            Me.SearchableComboBoxForm_PostPeriodCutoff.Size = New System.Drawing.Size(119, 20)
            Me.SearchableComboBoxForm_PostPeriodCutoff.TabIndex = 1
            '
            'SearchableComboBoxViewControl_InvoiceNumber
            '
            Me.SearchableComboBoxViewControl_InvoiceNumber.AFActiveFilterString = ""
            Me.SearchableComboBoxViewControl_InvoiceNumber.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewControl_InvoiceNumber.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewControl_InvoiceNumber.DataSourceClearing = False
            Me.SearchableComboBoxViewControl_InvoiceNumber.EnableDisabledRows = False
            Me.SearchableComboBoxViewControl_InvoiceNumber.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewControl_InvoiceNumber.Name = "SearchableComboBoxViewControl_InvoiceNumber"
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewControl_InvoiceNumber.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewControl_InvoiceNumber.RunStandardValidation = True
            Me.SearchableComboBoxViewControl_InvoiceNumber.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewControl_InvoiceNumber.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxForm_FeePostPeriod
            '
            Me.SearchableComboBoxForm_FeePostPeriod.ActiveFilterString = ""
            Me.SearchableComboBoxForm_FeePostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_FeePostPeriod.AutoFillMode = False
            Me.SearchableComboBoxForm_FeePostPeriod.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_FeePostPeriod.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.PostPeriod
            Me.SearchableComboBoxForm_FeePostPeriod.DataSource = Nothing
            Me.SearchableComboBoxForm_FeePostPeriod.DisableMouseWheel = True
            Me.SearchableComboBoxForm_FeePostPeriod.DisplayName = ""
            Me.SearchableComboBoxForm_FeePostPeriod.EditValue = ""
            Me.SearchableComboBoxForm_FeePostPeriod.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_FeePostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_FeePostPeriod.Location = New System.Drawing.Point(841, 12)
            Me.SearchableComboBoxForm_FeePostPeriod.Name = "SearchableComboBoxForm_FeePostPeriod"
            Me.SearchableComboBoxForm_FeePostPeriod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_FeePostPeriod.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_FeePostPeriod.Properties.NullText = "Select Post Period"
            Me.SearchableComboBoxForm_FeePostPeriod.Properties.PopupView = Me.GridView1
            Me.SearchableComboBoxForm_FeePostPeriod.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_FeePostPeriod.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_FeePostPeriod.SecurityEnabled = True
            Me.SearchableComboBoxForm_FeePostPeriod.SelectedValue = ""
            Me.SearchableComboBoxForm_FeePostPeriod.Size = New System.Drawing.Size(119, 20)
            Me.SearchableComboBoxForm_FeePostPeriod.TabIndex = 11
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
            Me.GridView1.SkipAddingControlsOnModifyColumn = False
            Me.GridView1.SkipSettingFontOnModifyColumn = False
            '
            'LabelForm_FeePostPeriod
            '
            Me.LabelForm_FeePostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FeePostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FeePostPeriod.Location = New System.Drawing.Point(741, 12)
            Me.LabelForm_FeePostPeriod.Name = "LabelForm_FeePostPeriod"
            Me.LabelForm_FeePostPeriod.Size = New System.Drawing.Size(94, 20)
            Me.LabelForm_FeePostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FeePostPeriod.TabIndex = 10
            Me.LabelForm_FeePostPeriod.Text = "Fee Post Period:"
            '
            'ClientLatePaymentFeeForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1054, 624)
            Me.Controls.Add(Me.SearchableComboBoxForm_FeePostPeriod)
            Me.Controls.Add(Me.LabelForm_FeePostPeriod)
            Me.Controls.Add(Me.SearchableComboBoxForm_PostPeriodCutoff)
            Me.Controls.Add(Me.DateTimePickerForm_AgingDate)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DateTimePickerForm_FeeInvoiceDate)
            Me.Controls.Add(Me.LabelForm_FeeInvoiceDate)
            Me.Controls.Add(Me.LabelForm_AgingDate)
            Me.Controls.Add(Me.LabelForm_PostPeriodCutoff)
            Me.Controls.Add(Me.DataGridViewForm_LateFees)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ClientLatePaymentFeeForm"
            Me.Text = "Client Late Payment Fees"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.DateTimePickerForm_FeeInvoiceDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_AgingDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_PostPeriodCutoff.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewControl_InvoiceNumber, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_FeePostPeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Post As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DateTimePickerForm_FeeInvoiceDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_FeeInvoiceDate As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_AgingDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_PostPeriodCutoff As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_LateFees As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents DateTimePickerForm_AgingDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents SearchableComboBoxForm_PostPeriodCutoff As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewControl_InvoiceNumber As WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxForm_FeePostPeriod As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelForm_FeePostPeriod As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents RibbonBarOptions_View As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemView_ShowDescriptions As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_CreateInvoice As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemCreateInvoice_CheckAll As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemCreateInvoice_UncheckAll As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace