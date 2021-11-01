Namespace Employee.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TimesheetSearchDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimesheetSearchDialog))
            Me.DataGridViewForm_Time = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_Search = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.DateTimePickerSearch_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerSearch_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainer4 = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemSearch_From = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItem2 = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainer5 = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainer6 = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemSearch_To = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemSearch_Show = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ControlContainerItem3 = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemSearch_Search = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Open = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Submit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Unsubmit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ComboBox_ShowTime = New DevComponents.DotNetBar.ComboBoxItem
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarOptions_Search.SuspendLayout()
            CType(Me.DateTimePickerSearch_From, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerSearch_To, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(609, 154)
            Me.RibbonControlForm_MainRibbon.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogAddButton = "&Add >>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCancelButton = "Cancel"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogOkButton = "OK"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogRemoveButton = "&Remove"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Search)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(609, 95)
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Search, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            '
            'RibbonBarFilePanel_System
            '
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 92)
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSystem_Close
            '
            'Me.ButtonItemSystem_Close.Image = AdvantageFramework.My.Resources.ExitImage
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_Time)
            Me.PanelForm_Form.Size = New System.Drawing.Size(609, 298)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 453)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(609, 18)
            '
            'DataGridViewForm_Time
            '
            Me.DataGridViewForm_Time.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Time.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Time.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Time.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Time.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Time.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Time.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Time.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewForm_Time.DataSource = Nothing
            Me.DataGridViewForm_Time.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Time.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Time.ItemDescription = "Item(s)"
            Me.DataGridViewForm_Time.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewForm_Time.MultiSelect = True
            Me.DataGridViewForm_Time.Name = "DataGridViewForm_Time"
            Me.DataGridViewForm_Time.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Time.RunStandardValidation = True
            Me.DataGridViewForm_Time.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Time.Size = New System.Drawing.Size(603, 291)
            Me.DataGridViewForm_Time.TabIndex = 0
            Me.DataGridViewForm_Time.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Time.ViewCaptionHeight = -1
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
            Me.RibbonBarOptions_Search.Controls.Add(Me.DateTimePickerSearch_From)
            Me.RibbonBarOptions_Search.Controls.Add(Me.DateTimePickerSearch_To)
            Me.RibbonBarOptions_Search.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Search.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer3, Me.ButtonItemSearch_Search})
            Me.RibbonBarOptions_Search.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Search.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Search.Name = "RibbonBarOptions_Search"
            Me.RibbonBarOptions_Search.SecurityEnabled = True
            Me.RibbonBarOptions_Search.Size = New System.Drawing.Size(225, 92)
            Me.RibbonBarOptions_Search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Search.TabIndex = 7
            Me.RibbonBarOptions_Search.Text = "Search"
            '
            '
            '
            Me.RibbonBarOptions_Search.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Search.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Search.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'DateTimePickerSearch_From
            '
            Me.DateTimePickerSearch_From.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerSearch_From.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerSearch_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSearch_From.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerSearch_From.ButtonDropDown.Visible = True
            Me.DateTimePickerSearch_From.ButtonFreeText.Checked = True
            Me.DateTimePickerSearch_From.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerSearch_From.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerSearch_From.DisplayName = ""
            Me.DateTimePickerSearch_From.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerSearch_From.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerSearch_From.FocusHighlightEnabled = True
            Me.DateTimePickerSearch_From.FreeTextEntryMode = True
            Me.DateTimePickerSearch_From.IsPopupCalendarOpen = False
            Me.DateTimePickerSearch_From.Location = New System.Drawing.Point(47, 3)
            Me.DateTimePickerSearch_From.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerSearch_From.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerSearch_From.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSearch_From.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerSearch_From.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerSearch_From.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerSearch_From.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerSearch_From.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerSearch_From.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerSearch_From.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerSearch_From.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerSearch_From.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSearch_From.MonthCalendar.DisplayMonth = New Date(2014, 3, 1, 0, 0, 0, 0)
            Me.DateTimePickerSearch_From.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerSearch_From.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerSearch_From.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerSearch_From.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerSearch_From.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerSearch_From.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSearch_From.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerSearch_From.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerSearch_From.Name = "DateTimePickerSearch_From"
            Me.DateTimePickerSearch_From.ReadOnly = False
            Me.DateTimePickerSearch_From.Size = New System.Drawing.Size(115, 20)
            Me.DateTimePickerSearch_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerSearch_From.TabIndex = 1
            Me.DateTimePickerSearch_From.Value = New Date(2014, 3, 17, 14, 41, 29, 975)
            '
            'DateTimePickerSearch_To
            '
            Me.DateTimePickerSearch_To.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerSearch_To.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerSearch_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSearch_To.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerSearch_To.ButtonDropDown.Visible = True
            Me.DateTimePickerSearch_To.ButtonFreeText.Checked = True
            Me.DateTimePickerSearch_To.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerSearch_To.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerSearch_To.DisplayName = ""
            Me.DateTimePickerSearch_To.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerSearch_To.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerSearch_To.FocusHighlightEnabled = True
            Me.DateTimePickerSearch_To.FreeTextEntryMode = True
            Me.DateTimePickerSearch_To.IsPopupCalendarOpen = False
            Me.DateTimePickerSearch_To.Location = New System.Drawing.Point(47, 26)
            Me.DateTimePickerSearch_To.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerSearch_To.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerSearch_To.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSearch_To.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerSearch_To.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerSearch_To.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerSearch_To.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerSearch_To.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerSearch_To.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerSearch_To.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerSearch_To.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerSearch_To.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSearch_To.MonthCalendar.DisplayMonth = New Date(2014, 3, 1, 0, 0, 0, 0)
            Me.DateTimePickerSearch_To.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerSearch_To.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerSearch_To.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerSearch_To.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerSearch_To.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerSearch_To.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSearch_To.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerSearch_To.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerSearch_To.Name = "DateTimePickerSearch_To"
            Me.DateTimePickerSearch_To.ReadOnly = False
            Me.DateTimePickerSearch_To.Size = New System.Drawing.Size(115, 20)
            Me.DateTimePickerSearch_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerSearch_To.TabIndex = 2
            Me.DateTimePickerSearch_To.Value = New Date(2014, 3, 17, 14, 41, 29, 993)
            '
            'ItemContainer3
            '
            '
            '
            '
            Me.ItemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer3.Name = "ItemContainer3"
            Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer4, Me.ItemContainer5, Me.ItemContainer6})
            '
            '
            '
            Me.ItemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainer4
            '
            '
            '
            '
            Me.ItemContainer4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer4.Name = "ItemContainer4"
            Me.ItemContainer4.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemSearch_From, Me.ControlContainerItem2})
            '
            '
            '
            Me.ItemContainer4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemSearch_From
            '
            Me.LabelItemSearch_From.Name = "LabelItemSearch_From"
            Me.LabelItemSearch_From.Text = "From:"
            Me.LabelItemSearch_From.Width = 40
            '
            'ControlContainerItem2
            '
            Me.ControlContainerItem2.AllowItemResize = True
            Me.ControlContainerItem2.Control = Me.DateTimePickerSearch_From
            Me.ControlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItem2.Name = "ControlContainerItem2"
            Me.ControlContainerItem2.Text = "ControlContainerItem2"
            '
            'ItemContainer5
            '
            '
            '
            '
            Me.ItemContainer5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer5.Name = "ItemContainer5"
            Me.ItemContainer5.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemSearch_To, Me.ControlContainerItem1})
            '
            '
            '
            Me.ItemContainer5.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainer6
            '
            '
            '
            '
            Me.ItemContainer6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer6.Name = "ItemContainer6"
            Me.ItemContainer6.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemSearch_Show, Me.ComboBox_ShowTime})
            '
            '
            '
            Me.ItemContainer6.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemSearch_To
            '
            Me.LabelItemSearch_To.Name = "LabelItemSearch_To"
            Me.LabelItemSearch_To.Text = "To:"
            Me.LabelItemSearch_To.Width = 40
            '
            'LabelItemSearch_Show
            '
            Me.LabelItemSearch_Show.Name = "LabelItemSearch_Show"
            Me.LabelItemSearch_Show.Text = "Show:"
            Me.LabelItemSearch_Show.Width = 40
            '
            'ControlContainerItem1
            '
            Me.ControlContainerItem1.AllowItemResize = True
            Me.ControlContainerItem1.Control = Me.DateTimePickerSearch_To
            Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItem1.Name = "ControlContainerItem1"
            Me.ControlContainerItem1.Text = "ControlContainerItem1"
            '
            'ControlContainerItem3
            '
            'Me.ControlContainerItem3.AllowItemResize = True
            'Me.ControlContainerItem3.Control = Me.ComboBox_ShowTime
            'Me.ControlContainerItem3.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            'Me.ControlContainerItem3.Name = "ControlContainerItem3"
            'Me.ControlContainerItem3.Text = "ControlContainerItem3"
            '
            'ComboBox_ShowTime
            '
            Me.ComboBox_ShowTime.ComboWidth = 115
            Me.ComboBox_ShowTime.DropDownHeight = 106
            Me.ComboBox_ShowTime.Name = "ComboBox_ShowTime"
            '
            'ButtonItemSearch_Search
            '
            Me.ButtonItemSearch_Search.BeginGroup = True
            Me.ButtonItemSearch_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSearch_Search.Name = "ButtonItemSearch_Search"
            Me.ButtonItemSearch_Search.RibbonWordWrap = False
            Me.ButtonItemSearch_Search.SecurityEnabled = True
            Me.ButtonItemSearch_Search.SubItemsExpandWidth = 14
            Me.ButtonItemSearch_Search.Text = "Search"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Open, Me.ButtonItemActions_Submit, Me.ButtonItemActions_Unsubmit})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(328, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(154, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 8
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
            'ButtonItemActions_Open
            '
            Me.ButtonItemActions_Open.BeginGroup = True
            Me.ButtonItemActions_Open.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Open.Name = "ButtonItemActions_Open"
            Me.ButtonItemActions_Open.RibbonWordWrap = False
            Me.ButtonItemActions_Open.SecurityEnabled = True
            Me.ButtonItemActions_Open.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Open.Text = "Open"
            '
            'ButtonItemActions_Submit
            '
            Me.ButtonItemActions_Submit.BeginGroup = True
            Me.ButtonItemActions_Submit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Submit.Name = "ButtonItemActions_Submit"
            Me.ButtonItemActions_Submit.RibbonWordWrap = False
            Me.ButtonItemActions_Submit.SecurityEnabled = True
            Me.ButtonItemActions_Submit.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Submit.Text = "Submit"
            '
            'ButtonItemActions_Unsubmit
            '
            Me.ButtonItemActions_Unsubmit.BeginGroup = True
            Me.ButtonItemActions_Unsubmit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Unsubmit.Name = "ButtonItemActions_Unsubmit"
            Me.ButtonItemActions_Unsubmit.RibbonWordWrap = False
            Me.ButtonItemActions_Unsubmit.SecurityEnabled = True
            Me.ButtonItemActions_Unsubmit.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Unsubmit.Text = "Unsubmit"
            '
            'TimesheetSearchDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(619, 473)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "TimesheetSearchDialog"
            Me.Text = "Search"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarOptions_Search.ResumeLayout(False)
            CType(Me.DateTimePickerSearch_From, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerSearch_To, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_Time As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Search As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents DateTimePickerSearch_From As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerSearch_To As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainer4 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSearch_From As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItem2 As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ItemContainer5 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainer6 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSearch_To As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemSearch_Show As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ControlContainerItem3 As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemSearch_Search As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Open As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Submit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Unsubmit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ComboBox_ShowTime As DevComponents.DotNetBar.ComboBoxItem
    End Class

End Namespace