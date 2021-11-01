Namespace Employee.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeTimesheetForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeTimesheetForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Options = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemOptions_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOptions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOptions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOptions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_AddCV = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Info = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Settings = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Approval = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Search = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_GroupBy = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainer8 = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainer5 = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainer6 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemGroupBy_Client = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemGroupBy_Division = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainer7 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemGroupBy_Product = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemGroupBy_Job = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Search = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.SearchableComboBoxSearch_Employees = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBox1View = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.ItemContainer2 = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainer4 = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemSearch_Employees = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
            Me.MonthCalendarControl_TimesheetDates = New DevComponents.Editors.DateTimeAdv.MonthCalendarAdv()
            Me.RadioButtonControlForm_CustomDateRange = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlForm_FullWeek = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlForm_WeekDay = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlForm_SelectedDateOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewProject_ProjectTemplates = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelForm_Main = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TimesheetControlForm_Timesheet = New AdvantageFramework.WinForm.Presentation.Controls.TimesheetControl()
            Me.SuperTooltipForm_ToolTip = New DevComponents.DotNetBar.SuperTooltip()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBarOptions_Search.SuspendLayout()
            CType(Me.SearchableComboBoxSearch_Employees.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanel2.SuspendLayout()
            CType(Me.PanelForm_Main, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Main.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Options)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_GroupBy)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Search)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(5, 407)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1175, 98)
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
            'RibbonBarOptions_Options
            '
            Me.RibbonBarOptions_Options.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Options.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Options.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Options.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Options.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Options.DragDropSupport = True
            Me.RibbonBarOptions_Options.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptions_Copy, Me.ButtonItemOptions_Delete, Me.ButtonItemOptions_Cancel, Me.ButtonItemOptions_Refresh})
            Me.RibbonBarOptions_Options.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Options.Location = New System.Drawing.Point(779, 0)
            Me.RibbonBarOptions_Options.Name = "RibbonBarOptions_Options"
            Me.RibbonBarOptions_Options.SecurityEnabled = True
            Me.RibbonBarOptions_Options.Size = New System.Drawing.Size(198, 98)
            Me.RibbonBarOptions_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Options.TabIndex = 3
            Me.RibbonBarOptions_Options.Text = "Options"
            '
            '
            '
            Me.RibbonBarOptions_Options.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Options.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Options.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemOptions_Copy
            '
            Me.ButtonItemOptions_Copy.BeginGroup = True
            Me.ButtonItemOptions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_Copy.Name = "ButtonItemOptions_Copy"
            Me.ButtonItemOptions_Copy.RibbonWordWrap = False
            Me.ButtonItemOptions_Copy.SecurityEnabled = True
            Me.ButtonItemOptions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_Copy.Text = "Copy Row"
            '
            'ButtonItemOptions_Delete
            '
            Me.ButtonItemOptions_Delete.BeginGroup = True
            Me.ButtonItemOptions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_Delete.Name = "ButtonItemOptions_Delete"
            Me.ButtonItemOptions_Delete.RibbonWordWrap = False
            Me.ButtonItemOptions_Delete.SecurityEnabled = True
            Me.ButtonItemOptions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_Delete.Text = "Delete"
            '
            'ButtonItemOptions_Cancel
            '
            Me.ButtonItemOptions_Cancel.BeginGroup = True
            Me.ButtonItemOptions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_Cancel.Name = "ButtonItemOptions_Cancel"
            Me.ButtonItemOptions_Cancel.RibbonWordWrap = False
            Me.ButtonItemOptions_Cancel.SecurityEnabled = True
            Me.ButtonItemOptions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_Cancel.Text = "Cancel"
            '
            'ButtonItemOptions_Refresh
            '
            Me.ButtonItemOptions_Refresh.BeginGroup = True
            Me.ButtonItemOptions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_Refresh.Name = "ButtonItemOptions_Refresh"
            Me.ButtonItemOptions_Refresh.RibbonWordWrap = False
            Me.ButtonItemOptions_Refresh.SecurityEnabled = True
            Me.ButtonItemOptions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_Refresh.Text = "Refresh"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_AddCV, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_Info, Me.ButtonItemActions_Settings, Me.ButtonItemActions_Approval, Me.ButtonItemActions_Print, Me.ButtonItemActions_Search})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(376, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(403, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 2
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
            'ButtonItemActions_AddCV
            '
            Me.ButtonItemActions_AddCV.BeginGroup = True
            Me.ButtonItemActions_AddCV.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_AddCV.Name = "ButtonItemActions_AddCV"
            Me.ButtonItemActions_AddCV.RibbonWordWrap = False
            Me.ButtonItemActions_AddCV.SecurityEnabled = True
            Me.ButtonItemActions_AddCV.SubItemsExpandWidth = 14
            Me.ButtonItemActions_AddCV.Text = "Add (CV)"
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
            'ButtonItemActions_Info
            '
            Me.ButtonItemActions_Info.BeginGroup = True
            Me.ButtonItemActions_Info.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Info.Name = "ButtonItemActions_Info"
            Me.ButtonItemActions_Info.RibbonWordWrap = False
            Me.ButtonItemActions_Info.SecurityEnabled = True
            Me.ButtonItemActions_Info.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Info.Text = "Info"
            '
            'ButtonItemActions_Settings
            '
            Me.ButtonItemActions_Settings.BeginGroup = True
            Me.ButtonItemActions_Settings.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Settings.Name = "ButtonItemActions_Settings"
            Me.ButtonItemActions_Settings.RibbonWordWrap = False
            Me.ButtonItemActions_Settings.SecurityEnabled = True
            Me.ButtonItemActions_Settings.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Settings.Text = "Settings"
            '
            'ButtonItemActions_Approval
            '
            Me.ButtonItemActions_Approval.BeginGroup = True
            Me.ButtonItemActions_Approval.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Approval.Name = "ButtonItemActions_Approval"
            Me.ButtonItemActions_Approval.RibbonWordWrap = False
            Me.ButtonItemActions_Approval.SecurityEnabled = True
            Me.ButtonItemActions_Approval.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Approval.Text = "Approval"
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
            'ButtonItemActions_Search
            '
            Me.ButtonItemActions_Search.BeginGroup = True
            Me.ButtonItemActions_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Search.Name = "ButtonItemActions_Search"
            Me.ButtonItemActions_Search.RibbonWordWrap = False
            Me.ButtonItemActions_Search.SecurityEnabled = True
            Me.ButtonItemActions_Search.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Search.Text = "Advanced <br></br><span width=""6""> </span>Search"
            '
            'RibbonBarOptions_GroupBy
            '
            Me.RibbonBarOptions_GroupBy.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_GroupBy.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GroupBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GroupBy.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_GroupBy.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_GroupBy.DragDropSupport = True
            Me.RibbonBarOptions_GroupBy.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer8})
            Me.RibbonBarOptions_GroupBy.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_GroupBy.Location = New System.Drawing.Point(219, 0)
            Me.RibbonBarOptions_GroupBy.Name = "RibbonBarOptions_GroupBy"
            Me.RibbonBarOptions_GroupBy.SecurityEnabled = True
            Me.RibbonBarOptions_GroupBy.Size = New System.Drawing.Size(157, 98)
            Me.RibbonBarOptions_GroupBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_GroupBy.TabIndex = 1
            Me.RibbonBarOptions_GroupBy.Text = "Group By"
            '
            '
            '
            Me.RibbonBarOptions_GroupBy.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GroupBy.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GroupBy.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainer8
            '
            '
            '
            '
            Me.ItemContainer8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer8.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer8.Name = "ItemContainer8"
            Me.ItemContainer8.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1})
            '
            '
            '
            Me.ItemContainer8.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainer1
            '
            '
            '
            '
            Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer1.Name = "ItemContainer1"
            Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer5})
            '
            '
            '
            Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainer5
            '
            '
            '
            '
            Me.ItemContainer5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer5.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer5.Name = "ItemContainer5"
            Me.ItemContainer5.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer6, Me.ItemContainer7})
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
            Me.ItemContainer6.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGroupBy_Client, Me.ButtonItemGroupBy_Division})
            '
            '
            '
            Me.ItemContainer6.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemGroupBy_Client
            '
            Me.ButtonItemGroupBy_Client.AutoCheckOnClick = True
            Me.ButtonItemGroupBy_Client.FixedSize = New System.Drawing.Size(75, 20)
            Me.ButtonItemGroupBy_Client.Name = "ButtonItemGroupBy_Client"
            Me.ButtonItemGroupBy_Client.Text = "Client"
            '
            'ButtonItemGroupBy_Division
            '
            Me.ButtonItemGroupBy_Division.AutoCheckOnClick = True
            Me.ButtonItemGroupBy_Division.FixedSize = New System.Drawing.Size(75, 20)
            Me.ButtonItemGroupBy_Division.Name = "ButtonItemGroupBy_Division"
            Me.ButtonItemGroupBy_Division.Text = "Division"
            '
            'ItemContainer7
            '
            '
            '
            '
            Me.ItemContainer7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer7.Name = "ItemContainer7"
            Me.ItemContainer7.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGroupBy_Product, Me.ButtonItemGroupBy_Job})
            '
            '
            '
            Me.ItemContainer7.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemGroupBy_Product
            '
            Me.ButtonItemGroupBy_Product.AutoCheckOnClick = True
            Me.ButtonItemGroupBy_Product.FixedSize = New System.Drawing.Size(75, 20)
            Me.ButtonItemGroupBy_Product.Name = "ButtonItemGroupBy_Product"
            Me.ButtonItemGroupBy_Product.Text = "Product"
            '
            'ButtonItemGroupBy_Job
            '
            Me.ButtonItemGroupBy_Job.AutoCheckOnClick = True
            Me.ButtonItemGroupBy_Job.FixedSize = New System.Drawing.Size(75, 20)
            Me.ButtonItemGroupBy_Job.Name = "ButtonItemGroupBy_Job"
            Me.ButtonItemGroupBy_Job.Text = "Job"
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
            Me.RibbonBarOptions_Search.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Search.DragDropSupport = True
            Me.RibbonBarOptions_Search.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer2})
            Me.RibbonBarOptions_Search.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Search.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Search.Name = "RibbonBarOptions_Search"
            Me.RibbonBarOptions_Search.SecurityEnabled = True
            Me.RibbonBarOptions_Search.Size = New System.Drawing.Size(219, 98)
            Me.RibbonBarOptions_Search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Search.TabIndex = 0
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
            Me.SearchableComboBoxSearch_Employees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxSearch_Employees.DataSource = Nothing
            Me.SearchableComboBoxSearch_Employees.DisableMouseWheel = False
            Me.SearchableComboBoxSearch_Employees.DisplayName = ""
            Me.SearchableComboBoxSearch_Employees.EnterMoveNextControl = True
            Me.SearchableComboBoxSearch_Employees.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxSearch_Employees.Location = New System.Drawing.Point(65, 60)
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
            'ItemContainer2
            '
            '
            '
            '
            Me.ItemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer2.Name = "ItemContainer2"
            Me.ItemContainer2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer4})
            '
            '
            '
            Me.ItemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
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
            'GridView1
            '
            Me.GridView1.AFActiveFilterString = ""
            Me.GridView1.AllowExtraItemsInGridLookupEdits = True
            Me.GridView1.AutoFilterLookupColumns = False
            Me.GridView1.AutoloadRepositoryDatasource = True
            Me.GridView1.DataSourceClearing = False
            Me.GridView1.EnableDisabledRows = False
            Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView1.OptionsView.ShowGroupPanel = False
            Me.GridView1.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView1.RunStandardValidation = True
            '
            'ItemContainer3
            '
            '
            '
            '
            Me.ItemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer3.Name = "ItemContainer3"
            '
            '
            '
            Me.ItemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'MonthCalendarControl_TimesheetDates
            '
            Me.MonthCalendarControl_TimesheetDates.AutoSize = True
            '
            '
            '
            Me.MonthCalendarControl_TimesheetDates.BackgroundStyle.Class = "MonthCalendarAdv"
            Me.MonthCalendarControl_TimesheetDates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.MonthCalendarControl_TimesheetDates.Colors.DayMarker.BorderColor = System.Drawing.SystemColors.Highlight
            Me.MonthCalendarControl_TimesheetDates.Colors.DayMarker.TextColor = System.Drawing.SystemColors.Highlight
            Me.MonthCalendarControl_TimesheetDates.Colors.Selection.BackColor = System.Drawing.Color.Transparent
            Me.MonthCalendarControl_TimesheetDates.Colors.Selection.BackColor2 = System.Drawing.Color.Transparent
            Me.MonthCalendarControl_TimesheetDates.Colors.Selection.BorderColor = System.Drawing.Color.Black
            '
            '
            '
            Me.MonthCalendarControl_TimesheetDates.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.MonthCalendarControl_TimesheetDates.ContainerControlProcessDialogKey = True
            Me.MonthCalendarControl_TimesheetDates.DaySize = New System.Drawing.Size(27, 20)
            Me.MonthCalendarControl_TimesheetDates.DisplayMonth = New Date(CType(0, Long))
            Me.MonthCalendarControl_TimesheetDates.Location = New System.Drawing.Point(12, 12)
            Me.MonthCalendarControl_TimesheetDates.MultiSelect = True
            Me.MonthCalendarControl_TimesheetDates.Name = "MonthCalendarControl_TimesheetDates"
            '
            '
            '
            Me.MonthCalendarControl_TimesheetDates.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.MonthCalendarControl_TimesheetDates.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.MonthCalendarControl_TimesheetDates.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.MonthCalendarControl_TimesheetDates.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.MonthCalendarControl_TimesheetDates.Size = New System.Drawing.Size(191, 166)
            Me.MonthCalendarControl_TimesheetDates.TabIndex = 0
            '
            'RadioButtonControlForm_CustomDateRange
            '
            Me.RadioButtonControlForm_CustomDateRange.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlForm_CustomDateRange.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_CustomDateRange.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_CustomDateRange.Location = New System.Drawing.Point(12, 262)
            Me.RadioButtonControlForm_CustomDateRange.Name = "RadioButtonControlForm_CustomDateRange"
            Me.RadioButtonControlForm_CustomDateRange.SecurityEnabled = True
            Me.RadioButtonControlForm_CustomDateRange.Size = New System.Drawing.Size(191, 20)
            Me.RadioButtonControlForm_CustomDateRange.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_CustomDateRange.TabIndex = 4
            Me.RadioButtonControlForm_CustomDateRange.TabOnEnter = True
            Me.RadioButtonControlForm_CustomDateRange.TabStop = False
            Me.RadioButtonControlForm_CustomDateRange.Text = "Custom Date Range"
            '
            'RadioButtonControlForm_FullWeek
            '
            Me.RadioButtonControlForm_FullWeek.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlForm_FullWeek.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_FullWeek.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_FullWeek.Location = New System.Drawing.Point(12, 184)
            Me.RadioButtonControlForm_FullWeek.Name = "RadioButtonControlForm_FullWeek"
            Me.RadioButtonControlForm_FullWeek.SecurityEnabled = True
            Me.RadioButtonControlForm_FullWeek.Size = New System.Drawing.Size(191, 20)
            Me.RadioButtonControlForm_FullWeek.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_FullWeek.TabIndex = 1
            Me.RadioButtonControlForm_FullWeek.TabOnEnter = True
            Me.RadioButtonControlForm_FullWeek.TabStop = False
            Me.RadioButtonControlForm_FullWeek.Text = "Full Week View"
            '
            'RadioButtonControlForm_WeekDay
            '
            Me.RadioButtonControlForm_WeekDay.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlForm_WeekDay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_WeekDay.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_WeekDay.Location = New System.Drawing.Point(12, 210)
            Me.RadioButtonControlForm_WeekDay.Name = "RadioButtonControlForm_WeekDay"
            Me.RadioButtonControlForm_WeekDay.SecurityEnabled = True
            Me.RadioButtonControlForm_WeekDay.Size = New System.Drawing.Size(191, 20)
            Me.RadioButtonControlForm_WeekDay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_WeekDay.TabIndex = 2
            Me.RadioButtonControlForm_WeekDay.TabOnEnter = True
            Me.RadioButtonControlForm_WeekDay.TabStop = False
            Me.RadioButtonControlForm_WeekDay.Text = "5 Day Week View"
            '
            'RadioButtonControlForm_SelectedDateOnly
            '
            Me.RadioButtonControlForm_SelectedDateOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlForm_SelectedDateOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_SelectedDateOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_SelectedDateOnly.Location = New System.Drawing.Point(12, 236)
            Me.RadioButtonControlForm_SelectedDateOnly.Name = "RadioButtonControlForm_SelectedDateOnly"
            Me.RadioButtonControlForm_SelectedDateOnly.SecurityEnabled = True
            Me.RadioButtonControlForm_SelectedDateOnly.Size = New System.Drawing.Size(191, 20)
            Me.RadioButtonControlForm_SelectedDateOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_SelectedDateOnly.TabIndex = 3
            Me.RadioButtonControlForm_SelectedDateOnly.TabOnEnter = True
            Me.RadioButtonControlForm_SelectedDateOnly.TabStop = False
            Me.RadioButtonControlForm_SelectedDateOnly.Text = "Selected Date Only"
            '
            'TabControlPanel2
            '
            Me.TabControlPanel2.Controls.Add(Me.DataGridViewProject_ProjectTemplates)
            Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel2.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel2.Name = "TabControlPanel2"
            Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel2.Size = New System.Drawing.Size(736, 185)
            Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel2.Style.GradientAngle = 90
            Me.TabControlPanel2.TabIndex = 2
            '
            'DataGridViewProject_ProjectTemplates
            '
            Me.DataGridViewProject_ProjectTemplates.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewProject_ProjectTemplates.AllowDragAndDrop = False
            Me.DataGridViewProject_ProjectTemplates.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewProject_ProjectTemplates.AllowSelectGroupHeaderRow = True
            Me.DataGridViewProject_ProjectTemplates.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewProject_ProjectTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewProject_ProjectTemplates.AutoFilterLookupColumns = False
            Me.DataGridViewProject_ProjectTemplates.AutoloadRepositoryDatasource = True
            Me.DataGridViewProject_ProjectTemplates.AutoUpdateViewCaption = True
            Me.DataGridViewProject_ProjectTemplates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewProject_ProjectTemplates.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewProject_ProjectTemplates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewProject_ProjectTemplates.ItemDescription = "Item(s)"
            Me.DataGridViewProject_ProjectTemplates.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewProject_ProjectTemplates.MultiSelect = True
            Me.DataGridViewProject_ProjectTemplates.Name = "DataGridViewProject_ProjectTemplates"
            Me.DataGridViewProject_ProjectTemplates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewProject_ProjectTemplates.RunStandardValidation = True
            Me.DataGridViewProject_ProjectTemplates.ShowColumnMenuOnRightClick = False
            Me.DataGridViewProject_ProjectTemplates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewProject_ProjectTemplates.Size = New System.Drawing.Size(728, 177)
            Me.DataGridViewProject_ProjectTemplates.TabIndex = 2
            Me.DataGridViewProject_ProjectTemplates.UseEmbeddedNavigator = False
            Me.DataGridViewProject_ProjectTemplates.ViewCaptionHeight = -1
            '
            'PanelForm_Main
            '
            Me.PanelForm_Main.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelForm_Main.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_Main.Controls.Add(Me.TimesheetControlForm_Timesheet)
            Me.PanelForm_Main.Location = New System.Drawing.Point(209, 12)
            Me.PanelForm_Main.Name = "PanelForm_Main"
            Me.PanelForm_Main.Size = New System.Drawing.Size(1010, 499)
            Me.PanelForm_Main.TabIndex = 16
            '
            'TimesheetControlForm_Timesheet
            '
            Me.TimesheetControlForm_Timesheet.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TimesheetControlForm_Timesheet.Location = New System.Drawing.Point(0, 0)
            Me.TimesheetControlForm_Timesheet.Name = "TimesheetControlForm_Timesheet"
            Me.TimesheetControlForm_Timesheet.ShowComments = False
            Me.TimesheetControlForm_Timesheet.Size = New System.Drawing.Size(1010, 499)
            Me.TimesheetControlForm_Timesheet.TabIndex = 6
            Me.TimesheetControlForm_Timesheet.TimesheetGroupByOption = AdvantageFramework.EmployeeTimesheet.Methods.TimesheetGroupByOptions.None
            '
            'SuperTooltipForm_ToolTip
            '
            Me.SuperTooltipForm_ToolTip.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
            Me.SuperTooltipForm_ToolTip.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            '
            'EmployeeTimesheetForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1231, 523)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_Main)
            Me.Controls.Add(Me.RadioButtonControlForm_SelectedDateOnly)
            Me.Controls.Add(Me.RadioButtonControlForm_WeekDay)
            Me.Controls.Add(Me.RadioButtonControlForm_FullWeek)
            Me.Controls.Add(Me.RadioButtonControlForm_CustomDateRange)
            Me.Controls.Add(Me.MonthCalendarControl_TimesheetDates)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeTimesheetForm"
            Me.Text = "Timesheet"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBarOptions_Search.ResumeLayout(False)
            CType(Me.SearchableComboBoxSearch_Employees.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanel2.ResumeLayout(False)
            CType(Me.PanelForm_Main, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Main.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Search As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainer4 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSearch_Employees As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents SearchableComboBoxSearch_Employees As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBox1View As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents MonthCalendarControl_TimesheetDates As DevComponents.Editors.DateTimeAdv.MonthCalendarAdv
        Friend WithEvents RadioButtonControlForm_CustomDateRange As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlForm_FullWeek As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlForm_WeekDay As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlForm_SelectedDateOnly As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents PanelForm_Main As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents TimesheetControlForm_Timesheet As AdvantageFramework.WinForm.Presentation.Controls.TimesheetControl
        Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewProject_ProjectTemplates As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Settings As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_AddCV As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Options As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemOptions_Copy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOptions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOptions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOptions_Refresh As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Approval As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Info As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents ButtonItemActions_Search As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainer2 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainer5 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainer6 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemGroupBy_Client As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemGroupBy_Division As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainer7 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemGroupBy_Product As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemGroupBy_Job As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_GroupBy As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainer8 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents SuperTooltipForm_ToolTip As DevComponents.DotNetBar.SuperTooltip

    End Class

End Namespace

