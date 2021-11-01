Namespace Billing.Reports.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class InvoicePrintingQuickSelectionDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvoicePrintingQuickSelectionDialog))
            Me.DataGridViewForm_Invoices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ContextMenuBarForm_Invoices = New DevComponents.DotNetBar.ContextMenuBar()
            Me.ButtonItemCM_Invoices = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemInovices_SetInvoiceCategory = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Select = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Search = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.DateTimePickerDates_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerDates_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ItemContainerSeach_Production = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemSearch_Production = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerSeach_MediaGroup1 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemSearch_Magazine = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemSearch_Newspaper = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemSearch_Internet = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerSeach_MediaGroup2 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemSearch_OutOfHome = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemSearch_Radio = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemSearch_TV = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerSearch_Spacer = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemSpacer_Spacer = New DevComponents.DotNetBar.LabelItem()
            Me.ItemContainerDates_Dates = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerDates_Top = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemDates_From = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemDates_From = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemDates_YTD = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDates_1Year = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerDates_Bottom = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemDates_To = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemDates_To = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemDates_MTD = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDates_2Years = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemSearch_Search = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemSearch_DraftInvoices = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ContextMenuBarForm_Invoices, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarOptions_Search.SuspendLayout()
            CType(Me.DateTimePickerDates_From, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerDates_To, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Search)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Search, 0)
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
            Me.ButtonItemSystem_Close.Image = CType(resources.GetObject("ButtonItemSystem_Close.Image"), System.Drawing.Image)
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.ContextMenuBarForm_Invoices)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_Invoices)
            Me.PanelForm_Form.Size = New System.Drawing.Size(982, 555)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 710)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(982, 18)
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
            Me.DataGridViewForm_Invoices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_Invoices.DataSource = Nothing
            Me.DataGridViewForm_Invoices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Invoices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
            Me.DataGridViewForm_Invoices.ItemDescription = "Invoice(s)"
            Me.DataGridViewForm_Invoices.Location = New System.Drawing.Point(15, 11)
            Me.DataGridViewForm_Invoices.MultiSelect = True
            Me.DataGridViewForm_Invoices.Name = "DataGridViewForm_Invoices"
            Me.DataGridViewForm_Invoices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Invoices.RunStandardValidation = True
            Me.DataGridViewForm_Invoices.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Invoices.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Invoices.Size = New System.Drawing.Size(951, 533)
            Me.DataGridViewForm_Invoices.TabIndex = 4
            Me.DataGridViewForm_Invoices.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Invoices.ViewCaptionHeight = -1
            '
            'ContextMenuBarForm_Invoices
            '
            Me.ContextMenuBarForm_Invoices.AntiAlias = True
            Me.ContextMenuBarForm_Invoices.DockSide = DevComponents.DotNetBar.eDockSide.Document
            Me.ContextMenuBarForm_Invoices.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.ContextMenuBarForm_Invoices.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCM_Invoices})
            Me.ContextMenuBarForm_Invoices.Location = New System.Drawing.Point(1072, 168)
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
            Me.ButtonItemCM_Invoices.SecurityEnabled = True
            Me.ButtonItemCM_Invoices.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemInovices_SetInvoiceCategory})
            Me.ButtonItemCM_Invoices.Text = "CM"
            '
            'ButtonItemInovices_SetInvoiceCategory
            '
            Me.ButtonItemInovices_SetInvoiceCategory.Name = "ButtonItemInovices_SetInvoiceCategory"
            Me.ButtonItemInovices_SetInvoiceCategory.SecurityEnabled = True
            Me.ButtonItemInovices_SetInvoiceCategory.Text = "Set Invoice Category"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Select, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(95, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 1
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
            'ButtonItemActions_Select
            '
            Me.ButtonItemActions_Select.BeginGroup = True
            Me.ButtonItemActions_Select.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Select.Name = "ButtonItemActions_Select"
            Me.ButtonItemActions_Select.RibbonWordWrap = False
            Me.ButtonItemActions_Select.SecurityEnabled = True
            Me.ButtonItemActions_Select.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Select.Text = "Select"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SecurityEnabled = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
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
            Me.RibbonBarOptions_Search.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSeach_Production, Me.ItemContainerSeach_MediaGroup1, Me.ItemContainerSeach_MediaGroup2, Me.ItemContainerSearch_Spacer, Me.ItemContainerDates_Dates, Me.ButtonItemSearch_Search, Me.ButtonItemSearch_DraftInvoices})
            Me.RibbonBarOptions_Search.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Search.Location = New System.Drawing.Point(198, 0)
            Me.RibbonBarOptions_Search.Name = "RibbonBarOptions_Search"
            Me.RibbonBarOptions_Search.SecurityEnabled = True
            Me.RibbonBarOptions_Search.Size = New System.Drawing.Size(534, 92)
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
            Me.DateTimePickerDates_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
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
            Me.DateTimePickerDates_From.Location = New System.Drawing.Point(254, 16)
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
            '
            '
            '
            Me.DateTimePickerDates_From.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_From.MonthCalendar.DisplayMonth = New Date(2015, 9, 1, 0, 0, 0, 0)
            Me.DateTimePickerDates_From.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerDates_From.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDates_From.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_From.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerDates_From.Name = "DateTimePickerDates_From"
            Me.DateTimePickerDates_From.ReadOnly = False
            Me.DateTimePickerDates_From.Size = New System.Drawing.Size(85, 20)
            Me.DateTimePickerDates_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDates_From.TabIndex = 0
            Me.DateTimePickerDates_From.TabOnEnter = True
            Me.DateTimePickerDates_From.Value = New Date(2015, 9, 11, 15, 5, 57, 150)
            '
            'DateTimePickerDates_To
            '
            Me.DateTimePickerDates_To.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerDates_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
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
            Me.DateTimePickerDates_To.Location = New System.Drawing.Point(254, 39)
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
            '
            '
            '
            Me.DateTimePickerDates_To.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_To.MonthCalendar.DisplayMonth = New Date(2015, 9, 1, 0, 0, 0, 0)
            Me.DateTimePickerDates_To.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerDates_To.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDates_To.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_To.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerDates_To.Name = "DateTimePickerDates_To"
            Me.DateTimePickerDates_To.ReadOnly = False
            Me.DateTimePickerDates_To.Size = New System.Drawing.Size(85, 20)
            Me.DateTimePickerDates_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDates_To.TabIndex = 1
            Me.DateTimePickerDates_To.TabOnEnter = True
            Me.DateTimePickerDates_To.Value = New Date(2015, 9, 11, 15, 5, 57, 181)
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
            Me.ItemContainerSeach_Production.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSeach_Production.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemSearch_Production
            '
            Me.ButtonItemSearch_Production.AutoCheckOnClick = True
            Me.ButtonItemSearch_Production.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_Production.Checked = True
            Me.ButtonItemSearch_Production.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSearch_Production.Name = "ButtonItemSearch_Production"
            Me.ButtonItemSearch_Production.RibbonWordWrap = False
            Me.ButtonItemSearch_Production.SecurityEnabled = True
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
            Me.ItemContainerSeach_MediaGroup1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSeach_MediaGroup1.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemSearch_Magazine
            '
            Me.ButtonItemSearch_Magazine.AutoCheckOnClick = True
            Me.ButtonItemSearch_Magazine.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_Magazine.Checked = True
            Me.ButtonItemSearch_Magazine.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemSearch_Magazine.Name = "ButtonItemSearch_Magazine"
            Me.ButtonItemSearch_Magazine.RibbonWordWrap = False
            Me.ButtonItemSearch_Magazine.SecurityEnabled = True
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
            Me.ButtonItemSearch_Newspaper.SecurityEnabled = True
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
            Me.ButtonItemSearch_Internet.SecurityEnabled = True
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
            Me.ItemContainerSeach_MediaGroup2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSeach_MediaGroup2.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemSearch_OutOfHome
            '
            Me.ButtonItemSearch_OutOfHome.AutoCheckOnClick = True
            Me.ButtonItemSearch_OutOfHome.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_OutOfHome.Checked = True
            Me.ButtonItemSearch_OutOfHome.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemSearch_OutOfHome.Name = "ButtonItemSearch_OutOfHome"
            Me.ButtonItemSearch_OutOfHome.RibbonWordWrap = False
            Me.ButtonItemSearch_OutOfHome.SecurityEnabled = True
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
            Me.ButtonItemSearch_Radio.SecurityEnabled = True
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
            Me.ButtonItemSearch_TV.SecurityEnabled = True
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
            Me.ButtonItemDates_YTD.SecurityEnabled = True
            Me.ButtonItemDates_YTD.Text = "YTD"
            '
            'ButtonItemDates_1Year
            '
            Me.ButtonItemDates_1Year.BeginGroup = True
            Me.ButtonItemDates_1Year.Name = "ButtonItemDates_1Year"
            Me.ButtonItemDates_1Year.SecurityEnabled = True
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
            Me.ButtonItemDates_MTD.SecurityEnabled = True
            Me.ButtonItemDates_MTD.Text = "MTD"
            '
            'ButtonItemDates_2Years
            '
            Me.ButtonItemDates_2Years.BeginGroup = True
            Me.ButtonItemDates_2Years.Name = "ButtonItemDates_2Years"
            Me.ButtonItemDates_2Years.SecurityEnabled = True
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
            'InvoicePrintingQuickSelectionDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "InvoicePrintingQuickSelectionDialog"
            Me.Text = "Invoice Printing"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ContextMenuBarForm_Invoices, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarOptions_Search.ResumeLayout(False)
            CType(Me.DateTimePickerDates_From, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerDates_To, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_Invoices As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ContextMenuBarForm_Invoices As DevComponents.DotNetBar.ContextMenuBar
        Friend WithEvents ButtonItemCM_Invoices As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemInovices_SetInvoiceCategory As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Search As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents DateTimePickerDates_From As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerDates_To As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents ItemContainerSeach_Production As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemSearch_Production As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerSeach_MediaGroup1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemSearch_Magazine As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSearch_Newspaper As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSearch_Internet As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerSeach_MediaGroup2 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemSearch_OutOfHome As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSearch_Radio As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSearch_TV As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerSearch_Spacer As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSpacer_Spacer As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ItemContainerDates_Dates As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerDates_Top As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemDates_From As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemDates_From As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemDates_YTD As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDates_1Year As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerDates_Bottom As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemDates_To As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemDates_To As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemDates_MTD As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDates_2Years As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSearch_Search As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSearch_DraftInvoices As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Select As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace

