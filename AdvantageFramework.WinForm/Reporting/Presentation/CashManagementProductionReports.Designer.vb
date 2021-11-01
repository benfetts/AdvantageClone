Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CashManagementProductionReports
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CashManagementProductionReports))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TabControlProduction_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelProductionOptionsTab_Options = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBox1 = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.RadioButtonControl_Net = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_Gross = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.PanelVersionAndOptions_Include = New System.Windows.Forms.Panel()
            Me.RadioButtonForm_Summary = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonFormDetail = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBox_IncludeClosedJobs = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.Label_ArAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_IncludeNonbillable = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_ShowJobsWithNoDetails = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ButtonForm_2Years = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_1Year = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_MTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ComboBoxForm_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DateTimePickerForm_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.TabItemProductionCriteria_OptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients = New DevComponents.DotNetBar.TabControlPanel()
            Me.CDPChooserControl_Production = New AdvantageFramework.WinForm.Presentation.Controls.CDPChooserControl()
            Me.TabItemProductionCriteria_SelectClientsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectOfficesTab_SelectOffices = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectOffices_Offices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectOffices_AllOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectOffices_ChooseOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectOfficesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives = New DevComponents.DotNetBar.TabControlPanel()
            Me.AEChooserControl_Production = New AdvantageFramework.WinForm.Presentation.Controls.AEChooserControl()
            Me.TabItemProductionCriteria_SelectAccountExecutivesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridView_Campaigns = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectCampaigns_AllCampaigns = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectCampaigns_ChooseCampaigns = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelJobTypes = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes = New DevComponents.DotNetBar.TabControlPanel()
            Me.JobTypeChooserControl1 = New AdvantageFramework.WinForm.Presentation.Controls.JobTypeChooserControl()
            Me.TabItemJobTypes = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlProduction_Criteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlProduction_Criteria.SuspendLayout()
            Me.TabControlPanelProductionOptionsTab_Options.SuspendLayout()
            CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.PanelVersionAndOptions_Include.SuspendLayout()
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.SuspendLayout()
            Me.TabControlPanelSelectOfficesTab_SelectOffices.SuspendLayout()
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.SuspendLayout()
            Me.TabControlPanel1.SuspendLayout()
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.SuspendLayout()
            Me.TabControlPanelJobTypes.SuspendLayout()
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.SuspendLayout()
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
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelProductionOptionsTab_Options)
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelProductionSelectClientsTab_SelectClients)
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelSelectOfficesTab_SelectOffices)
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives)
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanel1)
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelJobTypes)
            Me.TabControlProduction_Criteria.Location = New System.Drawing.Point(12, 12)
            Me.TabControlProduction_Criteria.Name = "TabControlProduction_Criteria"
            Me.TabControlProduction_Criteria.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlProduction_Criteria.SelectedTabIndex = 0
            Me.TabControlProduction_Criteria.Size = New System.Drawing.Size(917, 579)
            Me.TabControlProduction_Criteria.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlProduction_Criteria.TabIndex = 9
            Me.TabControlProduction_Criteria.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItemProductionCriteria_OptionsTab)
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItemJDA_SelectOfficesTab)
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItemProductionCriteria_SelectClientsTab)
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItemProductionCriteria_SelectAccountExecutivesTab)
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItem1)
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItemJobTypes)
            Me.TabControlProduction_Criteria.TabStop = False
            Me.TabControlProduction_Criteria.Text = "TabControl1"
            '
            'TabControlPanelProductionOptionsTab_Options
            '
            Me.TabControlPanelProductionOptionsTab_Options.Controls.Add(Me.GroupBox1)
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
            'GroupBox1
            '
            Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox1.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.GroupBox1.Appearance.Options.UseBackColor = True
            Me.GroupBox1.Controls.Add(Me.Panel1)
            Me.GroupBox1.Controls.Add(Me.PanelVersionAndOptions_Include)
            Me.GroupBox1.Controls.Add(Me.CheckBox_IncludeClosedJobs)
            Me.GroupBox1.Controls.Add(Me.Label_ArAmount)
            Me.GroupBox1.Controls.Add(Me.LabelForm_Type)
            Me.GroupBox1.Controls.Add(Me.CheckBoxForm_IncludeNonbillable)
            Me.GroupBox1.Controls.Add(Me.CheckBoxForm_ShowJobsWithNoDetails)
            Me.GroupBox1.Controls.Add(Me.ButtonForm_2Years)
            Me.GroupBox1.Controls.Add(Me.ButtonForm_1Year)
            Me.GroupBox1.Controls.Add(Me.ButtonForm_MTD)
            Me.GroupBox1.Controls.Add(Me.ButtonForm_YTD)
            Me.GroupBox1.Controls.Add(Me.LabelForm_To)
            Me.GroupBox1.Controls.Add(Me.LabelForm_From)
            Me.GroupBox1.Controls.Add(Me.LabelForm_Criteria)
            Me.GroupBox1.Controls.Add(Me.DateTimePickerForm_To)
            Me.GroupBox1.Controls.Add(Me.ComboBoxForm_Criteria)
            Me.GroupBox1.Controls.Add(Me.DateTimePickerForm_From)
            Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(908, 546)
            Me.GroupBox1.TabIndex = 1
            Me.GroupBox1.Text = "Report Options"
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.RadioButtonControl_Net)
            Me.Panel1.Controls.Add(Me.RadioButtonControl_Gross)
            Me.Panel1.Location = New System.Drawing.Point(119, 50)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(175, 20)
            Me.Panel1.TabIndex = 21
            '
            'RadioButtonControl_Net
            '
            Me.RadioButtonControl_Net.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_Net.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_Net.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_Net.Checked = True
            Me.RadioButtonControl_Net.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControl_Net.CheckValue = "Y"
            Me.RadioButtonControl_Net.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonControl_Net.Name = "RadioButtonControl_Net"
            Me.RadioButtonControl_Net.SecurityEnabled = True
            Me.RadioButtonControl_Net.Size = New System.Drawing.Size(87, 20)
            Me.RadioButtonControl_Net.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_Net.TabIndex = 16
            Me.RadioButtonControl_Net.TabOnEnter = True
            Me.RadioButtonControl_Net.Text = "Net"
            '
            'RadioButtonControl_Gross
            '
            Me.RadioButtonControl_Gross.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_Gross.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_Gross.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_Gross.Location = New System.Drawing.Point(93, 0)
            Me.RadioButtonControl_Gross.Name = "RadioButtonControl_Gross"
            Me.RadioButtonControl_Gross.SecurityEnabled = True
            Me.RadioButtonControl_Gross.Size = New System.Drawing.Size(82, 20)
            Me.RadioButtonControl_Gross.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_Gross.TabIndex = 17
            Me.RadioButtonControl_Gross.TabOnEnter = True
            Me.RadioButtonControl_Gross.TabStop = False
            Me.RadioButtonControl_Gross.Text = "Gross"
            '
            'PanelVersionAndOptions_Include
            '
            Me.PanelVersionAndOptions_Include.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.PanelVersionAndOptions_Include.BackColor = System.Drawing.Color.White
            Me.PanelVersionAndOptions_Include.Controls.Add(Me.RadioButtonForm_Summary)
            Me.PanelVersionAndOptions_Include.Controls.Add(Me.RadioButtonFormDetail)
            Me.PanelVersionAndOptions_Include.Location = New System.Drawing.Point(119, 24)
            Me.PanelVersionAndOptions_Include.Name = "PanelVersionAndOptions_Include"
            Me.PanelVersionAndOptions_Include.Size = New System.Drawing.Size(175, 20)
            Me.PanelVersionAndOptions_Include.TabIndex = 20
            '
            'RadioButtonForm_Summary
            '
            Me.RadioButtonForm_Summary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_Summary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_Summary.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_Summary.Checked = True
            Me.RadioButtonForm_Summary.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_Summary.CheckValue = "Y"
            Me.RadioButtonForm_Summary.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonForm_Summary.Name = "RadioButtonForm_Summary"
            Me.RadioButtonForm_Summary.SecurityEnabled = True
            Me.RadioButtonForm_Summary.Size = New System.Drawing.Size(87, 20)
            Me.RadioButtonForm_Summary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_Summary.TabIndex = 13
            Me.RadioButtonForm_Summary.TabOnEnter = True
            Me.RadioButtonForm_Summary.Text = "Summary"
            '
            'RadioButtonFormDetail
            '
            Me.RadioButtonFormDetail.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonFormDetail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonFormDetail.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonFormDetail.Location = New System.Drawing.Point(93, 1)
            Me.RadioButtonFormDetail.Name = "RadioButtonFormDetail"
            Me.RadioButtonFormDetail.SecurityEnabled = True
            Me.RadioButtonFormDetail.Size = New System.Drawing.Size(82, 20)
            Me.RadioButtonFormDetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonFormDetail.TabIndex = 14
            Me.RadioButtonFormDetail.TabOnEnter = True
            Me.RadioButtonFormDetail.TabStop = False
            Me.RadioButtonFormDetail.Text = "Detail"
            '
            'CheckBox_IncludeClosedJobs
            '
            '
            '
            '
            Me.CheckBox_IncludeClosedJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBox_IncludeClosedJobs.CheckValue = 0
            Me.CheckBox_IncludeClosedJobs.CheckValueChecked = 1
            Me.CheckBox_IncludeClosedJobs.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBox_IncludeClosedJobs.CheckValueUnchecked = 0
            Me.CheckBox_IncludeClosedJobs.ChildControls = CType(resources.GetObject("CheckBox_IncludeClosedJobs.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBox_IncludeClosedJobs.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBox_IncludeClosedJobs.Location = New System.Drawing.Point(5, 76)
            Me.CheckBox_IncludeClosedJobs.Name = "CheckBox_IncludeClosedJobs"
            Me.CheckBox_IncludeClosedJobs.OldestSibling = Nothing
            Me.CheckBox_IncludeClosedJobs.SecurityEnabled = True
            Me.CheckBox_IncludeClosedJobs.SiblingControls = CType(resources.GetObject("CheckBox_IncludeClosedJobs.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBox_IncludeClosedJobs.Size = New System.Drawing.Size(421, 20)
            Me.CheckBox_IncludeClosedJobs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBox_IncludeClosedJobs.TabIndex = 19
            Me.CheckBox_IncludeClosedJobs.TabOnEnter = True
            Me.CheckBox_IncludeClosedJobs.Text = "Include Closed Jobs"
            '
            'Label_ArAmount
            '
            Me.Label_ArAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label_ArAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label_ArAmount.Location = New System.Drawing.Point(7, 50)
            Me.Label_ArAmount.Name = "Label_ArAmount"
            Me.Label_ArAmount.Size = New System.Drawing.Size(106, 20)
            Me.Label_ArAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label_ArAmount.TabIndex = 18
            Me.Label_ArAmount.Text = "AR Paid Amount:"
            '
            'LabelForm_Type
            '
            Me.LabelForm_Type.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Type.Location = New System.Drawing.Point(5, 24)
            Me.LabelForm_Type.Name = "LabelForm_Type"
            Me.LabelForm_Type.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Type.TabIndex = 15
            Me.LabelForm_Type.Text = "Type:"
            '
            'CheckBoxForm_IncludeNonbillable
            '
            '
            '
            '
            Me.CheckBoxForm_IncludeNonbillable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IncludeNonbillable.CheckValue = 0
            Me.CheckBoxForm_IncludeNonbillable.CheckValueChecked = 1
            Me.CheckBoxForm_IncludeNonbillable.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IncludeNonbillable.CheckValueUnchecked = 0
            Me.CheckBoxForm_IncludeNonbillable.ChildControls = CType(resources.GetObject("CheckBoxForm_IncludeNonbillable.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeNonbillable.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IncludeNonbillable.Location = New System.Drawing.Point(5, 102)
            Me.CheckBoxForm_IncludeNonbillable.Name = "CheckBoxForm_IncludeNonbillable"
            Me.CheckBoxForm_IncludeNonbillable.OldestSibling = Nothing
            Me.CheckBoxForm_IncludeNonbillable.SecurityEnabled = True
            Me.CheckBoxForm_IncludeNonbillable.SiblingControls = CType(resources.GetObject("CheckBoxForm_IncludeNonbillable.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeNonbillable.Size = New System.Drawing.Size(421, 20)
            Me.CheckBoxForm_IncludeNonbillable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IncludeNonbillable.TabIndex = 8
            Me.CheckBoxForm_IncludeNonbillable.TabOnEnter = True
            Me.CheckBoxForm_IncludeNonbillable.Text = "Include Non Billable Cost Amount"
            '
            'CheckBoxForm_ShowJobsWithNoDetails
            '
            '
            '
            '
            Me.CheckBoxForm_ShowJobsWithNoDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ShowJobsWithNoDetails.CheckValue = 0
            Me.CheckBoxForm_ShowJobsWithNoDetails.CheckValueChecked = 1
            Me.CheckBoxForm_ShowJobsWithNoDetails.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ShowJobsWithNoDetails.CheckValueUnchecked = 0
            Me.CheckBoxForm_ShowJobsWithNoDetails.ChildControls = CType(resources.GetObject("CheckBoxForm_ShowJobsWithNoDetails.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ShowJobsWithNoDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ShowJobsWithNoDetails.Location = New System.Drawing.Point(5, 206)
            Me.CheckBoxForm_ShowJobsWithNoDetails.Name = "CheckBoxForm_ShowJobsWithNoDetails"
            Me.CheckBoxForm_ShowJobsWithNoDetails.OldestSibling = Nothing
            Me.CheckBoxForm_ShowJobsWithNoDetails.SecurityEnabled = True
            Me.CheckBoxForm_ShowJobsWithNoDetails.SiblingControls = CType(resources.GetObject("CheckBoxForm_ShowJobsWithNoDetails.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ShowJobsWithNoDetails.Size = New System.Drawing.Size(175, 20)
            Me.CheckBoxForm_ShowJobsWithNoDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ShowJobsWithNoDetails.TabIndex = 7
            Me.CheckBoxForm_ShowJobsWithNoDetails.TabOnEnter = True
            Me.CheckBoxForm_ShowJobsWithNoDetails.Text = "Show Jobs With No Details"
            Me.CheckBoxForm_ShowJobsWithNoDetails.Visible = False
            '
            'ButtonForm_2Years
            '
            Me.ButtonForm_2Years.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_2Years.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_2Years.Location = New System.Drawing.Point(267, 179)
            Me.ButtonForm_2Years.Name = "ButtonForm_2Years"
            Me.ButtonForm_2Years.SecurityEnabled = True
            Me.ButtonForm_2Years.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_2Years.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_2Years.TabIndex = 6
            Me.ButtonForm_2Years.Text = "2 Years"
            Me.ButtonForm_2Years.Visible = False
            '
            'ButtonForm_1Year
            '
            Me.ButtonForm_1Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_1Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_1Year.Location = New System.Drawing.Point(267, 153)
            Me.ButtonForm_1Year.Name = "ButtonForm_1Year"
            Me.ButtonForm_1Year.SecurityEnabled = True
            Me.ButtonForm_1Year.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_1Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_1Year.TabIndex = 3
            Me.ButtonForm_1Year.Text = "1 Year"
            Me.ButtonForm_1Year.Visible = False
            '
            'ButtonForm_MTD
            '
            Me.ButtonForm_MTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_MTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_MTD.Location = New System.Drawing.Point(186, 179)
            Me.ButtonForm_MTD.Name = "ButtonForm_MTD"
            Me.ButtonForm_MTD.SecurityEnabled = True
            Me.ButtonForm_MTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_MTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_MTD.TabIndex = 5
            Me.ButtonForm_MTD.Text = "MTD"
            Me.ButtonForm_MTD.Visible = False
            '
            'ButtonForm_YTD
            '
            Me.ButtonForm_YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_YTD.Location = New System.Drawing.Point(186, 153)
            Me.ButtonForm_YTD.Name = "ButtonForm_YTD"
            Me.ButtonForm_YTD.SecurityEnabled = True
            Me.ButtonForm_YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_YTD.TabIndex = 2
            Me.ButtonForm_YTD.Text = "YTD"
            Me.ButtonForm_YTD.Visible = False
            '
            'LabelForm_To
            '
            Me.LabelForm_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_To.Location = New System.Drawing.Point(5, 179)
            Me.LabelForm_To.Name = "LabelForm_To"
            Me.LabelForm_To.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_To.TabIndex = 0
            Me.LabelForm_To.Text = "To:"
            Me.LabelForm_To.Visible = False
            '
            'LabelForm_From
            '
            Me.LabelForm_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_From.Location = New System.Drawing.Point(5, 153)
            Me.LabelForm_From.Name = "LabelForm_From"
            Me.LabelForm_From.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_From.TabIndex = 8
            Me.LabelForm_From.Text = "From:"
            Me.LabelForm_From.Visible = False
            '
            'LabelForm_Criteria
            '
            Me.LabelForm_Criteria.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Criteria.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Criteria.Location = New System.Drawing.Point(5, 127)
            Me.LabelForm_Criteria.Name = "LabelForm_Criteria"
            Me.LabelForm_Criteria.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_Criteria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Criteria.TabIndex = 0
            Me.LabelForm_Criteria.Text = "Criteria:"
            Me.LabelForm_Criteria.Visible = False
            '
            'DateTimePickerForm_To
            '
            Me.DateTimePickerForm_To.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_To.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_To.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_To.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_To.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_To.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_To.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_To.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_To.DisplayName = ""
            Me.DateTimePickerForm_To.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_To.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_To.FocusHighlightEnabled = True
            Me.DateTimePickerForm_To.FreeTextEntryMode = True
            Me.DateTimePickerForm_To.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_To.Location = New System.Drawing.Point(56, 179)
            Me.DateTimePickerForm_To.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_To.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerForm_To.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerForm_To.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_To.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_To.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_To.MonthCalendar.DisplayMonth = New Date(2012, 7, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_To.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_To.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_To.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_To.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_To.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_To.Name = "DateTimePickerForm_To"
            Me.DateTimePickerForm_To.ReadOnly = False
            Me.DateTimePickerForm_To.Size = New System.Drawing.Size(124, 21)
            Me.DateTimePickerForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_To.TabIndex = 4
            Me.DateTimePickerForm_To.TabOnEnter = True
            Me.DateTimePickerForm_To.Value = New Date(2017, 8, 7, 11, 18, 28, 763)
            Me.DateTimePickerForm_To.Visible = False
            '
            'ComboBoxForm_Criteria
            '
            Me.ComboBoxForm_Criteria.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Criteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Criteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Criteria.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Criteria.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Criteria.BookmarkingEnabled = False
            Me.ComboBoxForm_Criteria.ClientCode = ""
            Me.ComboBoxForm_Criteria.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxForm_Criteria.DisableMouseWheel = False
            Me.ComboBoxForm_Criteria.DisplayMember = "Name"
            Me.ComboBoxForm_Criteria.DisplayName = ""
            Me.ComboBoxForm_Criteria.DivisionCode = ""
            Me.ComboBoxForm_Criteria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Criteria.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Criteria.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Criteria.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Criteria.FocusHighlightEnabled = True
            Me.ComboBoxForm_Criteria.FormattingEnabled = True
            Me.ComboBoxForm_Criteria.ItemHeight = 16
            Me.ComboBoxForm_Criteria.Location = New System.Drawing.Point(56, 127)
            Me.ComboBoxForm_Criteria.Name = "ComboBoxForm_Criteria"
            Me.ComboBoxForm_Criteria.ReadOnly = False
            Me.ComboBoxForm_Criteria.SecurityEnabled = True
            Me.ComboBoxForm_Criteria.Size = New System.Drawing.Size(347, 22)
            Me.ComboBoxForm_Criteria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Criteria.TabIndex = 0
            Me.ComboBoxForm_Criteria.TabOnEnter = True
            Me.ComboBoxForm_Criteria.ValueMember = "Value"
            Me.ComboBoxForm_Criteria.Visible = False
            Me.ComboBoxForm_Criteria.WatermarkText = "Select"
            '
            'DateTimePickerForm_From
            '
            Me.DateTimePickerForm_From.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_From.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_From.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_From.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_From.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_From.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_From.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_From.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_From.DisplayName = ""
            Me.DateTimePickerForm_From.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_From.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_From.FocusHighlightEnabled = True
            Me.DateTimePickerForm_From.FreeTextEntryMode = True
            Me.DateTimePickerForm_From.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_From.Location = New System.Drawing.Point(56, 153)
            Me.DateTimePickerForm_From.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_From.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerForm_From.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerForm_From.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_From.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_From.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_From.MonthCalendar.DisplayMonth = New Date(2012, 7, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_From.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_From.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_From.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_From.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_From.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_From.Name = "DateTimePickerForm_From"
            Me.DateTimePickerForm_From.ReadOnly = False
            Me.DateTimePickerForm_From.Size = New System.Drawing.Size(124, 21)
            Me.DateTimePickerForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_From.TabIndex = 1
            Me.DateTimePickerForm_From.TabOnEnter = True
            Me.DateTimePickerForm_From.Value = New Date(2017, 8, 7, 11, 18, 20, 812)
            Me.DateTimePickerForm_From.Visible = False
            '
            'TabItemProductionCriteria_OptionsTab
            '
            Me.TabItemProductionCriteria_OptionsTab.AttachedControl = Me.TabControlPanelProductionOptionsTab_Options
            Me.TabItemProductionCriteria_OptionsTab.Name = "TabItemProductionCriteria_OptionsTab"
            Me.TabItemProductionCriteria_OptionsTab.Text = "Options"
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
            'TabControlPanelSelectOfficesTab_SelectOffices
            '
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Controls.Add(Me.DataGridViewSelectOffices_Offices)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Controls.Add(Me.RadioButtonSelectOffices_AllOffices)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Controls.Add(Me.RadioButtonSelectOffices_ChooseOffices)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Name = "TabControlPanelSelectOfficesTab_SelectOffices"
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Size = New System.Drawing.Size(917, 552)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.GradientAngle = 90
            Me.TabControlPanelSelectOfficesTab_SelectOffices.TabIndex = 0
            Me.TabControlPanelSelectOfficesTab_SelectOffices.TabItem = Me.TabItemJDA_SelectOfficesTab
            '
            'DataGridViewSelectOffices_Offices
            '
            Me.DataGridViewSelectOffices_Offices.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectOffices_Offices.AllowDragAndDrop = False
            Me.DataGridViewSelectOffices_Offices.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectOffices_Offices.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectOffices_Offices.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectOffices_Offices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectOffices_Offices.AutoFilterLookupColumns = False
            Me.DataGridViewSelectOffices_Offices.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectOffices_Offices.AutoUpdateViewCaption = True
            Me.DataGridViewSelectOffices_Offices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectOffices_Offices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectOffices_Offices.Enabled = False
            Me.DataGridViewSelectOffices_Offices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectOffices_Offices.ItemDescription = "Office(s)"
            Me.DataGridViewSelectOffices_Offices.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectOffices_Offices.MultiSelect = False
            Me.DataGridViewSelectOffices_Offices.Name = "DataGridViewSelectOffices_Offices"
            Me.DataGridViewSelectOffices_Offices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectOffices_Offices.RunStandardValidation = True
            Me.DataGridViewSelectOffices_Offices.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectOffices_Offices.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectOffices_Offices.Size = New System.Drawing.Size(909, 518)
            Me.DataGridViewSelectOffices_Offices.TabIndex = 2
            Me.DataGridViewSelectOffices_Offices.UseEmbeddedNavigator = False
            Me.DataGridViewSelectOffices_Offices.ViewCaptionHeight = -1
            '
            'RadioButtonSelectOffices_AllOffices
            '
            Me.RadioButtonSelectOffices_AllOffices.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectOffices_AllOffices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectOffices_AllOffices.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectOffices_AllOffices.Checked = True
            Me.RadioButtonSelectOffices_AllOffices.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectOffices_AllOffices.CheckValue = "Y"
            Me.RadioButtonSelectOffices_AllOffices.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectOffices_AllOffices.Name = "RadioButtonSelectOffices_AllOffices"
            Me.RadioButtonSelectOffices_AllOffices.SecurityEnabled = True
            Me.RadioButtonSelectOffices_AllOffices.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonSelectOffices_AllOffices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectOffices_AllOffices.TabIndex = 0
            Me.RadioButtonSelectOffices_AllOffices.TabOnEnter = True
            Me.RadioButtonSelectOffices_AllOffices.Text = "All Offices"
            '
            'RadioButtonSelectOffices_ChooseOffices
            '
            Me.RadioButtonSelectOffices_ChooseOffices.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectOffices_ChooseOffices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectOffices_ChooseOffices.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectOffices_ChooseOffices.Location = New System.Drawing.Point(87, 4)
            Me.RadioButtonSelectOffices_ChooseOffices.Name = "RadioButtonSelectOffices_ChooseOffices"
            Me.RadioButtonSelectOffices_ChooseOffices.SecurityEnabled = True
            Me.RadioButtonSelectOffices_ChooseOffices.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectOffices_ChooseOffices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectOffices_ChooseOffices.TabIndex = 1
            Me.RadioButtonSelectOffices_ChooseOffices.TabOnEnter = True
            Me.RadioButtonSelectOffices_ChooseOffices.TabStop = False
            Me.RadioButtonSelectOffices_ChooseOffices.Text = "Choose Offices"
            '
            'TabItemJDA_SelectOfficesTab
            '
            Me.TabItemJDA_SelectOfficesTab.AttachedControl = Me.TabControlPanelSelectOfficesTab_SelectOffices
            Me.TabItemJDA_SelectOfficesTab.Name = "TabItemJDA_SelectOfficesTab"
            Me.TabItemJDA_SelectOfficesTab.Text = "Select Offices"
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
            Me.TabItem1.Visible = False
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
            Me.TabItemJobTypes.Visible = False
            '
            'CashManagementProductionReports
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(941, 673)
            Me.Controls.Add(Me.TabControlProduction_Criteria)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "CashManagementProductionReports"
            Me.Text = "Cash Management Production Criteria"
            CType(Me.TabControlProduction_Criteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlProduction_Criteria.ResumeLayout(False)
            Me.TabControlPanelProductionOptionsTab_Options.ResumeLayout(False)
            CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.PanelVersionAndOptions_Include.ResumeLayout(False)
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.ResumeLayout(False)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.ResumeLayout(False)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.ResumeLayout(False)
            Me.TabControlPanel1.ResumeLayout(False)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.ResumeLayout(False)
            Me.TabControlPanelJobTypes.ResumeLayout(False)
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.ResumeLayout(False)
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
        Friend WithEvents TabControlPanelSelectOfficesTab_SelectOffices As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemJDA_SelectOfficesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents RadioButtonSelectOffices_AllOffices As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectOffices_ChooseOffices As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents DataGridViewSelectOffices_Offices As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents GroupBox1 As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxForm_IncludeNonbillable As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_ShowJobsWithNoDetails As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ButtonForm_2Years As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_1Year As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_MTD As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_YTD As WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_To As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_From As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Criteria As WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_To As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents ComboBoxForm_Criteria As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DateTimePickerForm_From As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents RadioButtonFormDetail As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_Summary As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelForm_Type As WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBox_IncludeClosedJobs As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents Label_ArAmount As WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonControl_Gross As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControl_Net As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents Panel1 As Windows.Forms.Panel
        Friend WithEvents PanelVersionAndOptions_Include As Windows.Forms.Panel
    End Class

End Namespace