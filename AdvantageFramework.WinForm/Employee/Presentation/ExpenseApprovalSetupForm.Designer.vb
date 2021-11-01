Namespace Employee.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ExpenseApprovalSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExpenseApprovalSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Status = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemStatus_Approved = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemStatus_Denied = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemStatus_Pending = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Search = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.CheckBoxSearch_Pending = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxSearch_Denied = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxSearch_Approved = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SearchableComboBoxForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.DateTimePickerSearch_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerSearch_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainer2 = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemSearch_Employees = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemSearch_Employee = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemSearch_StartDate = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemSearch_StartDate = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainer4 = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemSearch_EndDate = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemSearch_EndDate = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerSearch_Status = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerStatus_Pending = New DevComponents.DotNetBar.ItemContainer()
            Me.ControlContainerItemPending_Pending = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerStatus_Denied = New DevComponents.DotNetBar.ItemContainer()
            Me.ControlContainerItemDenied_Denied = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerStatus_Approved = New DevComponents.DotNetBar.ItemContainer()
            Me.ControlContainerItemApproved_Approved = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemSearch_Search = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Expand = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Collapse = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewForm_ExpenseReports = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBarOptions_Search.SuspendLayout()
            CType(Me.SearchableComboBoxForm_Employee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewForm_Employee, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerSearch_StartDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerSearch_EndDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Status)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Search)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 99)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 3
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_Status
            '
            Me.RibbonBarOptions_Status.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Status.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Status.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Status.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Status.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Status.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemStatus_Approved, Me.ButtonItemStatus_Denied, Me.ButtonItemStatus_Pending})
            Me.RibbonBarOptions_Status.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Status.Location = New System.Drawing.Point(516, 0)
            Me.RibbonBarOptions_Status.Name = "RibbonBarOptions_Status"
            Me.RibbonBarOptions_Status.Size = New System.Drawing.Size(159, 98)
            Me.RibbonBarOptions_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Status.TabIndex = 2
            Me.RibbonBarOptions_Status.Text = "Update Status"
            '
            '
            '
            Me.RibbonBarOptions_Status.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Status.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Status.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemStatus_Approved
            '
            Me.ButtonItemStatus_Approved.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemStatus_Approved.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemStatus_Approved.Name = "ButtonItemStatus_Approved"
            Me.ButtonItemStatus_Approved.RibbonWordWrap = False
            Me.ButtonItemStatus_Approved.Stretch = True
            Me.ButtonItemStatus_Approved.SubItemsExpandWidth = 14
            Me.ButtonItemStatus_Approved.Text = "Approved"
            '
            'ButtonItemStatus_Denied
            '
            Me.ButtonItemStatus_Denied.BeginGroup = True
            Me.ButtonItemStatus_Denied.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemStatus_Denied.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemStatus_Denied.Name = "ButtonItemStatus_Denied"
            Me.ButtonItemStatus_Denied.RibbonWordWrap = False
            Me.ButtonItemStatus_Denied.Stretch = True
            Me.ButtonItemStatus_Denied.SubItemsExpandWidth = 14
            Me.ButtonItemStatus_Denied.Text = "Denied"
            '
            'ButtonItemStatus_Pending
            '
            Me.ButtonItemStatus_Pending.BeginGroup = True
            Me.ButtonItemStatus_Pending.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemStatus_Pending.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemStatus_Pending.Name = "ButtonItemStatus_Pending"
            Me.ButtonItemStatus_Pending.RibbonWordWrap = False
            Me.ButtonItemStatus_Pending.Stretch = True
            Me.ButtonItemStatus_Pending.SubItemsExpandWidth = 14
            Me.ButtonItemStatus_Pending.Text = "Pending"
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
            Me.RibbonBarOptions_Search.Controls.Add(Me.CheckBoxSearch_Pending)
            Me.RibbonBarOptions_Search.Controls.Add(Me.CheckBoxSearch_Denied)
            Me.RibbonBarOptions_Search.Controls.Add(Me.CheckBoxSearch_Approved)
            Me.RibbonBarOptions_Search.Controls.Add(Me.SearchableComboBoxForm_Employee)
            Me.RibbonBarOptions_Search.Controls.Add(Me.DateTimePickerSearch_StartDate)
            Me.RibbonBarOptions_Search.Controls.Add(Me.DateTimePickerSearch_EndDate)
            Me.RibbonBarOptions_Search.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Search.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1, Me.ItemContainerSearch_Status, Me.ButtonItemSearch_Search})
            Me.RibbonBarOptions_Search.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Search.Location = New System.Drawing.Point(186, 0)
            Me.RibbonBarOptions_Search.Name = "RibbonBarOptions_Search"
            Me.RibbonBarOptions_Search.Size = New System.Drawing.Size(330, 98)
            Me.RibbonBarOptions_Search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Search.TabIndex = 1
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
            'CheckBoxSearch_Pending
            '
            '
            '
            '
            Me.CheckBoxSearch_Pending.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSearch_Pending.CheckValue = 0
            Me.CheckBoxSearch_Pending.CheckValueChecked = 1
            Me.CheckBoxSearch_Pending.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSearch_Pending.CheckValueUnchecked = 0
            Me.CheckBoxSearch_Pending.ChildControls = CType(resources.GetObject("CheckBoxSearch_Pending.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSearch_Pending.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSearch_Pending.Location = New System.Drawing.Point(200, 13)
            Me.CheckBoxSearch_Pending.Name = "CheckBoxSearch_Pending"
            Me.CheckBoxSearch_Pending.OldestSibling = Nothing
            Me.CheckBoxSearch_Pending.SecurityEnabled = True
            Me.CheckBoxSearch_Pending.SiblingControls = CType(resources.GetObject("CheckBoxSearch_Pending.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSearch_Pending.Size = New System.Drawing.Size(77, 20)
            Me.CheckBoxSearch_Pending.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSearch_Pending.TabIndex = 6
            Me.CheckBoxSearch_Pending.Text = "Pending"
            '
            'CheckBoxSearch_Denied
            '
            '
            '
            '
            Me.CheckBoxSearch_Denied.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSearch_Denied.CheckValue = 0
            Me.CheckBoxSearch_Denied.CheckValueChecked = 1
            Me.CheckBoxSearch_Denied.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSearch_Denied.CheckValueUnchecked = 0
            Me.CheckBoxSearch_Denied.ChildControls = CType(resources.GetObject("CheckBoxSearch_Denied.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSearch_Denied.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSearch_Denied.Location = New System.Drawing.Point(200, 36)
            Me.CheckBoxSearch_Denied.Name = "CheckBoxSearch_Denied"
            Me.CheckBoxSearch_Denied.OldestSibling = Nothing
            Me.CheckBoxSearch_Denied.SecurityEnabled = True
            Me.CheckBoxSearch_Denied.SiblingControls = CType(resources.GetObject("CheckBoxSearch_Denied.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSearch_Denied.Size = New System.Drawing.Size(77, 20)
            Me.CheckBoxSearch_Denied.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSearch_Denied.TabIndex = 7
            Me.CheckBoxSearch_Denied.Text = "Denied"
            '
            'CheckBoxSearch_Approved
            '
            '
            '
            '
            Me.CheckBoxSearch_Approved.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSearch_Approved.CheckValue = 0
            Me.CheckBoxSearch_Approved.CheckValueChecked = 1
            Me.CheckBoxSearch_Approved.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSearch_Approved.CheckValueUnchecked = 0
            Me.CheckBoxSearch_Approved.ChildControls = CType(resources.GetObject("CheckBoxSearch_Approved.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSearch_Approved.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSearch_Approved.Location = New System.Drawing.Point(200, 59)
            Me.CheckBoxSearch_Approved.Name = "CheckBoxSearch_Approved"
            Me.CheckBoxSearch_Approved.OldestSibling = Nothing
            Me.CheckBoxSearch_Approved.SecurityEnabled = True
            Me.CheckBoxSearch_Approved.SiblingControls = CType(resources.GetObject("CheckBoxSearch_Approved.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSearch_Approved.Size = New System.Drawing.Size(77, 20)
            Me.CheckBoxSearch_Approved.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSearch_Approved.TabIndex = 8
            Me.CheckBoxSearch_Approved.Text = "Approved"
            '
            'SearchableComboBoxForm_Employee
            '
            Me.SearchableComboBoxForm_Employee.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Employee.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Employee.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Employee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxForm_Employee.DataSource = Nothing
            Me.SearchableComboBoxForm_Employee.DisableMouseWheel = False
            Me.SearchableComboBoxForm_Employee.DisplayName = ""
            Me.SearchableComboBoxForm_Employee.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.All
            Me.SearchableComboBoxForm_Employee.Location = New System.Drawing.Point(65, 13)
            Me.SearchableComboBoxForm_Employee.Name = "SearchableComboBoxForm_Employee"
            Me.SearchableComboBoxForm_Employee.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Employee.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_Employee.Properties.NullText = "Select Employee"
            Me.SearchableComboBoxForm_Employee.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_Employee.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Employee.Properties.View = Me.SearchableComboBoxViewForm_Employee
            Me.SearchableComboBoxForm_Employee.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Employee.Size = New System.Drawing.Size(130, 20)
            Me.SearchableComboBoxForm_Employee.TabIndex = 6
            '
            'SearchableComboBoxViewForm_Employee
            '
            Me.SearchableComboBoxViewForm_Employee.AFActiveFilterString = ""
            Me.SearchableComboBoxViewForm_Employee.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Employee.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewForm_Employee.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewForm_Employee.DataSourceClearing = False
            Me.SearchableComboBoxViewForm_Employee.EnableDisabledRows = False
            Me.SearchableComboBoxViewForm_Employee.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewForm_Employee.Name = "SearchableComboBoxViewForm_Employee"
            Me.SearchableComboBoxViewForm_Employee.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewForm_Employee.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewForm_Employee.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewForm_Employee.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewForm_Employee.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewForm_Employee.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewForm_Employee.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewForm_Employee.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewForm_Employee.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewForm_Employee.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewForm_Employee.RunStandardValidation = True
            '
            'DateTimePickerSearch_StartDate
            '
            Me.DateTimePickerSearch_StartDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerSearch_StartDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerSearch_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSearch_StartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerSearch_StartDate.ButtonDropDown.Visible = True
            Me.DateTimePickerSearch_StartDate.ButtonFreeText.Checked = True
            Me.DateTimePickerSearch_StartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerSearch_StartDate.CustomFormat = ""
            Me.DateTimePickerSearch_StartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerSearch_StartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerSearch_StartDate.FocusHighlightEnabled = True
            Me.DateTimePickerSearch_StartDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerSearch_StartDate.FreeTextEntryMode = True
            Me.DateTimePickerSearch_StartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerSearch_StartDate.Location = New System.Drawing.Point(65, 36)
            Me.DateTimePickerSearch_StartDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerSearch_StartDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerSearch_StartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSearch_StartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerSearch_StartDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerSearch_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerSearch_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerSearch_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerSearch_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerSearch_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerSearch_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerSearch_StartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSearch_StartDate.MonthCalendar.DisplayMonth = New Date(2013, 1, 1, 0, 0, 0, 0)
            Me.DateTimePickerSearch_StartDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerSearch_StartDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerSearch_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerSearch_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerSearch_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerSearch_StartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSearch_StartDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerSearch_StartDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerSearch_StartDate.Name = "DateTimePickerSearch_StartDate"
            Me.DateTimePickerSearch_StartDate.ReadOnly = False
            Me.DateTimePickerSearch_StartDate.Size = New System.Drawing.Size(130, 20)
            Me.DateTimePickerSearch_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerSearch_StartDate.TabIndex = 6
            Me.DateTimePickerSearch_StartDate.Value = New Date(2013, 8, 9, 10, 29, 44, 814)
            '
            'DateTimePickerSearch_EndDate
            '
            Me.DateTimePickerSearch_EndDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerSearch_EndDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerSearch_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSearch_EndDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerSearch_EndDate.ButtonDropDown.Visible = True
            Me.DateTimePickerSearch_EndDate.ButtonFreeText.Checked = True
            Me.DateTimePickerSearch_EndDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerSearch_EndDate.CustomFormat = ""
            Me.DateTimePickerSearch_EndDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerSearch_EndDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerSearch_EndDate.FocusHighlightEnabled = True
            Me.DateTimePickerSearch_EndDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerSearch_EndDate.FreeTextEntryMode = True
            Me.DateTimePickerSearch_EndDate.IsPopupCalendarOpen = False
            Me.DateTimePickerSearch_EndDate.Location = New System.Drawing.Point(65, 59)
            Me.DateTimePickerSearch_EndDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerSearch_EndDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerSearch_EndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSearch_EndDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerSearch_EndDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerSearch_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerSearch_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerSearch_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerSearch_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerSearch_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerSearch_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerSearch_EndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSearch_EndDate.MonthCalendar.DisplayMonth = New Date(2013, 1, 1, 0, 0, 0, 0)
            Me.DateTimePickerSearch_EndDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerSearch_EndDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerSearch_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerSearch_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerSearch_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerSearch_EndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSearch_EndDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerSearch_EndDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerSearch_EndDate.Name = "DateTimePickerSearch_EndDate"
            Me.DateTimePickerSearch_EndDate.ReadOnly = False
            Me.DateTimePickerSearch_EndDate.Size = New System.Drawing.Size(130, 20)
            Me.DateTimePickerSearch_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerSearch_EndDate.TabIndex = 7
            Me.DateTimePickerSearch_EndDate.Value = New Date(2013, 8, 9, 10, 29, 44, 837)
            '
            'ItemContainer1
            '
            '
            '
            '
            Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer1.Name = "ItemContainer1"
            Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer2, Me.ItemContainer3, Me.ItemContainer4})
            '
            '
            '
            Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer1.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainer2
            '
            '
            '
            '
            Me.ItemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer2.Name = "ItemContainer2"
            Me.ItemContainer2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemSearch_Employees, Me.ControlContainerItemSearch_Employee})
            '
            '
            '
            Me.ItemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemSearch_Employees
            '
            Me.LabelItemSearch_Employees.Name = "LabelItemSearch_Employees"
            Me.LabelItemSearch_Employees.Text = "Employee:"
            Me.LabelItemSearch_Employees.Width = 58
            '
            'ControlContainerItemSearch_Employee
            '
            Me.ControlContainerItemSearch_Employee.AllowItemResize = True
            Me.ControlContainerItemSearch_Employee.Control = Me.SearchableComboBoxForm_Employee
            Me.ControlContainerItemSearch_Employee.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemSearch_Employee.Name = "ControlContainerItemSearch_Employee"
            Me.ControlContainerItemSearch_Employee.Text = "ControlContainerItem1"
            '
            'ItemContainer3
            '
            '
            '
            '
            Me.ItemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer3.Name = "ItemContainer3"
            Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemSearch_StartDate, Me.ControlContainerItemSearch_StartDate})
            '
            '
            '
            Me.ItemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemSearch_StartDate
            '
            Me.LabelItemSearch_StartDate.Name = "LabelItemSearch_StartDate"
            Me.LabelItemSearch_StartDate.Text = "Start Date:"
            Me.LabelItemSearch_StartDate.Width = 58
            '
            'ControlContainerItemSearch_StartDate
            '
            Me.ControlContainerItemSearch_StartDate.AllowItemResize = True
            Me.ControlContainerItemSearch_StartDate.Control = Me.DateTimePickerSearch_StartDate
            Me.ControlContainerItemSearch_StartDate.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemSearch_StartDate.Name = "ControlContainerItemSearch_StartDate"
            Me.ControlContainerItemSearch_StartDate.Text = "Start Date"
            '
            'ItemContainer4
            '
            '
            '
            '
            Me.ItemContainer4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer4.Name = "ItemContainer4"
            Me.ItemContainer4.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemSearch_EndDate, Me.ControlContainerItemSearch_EndDate})
            '
            '
            '
            Me.ItemContainer4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemSearch_EndDate
            '
            Me.LabelItemSearch_EndDate.Name = "LabelItemSearch_EndDate"
            Me.LabelItemSearch_EndDate.Text = "End Date:"
            Me.LabelItemSearch_EndDate.Width = 58
            '
            'ControlContainerItemSearch_EndDate
            '
            Me.ControlContainerItemSearch_EndDate.AllowItemResize = True
            Me.ControlContainerItemSearch_EndDate.Control = Me.DateTimePickerSearch_EndDate
            Me.ControlContainerItemSearch_EndDate.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemSearch_EndDate.Name = "ControlContainerItemSearch_EndDate"
            Me.ControlContainerItemSearch_EndDate.Text = "End Date"
            '
            'ItemContainerSearch_Status
            '
            '
            '
            '
            Me.ItemContainerSearch_Status.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_Status.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSearch_Status.Name = "ItemContainerSearch_Status"
            Me.ItemContainerSearch_Status.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerStatus_Pending, Me.ItemContainerStatus_Denied, Me.ItemContainerStatus_Approved})
            '
            '
            '
            Me.ItemContainerSearch_Status.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_Status.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainerStatus_Pending
            '
            '
            '
            '
            Me.ItemContainerStatus_Pending.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerStatus_Pending.Name = "ItemContainerStatus_Pending"
            Me.ItemContainerStatus_Pending.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItemPending_Pending})
            '
            '
            '
            Me.ItemContainerStatus_Pending.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ControlContainerItemPending_Pending
            '
            Me.ControlContainerItemPending_Pending.AllowItemResize = True
            Me.ControlContainerItemPending_Pending.Control = Me.CheckBoxSearch_Pending
            Me.ControlContainerItemPending_Pending.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemPending_Pending.Name = "ControlContainerItemPending_Pending"
            Me.ControlContainerItemPending_Pending.Text = "Pending"
            '
            'ItemContainerStatus_Denied
            '
            '
            '
            '
            Me.ItemContainerStatus_Denied.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerStatus_Denied.Name = "ItemContainerStatus_Denied"
            Me.ItemContainerStatus_Denied.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItemDenied_Denied})
            '
            '
            '
            Me.ItemContainerStatus_Denied.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ControlContainerItemDenied_Denied
            '
            Me.ControlContainerItemDenied_Denied.AllowItemResize = True
            Me.ControlContainerItemDenied_Denied.Control = Me.CheckBoxSearch_Denied
            Me.ControlContainerItemDenied_Denied.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemDenied_Denied.Name = "ControlContainerItemDenied_Denied"
            Me.ControlContainerItemDenied_Denied.Text = "Denied"
            '
            'ItemContainerStatus_Approved
            '
            '
            '
            '
            Me.ItemContainerStatus_Approved.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerStatus_Approved.Name = "ItemContainerStatus_Approved"
            Me.ItemContainerStatus_Approved.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItemApproved_Approved})
            '
            '
            '
            Me.ItemContainerStatus_Approved.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ControlContainerItemApproved_Approved
            '
            Me.ControlContainerItemApproved_Approved.AllowItemResize = True
            Me.ControlContainerItemApproved_Approved.Control = Me.CheckBoxSearch_Approved
            Me.ControlContainerItemApproved_Approved.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemApproved_Approved.Name = "ControlContainerItemApproved_Approved"
            Me.ControlContainerItemApproved_Approved.Text = "Approved"
            '
            'ButtonItemSearch_Search
            '
            Me.ButtonItemSearch_Search.BeginGroup = True
            Me.ButtonItemSearch_Search.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSearch_Search.Name = "ButtonItemSearch_Search"
            Me.ButtonItemSearch_Search.RibbonWordWrap = False
            Me.ButtonItemSearch_Search.Stretch = True
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Save, Me.ButtonItemActions_Expand, Me.ButtonItemActions_Collapse})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(186, 98)
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
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.Stretch = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Expand
            '
            Me.ButtonItemActions_Expand.BeginGroup = True
            Me.ButtonItemActions_Expand.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Expand.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Expand.Name = "ButtonItemActions_Expand"
            Me.ButtonItemActions_Expand.RibbonWordWrap = False
            Me.ButtonItemActions_Expand.Stretch = True
            Me.ButtonItemActions_Expand.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Expand.Text = "Expand"
            '
            'ButtonItemActions_Collapse
            '
            Me.ButtonItemActions_Collapse.BeginGroup = True
            Me.ButtonItemActions_Collapse.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Collapse.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Collapse.Name = "ButtonItemActions_Collapse"
            Me.ButtonItemActions_Collapse.RibbonWordWrap = False
            Me.ButtonItemActions_Collapse.Stretch = True
            Me.ButtonItemActions_Collapse.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Collapse.Text = "Collapse"
            '
            'DataGridViewForm_ExpenseReports
            '
            Me.DataGridViewForm_ExpenseReports.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_ExpenseReports.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_ExpenseReports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_ExpenseReports.AutoFilterLookupColumns = False
            Me.DataGridViewForm_ExpenseReports.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_ExpenseReports.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_ExpenseReports.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_ExpenseReports.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_ExpenseReports.ItemDescription = "Expense Report(s)"
            Me.DataGridViewForm_ExpenseReports.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_ExpenseReports.MultiSelect = True
            Me.DataGridViewForm_ExpenseReports.Name = "DataGridViewForm_ExpenseReports"
            Me.DataGridViewForm_ExpenseReports.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_ExpenseReports.RunStandardValidation = True
            Me.DataGridViewForm_ExpenseReports.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ExpenseReports.Size = New System.Drawing.Size(689, 397)
            Me.DataGridViewForm_ExpenseReports.TabIndex = 4
            Me.DataGridViewForm_ExpenseReports.UseEmbeddedNavigator = False
            Me.DataGridViewForm_ExpenseReports.ViewCaptionHeight = -1
            '
            'ExpenseApprovalSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(713, 421)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_ExpenseReports)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ExpenseApprovalSetupForm"
            Me.Text = "Expense Approval"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBarOptions_Search.ResumeLayout(False)
            CType(Me.SearchableComboBoxForm_Employee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewForm_Employee, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerSearch_StartDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerSearch_EndDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewForm_ExpenseReports As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Search As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemSearch_Search As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainer2 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSearch_Employees As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemSearch_Employee As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSearch_StartDate As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemSearch_StartDate As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ItemContainer4 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSearch_EndDate As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemSearch_EndDate As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents SearchableComboBoxForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents DateTimePickerSearch_StartDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerSearch_EndDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents CheckBoxSearch_Pending As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSearch_Denied As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSearch_Approved As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ItemContainerSearch_Status As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerStatus_Pending As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ControlContainerItemPending_Pending As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ItemContainerStatus_Denied As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ControlContainerItemDenied_Denied As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ItemContainerStatus_Approved As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ControlContainerItemApproved_Approved As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemActions_Expand As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Status As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemStatus_Approved As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemStatus_Denied As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemStatus_Pending As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Collapse As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace

