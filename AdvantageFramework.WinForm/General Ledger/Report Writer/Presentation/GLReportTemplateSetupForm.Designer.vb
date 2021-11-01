Namespace GeneralLedger.ReportWriter.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GLReportTemplateSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GLReportTemplateSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Currency = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.RibbonBarOptions_BudgetData = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemBudgetData_Refresh = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDashboard_Edit = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Statement = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemStatement_View = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_TemplateColumns = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemTemplateColumns_AddNew = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTemplateColumns_Manage = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_TemplateRows = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemTemplateRows_AddNew = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTemplateRows_Manage = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_TemplateDetails = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.TextBoxTemplateDetails_TemplateName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ItemContainerTemplateDetails_TemplateDetails = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemTemplateDetails_TemplateName = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemTemplateDetails_TemplateDetails = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerTemplateDetails_StatementType = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemStatementType_IncomeStatement = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemStatementType_BalanceSheet = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemStatementType_Other = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTemplateDetails_OptionsAndPresets = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ContextMenuBar = New DevComponents.DotNetBar.ContextMenuBar()
            Me.ButtonItemCMB_DataArea = New DevComponents.DotNetBar.ButtonItem()
            Me.TabControlForm_Report = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelStatementTab_Statement = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewStatement_Statement = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReport_StatementTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDashboardTab_Dashboard = New DevComponents.DotNetBar.TabControlPanel()
            Me.DashboardViewerDashboard_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl()
            Me.TabItemReport_DashboardTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ItemContainerCurrency_Vertical = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemCurrency_Code = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemCurrency_Rate = New DevComponents.DotNetBar.LabelItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBarOptions_TemplateDetails.SuspendLayout()
            CType(Me.ContextMenuBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlForm_Report, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_Report.SuspendLayout()
            Me.TabControlPanelStatementTab_Statement.SuspendLayout()
            Me.TabControlPanelDashboardTab_Dashboard.SuspendLayout()
            CType(Me.DashboardViewerDashboard_Dashboard, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Currency)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_BudgetData)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Dashboard)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Statement)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_TemplateColumns)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_TemplateRows)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_TemplateDetails)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(-6, 164)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(989, 98)
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
            'RibbonBarOptions_Currency
            '
            Me.RibbonBarOptions_Currency.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Currency.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Currency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Currency.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Currency.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Currency.DragDropSupport = True
            Me.RibbonBarOptions_Currency.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerCurrency_Vertical})
            Me.RibbonBarOptions_Currency.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Currency.Location = New System.Drawing.Point(988, 0)
            Me.RibbonBarOptions_Currency.Name = "RibbonBarOptions_Currency"
            Me.RibbonBarOptions_Currency.SecurityEnabled = True
            Me.RibbonBarOptions_Currency.Size = New System.Drawing.Size(118, 98)
            Me.RibbonBarOptions_Currency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Currency.TabIndex = 16
            Me.RibbonBarOptions_Currency.Text = "Currency"
            '
            '
            '
            Me.RibbonBarOptions_Currency.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Currency.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Currency.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'RibbonBarOptions_BudgetData
            '
            Me.RibbonBarOptions_BudgetData.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_BudgetData.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_BudgetData.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_BudgetData.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_BudgetData.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_BudgetData.DragDropSupport = True
            Me.RibbonBarOptions_BudgetData.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_BudgetData.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemBudgetData_Refresh})
            Me.RibbonBarOptions_BudgetData.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_BudgetData.Location = New System.Drawing.Point(923, 0)
            Me.RibbonBarOptions_BudgetData.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_BudgetData.Name = "RibbonBarOptions_BudgetData"
            Me.RibbonBarOptions_BudgetData.SecurityEnabled = True
            Me.RibbonBarOptions_BudgetData.Size = New System.Drawing.Size(65, 98)
            Me.RibbonBarOptions_BudgetData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_BudgetData.TabIndex = 15
            Me.RibbonBarOptions_BudgetData.Text = "Budget Data"
            '
            '
            '
            Me.RibbonBarOptions_BudgetData.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_BudgetData.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_BudgetData.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemBudgetData_Refresh
            '
            Me.ButtonItemBudgetData_Refresh.BeginGroup = True
            Me.ButtonItemBudgetData_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemBudgetData_Refresh.Name = "ButtonItemBudgetData_Refresh"
            Me.ButtonItemBudgetData_Refresh.RibbonWordWrap = False
            Me.ButtonItemBudgetData_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemBudgetData_Refresh.Text = "Refresh"
            '
            'RibbonBarOptions_Dashboard
            '
            Me.RibbonBarOptions_Dashboard.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Dashboard.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Dashboard.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Dashboard.DragDropSupport = True
            Me.RibbonBarOptions_Dashboard.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Dashboard.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDashboard_Edit})
            Me.RibbonBarOptions_Dashboard.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Dashboard.Location = New System.Drawing.Point(858, 0)
            Me.RibbonBarOptions_Dashboard.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_Dashboard.Name = "RibbonBarOptions_Dashboard"
            Me.RibbonBarOptions_Dashboard.SecurityEnabled = True
            Me.RibbonBarOptions_Dashboard.Size = New System.Drawing.Size(65, 98)
            Me.RibbonBarOptions_Dashboard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Dashboard.TabIndex = 11
            Me.RibbonBarOptions_Dashboard.Text = "Dashboard"
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Dashboard.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDashboard_Edit
            '
            Me.ButtonItemDashboard_Edit.BeginGroup = True
            Me.ButtonItemDashboard_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDashboard_Edit.Name = "ButtonItemDashboard_Edit"
            Me.ButtonItemDashboard_Edit.RibbonWordWrap = False
            Me.ButtonItemDashboard_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemDashboard_Edit.Text = "Edit"
            '
            'RibbonBarOptions_Statement
            '
            Me.RibbonBarOptions_Statement.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Statement.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Statement.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Statement.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Statement.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Statement.DragDropSupport = True
            Me.RibbonBarOptions_Statement.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Statement.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemStatement_View})
            Me.RibbonBarOptions_Statement.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Statement.Location = New System.Drawing.Point(793, 0)
            Me.RibbonBarOptions_Statement.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_Statement.Name = "RibbonBarOptions_Statement"
            Me.RibbonBarOptions_Statement.SecurityEnabled = True
            Me.RibbonBarOptions_Statement.Size = New System.Drawing.Size(65, 98)
            Me.RibbonBarOptions_Statement.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Statement.TabIndex = 12
            Me.RibbonBarOptions_Statement.Text = "Statement"
            '
            '
            '
            Me.RibbonBarOptions_Statement.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Statement.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Statement.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemStatement_View
            '
            Me.ButtonItemStatement_View.BeginGroup = True
            Me.ButtonItemStatement_View.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemStatement_View.Name = "ButtonItemStatement_View"
            Me.ButtonItemStatement_View.RibbonWordWrap = False
            Me.ButtonItemStatement_View.SubItemsExpandWidth = 14
            Me.ButtonItemStatement_View.Text = "View"
            '
            'RibbonBarOptions_TemplateColumns
            '
            Me.RibbonBarOptions_TemplateColumns.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_TemplateColumns.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_TemplateColumns.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_TemplateColumns.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_TemplateColumns.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_TemplateColumns.DragDropSupport = True
            Me.RibbonBarOptions_TemplateColumns.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_TemplateColumns.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTemplateColumns_AddNew, Me.ButtonItemTemplateColumns_Manage})
            Me.RibbonBarOptions_TemplateColumns.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_TemplateColumns.Location = New System.Drawing.Point(683, 0)
            Me.RibbonBarOptions_TemplateColumns.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_TemplateColumns.Name = "RibbonBarOptions_TemplateColumns"
            Me.RibbonBarOptions_TemplateColumns.SecurityEnabled = True
            Me.RibbonBarOptions_TemplateColumns.Size = New System.Drawing.Size(110, 98)
            Me.RibbonBarOptions_TemplateColumns.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_TemplateColumns.TabIndex = 14
            Me.RibbonBarOptions_TemplateColumns.Text = "Template Columns"
            '
            '
            '
            Me.RibbonBarOptions_TemplateColumns.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_TemplateColumns.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_TemplateColumns.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemTemplateColumns_AddNew
            '
            Me.ButtonItemTemplateColumns_AddNew.BeginGroup = True
            Me.ButtonItemTemplateColumns_AddNew.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTemplateColumns_AddNew.Name = "ButtonItemTemplateColumns_AddNew"
            Me.ButtonItemTemplateColumns_AddNew.RibbonWordWrap = False
            Me.ButtonItemTemplateColumns_AddNew.SubItemsExpandWidth = 14
            Me.ButtonItemTemplateColumns_AddNew.Text = "Add New"
            '
            'ButtonItemTemplateColumns_Manage
            '
            Me.ButtonItemTemplateColumns_Manage.BeginGroup = True
            Me.ButtonItemTemplateColumns_Manage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTemplateColumns_Manage.Name = "ButtonItemTemplateColumns_Manage"
            Me.ButtonItemTemplateColumns_Manage.RibbonWordWrap = False
            Me.ButtonItemTemplateColumns_Manage.SubItemsExpandWidth = 14
            Me.ButtonItemTemplateColumns_Manage.Text = "Manage"
            '
            'RibbonBarOptions_TemplateRows
            '
            Me.RibbonBarOptions_TemplateRows.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_TemplateRows.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_TemplateRows.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_TemplateRows.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_TemplateRows.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_TemplateRows.DragDropSupport = True
            Me.RibbonBarOptions_TemplateRows.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_TemplateRows.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTemplateRows_AddNew, Me.ButtonItemTemplateRows_Manage})
            Me.RibbonBarOptions_TemplateRows.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_TemplateRows.Location = New System.Drawing.Point(574, 0)
            Me.RibbonBarOptions_TemplateRows.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_TemplateRows.Name = "RibbonBarOptions_TemplateRows"
            Me.RibbonBarOptions_TemplateRows.SecurityEnabled = True
            Me.RibbonBarOptions_TemplateRows.Size = New System.Drawing.Size(109, 98)
            Me.RibbonBarOptions_TemplateRows.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_TemplateRows.TabIndex = 13
            Me.RibbonBarOptions_TemplateRows.Text = "Template Rows"
            '
            '
            '
            Me.RibbonBarOptions_TemplateRows.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_TemplateRows.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_TemplateRows.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemTemplateRows_AddNew
            '
            Me.ButtonItemTemplateRows_AddNew.BeginGroup = True
            Me.ButtonItemTemplateRows_AddNew.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTemplateRows_AddNew.Name = "ButtonItemTemplateRows_AddNew"
            Me.ButtonItemTemplateRows_AddNew.RibbonWordWrap = False
            Me.ButtonItemTemplateRows_AddNew.SubItemsExpandWidth = 14
            Me.ButtonItemTemplateRows_AddNew.Text = "Add New"
            '
            'ButtonItemTemplateRows_Manage
            '
            Me.ButtonItemTemplateRows_Manage.BeginGroup = True
            Me.ButtonItemTemplateRows_Manage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTemplateRows_Manage.Name = "ButtonItemTemplateRows_Manage"
            Me.ButtonItemTemplateRows_Manage.RibbonWordWrap = False
            Me.ButtonItemTemplateRows_Manage.SubItemsExpandWidth = 14
            Me.ButtonItemTemplateRows_Manage.Text = "Manage"
            '
            'RibbonBarOptions_TemplateDetails
            '
            Me.RibbonBarOptions_TemplateDetails.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_TemplateDetails.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_TemplateDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_TemplateDetails.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_TemplateDetails.Controls.Add(Me.TextBoxTemplateDetails_TemplateName)
            Me.RibbonBarOptions_TemplateDetails.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_TemplateDetails.DragDropSupport = True
            Me.RibbonBarOptions_TemplateDetails.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerTemplateDetails_TemplateDetails, Me.ItemContainerTemplateDetails_StatementType, Me.ButtonItemTemplateDetails_OptionsAndPresets})
            Me.RibbonBarOptions_TemplateDetails.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_TemplateDetails.Location = New System.Drawing.Point(112, 0)
            Me.RibbonBarOptions_TemplateDetails.Name = "RibbonBarOptions_TemplateDetails"
            Me.RibbonBarOptions_TemplateDetails.SecurityEnabled = True
            Me.RibbonBarOptions_TemplateDetails.Size = New System.Drawing.Size(462, 98)
            Me.RibbonBarOptions_TemplateDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_TemplateDetails.TabIndex = 1
            Me.RibbonBarOptions_TemplateDetails.Text = "Template Details"
            '
            '
            '
            Me.RibbonBarOptions_TemplateDetails.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_TemplateDetails.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_TemplateDetails.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'TextBoxTemplateDetails_TemplateName
            '
            Me.TextBoxTemplateDetails_TemplateName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxTemplateDetails_TemplateName.Border.Class = "TextBoxBorder"
            Me.TextBoxTemplateDetails_TemplateName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTemplateDetails_TemplateName.CheckSpellingOnValidate = False
            Me.TextBoxTemplateDetails_TemplateName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTemplateDetails_TemplateName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxTemplateDetails_TemplateName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTemplateDetails_TemplateName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTemplateDetails_TemplateName.FocusHighlightEnabled = True
            Me.TextBoxTemplateDetails_TemplateName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxTemplateDetails_TemplateName.Location = New System.Drawing.Point(88, 51)
            Me.TextBoxTemplateDetails_TemplateName.MaxFileSize = CType(0, Long)
            Me.TextBoxTemplateDetails_TemplateName.Name = "TextBoxTemplateDetails_TemplateName"
            Me.TextBoxTemplateDetails_TemplateName.SecurityEnabled = True
            Me.TextBoxTemplateDetails_TemplateName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTemplateDetails_TemplateName.Size = New System.Drawing.Size(175, 20)
            Me.TextBoxTemplateDetails_TemplateName.StartingFolderName = Nothing
            Me.TextBoxTemplateDetails_TemplateName.TabIndex = 2
            Me.TextBoxTemplateDetails_TemplateName.TabOnEnter = True
            '
            'ItemContainerTemplateDetails_TemplateDetails
            '
            '
            '
            '
            Me.ItemContainerTemplateDetails_TemplateDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerTemplateDetails_TemplateDetails.BeginGroup = True
            Me.ItemContainerTemplateDetails_TemplateDetails.Name = "ItemContainerTemplateDetails_TemplateDetails"
            Me.ItemContainerTemplateDetails_TemplateDetails.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemTemplateDetails_TemplateName, Me.ControlContainerItemTemplateDetails_TemplateDetails})
            '
            '
            '
            Me.ItemContainerTemplateDetails_TemplateDetails.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerTemplateDetails_TemplateDetails.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'LabelItemTemplateDetails_TemplateName
            '
            Me.LabelItemTemplateDetails_TemplateName.Name = "LabelItemTemplateDetails_TemplateName"
            Me.LabelItemTemplateDetails_TemplateName.Text = "Template Name:"
            Me.LabelItemTemplateDetails_TemplateName.Width = 82
            '
            'ControlContainerItemTemplateDetails_TemplateDetails
            '
            Me.ControlContainerItemTemplateDetails_TemplateDetails.AllowItemResize = True
            Me.ControlContainerItemTemplateDetails_TemplateDetails.Control = Me.TextBoxTemplateDetails_TemplateName
            Me.ControlContainerItemTemplateDetails_TemplateDetails.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemTemplateDetails_TemplateDetails.Name = "ControlContainerItemTemplateDetails_TemplateDetails"
            Me.ControlContainerItemTemplateDetails_TemplateDetails.Text = "ControlContainerItem1"
            '
            'ItemContainerTemplateDetails_StatementType
            '
            '
            '
            '
            Me.ItemContainerTemplateDetails_StatementType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerTemplateDetails_StatementType.BeginGroup = True
            Me.ItemContainerTemplateDetails_StatementType.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerTemplateDetails_StatementType.Name = "ItemContainerTemplateDetails_StatementType"
            Me.ItemContainerTemplateDetails_StatementType.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemStatementType_IncomeStatement, Me.ButtonItemStatementType_BalanceSheet, Me.ButtonItemStatementType_Other})
            '
            '
            '
            Me.ItemContainerTemplateDetails_StatementType.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemStatementType_IncomeStatement
            '
            Me.ButtonItemStatementType_IncomeStatement.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemStatementType_IncomeStatement.CanCustomize = False
            Me.ButtonItemStatementType_IncomeStatement.Checked = True
            Me.ButtonItemStatementType_IncomeStatement.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None
            Me.ButtonItemStatementType_IncomeStatement.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemStatementType_IncomeStatement.Name = "ButtonItemStatementType_IncomeStatement"
            Me.ButtonItemStatementType_IncomeStatement.Stretch = True
            Me.ButtonItemStatementType_IncomeStatement.SubItemsExpandWidth = 14
            Me.ButtonItemStatementType_IncomeStatement.Text = "Income Statement"
            '
            'ButtonItemStatementType_BalanceSheet
            '
            Me.ButtonItemStatementType_BalanceSheet.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemStatementType_BalanceSheet.CanCustomize = False
            Me.ButtonItemStatementType_BalanceSheet.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None
            Me.ButtonItemStatementType_BalanceSheet.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemStatementType_BalanceSheet.Name = "ButtonItemStatementType_BalanceSheet"
            Me.ButtonItemStatementType_BalanceSheet.SubItemsExpandWidth = 14
            Me.ButtonItemStatementType_BalanceSheet.Text = "BalanceSheet"
            '
            'ButtonItemStatementType_Other
            '
            Me.ButtonItemStatementType_Other.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemStatementType_Other.CanCustomize = False
            Me.ButtonItemStatementType_Other.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None
            Me.ButtonItemStatementType_Other.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemStatementType_Other.Name = "ButtonItemStatementType_Other"
            Me.ButtonItemStatementType_Other.Stretch = True
            Me.ButtonItemStatementType_Other.SubItemsExpandWidth = 14
            Me.ButtonItemStatementType_Other.Text = "Other"
            '
            'ButtonItemTemplateDetails_OptionsAndPresets
            '
            Me.ButtonItemTemplateDetails_OptionsAndPresets.BeginGroup = True
            Me.ButtonItemTemplateDetails_OptionsAndPresets.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTemplateDetails_OptionsAndPresets.Name = "ButtonItemTemplateDetails_OptionsAndPresets"
            Me.ButtonItemTemplateDetails_OptionsAndPresets.RibbonWordWrap = False
            Me.ButtonItemTemplateDetails_OptionsAndPresets.SubItemsExpandWidth = 14
            Me.ButtonItemTemplateDetails_OptionsAndPresets.Text = "Options / Presets"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(112, 98)
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
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ContextMenuBar
            '
            Me.ContextMenuBar.AntiAlias = True
            Me.ContextMenuBar.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.ContextMenuBar.IsMaximized = False
            Me.ContextMenuBar.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCMB_DataArea})
            Me.ContextMenuBar.Location = New System.Drawing.Point(255, 7)
            Me.ContextMenuBar.Name = "ContextMenuBar"
            Me.ContextMenuBar.Size = New System.Drawing.Size(75, 25)
            Me.ContextMenuBar.Stretch = True
            Me.ContextMenuBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ContextMenuBar.TabIndex = 5
            Me.ContextMenuBar.TabStop = False
            Me.ContextMenuBar.Text = "ContextMenuBar1"
            '
            'ButtonItemCMB_DataArea
            '
            Me.ButtonItemCMB_DataArea.AutoExpandOnClick = True
            Me.ButtonItemCMB_DataArea.Name = "ButtonItemCMB_DataArea"
            Me.ButtonItemCMB_DataArea.Text = "DataArea"
            '
            'TabControlForm_Report
            '
            Me.TabControlForm_Report.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_Report.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_Report.CanReorderTabs = False
            Me.TabControlForm_Report.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_Report.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_Report.Controls.Add(Me.TabControlPanelStatementTab_Statement)
            Me.TabControlForm_Report.Controls.Add(Me.TabControlPanelDashboardTab_Dashboard)
            Me.TabControlForm_Report.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_Report.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_Report.Name = "TabControlForm_Report"
            Me.TabControlForm_Report.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_Report.SelectedTabIndex = 0
            Me.TabControlForm_Report.Size = New System.Drawing.Size(955, 397)
            Me.TabControlForm_Report.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_Report.TabIndex = 6
            Me.TabControlForm_Report.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_Report.Tabs.Add(Me.TabItemReport_StatementTab)
            Me.TabControlForm_Report.Tabs.Add(Me.TabItemReport_DashboardTab)
            '
            'TabControlPanelStatementTab_Statement
            '
            Me.TabControlPanelStatementTab_Statement.Controls.Add(Me.DataGridViewStatement_Statement)
            Me.TabControlPanelStatementTab_Statement.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelStatementTab_Statement.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelStatementTab_Statement.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelStatementTab_Statement.Name = "TabControlPanelStatementTab_Statement"
            Me.TabControlPanelStatementTab_Statement.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelStatementTab_Statement.Size = New System.Drawing.Size(955, 370)
            Me.TabControlPanelStatementTab_Statement.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelStatementTab_Statement.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelStatementTab_Statement.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelStatementTab_Statement.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelStatementTab_Statement.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelStatementTab_Statement.Style.GradientAngle = 90
            Me.TabControlPanelStatementTab_Statement.TabIndex = 2
            Me.TabControlPanelStatementTab_Statement.TabItem = Me.TabItemReport_StatementTab
            '
            'DataGridViewStatement_Statement
            '
            Me.DataGridViewStatement_Statement.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewStatement_Statement.AllowDragAndDrop = False
            Me.DataGridViewStatement_Statement.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewStatement_Statement.AllowSelectGroupHeaderRow = True
            Me.DataGridViewStatement_Statement.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewStatement_Statement.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewStatement_Statement.AutoFilterLookupColumns = False
            Me.DataGridViewStatement_Statement.AutoloadRepositoryDatasource = True
            Me.DataGridViewStatement_Statement.AutoUpdateViewCaption = True
            Me.DataGridViewStatement_Statement.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewStatement_Statement.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewStatement_Statement.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewStatement_Statement.ItemDescription = "Item(s)"
            Me.DataGridViewStatement_Statement.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewStatement_Statement.MultiSelect = True
            Me.DataGridViewStatement_Statement.Name = "DataGridViewStatement_Statement"
            Me.DataGridViewStatement_Statement.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewStatement_Statement.RunStandardValidation = True
            Me.DataGridViewStatement_Statement.ShowColumnMenuOnRightClick = False
            Me.DataGridViewStatement_Statement.ShowSelectDeselectAllButtons = False
            Me.DataGridViewStatement_Statement.Size = New System.Drawing.Size(947, 362)
            Me.DataGridViewStatement_Statement.TabIndex = 0
            Me.DataGridViewStatement_Statement.UseEmbeddedNavigator = False
            Me.DataGridViewStatement_Statement.ViewCaptionHeight = -1
            '
            'TabItemReport_StatementTab
            '
            Me.TabItemReport_StatementTab.AttachedControl = Me.TabControlPanelStatementTab_Statement
            Me.TabItemReport_StatementTab.Name = "TabItemReport_StatementTab"
            Me.TabItemReport_StatementTab.Text = "Statement"
            '
            'TabControlPanelDashboardTab_Dashboard
            '
            Me.TabControlPanelDashboardTab_Dashboard.Controls.Add(Me.DashboardViewerDashboard_Dashboard)
            Me.TabControlPanelDashboardTab_Dashboard.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDashboardTab_Dashboard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDashboardTab_Dashboard.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDashboardTab_Dashboard.Name = "TabControlPanelDashboardTab_Dashboard"
            Me.TabControlPanelDashboardTab_Dashboard.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDashboardTab_Dashboard.Size = New System.Drawing.Size(955, 370)
            Me.TabControlPanelDashboardTab_Dashboard.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDashboardTab_Dashboard.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDashboardTab_Dashboard.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDashboardTab_Dashboard.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDashboardTab_Dashboard.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDashboardTab_Dashboard.Style.GradientAngle = 90
            Me.TabControlPanelDashboardTab_Dashboard.TabIndex = 1
            Me.TabControlPanelDashboardTab_Dashboard.TabItem = Me.TabItemReport_DashboardTab
            '
            'DashboardViewerDashboard_Dashboard
            '
            Me.DashboardViewerDashboard_Dashboard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DashboardViewerDashboard_Dashboard.Location = New System.Drawing.Point(4, 4)
            Me.DashboardViewerDashboard_Dashboard.Name = "DashboardViewerDashboard_Dashboard"
            Me.DashboardViewerDashboard_Dashboard.Size = New System.Drawing.Size(945, 362)
            Me.DashboardViewerDashboard_Dashboard.TabIndex = 0
            '
            'TabItemReport_DashboardTab
            '
            Me.TabItemReport_DashboardTab.AttachedControl = Me.TabControlPanelDashboardTab_Dashboard
            Me.TabItemReport_DashboardTab.Name = "TabItemReport_DashboardTab"
            Me.TabItemReport_DashboardTab.Text = "Dashboard"
            '
            'ItemContainerCurrency_Vertical
            '
            '
            '
            '
            Me.ItemContainerCurrency_Vertical.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerCurrency_Vertical.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerCurrency_Vertical.Name = "ItemContainerCurrency_Vertical"
            Me.ItemContainerCurrency_Vertical.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemCurrency_Code, Me.LabelItemCurrency_Rate})
            '
            '
            '
            Me.ItemContainerCurrency_Vertical.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemCurrency_Code
            '
            Me.LabelItemCurrency_Code.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelItemCurrency_Code.ForeColor = System.Drawing.Color.Blue
            Me.LabelItemCurrency_Code.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
            Me.LabelItemCurrency_Code.Name = "LabelItemCurrency_Code"
            Me.LabelItemCurrency_Code.TextAlignment = System.Drawing.StringAlignment.Center
            '
            'LabelItemCurrency_Rate
            '
            Me.LabelItemCurrency_Rate.Name = "LabelItemCurrency_Rate"
            Me.LabelItemCurrency_Rate.TextAlignment = System.Drawing.StringAlignment.Center
            '
            'GLReportTemplateSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(979, 421)
            Me.Controls.Add(Me.ContextMenuBar)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.TabControlForm_Report)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "GLReportTemplateSetupForm"
            Me.Text = "GL Report Template Setup"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBarOptions_TemplateDetails.ResumeLayout(False)
            CType(Me.ContextMenuBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlForm_Report, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_Report.ResumeLayout(False)
            Me.TabControlPanelStatementTab_Statement.ResumeLayout(False)
            Me.TabControlPanelDashboardTab_Dashboard.ResumeLayout(False)
            CType(Me.DashboardViewerDashboard_Dashboard, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_TemplateDetails As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerTemplateDetails_TemplateDetails As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemTemplateDetails_TemplateName As DevComponents.DotNetBar.LabelItem
        Friend WithEvents TextBoxTemplateDetails_TemplateName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ControlContainerItemTemplateDetails_TemplateDetails As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ContextMenuBar As DevComponents.DotNetBar.ContextMenuBar
        Friend WithEvents ButtonItemCMB_DataArea As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Dashboard As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDashboard_Edit As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlForm_Report As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelDashboardTab_Dashboard As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DashboardViewerDashboard_Dashboard As AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl
        Friend WithEvents TabItemReport_DashboardTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelStatementTab_Statement As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewStatement_Statement As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemReport_StatementTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents RibbonBarOptions_Statement As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemStatement_View As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_TemplateRows As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemTemplateRows_AddNew As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemTemplateRows_Manage As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_TemplateColumns As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemTemplateColumns_AddNew As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemTemplateColumns_Manage As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemTemplateDetails_OptionsAndPresets As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerTemplateDetails_StatementType As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemStatementType_IncomeStatement As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemStatementType_BalanceSheet As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemStatementType_Other As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_BudgetData As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemBudgetData_Refresh As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Currency As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerCurrency_Vertical As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemCurrency_Code As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemCurrency_Rate As DevComponents.DotNetBar.LabelItem
    End Class

End Namespace

