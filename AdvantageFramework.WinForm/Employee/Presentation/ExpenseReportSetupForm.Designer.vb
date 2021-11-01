Namespace Employee.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ExpenseReportSetupForm
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExpenseReportSetupForm))
			Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
			Me.RibbonBarOptions_Filter = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemFilter_All = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemFilter_SelectedLineItem = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Receipts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemReceipts_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemReceipts_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemReceipts_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Items = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemItems_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemItems_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemItems_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemItems_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemItems_Documents = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Search = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.SearchableComboBoxSearch_Employees = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
			Me.SearchableComboBox1View = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
			Me.ComboBoxSearch_Month = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
			Me.ComboBoxSearch_Year = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
			Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
			Me.ItemContainer4 = New DevComponents.DotNetBar.ItemContainer()
			Me.LabelItemSearch_Employees = New DevComponents.DotNetBar.LabelItem()
			Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
			Me.ItemContainer2 = New DevComponents.DotNetBar.ItemContainer()
			Me.LabelItemSearch_Month = New DevComponents.DotNetBar.LabelItem()
			Me.ControlContainerItemSearch_Month = New DevComponents.DotNetBar.ControlContainerItem()
			Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
			Me.LabelItemSearch_Year = New DevComponents.DotNetBar.LabelItem()
			Me.ControlContainerItem2 = New DevComponents.DotNetBar.ControlContainerItem()
			Me.ButtonItemSearch_Search = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemActions_Import = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Submit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Unsubmit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_ViewReceipts = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
			Me.ExpenseReportControlRightSection_ExpenseReport = New AdvantageFramework.WinForm.Presentation.Controls.ExpenseReportControl()
			Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
			Me.DataGridViewLeftSection_ExpenseReports = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
			Me.ExpandableSplitterControl1 = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
			Me.ButtonItemReceiptsUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
			Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
			Me.RibbonBarOptions_Search.SuspendLayout()
			CType(Me.SearchableComboBoxSearch_Employees.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.PanelForm_RightSection.SuspendLayout()
			CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.PanelForm_LeftSection.SuspendLayout()
			Me.SuspendLayout()
			'
			'RibbonBarMergeContainerForm_Options
			'
			Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Filter)
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Receipts)
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Items)
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Search)
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
			Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(5, 343)
			Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
			Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
			Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
			Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1225, 98)
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
			Me.RibbonBarMergeContainerForm_Options.TabIndex = 7
			Me.RibbonBarMergeContainerForm_Options.Visible = False
			'
			'RibbonBarOptions_Filter
			'
			Me.RibbonBarOptions_Filter.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_Filter.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Filter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Filter.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_Filter.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_Filter.DragDropSupport = True
			Me.RibbonBarOptions_Filter.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFilter_All, Me.ButtonItemFilter_SelectedLineItem})
			Me.RibbonBarOptions_Filter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Filter.Location = New System.Drawing.Point(992, 0)
			Me.RibbonBarOptions_Filter.Name = "RibbonBarOptions_Filter"
			Me.RibbonBarOptions_Filter.SecurityEnabled = True
			Me.RibbonBarOptions_Filter.Size = New System.Drawing.Size(170, 98)
			Me.RibbonBarOptions_Filter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Filter.TabIndex = 7
			Me.RibbonBarOptions_Filter.Text = "Filter"
			'
			'
			'
			Me.RibbonBarOptions_Filter.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Filter.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Filter.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemFilter_All
			'
			Me.ButtonItemFilter_All.AutoCheckOnClick = True
			Me.ButtonItemFilter_All.BeginGroup = True
			Me.ButtonItemFilter_All.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemFilter_All.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemFilter_All.Name = "ButtonItemFilter_All"
			Me.ButtonItemFilter_All.RibbonWordWrap = False
			Me.ButtonItemFilter_All.SecurityEnabled = True
			Me.ButtonItemFilter_All.Stretch = True
			Me.ButtonItemFilter_All.SubItemsExpandWidth = 14
			Me.ButtonItemFilter_All.Text = "All"
			'
			'ButtonItemFilter_SelectedLineItem
			'
			Me.ButtonItemFilter_SelectedLineItem.AutoCheckOnClick = True
			Me.ButtonItemFilter_SelectedLineItem.BeginGroup = True
			Me.ButtonItemFilter_SelectedLineItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemFilter_SelectedLineItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemFilter_SelectedLineItem.Name = "ButtonItemFilter_SelectedLineItem"
			Me.ButtonItemFilter_SelectedLineItem.RibbonWordWrap = False
			Me.ButtonItemFilter_SelectedLineItem.SecurityEnabled = True
			Me.ButtonItemFilter_SelectedLineItem.Stretch = True
			Me.ButtonItemFilter_SelectedLineItem.SubItemsExpandWidth = 14
			Me.ButtonItemFilter_SelectedLineItem.Text = "Selected Line Item(s)"
			'
			'RibbonBarOptions_Receipts
			'
			Me.RibbonBarOptions_Receipts.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_Receipts.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Receipts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Receipts.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_Receipts.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_Receipts.DragDropSupport = True
			Me.RibbonBarOptions_Receipts.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReceipts_Upload, Me.ButtonItemReceipts_Download, Me.ButtonItemReceipts_Delete})
			Me.RibbonBarOptions_Receipts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Receipts.Location = New System.Drawing.Point(838, 0)
			Me.RibbonBarOptions_Receipts.Name = "RibbonBarOptions_Receipts"
			Me.RibbonBarOptions_Receipts.SecurityEnabled = True
			Me.RibbonBarOptions_Receipts.Size = New System.Drawing.Size(154, 98)
			Me.RibbonBarOptions_Receipts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Receipts.TabIndex = 6
			Me.RibbonBarOptions_Receipts.Text = "Receipts"
			'
			'
			'
			Me.RibbonBarOptions_Receipts.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Receipts.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Receipts.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemReceipts_Upload
			'
			Me.ButtonItemReceipts_Upload.BeginGroup = True
			Me.ButtonItemReceipts_Upload.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemReceipts_Upload.Name = "ButtonItemReceipts_Upload"
			Me.ButtonItemReceipts_Upload.RibbonWordWrap = False
			Me.ButtonItemReceipts_Upload.SecurityEnabled = True
			Me.ButtonItemReceipts_Upload.SplitButton = True
			Me.ButtonItemReceipts_Upload.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReceiptsUpload_EmailLink})
			Me.ButtonItemReceipts_Upload.SubItemsExpandWidth = 14
			Me.ButtonItemReceipts_Upload.Text = "Upload"
			'
			'ButtonItemReceipts_Download
			'
			Me.ButtonItemReceipts_Download.BeginGroup = True
			Me.ButtonItemReceipts_Download.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemReceipts_Download.Name = "ButtonItemReceipts_Download"
			Me.ButtonItemReceipts_Download.RibbonWordWrap = False
			Me.ButtonItemReceipts_Download.SecurityEnabled = True
			Me.ButtonItemReceipts_Download.SubItemsExpandWidth = 14
			Me.ButtonItemReceipts_Download.Text = "Download"
			'
			'ButtonItemReceipts_Delete
			'
			Me.ButtonItemReceipts_Delete.BeginGroup = True
			Me.ButtonItemReceipts_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemReceipts_Delete.Name = "ButtonItemReceipts_Delete"
			Me.ButtonItemReceipts_Delete.RibbonWordWrap = False
			Me.ButtonItemReceipts_Delete.SecurityEnabled = True
			Me.ButtonItemReceipts_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemReceipts_Delete.Text = "Delete"
			'
			'RibbonBarOptions_Items
			'
			Me.RibbonBarOptions_Items.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_Items.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Items.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Items.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_Items.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_Items.DragDropSupport = True
			Me.RibbonBarOptions_Items.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemItems_Export, Me.ButtonItemItems_Copy, Me.ButtonItemItems_Delete, Me.ButtonItemItems_Cancel, Me.ButtonItemItems_Documents})
			Me.RibbonBarOptions_Items.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Items.Location = New System.Drawing.Point(605, 0)
			Me.RibbonBarOptions_Items.Name = "RibbonBarOptions_Items"
			Me.RibbonBarOptions_Items.SecurityEnabled = True
			Me.RibbonBarOptions_Items.Size = New System.Drawing.Size(233, 98)
			Me.RibbonBarOptions_Items.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Items.TabIndex = 5
			Me.RibbonBarOptions_Items.Text = "Items"
			'
			'
			'
			Me.RibbonBarOptions_Items.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Items.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Items.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemItems_Export
			'
			Me.ButtonItemItems_Export.BeginGroup = True
			Me.ButtonItemItems_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemItems_Export.Name = "ButtonItemItems_Export"
			Me.ButtonItemItems_Export.RibbonWordWrap = False
			Me.ButtonItemItems_Export.SecurityEnabled = True
			Me.ButtonItemItems_Export.SubItemsExpandWidth = 14
			Me.ButtonItemItems_Export.Text = "Export"
			'
			'ButtonItemItems_Copy
			'
			Me.ButtonItemItems_Copy.BeginGroup = True
			Me.ButtonItemItems_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemItems_Copy.Name = "ButtonItemItems_Copy"
			Me.ButtonItemItems_Copy.RibbonWordWrap = False
			Me.ButtonItemItems_Copy.SecurityEnabled = True
			Me.ButtonItemItems_Copy.SubItemsExpandWidth = 14
			Me.ButtonItemItems_Copy.Text = "Copy"
			'
			'ButtonItemItems_Delete
			'
			Me.ButtonItemItems_Delete.BeginGroup = True
			Me.ButtonItemItems_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemItems_Delete.Name = "ButtonItemItems_Delete"
			Me.ButtonItemItems_Delete.RibbonWordWrap = False
			Me.ButtonItemItems_Delete.SecurityEnabled = True
			Me.ButtonItemItems_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemItems_Delete.Text = "Delete"
			'
			'ButtonItemItems_Cancel
			'
			Me.ButtonItemItems_Cancel.BeginGroup = True
			Me.ButtonItemItems_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemItems_Cancel.Name = "ButtonItemItems_Cancel"
			Me.ButtonItemItems_Cancel.RibbonWordWrap = False
			Me.ButtonItemItems_Cancel.SecurityEnabled = True
			Me.ButtonItemItems_Cancel.SubItemsExpandWidth = 14
			Me.ButtonItemItems_Cancel.Text = "Cancel"
			'
			'ButtonItemItems_Documents
			'
			Me.ButtonItemItems_Documents.BeginGroup = True
			Me.ButtonItemItems_Documents.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemItems_Documents.Name = "ButtonItemItems_Documents"
			Me.ButtonItemItems_Documents.RibbonWordWrap = False
			Me.ButtonItemItems_Documents.SecurityEnabled = True
			Me.ButtonItemItems_Documents.SubItemsExpandWidth = 14
			Me.ButtonItemItems_Documents.Text = "Documents"
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
			Me.RibbonBarOptions_Search.Controls.Add(Me.SearchableComboBoxSearch_Employees)
			Me.RibbonBarOptions_Search.Controls.Add(Me.ComboBoxSearch_Month)
			Me.RibbonBarOptions_Search.Controls.Add(Me.ComboBoxSearch_Year)
			Me.RibbonBarOptions_Search.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_Search.DragDropSupport = True
			Me.RibbonBarOptions_Search.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1, Me.ButtonItemSearch_Search})
			Me.RibbonBarOptions_Search.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Search.Location = New System.Drawing.Point(331, 0)
			Me.RibbonBarOptions_Search.Name = "RibbonBarOptions_Search"
			Me.RibbonBarOptions_Search.SecurityEnabled = True
			Me.RibbonBarOptions_Search.Size = New System.Drawing.Size(274, 98)
			Me.RibbonBarOptions_Search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Search.TabIndex = 4
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
			'SearchableComboBoxSearch_Employees
			'
			Me.SearchableComboBoxSearch_Employees.ActiveFilterString = ""
			Me.SearchableComboBoxSearch_Employees.AddInactiveItemsOnSelectedValue = False
			Me.SearchableComboBoxSearch_Employees.AutoFillMode = False
			Me.SearchableComboBoxSearch_Employees.BookmarkingEnabled = False
			Me.SearchableComboBoxSearch_Employees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.EmployeesIncludingTerminated
			Me.SearchableComboBoxSearch_Employees.DataSource = Nothing
			Me.SearchableComboBoxSearch_Employees.DisableMouseWheel = False
			Me.SearchableComboBoxSearch_Employees.DisplayName = ""
			Me.SearchableComboBoxSearch_Employees.EnterMoveNextControl = True
			Me.SearchableComboBoxSearch_Employees.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
			Me.SearchableComboBoxSearch_Employees.Location = New System.Drawing.Point(65, 19)
			Me.SearchableComboBoxSearch_Employees.Name = "SearchableComboBoxSearch_Employees"
			Me.SearchableComboBoxSearch_Employees.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.SearchableComboBoxSearch_Employees.Properties.DisplayMember = "Name"
			Me.SearchableComboBoxSearch_Employees.Properties.NullText = "Select Employee"
			Me.SearchableComboBoxSearch_Employees.Properties.ShowClearButton = False
			Me.SearchableComboBoxSearch_Employees.Properties.ValueMember = "Code"
			Me.SearchableComboBoxSearch_Employees.Properties.View = Me.SearchableComboBox1View
			Me.SearchableComboBoxSearch_Employees.SecurityEnabled = True
			Me.SearchableComboBoxSearch_Employees.SelectedValue = Nothing
			Me.SearchableComboBoxSearch_Employees.Size = New System.Drawing.Size(150, 20)
			Me.SearchableComboBoxSearch_Employees.TabIndex = 1
			'
			'SearchableComboBox1View
			'
			Me.SearchableComboBox1View.AFActiveFilterString = ""
			Me.SearchableComboBox1View.AllowExtraItemsInGridLookupEdits = True
			Me.SearchableComboBox1View.AutoFilterLookupColumns = False
			Me.SearchableComboBox1View.AutoloadRepositoryDatasource = True
			Me.SearchableComboBox1View.DataSourceClearing = False
			Me.SearchableComboBox1View.EnableDisabledRows = False
			Me.SearchableComboBox1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
			Me.SearchableComboBox1View.Name = "SearchableComboBox1View"
			Me.SearchableComboBox1View.OptionsSelection.EnableAppearanceFocusedCell = False
			Me.SearchableComboBox1View.OptionsView.ShowGroupPanel = False
			Me.SearchableComboBox1View.RestoredLayoutNonVisibleGridColumnList = Nothing
			Me.SearchableComboBox1View.RunStandardValidation = True
			'
			'ComboBoxSearch_Month
			'
			Me.ComboBoxSearch_Month.AddInactiveItemsOnSelectedValue = False
			Me.ComboBoxSearch_Month.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
			Me.ComboBoxSearch_Month.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBoxSearch_Month.AutoFindItemInDataSource = False
			Me.ComboBoxSearch_Month.AutoSelectSingleItemDatasource = False
			Me.ComboBoxSearch_Month.BookmarkingEnabled = False
			Me.ComboBoxSearch_Month.ClientCode = ""
			Me.ComboBoxSearch_Month.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Month
			Me.ComboBoxSearch_Month.DisableMouseWheel = False
			Me.ComboBoxSearch_Month.DisplayMember = "Value"
			Me.ComboBoxSearch_Month.DisplayName = ""
			Me.ComboBoxSearch_Month.DivisionCode = ""
			Me.ComboBoxSearch_Month.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
			Me.ComboBoxSearch_Month.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.ComboBoxSearch_Month.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
			Me.ComboBoxSearch_Month.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.ComboBoxSearch_Month.FocusHighlightEnabled = True
			Me.ComboBoxSearch_Month.FormattingEnabled = True
			Me.ComboBoxSearch_Month.ItemHeight = 14
			Me.ComboBoxSearch_Month.Location = New System.Drawing.Point(65, 43)
			Me.ComboBoxSearch_Month.Name = "ComboBoxSearch_Month"
			Me.ComboBoxSearch_Month.ReadOnly = False
			Me.ComboBoxSearch_Month.SecurityEnabled = True
			Me.ComboBoxSearch_Month.Size = New System.Drawing.Size(150, 20)
			Me.ComboBoxSearch_Month.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ComboBoxSearch_Month.TabIndex = 1
			Me.ComboBoxSearch_Month.TabOnEnter = True
			Me.ComboBoxSearch_Month.ValueMember = "Key"
			Me.ComboBoxSearch_Month.WatermarkText = "Select Month"
			'
			'ComboBoxSearch_Year
			'
			Me.ComboBoxSearch_Year.AddInactiveItemsOnSelectedValue = False
			Me.ComboBoxSearch_Year.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
			Me.ComboBoxSearch_Year.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBoxSearch_Year.AutoFindItemInDataSource = False
			Me.ComboBoxSearch_Year.AutoSelectSingleItemDatasource = False
			Me.ComboBoxSearch_Year.BookmarkingEnabled = False
			Me.ComboBoxSearch_Year.ClientCode = ""
			Me.ComboBoxSearch_Year.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.ShortNumeric
			Me.ComboBoxSearch_Year.DisableMouseWheel = False
			Me.ComboBoxSearch_Year.DisplayMember = "Number"
			Me.ComboBoxSearch_Year.DisplayName = ""
			Me.ComboBoxSearch_Year.DivisionCode = ""
			Me.ComboBoxSearch_Year.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
			Me.ComboBoxSearch_Year.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.ComboBoxSearch_Year.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
			Me.ComboBoxSearch_Year.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.ComboBoxSearch_Year.FocusHighlightEnabled = True
			Me.ComboBoxSearch_Year.FormattingEnabled = True
			Me.ComboBoxSearch_Year.ItemHeight = 14
			Me.ComboBoxSearch_Year.Location = New System.Drawing.Point(65, 66)
			Me.ComboBoxSearch_Year.Name = "ComboBoxSearch_Year"
			Me.ComboBoxSearch_Year.ReadOnly = False
			Me.ComboBoxSearch_Year.SecurityEnabled = True
			Me.ComboBoxSearch_Year.Size = New System.Drawing.Size(150, 20)
			Me.ComboBoxSearch_Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ComboBoxSearch_Year.TabIndex = 1
			Me.ComboBoxSearch_Year.TabOnEnter = True
			Me.ComboBoxSearch_Year.ValueMember = "Number"
			Me.ComboBoxSearch_Year.WatermarkText = "Select"
			'
			'ItemContainer1
			'
			'
			'
			'
			Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.ItemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
			Me.ItemContainer1.Name = "ItemContainer1"
			Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer4, Me.ItemContainer2, Me.ItemContainer3})
			'
			'
			'
			Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.ItemContainer1.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
			'
			'ItemContainer4
			'
			'
			'
			'
			Me.ItemContainer4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.ItemContainer4.Name = "ItemContainer4"
			Me.ItemContainer4.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemSearch_Employees, Me.ControlContainerItem1})
			'
			'
			'
			Me.ItemContainer4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'LabelItemSearch_Employees
			'
			Me.LabelItemSearch_Employees.Name = "LabelItemSearch_Employees"
			Me.LabelItemSearch_Employees.Text = "Employee:"
			Me.LabelItemSearch_Employees.Width = 58
			'
			'ControlContainerItem1
			'
			Me.ControlContainerItem1.AllowItemResize = True
			Me.ControlContainerItem1.Control = Me.SearchableComboBoxSearch_Employees
			Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
			Me.ControlContainerItem1.Name = "ControlContainerItem1"
			Me.ControlContainerItem1.Text = "ControlContainerItem1"
			'
			'ItemContainer2
			'
			'
			'
			'
			Me.ItemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.ItemContainer2.Name = "ItemContainer2"
			Me.ItemContainer2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemSearch_Month, Me.ControlContainerItemSearch_Month})
			'
			'
			'
			Me.ItemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'LabelItemSearch_Month
			'
			Me.LabelItemSearch_Month.Name = "LabelItemSearch_Month"
			Me.LabelItemSearch_Month.Text = "Month:"
			Me.LabelItemSearch_Month.Width = 58
			'
			'ControlContainerItemSearch_Month
			'
			Me.ControlContainerItemSearch_Month.AllowItemResize = True
			Me.ControlContainerItemSearch_Month.Control = Me.ComboBoxSearch_Month
			Me.ControlContainerItemSearch_Month.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
			Me.ControlContainerItemSearch_Month.Name = "ControlContainerItemSearch_Month"
			Me.ControlContainerItemSearch_Month.Text = "ControlContainerItem2"
			'
			'ItemContainer3
			'
			'
			'
			'
			Me.ItemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.ItemContainer3.Name = "ItemContainer3"
			Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemSearch_Year, Me.ControlContainerItem2})
			'
			'
			'
			Me.ItemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'LabelItemSearch_Year
			'
			Me.LabelItemSearch_Year.Name = "LabelItemSearch_Year"
			Me.LabelItemSearch_Year.Text = "Year: "
			Me.LabelItemSearch_Year.Width = 58
			'
			'ControlContainerItem2
			'
			Me.ControlContainerItem2.AllowItemResize = True
			Me.ControlContainerItem2.Control = Me.ComboBoxSearch_Year
			Me.ControlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
			Me.ControlContainerItem2.Name = "ControlContainerItem2"
			Me.ControlContainerItem2.Text = "ControlContainerItem2"
			'
			'ButtonItemSearch_Search
			'
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
			Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Import, Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Copy, Me.ButtonItemActions_Submit, Me.ButtonItemActions_Unsubmit, Me.ButtonItemActions_Print, Me.ButtonItemActions_ViewReceipts})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
			Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
			Me.RibbonBarOptions_Actions.SecurityEnabled = True
			Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(331, 98)
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
			'ButtonItemActions_Import
			'
			Me.ButtonItemActions_Import.BeginGroup = True
			Me.ButtonItemActions_Import.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Import.Name = "ButtonItemActions_Import"
			Me.ButtonItemActions_Import.RibbonWordWrap = False
			Me.ButtonItemActions_Import.SecurityEnabled = True
			Me.ButtonItemActions_Import.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Import.Text = "Import"
			'
			'ButtonItemActions_Add
			'
			Me.ButtonItemActions_Add.BeginGroup = True
			Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
			Me.ButtonItemActions_Add.RibbonWordWrap = False
			Me.ButtonItemActions_Add.SecurityEnabled = True
			Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Add.Text = "Add"
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
			'ButtonItemActions_Copy
			'
			Me.ButtonItemActions_Copy.BeginGroup = True
			Me.ButtonItemActions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
			Me.ButtonItemActions_Copy.RibbonWordWrap = False
			Me.ButtonItemActions_Copy.SecurityEnabled = True
			Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Copy.Text = "Copy"
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
			'ButtonItemActions_Print
			'
			Me.ButtonItemActions_Print.BeginGroup = True
			Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
			Me.ButtonItemActions_Print.RibbonWordWrap = False
			Me.ButtonItemActions_Print.SecurityEnabled = True
			Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
            '
            'ButtonItemActions_ViewReceipts
            '
            Me.ButtonItemActions_ViewReceipts.BeginGroup = True
            Me.ButtonItemActions_ViewReceipts.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ViewReceipts.Name = "ButtonItemActions_ViewReceipts"
            Me.ButtonItemActions_ViewReceipts.RibbonWordWrap = False
            Me.ButtonItemActions_ViewReceipts.SecurityEnabled = True
            Me.ButtonItemActions_ViewReceipts.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ViewReceipts.Text = "Receipts"
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.ExpenseReportControlRightSection_ExpenseReport)
			Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
			Me.PanelForm_RightSection.Location = New System.Drawing.Point(258, 0)
			Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
			Me.PanelForm_RightSection.Size = New System.Drawing.Size(984, 453)
			Me.PanelForm_RightSection.TabIndex = 8
			'
			'ExpenseReportControlRightSection_ExpenseReport
			'
			Me.ExpenseReportControlRightSection_ExpenseReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ExpenseReportControlRightSection_ExpenseReport.Location = New System.Drawing.Point(6, 12)
			Me.ExpenseReportControlRightSection_ExpenseReport.Name = "ExpenseReportControlRightSection_ExpenseReport"
			Me.ExpenseReportControlRightSection_ExpenseReport.Size = New System.Drawing.Size(966, 429)
			Me.ExpenseReportControlRightSection_ExpenseReport.TabIndex = 0
			'
			'PanelForm_LeftSection
			'
			Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_ExpenseReports)
			Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
			Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
			Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
			Me.PanelForm_LeftSection.Size = New System.Drawing.Size(252, 453)
			Me.PanelForm_LeftSection.TabIndex = 10
			'
			'DataGridViewLeftSection_ExpenseReports
			'
			Me.DataGridViewLeftSection_ExpenseReports.AddFixedColumnCheckItemsToGridMenu = False
			Me.DataGridViewLeftSection_ExpenseReports.AllowDragAndDrop = False
			Me.DataGridViewLeftSection_ExpenseReports.AllowExtraItemsInGridLookupEdits = True
			Me.DataGridViewLeftSection_ExpenseReports.AllowSelectGroupHeaderRow = True
			Me.DataGridViewLeftSection_ExpenseReports.AlwaysForceShowRowSelectionOnUserInput = True
			Me.DataGridViewLeftSection_ExpenseReports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.DataGridViewLeftSection_ExpenseReports.AutoFilterLookupColumns = False
			Me.DataGridViewLeftSection_ExpenseReports.AutoloadRepositoryDatasource = True
			Me.DataGridViewLeftSection_ExpenseReports.AutoUpdateViewCaption = True
			Me.DataGridViewLeftSection_ExpenseReports.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
			Me.DataGridViewLeftSection_ExpenseReports.DataSource = Nothing
			Me.DataGridViewLeftSection_ExpenseReports.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
			Me.DataGridViewLeftSection_ExpenseReports.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
			Me.DataGridViewLeftSection_ExpenseReports.ItemDescription = ""
			Me.DataGridViewLeftSection_ExpenseReports.Location = New System.Drawing.Point(12, 12)
			Me.DataGridViewLeftSection_ExpenseReports.MultiSelect = True
			Me.DataGridViewLeftSection_ExpenseReports.Name = "DataGridViewLeftSection_ExpenseReports"
			Me.DataGridViewLeftSection_ExpenseReports.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
			Me.DataGridViewLeftSection_ExpenseReports.RunStandardValidation = True
			Me.DataGridViewLeftSection_ExpenseReports.ShowColumnMenuOnRightClick = False
			Me.DataGridViewLeftSection_ExpenseReports.ShowSelectDeselectAllButtons = False
			Me.DataGridViewLeftSection_ExpenseReports.Size = New System.Drawing.Size(234, 429)
			Me.DataGridViewLeftSection_ExpenseReports.TabIndex = 2
			Me.DataGridViewLeftSection_ExpenseReports.UseEmbeddedNavigator = False
			Me.DataGridViewLeftSection_ExpenseReports.ViewCaptionHeight = -1
			'
			'ExpandableSplitterControl1
			'
			Me.ExpandableSplitterControl1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
			Me.ExpandableSplitterControl1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
			Me.ExpandableSplitterControl1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
			Me.ExpandableSplitterControl1.ExpandableControl = Me.PanelForm_LeftSection
			Me.ExpandableSplitterControl1.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
			Me.ExpandableSplitterControl1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
			Me.ExpandableSplitterControl1.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
			Me.ExpandableSplitterControl1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
			Me.ExpandableSplitterControl1.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
			Me.ExpandableSplitterControl1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
			Me.ExpandableSplitterControl1.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
			Me.ExpandableSplitterControl1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
			Me.ExpandableSplitterControl1.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
			Me.ExpandableSplitterControl1.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
			Me.ExpandableSplitterControl1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
			Me.ExpandableSplitterControl1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
			Me.ExpandableSplitterControl1.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
			Me.ExpandableSplitterControl1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
			Me.ExpandableSplitterControl1.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
			Me.ExpandableSplitterControl1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
			Me.ExpandableSplitterControl1.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
			Me.ExpandableSplitterControl1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
			Me.ExpandableSplitterControl1.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
			Me.ExpandableSplitterControl1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
			Me.ExpandableSplitterControl1.Location = New System.Drawing.Point(252, 0)
			Me.ExpandableSplitterControl1.Name = "ExpandableSplitterControl1"
			Me.ExpandableSplitterControl1.Size = New System.Drawing.Size(6, 453)
			Me.ExpandableSplitterControl1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
			Me.ExpandableSplitterControl1.TabIndex = 11
			Me.ExpandableSplitterControl1.TabStop = False
			'
			'ButtonItemUpload_EmailLink
			'
			Me.ButtonItemReceiptsUpload_EmailLink.Name = "ButtonItemUpload_EmailLink"
			Me.ButtonItemReceiptsUpload_EmailLink.Text = "Email Link"
			'
			'ExpenseReportSetupForm
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1242, 453)
			Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
			Me.Controls.Add(Me.PanelForm_RightSection)
			Me.Controls.Add(Me.ExpandableSplitterControl1)
			Me.Controls.Add(Me.PanelForm_LeftSection)
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "ExpenseReportSetupForm"
			Me.Text = "Expense Reports"
			Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
			Me.RibbonBarOptions_Search.ResumeLayout(False)
			CType(Me.SearchableComboBoxSearch_Employees.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
			Me.PanelForm_RightSection.ResumeLayout(False)
			CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
			Me.PanelForm_LeftSection.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_ExpenseReports As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ExpenseReportControlRightSection_ExpenseReport As AdvantageFramework.WinForm.Presentation.Controls.ExpenseReportControl
        Friend WithEvents ButtonItemActions_Copy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Submit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Unsubmit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Receipts As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemReceipts_Upload As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemReceipts_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Items As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemItems_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemItems_Copy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemItems_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemItems_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Search As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainer2 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSearch_Month As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSearch_Year As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ButtonItemSearch_Search As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Import As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemReceipts_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainer4 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSearch_Employees As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ExpandableSplitterControl1 As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_ViewReceipts As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ComboBoxSearch_Month As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxSearch_Year As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ControlContainerItemSearch_Month As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ControlContainerItem2 As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemItems_Documents As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Filter As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemFilter_All As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemFilter_SelectedLineItem As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents SearchableComboBoxSearch_Employees As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBox1View As AdvantageFramework.WinForm.Presentation.Controls.GridView
		Friend WithEvents ButtonItemReceiptsUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
	End Class

End Namespace

