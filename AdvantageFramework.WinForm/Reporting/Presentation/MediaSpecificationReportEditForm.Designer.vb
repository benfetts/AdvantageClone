Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaSpecificationReportEditForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaSpecificationReportEditForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Filter = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemFilter_ShowFilterEditor = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemFilter_ShowAutoFilterRow = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerView_ViewLeft = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemViewLeft_AllowCellMerging = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemViewLeft_ShowViewCaption = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemViewLeft_ShowGroupByBox = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_QuickCustomize = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemQuickCustomize_Columns = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Report = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemReport_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReport_SaveAs = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBox_ReportType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxTemplates_Templates = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxCriteria_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DateTimePickerDateFrom_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerDateTo_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ItemContainerSearch_ReportType = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemReportType = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItem_ReportType = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerActions_Templates = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemTemplates_Templates = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemTemplates_Templates = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerActions_Search = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerSearch_Criteria = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemCriteria_Criteria = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemCriteria_Criteria = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerSearch_DateFrom = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemDateFrom_From = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemDateFrom_DateFrom = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemDateFrom_YTD = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDateFrom_1Year = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerSearch_DateTo = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemDateTo_To = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemDateTo_DateTo = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemDateTo_MTD = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDateTo_2Years = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_AcceptedOnly = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_View = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewForm_JobVersionReport = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Printing = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarPrinting_Options = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerOptions_OptionsLeft = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOptionsLeft_PrintFilterInfo = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerOptions_OptionsMiddle = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemOptionsMiddle_PrintHeader = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOptionsMiddle_PrintFooter = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOptionsMiddle_PrintGroupFooter = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerOptions_OptionsRight = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemOptionsRight_PrintSelectedRowsOnly = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarPrinting_Printing = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPrinting_Print = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBarOptions_Actions.SuspendLayout()
            CType(Me.DateTimePickerDateFrom_From, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerDateTo_To, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarMergeContainerForm_Printing.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Filter)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_QuickCustomize)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Report)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 12)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "Report"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1132, 113)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 1
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
            Me.RibbonBarOptions_Filter.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFilter_ShowFilterEditor, Me.ButtonItemFilter_ShowAutoFilterRow})
            Me.RibbonBarOptions_Filter.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_Filter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Filter.Location = New System.Drawing.Point(1001, 0)
            Me.RibbonBarOptions_Filter.Name = "RibbonBarOptions_Filter"
            Me.RibbonBarOptions_Filter.SecurityEnabled = True
            Me.RibbonBarOptions_Filter.Size = New System.Drawing.Size(120, 113)
            Me.RibbonBarOptions_Filter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Filter.TabIndex = 6
            Me.RibbonBarOptions_Filter.Text = "Filter"
            '
            '
            '
            Me.RibbonBarOptions_Filter.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Filter.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemFilter_ShowFilterEditor
            '
            Me.ButtonItemFilter_ShowFilterEditor.Name = "ButtonItemFilter_ShowFilterEditor"
            Me.ButtonItemFilter_ShowFilterEditor.SubItemsExpandWidth = 14
            Me.ButtonItemFilter_ShowFilterEditor.Text = "Show Filter Editor"
            '
            'ButtonItemFilter_ShowAutoFilterRow
            '
            Me.ButtonItemFilter_ShowAutoFilterRow.AutoCheckOnClick = True
            Me.ButtonItemFilter_ShowAutoFilterRow.Name = "ButtonItemFilter_ShowAutoFilterRow"
            Me.ButtonItemFilter_ShowAutoFilterRow.Stretch = True
            Me.ButtonItemFilter_ShowAutoFilterRow.SubItemsExpandWidth = 14
            Me.ButtonItemFilter_ShowAutoFilterRow.Text = "Show Auto Filter Row"
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
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerView_ViewLeft})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(888, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(113, 113)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 5
            Me.RibbonBarOptions_View.Text = "View"
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerView_ViewLeft
            '
            '
            '
            '
            Me.ItemContainerView_ViewLeft.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerView_ViewLeft.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerView_ViewLeft.Name = "ItemContainerView_ViewLeft"
            Me.ItemContainerView_ViewLeft.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemViewLeft_AllowCellMerging, Me.ButtonItemViewLeft_ShowViewCaption, Me.ButtonItemViewLeft_ShowGroupByBox})
            '
            '
            '
            Me.ItemContainerView_ViewLeft.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerView_ViewLeft.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemViewLeft_AllowCellMerging
            '
            Me.ButtonItemViewLeft_AllowCellMerging.AutoCheckOnClick = True
            Me.ButtonItemViewLeft_AllowCellMerging.Name = "ButtonItemViewLeft_AllowCellMerging"
            Me.ButtonItemViewLeft_AllowCellMerging.Stretch = True
            Me.ButtonItemViewLeft_AllowCellMerging.SubItemsExpandWidth = 14
            Me.ButtonItemViewLeft_AllowCellMerging.Text = "Allow Cell Merging"
            '
            'ButtonItemViewLeft_ShowViewCaption
            '
            Me.ButtonItemViewLeft_ShowViewCaption.AutoCheckOnClick = True
            Me.ButtonItemViewLeft_ShowViewCaption.Checked = True
            Me.ButtonItemViewLeft_ShowViewCaption.Name = "ButtonItemViewLeft_ShowViewCaption"
            Me.ButtonItemViewLeft_ShowViewCaption.SubItemsExpandWidth = 14
            Me.ButtonItemViewLeft_ShowViewCaption.Text = "Show View Caption"
            '
            'ButtonItemViewLeft_ShowGroupByBox
            '
            Me.ButtonItemViewLeft_ShowGroupByBox.AutoCheckOnClick = True
            Me.ButtonItemViewLeft_ShowGroupByBox.Name = "ButtonItemViewLeft_ShowGroupByBox"
            Me.ButtonItemViewLeft_ShowGroupByBox.Stretch = True
            Me.ButtonItemViewLeft_ShowGroupByBox.SubItemsExpandWidth = 14
            Me.ButtonItemViewLeft_ShowGroupByBox.Text = "Show Group By Box"
            '
            'RibbonBarOptions_QuickCustomize
            '
            Me.RibbonBarOptions_QuickCustomize.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_QuickCustomize.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_QuickCustomize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_QuickCustomize.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_QuickCustomize.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_QuickCustomize.DragDropSupport = True
            Me.RibbonBarOptions_QuickCustomize.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_QuickCustomize.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemQuickCustomize_Columns})
            Me.RibbonBarOptions_QuickCustomize.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_QuickCustomize.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_QuickCustomize.Location = New System.Drawing.Point(788, 0)
            Me.RibbonBarOptions_QuickCustomize.MinimumSize = New System.Drawing.Size(90, 0)
            Me.RibbonBarOptions_QuickCustomize.Name = "RibbonBarOptions_QuickCustomize"
            Me.RibbonBarOptions_QuickCustomize.SecurityEnabled = True
            Me.RibbonBarOptions_QuickCustomize.Size = New System.Drawing.Size(100, 113)
            Me.RibbonBarOptions_QuickCustomize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_QuickCustomize.TabIndex = 4
            Me.RibbonBarOptions_QuickCustomize.Text = "Quick Customize"
            '
            '
            '
            Me.RibbonBarOptions_QuickCustomize.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_QuickCustomize.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemQuickCustomize_Columns
            '
            Me.ButtonItemQuickCustomize_Columns.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemQuickCustomize_Columns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemQuickCustomize_Columns.Name = "ButtonItemQuickCustomize_Columns"
            Me.ButtonItemQuickCustomize_Columns.SubItemsExpandWidth = 14
            Me.ButtonItemQuickCustomize_Columns.Text = "Columns"
            '
            'RibbonBarOptions_Report
            '
            Me.RibbonBarOptions_Report.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Report.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Report.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Report.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Report.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Report.DragDropSupport = True
            Me.RibbonBarOptions_Report.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Report.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReport_Save, Me.ButtonItemReport_SaveAs})
            Me.RibbonBarOptions_Report.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Report.Location = New System.Drawing.Point(688, 0)
            Me.RibbonBarOptions_Report.Name = "RibbonBarOptions_Report"
            Me.RibbonBarOptions_Report.SecurityEnabled = True
            Me.RibbonBarOptions_Report.Size = New System.Drawing.Size(100, 113)
            Me.RibbonBarOptions_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Report.TabIndex = 7
            Me.RibbonBarOptions_Report.Text = "Report"
            '
            '
            '
            Me.RibbonBarOptions_Report.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Report.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemReport_Save
            '
            Me.ButtonItemReport_Save.BeginGroup = True
            Me.ButtonItemReport_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReport_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReport_Save.Name = "ButtonItemReport_Save"
            Me.ButtonItemReport_Save.RibbonWordWrap = False
            Me.ButtonItemReport_Save.SubItemsExpandWidth = 14
            Me.ButtonItemReport_Save.Text = "Save"
            '
            'ButtonItemReport_SaveAs
            '
            Me.ButtonItemReport_SaveAs.BeginGroup = True
            Me.ButtonItemReport_SaveAs.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReport_SaveAs.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReport_SaveAs.Name = "ButtonItemReport_SaveAs"
            Me.ButtonItemReport_SaveAs.RibbonWordWrap = False
            Me.ButtonItemReport_SaveAs.SubItemsExpandWidth = 14
            Me.ButtonItemReport_SaveAs.Text = "Save As..."
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
            Me.RibbonBarOptions_Actions.Controls.Add(Me.ComboBox_ReportType)
            Me.RibbonBarOptions_Actions.Controls.Add(Me.ComboBoxTemplates_Templates)
            Me.RibbonBarOptions_Actions.Controls.Add(Me.ComboBoxCriteria_Criteria)
            Me.RibbonBarOptions_Actions.Controls.Add(Me.DateTimePickerDateFrom_From)
            Me.RibbonBarOptions_Actions.Controls.Add(Me.DateTimePickerDateTo_To)
            Me.RibbonBarOptions_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSearch_ReportType, Me.ItemContainerActions_Templates, Me.ItemContainerActions_Search, Me.ButtonItemActions_AcceptedOnly, Me.ButtonItemActions_View})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(688, 113)
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
            'ComboBox_ReportType
            '
            Me.ComboBox_ReportType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBox_ReportType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBox_ReportType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBox_ReportType.AutoFindItemInDataSource = False
            Me.ComboBox_ReportType.AutoSelectSingleItemDatasource = False
            Me.ComboBox_ReportType.BookmarkingEnabled = False
            Me.ComboBox_ReportType.ClientCode = ""
            Me.ComboBox_ReportType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBox_ReportType.DisableMouseWheel = False
            Me.ComboBox_ReportType.DisplayMember = "Name"
            Me.ComboBox_ReportType.DisplayName = ""
            Me.ComboBox_ReportType.DivisionCode = ""
            Me.ComboBox_ReportType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBox_ReportType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBox_ReportType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBox_ReportType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBox_ReportType.FocusHighlightEnabled = True
            Me.ComboBox_ReportType.FormattingEnabled = True
            Me.ComboBox_ReportType.ItemHeight = 14
            Me.ComboBox_ReportType.Location = New System.Drawing.Point(52, 18)
            Me.ComboBox_ReportType.Name = "ComboBox_ReportType"
            Me.ComboBox_ReportType.ReadOnly = False
            Me.ComboBox_ReportType.SecurityEnabled = True
            Me.ComboBox_ReportType.Size = New System.Drawing.Size(200, 20)
            Me.ComboBox_ReportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBox_ReportType.TabIndex = 1
            Me.ComboBox_ReportType.TabOnEnter = True
            Me.ComboBox_ReportType.ValueMember = "Value"
            Me.ComboBox_ReportType.WatermarkText = "Select"
            '
            'ComboBoxTemplates_Templates
            '
            Me.ComboBoxTemplates_Templates.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxTemplates_Templates.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxTemplates_Templates.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxTemplates_Templates.AutoFindItemInDataSource = False
            Me.ComboBoxTemplates_Templates.AutoSelectSingleItemDatasource = False
            Me.ComboBoxTemplates_Templates.BookmarkingEnabled = False
            Me.ComboBoxTemplates_Templates.ClientCode = ""
            Me.ComboBoxTemplates_Templates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.JobVersionTemplate
            Me.ComboBoxTemplates_Templates.DisableMouseWheel = False
            Me.ComboBoxTemplates_Templates.DisplayMember = "Name"
            Me.ComboBoxTemplates_Templates.DisplayName = ""
            Me.ComboBoxTemplates_Templates.DivisionCode = ""
            Me.ComboBoxTemplates_Templates.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxTemplates_Templates.Enabled = False
            Me.ComboBoxTemplates_Templates.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxTemplates_Templates.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxTemplates_Templates.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxTemplates_Templates.FocusHighlightEnabled = True
            Me.ComboBoxTemplates_Templates.FormattingEnabled = True
            Me.ComboBoxTemplates_Templates.ItemHeight = 14
            Me.ComboBoxTemplates_Templates.Location = New System.Drawing.Point(294, 18)
            Me.ComboBoxTemplates_Templates.Name = "ComboBoxTemplates_Templates"
            Me.ComboBoxTemplates_Templates.ReadOnly = False
            Me.ComboBoxTemplates_Templates.SecurityEnabled = True
            Me.ComboBoxTemplates_Templates.Size = New System.Drawing.Size(150, 20)
            Me.ComboBoxTemplates_Templates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxTemplates_Templates.TabIndex = 0
            Me.ComboBoxTemplates_Templates.TabOnEnter = True
            Me.ComboBoxTemplates_Templates.ValueMember = "Value"
            Me.ComboBoxTemplates_Templates.WatermarkText = "Select Job Version Template"
            '
            'ComboBoxCriteria_Criteria
            '
            Me.ComboBoxCriteria_Criteria.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxCriteria_Criteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxCriteria_Criteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxCriteria_Criteria.AutoFindItemInDataSource = False
            Me.ComboBoxCriteria_Criteria.AutoSelectSingleItemDatasource = False
            Me.ComboBoxCriteria_Criteria.BookmarkingEnabled = False
            Me.ComboBoxCriteria_Criteria.ClientCode = ""
            Me.ComboBoxCriteria_Criteria.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxCriteria_Criteria.DisableMouseWheel = False
            Me.ComboBoxCriteria_Criteria.DisplayMember = "Name"
            Me.ComboBoxCriteria_Criteria.DisplayName = ""
            Me.ComboBoxCriteria_Criteria.DivisionCode = ""
            Me.ComboBoxCriteria_Criteria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxCriteria_Criteria.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxCriteria_Criteria.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxCriteria_Criteria.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxCriteria_Criteria.FocusHighlightEnabled = True
            Me.ComboBoxCriteria_Criteria.FormattingEnabled = True
            Me.ComboBoxCriteria_Criteria.ItemHeight = 14
            Me.ComboBoxCriteria_Criteria.Location = New System.Drawing.Point(495, 18)
            Me.ComboBoxCriteria_Criteria.Name = "ComboBoxCriteria_Criteria"
            Me.ComboBoxCriteria_Criteria.ReadOnly = False
            Me.ComboBoxCriteria_Criteria.SecurityEnabled = True
            Me.ComboBoxCriteria_Criteria.Size = New System.Drawing.Size(175, 20)
            Me.ComboBoxCriteria_Criteria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxCriteria_Criteria.TabIndex = 1
            Me.ComboBoxCriteria_Criteria.TabOnEnter = True
            Me.ComboBoxCriteria_Criteria.ValueMember = "Value"
            Me.ComboBoxCriteria_Criteria.WatermarkText = "Select"
            '
            'DateTimePickerDateFrom_From
            '
            Me.DateTimePickerDateFrom_From.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerDateFrom_From.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerDateFrom_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDateFrom_From.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerDateFrom_From.ButtonDropDown.Visible = True
            Me.DateTimePickerDateFrom_From.ButtonFreeText.Checked = True
            Me.DateTimePickerDateFrom_From.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerDateFrom_From.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerDateFrom_From.DisplayName = ""
            Me.DateTimePickerDateFrom_From.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerDateFrom_From.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerDateFrom_From.FocusHighlightEnabled = True
            Me.DateTimePickerDateFrom_From.FreeTextEntryMode = True
            Me.DateTimePickerDateFrom_From.IsPopupCalendarOpen = False
            Me.DateTimePickerDateFrom_From.Location = New System.Drawing.Point(495, 39)
            Me.DateTimePickerDateFrom_From.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerDateFrom_From.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerDateFrom_From.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDateFrom_From.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerDateFrom_From.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerDateFrom_From.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerDateFrom_From.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDateFrom_From.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerDateFrom_From.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerDateFrom_From.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerDateFrom_From.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerDateFrom_From.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDateFrom_From.MonthCalendar.DisplayMonth = New Date(2012, 12, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerDateFrom_From.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerDateFrom_From.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDateFrom_From.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerDateFrom_From.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDateFrom_From.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerDateFrom_From.Name = "DateTimePickerDateFrom_From"
            Me.DateTimePickerDateFrom_From.ReadOnly = False
            Me.DateTimePickerDateFrom_From.Size = New System.Drawing.Size(100, 20)
            Me.DateTimePickerDateFrom_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDateFrom_From.TabIndex = 2
            Me.DateTimePickerDateFrom_From.TabOnEnter = True
            Me.DateTimePickerDateFrom_From.Value = New Date(2013, 5, 17, 10, 44, 4, 97)
            '
            'DateTimePickerDateTo_To
            '
            Me.DateTimePickerDateTo_To.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerDateTo_To.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerDateTo_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDateTo_To.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerDateTo_To.ButtonDropDown.Visible = True
            Me.DateTimePickerDateTo_To.ButtonFreeText.Checked = True
            Me.DateTimePickerDateTo_To.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerDateTo_To.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerDateTo_To.DisplayName = ""
            Me.DateTimePickerDateTo_To.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerDateTo_To.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerDateTo_To.FocusHighlightEnabled = True
            Me.DateTimePickerDateTo_To.FreeTextEntryMode = True
            Me.DateTimePickerDateTo_To.IsPopupCalendarOpen = False
            Me.DateTimePickerDateTo_To.Location = New System.Drawing.Point(495, 61)
            Me.DateTimePickerDateTo_To.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerDateTo_To.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerDateTo_To.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDateTo_To.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerDateTo_To.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerDateTo_To.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerDateTo_To.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDateTo_To.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerDateTo_To.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerDateTo_To.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerDateTo_To.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerDateTo_To.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDateTo_To.MonthCalendar.DisplayMonth = New Date(2012, 12, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerDateTo_To.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerDateTo_To.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDateTo_To.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerDateTo_To.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDateTo_To.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerDateTo_To.Name = "DateTimePickerDateTo_To"
            Me.DateTimePickerDateTo_To.ReadOnly = False
            Me.DateTimePickerDateTo_To.Size = New System.Drawing.Size(100, 20)
            Me.DateTimePickerDateTo_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDateTo_To.TabIndex = 3
            Me.DateTimePickerDateTo_To.TabOnEnter = True
            Me.DateTimePickerDateTo_To.Value = New Date(2013, 5, 17, 10, 44, 4, 117)
            '
            'ItemContainerSearch_ReportType
            '
            '
            '
            '
            Me.ItemContainerSearch_ReportType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_ReportType.Name = "ItemContainerSearch_ReportType"
            Me.ItemContainerSearch_ReportType.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemReportType, Me.ControlContainerItem_ReportType})
            '
            '
            '
            Me.ItemContainerSearch_ReportType.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSearch_ReportType.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemReportType
            '
            Me.LabelItemReportType.Name = "LabelItemReportType"
            Me.LabelItemReportType.PaddingBottom = 4
            Me.LabelItemReportType.PaddingTop = 4
            Me.LabelItemReportType.Text = "Report:"
            Me.LabelItemReportType.Width = 45
            '
            'ControlContainerItem_ReportType
            '
            Me.ControlContainerItem_ReportType.AllowItemResize = True
            Me.ControlContainerItem_ReportType.Control = Me.ComboBox_ReportType
            Me.ControlContainerItem_ReportType.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItem_ReportType.Name = "ControlContainerItem_ReportType"
            '
            'ItemContainerActions_Templates
            '
            '
            '
            '
            Me.ItemContainerActions_Templates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerActions_Templates.BeginGroup = True
            Me.ItemContainerActions_Templates.Name = "ItemContainerActions_Templates"
            Me.ItemContainerActions_Templates.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemTemplates_Templates, Me.ControlContainerItemTemplates_Templates})
            '
            '
            '
            Me.ItemContainerActions_Templates.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerActions_Templates.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemTemplates_Templates
            '
            Me.LabelItemTemplates_Templates.Name = "LabelItemTemplates_Templates"
            Me.LabelItemTemplates_Templates.PaddingBottom = 4
            Me.LabelItemTemplates_Templates.PaddingTop = 4
            Me.LabelItemTemplates_Templates.Text = "Status:"
            '
            'ControlContainerItemTemplates_Templates
            '
            Me.ControlContainerItemTemplates_Templates.AllowItemResize = True
            Me.ControlContainerItemTemplates_Templates.Control = Me.ComboBoxTemplates_Templates
            Me.ControlContainerItemTemplates_Templates.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemTemplates_Templates.Name = "ControlContainerItemTemplates_Templates"
            '
            'ItemContainerActions_Search
            '
            '
            '
            '
            Me.ItemContainerActions_Search.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerActions_Search.BeginGroup = True
            Me.ItemContainerActions_Search.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerActions_Search.Name = "ItemContainerActions_Search"
            Me.ItemContainerActions_Search.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSearch_Criteria, Me.ItemContainerSearch_DateFrom, Me.ItemContainerSearch_DateTo})
            '
            '
            '
            Me.ItemContainerActions_Search.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerActions_Search.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerSearch_Criteria
            '
            '
            '
            '
            Me.ItemContainerSearch_Criteria.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_Criteria.Name = "ItemContainerSearch_Criteria"
            Me.ItemContainerSearch_Criteria.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemCriteria_Criteria, Me.ControlContainerItemCriteria_Criteria})
            '
            '
            '
            Me.ItemContainerSearch_Criteria.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSearch_Criteria.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemCriteria_Criteria
            '
            Me.LabelItemCriteria_Criteria.Name = "LabelItemCriteria_Criteria"
            Me.LabelItemCriteria_Criteria.PaddingBottom = 4
            Me.LabelItemCriteria_Criteria.PaddingTop = 4
            Me.LabelItemCriteria_Criteria.Text = "Criteria:"
            Me.LabelItemCriteria_Criteria.Width = 45
            '
            'ControlContainerItemCriteria_Criteria
            '
            Me.ControlContainerItemCriteria_Criteria.AllowItemResize = True
            Me.ControlContainerItemCriteria_Criteria.Control = Me.ComboBoxCriteria_Criteria
            Me.ControlContainerItemCriteria_Criteria.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemCriteria_Criteria.Name = "ControlContainerItemCriteria_Criteria"
            '
            'ItemContainerSearch_DateFrom
            '
            '
            '
            '
            Me.ItemContainerSearch_DateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_DateFrom.Name = "ItemContainerSearch_DateFrom"
            Me.ItemContainerSearch_DateFrom.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemDateFrom_From, Me.ControlContainerItemDateFrom_DateFrom, Me.ButtonItemDateFrom_YTD, Me.ButtonItemDateFrom_1Year})
            '
            '
            '
            Me.ItemContainerSearch_DateFrom.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSearch_DateFrom.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemDateFrom_From
            '
            Me.LabelItemDateFrom_From.Name = "LabelItemDateFrom_From"
            Me.LabelItemDateFrom_From.PaddingBottom = 4
            Me.LabelItemDateFrom_From.PaddingTop = 4
            Me.LabelItemDateFrom_From.Text = "From:"
            Me.LabelItemDateFrom_From.Width = 45
            '
            'ControlContainerItemDateFrom_DateFrom
            '
            Me.ControlContainerItemDateFrom_DateFrom.AllowItemResize = True
            Me.ControlContainerItemDateFrom_DateFrom.Control = Me.DateTimePickerDateFrom_From
            Me.ControlContainerItemDateFrom_DateFrom.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemDateFrom_DateFrom.Name = "ControlContainerItemDateFrom_DateFrom"
            '
            'ButtonItemDateFrom_YTD
            '
            Me.ButtonItemDateFrom_YTD.BeginGroup = True
            Me.ButtonItemDateFrom_YTD.Name = "ButtonItemDateFrom_YTD"
            Me.ButtonItemDateFrom_YTD.Text = "YTD"
            '
            'ButtonItemDateFrom_1Year
            '
            Me.ButtonItemDateFrom_1Year.BeginGroup = True
            Me.ButtonItemDateFrom_1Year.Name = "ButtonItemDateFrom_1Year"
            Me.ButtonItemDateFrom_1Year.Text = "1 Year"
            '
            'ItemContainerSearch_DateTo
            '
            '
            '
            '
            Me.ItemContainerSearch_DateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_DateTo.Name = "ItemContainerSearch_DateTo"
            Me.ItemContainerSearch_DateTo.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemDateTo_To, Me.ControlContainerItemDateTo_DateTo, Me.ButtonItemDateTo_MTD, Me.ButtonItemDateTo_2Years})
            '
            '
            '
            Me.ItemContainerSearch_DateTo.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSearch_DateTo.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemDateTo_To
            '
            Me.LabelItemDateTo_To.Name = "LabelItemDateTo_To"
            Me.LabelItemDateTo_To.PaddingBottom = 4
            Me.LabelItemDateTo_To.PaddingTop = 4
            Me.LabelItemDateTo_To.Text = "To: "
            Me.LabelItemDateTo_To.Width = 45
            '
            'ControlContainerItemDateTo_DateTo
            '
            Me.ControlContainerItemDateTo_DateTo.AllowItemResize = True
            Me.ControlContainerItemDateTo_DateTo.Control = Me.DateTimePickerDateTo_To
            Me.ControlContainerItemDateTo_DateTo.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemDateTo_DateTo.Name = "ControlContainerItemDateTo_DateTo"
            '
            'ButtonItemDateTo_MTD
            '
            Me.ButtonItemDateTo_MTD.BeginGroup = True
            Me.ButtonItemDateTo_MTD.Name = "ButtonItemDateTo_MTD"
            Me.ButtonItemDateTo_MTD.Text = "MTD"
            '
            'ButtonItemDateTo_2Years
            '
            Me.ButtonItemDateTo_2Years.BeginGroup = True
            Me.ButtonItemDateTo_2Years.Name = "ButtonItemDateTo_2Years"
            Me.ButtonItemDateTo_2Years.Text = "2 Years"
            '
            'ButtonItemActions_AcceptedOnly
            '
            Me.ButtonItemActions_AcceptedOnly.AutoCheckOnClick = True
            Me.ButtonItemActions_AcceptedOnly.BeginGroup = True
            Me.ButtonItemActions_AcceptedOnly.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_AcceptedOnly.Name = "ButtonItemActions_AcceptedOnly"
            Me.ButtonItemActions_AcceptedOnly.RibbonWordWrap = False
            Me.ButtonItemActions_AcceptedOnly.SubItemsExpandWidth = 14
            Me.ButtonItemActions_AcceptedOnly.Text = "Accepted Only"
            '
            'ButtonItemActions_View
            '
            Me.ButtonItemActions_View.BeginGroup = True
            Me.ButtonItemActions_View.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_View.Name = "ButtonItemActions_View"
            Me.ButtonItemActions_View.RibbonWordWrap = False
            Me.ButtonItemActions_View.SubItemsExpandWidth = 14
            Me.ButtonItemActions_View.Text = "View"
            '
            'DataGridViewForm_JobVersionReport
            '
            Me.DataGridViewForm_JobVersionReport.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_JobVersionReport.AllowDragAndDrop = False
            Me.DataGridViewForm_JobVersionReport.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_JobVersionReport.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_JobVersionReport.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_JobVersionReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_JobVersionReport.AutoFilterLookupColumns = False
            Me.DataGridViewForm_JobVersionReport.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_JobVersionReport.AutoUpdateViewCaption = True
            Me.DataGridViewForm_JobVersionReport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.DynamicReport
            Me.DataGridViewForm_JobVersionReport.DataSource = Nothing
            Me.DataGridViewForm_JobVersionReport.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_JobVersionReport.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_JobVersionReport.ItemDescription = ""
            Me.DataGridViewForm_JobVersionReport.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_JobVersionReport.MultiSelect = True
            Me.DataGridViewForm_JobVersionReport.Name = "DataGridViewForm_JobVersionReport"
            Me.DataGridViewForm_JobVersionReport.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_JobVersionReport.RunStandardValidation = True
            Me.DataGridViewForm_JobVersionReport.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_JobVersionReport.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_JobVersionReport.Size = New System.Drawing.Size(1132, 408)
            Me.DataGridViewForm_JobVersionReport.TabIndex = 2
            Me.DataGridViewForm_JobVersionReport.UseEmbeddedNavigator = False
            Me.DataGridViewForm_JobVersionReport.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Printing
            '
            Me.RibbonBarMergeContainerForm_Printing.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Printing.Controls.Add(Me.RibbonBarPrinting_Options)
            Me.RibbonBarMergeContainerForm_Printing.Controls.Add(Me.RibbonBarPrinting_Printing)
            Me.RibbonBarMergeContainerForm_Printing.Location = New System.Drawing.Point(218, 167)
            Me.RibbonBarMergeContainerForm_Printing.MergeRibbonGroupName = "Report"
            Me.RibbonBarMergeContainerForm_Printing.Name = "RibbonBarMergeContainerForm_Printing"
            Me.RibbonBarMergeContainerForm_Printing.RibbonTabText = "Printing"
            Me.RibbonBarMergeContainerForm_Printing.Size = New System.Drawing.Size(720, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Printing.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Printing.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Printing.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Printing.TabIndex = 0
            Me.RibbonBarMergeContainerForm_Printing.Visible = False
            '
            'RibbonBarPrinting_Options
            '
            Me.RibbonBarPrinting_Options.AutoOverflowEnabled = False
            Me.RibbonBarPrinting_Options.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarPrinting_Options.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPrinting_Options.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarPrinting_Options.ContainerControlProcessDialogKey = True
            Me.RibbonBarPrinting_Options.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarPrinting_Options.DragDropSupport = True
            Me.RibbonBarPrinting_Options.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerOptions_OptionsLeft, Me.ItemContainerOptions_OptionsMiddle, Me.ItemContainerOptions_OptionsRight})
            Me.RibbonBarPrinting_Options.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarPrinting_Options.Location = New System.Drawing.Point(100, 0)
            Me.RibbonBarPrinting_Options.Name = "RibbonBarPrinting_Options"
            Me.RibbonBarPrinting_Options.SecurityEnabled = True
            Me.RibbonBarPrinting_Options.Size = New System.Drawing.Size(382, 98)
            Me.RibbonBarPrinting_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarPrinting_Options.TabIndex = 3
            Me.RibbonBarPrinting_Options.Text = "Options"
            '
            '
            '
            Me.RibbonBarPrinting_Options.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPrinting_Options.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerOptions_OptionsLeft
            '
            '
            '
            '
            Me.ItemContainerOptions_OptionsLeft.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerOptions_OptionsLeft.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerOptions_OptionsLeft.Name = "ItemContainerOptions_OptionsLeft"
            Me.ItemContainerOptions_OptionsLeft.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage, Me.ButtonItemOptionsLeft_PrintFilterInfo})
            '
            '
            '
            Me.ItemContainerOptions_OptionsLeft.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerOptions_OptionsLeft.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemOptionsLeft_AutoSizeColumnsToPage
            '
            Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage.AutoCheckOnClick = True
            Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked = True
            Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage.Name = "ButtonItemOptionsLeft_AutoSizeColumnsToPage"
            Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage.Text = "Auto Size Columns To Page"
            '
            'ButtonItemOptionsLeft_PrintFilterInfo
            '
            Me.ButtonItemOptionsLeft_PrintFilterInfo.AutoCheckOnClick = True
            Me.ButtonItemOptionsLeft_PrintFilterInfo.Name = "ButtonItemOptionsLeft_PrintFilterInfo"
            Me.ButtonItemOptionsLeft_PrintFilterInfo.Text = "Print Filter Info"
            '
            'ItemContainerOptions_OptionsMiddle
            '
            '
            '
            '
            Me.ItemContainerOptions_OptionsMiddle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerOptions_OptionsMiddle.BeginGroup = True
            Me.ItemContainerOptions_OptionsMiddle.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerOptions_OptionsMiddle.Name = "ItemContainerOptions_OptionsMiddle"
            Me.ItemContainerOptions_OptionsMiddle.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptionsMiddle_PrintHeader, Me.ButtonItemOptionsMiddle_PrintFooter, Me.ButtonItemOptionsMiddle_PrintGroupFooter})
            '
            '
            '
            Me.ItemContainerOptions_OptionsMiddle.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerOptions_OptionsMiddle.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemOptionsMiddle_PrintHeader
            '
            Me.ButtonItemOptionsMiddle_PrintHeader.AutoCheckOnClick = True
            Me.ButtonItemOptionsMiddle_PrintHeader.Checked = True
            Me.ButtonItemOptionsMiddle_PrintHeader.Name = "ButtonItemOptionsMiddle_PrintHeader"
            Me.ButtonItemOptionsMiddle_PrintHeader.Text = "Print Header"
            '
            'ButtonItemOptionsMiddle_PrintFooter
            '
            Me.ButtonItemOptionsMiddle_PrintFooter.AutoCheckOnClick = True
            Me.ButtonItemOptionsMiddle_PrintFooter.Checked = True
            Me.ButtonItemOptionsMiddle_PrintFooter.Name = "ButtonItemOptionsMiddle_PrintFooter"
            Me.ButtonItemOptionsMiddle_PrintFooter.Text = "Print Footer"
            '
            'ButtonItemOptionsMiddle_PrintGroupFooter
            '
            Me.ButtonItemOptionsMiddle_PrintGroupFooter.AutoCheckOnClick = True
            Me.ButtonItemOptionsMiddle_PrintGroupFooter.Checked = True
            Me.ButtonItemOptionsMiddle_PrintGroupFooter.Name = "ButtonItemOptionsMiddle_PrintGroupFooter"
            Me.ButtonItemOptionsMiddle_PrintGroupFooter.Text = "Print Group Footer"
            '
            'ItemContainerOptions_OptionsRight
            '
            '
            '
            '
            Me.ItemContainerOptions_OptionsRight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerOptions_OptionsRight.BeginGroup = True
            Me.ItemContainerOptions_OptionsRight.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerOptions_OptionsRight.Name = "ItemContainerOptions_OptionsRight"
            Me.ItemContainerOptions_OptionsRight.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptionsRight_PrintSelectedRowsOnly})
            '
            '
            '
            Me.ItemContainerOptions_OptionsRight.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerOptions_OptionsRight.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemOptionsRight_PrintSelectedRowsOnly
            '
            Me.ButtonItemOptionsRight_PrintSelectedRowsOnly.AutoCheckOnClick = True
            Me.ButtonItemOptionsRight_PrintSelectedRowsOnly.Name = "ButtonItemOptionsRight_PrintSelectedRowsOnly"
            Me.ButtonItemOptionsRight_PrintSelectedRowsOnly.Text = "Print Selected Rows Only"
            '
            'RibbonBarPrinting_Printing
            '
            Me.RibbonBarPrinting_Printing.AutoOverflowEnabled = False
            Me.RibbonBarPrinting_Printing.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarPrinting_Printing.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPrinting_Printing.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarPrinting_Printing.ContainerControlProcessDialogKey = True
            Me.RibbonBarPrinting_Printing.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarPrinting_Printing.DragDropSupport = True
            Me.RibbonBarPrinting_Printing.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarPrinting_Printing.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPrinting_Print})
            Me.RibbonBarPrinting_Printing.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarPrinting_Printing.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarPrinting_Printing.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarPrinting_Printing.Name = "RibbonBarPrinting_Printing"
            Me.RibbonBarPrinting_Printing.SecurityEnabled = True
            Me.RibbonBarPrinting_Printing.Size = New System.Drawing.Size(100, 98)
            Me.RibbonBarPrinting_Printing.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarPrinting_Printing.TabIndex = 2
            Me.RibbonBarPrinting_Printing.Text = "Printing"
            '
            '
            '
            Me.RibbonBarPrinting_Printing.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPrinting_Printing.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemPrinting_Print
            '
            Me.ButtonItemPrinting_Print.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPrinting_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPrinting_Print.Name = "ButtonItemPrinting_Print"
            Me.ButtonItemPrinting_Print.RibbonWordWrap = False
            Me.ButtonItemPrinting_Print.SubItemsExpandWidth = 14
            Me.ButtonItemPrinting_Print.Text = "Print"
            '
            'MediaSpecificationReportEditForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1156, 432)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Printing)
            Me.Controls.Add(Me.DataGridViewForm_JobVersionReport)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaSpecificationReportEditForm"
            Me.Text = "Media Specification Report"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBarOptions_Actions.ResumeLayout(False)
            CType(Me.DateTimePickerDateFrom_From, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerDateTo_To, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarMergeContainerForm_Printing.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents DataGridViewForm_JobVersionReport As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ItemContainerActions_Templates As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemTemplates_Templates As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ItemContainerActions_Search As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerSearch_Criteria As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemCriteria_Criteria As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ItemContainerSearch_DateTo As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemDateTo_To As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ButtonItemDateTo_MTD As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDateTo_2Years As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_View As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ComboBoxCriteria_Criteria As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ControlContainerItemCriteria_Criteria As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ControlContainerItemDateTo_DateTo As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents DateTimePickerDateFrom_From As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents ItemContainerSearch_DateFrom As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemDateFrom_From As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemDateFrom_DateFrom As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemDateFrom_YTD As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDateFrom_1Year As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DateTimePickerDateTo_To As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents ComboBoxTemplates_Templates As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ControlContainerItemTemplates_Templates As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents RibbonBarOptions_Filter As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemFilter_ShowFilterEditor As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemFilter_ShowAutoFilterRow As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerView_ViewLeft As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemViewLeft_AllowCellMerging As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemViewLeft_ShowViewCaption As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemViewLeft_ShowGroupByBox As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_QuickCustomize As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemQuickCustomize_Columns As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_Printing As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarPrinting_Options As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerOptions_OptionsLeft As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemOptionsLeft_AutoSizeColumnsToPage As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemOptionsLeft_PrintFilterInfo As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerOptions_OptionsMiddle As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemOptionsMiddle_PrintHeader As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemOptionsMiddle_PrintFooter As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemOptionsMiddle_PrintGroupFooter As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerOptions_OptionsRight As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemOptionsRight_PrintSelectedRowsOnly As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarPrinting_Printing As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemPrinting_Print As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_AcceptedOnly As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Report As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemReport_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReport_SaveAs As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerSearch_ReportType As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemReportType As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItem_ReportType As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ComboBox_ReportType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    End Class

End Namespace