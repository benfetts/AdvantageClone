Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeUpdateSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeUpdateSetupForm))
            Me.DataGridViewLeftSection_Employees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabControRightSection_EmployeeDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelGeneralInformationTab_GeneralInformation = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewGeneralInformation_GeneralInformation = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemEmployeeDetails_GeneralInformationTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewEmployeeSettings_EmployeeSettings = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemEmployeeDetails_EmployeeSettingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelHRInformationTab_HRInformation = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewHRInformation_HRInformation = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemEmployeeDetails_HRInformationTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelNotesTab_Notes = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewNotes_Notes = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemEmployeeDetails_NotesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_HRHistory = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemHRHistory_View = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Text = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemText_CheckSpelling = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Sort = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemSort_Code = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemSort_FirstName = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSort_LastName = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_PrintFiltered = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_AccruePaidTimeOff = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_UpdateDates = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_CostAndDepartmentUpdate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ExpandableSplitterForm_LeftRightSection = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonItemActions_ImportHours = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            CType(Me.TabControRightSection_EmployeeDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControRightSection_EmployeeDetails.SuspendLayout()
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.SuspendLayout()
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.SuspendLayout()
            Me.TabControlPanelHRInformationTab_HRInformation.SuspendLayout()
            Me.TabControlPanelNotesTab_Notes.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.SuspendLayout()
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
            Me.DataGridViewLeftSection_Employees.DataSource = Nothing
            Me.DataGridViewLeftSection_Employees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_Employees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Employees.ItemDescription = ""
            Me.DataGridViewLeftSection_Employees.Location = New System.Drawing.Point(9, 17)
            Me.DataGridViewLeftSection_Employees.MultiSelect = True
            Me.DataGridViewLeftSection_Employees.Name = "DataGridViewLeftSection_Employees"
            Me.DataGridViewLeftSection_Employees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Employees.RunStandardValidation = True
            Me.DataGridViewLeftSection_Employees.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_Employees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Employees.Size = New System.Drawing.Size(211, 498)
            Me.DataGridViewLeftSection_Employees.TabIndex = 0
            Me.DataGridViewLeftSection_Employees.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Employees.ViewCaptionHeight = -1
            '
            'TabControRightSection_EmployeeDetails
            '
            Me.TabControRightSection_EmployeeDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControRightSection_EmployeeDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControRightSection_EmployeeDetails.CanReorderTabs = False
            Me.TabControRightSection_EmployeeDetails.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControRightSection_EmployeeDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControRightSection_EmployeeDetails.Controls.Add(Me.TabControlPanelGeneralInformationTab_GeneralInformation)
            Me.TabControRightSection_EmployeeDetails.Controls.Add(Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings)
            Me.TabControRightSection_EmployeeDetails.Controls.Add(Me.TabControlPanelHRInformationTab_HRInformation)
            Me.TabControRightSection_EmployeeDetails.Controls.Add(Me.TabControlPanelNotesTab_Notes)
            Me.TabControRightSection_EmployeeDetails.Location = New System.Drawing.Point(6, 9)
            Me.TabControRightSection_EmployeeDetails.Name = "TabControRightSection_EmployeeDetails"
            Me.TabControRightSection_EmployeeDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControRightSection_EmployeeDetails.SelectedTabIndex = 0
            Me.TabControRightSection_EmployeeDetails.Size = New System.Drawing.Size(658, 506)
            Me.TabControRightSection_EmployeeDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControRightSection_EmployeeDetails.TabIndex = 0
            Me.TabControRightSection_EmployeeDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControRightSection_EmployeeDetails.Tabs.Add(Me.TabItemEmployeeDetails_GeneralInformationTab)
            Me.TabControRightSection_EmployeeDetails.Tabs.Add(Me.TabItemEmployeeDetails_EmployeeSettingsTab)
            Me.TabControRightSection_EmployeeDetails.Tabs.Add(Me.TabItemEmployeeDetails_HRInformationTab)
            Me.TabControRightSection_EmployeeDetails.Tabs.Add(Me.TabItemEmployeeDetails_NotesTab)
            '
            'TabControlPanelGeneralInformationTab_GeneralInformation
            '
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Controls.Add(Me.DataGridViewGeneralInformation_GeneralInformation)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Margin = New System.Windows.Forms.Padding(0)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Name = "TabControlPanelGeneralInformationTab_GeneralInformation"
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Size = New System.Drawing.Size(658, 479)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Style.GradientAngle = 90
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.TabIndex = 0
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.TabItem = Me.TabItemEmployeeDetails_GeneralInformationTab
            '
            'DataGridViewGeneralInformation_GeneralInformation
            '
            Me.DataGridViewGeneralInformation_GeneralInformation.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewGeneralInformation_GeneralInformation.AllowDragAndDrop = False
            Me.DataGridViewGeneralInformation_GeneralInformation.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewGeneralInformation_GeneralInformation.AllowSelectGroupHeaderRow = True
            Me.DataGridViewGeneralInformation_GeneralInformation.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewGeneralInformation_GeneralInformation.AutoFilterLookupColumns = False
            Me.DataGridViewGeneralInformation_GeneralInformation.AutoloadRepositoryDatasource = True
            Me.DataGridViewGeneralInformation_GeneralInformation.AutoUpdateViewCaption = True
            Me.DataGridViewGeneralInformation_GeneralInformation.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewGeneralInformation_GeneralInformation.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewGeneralInformation_GeneralInformation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewGeneralInformation_GeneralInformation.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewGeneralInformation_GeneralInformation.ItemDescription = ""
            Me.DataGridViewGeneralInformation_GeneralInformation.Location = New System.Drawing.Point(1, 1)
            Me.DataGridViewGeneralInformation_GeneralInformation.Margin = New System.Windows.Forms.Padding(0)
            Me.DataGridViewGeneralInformation_GeneralInformation.MultiSelect = True
            Me.DataGridViewGeneralInformation_GeneralInformation.Name = "DataGridViewGeneralInformation_GeneralInformation"
            Me.DataGridViewGeneralInformation_GeneralInformation.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewGeneralInformation_GeneralInformation.RunStandardValidation = True
            Me.DataGridViewGeneralInformation_GeneralInformation.ShowColumnMenuOnRightClick = False
            Me.DataGridViewGeneralInformation_GeneralInformation.ShowSelectDeselectAllButtons = False
            Me.DataGridViewGeneralInformation_GeneralInformation.Size = New System.Drawing.Size(656, 477)
            Me.DataGridViewGeneralInformation_GeneralInformation.TabIndex = 0
            Me.DataGridViewGeneralInformation_GeneralInformation.UseEmbeddedNavigator = False
            Me.DataGridViewGeneralInformation_GeneralInformation.ViewCaptionHeight = -1
            '
            'TabItemEmployeeDetails_GeneralInformationTab
            '
            Me.TabItemEmployeeDetails_GeneralInformationTab.AttachedControl = Me.TabControlPanelGeneralInformationTab_GeneralInformation
            Me.TabItemEmployeeDetails_GeneralInformationTab.Name = "TabItemEmployeeDetails_GeneralInformationTab"
            Me.TabItemEmployeeDetails_GeneralInformationTab.Text = "General Information"
            '
            'TabControlPanelEmployeeSettingsTab_EmployeeSettings
            '
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.Controls.Add(Me.DataGridViewEmployeeSettings_EmployeeSettings)
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.Margin = New System.Windows.Forms.Padding(0)
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.Name = "TabControlPanelEmployeeSettingsTab_EmployeeSettings"
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.Size = New System.Drawing.Size(658, 479)
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.Style.GradientAngle = 90
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.TabIndex = 1
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.TabItem = Me.TabItemEmployeeDetails_EmployeeSettingsTab
            '
            'DataGridViewEmployeeSettings_EmployeeSettings
            '
            Me.DataGridViewEmployeeSettings_EmployeeSettings.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewEmployeeSettings_EmployeeSettings.AllowDragAndDrop = False
            Me.DataGridViewEmployeeSettings_EmployeeSettings.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewEmployeeSettings_EmployeeSettings.AllowSelectGroupHeaderRow = True
            Me.DataGridViewEmployeeSettings_EmployeeSettings.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewEmployeeSettings_EmployeeSettings.AutoFilterLookupColumns = False
            Me.DataGridViewEmployeeSettings_EmployeeSettings.AutoloadRepositoryDatasource = True
            Me.DataGridViewEmployeeSettings_EmployeeSettings.AutoUpdateViewCaption = True
            Me.DataGridViewEmployeeSettings_EmployeeSettings.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewEmployeeSettings_EmployeeSettings.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewEmployeeSettings_EmployeeSettings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewEmployeeSettings_EmployeeSettings.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewEmployeeSettings_EmployeeSettings.ItemDescription = ""
            Me.DataGridViewEmployeeSettings_EmployeeSettings.Location = New System.Drawing.Point(1, 1)
            Me.DataGridViewEmployeeSettings_EmployeeSettings.MultiSelect = True
            Me.DataGridViewEmployeeSettings_EmployeeSettings.Name = "DataGridViewEmployeeSettings_EmployeeSettings"
            Me.DataGridViewEmployeeSettings_EmployeeSettings.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewEmployeeSettings_EmployeeSettings.RunStandardValidation = True
            Me.DataGridViewEmployeeSettings_EmployeeSettings.ShowColumnMenuOnRightClick = False
            Me.DataGridViewEmployeeSettings_EmployeeSettings.ShowSelectDeselectAllButtons = False
            Me.DataGridViewEmployeeSettings_EmployeeSettings.Size = New System.Drawing.Size(656, 477)
            Me.DataGridViewEmployeeSettings_EmployeeSettings.TabIndex = 1
            Me.DataGridViewEmployeeSettings_EmployeeSettings.UseEmbeddedNavigator = False
            Me.DataGridViewEmployeeSettings_EmployeeSettings.ViewCaptionHeight = -1
            '
            'TabItemEmployeeDetails_EmployeeSettingsTab
            '
            Me.TabItemEmployeeDetails_EmployeeSettingsTab.AttachedControl = Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings
            Me.TabItemEmployeeDetails_EmployeeSettingsTab.Name = "TabItemEmployeeDetails_EmployeeSettingsTab"
            Me.TabItemEmployeeDetails_EmployeeSettingsTab.Text = "Employee Settings"
            '
            'TabControlPanelHRInformationTab_HRInformation
            '
            Me.TabControlPanelHRInformationTab_HRInformation.Controls.Add(Me.DataGridViewHRInformation_HRInformation)
            Me.TabControlPanelHRInformationTab_HRInformation.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelHRInformationTab_HRInformation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelHRInformationTab_HRInformation.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelHRInformationTab_HRInformation.Margin = New System.Windows.Forms.Padding(0)
            Me.TabControlPanelHRInformationTab_HRInformation.Name = "TabControlPanelHRInformationTab_HRInformation"
            Me.TabControlPanelHRInformationTab_HRInformation.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelHRInformationTab_HRInformation.Size = New System.Drawing.Size(658, 479)
            Me.TabControlPanelHRInformationTab_HRInformation.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelHRInformationTab_HRInformation.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelHRInformationTab_HRInformation.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelHRInformationTab_HRInformation.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelHRInformationTab_HRInformation.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelHRInformationTab_HRInformation.Style.GradientAngle = 90
            Me.TabControlPanelHRInformationTab_HRInformation.TabIndex = 0
            Me.TabControlPanelHRInformationTab_HRInformation.TabItem = Me.TabItemEmployeeDetails_HRInformationTab
            '
            'DataGridViewHRInformation_HRInformation
            '
            Me.DataGridViewHRInformation_HRInformation.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewHRInformation_HRInformation.AllowDragAndDrop = False
            Me.DataGridViewHRInformation_HRInformation.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewHRInformation_HRInformation.AllowSelectGroupHeaderRow = True
            Me.DataGridViewHRInformation_HRInformation.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewHRInformation_HRInformation.AutoFilterLookupColumns = False
            Me.DataGridViewHRInformation_HRInformation.AutoloadRepositoryDatasource = True
            Me.DataGridViewHRInformation_HRInformation.AutoUpdateViewCaption = True
            Me.DataGridViewHRInformation_HRInformation.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewHRInformation_HRInformation.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewHRInformation_HRInformation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewHRInformation_HRInformation.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewHRInformation_HRInformation.ItemDescription = ""
            Me.DataGridViewHRInformation_HRInformation.Location = New System.Drawing.Point(1, 1)
            Me.DataGridViewHRInformation_HRInformation.MultiSelect = True
            Me.DataGridViewHRInformation_HRInformation.Name = "DataGridViewHRInformation_HRInformation"
            Me.DataGridViewHRInformation_HRInformation.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewHRInformation_HRInformation.RunStandardValidation = True
            Me.DataGridViewHRInformation_HRInformation.ShowColumnMenuOnRightClick = False
            Me.DataGridViewHRInformation_HRInformation.ShowSelectDeselectAllButtons = False
            Me.DataGridViewHRInformation_HRInformation.Size = New System.Drawing.Size(656, 477)
            Me.DataGridViewHRInformation_HRInformation.TabIndex = 1
            Me.DataGridViewHRInformation_HRInformation.UseEmbeddedNavigator = False
            Me.DataGridViewHRInformation_HRInformation.ViewCaptionHeight = -1
            '
            'TabItemEmployeeDetails_HRInformationTab
            '
            Me.TabItemEmployeeDetails_HRInformationTab.AttachedControl = Me.TabControlPanelHRInformationTab_HRInformation
            Me.TabItemEmployeeDetails_HRInformationTab.Name = "TabItemEmployeeDetails_HRInformationTab"
            Me.TabItemEmployeeDetails_HRInformationTab.Text = "H/R && Rate Information"
            '
            'TabControlPanelNotesTab_Notes
            '
            Me.TabControlPanelNotesTab_Notes.Controls.Add(Me.DataGridViewNotes_Notes)
            Me.TabControlPanelNotesTab_Notes.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelNotesTab_Notes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelNotesTab_Notes.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelNotesTab_Notes.Margin = New System.Windows.Forms.Padding(0)
            Me.TabControlPanelNotesTab_Notes.Name = "TabControlPanelNotesTab_Notes"
            Me.TabControlPanelNotesTab_Notes.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelNotesTab_Notes.Size = New System.Drawing.Size(658, 479)
            Me.TabControlPanelNotesTab_Notes.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelNotesTab_Notes.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelNotesTab_Notes.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelNotesTab_Notes.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelNotesTab_Notes.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelNotesTab_Notes.Style.GradientAngle = 90
            Me.TabControlPanelNotesTab_Notes.TabIndex = 2
            Me.TabControlPanelNotesTab_Notes.TabItem = Me.TabItemEmployeeDetails_NotesTab
            '
            'DataGridViewNotes_Notes
            '
            Me.DataGridViewNotes_Notes.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewNotes_Notes.AllowDragAndDrop = False
            Me.DataGridViewNotes_Notes.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewNotes_Notes.AllowSelectGroupHeaderRow = True
            Me.DataGridViewNotes_Notes.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewNotes_Notes.AutoFilterLookupColumns = False
            Me.DataGridViewNotes_Notes.AutoloadRepositoryDatasource = True
            Me.DataGridViewNotes_Notes.AutoUpdateViewCaption = True
            Me.DataGridViewNotes_Notes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewNotes_Notes.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewNotes_Notes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewNotes_Notes.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewNotes_Notes.ItemDescription = ""
            Me.DataGridViewNotes_Notes.Location = New System.Drawing.Point(1, 1)
            Me.DataGridViewNotes_Notes.MultiSelect = True
            Me.DataGridViewNotes_Notes.Name = "DataGridViewNotes_Notes"
            Me.DataGridViewNotes_Notes.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewNotes_Notes.RunStandardValidation = True
            Me.DataGridViewNotes_Notes.ShowColumnMenuOnRightClick = False
            Me.DataGridViewNotes_Notes.ShowSelectDeselectAllButtons = False
            Me.DataGridViewNotes_Notes.Size = New System.Drawing.Size(656, 477)
            Me.DataGridViewNotes_Notes.TabIndex = 1
            Me.DataGridViewNotes_Notes.UseEmbeddedNavigator = False
            Me.DataGridViewNotes_Notes.ViewCaptionHeight = -1
            '
            'TabItemEmployeeDetails_NotesTab
            '
            Me.TabItemEmployeeDetails_NotesTab.AttachedControl = Me.TabControlPanelNotesTab_Notes
            Me.TabItemEmployeeDetails_NotesTab.Name = "TabItemEmployeeDetails_NotesTab"
            Me.TabItemEmployeeDetails_NotesTab.Text = "Notes"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_HRHistory)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Text)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Sort)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(123, 305)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(769, 98)
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
            Me.RibbonBarOptions_HRHistory.Location = New System.Drawing.Point(680, 0)
            Me.RibbonBarOptions_HRHistory.MinimumSize = New System.Drawing.Size(75, 0)
            Me.RibbonBarOptions_HRHistory.Name = "RibbonBarOptions_HRHistory"
            Me.RibbonBarOptions_HRHistory.SecurityEnabled = True
            Me.RibbonBarOptions_HRHistory.Size = New System.Drawing.Size(75, 98)
            Me.RibbonBarOptions_HRHistory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_HRHistory.TabIndex = 12
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
            'RibbonBarOptions_Text
            '
            Me.RibbonBarOptions_Text.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Text.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Text.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Text.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Text.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Text.DragDropSupport = True
            Me.RibbonBarOptions_Text.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemText_CheckSpelling})
            Me.RibbonBarOptions_Text.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Text.Location = New System.Drawing.Point(581, 0)
            Me.RibbonBarOptions_Text.Name = "RibbonBarOptions_Text"
            Me.RibbonBarOptions_Text.SecurityEnabled = True
            Me.RibbonBarOptions_Text.Size = New System.Drawing.Size(99, 98)
            Me.RibbonBarOptions_Text.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Text.TabIndex = 8
            Me.RibbonBarOptions_Text.Text = "Text"
            '
            '
            '
            Me.RibbonBarOptions_Text.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Text.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Text.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Text.Visible = False
            '
            'ButtonItemText_CheckSpelling
            '
            Me.ButtonItemText_CheckSpelling.BeginGroup = True
            Me.ButtonItemText_CheckSpelling.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemText_CheckSpelling.Name = "ButtonItemText_CheckSpelling"
            Me.ButtonItemText_CheckSpelling.RibbonWordWrap = False
            Me.ButtonItemText_CheckSpelling.SecurityEnabled = True
            Me.ButtonItemText_CheckSpelling.SubItemsExpandWidth = 14
            Me.ButtonItemText_CheckSpelling.Text = "Check Spelling"
            '
            'RibbonBarOptions_Sort
            '
            Me.RibbonBarOptions_Sort.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Sort.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Sort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Sort.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Sort.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Sort.DragDropSupport = True
            Me.RibbonBarOptions_Sort.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Sort.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSort_Code, Me.ButtonItemSort_FirstName, Me.ButtonItemSort_LastName})
            Me.RibbonBarOptions_Sort.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_Sort.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Sort.Location = New System.Drawing.Point(506, 0)
            Me.RibbonBarOptions_Sort.MinimumSize = New System.Drawing.Size(75, 0)
            Me.RibbonBarOptions_Sort.Name = "RibbonBarOptions_Sort"
            Me.RibbonBarOptions_Sort.SecurityEnabled = True
            Me.RibbonBarOptions_Sort.Size = New System.Drawing.Size(75, 98)
            Me.RibbonBarOptions_Sort.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Sort.TabIndex = 13
            Me.RibbonBarOptions_Sort.Text = "Sort"
            '
            '
            '
            Me.RibbonBarOptions_Sort.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Sort.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Sort.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemSort_Code
            '
            Me.ButtonItemSort_Code.AutoCheckOnClick = True
            Me.ButtonItemSort_Code.BeginGroup = True
            Me.ButtonItemSort_Code.Checked = True
            Me.ButtonItemSort_Code.Name = "ButtonItemSort_Code"
            Me.ButtonItemSort_Code.OptionGroup = "Sort"
            Me.ButtonItemSort_Code.RibbonWordWrap = False
            Me.ButtonItemSort_Code.SecurityEnabled = True
            Me.ButtonItemSort_Code.SubItemsExpandWidth = 14
            Me.ButtonItemSort_Code.Text = "Code"
            '
            'ButtonItemSort_FirstName
            '
            Me.ButtonItemSort_FirstName.AutoCheckOnClick = True
            Me.ButtonItemSort_FirstName.Name = "ButtonItemSort_FirstName"
            Me.ButtonItemSort_FirstName.OptionGroup = "Sort"
            Me.ButtonItemSort_FirstName.SubItemsExpandWidth = 14
            Me.ButtonItemSort_FirstName.Text = "First Name"
            '
            'ButtonItemSort_LastName
            '
            Me.ButtonItemSort_LastName.AutoCheckOnClick = True
            Me.ButtonItemSort_LastName.Name = "ButtonItemSort_LastName"
            Me.ButtonItemSort_LastName.OptionGroup = "Sort"
            Me.ButtonItemSort_LastName.SubItemsExpandWidth = 14
            Me.ButtonItemSort_LastName.Text = "Last Name"
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
            Me.RibbonBarOptions_Actions.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_ImportHours, Me.ButtonItemActions_Save, Me.ButtonItemActions_Print, Me.ButtonItemActions_PrintFiltered, Me.ButtonItemActions_AccruePaidTimeOff, Me.ButtonItemActions_UpdateDates, Me.ButtonItemActions_CostAndDepartmentUpdate})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(506, 98)
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
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SecurityEnabled = True
            Me.ButtonItemActions_Save.Stretch = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            Me.ButtonItemActions_Save.Tooltip = "Save Employee Data"
            '
            'ButtonItemActions_Print
            '
            Me.ButtonItemActions_Print.BeginGroup = True
            Me.ButtonItemActions_Print.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
            Me.ButtonItemActions_Print.RibbonWordWrap = False
            Me.ButtonItemActions_Print.SecurityEnabled = True
            Me.ButtonItemActions_Print.Stretch = True
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
            Me.ButtonItemActions_Print.Tooltip = "Print"
            '
            'ButtonItemActions_PrintFiltered
            '
            Me.ButtonItemActions_PrintFiltered.BeginGroup = True
            Me.ButtonItemActions_PrintFiltered.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_PrintFiltered.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_PrintFiltered.Name = "ButtonItemActions_PrintFiltered"
            Me.ButtonItemActions_PrintFiltered.RibbonWordWrap = False
            Me.ButtonItemActions_PrintFiltered.SecurityEnabled = True
            Me.ButtonItemActions_PrintFiltered.Stretch = True
            Me.ButtonItemActions_PrintFiltered.SubItemsExpandWidth = 14
            Me.ButtonItemActions_PrintFiltered.Text = "Print Filtered"
            Me.ButtonItemActions_PrintFiltered.Tooltip = "Print Filtered"
            '
            'ButtonItemActions_AccruePaidTimeOff
            '
            Me.ButtonItemActions_AccruePaidTimeOff.BeginGroup = True
            Me.ButtonItemActions_AccruePaidTimeOff.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_AccruePaidTimeOff.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_AccruePaidTimeOff.Name = "ButtonItemActions_AccruePaidTimeOff"
            Me.ButtonItemActions_AccruePaidTimeOff.RibbonWordWrap = False
            Me.ButtonItemActions_AccruePaidTimeOff.SecurityEnabled = True
            Me.ButtonItemActions_AccruePaidTimeOff.Stretch = True
            Me.ButtonItemActions_AccruePaidTimeOff.SubItemsExpandWidth = 14
            Me.ButtonItemActions_AccruePaidTimeOff.Text = "Accrue PTO"
            Me.ButtonItemActions_AccruePaidTimeOff.Tooltip = "Accrue Paid Time Off"
            '
            'ButtonItemActions_UpdateDates
            '
            Me.ButtonItemActions_UpdateDates.BeginGroup = True
            Me.ButtonItemActions_UpdateDates.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_UpdateDates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_UpdateDates.Name = "ButtonItemActions_UpdateDates"
            Me.ButtonItemActions_UpdateDates.RibbonWordWrap = False
            Me.ButtonItemActions_UpdateDates.SecurityEnabled = True
            Me.ButtonItemActions_UpdateDates.Stretch = True
            Me.ButtonItemActions_UpdateDates.SubItemsExpandWidth = 14
            Me.ButtonItemActions_UpdateDates.Text = "Update Dates"
            Me.ButtonItemActions_UpdateDates.Tooltip = "Update Dates"
            '
            'ButtonItemActions_CostAndDepartmentUpdate
            '
            Me.ButtonItemActions_CostAndDepartmentUpdate.BeginGroup = True
            Me.ButtonItemActions_CostAndDepartmentUpdate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_CostAndDepartmentUpdate.Name = "ButtonItemActions_CostAndDepartmentUpdate"
            Me.ButtonItemActions_CostAndDepartmentUpdate.RibbonWordWrap = False
            Me.ButtonItemActions_CostAndDepartmentUpdate.SecurityEnabled = True
            Me.ButtonItemActions_CostAndDepartmentUpdate.SubItemsExpandWidth = 14
            Me.ButtonItemActions_CostAndDepartmentUpdate.Text = "<span width=""25""></span>Cost and <br></br>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Department Update"
            Me.ButtonItemActions_CostAndDepartmentUpdate.Tooltip = "Cost and Department Update"
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Employees)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(226, 524)
            Me.PanelForm_LeftSection.TabIndex = 8
            '
            'ExpandableSplitterForm_LeftRightSection
            '
            Me.ExpandableSplitterForm_LeftRightSection.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSection.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRightSection.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterForm_LeftRightSection.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterForm_LeftRightSection.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSection.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRightSection.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSection.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftRightSection.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSection.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftRightSection.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSection.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterForm_LeftRightSection.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSection.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSection.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterForm_LeftRightSection.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterForm_LeftRightSection.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSection.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRightSection.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSection.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftRightSection.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSection.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRightSection.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSection.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterForm_LeftRightSection.Location = New System.Drawing.Point(226, 0)
            Me.ExpandableSplitterForm_LeftRightSection.Name = "ExpandableSplitterForm_LeftRightSection"
            Me.ExpandableSplitterForm_LeftRightSection.Size = New System.Drawing.Size(6, 524)
            Me.ExpandableSplitterForm_LeftRightSection.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterForm_LeftRightSection.TabIndex = 9
            Me.ExpandableSplitterForm_LeftRightSection.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_RightSection.Controls.Add(Me.TabControRightSection_EmployeeDetails)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(232, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(676, 524)
            Me.PanelForm_RightSection.TabIndex = 10
            '
            'ButtonItemActions_ImportHours
            '
            Me.ButtonItemActions_ImportHours.BeginGroup = True
            Me.ButtonItemActions_ImportHours.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_ImportHours.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ImportHours.Name = "ButtonItemActions_ImportHours"
            Me.ButtonItemActions_ImportHours.RibbonWordWrap = False
            Me.ButtonItemActions_ImportHours.SecurityEnabled = True
            Me.ButtonItemActions_ImportHours.Stretch = True
            Me.ButtonItemActions_ImportHours.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ImportHours.Text = "Import Hours"
            '
            'EmployeeUpdateSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(908, 524)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterForm_LeftRightSection)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeUpdateSetupForm"
            Me.Text = "Employee Update"
            CType(Me.TabControRightSection_EmployeeDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControRightSection_EmployeeDetails.ResumeLayout(False)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.ResumeLayout(False)
            Me.TabControlPanelEmployeeSettingsTab_EmployeeSettings.ResumeLayout(False)
            Me.TabControlPanelHRInformationTab_HRInformation.ResumeLayout(False)
            Me.TabControlPanelNotesTab_Notes.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewLeftSection_Employees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewNotes_Notes As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewHRInformation_HRInformation As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewEmployeeSettings_EmployeeSettings As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewGeneralInformation_GeneralInformation As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Private WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Private WithEvents TabControRightSection_EmployeeDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Private WithEvents TabControlPanelHRInformationTab_HRInformation As DevComponents.DotNetBar.TabControlPanel
        Private WithEvents TabItemEmployeeDetails_HRInformationTab As DevComponents.DotNetBar.TabItem
        Private WithEvents TabControlPanelGeneralInformationTab_GeneralInformation As DevComponents.DotNetBar.TabControlPanel
        Private WithEvents TabItemEmployeeDetails_GeneralInformationTab As DevComponents.DotNetBar.TabItem
        Private WithEvents TabControlPanelEmployeeSettingsTab_EmployeeSettings As DevComponents.DotNetBar.TabControlPanel
        Private WithEvents TabItemEmployeeDetails_EmployeeSettingsTab As DevComponents.DotNetBar.TabItem
        Private WithEvents TabControlPanelNotesTab_Notes As DevComponents.DotNetBar.TabControlPanel
        Private WithEvents TabItemEmployeeDetails_NotesTab As DevComponents.DotNetBar.TabItem
        Private WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemActions_AccruePaidTimeOff As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemActions_UpdateDates As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemActions_CostAndDepartmentUpdate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_Text As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemText_CheckSpelling As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ExpandableSplitterForm_LeftRightSection As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Private WithEvents ButtonItemActions_PrintFiltered As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_HRHistory As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemHRHistory_View As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_Sort As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemSort_Code As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSort_FirstName As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSort_LastName As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemActions_ImportHours As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace

