Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class JobDetailInitialLoadingDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobDetailInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TabControlProduction_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridView_Campaigns = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectCampaigns_AllCampaigns = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectCampaigns_ChooseCampaigns = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProductionOptionsTab_Options = New DevComponents.DotNetBar.TabControlPanel()
            Me.JobDetailControl1 = New AdvantageFramework.WinForm.Presentation.Controls.JobDetailControl()
            Me.TabItemProductionCriteria_OptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelJobTypes = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes = New DevComponents.DotNetBar.TabControlPanel()
            Me.JobTypeChooserControl1 = New AdvantageFramework.WinForm.Presentation.Controls.JobTypeChooserControl()
            Me.TabItemJobTypes = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients = New DevComponents.DotNetBar.TabControlPanel()
            Me.CDPChooserControl_Production = New AdvantageFramework.WinForm.Presentation.Controls.CDPChooserControl()
            Me.TabItemProductionCriteria_SelectClientsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives = New DevComponents.DotNetBar.TabControlPanel()
            Me.AEChooserControl_Production = New AdvantageFramework.WinForm.Presentation.Controls.AEChooserControl()
            Me.TabItemProductionCriteria_SelectAccountExecutivesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlProduction_Criteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlProduction_Criteria.SuspendLayout()
            Me.TabControlPanel1.SuspendLayout()
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.SuspendLayout()
            Me.TabControlPanelProductionOptionsTab_Options.SuspendLayout()
            Me.TabControlPanelJobTypes.SuspendLayout()
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.SuspendLayout()
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.SuspendLayout()
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(773, 641)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 0
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(854, 641)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 1
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'TabControlProduction_Criteria
            '
            Me.TabControlProduction_Criteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlProduction_Criteria.BackColor = System.Drawing.Color.White
            Me.TabControlProduction_Criteria.CanReorderTabs = True
            Me.TabControlProduction_Criteria.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlProduction_Criteria.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanel1)
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelJobTypes)
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives)
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelProductionOptionsTab_Options)
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelProductionSelectClientsTab_SelectClients)
            Me.TabControlProduction_Criteria.Location = New System.Drawing.Point(12, 12)
            Me.TabControlProduction_Criteria.Name = "TabControlProduction_Criteria"
            Me.TabControlProduction_Criteria.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlProduction_Criteria.SelectedTabIndex = 0
            Me.TabControlProduction_Criteria.Size = New System.Drawing.Size(917, 579)
            Me.TabControlProduction_Criteria.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlProduction_Criteria.TabIndex = 9
            Me.TabControlProduction_Criteria.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItemProductionCriteria_OptionsTab)
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItemProductionCriteria_SelectClientsTab)
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItemProductionCriteria_SelectAccountExecutivesTab)
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItem1)
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItemJobTypes)
            Me.TabControlProduction_Criteria.TabStop = False
            Me.TabControlProduction_Criteria.Text = "TabControl1"
            '
            'TabControlPanel1
            '
            Me.TabControlPanel1.Controls.Add(Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses)
            Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel1.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel1.Name = "TabControlPanel1"
            Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel1.Size = New System.Drawing.Size(917, 552)
            Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel1.Style.GradientAngle = 90
            Me.TabControlPanel1.TabIndex = 16
            Me.TabControlPanel1.TabItem = Me.TabItem1
            '
            'TabControlPanelSelectSalesClassesTab_SelectSalesClasses
            '
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Controls.Add(Me.DataGridView_Campaigns)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Controls.Add(Me.RadioButtonSelectCampaigns_AllCampaigns)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Controls.Add(Me.RadioButtonSelectCampaigns_ChooseCampaigns)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Location = New System.Drawing.Point(1, 1)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Name = "TabControlPanelSelectSalesClassesTab_SelectSalesClasses"
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Size = New System.Drawing.Size(915, 550)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.GradientAngle = 90
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.TabIndex = 4
            '
            'DataGridView_Campaigns
            '
            Me.DataGridView_Campaigns.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridView_Campaigns.AllowDragAndDrop = False
            Me.DataGridView_Campaigns.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridView_Campaigns.AllowSelectGroupHeaderRow = True
            Me.DataGridView_Campaigns.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridView_Campaigns.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridView_Campaigns.AutoFilterLookupColumns = False
            Me.DataGridView_Campaigns.AutoloadRepositoryDatasource = True
            Me.DataGridView_Campaigns.AutoUpdateViewCaption = True
            Me.DataGridView_Campaigns.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridView_Campaigns.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridView_Campaigns.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridView_Campaigns.ItemDescription = "Campaign(s)"
            Me.DataGridView_Campaigns.Location = New System.Drawing.Point(2, 30)
            Me.DataGridView_Campaigns.MultiSelect = True
            Me.DataGridView_Campaigns.Name = "DataGridView_Campaigns"
            Me.DataGridView_Campaigns.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridView_Campaigns.RunStandardValidation = True
            Me.DataGridView_Campaigns.ShowColumnMenuOnRightClick = False
            Me.DataGridView_Campaigns.ShowSelectDeselectAllButtons = False
            Me.DataGridView_Campaigns.Size = New System.Drawing.Size(909, 518)
            Me.DataGridView_Campaigns.TabIndex = 16
            Me.DataGridView_Campaigns.UseEmbeddedNavigator = False
            Me.DataGridView_Campaigns.ViewCaptionHeight = -1
            '
            'RadioButtonSelectCampaigns_AllCampaigns
            '
            Me.RadioButtonSelectCampaigns_AllCampaigns.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectCampaigns_AllCampaigns.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectCampaigns_AllCampaigns.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectCampaigns_AllCampaigns.Checked = True
            Me.RadioButtonSelectCampaigns_AllCampaigns.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectCampaigns_AllCampaigns.CheckValue = "Y"
            Me.RadioButtonSelectCampaigns_AllCampaigns.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectCampaigns_AllCampaigns.Name = "RadioButtonSelectCampaigns_AllCampaigns"
            Me.RadioButtonSelectCampaigns_AllCampaigns.SecurityEnabled = True
            Me.RadioButtonSelectCampaigns_AllCampaigns.Size = New System.Drawing.Size(113, 20)
            Me.RadioButtonSelectCampaigns_AllCampaigns.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectCampaigns_AllCampaigns.TabIndex = 0
            Me.RadioButtonSelectCampaigns_AllCampaigns.TabOnEnter = True
            Me.RadioButtonSelectCampaigns_AllCampaigns.Text = "All Campaigns"
            '
            'RadioButtonSelectCampaigns_ChooseCampaigns
            '
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.Location = New System.Drawing.Point(123, 4)
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.Name = "RadioButtonSelectCampaigns_ChooseCampaigns"
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.SecurityEnabled = True
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.Size = New System.Drawing.Size(164, 20)
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.TabIndex = 1
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.TabOnEnter = True
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.TabStop = False
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.Text = "Choose Campaigns"
            '
            'TabItem1
            '
            Me.TabItem1.AttachedControl = Me.TabControlPanel1
            Me.TabItem1.Name = "TabItem1"
            Me.TabItem1.Text = "Select Campaigns"
            '
            'TabControlPanelProductionOptionsTab_Options
            '
            Me.TabControlPanelProductionOptionsTab_Options.Controls.Add(Me.JobDetailControl1)
            Me.TabControlPanelProductionOptionsTab_Options.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProductionOptionsTab_Options.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionOptionsTab_Options.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProductionOptionsTab_Options.Name = "TabControlPanelProductionOptionsTab_Options"
            Me.TabControlPanelProductionOptionsTab_Options.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionOptionsTab_Options.Size = New System.Drawing.Size(917, 552)
            Me.TabControlPanelProductionOptionsTab_Options.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProductionOptionsTab_Options.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProductionOptionsTab_Options.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionOptionsTab_Options.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProductionOptionsTab_Options.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionOptionsTab_Options.Style.GradientAngle = 90
            Me.TabControlPanelProductionOptionsTab_Options.TabIndex = 1
            Me.TabControlPanelProductionOptionsTab_Options.TabItem = Me.TabItemProductionCriteria_OptionsTab
            '
            'JobDetailControl1
            '
            Me.JobDetailControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.JobDetailControl1.Location = New System.Drawing.Point(3, 0)
            Me.JobDetailControl1.Name = "JobDetailControl1"
            Me.JobDetailControl1.Size = New System.Drawing.Size(911, 548)
            Me.JobDetailControl1.TabIndex = 0
            '
            'TabItemProductionCriteria_OptionsTab
            '
            Me.TabItemProductionCriteria_OptionsTab.AttachedControl = Me.TabControlPanelProductionOptionsTab_Options
            Me.TabItemProductionCriteria_OptionsTab.Name = "TabItemProductionCriteria_OptionsTab"
            Me.TabItemProductionCriteria_OptionsTab.Text = "Options"
            '
            'TabControlPanelJobTypes
            '
            Me.TabControlPanelJobTypes.Controls.Add(Me.TabControlPanelSelectJobTypesTab_SelectJobTypes)
            Me.TabControlPanelJobTypes.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelJobTypes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelJobTypes.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelJobTypes.Name = "TabControlPanelJobTypes"
            Me.TabControlPanelJobTypes.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelJobTypes.Size = New System.Drawing.Size(917, 552)
            Me.TabControlPanelJobTypes.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelJobTypes.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelJobTypes.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelJobTypes.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelJobTypes.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelJobTypes.Style.GradientAngle = 90
            Me.TabControlPanelJobTypes.TabIndex = 16
            Me.TabControlPanelJobTypes.TabItem = Me.TabItemJobTypes
            '
            'TabControlPanelSelectJobTypesTab_SelectJobTypes
            '
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Controls.Add(Me.JobTypeChooserControl1)
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Location = New System.Drawing.Point(1, 1)
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Name = "TabControlPanelSelectJobTypesTab_SelectJobTypes"
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Size = New System.Drawing.Size(915, 550)
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Style.GradientAngle = 90
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.TabIndex = 4
            '
            'JobTypeChooserControl1
            '
            Me.JobTypeChooserControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.JobTypeChooserControl1.Location = New System.Drawing.Point(4, 4)
            Me.JobTypeChooserControl1.Name = "JobTypeChooserControl1"
            Me.JobTypeChooserControl1.Size = New System.Drawing.Size(909, 544)
            Me.JobTypeChooserControl1.TabIndex = 0
            '
            'TabItemJobTypes
            '
            Me.TabItemJobTypes.AttachedControl = Me.TabControlPanelJobTypes
            Me.TabItemJobTypes.Name = "TabItemJobTypes"
            Me.TabItemJobTypes.Text = "Select Job Types"
            '
            'TabControlPanelProductionSelectClientsTab_SelectClients
            '
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Controls.Add(Me.CDPChooserControl_Production)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Name = "TabControlPanelProductionSelectClientsTab_SelectClients"
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Size = New System.Drawing.Size(917, 552)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Style.GradientAngle = 90
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.TabIndex = 5
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.TabItem = Me.TabItemProductionCriteria_SelectClientsTab
            '
            'CDPChooserControl_Production
            '
            Me.CDPChooserControl_Production.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CDPChooserControl_Production.BackColor = System.Drawing.Color.Transparent
            Me.CDPChooserControl_Production.Location = New System.Drawing.Point(4, 4)
            Me.CDPChooserControl_Production.Name = "CDPChooserControl_Production"
            Me.CDPChooserControl_Production.Size = New System.Drawing.Size(909, 544)
            Me.CDPChooserControl_Production.TabIndex = 0
            '
            'TabItemProductionCriteria_SelectClientsTab
            '
            Me.TabItemProductionCriteria_SelectClientsTab.AttachedControl = Me.TabControlPanelProductionSelectClientsTab_SelectClients
            Me.TabItemProductionCriteria_SelectClientsTab.Name = "TabItemProductionCriteria_SelectClientsTab"
            Me.TabItemProductionCriteria_SelectClientsTab.Text = "Select Clients"
            '
            'TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives
            '
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Controls.Add(Me.AEChooserControl_Production)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Name = "TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives"
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Size = New System.Drawing.Size(917, 552)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.GradientAngle = 90
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.TabIndex = 9
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.TabItem = Me.TabItemProductionCriteria_SelectAccountExecutivesTab
            '
            'AEChooserControl_Production
            '
            Me.AEChooserControl_Production.BackColor = System.Drawing.Color.Transparent
            Me.AEChooserControl_Production.Location = New System.Drawing.Point(4, 4)
            Me.AEChooserControl_Production.Name = "AEChooserControl_Production"
            Me.AEChooserControl_Production.Size = New System.Drawing.Size(906, 473)
            Me.AEChooserControl_Production.TabIndex = 0
            '
            'TabItemProductionCriteria_SelectAccountExecutivesTab
            '
            Me.TabItemProductionCriteria_SelectAccountExecutivesTab.AttachedControl = Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives
            Me.TabItemProductionCriteria_SelectAccountExecutivesTab.Name = "TabItemProductionCriteria_SelectAccountExecutivesTab"
            Me.TabItemProductionCriteria_SelectAccountExecutivesTab.Text = "Select Account Executives"
            '
            'JobDetailInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(941, 673)
            Me.Controls.Add(Me.TabControlProduction_Criteria)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "JobDetailInitialLoadingDialog"
            Me.Text = "Job Detail Criteria"
            CType(Me.TabControlProduction_Criteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlProduction_Criteria.ResumeLayout(False)
            Me.TabControlPanel1.ResumeLayout(False)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.ResumeLayout(False)
            Me.TabControlPanelProductionOptionsTab_Options.ResumeLayout(False)
            Me.TabControlPanelJobTypes.ResumeLayout(False)
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.ResumeLayout(False)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.ResumeLayout(False)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TabControlProduction_Criteria As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelProductionOptionsTab_Options As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemProductionCriteria_OptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelProductionSelectClientsTab_SelectClients As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CDPChooserControl_Production As WinForm.Presentation.Controls.CDPChooserControl
        Friend WithEvents TabItemProductionCriteria_SelectClientsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents AEChooserControl_Production As WinForm.Presentation.Controls.AEChooserControl
        Friend WithEvents TabItemProductionCriteria_SelectAccountExecutivesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents JobDetailControl1 As WinForm.Presentation.Controls.JobDetailControl
        Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabControlPanelJobTypes As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabItemJobTypes As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectSalesClassesTab_SelectSalesClasses As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabControlPanelSelectJobTypesTab_SelectJobTypes As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents RadioButtonSelectCampaigns_AllCampaigns As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectCampaigns_ChooseCampaigns As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents JobTypeChooserControl1 As WinForm.Presentation.Controls.JobTypeChooserControl
        Friend WithEvents DataGridView_Campaigns As WinForm.Presentation.Controls.DataGridView
    End Class

End Namespace