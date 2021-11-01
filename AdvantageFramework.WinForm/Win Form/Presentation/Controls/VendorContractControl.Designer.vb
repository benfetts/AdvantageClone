Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class VendorContractControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VendorContractControl))
            Me.TabControlControl_ContractSetup = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelDocumentsTab_Documents = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlDocuments_VendorContractDocuments = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemContractSetup_DocumentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelGeneral_General = New DevComponents.DotNetBar.TabControlPanel()
            Me.SearchableComboBoxGeneral_Client = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewGeneral_Client = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.DateTimePickerGeneral_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerGeneral_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelGeneralEndDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralStartDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxGeneral_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxGeneral_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxGeneral_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelGeneral_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemContractSetup_GeneralTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelContactsTab_Contacts = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewInternalContacts_Contacts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemContractSetup_InternalContactsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.LabelGeneral_Comments = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneral_Comments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            CType(Me.TabControlControl_ContractSetup, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_ContractSetup.SuspendLayout()
            Me.TabControlPanelDocumentsTab_Documents.SuspendLayout()
            Me.TabControlPanelGeneral_General.SuspendLayout()
            CType(Me.SearchableComboBoxGeneral_Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewGeneral_Client, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerGeneral_EndDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerGeneral_StartDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelContactsTab_Contacts.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControlControl_ContractSetup
            '
            Me.TabControlControl_ContractSetup.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlControl_ContractSetup.CanReorderTabs = True
            Me.TabControlControl_ContractSetup.Controls.Add(Me.TabControlPanelGeneral_General)
            Me.TabControlControl_ContractSetup.Controls.Add(Me.TabControlPanelContactsTab_Contacts)
            Me.TabControlControl_ContractSetup.Controls.Add(Me.TabControlPanelDocumentsTab_Documents)
            Me.TabControlControl_ContractSetup.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_ContractSetup.Location = New System.Drawing.Point(0, 0)
            Me.TabControlControl_ContractSetup.Name = "TabControlControl_ContractSetup"
            Me.TabControlControl_ContractSetup.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_ContractSetup.SelectedTabIndex = 0
            Me.TabControlControl_ContractSetup.Size = New System.Drawing.Size(602, 470)
            Me.TabControlControl_ContractSetup.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_ContractSetup.TabIndex = 0
            Me.TabControlControl_ContractSetup.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_ContractSetup.Tabs.Add(Me.TabItemContractSetup_GeneralTab)
            Me.TabControlControl_ContractSetup.Tabs.Add(Me.TabItemContractSetup_InternalContactsTab)
            Me.TabControlControl_ContractSetup.Tabs.Add(Me.TabItemContractSetup_DocumentsTab)
            Me.TabControlControl_ContractSetup.Text = "TabControl1"
            '
            'TabControlPanelDocumentsTab_Documents
            '
            Me.TabControlPanelDocumentsTab_Documents.Controls.Add(Me.DocumentManagerControlDocuments_VendorContractDocuments)
            Me.TabControlPanelDocumentsTab_Documents.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDocumentsTab_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDocumentsTab_Documents.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDocumentsTab_Documents.Name = "TabControlPanelDocumentsTab_Documents"
            Me.TabControlPanelDocumentsTab_Documents.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDocumentsTab_Documents.Size = New System.Drawing.Size(602, 443)
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDocumentsTab_Documents.Style.GradientAngle = 90
            Me.TabControlPanelDocumentsTab_Documents.TabIndex = 7
            Me.TabControlPanelDocumentsTab_Documents.TabItem = Me.TabItemContractSetup_DocumentsTab
            '
            'DocumentManagerControlDocuments_VendorContractDocuments
            '
            Me.DocumentManagerControlDocuments_VendorContractDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlDocuments_VendorContractDocuments.Location = New System.Drawing.Point(6, 6)
            Me.DocumentManagerControlDocuments_VendorContractDocuments.Margin = New System.Windows.Forms.Padding(4)
            Me.DocumentManagerControlDocuments_VendorContractDocuments.Name = "DocumentManagerControlDocuments_VendorContractDocuments"
            Me.DocumentManagerControlDocuments_VendorContractDocuments.Size = New System.Drawing.Size(590, 433)
            Me.DocumentManagerControlDocuments_VendorContractDocuments.TabIndex = 0
            '
            'TabItemContractSetup_DocumentsTab
            '
            Me.TabItemContractSetup_DocumentsTab.AttachedControl = Me.TabControlPanelDocumentsTab_Documents
            Me.TabItemContractSetup_DocumentsTab.Name = "TabItemContractSetup_DocumentsTab"
            Me.TabItemContractSetup_DocumentsTab.Text = "Documents"
            '
            'TabControlPanelGeneral_General
            '
            Me.TabControlPanelGeneral_General.Controls.Add(Me.TextBoxGeneral_Comments)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.LabelGeneral_Comments)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.SearchableComboBoxGeneral_Client)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.DateTimePickerGeneral_EndDate)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.DateTimePickerGeneral_StartDate)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.LabelGeneralEndDate)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.LabelGeneralStartDate)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.LabelGeneral_Code)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.LabelGeneral_Vendor)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.CheckBoxGeneral_Inactive)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.TextBoxGeneral_Code)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.TextBoxGeneral_Description)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.LabelGeneral_Description)
            Me.TabControlPanelGeneral_General.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelGeneral_General.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGeneral_General.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGeneral_General.Name = "TabControlPanelGeneral_General"
            Me.TabControlPanelGeneral_General.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGeneral_General.Size = New System.Drawing.Size(602, 443)
            Me.TabControlPanelGeneral_General.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneral_General.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneral_General.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGeneral_General.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGeneral_General.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGeneral_General.Style.GradientAngle = 90
            Me.TabControlPanelGeneral_General.TabIndex = 0
            Me.TabControlPanelGeneral_General.TabItem = Me.TabItemContractSetup_GeneralTab
            '
            'SearchableComboBoxGeneral_Client
            '
            Me.SearchableComboBoxGeneral_Client.ActiveFilterString = ""
            Me.SearchableComboBoxGeneral_Client.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneral_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneral_Client.AutoFillMode = False
            Me.SearchableComboBoxGeneral_Client.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneral_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Client
            Me.SearchableComboBoxGeneral_Client.DataSource = Nothing
            Me.SearchableComboBoxGeneral_Client.DisableMouseWheel = True
            Me.SearchableComboBoxGeneral_Client.DisplayName = ""
            Me.SearchableComboBoxGeneral_Client.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneral_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxGeneral_Client.Location = New System.Drawing.Point(79, 56)
            Me.SearchableComboBoxGeneral_Client.Name = "SearchableComboBoxGeneral_Client"
            Me.SearchableComboBoxGeneral_Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneral_Client.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneral_Client.Properties.NullText = "Select Client"
            Me.SearchableComboBoxGeneral_Client.Properties.ShowClearButton = False
            Me.SearchableComboBoxGeneral_Client.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneral_Client.Properties.View = Me.SearchableComboBoxViewGeneral_Client
            Me.SearchableComboBoxGeneral_Client.SecurityEnabled = True
            Me.SearchableComboBoxGeneral_Client.SelectedValue = Nothing
            Me.SearchableComboBoxGeneral_Client.Size = New System.Drawing.Size(517, 20)
            Me.SearchableComboBoxGeneral_Client.TabIndex = 7
            '
            'SearchableComboBoxViewGeneral_Client
            '
            Me.SearchableComboBoxViewGeneral_Client.AFActiveFilterString = ""
            Me.SearchableComboBoxViewGeneral_Client.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewGeneral_Client.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewGeneral_Client.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewGeneral_Client.DataSourceClearing = False
            Me.SearchableComboBoxViewGeneral_Client.EnableDisabledRows = False
            Me.SearchableComboBoxViewGeneral_Client.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewGeneral_Client.Name = "SearchableComboBoxViewGeneral_Client"
            Me.SearchableComboBoxViewGeneral_Client.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGeneral_Client.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGeneral_Client.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewGeneral_Client.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewGeneral_Client.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewGeneral_Client.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewGeneral_Client.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewGeneral_Client.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewGeneral_Client.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewGeneral_Client.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewGeneral_Client.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewGeneral_Client.RunStandardValidation = True
            '
            'DateTimePickerGeneral_EndDate
            '
            Me.DateTimePickerGeneral_EndDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerGeneral_EndDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerGeneral_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_EndDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerGeneral_EndDate.ButtonDropDown.Visible = True
            Me.DateTimePickerGeneral_EndDate.ButtonFreeText.Checked = True
            Me.DateTimePickerGeneral_EndDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerGeneral_EndDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerGeneral_EndDate.DisplayName = ""
            Me.DateTimePickerGeneral_EndDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerGeneral_EndDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerGeneral_EndDate.FocusHighlightEnabled = True
            Me.DateTimePickerGeneral_EndDate.FreeTextEntryMode = True
            Me.DateTimePickerGeneral_EndDate.IsPopupCalendarOpen = False
            Me.DateTimePickerGeneral_EndDate.Location = New System.Drawing.Point(79, 108)
            Me.DateTimePickerGeneral_EndDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerGeneral_EndDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.DisplayMonth = New Date(2012, 5, 1, 0, 0, 0, 0)
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerGeneral_EndDate.Name = "DateTimePickerGeneral_EndDate"
            Me.DateTimePickerGeneral_EndDate.ReadOnly = False
            Me.DateTimePickerGeneral_EndDate.Size = New System.Drawing.Size(125, 20)
            Me.DateTimePickerGeneral_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerGeneral_EndDate.TabIndex = 18
            Me.DateTimePickerGeneral_EndDate.TabOnEnter = True
            Me.DateTimePickerGeneral_EndDate.Value = New Date(2013, 11, 20, 9, 22, 37, 992)
            '
            'DateTimePickerGeneral_StartDate
            '
            Me.DateTimePickerGeneral_StartDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerGeneral_StartDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerGeneral_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_StartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerGeneral_StartDate.ButtonDropDown.Visible = True
            Me.DateTimePickerGeneral_StartDate.ButtonFreeText.Checked = True
            Me.DateTimePickerGeneral_StartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerGeneral_StartDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerGeneral_StartDate.DisplayName = ""
            Me.DateTimePickerGeneral_StartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerGeneral_StartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerGeneral_StartDate.FocusHighlightEnabled = True
            Me.DateTimePickerGeneral_StartDate.FreeTextEntryMode = True
            Me.DateTimePickerGeneral_StartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerGeneral_StartDate.Location = New System.Drawing.Point(79, 82)
            Me.DateTimePickerGeneral_StartDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerGeneral_StartDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.DisplayMonth = New Date(2012, 5, 1, 0, 0, 0, 0)
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerGeneral_StartDate.Name = "DateTimePickerGeneral_StartDate"
            Me.DateTimePickerGeneral_StartDate.ReadOnly = False
            Me.DateTimePickerGeneral_StartDate.Size = New System.Drawing.Size(125, 20)
            Me.DateTimePickerGeneral_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerGeneral_StartDate.TabIndex = 16
            Me.DateTimePickerGeneral_StartDate.TabOnEnter = True
            Me.DateTimePickerGeneral_StartDate.Value = New Date(2013, 11, 20, 9, 22, 38, 23)
            '
            'LabelGeneralEndDate
            '
            Me.LabelGeneralEndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralEndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralEndDate.Location = New System.Drawing.Point(6, 108)
            Me.LabelGeneralEndDate.Name = "LabelGeneralEndDate"
            Me.LabelGeneralEndDate.Size = New System.Drawing.Size(67, 20)
            Me.LabelGeneralEndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralEndDate.TabIndex = 17
            Me.LabelGeneralEndDate.Text = "End Date:"
            '
            'LabelGeneralStartDate
            '
            Me.LabelGeneralStartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralStartDate.Location = New System.Drawing.Point(6, 82)
            Me.LabelGeneralStartDate.Name = "LabelGeneralStartDate"
            Me.LabelGeneralStartDate.Size = New System.Drawing.Size(67, 20)
            Me.LabelGeneralStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralStartDate.TabIndex = 15
            Me.LabelGeneralStartDate.Text = "Start Date:"
            '
            'LabelGeneral_Code
            '
            Me.LabelGeneral_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Code.Location = New System.Drawing.Point(6, 4)
            Me.LabelGeneral_Code.Name = "LabelGeneral_Code"
            Me.LabelGeneral_Code.Size = New System.Drawing.Size(67, 20)
            Me.LabelGeneral_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Code.TabIndex = 0
            Me.LabelGeneral_Code.Text = "Code:"
            '
            'LabelGeneral_Vendor
            '
            Me.LabelGeneral_Vendor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Vendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Vendor.Location = New System.Drawing.Point(6, 56)
            Me.LabelGeneral_Vendor.Name = "LabelGeneral_Vendor"
            Me.LabelGeneral_Vendor.Size = New System.Drawing.Size(67, 20)
            Me.LabelGeneral_Vendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Vendor.TabIndex = 6
            Me.LabelGeneral_Vendor.Text = "Vendor: "
            '
            'CheckBoxGeneral_Inactive
            '
            Me.CheckBoxGeneral_Inactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGeneral_Inactive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGeneral_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGeneral_Inactive.CheckValue = 0
            Me.CheckBoxGeneral_Inactive.CheckValueChecked = 1
            Me.CheckBoxGeneral_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGeneral_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxGeneral_Inactive.ChildControls = CType(resources.GetObject("CheckBoxGeneral_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneral_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGeneral_Inactive.Location = New System.Drawing.Point(530, 30)
            Me.CheckBoxGeneral_Inactive.Name = "CheckBoxGeneral_Inactive"
            Me.CheckBoxGeneral_Inactive.OldestSibling = Nothing
            Me.CheckBoxGeneral_Inactive.SecurityEnabled = True
            Me.CheckBoxGeneral_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxGeneral_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneral_Inactive.Size = New System.Drawing.Size(66, 20)
            Me.CheckBoxGeneral_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGeneral_Inactive.TabIndex = 5
            Me.CheckBoxGeneral_Inactive.TabOnEnter = True
            Me.CheckBoxGeneral_Inactive.Text = "Inactive"
            '
            'TextBoxGeneral_Code
            '
            '
            '
            '
            Me.TextBoxGeneral_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_Code.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxGeneral_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Code.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Code.Location = New System.Drawing.Point(79, 5)
            Me.TextBoxGeneral_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Code.Name = "TextBoxGeneral_Code"
            Me.TextBoxGeneral_Code.SecurityEnabled = True
            Me.TextBoxGeneral_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Code.Size = New System.Drawing.Size(75, 20)
            Me.TextBoxGeneral_Code.StartingFolderName = Nothing
            Me.TextBoxGeneral_Code.TabIndex = 1
            Me.TextBoxGeneral_Code.TabOnEnter = True
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
            Me.TextBoxGeneral_Description.Location = New System.Drawing.Point(79, 30)
            Me.TextBoxGeneral_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Description.Name = "TextBoxGeneral_Description"
            Me.TextBoxGeneral_Description.SecurityEnabled = True
            Me.TextBoxGeneral_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Description.Size = New System.Drawing.Size(445, 20)
            Me.TextBoxGeneral_Description.StartingFolderName = Nothing
            Me.TextBoxGeneral_Description.TabIndex = 4
            Me.TextBoxGeneral_Description.TabOnEnter = True
            '
            'LabelGeneral_Description
            '
            Me.LabelGeneral_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Description.Location = New System.Drawing.Point(6, 30)
            Me.LabelGeneral_Description.Name = "LabelGeneral_Description"
            Me.LabelGeneral_Description.Size = New System.Drawing.Size(67, 20)
            Me.LabelGeneral_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Description.TabIndex = 3
            Me.LabelGeneral_Description.Text = "Description:"
            '
            'TabItemContractSetup_GeneralTab
            '
            Me.TabItemContractSetup_GeneralTab.AttachedControl = Me.TabControlPanelGeneral_General
            Me.TabItemContractSetup_GeneralTab.Name = "TabItemContractSetup_GeneralTab"
            Me.TabItemContractSetup_GeneralTab.Text = "General"
            '
            'TabControlPanelContactsTab_Contacts
            '
            Me.TabControlPanelContactsTab_Contacts.Controls.Add(Me.DataGridViewInternalContacts_Contacts)
            Me.TabControlPanelContactsTab_Contacts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelContactsTab_Contacts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelContactsTab_Contacts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelContactsTab_Contacts.Name = "TabControlPanelContactsTab_Contacts"
            Me.TabControlPanelContactsTab_Contacts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelContactsTab_Contacts.Size = New System.Drawing.Size(602, 443)
            Me.TabControlPanelContactsTab_Contacts.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelContactsTab_Contacts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelContactsTab_Contacts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelContactsTab_Contacts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelContactsTab_Contacts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelContactsTab_Contacts.Style.GradientAngle = 90
            Me.TabControlPanelContactsTab_Contacts.TabIndex = 9
            Me.TabControlPanelContactsTab_Contacts.TabItem = Me.TabItemContractSetup_InternalContactsTab
            '
            'DataGridViewInternalContacts_Contacts
            '
            Me.DataGridViewInternalContacts_Contacts.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewInternalContacts_Contacts.AllowDragAndDrop = False
            Me.DataGridViewInternalContacts_Contacts.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewInternalContacts_Contacts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewInternalContacts_Contacts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewInternalContacts_Contacts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewInternalContacts_Contacts.AutoFilterLookupColumns = False
            Me.DataGridViewInternalContacts_Contacts.AutoloadRepositoryDatasource = True
            Me.DataGridViewInternalContacts_Contacts.AutoUpdateViewCaption = True
            Me.DataGridViewInternalContacts_Contacts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewInternalContacts_Contacts.DataSource = Nothing
            Me.DataGridViewInternalContacts_Contacts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewInternalContacts_Contacts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewInternalContacts_Contacts.ItemDescription = "Internal Contact(s)"
            Me.DataGridViewInternalContacts_Contacts.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewInternalContacts_Contacts.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewInternalContacts_Contacts.MultiSelect = False
            Me.DataGridViewInternalContacts_Contacts.Name = "DataGridViewInternalContacts_Contacts"
            Me.DataGridViewInternalContacts_Contacts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewInternalContacts_Contacts.RunStandardValidation = True
            Me.DataGridViewInternalContacts_Contacts.ShowColumnMenuOnRightClick = False
            Me.DataGridViewInternalContacts_Contacts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewInternalContacts_Contacts.Size = New System.Drawing.Size(590, 433)
            Me.DataGridViewInternalContacts_Contacts.TabIndex = 17
            Me.DataGridViewInternalContacts_Contacts.UseEmbeddedNavigator = False
            Me.DataGridViewInternalContacts_Contacts.ViewCaptionHeight = -1
            '
            'TabItemContractSetup_InternalContactsTab
            '
            Me.TabItemContractSetup_InternalContactsTab.AttachedControl = Me.TabControlPanelContactsTab_Contacts
            Me.TabItemContractSetup_InternalContactsTab.Name = "TabItemContractSetup_InternalContactsTab"
            Me.TabItemContractSetup_InternalContactsTab.Text = "Internal Contacts"
            '
            'LabelGeneral_Comments
            '
            Me.LabelGeneral_Comments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Comments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Comments.Location = New System.Drawing.Point(6, 134)
            Me.LabelGeneral_Comments.Name = "LabelGeneral_Comments"
            Me.LabelGeneral_Comments.Size = New System.Drawing.Size(67, 20)
            Me.LabelGeneral_Comments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Comments.TabIndex = 20
            Me.LabelGeneral_Comments.Text = "Comments:"
            '
            'TextBoxGeneral_Comments
            '
            Me.TextBoxGeneral_Comments.AcceptsReturn = True
            Me.TextBoxGeneral_Comments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxGeneral_Comments.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_Comments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_Comments.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_Comments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_Comments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxGeneral_Comments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Comments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Comments.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Comments.Location = New System.Drawing.Point(79, 134)
            Me.TextBoxGeneral_Comments.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Comments.Multiline = True
            Me.TextBoxGeneral_Comments.Name = "TextBoxGeneral_Comments"
            Me.TextBoxGeneral_Comments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxGeneral_Comments.SecurityEnabled = True
            Me.TextBoxGeneral_Comments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Comments.Size = New System.Drawing.Size(517, 305)
            Me.TextBoxGeneral_Comments.StartingFolderName = Nothing
            Me.TextBoxGeneral_Comments.TabIndex = 21
            Me.TextBoxGeneral_Comments.TabOnEnter = True
            '
            'VendorContractControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlControl_ContractSetup)
            Me.Name = "VendorContractControl"
            Me.Size = New System.Drawing.Size(602, 470)
            CType(Me.TabControlControl_ContractSetup, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_ContractSetup.ResumeLayout(False)
            Me.TabControlPanelDocumentsTab_Documents.ResumeLayout(False)
            Me.TabControlPanelGeneral_General.ResumeLayout(False)
            CType(Me.SearchableComboBoxGeneral_Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewGeneral_Client, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerGeneral_EndDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerGeneral_StartDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelContactsTab_Contacts.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlControl_ContractSetup As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelGeneral_General As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemContractSetup_GeneralTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDocumentsTab_Documents As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemContractSetup_DocumentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DocumentManagerControlDocuments_VendorContractDocuments As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents TabControlPanelContactsTab_Contacts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemContractSetup_InternalContactsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelGeneral_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Vendor As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxGeneral_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxGeneral_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxGeneral_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelGeneral_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralStartDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralEndDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerGeneral_EndDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerGeneral_StartDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents SearchableComboBoxGeneral_Client As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewGeneral_Client As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents DataGridViewInternalContacts_Contacts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TextBoxGeneral_Comments As TextBox
        Friend WithEvents LabelGeneral_Comments As Label
    End Class

End Namespace
