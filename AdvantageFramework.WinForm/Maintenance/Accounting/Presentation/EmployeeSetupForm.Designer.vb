Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeSetupForm))
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.EmployeeControlRightSection_Employee = New AdvantageFramework.WinForm.Presentation.Controls.EmployeeControl()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_Employees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_CostRateAndDepartmentTeam = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemCostRateAndDepartmentTeam_Update = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_HRHistory = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemHRHistory_View = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_TimesheetFunction = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTimesheetFunctionCopy_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTimesheetFunctionCopy_CopyTo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_CDP = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemCDP_CDPCopy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemCDPCopy_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemCDPCopy_CopyTo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Employee = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemEmployee_EmployeeCopy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEmployeeCopy_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEmployeeCopy_CopyTo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDocuments_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Office = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemOffice_OfficeCopy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOfficeCopy_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOfficeCopy_CopyTo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_BillingRatesActions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemBillingRatesActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemBillingRatesActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_SecurityActions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemSecurityActions_AddUser = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemSecurityActions_ChangePassword = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_NotesActions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemNotesActions_CheckSpelling = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Terminate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_PrintFiltered = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarMergeContainerForm_Import = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarImport_Import = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemImport_Wizard = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemImport_PendingRecords = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_AdditionalEmails = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemAdditionalEmails_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemAdditionalEmails_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Import.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.EmployeeControlRightSection_Employee)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(236, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(843, 550)
            Me.PanelForm_RightSection.TabIndex = 2
            '
            'EmployeeControlRightSection_Employee
            '
            Me.EmployeeControlRightSection_Employee.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.EmployeeControlRightSection_Employee.Location = New System.Drawing.Point(6, 12)
            Me.EmployeeControlRightSection_Employee.Name = "EmployeeControlRightSection_Employee"
            Me.EmployeeControlRightSection_Employee.Size = New System.Drawing.Size(825, 529)
            Me.EmployeeControlRightSection_Employee.TabIndex = 0
            '
            'ExpandableSplitterControlForm_LeftRight
            '
            Me.ExpandableSplitterControlForm_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlForm_LeftRight.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(230, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 550)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 1
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Employees)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(230, 550)
            Me.PanelForm_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_Employees
            '
            Me.DataGridViewLeftSection_Employees.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_Employees.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_Employees.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_Employees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_Employees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_Employees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Employees.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_Employees.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_Employees.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_Employees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_Employees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_Employees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Employees.ItemDescription = ""
            Me.DataGridViewLeftSection_Employees.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_Employees.MultiSelect = True
            Me.DataGridViewLeftSection_Employees.Name = "DataGridViewLeftSection_Employees"
            Me.DataGridViewLeftSection_Employees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Employees.RunStandardValidation = True
            Me.DataGridViewLeftSection_Employees.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_Employees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Employees.Size = New System.Drawing.Size(212, 526)
            Me.DataGridViewLeftSection_Employees.TabIndex = 0
            Me.DataGridViewLeftSection_Employees.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Employees.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_AdditionalEmails)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_CostRateAndDepartmentTeam)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_HRHistory)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_TimesheetFunction)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_CDP)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Employee)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Documents)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Office)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_BillingRatesActions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_SecurityActions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_NotesActions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "Report"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1074, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 4
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_CostRateAndDepartmentTeam
            '
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.DragDropSupport = True
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCostRateAndDepartmentTeam_Update})
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.Location = New System.Drawing.Point(796, 0)
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.MinimumSize = New System.Drawing.Size(130, 0)
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.Name = "RibbonBarOptions_CostRateAndDepartmentTeam"
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.SecurityEnabled = True
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.Size = New System.Drawing.Size(130, 98)
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.TabIndex = 12
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.Text = "Cost and Department"
            '
            '
            '
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_CostRateAndDepartmentTeam.Visible = False
            '
            'ButtonItemCostRateAndDepartmentTeam_Update
            '
            Me.ButtonItemCostRateAndDepartmentTeam_Update.BeginGroup = True
            Me.ButtonItemCostRateAndDepartmentTeam_Update.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemCostRateAndDepartmentTeam_Update.Name = "ButtonItemCostRateAndDepartmentTeam_Update"
            Me.ButtonItemCostRateAndDepartmentTeam_Update.RibbonWordWrap = False
            Me.ButtonItemCostRateAndDepartmentTeam_Update.SecurityEnabled = True
            Me.ButtonItemCostRateAndDepartmentTeam_Update.SubItemsExpandWidth = 14
            Me.ButtonItemCostRateAndDepartmentTeam_Update.Text = "Update"
            '
            'RibbonBarOptions_HRHistory
            '
            Me.RibbonBarOptions_HRHistory.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_HRHistory.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_HRHistory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_HRHistory.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_HRHistory.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_HRHistory.DragDropSupport = True
            Me.RibbonBarOptions_HRHistory.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_HRHistory.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemHRHistory_View})
            Me.RibbonBarOptions_HRHistory.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_HRHistory.Location = New System.Drawing.Point(721, 0)
            Me.RibbonBarOptions_HRHistory.MinimumSize = New System.Drawing.Size(75, 0)
            Me.RibbonBarOptions_HRHistory.Name = "RibbonBarOptions_HRHistory"
            Me.RibbonBarOptions_HRHistory.SecurityEnabled = True
            Me.RibbonBarOptions_HRHistory.Size = New System.Drawing.Size(75, 98)
            Me.RibbonBarOptions_HRHistory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_HRHistory.TabIndex = 11
            Me.RibbonBarOptions_HRHistory.Text = "H/R History"
            '
            '
            '
            Me.RibbonBarOptions_HRHistory.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_HRHistory.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_HRHistory.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_HRHistory.Visible = False
            '
            'ButtonItemHRHistory_View
            '
            Me.ButtonItemHRHistory_View.BeginGroup = True
            Me.ButtonItemHRHistory_View.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemHRHistory_View.Name = "ButtonItemHRHistory_View"
            Me.ButtonItemHRHistory_View.RibbonWordWrap = False
            Me.ButtonItemHRHistory_View.SecurityEnabled = True
            Me.ButtonItemHRHistory_View.SubItemsExpandWidth = 14
            Me.ButtonItemHRHistory_View.Text = "View"
            '
            'RibbonBarOptions_TimesheetFunction
            '
            Me.RibbonBarOptions_TimesheetFunction.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_TimesheetFunction.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_TimesheetFunction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_TimesheetFunction.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_TimesheetFunction.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_TimesheetFunction.DragDropSupport = True
            Me.RibbonBarOptions_TimesheetFunction.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_TimesheetFunction.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy})
            Me.RibbonBarOptions_TimesheetFunction.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_TimesheetFunction.Location = New System.Drawing.Point(651, 0)
            Me.RibbonBarOptions_TimesheetFunction.MinimumSize = New System.Drawing.Size(70, 0)
            Me.RibbonBarOptions_TimesheetFunction.Name = "RibbonBarOptions_TimesheetFunction"
            Me.RibbonBarOptions_TimesheetFunction.SecurityEnabled = True
            Me.RibbonBarOptions_TimesheetFunction.Size = New System.Drawing.Size(70, 98)
            Me.RibbonBarOptions_TimesheetFunction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_TimesheetFunction.TabIndex = 10
            Me.RibbonBarOptions_TimesheetFunction.Text = "TS Function"
            '
            '
            '
            Me.RibbonBarOptions_TimesheetFunction.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_TimesheetFunction.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_TimesheetFunction.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemTimesheetFunction_TimesheetFunctionCopy
            '
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.AutoExpandOnClick = True
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.BeginGroup = True
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.Name = "ButtonItemTimesheetFunction_TimesheetFunctionCopy"
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.RibbonWordWrap = False
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.SecurityEnabled = True
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTimesheetFunctionCopy_CopyFrom, Me.ButtonItemTimesheetFunctionCopy_CopyTo})
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.SubItemsExpandWidth = 14
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.Text = "Copy"
            '
            'ButtonItemTimesheetFunctionCopy_CopyFrom
            '
            Me.ButtonItemTimesheetFunctionCopy_CopyFrom.Name = "ButtonItemTimesheetFunctionCopy_CopyFrom"
            Me.ButtonItemTimesheetFunctionCopy_CopyFrom.SecurityEnabled = True
            Me.ButtonItemTimesheetFunctionCopy_CopyFrom.Text = "Copy From Employee"
            '
            'ButtonItemTimesheetFunctionCopy_CopyTo
            '
            Me.ButtonItemTimesheetFunctionCopy_CopyTo.Name = "ButtonItemTimesheetFunctionCopy_CopyTo"
            Me.ButtonItemTimesheetFunctionCopy_CopyTo.SecurityEnabled = True
            Me.ButtonItemTimesheetFunctionCopy_CopyTo.Text = "Copy To Employee"
            '
            'RibbonBarOptions_CDP
            '
            Me.RibbonBarOptions_CDP.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_CDP.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_CDP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_CDP.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_CDP.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_CDP.DragDropSupport = True
            Me.RibbonBarOptions_CDP.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_CDP.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCDP_CDPCopy})
            Me.RibbonBarOptions_CDP.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_CDP.Location = New System.Drawing.Point(586, 0)
            Me.RibbonBarOptions_CDP.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_CDP.Name = "RibbonBarOptions_CDP"
            Me.RibbonBarOptions_CDP.SecurityEnabled = True
            Me.RibbonBarOptions_CDP.Size = New System.Drawing.Size(65, 98)
            Me.RibbonBarOptions_CDP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_CDP.TabIndex = 9
            Me.RibbonBarOptions_CDP.Text = "C/D/P"
            '
            '
            '
            Me.RibbonBarOptions_CDP.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_CDP.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_CDP.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemCDP_CDPCopy
            '
            Me.ButtonItemCDP_CDPCopy.AutoExpandOnClick = True
            Me.ButtonItemCDP_CDPCopy.BeginGroup = True
            Me.ButtonItemCDP_CDPCopy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemCDP_CDPCopy.Name = "ButtonItemCDP_CDPCopy"
            Me.ButtonItemCDP_CDPCopy.RibbonWordWrap = False
            Me.ButtonItemCDP_CDPCopy.SecurityEnabled = True
            Me.ButtonItemCDP_CDPCopy.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCDPCopy_CopyFrom, Me.ButtonItemCDPCopy_CopyTo})
            Me.ButtonItemCDP_CDPCopy.SubItemsExpandWidth = 14
            Me.ButtonItemCDP_CDPCopy.Text = "Copy"
            '
            'ButtonItemCDPCopy_CopyFrom
            '
            Me.ButtonItemCDPCopy_CopyFrom.Name = "ButtonItemCDPCopy_CopyFrom"
            Me.ButtonItemCDPCopy_CopyFrom.SecurityEnabled = True
            Me.ButtonItemCDPCopy_CopyFrom.Text = "Copy From User"
            '
            'ButtonItemCDPCopy_CopyTo
            '
            Me.ButtonItemCDPCopy_CopyTo.Name = "ButtonItemCDPCopy_CopyTo"
            Me.ButtonItemCDPCopy_CopyTo.SecurityEnabled = True
            Me.ButtonItemCDPCopy_CopyTo.Text = "Copy To User"
            '
            'RibbonBarOptions_Employee
            '
            Me.RibbonBarOptions_Employee.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Employee.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Employee.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Employee.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Employee.DragDropSupport = True
            Me.RibbonBarOptions_Employee.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Employee.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemEmployee_EmployeeCopy})
            Me.RibbonBarOptions_Employee.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Employee.Location = New System.Drawing.Point(521, 0)
            Me.RibbonBarOptions_Employee.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_Employee.Name = "RibbonBarOptions_Employee"
            Me.RibbonBarOptions_Employee.SecurityEnabled = True
            Me.RibbonBarOptions_Employee.Size = New System.Drawing.Size(65, 98)
            Me.RibbonBarOptions_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Employee.TabIndex = 8
            Me.RibbonBarOptions_Employee.Text = "Employee"
            '
            '
            '
            Me.RibbonBarOptions_Employee.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Employee.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Employee.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemEmployee_EmployeeCopy
            '
            Me.ButtonItemEmployee_EmployeeCopy.AutoExpandOnClick = True
            Me.ButtonItemEmployee_EmployeeCopy.BeginGroup = True
            Me.ButtonItemEmployee_EmployeeCopy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployee_EmployeeCopy.Name = "ButtonItemEmployee_EmployeeCopy"
            Me.ButtonItemEmployee_EmployeeCopy.RibbonWordWrap = False
            Me.ButtonItemEmployee_EmployeeCopy.SecurityEnabled = True
            Me.ButtonItemEmployee_EmployeeCopy.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemEmployeeCopy_CopyFrom, Me.ButtonItemEmployeeCopy_CopyTo})
            Me.ButtonItemEmployee_EmployeeCopy.SubItemsExpandWidth = 14
            Me.ButtonItemEmployee_EmployeeCopy.Text = "Copy"
            '
            'ButtonItemEmployeeCopy_CopyFrom
            '
            Me.ButtonItemEmployeeCopy_CopyFrom.Name = "ButtonItemEmployeeCopy_CopyFrom"
            Me.ButtonItemEmployeeCopy_CopyFrom.SecurityEnabled = True
            Me.ButtonItemEmployeeCopy_CopyFrom.Text = "Copy From User"
            '
            'ButtonItemEmployeeCopy_CopyTo
            '
            Me.ButtonItemEmployeeCopy_CopyTo.Name = "ButtonItemEmployeeCopy_CopyTo"
            Me.ButtonItemEmployeeCopy_CopyTo.SecurityEnabled = True
            Me.ButtonItemEmployeeCopy_CopyTo.Text = "Copy To User"
            '
            'RibbonBarOptions_Documents
            '
            Me.RibbonBarOptions_Documents.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Documents.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Documents.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Documents.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Documents.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Documents.DragDropSupport = True
            Me.RibbonBarOptions_Documents.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDocuments_Upload, Me.ButtonItemDocuments_Download, Me.ButtonItemDocuments_OpenURL, Me.ButtonItemDocuments_Delete})
            Me.RibbonBarOptions_Documents.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Documents.Location = New System.Drawing.Point(465, 0)
            Me.RibbonBarOptions_Documents.Name = "RibbonBarOptions_Documents"
            Me.RibbonBarOptions_Documents.SecurityEnabled = True
            Me.RibbonBarOptions_Documents.Size = New System.Drawing.Size(56, 98)
            Me.RibbonBarOptions_Documents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Documents.TabIndex = 7
            Me.RibbonBarOptions_Documents.Text = "Documents"
            '
            '
            '
            Me.RibbonBarOptions_Documents.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Documents.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Documents.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDocuments_Upload
            '
            Me.ButtonItemDocuments_Upload.BeginGroup = True
            Me.ButtonItemDocuments_Upload.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_Upload.Name = "ButtonItemDocuments_Upload"
            Me.ButtonItemDocuments_Upload.RibbonWordWrap = False
            Me.ButtonItemDocuments_Upload.SecurityEnabled = True
            Me.ButtonItemDocuments_Upload.SplitButton = True
            Me.ButtonItemDocuments_Upload.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUpload_EmailLink})
            Me.ButtonItemDocuments_Upload.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_Upload.Text = "Upload"
            '
            'ButtonItemUpload_EmailLink
            '
            Me.ButtonItemUpload_EmailLink.Name = "ButtonItemUpload_EmailLink"
            Me.ButtonItemUpload_EmailLink.Text = "Email Link"
            '
            'ButtonItemDocuments_Download
            '
            Me.ButtonItemDocuments_Download.BeginGroup = True
            Me.ButtonItemDocuments_Download.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_Download.Name = "ButtonItemDocuments_Download"
            Me.ButtonItemDocuments_Download.RibbonWordWrap = False
            Me.ButtonItemDocuments_Download.SecurityEnabled = True
            Me.ButtonItemDocuments_Download.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_Download.Text = "Download"
            '
            'ButtonItemDocuments_OpenURL
            '
            Me.ButtonItemDocuments_OpenURL.BeginGroup = True
            Me.ButtonItemDocuments_OpenURL.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_OpenURL.Name = "ButtonItemDocuments_OpenURL"
            Me.ButtonItemDocuments_OpenURL.RibbonWordWrap = False
            Me.ButtonItemDocuments_OpenURL.SecurityEnabled = True
            Me.ButtonItemDocuments_OpenURL.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_OpenURL.Text = "Open URL"
            '
            'ButtonItemDocuments_Delete
            '
            Me.ButtonItemDocuments_Delete.BeginGroup = True
            Me.ButtonItemDocuments_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_Delete.Name = "ButtonItemDocuments_Delete"
            Me.ButtonItemDocuments_Delete.RibbonWordWrap = False
            Me.ButtonItemDocuments_Delete.SecurityEnabled = True
            Me.ButtonItemDocuments_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_Delete.Text = "Delete"
            '
            'RibbonBarOptions_Office
            '
            Me.RibbonBarOptions_Office.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Office.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Office.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Office.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Office.DragDropSupport = True
            Me.RibbonBarOptions_Office.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Office.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOffice_OfficeCopy})
            Me.RibbonBarOptions_Office.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Office.Location = New System.Drawing.Point(400, 0)
            Me.RibbonBarOptions_Office.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_Office.Name = "RibbonBarOptions_Office"
            Me.RibbonBarOptions_Office.SecurityEnabled = True
            Me.RibbonBarOptions_Office.Size = New System.Drawing.Size(65, 98)
            Me.RibbonBarOptions_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Office.TabIndex = 5
            Me.RibbonBarOptions_Office.Text = "Office"
            '
            '
            '
            Me.RibbonBarOptions_Office.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Office.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Office.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemOffice_OfficeCopy
            '
            Me.ButtonItemOffice_OfficeCopy.AutoExpandOnClick = True
            Me.ButtonItemOffice_OfficeCopy.BeginGroup = True
            Me.ButtonItemOffice_OfficeCopy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOffice_OfficeCopy.Name = "ButtonItemOffice_OfficeCopy"
            Me.ButtonItemOffice_OfficeCopy.RibbonWordWrap = False
            Me.ButtonItemOffice_OfficeCopy.SecurityEnabled = True
            Me.ButtonItemOffice_OfficeCopy.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOfficeCopy_CopyFrom, Me.ButtonItemOfficeCopy_CopyTo})
            Me.ButtonItemOffice_OfficeCopy.SubItemsExpandWidth = 14
            Me.ButtonItemOffice_OfficeCopy.Text = "Copy"
            '
            'ButtonItemOfficeCopy_CopyFrom
            '
            Me.ButtonItemOfficeCopy_CopyFrom.Name = "ButtonItemOfficeCopy_CopyFrom"
            Me.ButtonItemOfficeCopy_CopyFrom.SecurityEnabled = True
            Me.ButtonItemOfficeCopy_CopyFrom.Text = "Copy From Employee"
            '
            'ButtonItemOfficeCopy_CopyTo
            '
            Me.ButtonItemOfficeCopy_CopyTo.Name = "ButtonItemOfficeCopy_CopyTo"
            Me.ButtonItemOfficeCopy_CopyTo.SecurityEnabled = True
            Me.ButtonItemOfficeCopy_CopyTo.Text = "Copy To Employee"
            '
            'RibbonBarOptions_BillingRatesActions
            '
            Me.RibbonBarOptions_BillingRatesActions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_BillingRatesActions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_BillingRatesActions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_BillingRatesActions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_BillingRatesActions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_BillingRatesActions.DragDropSupport = True
            Me.RibbonBarOptions_BillingRatesActions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemBillingRatesActions_Delete, Me.ButtonItemBillingRatesActions_Cancel})
            Me.RibbonBarOptions_BillingRatesActions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_BillingRatesActions.Location = New System.Drawing.Point(303, 0)
            Me.RibbonBarOptions_BillingRatesActions.Name = "RibbonBarOptions_BillingRatesActions"
            Me.RibbonBarOptions_BillingRatesActions.SecurityEnabled = True
            Me.RibbonBarOptions_BillingRatesActions.Size = New System.Drawing.Size(97, 98)
            Me.RibbonBarOptions_BillingRatesActions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_BillingRatesActions.TabIndex = 3
            Me.RibbonBarOptions_BillingRatesActions.Text = "Billing Rates"
            '
            '
            '
            Me.RibbonBarOptions_BillingRatesActions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_BillingRatesActions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_BillingRatesActions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_BillingRatesActions.Visible = False
            '
            'ButtonItemBillingRatesActions_Delete
            '
            Me.ButtonItemBillingRatesActions_Delete.BeginGroup = True
            Me.ButtonItemBillingRatesActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemBillingRatesActions_Delete.Name = "ButtonItemBillingRatesActions_Delete"
            Me.ButtonItemBillingRatesActions_Delete.RibbonWordWrap = False
            Me.ButtonItemBillingRatesActions_Delete.SecurityEnabled = True
            Me.ButtonItemBillingRatesActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemBillingRatesActions_Delete.Text = "Delete"
            '
            'ButtonItemBillingRatesActions_Cancel
            '
            Me.ButtonItemBillingRatesActions_Cancel.BeginGroup = True
            Me.ButtonItemBillingRatesActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemBillingRatesActions_Cancel.Name = "ButtonItemBillingRatesActions_Cancel"
            Me.ButtonItemBillingRatesActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemBillingRatesActions_Cancel.SecurityEnabled = True
            Me.ButtonItemBillingRatesActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemBillingRatesActions_Cancel.Text = "Cancel"
            '
            'RibbonBarOptions_SecurityActions
            '
            Me.RibbonBarOptions_SecurityActions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_SecurityActions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SecurityActions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SecurityActions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_SecurityActions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_SecurityActions.DragDropSupport = True
            Me.RibbonBarOptions_SecurityActions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSecurityActions_AddUser, Me.ButtonItemSecurityActions_ChangePassword})
            Me.RibbonBarOptions_SecurityActions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_SecurityActions.Location = New System.Drawing.Point(224, 0)
            Me.RibbonBarOptions_SecurityActions.Name = "RibbonBarOptions_SecurityActions"
            Me.RibbonBarOptions_SecurityActions.SecurityEnabled = True
            Me.RibbonBarOptions_SecurityActions.Size = New System.Drawing.Size(79, 98)
            Me.RibbonBarOptions_SecurityActions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_SecurityActions.TabIndex = 2
            Me.RibbonBarOptions_SecurityActions.Text = "Security"
            '
            '
            '
            Me.RibbonBarOptions_SecurityActions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SecurityActions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SecurityActions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemSecurityActions_AddUser
            '
            Me.ButtonItemSecurityActions_AddUser.BeginGroup = True
            Me.ButtonItemSecurityActions_AddUser.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSecurityActions_AddUser.Name = "ButtonItemSecurityActions_AddUser"
            Me.ButtonItemSecurityActions_AddUser.RibbonWordWrap = False
            Me.ButtonItemSecurityActions_AddUser.SecurityEnabled = True
            Me.ButtonItemSecurityActions_AddUser.SubItemsExpandWidth = 14
            Me.ButtonItemSecurityActions_AddUser.Text = "Add User"
            '
            'ButtonItemSecurityActions_ChangePassword
            '
            Me.ButtonItemSecurityActions_ChangePassword.BeginGroup = True
            Me.ButtonItemSecurityActions_ChangePassword.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSecurityActions_ChangePassword.Name = "ButtonItemSecurityActions_ChangePassword"
            Me.ButtonItemSecurityActions_ChangePassword.RibbonWordWrap = False
            Me.ButtonItemSecurityActions_ChangePassword.SecurityEnabled = True
            Me.ButtonItemSecurityActions_ChangePassword.SubItemsExpandWidth = 14
            Me.ButtonItemSecurityActions_ChangePassword.Text = "Change Password"
            '
            'RibbonBarOptions_NotesActions
            '
            Me.RibbonBarOptions_NotesActions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_NotesActions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_NotesActions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_NotesActions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_NotesActions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_NotesActions.DragDropSupport = True
            Me.RibbonBarOptions_NotesActions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemNotesActions_CheckSpelling})
            Me.RibbonBarOptions_NotesActions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_NotesActions.Location = New System.Drawing.Point(125, 0)
            Me.RibbonBarOptions_NotesActions.Name = "RibbonBarOptions_NotesActions"
            Me.RibbonBarOptions_NotesActions.SecurityEnabled = True
            Me.RibbonBarOptions_NotesActions.Size = New System.Drawing.Size(99, 98)
            Me.RibbonBarOptions_NotesActions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_NotesActions.TabIndex = 1
            Me.RibbonBarOptions_NotesActions.Text = "Notes"
            '
            '
            '
            Me.RibbonBarOptions_NotesActions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_NotesActions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_NotesActions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemNotesActions_CheckSpelling
            '
            Me.ButtonItemNotesActions_CheckSpelling.BeginGroup = True
            Me.ButtonItemNotesActions_CheckSpelling.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemNotesActions_CheckSpelling.Name = "ButtonItemNotesActions_CheckSpelling"
            Me.ButtonItemNotesActions_CheckSpelling.RibbonWordWrap = False
            Me.ButtonItemNotesActions_CheckSpelling.SecurityEnabled = True
            Me.ButtonItemNotesActions_CheckSpelling.SubItemsExpandWidth = 14
            Me.ButtonItemNotesActions_CheckSpelling.Text = "Check Spelling"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Terminate, Me.ButtonItemActions_Print, Me.ButtonItemActions_PrintFiltered, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(125, 98)
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
            'ButtonItemActions_Terminate
            '
            Me.ButtonItemActions_Terminate.BeginGroup = True
            Me.ButtonItemActions_Terminate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Terminate.Name = "ButtonItemActions_Terminate"
            Me.ButtonItemActions_Terminate.RibbonWordWrap = False
            Me.ButtonItemActions_Terminate.SecurityEnabled = True
            Me.ButtonItemActions_Terminate.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Terminate.Text = "Terminate"
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
            'ButtonItemActions_PrintFiltered
            '
            Me.ButtonItemActions_PrintFiltered.BeginGroup = True
            Me.ButtonItemActions_PrintFiltered.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_PrintFiltered.Name = "ButtonItemActions_PrintFiltered"
            Me.ButtonItemActions_PrintFiltered.RibbonWordWrap = False
            Me.ButtonItemActions_PrintFiltered.SecurityEnabled = True
            Me.ButtonItemActions_PrintFiltered.SubItemsExpandWidth = 14
            Me.ButtonItemActions_PrintFiltered.Text = "Print Filtered"
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.SecurityEnabled = True
            Me.ButtonItemActions_Refresh.Stretch = True
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'RibbonBarMergeContainerForm_Import
            '
            Me.RibbonBarMergeContainerForm_Import.AutoActivateTab = False
            Me.RibbonBarMergeContainerForm_Import.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Import.Controls.Add(Me.RibbonBarImport_Import)
            Me.RibbonBarMergeContainerForm_Import.Location = New System.Drawing.Point(454, 226)
            Me.RibbonBarMergeContainerForm_Import.MergeRibbonGroupName = "Report"
            Me.RibbonBarMergeContainerForm_Import.Name = "RibbonBarMergeContainerForm_Import"
            Me.RibbonBarMergeContainerForm_Import.RibbonTabText = "Import"
            Me.RibbonBarMergeContainerForm_Import.Size = New System.Drawing.Size(171, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Import.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Import.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Import.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Import.TabIndex = 3
            Me.RibbonBarMergeContainerForm_Import.Visible = False
            '
            'RibbonBarImport_Import
            '
            Me.RibbonBarImport_Import.AutoOverflowEnabled = False
            Me.RibbonBarImport_Import.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarImport_Import.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarImport_Import.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarImport_Import.ContainerControlProcessDialogKey = True
            Me.RibbonBarImport_Import.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarImport_Import.DragDropSupport = True
            Me.RibbonBarImport_Import.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarImport_Import.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemImport_Wizard, Me.ButtonItemImport_PendingRecords})
            Me.RibbonBarImport_Import.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarImport_Import.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarImport_Import.Name = "RibbonBarImport_Import"
            Me.RibbonBarImport_Import.SecurityEnabled = True
            Me.RibbonBarImport_Import.Size = New System.Drawing.Size(150, 98)
            Me.RibbonBarImport_Import.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarImport_Import.TabIndex = 0
            Me.RibbonBarImport_Import.Text = "Import"
            '
            '
            '
            Me.RibbonBarImport_Import.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarImport_Import.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarImport_Import.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemImport_Wizard
            '
            Me.ButtonItemImport_Wizard.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemImport_Wizard.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemImport_Wizard.Name = "ButtonItemImport_Wizard"
            Me.ButtonItemImport_Wizard.RibbonWordWrap = False
            Me.ButtonItemImport_Wizard.SecurityEnabled = True
            Me.ButtonItemImport_Wizard.SubItemsExpandWidth = 14
            Me.ButtonItemImport_Wizard.Text = "Wizard"
            '
            'ButtonItemImport_PendingRecords
            '
            Me.ButtonItemImport_PendingRecords.BeginGroup = True
            Me.ButtonItemImport_PendingRecords.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemImport_PendingRecords.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemImport_PendingRecords.Name = "ButtonItemImport_PendingRecords"
            Me.ButtonItemImport_PendingRecords.RibbonWordWrap = False
            Me.ButtonItemImport_PendingRecords.SecurityEnabled = True
            Me.ButtonItemImport_PendingRecords.SubItemsExpandWidth = 14
            Me.ButtonItemImport_PendingRecords.Text = "Pending Records"
            '
            'RibbonBarOptions_AdditionalEmails
            '
            Me.RibbonBarOptions_AdditionalEmails.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_AdditionalEmails.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_AdditionalEmails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_AdditionalEmails.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_AdditionalEmails.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_AdditionalEmails.DragDropSupport = True
            Me.RibbonBarOptions_AdditionalEmails.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemAdditionalEmails_Add, Me.ButtonItemAdditionalEmails_Delete})
            Me.RibbonBarOptions_AdditionalEmails.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_AdditionalEmails.Location = New System.Drawing.Point(926, 0)
            Me.RibbonBarOptions_AdditionalEmails.Name = "RibbonBarOptions_AdditionalEmails"
            Me.RibbonBarOptions_AdditionalEmails.SecurityEnabled = True
            Me.RibbonBarOptions_AdditionalEmails.Size = New System.Drawing.Size(115, 98)
            Me.RibbonBarOptions_AdditionalEmails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_AdditionalEmails.TabIndex = 13
            Me.RibbonBarOptions_AdditionalEmails.Text = "Additional Emails"
            '
            '
            '
            Me.RibbonBarOptions_AdditionalEmails.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_AdditionalEmails.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_AdditionalEmails.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_AdditionalEmails.Visible = False
            '
            'ButtonItemAdditionalEmails_Add
            '
            Me.ButtonItemAdditionalEmails_Add.BeginGroup = True
            Me.ButtonItemAdditionalEmails_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemAdditionalEmails_Add.Name = "ButtonItemAdditionalEmails_Add"
            Me.ButtonItemAdditionalEmails_Add.RibbonWordWrap = False
            Me.ButtonItemAdditionalEmails_Add.SecurityEnabled = True
            Me.ButtonItemAdditionalEmails_Add.SubItemsExpandWidth = 14
            Me.ButtonItemAdditionalEmails_Add.Text = "Add"
            '
            'ButtonItemAdditionalEmails_Delete
            '
            Me.ButtonItemAdditionalEmails_Delete.BeginGroup = True
            Me.ButtonItemAdditionalEmails_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemAdditionalEmails_Delete.Name = "ButtonItemAdditionalEmails_Delete"
            Me.ButtonItemAdditionalEmails_Delete.RibbonWordWrap = False
            Me.ButtonItemAdditionalEmails_Delete.SecurityEnabled = True
            Me.ButtonItemAdditionalEmails_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemAdditionalEmails_Delete.Text = "Delete"
            '
            'EmployeeSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1079, 550)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Import)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeSetupForm"
            Me.Text = "Employee Maintenance"
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Import.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_Employees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Terminate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents EmployeeControlRightSection_Employee As AdvantageFramework.WinForm.Presentation.Controls.EmployeeControl
        Friend WithEvents RibbonBarOptions_NotesActions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_SecurityActions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemNotesActions_CheckSpelling As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSecurityActions_AddUser As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSecurityActions_ChangePassword As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_BillingRatesActions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemBillingRatesActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemBillingRatesActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Office As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemOffice_OfficeCopy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOfficeCopy_CopyFrom As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOfficeCopy_CopyTo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Documents As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDocuments_Upload As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_OpenURL As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_PrintFiltered As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_Import As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarImport_Import As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemImport_Wizard As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemImport_PendingRecords As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Employee As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemEmployee_EmployeeCopy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEmployeeCopy_CopyFrom As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEmployeeCopy_CopyTo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_TimesheetFunction As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemTimesheetFunction_TimesheetFunctionCopy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTimesheetFunctionCopy_CopyFrom As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTimesheetFunctionCopy_CopyTo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_CDP As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemCDP_CDPCopy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemCDPCopy_CopyFrom As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemCDPCopy_CopyTo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_HRHistory As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemHRHistory_View As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_CostRateAndDepartmentTeam As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemCostRateAndDepartmentTeam_Update As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_AdditionalEmails As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemAdditionalEmails_Add As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemAdditionalEmails_Delete As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace