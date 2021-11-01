Namespace Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BillingCommandCenterProductionBillingSelectionDialog
        Inherits WinForm.Presentation.BaseForms.BaseRibbonForm

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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingCommandCenterProductionBillingSelectionDialog))
            Me.RibbonBarOptions_BillingSelectionActions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemBillingSelectionActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemBillingSelectionActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DataGridViewForm_BillingSelection = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_BillingSelection = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.DateTimePickerBS_InvoiceDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ComboBoxBS_PostingPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ItemContainerSelection_Vertical = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerSelection_InvoiceDate = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemSelection_InvoiceDate = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemSelection_InvoiceDate = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerSelection_PostingPeriod = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemSelection_PostingPeriod = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemSelection_PostingPeriod = New DevComponents.DotNetBar.ControlContainerItem()
            Me.LabelItemAdvanceBilling_PercenToBill = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemAdvanceBilling_PercentBilled = New DevComponents.DotNetBar.LabelItem()
            Me.ItemContainerBillingSelectionVertical_Top = New DevComponents.DotNetBar.ItemContainer()
            Me.ControlContainerItemBS_InvoiceDate = New DevComponents.DotNetBar.ControlContainerItem()
            Me.RibbonBarOptions_ProcessInvoices = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemProcessInvoices_Process = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProcessInvoices_CoopSplits = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProcessInvoices_Draft = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProcessInvoices_Assign = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProcessInvoices_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProcessInvoices_Finish = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProcessInvoices_FinishDelete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProcessInvoices_Currency = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarOptions_BillingSelection.SuspendLayout()
            CType(Me.DateTimePickerBS_InvoiceDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(982, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_ProcessInvoices)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_BillingSelection)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_BillingSelectionActions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(982, 94)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_BillingSelectionActions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_BillingSelection, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_ProcessInvoices, 0)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(52, 92)
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
            Me.ButtonItemSystem_Close.Image = CType(resources.GetObject("ButtonItemSystem_Close.Image"), System.Drawing.Image)
            '
            'Office2007StartButtonMainRibbon_Home
            '
            Me.Office2007StartButtonMainRibbon_Home.ImagePaddingVertical = 0
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_BillingSelection)
            Me.PanelForm_Form.Size = New System.Drawing.Size(982, 555)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 710)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(982, 18)
            '
            'RibbonBarOptions_BillingSelectionActions
            '
            Me.RibbonBarOptions_BillingSelectionActions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_BillingSelectionActions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_BillingSelectionActions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_BillingSelectionActions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_BillingSelectionActions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_BillingSelectionActions.DragDropSupport = True
            Me.RibbonBarOptions_BillingSelectionActions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemBillingSelectionActions_Save, Me.ButtonItemBillingSelectionActions_Cancel})
            Me.RibbonBarOptions_BillingSelectionActions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_BillingSelectionActions.Location = New System.Drawing.Point(55, 0)
            Me.RibbonBarOptions_BillingSelectionActions.Name = "RibbonBarOptions_BillingSelectionActions"
            Me.RibbonBarOptions_BillingSelectionActions.SecurityEnabled = True
            Me.RibbonBarOptions_BillingSelectionActions.Size = New System.Drawing.Size(99, 92)
            Me.RibbonBarOptions_BillingSelectionActions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_BillingSelectionActions.TabIndex = 22
            Me.RibbonBarOptions_BillingSelectionActions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_BillingSelectionActions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_BillingSelectionActions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_BillingSelectionActions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemBillingSelectionActions_Save
            '
            Me.ButtonItemBillingSelectionActions_Save.BeginGroup = True
            Me.ButtonItemBillingSelectionActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemBillingSelectionActions_Save.Name = "ButtonItemBillingSelectionActions_Save"
            Me.ButtonItemBillingSelectionActions_Save.RibbonWordWrap = False
            Me.ButtonItemBillingSelectionActions_Save.SecurityEnabled = True
            Me.ButtonItemBillingSelectionActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemBillingSelectionActions_Save.Text = "Save"
            '
            'ButtonItemBillingSelectionActions_Cancel
            '
            Me.ButtonItemBillingSelectionActions_Cancel.BeginGroup = True
            Me.ButtonItemBillingSelectionActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemBillingSelectionActions_Cancel.Name = "ButtonItemBillingSelectionActions_Cancel"
            Me.ButtonItemBillingSelectionActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemBillingSelectionActions_Cancel.SecurityEnabled = True
            Me.ButtonItemBillingSelectionActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemBillingSelectionActions_Cancel.Text = "Cancel"
            '
            'DataGridViewForm_BillingSelection
            '
            Me.DataGridViewForm_BillingSelection.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_BillingSelection.AllowDragAndDrop = False
            Me.DataGridViewForm_BillingSelection.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_BillingSelection.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_BillingSelection.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_BillingSelection.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_BillingSelection.AutoFilterLookupColumns = False
            Me.DataGridViewForm_BillingSelection.AutoloadRepositoryDatasource = False
            Me.DataGridViewForm_BillingSelection.AutoUpdateViewCaption = True
            Me.DataGridViewForm_BillingSelection.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_BillingSelection.DataSource = Nothing
            Me.DataGridViewForm_BillingSelection.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_BillingSelection.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_BillingSelection.ItemDescription = "row(s) Available for Billing Selection"
            Me.DataGridViewForm_BillingSelection.Location = New System.Drawing.Point(4, 5)
            Me.DataGridViewForm_BillingSelection.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewForm_BillingSelection.MultiSelect = True
            Me.DataGridViewForm_BillingSelection.Name = "DataGridViewForm_BillingSelection"
            Me.DataGridViewForm_BillingSelection.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_BillingSelection.RunStandardValidation = True
            Me.DataGridViewForm_BillingSelection.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_BillingSelection.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_BillingSelection.Size = New System.Drawing.Size(974, 546)
            Me.DataGridViewForm_BillingSelection.TabIndex = 2
            Me.DataGridViewForm_BillingSelection.UseEmbeddedNavigator = False
            Me.DataGridViewForm_BillingSelection.ViewCaptionHeight = -1
            '
            'RibbonBarOptions_BillingSelection
            '
            Me.RibbonBarOptions_BillingSelection.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_BillingSelection.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_BillingSelection.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_BillingSelection.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_BillingSelection.Controls.Add(Me.DateTimePickerBS_InvoiceDate)
            Me.RibbonBarOptions_BillingSelection.Controls.Add(Me.ComboBoxBS_PostingPeriod)
            Me.RibbonBarOptions_BillingSelection.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_BillingSelection.DragDropSupport = True
            Me.RibbonBarOptions_BillingSelection.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSelection_Vertical})
            Me.RibbonBarOptions_BillingSelection.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_BillingSelection.Location = New System.Drawing.Point(154, 0)
            Me.RibbonBarOptions_BillingSelection.Name = "RibbonBarOptions_BillingSelection"
            Me.RibbonBarOptions_BillingSelection.SecurityEnabled = True
            Me.RibbonBarOptions_BillingSelection.Size = New System.Drawing.Size(243, 92)
            Me.RibbonBarOptions_BillingSelection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_BillingSelection.TabIndex = 36
            Me.RibbonBarOptions_BillingSelection.Text = "Selection"
            '
            '
            '
            Me.RibbonBarOptions_BillingSelection.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_BillingSelection.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_BillingSelection.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'DateTimePickerBS_InvoiceDate
            '
            Me.DateTimePickerBS_InvoiceDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerBS_InvoiceDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerBS_InvoiceDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerBS_InvoiceDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerBS_InvoiceDate.ButtonDropDown.Visible = True
            Me.DateTimePickerBS_InvoiceDate.ButtonFreeText.Checked = True
            Me.DateTimePickerBS_InvoiceDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerBS_InvoiceDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerBS_InvoiceDate.DisplayName = "Invoice Date"
            Me.DateTimePickerBS_InvoiceDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerBS_InvoiceDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerBS_InvoiceDate.FocusHighlightEnabled = True
            Me.DateTimePickerBS_InvoiceDate.FreeTextEntryMode = True
            Me.DateTimePickerBS_InvoiceDate.IsPopupCalendarOpen = False
            Me.DateTimePickerBS_InvoiceDate.Location = New System.Drawing.Point(87, 3)
            Me.DateTimePickerBS_InvoiceDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerBS_InvoiceDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.DisplayMonth = New Date(2015, 4, 1, 0, 0, 0, 0)
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerBS_InvoiceDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerBS_InvoiceDate.Name = "DateTimePickerBS_InvoiceDate"
            Me.DateTimePickerBS_InvoiceDate.ReadOnly = False
            Me.DateTimePickerBS_InvoiceDate.Size = New System.Drawing.Size(135, 20)
            Me.DateTimePickerBS_InvoiceDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerBS_InvoiceDate.TabIndex = 3
            Me.DateTimePickerBS_InvoiceDate.TabOnEnter = True
            Me.DateTimePickerBS_InvoiceDate.Value = New Date(2015, 4, 14, 15, 49, 38, 0)
            '
            'ComboBoxBS_PostingPeriod
            '
            Me.ComboBoxBS_PostingPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxBS_PostingPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxBS_PostingPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxBS_PostingPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxBS_PostingPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxBS_PostingPeriod.BookmarkingEnabled = False
            Me.ComboBoxBS_PostingPeriod.ClientCode = ""
            Me.ComboBoxBS_PostingPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxBS_PostingPeriod.DisableMouseWheel = False
            Me.ComboBoxBS_PostingPeriod.DisplayMember = "Description"
            Me.ComboBoxBS_PostingPeriod.DisplayName = "Posting Period"
            Me.ComboBoxBS_PostingPeriod.DivisionCode = ""
            Me.ComboBoxBS_PostingPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxBS_PostingPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxBS_PostingPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxBS_PostingPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxBS_PostingPeriod.FocusHighlightEnabled = True
            Me.ComboBoxBS_PostingPeriod.FormattingEnabled = True
            Me.ComboBoxBS_PostingPeriod.ItemHeight = 15
            Me.ComboBoxBS_PostingPeriod.Location = New System.Drawing.Point(87, 25)
            Me.ComboBoxBS_PostingPeriod.Name = "ComboBoxBS_PostingPeriod"
            Me.ComboBoxBS_PostingPeriod.ReadOnly = False
            Me.ComboBoxBS_PostingPeriod.SecurityEnabled = True
            Me.ComboBoxBS_PostingPeriod.Size = New System.Drawing.Size(135, 21)
            Me.ComboBoxBS_PostingPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxBS_PostingPeriod.TabIndex = 5
            Me.ComboBoxBS_PostingPeriod.TabOnEnter = True
            Me.ComboBoxBS_PostingPeriod.ValueMember = "Code"
            Me.ComboBoxBS_PostingPeriod.WatermarkText = "Select Post Period"
            '
            'ItemContainerSelection_Vertical
            '
            '
            '
            '
            Me.ItemContainerSelection_Vertical.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSelection_Vertical.BeginGroup = True
            Me.ItemContainerSelection_Vertical.FixedSize = New System.Drawing.Size(225, 0)
            Me.ItemContainerSelection_Vertical.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSelection_Vertical.Name = "ItemContainerSelection_Vertical"
            Me.ItemContainerSelection_Vertical.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSelection_InvoiceDate, Me.ItemContainerSelection_PostingPeriod})
            '
            '
            '
            Me.ItemContainerSelection_Vertical.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerSelection_InvoiceDate
            '
            '
            '
            '
            Me.ItemContainerSelection_InvoiceDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSelection_InvoiceDate.Name = "ItemContainerSelection_InvoiceDate"
            Me.ItemContainerSelection_InvoiceDate.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemSelection_InvoiceDate, Me.ControlContainerItemSelection_InvoiceDate})
            '
            '
            '
            Me.ItemContainerSelection_InvoiceDate.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemSelection_InvoiceDate
            '
            Me.LabelItemSelection_InvoiceDate.Name = "LabelItemSelection_InvoiceDate"
            Me.LabelItemSelection_InvoiceDate.Text = "Invoice Date:"
            Me.LabelItemSelection_InvoiceDate.Width = 80
            '
            'ControlContainerItemSelection_InvoiceDate
            '
            Me.ControlContainerItemSelection_InvoiceDate.AllowItemResize = True
            Me.ControlContainerItemSelection_InvoiceDate.Control = Me.DateTimePickerBS_InvoiceDate
            Me.ControlContainerItemSelection_InvoiceDate.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemSelection_InvoiceDate.Name = "ControlContainerItemSelection_InvoiceDate"
            Me.ControlContainerItemSelection_InvoiceDate.Text = "ControlContainerItem1"
            '
            'ItemContainerSelection_PostingPeriod
            '
            '
            '
            '
            Me.ItemContainerSelection_PostingPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSelection_PostingPeriod.Name = "ItemContainerSelection_PostingPeriod"
            Me.ItemContainerSelection_PostingPeriod.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemSelection_PostingPeriod, Me.ControlContainerItemSelection_PostingPeriod})
            '
            '
            '
            Me.ItemContainerSelection_PostingPeriod.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemSelection_PostingPeriod
            '
            Me.LabelItemSelection_PostingPeriod.Name = "LabelItemSelection_PostingPeriod"
            Me.LabelItemSelection_PostingPeriod.Text = "Posting Period:"
            Me.LabelItemSelection_PostingPeriod.Width = 80
            '
            'ControlContainerItemSelection_PostingPeriod
            '
            Me.ControlContainerItemSelection_PostingPeriod.AllowItemResize = True
            Me.ControlContainerItemSelection_PostingPeriod.Control = Me.ComboBoxBS_PostingPeriod
            Me.ControlContainerItemSelection_PostingPeriod.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemSelection_PostingPeriod.Name = "ControlContainerItemSelection_PostingPeriod"
            Me.ControlContainerItemSelection_PostingPeriod.Text = "ControlContainerItem2"
            '
            'LabelItemAdvanceBilling_PercenToBill
            '
            Me.LabelItemAdvanceBilling_PercenToBill.Name = "LabelItemAdvanceBilling_PercenToBill"
            Me.LabelItemAdvanceBilling_PercenToBill.Text = "% to Bill:"
            Me.LabelItemAdvanceBilling_PercenToBill.Width = 55
            '
            'LabelItemAdvanceBilling_PercentBilled
            '
            Me.LabelItemAdvanceBilling_PercentBilled.Name = "LabelItemAdvanceBilling_PercentBilled"
            Me.LabelItemAdvanceBilling_PercentBilled.Text = "% Billed:"
            Me.LabelItemAdvanceBilling_PercentBilled.Width = 55
            '
            'ItemContainerBillingSelectionVertical_Top
            '
            '
            '
            '
            Me.ItemContainerBillingSelectionVertical_Top.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerBillingSelectionVertical_Top.Name = "ItemContainerBillingSelectionVertical_Top"
            Me.ItemContainerBillingSelectionVertical_Top.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemAdvanceBilling_PercenToBill, Me.ControlContainerItemBS_InvoiceDate})
            '
            '
            '
            Me.ItemContainerBillingSelectionVertical_Top.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ControlContainerItemBS_InvoiceDate
            '
            Me.ControlContainerItemBS_InvoiceDate.AllowItemResize = True
            Me.ControlContainerItemBS_InvoiceDate.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemBS_InvoiceDate.Name = "ControlContainerItemBS_InvoiceDate"
            Me.ControlContainerItemBS_InvoiceDate.Text = "ControlContainerItem2"
            '
            'RibbonBarOptions_ProcessInvoices
            '
            Me.RibbonBarOptions_ProcessInvoices.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ProcessInvoices.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ProcessInvoices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ProcessInvoices.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ProcessInvoices.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ProcessInvoices.DragDropSupport = True
            Me.RibbonBarOptions_ProcessInvoices.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemProcessInvoices_Process, Me.ButtonItemProcessInvoices_CoopSplits, Me.ButtonItemProcessInvoices_Currency, Me.ButtonItemProcessInvoices_Draft, Me.ButtonItemProcessInvoices_Assign, Me.ButtonItemProcessInvoices_Print, Me.ButtonItemProcessInvoices_Finish, Me.ButtonItemProcessInvoices_FinishDelete})
            Me.RibbonBarOptions_ProcessInvoices.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ProcessInvoices.Location = New System.Drawing.Point(397, 0)
            Me.RibbonBarOptions_ProcessInvoices.Name = "RibbonBarOptions_ProcessInvoices"
            Me.RibbonBarOptions_ProcessInvoices.SecurityEnabled = True
            Me.RibbonBarOptions_ProcessInvoices.Size = New System.Drawing.Size(481, 92)
            Me.RibbonBarOptions_ProcessInvoices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ProcessInvoices.TabIndex = 41
            Me.RibbonBarOptions_ProcessInvoices.Text = "Process Invoices"
            '
            '
            '
            Me.RibbonBarOptions_ProcessInvoices.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ProcessInvoices.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ProcessInvoices.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemProcessInvoices_Process
            '
            Me.ButtonItemProcessInvoices_Process.BeginGroup = True
            Me.ButtonItemProcessInvoices_Process.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessInvoices_Process.Name = "ButtonItemProcessInvoices_Process"
            Me.ButtonItemProcessInvoices_Process.RibbonWordWrap = False
            Me.ButtonItemProcessInvoices_Process.SecurityEnabled = True
            Me.ButtonItemProcessInvoices_Process.SubItemsExpandWidth = 14
            Me.ButtonItemProcessInvoices_Process.Text = "Process"
            '
            'ButtonItemProcessInvoices_CoopSplits
            '
            Me.ButtonItemProcessInvoices_CoopSplits.BeginGroup = True
            Me.ButtonItemProcessInvoices_CoopSplits.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessInvoices_CoopSplits.Name = "ButtonItemProcessInvoices_CoopSplits"
            Me.ButtonItemProcessInvoices_CoopSplits.RibbonWordWrap = False
            Me.ButtonItemProcessInvoices_CoopSplits.SecurityEnabled = True
            Me.ButtonItemProcessInvoices_CoopSplits.SubItemsExpandWidth = 14
            Me.ButtonItemProcessInvoices_CoopSplits.Text = "Co-op Distribution"
            '
            'ButtonItemProcessInvoices_Draft
            '
            Me.ButtonItemProcessInvoices_Draft.BeginGroup = True
            Me.ButtonItemProcessInvoices_Draft.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessInvoices_Draft.Name = "ButtonItemProcessInvoices_Draft"
            Me.ButtonItemProcessInvoices_Draft.RibbonWordWrap = False
            Me.ButtonItemProcessInvoices_Draft.SecurityEnabled = True
            Me.ButtonItemProcessInvoices_Draft.SubItemsExpandWidth = 14
            Me.ButtonItemProcessInvoices_Draft.Text = "Draft"
            '
            'ButtonItemProcessInvoices_Assign
            '
            Me.ButtonItemProcessInvoices_Assign.BeginGroup = True
            Me.ButtonItemProcessInvoices_Assign.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessInvoices_Assign.Name = "ButtonItemProcessInvoices_Assign"
            Me.ButtonItemProcessInvoices_Assign.RibbonWordWrap = False
            Me.ButtonItemProcessInvoices_Assign.SecurityEnabled = True
            Me.ButtonItemProcessInvoices_Assign.SubItemsExpandWidth = 14
            Me.ButtonItemProcessInvoices_Assign.Text = "Assign"
            '
            'ButtonItemProcessInvoices_Print
            '
            Me.ButtonItemProcessInvoices_Print.BeginGroup = True
            Me.ButtonItemProcessInvoices_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessInvoices_Print.Name = "ButtonItemProcessInvoices_Print"
            Me.ButtonItemProcessInvoices_Print.RibbonWordWrap = False
            Me.ButtonItemProcessInvoices_Print.SecurityEnabled = True
            Me.ButtonItemProcessInvoices_Print.SubItemsExpandWidth = 14
            Me.ButtonItemProcessInvoices_Print.Text = "Print"
            '
            'ButtonItemProcessInvoices_Finish
            '
            Me.ButtonItemProcessInvoices_Finish.BeginGroup = True
            Me.ButtonItemProcessInvoices_Finish.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessInvoices_Finish.Name = "ButtonItemProcessInvoices_Finish"
            Me.ButtonItemProcessInvoices_Finish.RibbonWordWrap = False
            Me.ButtonItemProcessInvoices_Finish.SecurityEnabled = True
            Me.ButtonItemProcessInvoices_Finish.SubItemsExpandWidth = 14
            Me.ButtonItemProcessInvoices_Finish.Text = "Finish"
            '
            'ButtonItemProcessInvoices_FinishDelete
            '
            Me.ButtonItemProcessInvoices_FinishDelete.BeginGroup = True
            Me.ButtonItemProcessInvoices_FinishDelete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessInvoices_FinishDelete.Name = "ButtonItemProcessInvoices_FinishDelete"
            Me.ButtonItemProcessInvoices_FinishDelete.RibbonWordWrap = False
            Me.ButtonItemProcessInvoices_FinishDelete.SecurityEnabled = True
            Me.ButtonItemProcessInvoices_FinishDelete.SubItemsExpandWidth = 14
            Me.ButtonItemProcessInvoices_FinishDelete.Text = "Finish && Delete"
            '
            'ButtonItemProcessInvoices_Currency
            '
            Me.ButtonItemProcessInvoices_Currency.BeginGroup = True
            Me.ButtonItemProcessInvoices_Currency.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessInvoices_Currency.Name = "ButtonItemProcessInvoices_Currency"
            Me.ButtonItemProcessInvoices_Currency.RibbonWordWrap = False
            Me.ButtonItemProcessInvoices_Currency.SecurityEnabled = True
            Me.ButtonItemProcessInvoices_Currency.SubItemsExpandWidth = 14
            Me.ButtonItemProcessInvoices_Currency.Text = "Currency"
            '
            'BillingCommandCenterProductionBillingSelectionDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillingCommandCenterProductionBillingSelectionDialog"
            Me.Text = "Billing Command Center Production Billing Selection"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarOptions_BillingSelection.ResumeLayout(False)
            CType(Me.DateTimePickerBS_InvoiceDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_BillingSelectionActions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemBillingSelectionActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemBillingSelectionActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewForm_BillingSelection As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_BillingSelection As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerBillingSelectionVertical_Top As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ControlContainerItemBS_InvoiceDate As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ComboBoxBS_PostingPeriod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelItemAdvanceBilling_PercenToBill As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemAdvanceBilling_PercentBilled As DevComponents.DotNetBar.LabelItem
        Friend WithEvents DateTimePickerBS_InvoiceDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents ItemContainerSelection_Vertical As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerSelection_InvoiceDate As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSelection_InvoiceDate As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemSelection_InvoiceDate As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ItemContainerSelection_PostingPeriod As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSelection_PostingPeriod As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemSelection_PostingPeriod As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents RibbonBarOptions_ProcessInvoices As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemProcessInvoices_Process As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProcessInvoices_CoopSplits As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProcessInvoices_Draft As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProcessInvoices_Assign As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProcessInvoices_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProcessInvoices_Finish As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProcessInvoices_FinishDelete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProcessInvoices_Currency As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace