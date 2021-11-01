Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProjectScheduleControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.ExpandablePanelControl_General = New DevComponents.DotNetBar.ExpandablePanel()
            Me.TabControlControl_ProjectScheduleDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelTaskDetailsTab_TaskDetails = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelTaskDetails_GutComplete = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonControlTaskDetails_DueDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelTaskDetails_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonControlTaskDetails_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.DateTimePickerTaskDetails_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.SearchableComboBoxTaskDetails_TrafficStatus = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.DateTimePickerTaskDetails_DueDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelTaskDetails_DueDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTaskDetails_CompletedDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerTaskDetails_CompletedDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelTaskDetails_Traffic = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemProjectScheduleDetails_TaskDetailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelRelatedJobsTab_RelatedJobs = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlRelatedJobs_RelatedJobs = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelJobsThatPrecede_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_RemoveJob = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_AddJob = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewJobsThatPrecede_Jobs = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelJobsThatPrecede_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewJobsThatPrecede_AvailableJobs = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemRelatedJobs_JobsThatPrecede = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewJobsThatFollow_Jobs = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemRelatedJobs_JobsThatFollowTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabItemProjectScheduleDetails_RelatedJobsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAssignmentsTab_Assignments = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewAssignments_Assignments = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemProjectScheduleDetails_AssignmentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelJobInformationTab_JobInformation = New DevComponents.DotNetBar.TabControlPanel()
            Me.SearchableComboBoxJobInformation_AccountExecutive = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.LabelJobInformation_AccountExecutive = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxJobInformation_Component = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView13 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.SearchableComboBoxJobInformation_Job = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView14 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.SearchableComboBoxJobInformation_Product = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView11 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.SearchableComboBoxJobInformation_Division = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView10 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.LabelJobInformation_Component = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelJobInformation_Job = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelJobInformation_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelJobInformation_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelJobInformation_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxJobInformation_Client = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.TabItemProjectScheduleDetails_JobInformationTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOtherInformationTab_OtherInformation = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelOtherInformation_DateShipped = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelOtherInformation_DateDelivered = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxOtherInformation_Reference = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.DateTimePickerOtherInformation_Shipped = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.TextBoxOtherInformation_ReceivedBy = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.DateTimePickerOtherInformation_Delivered = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelOtherInformation_ReceivedBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelOtherInformation_Reference = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemProjectScheduleDetails_OtherInformationTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCommentsTab_Comments = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxComments_Comments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemProjectScheduleDetails_CommentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ToolTipControllerControl_ToolTips = New DevExpress.Utils.ToolTipController(Me.components)
            Me.DataGridViewControl_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlControl_TopBottom = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.NumericInputTaskDetails_GutComplete = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ExpandablePanelControl_General.SuspendLayout()
            CType(Me.TabControlControl_ProjectScheduleDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_ProjectScheduleDetails.SuspendLayout()
            Me.TabControlPanelTaskDetailsTab_TaskDetails.SuspendLayout()
            CType(Me.DateTimePickerTaskDetails_StartDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTaskDetails_TrafficStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerTaskDetails_DueDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerTaskDetails_CompletedDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelRelatedJobsTab_RelatedJobs.SuspendLayout()
            CType(Me.TabControlRelatedJobs_RelatedJobs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlRelatedJobs_RelatedJobs.SuspendLayout()
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.SuspendLayout()
            CType(Me.PanelJobsThatPrecede_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelJobsThatPrecede_RightSection.SuspendLayout()
            CType(Me.PanelJobsThatPrecede_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelJobsThatPrecede_LeftSection.SuspendLayout()
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow.SuspendLayout()
            Me.TabControlPanelAssignmentsTab_Assignments.SuspendLayout()
            Me.TabControlPanelJobInformationTab_JobInformation.SuspendLayout()
            CType(Me.SearchableComboBoxJobInformation_AccountExecutive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxJobInformation_Component.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView13, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxJobInformation_Job.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView14, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxJobInformation_Product.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView11, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxJobInformation_Division.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView10, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxJobInformation_Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelOtherInformationTab_OtherInformation.SuspendLayout()
            CType(Me.DateTimePickerOtherInformation_Shipped, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerOtherInformation_Delivered, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelCommentsTab_Comments.SuspendLayout()
            CType(Me.NumericInputTaskDetails_GutComplete.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ExpandablePanelControl_General
            '
            Me.ExpandablePanelControl_General.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.ExpandablePanelControl_General.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ExpandablePanelControl_General.Controls.Add(Me.TabControlControl_ProjectScheduleDetails)
            Me.ExpandablePanelControl_General.DisabledBackColor = System.Drawing.Color.Empty
            Me.ExpandablePanelControl_General.Dock = System.Windows.Forms.DockStyle.Top
            Me.ExpandablePanelControl_General.HideControlsWhenCollapsed = True
            Me.ExpandablePanelControl_General.Location = New System.Drawing.Point(0, 0)
            Me.ExpandablePanelControl_General.Name = "ExpandablePanelControl_General"
            Me.ExpandablePanelControl_General.Size = New System.Drawing.Size(685, 220)
            Me.ExpandablePanelControl_General.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.ExpandablePanelControl_General.Style.BackColor1.Color = System.Drawing.Color.White
            Me.ExpandablePanelControl_General.Style.BackColor2.Color = System.Drawing.Color.White
            Me.ExpandablePanelControl_General.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.ExpandablePanelControl_General.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.ExpandablePanelControl_General.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandablePanelControl_General.Style.GradientAngle = 90
            Me.ExpandablePanelControl_General.TabIndex = 3
            Me.ExpandablePanelControl_General.TextDockConstrained = False
            Me.ExpandablePanelControl_General.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
            Me.ExpandablePanelControl_General.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandablePanelControl_General.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
            Me.ExpandablePanelControl_General.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandablePanelControl_General.TitleStyle.ForeColor.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.ExpandablePanelControl_General.TitleStyle.GradientAngle = 90
            Me.ExpandablePanelControl_General.TitleText = "General Info"
            '
            'TabControlControl_ProjectScheduleDetails
            '
            Me.TabControlControl_ProjectScheduleDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlControl_ProjectScheduleDetails.BackColor = System.Drawing.Color.White
            Me.TabControlControl_ProjectScheduleDetails.CanReorderTabs = True
            Me.TabControlControl_ProjectScheduleDetails.Controls.Add(Me.TabControlPanelTaskDetailsTab_TaskDetails)
            Me.TabControlControl_ProjectScheduleDetails.Controls.Add(Me.TabControlPanelRelatedJobsTab_RelatedJobs)
            Me.TabControlControl_ProjectScheduleDetails.Controls.Add(Me.TabControlPanelAssignmentsTab_Assignments)
            Me.TabControlControl_ProjectScheduleDetails.Controls.Add(Me.TabControlPanelOtherInformationTab_OtherInformation)
            Me.TabControlControl_ProjectScheduleDetails.Controls.Add(Me.TabControlPanelCommentsTab_Comments)
            Me.TabControlControl_ProjectScheduleDetails.Controls.Add(Me.TabControlPanelJobInformationTab_JobInformation)
            Me.TabControlControl_ProjectScheduleDetails.ForeColor = System.Drawing.Color.Black
            Me.TabControlControl_ProjectScheduleDetails.Location = New System.Drawing.Point(3, 28)
            Me.TabControlControl_ProjectScheduleDetails.Name = "TabControlControl_ProjectScheduleDetails"
            Me.TabControlControl_ProjectScheduleDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_ProjectScheduleDetails.SelectedTabIndex = 3
            Me.TabControlControl_ProjectScheduleDetails.Size = New System.Drawing.Size(679, 189)
            Me.TabControlControl_ProjectScheduleDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_ProjectScheduleDetails.TabIndex = 2
            Me.TabControlControl_ProjectScheduleDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_ProjectScheduleDetails.Tabs.Add(Me.TabItemProjectScheduleDetails_JobInformationTab)
            Me.TabControlControl_ProjectScheduleDetails.Tabs.Add(Me.TabItemProjectScheduleDetails_CommentsTab)
            Me.TabControlControl_ProjectScheduleDetails.Tabs.Add(Me.TabItemProjectScheduleDetails_OtherInformationTab)
            Me.TabControlControl_ProjectScheduleDetails.Tabs.Add(Me.TabItemProjectScheduleDetails_AssignmentsTab)
            Me.TabControlControl_ProjectScheduleDetails.Tabs.Add(Me.TabItemProjectScheduleDetails_RelatedJobsTab)
            Me.TabControlControl_ProjectScheduleDetails.Tabs.Add(Me.TabItemProjectScheduleDetails_TaskDetailsTab)
            Me.TabControlControl_ProjectScheduleDetails.Text = "TabControl1"
            '
            'TabControlPanelTaskDetailsTab_TaskDetails
            '
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Controls.Add(Me.NumericInputTaskDetails_GutComplete)
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Controls.Add(Me.LabelTaskDetails_GutComplete)
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Controls.Add(Me.RadioButtonControlTaskDetails_DueDate)
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Controls.Add(Me.LabelTaskDetails_StartDate)
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Controls.Add(Me.RadioButtonControlTaskDetails_StartDate)
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Controls.Add(Me.DateTimePickerTaskDetails_StartDate)
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Controls.Add(Me.SearchableComboBoxTaskDetails_TrafficStatus)
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Controls.Add(Me.DateTimePickerTaskDetails_DueDate)
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Controls.Add(Me.LabelTaskDetails_DueDate)
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Controls.Add(Me.LabelTaskDetails_CompletedDate)
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Controls.Add(Me.DateTimePickerTaskDetails_CompletedDate)
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Controls.Add(Me.LabelTaskDetails_Traffic)
            Me.TabControlPanelTaskDetailsTab_TaskDetails.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Name = "TabControlPanelTaskDetailsTab_TaskDetails"
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Size = New System.Drawing.Size(679, 162)
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTaskDetailsTab_TaskDetails.Style.GradientAngle = 90
            Me.TabControlPanelTaskDetailsTab_TaskDetails.TabIndex = 2
            Me.TabControlPanelTaskDetailsTab_TaskDetails.TabItem = Me.TabItemProjectScheduleDetails_TaskDetailsTab
            '
            'LabelTaskDetails_GutComplete
            '
            Me.LabelTaskDetails_GutComplete.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTaskDetails_GutComplete.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTaskDetails_GutComplete.Location = New System.Drawing.Point(4, 82)
            Me.LabelTaskDetails_GutComplete.Name = "LabelTaskDetails_GutComplete"
            Me.LabelTaskDetails_GutComplete.Size = New System.Drawing.Size(98, 20)
            Me.LabelTaskDetails_GutComplete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTaskDetails_GutComplete.TabIndex = 8
            Me.LabelTaskDetails_GutComplete.Text = "Gut % Complete:"
            '
            'RadioButtonControlTaskDetails_DueDate
            '
            Me.RadioButtonControlTaskDetails_DueDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlTaskDetails_DueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlTaskDetails_DueDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlTaskDetails_DueDate.Location = New System.Drawing.Point(82, 30)
            Me.RadioButtonControlTaskDetails_DueDate.Name = "RadioButtonControlTaskDetails_DueDate"
            Me.RadioButtonControlTaskDetails_DueDate.SecurityEnabled = True
            Me.RadioButtonControlTaskDetails_DueDate.Size = New System.Drawing.Size(20, 20)
            Me.RadioButtonControlTaskDetails_DueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlTaskDetails_DueDate.TabIndex = 4
            Me.RadioButtonControlTaskDetails_DueDate.TabOnEnter = True
            Me.RadioButtonControlTaskDetails_DueDate.TabStop = False
            '
            'LabelTaskDetails_StartDate
            '
            Me.LabelTaskDetails_StartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTaskDetails_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTaskDetails_StartDate.Location = New System.Drawing.Point(4, 4)
            Me.LabelTaskDetails_StartDate.Name = "LabelTaskDetails_StartDate"
            Me.LabelTaskDetails_StartDate.Size = New System.Drawing.Size(72, 20)
            Me.LabelTaskDetails_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTaskDetails_StartDate.TabIndex = 0
            Me.LabelTaskDetails_StartDate.Text = "Start Date:"
            '
            'RadioButtonControlTaskDetails_StartDate
            '
            Me.RadioButtonControlTaskDetails_StartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlTaskDetails_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlTaskDetails_StartDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlTaskDetails_StartDate.Location = New System.Drawing.Point(82, 4)
            Me.RadioButtonControlTaskDetails_StartDate.Name = "RadioButtonControlTaskDetails_StartDate"
            Me.RadioButtonControlTaskDetails_StartDate.SecurityEnabled = True
            Me.RadioButtonControlTaskDetails_StartDate.Size = New System.Drawing.Size(20, 20)
            Me.RadioButtonControlTaskDetails_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlTaskDetails_StartDate.TabIndex = 1
            Me.RadioButtonControlTaskDetails_StartDate.TabOnEnter = True
            Me.RadioButtonControlTaskDetails_StartDate.TabStop = False
            '
            'DateTimePickerTaskDetails_StartDate
            '
            Me.DateTimePickerTaskDetails_StartDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerTaskDetails_StartDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerTaskDetails_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerTaskDetails_StartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerTaskDetails_StartDate.ButtonDropDown.Visible = True
            Me.DateTimePickerTaskDetails_StartDate.ButtonFreeText.Checked = True
            Me.DateTimePickerTaskDetails_StartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerTaskDetails_StartDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerTaskDetails_StartDate.DisplayName = ""
            Me.DateTimePickerTaskDetails_StartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerTaskDetails_StartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerTaskDetails_StartDate.FocusHighlightEnabled = True
            Me.DateTimePickerTaskDetails_StartDate.FreeTextEntryMode = True
            Me.DateTimePickerTaskDetails_StartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerTaskDetails_StartDate.Location = New System.Drawing.Point(108, 4)
            Me.DateTimePickerTaskDetails_StartDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerTaskDetails_StartDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerTaskDetails_StartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerTaskDetails_StartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerTaskDetails_StartDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerTaskDetails_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerTaskDetails_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerTaskDetails_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerTaskDetails_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerTaskDetails_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerTaskDetails_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerTaskDetails_StartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerTaskDetails_StartDate.MonthCalendar.DisplayMonth = New Date(2013, 10, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerTaskDetails_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerTaskDetails_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerTaskDetails_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerTaskDetails_StartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerTaskDetails_StartDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerTaskDetails_StartDate.Name = "DateTimePickerTaskDetails_StartDate"
            Me.DateTimePickerTaskDetails_StartDate.ReadOnly = False
            Me.DateTimePickerTaskDetails_StartDate.Size = New System.Drawing.Size(90, 20)
            Me.DateTimePickerTaskDetails_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerTaskDetails_StartDate.TabIndex = 2
            Me.DateTimePickerTaskDetails_StartDate.TabOnEnter = True
            Me.DateTimePickerTaskDetails_StartDate.Value = New Date(2013, 11, 27, 14, 22, 27, 819)
            '
            'SearchableComboBoxTaskDetails_TrafficStatus
            '
            Me.SearchableComboBoxTaskDetails_TrafficStatus.ActiveFilterString = ""
            Me.SearchableComboBoxTaskDetails_TrafficStatus.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxTaskDetails_TrafficStatus.AutoFillMode = False
            Me.SearchableComboBoxTaskDetails_TrafficStatus.BookmarkingEnabled = False
            Me.SearchableComboBoxTaskDetails_TrafficStatus.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Status
            Me.SearchableComboBoxTaskDetails_TrafficStatus.DataSource = Nothing
            Me.SearchableComboBoxTaskDetails_TrafficStatus.DisableMouseWheel = False
            Me.SearchableComboBoxTaskDetails_TrafficStatus.DisplayName = ""
            Me.SearchableComboBoxTaskDetails_TrafficStatus.EnterMoveNextControl = True
            Me.SearchableComboBoxTaskDetails_TrafficStatus.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxTaskDetails_TrafficStatus.Location = New System.Drawing.Point(108, 108)
            Me.SearchableComboBoxTaskDetails_TrafficStatus.Name = "SearchableComboBoxTaskDetails_TrafficStatus"
            Me.SearchableComboBoxTaskDetails_TrafficStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTaskDetails_TrafficStatus.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxTaskDetails_TrafficStatus.Properties.NullText = "Select Status"
            Me.SearchableComboBoxTaskDetails_TrafficStatus.Properties.ShowClearButton = False
            Me.SearchableComboBoxTaskDetails_TrafficStatus.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTaskDetails_TrafficStatus.Properties.View = Me.GridView5
            Me.SearchableComboBoxTaskDetails_TrafficStatus.SecurityEnabled = True
            Me.SearchableComboBoxTaskDetails_TrafficStatus.SelectedValue = Nothing
            Me.SearchableComboBoxTaskDetails_TrafficStatus.Size = New System.Drawing.Size(281, 20)
            Me.SearchableComboBoxTaskDetails_TrafficStatus.TabIndex = 11
            '
            'GridView5
            '
            Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView5.Name = "GridView5"
            Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView5.OptionsView.ShowGroupPanel = False
            '
            'DateTimePickerTaskDetails_DueDate
            '
            Me.DateTimePickerTaskDetails_DueDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerTaskDetails_DueDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerTaskDetails_DueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerTaskDetails_DueDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerTaskDetails_DueDate.ButtonDropDown.Visible = True
            Me.DateTimePickerTaskDetails_DueDate.ButtonFreeText.Checked = True
            Me.DateTimePickerTaskDetails_DueDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerTaskDetails_DueDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerTaskDetails_DueDate.DisplayName = ""
            Me.DateTimePickerTaskDetails_DueDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerTaskDetails_DueDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerTaskDetails_DueDate.FocusHighlightEnabled = True
            Me.DateTimePickerTaskDetails_DueDate.FreeTextEntryMode = True
            Me.DateTimePickerTaskDetails_DueDate.IsPopupCalendarOpen = False
            Me.DateTimePickerTaskDetails_DueDate.Location = New System.Drawing.Point(108, 30)
            Me.DateTimePickerTaskDetails_DueDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerTaskDetails_DueDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerTaskDetails_DueDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerTaskDetails_DueDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerTaskDetails_DueDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerTaskDetails_DueDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerTaskDetails_DueDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerTaskDetails_DueDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerTaskDetails_DueDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerTaskDetails_DueDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerTaskDetails_DueDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerTaskDetails_DueDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerTaskDetails_DueDate.MonthCalendar.DisplayMonth = New Date(2013, 10, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerTaskDetails_DueDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerTaskDetails_DueDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerTaskDetails_DueDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerTaskDetails_DueDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerTaskDetails_DueDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerTaskDetails_DueDate.Name = "DateTimePickerTaskDetails_DueDate"
            Me.DateTimePickerTaskDetails_DueDate.ReadOnly = False
            Me.DateTimePickerTaskDetails_DueDate.Size = New System.Drawing.Size(90, 20)
            Me.DateTimePickerTaskDetails_DueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerTaskDetails_DueDate.TabIndex = 5
            Me.DateTimePickerTaskDetails_DueDate.TabOnEnter = True
            Me.DateTimePickerTaskDetails_DueDate.Value = New Date(2013, 11, 27, 14, 22, 27, 802)
            '
            'LabelTaskDetails_DueDate
            '
            Me.LabelTaskDetails_DueDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTaskDetails_DueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTaskDetails_DueDate.Location = New System.Drawing.Point(4, 30)
            Me.LabelTaskDetails_DueDate.Name = "LabelTaskDetails_DueDate"
            Me.LabelTaskDetails_DueDate.Size = New System.Drawing.Size(72, 20)
            Me.LabelTaskDetails_DueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTaskDetails_DueDate.TabIndex = 3
            Me.LabelTaskDetails_DueDate.Text = "Due Date:"
            '
            'LabelTaskDetails_CompletedDate
            '
            Me.LabelTaskDetails_CompletedDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTaskDetails_CompletedDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTaskDetails_CompletedDate.Location = New System.Drawing.Point(4, 56)
            Me.LabelTaskDetails_CompletedDate.Name = "LabelTaskDetails_CompletedDate"
            Me.LabelTaskDetails_CompletedDate.Size = New System.Drawing.Size(98, 20)
            Me.LabelTaskDetails_CompletedDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTaskDetails_CompletedDate.TabIndex = 6
            Me.LabelTaskDetails_CompletedDate.Text = "Completed Date:"
            '
            'DateTimePickerTaskDetails_CompletedDate
            '
            Me.DateTimePickerTaskDetails_CompletedDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerTaskDetails_CompletedDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerTaskDetails_CompletedDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerTaskDetails_CompletedDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerTaskDetails_CompletedDate.ButtonDropDown.Visible = True
            Me.DateTimePickerTaskDetails_CompletedDate.ButtonFreeText.Checked = True
            Me.DateTimePickerTaskDetails_CompletedDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerTaskDetails_CompletedDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerTaskDetails_CompletedDate.DisplayName = ""
            Me.DateTimePickerTaskDetails_CompletedDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerTaskDetails_CompletedDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerTaskDetails_CompletedDate.FocusHighlightEnabled = True
            Me.DateTimePickerTaskDetails_CompletedDate.FreeTextEntryMode = True
            Me.DateTimePickerTaskDetails_CompletedDate.IsPopupCalendarOpen = False
            Me.DateTimePickerTaskDetails_CompletedDate.Location = New System.Drawing.Point(108, 56)
            Me.DateTimePickerTaskDetails_CompletedDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerTaskDetails_CompletedDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerTaskDetails_CompletedDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerTaskDetails_CompletedDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerTaskDetails_CompletedDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerTaskDetails_CompletedDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerTaskDetails_CompletedDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerTaskDetails_CompletedDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerTaskDetails_CompletedDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerTaskDetails_CompletedDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerTaskDetails_CompletedDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerTaskDetails_CompletedDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerTaskDetails_CompletedDate.MonthCalendar.DisplayMonth = New Date(2013, 10, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerTaskDetails_CompletedDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerTaskDetails_CompletedDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerTaskDetails_CompletedDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerTaskDetails_CompletedDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerTaskDetails_CompletedDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerTaskDetails_CompletedDate.Name = "DateTimePickerTaskDetails_CompletedDate"
            Me.DateTimePickerTaskDetails_CompletedDate.ReadOnly = False
            Me.DateTimePickerTaskDetails_CompletedDate.Size = New System.Drawing.Size(90, 20)
            Me.DateTimePickerTaskDetails_CompletedDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerTaskDetails_CompletedDate.TabIndex = 7
            Me.DateTimePickerTaskDetails_CompletedDate.TabOnEnter = True
            Me.DateTimePickerTaskDetails_CompletedDate.Value = New Date(2013, 11, 27, 14, 22, 27, 777)
            '
            'LabelTaskDetails_Traffic
            '
            Me.LabelTaskDetails_Traffic.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTaskDetails_Traffic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTaskDetails_Traffic.Location = New System.Drawing.Point(4, 108)
            Me.LabelTaskDetails_Traffic.Name = "LabelTaskDetails_Traffic"
            Me.LabelTaskDetails_Traffic.Size = New System.Drawing.Size(98, 20)
            Me.LabelTaskDetails_Traffic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTaskDetails_Traffic.TabIndex = 10
            Me.LabelTaskDetails_Traffic.Text = "Traffic Status:"
            '
            'TabItemProjectScheduleDetails_TaskDetailsTab
            '
            Me.TabItemProjectScheduleDetails_TaskDetailsTab.AttachedControl = Me.TabControlPanelTaskDetailsTab_TaskDetails
            Me.TabItemProjectScheduleDetails_TaskDetailsTab.Name = "TabItemProjectScheduleDetails_TaskDetailsTab"
            Me.TabItemProjectScheduleDetails_TaskDetailsTab.Text = "Task Details"
            '
            'TabControlPanelRelatedJobsTab_RelatedJobs
            '
            Me.TabControlPanelRelatedJobsTab_RelatedJobs.Controls.Add(Me.TabControlRelatedJobs_RelatedJobs)
            Me.TabControlPanelRelatedJobsTab_RelatedJobs.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelRelatedJobsTab_RelatedJobs.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRelatedJobsTab_RelatedJobs.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRelatedJobsTab_RelatedJobs.Name = "TabControlPanelRelatedJobsTab_RelatedJobs"
            Me.TabControlPanelRelatedJobsTab_RelatedJobs.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRelatedJobsTab_RelatedJobs.Size = New System.Drawing.Size(679, 162)
            Me.TabControlPanelRelatedJobsTab_RelatedJobs.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRelatedJobsTab_RelatedJobs.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRelatedJobsTab_RelatedJobs.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRelatedJobsTab_RelatedJobs.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRelatedJobsTab_RelatedJobs.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRelatedJobsTab_RelatedJobs.Style.GradientAngle = 90
            Me.TabControlPanelRelatedJobsTab_RelatedJobs.TabIndex = 4
            Me.TabControlPanelRelatedJobsTab_RelatedJobs.TabItem = Me.TabItemProjectScheduleDetails_RelatedJobsTab
            '
            'TabControlRelatedJobs_RelatedJobs
            '
            Me.TabControlRelatedJobs_RelatedJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlRelatedJobs_RelatedJobs.BackColor = System.Drawing.Color.White
            Me.TabControlRelatedJobs_RelatedJobs.CanReorderTabs = True
            Me.TabControlRelatedJobs_RelatedJobs.Controls.Add(Me.TabControlPanelJobsThatFollowTab_JobsThatFollow)
            Me.TabControlRelatedJobs_RelatedJobs.Controls.Add(Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede)
            Me.TabControlRelatedJobs_RelatedJobs.ForeColor = System.Drawing.Color.Black
            Me.TabControlRelatedJobs_RelatedJobs.Location = New System.Drawing.Point(4, 4)
            Me.TabControlRelatedJobs_RelatedJobs.Name = "TabControlRelatedJobs_RelatedJobs"
            Me.TabControlRelatedJobs_RelatedJobs.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlRelatedJobs_RelatedJobs.SelectedTabIndex = 3
            Me.TabControlRelatedJobs_RelatedJobs.Size = New System.Drawing.Size(671, 154)
            Me.TabControlRelatedJobs_RelatedJobs.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlRelatedJobs_RelatedJobs.TabIndex = 3
            Me.TabControlRelatedJobs_RelatedJobs.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlRelatedJobs_RelatedJobs.Tabs.Add(Me.TabItemRelatedJobs_JobsThatPrecede)
            Me.TabControlRelatedJobs_RelatedJobs.Tabs.Add(Me.TabItemRelatedJobs_JobsThatFollowTab)
            Me.TabControlRelatedJobs_RelatedJobs.Text = "TabControl1"
            '
            'TabControlPanelJobsThatPrecedeTab_JobsThatPrecede
            '
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.Controls.Add(Me.PanelJobsThatPrecede_RightSection)
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.Controls.Add(Me.ExpandableSplitterControlJobsThatPrecede_LeftRight)
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.Controls.Add(Me.PanelJobsThatPrecede_LeftSection)
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.Name = "TabControlPanelJobsThatPrecedeTab_JobsThatPrecede"
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.Size = New System.Drawing.Size(671, 127)
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.Style.GradientAngle = 90
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.TabIndex = 5
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.TabItem = Me.TabItemRelatedJobs_JobsThatPrecede
            '
            'PanelJobsThatPrecede_RightSection
            '
            Me.PanelJobsThatPrecede_RightSection.Controls.Add(Me.ButtonRightSection_RemoveJob)
            Me.PanelJobsThatPrecede_RightSection.Controls.Add(Me.ButtonRightSection_AddJob)
            Me.PanelJobsThatPrecede_RightSection.Controls.Add(Me.DataGridViewJobsThatPrecede_Jobs)
            Me.PanelJobsThatPrecede_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelJobsThatPrecede_RightSection.Location = New System.Drawing.Point(259, 1)
            Me.PanelJobsThatPrecede_RightSection.Name = "PanelJobsThatPrecede_RightSection"
            Me.PanelJobsThatPrecede_RightSection.Size = New System.Drawing.Size(411, 125)
            Me.PanelJobsThatPrecede_RightSection.TabIndex = 1
            '
            'ButtonRightSection_RemoveJob
            '
            Me.ButtonRightSection_RemoveJob.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveJob.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveJob.Location = New System.Drawing.Point(6, 31)
            Me.ButtonRightSection_RemoveJob.Name = "ButtonRightSection_RemoveJob"
            Me.ButtonRightSection_RemoveJob.SecurityEnabled = True
            Me.ButtonRightSection_RemoveJob.Size = New System.Drawing.Size(73, 20)
            Me.ButtonRightSection_RemoveJob.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveJob.TabIndex = 3
            Me.ButtonRightSection_RemoveJob.Text = "<"
            '
            'ButtonRightSection_AddJob
            '
            Me.ButtonRightSection_AddJob.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddJob.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddJob.Location = New System.Drawing.Point(6, 5)
            Me.ButtonRightSection_AddJob.Name = "ButtonRightSection_AddJob"
            Me.ButtonRightSection_AddJob.SecurityEnabled = True
            Me.ButtonRightSection_AddJob.Size = New System.Drawing.Size(73, 20)
            Me.ButtonRightSection_AddJob.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddJob.TabIndex = 2
            Me.ButtonRightSection_AddJob.Text = ">"
            '
            'DataGridViewJobsThatPrecede_Jobs
            '
            Me.DataGridViewJobsThatPrecede_Jobs.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewJobsThatPrecede_Jobs.AllowDragAndDrop = False
            Me.DataGridViewJobsThatPrecede_Jobs.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewJobsThatPrecede_Jobs.AllowSelectGroupHeaderRow = True
            Me.DataGridViewJobsThatPrecede_Jobs.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewJobsThatPrecede_Jobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewJobsThatPrecede_Jobs.AutoFilterLookupColumns = False
            Me.DataGridViewJobsThatPrecede_Jobs.AutoloadRepositoryDatasource = True
            Me.DataGridViewJobsThatPrecede_Jobs.AutoUpdateViewCaption = True
            Me.DataGridViewJobsThatPrecede_Jobs.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewJobsThatPrecede_Jobs.DataSource = Nothing
            Me.DataGridViewJobsThatPrecede_Jobs.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewJobsThatPrecede_Jobs.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewJobsThatPrecede_Jobs.ItemDescription = ""
            Me.DataGridViewJobsThatPrecede_Jobs.Location = New System.Drawing.Point(85, 5)
            Me.DataGridViewJobsThatPrecede_Jobs.MultiSelect = True
            Me.DataGridViewJobsThatPrecede_Jobs.Name = "DataGridViewJobsThatPrecede_Jobs"
            Me.DataGridViewJobsThatPrecede_Jobs.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewJobsThatPrecede_Jobs.RunStandardValidation = True
            Me.DataGridViewJobsThatPrecede_Jobs.ShowColumnMenuOnRightClick = False
            Me.DataGridViewJobsThatPrecede_Jobs.ShowSelectDeselectAllButtons = False
            Me.DataGridViewJobsThatPrecede_Jobs.Size = New System.Drawing.Size(321, 115)
            Me.DataGridViewJobsThatPrecede_Jobs.TabIndex = 4
            Me.DataGridViewJobsThatPrecede_Jobs.UseEmbeddedNavigator = False
            Me.DataGridViewJobsThatPrecede_Jobs.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlJobsThatPrecede_LeftRight
            '
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.Location = New System.Drawing.Point(253, 1)
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.Name = "ExpandableSplitterControlJobsThatPrecede_LeftRight"
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.Size = New System.Drawing.Size(6, 125)
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.TabIndex = 12
            Me.ExpandableSplitterControlJobsThatPrecede_LeftRight.TabStop = False
            '
            'PanelJobsThatPrecede_LeftSection
            '
            Me.PanelJobsThatPrecede_LeftSection.Controls.Add(Me.DataGridViewJobsThatPrecede_AvailableJobs)
            Me.PanelJobsThatPrecede_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelJobsThatPrecede_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelJobsThatPrecede_LeftSection.Name = "PanelJobsThatPrecede_LeftSection"
            Me.PanelJobsThatPrecede_LeftSection.Size = New System.Drawing.Size(252, 125)
            Me.PanelJobsThatPrecede_LeftSection.TabIndex = 0
            '
            'DataGridViewJobsThatPrecede_AvailableJobs
            '
            Me.DataGridViewJobsThatPrecede_AvailableJobs.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewJobsThatPrecede_AvailableJobs.AllowDragAndDrop = False
            Me.DataGridViewJobsThatPrecede_AvailableJobs.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewJobsThatPrecede_AvailableJobs.AllowSelectGroupHeaderRow = True
            Me.DataGridViewJobsThatPrecede_AvailableJobs.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewJobsThatPrecede_AvailableJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewJobsThatPrecede_AvailableJobs.AutoFilterLookupColumns = False
            Me.DataGridViewJobsThatPrecede_AvailableJobs.AutoloadRepositoryDatasource = True
            Me.DataGridViewJobsThatPrecede_AvailableJobs.AutoUpdateViewCaption = True
            Me.DataGridViewJobsThatPrecede_AvailableJobs.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewJobsThatPrecede_AvailableJobs.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewJobsThatPrecede_AvailableJobs.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewJobsThatPrecede_AvailableJobs.ItemDescription = ""
            Me.DataGridViewJobsThatPrecede_AvailableJobs.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewJobsThatPrecede_AvailableJobs.MultiSelect = True
            Me.DataGridViewJobsThatPrecede_AvailableJobs.Name = "DataGridViewJobsThatPrecede_AvailableJobs"
            Me.DataGridViewJobsThatPrecede_AvailableJobs.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewJobsThatPrecede_AvailableJobs.RunStandardValidation = True
            Me.DataGridViewJobsThatPrecede_AvailableJobs.ShowColumnMenuOnRightClick = False
            Me.DataGridViewJobsThatPrecede_AvailableJobs.ShowSelectDeselectAllButtons = False
            Me.DataGridViewJobsThatPrecede_AvailableJobs.Size = New System.Drawing.Size(241, 115)
            Me.DataGridViewJobsThatPrecede_AvailableJobs.TabIndex = 0
            Me.DataGridViewJobsThatPrecede_AvailableJobs.UseEmbeddedNavigator = False
            Me.DataGridViewJobsThatPrecede_AvailableJobs.ViewCaptionHeight = -1
            '
            'TabItemRelatedJobs_JobsThatPrecede
            '
            Me.TabItemRelatedJobs_JobsThatPrecede.AttachedControl = Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede
            Me.TabItemRelatedJobs_JobsThatPrecede.Name = "TabItemRelatedJobs_JobsThatPrecede"
            Me.TabItemRelatedJobs_JobsThatPrecede.Text = "Jobs that precede this Job"
            '
            'TabControlPanelJobsThatFollowTab_JobsThatFollow
            '
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow.Controls.Add(Me.DataGridViewJobsThatFollow_Jobs)
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow.Name = "TabControlPanelJobsThatFollowTab_JobsThatFollow"
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow.Size = New System.Drawing.Size(671, 127)
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow.Style.GradientAngle = 90
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow.TabIndex = 3
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow.TabItem = Me.TabItemRelatedJobs_JobsThatFollowTab
            '
            'DataGridViewJobsThatFollow_Jobs
            '
            Me.DataGridViewJobsThatFollow_Jobs.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewJobsThatFollow_Jobs.AllowDragAndDrop = False
            Me.DataGridViewJobsThatFollow_Jobs.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewJobsThatFollow_Jobs.AllowSelectGroupHeaderRow = True
            Me.DataGridViewJobsThatFollow_Jobs.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewJobsThatFollow_Jobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewJobsThatFollow_Jobs.AutoFilterLookupColumns = False
            Me.DataGridViewJobsThatFollow_Jobs.AutoloadRepositoryDatasource = True
            Me.DataGridViewJobsThatFollow_Jobs.AutoUpdateViewCaption = True
            Me.DataGridViewJobsThatFollow_Jobs.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewJobsThatFollow_Jobs.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewJobsThatFollow_Jobs.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewJobsThatFollow_Jobs.ItemDescription = ""
            Me.DataGridViewJobsThatFollow_Jobs.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewJobsThatFollow_Jobs.MultiSelect = True
            Me.DataGridViewJobsThatFollow_Jobs.Name = "DataGridViewJobsThatFollow_Jobs"
            Me.DataGridViewJobsThatFollow_Jobs.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewJobsThatFollow_Jobs.RunStandardValidation = True
            Me.DataGridViewJobsThatFollow_Jobs.ShowColumnMenuOnRightClick = False
            Me.DataGridViewJobsThatFollow_Jobs.ShowSelectDeselectAllButtons = False
            Me.DataGridViewJobsThatFollow_Jobs.Size = New System.Drawing.Size(663, 119)
            Me.DataGridViewJobsThatFollow_Jobs.TabIndex = 0
            Me.DataGridViewJobsThatFollow_Jobs.UseEmbeddedNavigator = False
            Me.DataGridViewJobsThatFollow_Jobs.ViewCaptionHeight = -1
            '
            'TabItemRelatedJobs_JobsThatFollowTab
            '
            Me.TabItemRelatedJobs_JobsThatFollowTab.AttachedControl = Me.TabControlPanelJobsThatFollowTab_JobsThatFollow
            Me.TabItemRelatedJobs_JobsThatFollowTab.Name = "TabItemRelatedJobs_JobsThatFollowTab"
            Me.TabItemRelatedJobs_JobsThatFollowTab.Text = "Jobs that follow this Job"
            '
            'TabItemProjectScheduleDetails_RelatedJobsTab
            '
            Me.TabItemProjectScheduleDetails_RelatedJobsTab.AttachedControl = Me.TabControlPanelRelatedJobsTab_RelatedJobs
            Me.TabItemProjectScheduleDetails_RelatedJobsTab.Name = "TabItemProjectScheduleDetails_RelatedJobsTab"
            Me.TabItemProjectScheduleDetails_RelatedJobsTab.Text = "Related Jobs"
            '
            'TabControlPanelAssignmentsTab_Assignments
            '
            Me.TabControlPanelAssignmentsTab_Assignments.Controls.Add(Me.DataGridViewAssignments_Assignments)
            Me.TabControlPanelAssignmentsTab_Assignments.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAssignmentsTab_Assignments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAssignmentsTab_Assignments.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAssignmentsTab_Assignments.Name = "TabControlPanelAssignmentsTab_Assignments"
            Me.TabControlPanelAssignmentsTab_Assignments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAssignmentsTab_Assignments.Size = New System.Drawing.Size(679, 162)
            Me.TabControlPanelAssignmentsTab_Assignments.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAssignmentsTab_Assignments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAssignmentsTab_Assignments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAssignmentsTab_Assignments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAssignmentsTab_Assignments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAssignmentsTab_Assignments.Style.GradientAngle = 90
            Me.TabControlPanelAssignmentsTab_Assignments.TabIndex = 1
            Me.TabControlPanelAssignmentsTab_Assignments.TabItem = Me.TabItemProjectScheduleDetails_AssignmentsTab
            '
            'DataGridViewAssignments_Assignments
            '
            Me.DataGridViewAssignments_Assignments.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewAssignments_Assignments.AllowDragAndDrop = False
            Me.DataGridViewAssignments_Assignments.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewAssignments_Assignments.AllowSelectGroupHeaderRow = True
            Me.DataGridViewAssignments_Assignments.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewAssignments_Assignments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewAssignments_Assignments.AutoFilterLookupColumns = False
            Me.DataGridViewAssignments_Assignments.AutoloadRepositoryDatasource = True
            Me.DataGridViewAssignments_Assignments.AutoUpdateViewCaption = True
            Me.DataGridViewAssignments_Assignments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewAssignments_Assignments.DataSource = Nothing
            Me.DataGridViewAssignments_Assignments.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewAssignments_Assignments.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewAssignments_Assignments.ItemDescription = "Item(s)"
            Me.DataGridViewAssignments_Assignments.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewAssignments_Assignments.MultiSelect = True
            Me.DataGridViewAssignments_Assignments.Name = "DataGridViewAssignments_Assignments"
            Me.DataGridViewAssignments_Assignments.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewAssignments_Assignments.RunStandardValidation = True
            Me.DataGridViewAssignments_Assignments.ShowColumnMenuOnRightClick = False
            Me.DataGridViewAssignments_Assignments.ShowSelectDeselectAllButtons = False
            Me.DataGridViewAssignments_Assignments.Size = New System.Drawing.Size(672, 155)
            Me.DataGridViewAssignments_Assignments.TabIndex = 10
            Me.DataGridViewAssignments_Assignments.UseEmbeddedNavigator = False
            Me.DataGridViewAssignments_Assignments.ViewCaptionHeight = -1
            '
            'TabItemProjectScheduleDetails_AssignmentsTab
            '
            Me.TabItemProjectScheduleDetails_AssignmentsTab.AttachedControl = Me.TabControlPanelAssignmentsTab_Assignments
            Me.TabItemProjectScheduleDetails_AssignmentsTab.Name = "TabItemProjectScheduleDetails_AssignmentsTab"
            Me.TabItemProjectScheduleDetails_AssignmentsTab.Text = "Assignments"
            '
            'TabControlPanelJobInformationTab_JobInformation
            '
            Me.TabControlPanelJobInformationTab_JobInformation.Controls.Add(Me.SearchableComboBoxJobInformation_AccountExecutive)
            Me.TabControlPanelJobInformationTab_JobInformation.Controls.Add(Me.LabelJobInformation_AccountExecutive)
            Me.TabControlPanelJobInformationTab_JobInformation.Controls.Add(Me.SearchableComboBoxJobInformation_Component)
            Me.TabControlPanelJobInformationTab_JobInformation.Controls.Add(Me.SearchableComboBoxJobInformation_Job)
            Me.TabControlPanelJobInformationTab_JobInformation.Controls.Add(Me.SearchableComboBoxJobInformation_Product)
            Me.TabControlPanelJobInformationTab_JobInformation.Controls.Add(Me.SearchableComboBoxJobInformation_Division)
            Me.TabControlPanelJobInformationTab_JobInformation.Controls.Add(Me.LabelJobInformation_Component)
            Me.TabControlPanelJobInformationTab_JobInformation.Controls.Add(Me.LabelJobInformation_Job)
            Me.TabControlPanelJobInformationTab_JobInformation.Controls.Add(Me.LabelJobInformation_Product)
            Me.TabControlPanelJobInformationTab_JobInformation.Controls.Add(Me.LabelJobInformation_Client)
            Me.TabControlPanelJobInformationTab_JobInformation.Controls.Add(Me.LabelJobInformation_Division)
            Me.TabControlPanelJobInformationTab_JobInformation.Controls.Add(Me.SearchableComboBoxJobInformation_Client)
            Me.TabControlPanelJobInformationTab_JobInformation.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelJobInformationTab_JobInformation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelJobInformationTab_JobInformation.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelJobInformationTab_JobInformation.Name = "TabControlPanelJobInformationTab_JobInformation"
            Me.TabControlPanelJobInformationTab_JobInformation.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelJobInformationTab_JobInformation.Size = New System.Drawing.Size(679, 162)
            Me.TabControlPanelJobInformationTab_JobInformation.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelJobInformationTab_JobInformation.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelJobInformationTab_JobInformation.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelJobInformationTab_JobInformation.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelJobInformationTab_JobInformation.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelJobInformationTab_JobInformation.Style.GradientAngle = 90
            Me.TabControlPanelJobInformationTab_JobInformation.TabIndex = 5
            Me.TabControlPanelJobInformationTab_JobInformation.TabItem = Me.TabItemProjectScheduleDetails_JobInformationTab
            '
            'SearchableComboBoxJobInformation_AccountExecutive
            '
            Me.SearchableComboBoxJobInformation_AccountExecutive.ActiveFilterString = ""
            Me.SearchableComboBoxJobInformation_AccountExecutive.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxJobInformation_AccountExecutive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxJobInformation_AccountExecutive.AutoFillMode = False
            Me.SearchableComboBoxJobInformation_AccountExecutive.BookmarkingEnabled = False
            Me.SearchableComboBoxJobInformation_AccountExecutive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxJobInformation_AccountExecutive.DataSource = Nothing
            Me.SearchableComboBoxJobInformation_AccountExecutive.DisableMouseWheel = False
            Me.SearchableComboBoxJobInformation_AccountExecutive.DisplayName = ""
            Me.SearchableComboBoxJobInformation_AccountExecutive.EnterMoveNextControl = True
            Me.SearchableComboBoxJobInformation_AccountExecutive.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxJobInformation_AccountExecutive.Location = New System.Drawing.Point(113, 134)
            Me.SearchableComboBoxJobInformation_AccountExecutive.Name = "SearchableComboBoxJobInformation_AccountExecutive"
            Me.SearchableComboBoxJobInformation_AccountExecutive.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxJobInformation_AccountExecutive.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxJobInformation_AccountExecutive.Properties.NullText = "Select Employee"
            Me.SearchableComboBoxJobInformation_AccountExecutive.Properties.ShowClearButton = False
            Me.SearchableComboBoxJobInformation_AccountExecutive.Properties.ValueMember = "Code"
            Me.SearchableComboBoxJobInformation_AccountExecutive.Properties.View = Me.GridView7
            Me.SearchableComboBoxJobInformation_AccountExecutive.SecurityEnabled = True
            Me.SearchableComboBoxJobInformation_AccountExecutive.SelectedValue = Nothing
            Me.SearchableComboBoxJobInformation_AccountExecutive.Size = New System.Drawing.Size(308, 20)
            Me.SearchableComboBoxJobInformation_AccountExecutive.TabIndex = 11
            '
            'GridView7
            '
            Me.GridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView7.Name = "GridView7"
            Me.GridView7.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView7.OptionsView.ShowGroupPanel = False
            '
            'LabelJobInformation_AccountExecutive
            '
            Me.LabelJobInformation_AccountExecutive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelJobInformation_AccountExecutive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelJobInformation_AccountExecutive.Location = New System.Drawing.Point(4, 134)
            Me.LabelJobInformation_AccountExecutive.Name = "LabelJobInformation_AccountExecutive"
            Me.LabelJobInformation_AccountExecutive.Size = New System.Drawing.Size(103, 20)
            Me.LabelJobInformation_AccountExecutive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelJobInformation_AccountExecutive.TabIndex = 10
            Me.LabelJobInformation_AccountExecutive.Text = "Account Executive:"
            '
            'SearchableComboBoxJobInformation_Component
            '
            Me.SearchableComboBoxJobInformation_Component.ActiveFilterString = ""
            Me.SearchableComboBoxJobInformation_Component.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxJobInformation_Component.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxJobInformation_Component.AutoFillMode = False
            Me.SearchableComboBoxJobInformation_Component.BookmarkingEnabled = False
            Me.SearchableComboBoxJobInformation_Component.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.JobComponent
            Me.SearchableComboBoxJobInformation_Component.DataSource = Nothing
            Me.SearchableComboBoxJobInformation_Component.DisableMouseWheel = False
            Me.SearchableComboBoxJobInformation_Component.DisplayName = ""
            Me.SearchableComboBoxJobInformation_Component.EnterMoveNextControl = True
            Me.SearchableComboBoxJobInformation_Component.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxJobInformation_Component.Location = New System.Drawing.Point(113, 108)
            Me.SearchableComboBoxJobInformation_Component.Name = "SearchableComboBoxJobInformation_Component"
            Me.SearchableComboBoxJobInformation_Component.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxJobInformation_Component.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxJobInformation_Component.Properties.NullText = "Select Job Component"
            Me.SearchableComboBoxJobInformation_Component.Properties.ShowClearButton = False
            Me.SearchableComboBoxJobInformation_Component.Properties.ValueMember = "Number"
            Me.SearchableComboBoxJobInformation_Component.Properties.View = Me.GridView13
            Me.SearchableComboBoxJobInformation_Component.SecurityEnabled = True
            Me.SearchableComboBoxJobInformation_Component.SelectedValue = Nothing
            Me.SearchableComboBoxJobInformation_Component.Size = New System.Drawing.Size(308, 20)
            Me.SearchableComboBoxJobInformation_Component.TabIndex = 9
            '
            'GridView13
            '
            Me.GridView13.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView13.Name = "GridView13"
            Me.GridView13.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView13.OptionsView.ShowGroupPanel = False
            '
            'SearchableComboBoxJobInformation_Job
            '
            Me.SearchableComboBoxJobInformation_Job.ActiveFilterString = ""
            Me.SearchableComboBoxJobInformation_Job.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxJobInformation_Job.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxJobInformation_Job.AutoFillMode = False
            Me.SearchableComboBoxJobInformation_Job.BookmarkingEnabled = False
            Me.SearchableComboBoxJobInformation_Job.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Job
            Me.SearchableComboBoxJobInformation_Job.DataSource = Nothing
            Me.SearchableComboBoxJobInformation_Job.DisableMouseWheel = False
            Me.SearchableComboBoxJobInformation_Job.DisplayName = ""
            Me.SearchableComboBoxJobInformation_Job.EnterMoveNextControl = True
            Me.SearchableComboBoxJobInformation_Job.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxJobInformation_Job.Location = New System.Drawing.Point(113, 82)
            Me.SearchableComboBoxJobInformation_Job.Name = "SearchableComboBoxJobInformation_Job"
            Me.SearchableComboBoxJobInformation_Job.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxJobInformation_Job.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxJobInformation_Job.Properties.NullText = "Select Job"
            Me.SearchableComboBoxJobInformation_Job.Properties.ShowClearButton = False
            Me.SearchableComboBoxJobInformation_Job.Properties.ValueMember = "Number"
            Me.SearchableComboBoxJobInformation_Job.Properties.View = Me.GridView14
            Me.SearchableComboBoxJobInformation_Job.SecurityEnabled = True
            Me.SearchableComboBoxJobInformation_Job.SelectedValue = Nothing
            Me.SearchableComboBoxJobInformation_Job.Size = New System.Drawing.Size(308, 20)
            Me.SearchableComboBoxJobInformation_Job.TabIndex = 7
            '
            'GridView14
            '
            Me.GridView14.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView14.Name = "GridView14"
            Me.GridView14.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView14.OptionsView.ShowGroupPanel = False
            '
            'SearchableComboBoxJobInformation_Product
            '
            Me.SearchableComboBoxJobInformation_Product.ActiveFilterString = ""
            Me.SearchableComboBoxJobInformation_Product.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxJobInformation_Product.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxJobInformation_Product.AutoFillMode = False
            Me.SearchableComboBoxJobInformation_Product.BookmarkingEnabled = False
            Me.SearchableComboBoxJobInformation_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Product
            Me.SearchableComboBoxJobInformation_Product.DataSource = Nothing
            Me.SearchableComboBoxJobInformation_Product.DisableMouseWheel = False
            Me.SearchableComboBoxJobInformation_Product.DisplayName = ""
            Me.SearchableComboBoxJobInformation_Product.EnterMoveNextControl = True
            Me.SearchableComboBoxJobInformation_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxJobInformation_Product.Location = New System.Drawing.Point(113, 56)
            Me.SearchableComboBoxJobInformation_Product.Name = "SearchableComboBoxJobInformation_Product"
            Me.SearchableComboBoxJobInformation_Product.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxJobInformation_Product.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxJobInformation_Product.Properties.NullText = "Select Product"
            Me.SearchableComboBoxJobInformation_Product.Properties.ShowClearButton = False
            Me.SearchableComboBoxJobInformation_Product.Properties.ValueMember = "Code"
            Me.SearchableComboBoxJobInformation_Product.Properties.View = Me.GridView11
            Me.SearchableComboBoxJobInformation_Product.SecurityEnabled = True
            Me.SearchableComboBoxJobInformation_Product.SelectedValue = Nothing
            Me.SearchableComboBoxJobInformation_Product.Size = New System.Drawing.Size(308, 20)
            Me.SearchableComboBoxJobInformation_Product.TabIndex = 5
            '
            'GridView11
            '
            Me.GridView11.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView11.Name = "GridView11"
            Me.GridView11.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView11.OptionsView.ShowGroupPanel = False
            '
            'SearchableComboBoxJobInformation_Division
            '
            Me.SearchableComboBoxJobInformation_Division.ActiveFilterString = ""
            Me.SearchableComboBoxJobInformation_Division.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxJobInformation_Division.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxJobInformation_Division.AutoFillMode = False
            Me.SearchableComboBoxJobInformation_Division.BookmarkingEnabled = False
            Me.SearchableComboBoxJobInformation_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Division
            Me.SearchableComboBoxJobInformation_Division.DataSource = Nothing
            Me.SearchableComboBoxJobInformation_Division.DisableMouseWheel = False
            Me.SearchableComboBoxJobInformation_Division.DisplayName = ""
            Me.SearchableComboBoxJobInformation_Division.EnterMoveNextControl = True
            Me.SearchableComboBoxJobInformation_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxJobInformation_Division.Location = New System.Drawing.Point(113, 30)
            Me.SearchableComboBoxJobInformation_Division.Name = "SearchableComboBoxJobInformation_Division"
            Me.SearchableComboBoxJobInformation_Division.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxJobInformation_Division.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxJobInformation_Division.Properties.NullText = "Select Division"
            Me.SearchableComboBoxJobInformation_Division.Properties.ShowClearButton = False
            Me.SearchableComboBoxJobInformation_Division.Properties.ValueMember = "Code"
            Me.SearchableComboBoxJobInformation_Division.Properties.View = Me.GridView10
            Me.SearchableComboBoxJobInformation_Division.SecurityEnabled = True
            Me.SearchableComboBoxJobInformation_Division.SelectedValue = Nothing
            Me.SearchableComboBoxJobInformation_Division.Size = New System.Drawing.Size(308, 20)
            Me.SearchableComboBoxJobInformation_Division.TabIndex = 3
            '
            'GridView10
            '
            Me.GridView10.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView10.Name = "GridView10"
            Me.GridView10.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView10.OptionsView.ShowGroupPanel = False
            '
            'LabelJobInformation_Component
            '
            Me.LabelJobInformation_Component.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelJobInformation_Component.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelJobInformation_Component.Location = New System.Drawing.Point(4, 108)
            Me.LabelJobInformation_Component.Name = "LabelJobInformation_Component"
            Me.LabelJobInformation_Component.Size = New System.Drawing.Size(103, 20)
            Me.LabelJobInformation_Component.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelJobInformation_Component.TabIndex = 8
            Me.LabelJobInformation_Component.Text = "Component:"
            '
            'LabelJobInformation_Job
            '
            Me.LabelJobInformation_Job.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelJobInformation_Job.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelJobInformation_Job.Location = New System.Drawing.Point(4, 82)
            Me.LabelJobInformation_Job.Name = "LabelJobInformation_Job"
            Me.LabelJobInformation_Job.Size = New System.Drawing.Size(103, 20)
            Me.LabelJobInformation_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelJobInformation_Job.TabIndex = 6
            Me.LabelJobInformation_Job.Text = "Job:"
            '
            'LabelJobInformation_Product
            '
            Me.LabelJobInformation_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelJobInformation_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelJobInformation_Product.Location = New System.Drawing.Point(4, 56)
            Me.LabelJobInformation_Product.Name = "LabelJobInformation_Product"
            Me.LabelJobInformation_Product.Size = New System.Drawing.Size(103, 20)
            Me.LabelJobInformation_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelJobInformation_Product.TabIndex = 4
            Me.LabelJobInformation_Product.Text = "Product:"
            '
            'LabelJobInformation_Client
            '
            Me.LabelJobInformation_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelJobInformation_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelJobInformation_Client.Location = New System.Drawing.Point(4, 4)
            Me.LabelJobInformation_Client.Name = "LabelJobInformation_Client"
            Me.LabelJobInformation_Client.Size = New System.Drawing.Size(103, 20)
            Me.LabelJobInformation_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelJobInformation_Client.TabIndex = 0
            Me.LabelJobInformation_Client.Text = "Client:"
            '
            'LabelJobInformation_Division
            '
            Me.LabelJobInformation_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelJobInformation_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelJobInformation_Division.Location = New System.Drawing.Point(4, 30)
            Me.LabelJobInformation_Division.Name = "LabelJobInformation_Division"
            Me.LabelJobInformation_Division.Size = New System.Drawing.Size(103, 20)
            Me.LabelJobInformation_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelJobInformation_Division.TabIndex = 2
            Me.LabelJobInformation_Division.Text = "Division:"
            '
            'SearchableComboBoxJobInformation_Client
            '
            Me.SearchableComboBoxJobInformation_Client.ActiveFilterString = ""
            Me.SearchableComboBoxJobInformation_Client.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxJobInformation_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxJobInformation_Client.AutoFillMode = False
            Me.SearchableComboBoxJobInformation_Client.BookmarkingEnabled = False
            Me.SearchableComboBoxJobInformation_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Client
            Me.SearchableComboBoxJobInformation_Client.DataSource = Nothing
            Me.SearchableComboBoxJobInformation_Client.DisableMouseWheel = False
            Me.SearchableComboBoxJobInformation_Client.DisplayName = ""
            Me.SearchableComboBoxJobInformation_Client.EnterMoveNextControl = True
            Me.SearchableComboBoxJobInformation_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxJobInformation_Client.Location = New System.Drawing.Point(113, 4)
            Me.SearchableComboBoxJobInformation_Client.Name = "SearchableComboBoxJobInformation_Client"
            Me.SearchableComboBoxJobInformation_Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxJobInformation_Client.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxJobInformation_Client.Properties.NullText = "Select Client"
            Me.SearchableComboBoxJobInformation_Client.Properties.ShowClearButton = False
            Me.SearchableComboBoxJobInformation_Client.Properties.ValueMember = "Code"
            Me.SearchableComboBoxJobInformation_Client.Properties.View = Me.GridView6
            Me.SearchableComboBoxJobInformation_Client.SecurityEnabled = True
            Me.SearchableComboBoxJobInformation_Client.SelectedValue = Nothing
            Me.SearchableComboBoxJobInformation_Client.Size = New System.Drawing.Size(308, 20)
            Me.SearchableComboBoxJobInformation_Client.TabIndex = 1
            '
            'GridView6
            '
            Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView6.Name = "GridView6"
            Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView6.OptionsView.ShowGroupPanel = False
            '
            'TabItemProjectScheduleDetails_JobInformationTab
            '
            Me.TabItemProjectScheduleDetails_JobInformationTab.AttachedControl = Me.TabControlPanelJobInformationTab_JobInformation
            Me.TabItemProjectScheduleDetails_JobInformationTab.Name = "TabItemProjectScheduleDetails_JobInformationTab"
            Me.TabItemProjectScheduleDetails_JobInformationTab.Text = "Job Information"
            '
            'TabControlPanelOtherInformationTab_OtherInformation
            '
            Me.TabControlPanelOtherInformationTab_OtherInformation.Controls.Add(Me.LabelOtherInformation_DateShipped)
            Me.TabControlPanelOtherInformationTab_OtherInformation.Controls.Add(Me.LabelOtherInformation_DateDelivered)
            Me.TabControlPanelOtherInformationTab_OtherInformation.Controls.Add(Me.TextBoxOtherInformation_Reference)
            Me.TabControlPanelOtherInformationTab_OtherInformation.Controls.Add(Me.DateTimePickerOtherInformation_Shipped)
            Me.TabControlPanelOtherInformationTab_OtherInformation.Controls.Add(Me.TextBoxOtherInformation_ReceivedBy)
            Me.TabControlPanelOtherInformationTab_OtherInformation.Controls.Add(Me.DateTimePickerOtherInformation_Delivered)
            Me.TabControlPanelOtherInformationTab_OtherInformation.Controls.Add(Me.LabelOtherInformation_ReceivedBy)
            Me.TabControlPanelOtherInformationTab_OtherInformation.Controls.Add(Me.LabelOtherInformation_Reference)
            Me.TabControlPanelOtherInformationTab_OtherInformation.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOtherInformationTab_OtherInformation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOtherInformationTab_OtherInformation.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOtherInformationTab_OtherInformation.Name = "TabControlPanelOtherInformationTab_OtherInformation"
            Me.TabControlPanelOtherInformationTab_OtherInformation.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOtherInformationTab_OtherInformation.Size = New System.Drawing.Size(679, 162)
            Me.TabControlPanelOtherInformationTab_OtherInformation.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOtherInformationTab_OtherInformation.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOtherInformationTab_OtherInformation.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOtherInformationTab_OtherInformation.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOtherInformationTab_OtherInformation.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOtherInformationTab_OtherInformation.Style.GradientAngle = 90
            Me.TabControlPanelOtherInformationTab_OtherInformation.TabIndex = 6
            Me.TabControlPanelOtherInformationTab_OtherInformation.TabItem = Me.TabItemProjectScheduleDetails_OtherInformationTab
            '
            'LabelOtherInformation_DateShipped
            '
            Me.LabelOtherInformation_DateShipped.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOtherInformation_DateShipped.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOtherInformation_DateShipped.Location = New System.Drawing.Point(4, 4)
            Me.LabelOtherInformation_DateShipped.Name = "LabelOtherInformation_DateShipped"
            Me.LabelOtherInformation_DateShipped.Size = New System.Drawing.Size(87, 20)
            Me.LabelOtherInformation_DateShipped.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOtherInformation_DateShipped.TabIndex = 0
            Me.LabelOtherInformation_DateShipped.Text = "Date Shipped:"
            '
            'LabelOtherInformation_DateDelivered
            '
            Me.LabelOtherInformation_DateDelivered.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOtherInformation_DateDelivered.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOtherInformation_DateDelivered.Location = New System.Drawing.Point(4, 30)
            Me.LabelOtherInformation_DateDelivered.Name = "LabelOtherInformation_DateDelivered"
            Me.LabelOtherInformation_DateDelivered.Size = New System.Drawing.Size(87, 20)
            Me.LabelOtherInformation_DateDelivered.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOtherInformation_DateDelivered.TabIndex = 2
            Me.LabelOtherInformation_DateDelivered.Text = "Date Delivered:"
            '
            'TextBoxOtherInformation_Reference
            '
            Me.TextBoxOtherInformation_Reference.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxOtherInformation_Reference.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxOtherInformation_Reference.Border.Class = "TextBoxBorder"
            Me.TextBoxOtherInformation_Reference.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxOtherInformation_Reference.CheckSpellingOnValidate = False
            Me.TextBoxOtherInformation_Reference.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxOtherInformation_Reference.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxOtherInformation_Reference.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxOtherInformation_Reference.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxOtherInformation_Reference.FocusHighlightEnabled = True
            Me.TextBoxOtherInformation_Reference.ForeColor = System.Drawing.Color.Black
            Me.TextBoxOtherInformation_Reference.Location = New System.Drawing.Point(97, 82)
            Me.TextBoxOtherInformation_Reference.MaxFileSize = CType(0, Long)
            Me.TextBoxOtherInformation_Reference.Name = "TextBoxOtherInformation_Reference"
            Me.TextBoxOtherInformation_Reference.SecurityEnabled = True
            Me.TextBoxOtherInformation_Reference.ShowSpellCheckCompleteMessage = True
            Me.TextBoxOtherInformation_Reference.Size = New System.Drawing.Size(578, 20)
            Me.TextBoxOtherInformation_Reference.StartingFolderName = Nothing
            Me.TextBoxOtherInformation_Reference.TabIndex = 7
            Me.TextBoxOtherInformation_Reference.TabOnEnter = True
            '
            'DateTimePickerOtherInformation_Shipped
            '
            Me.DateTimePickerOtherInformation_Shipped.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerOtherInformation_Shipped.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerOtherInformation_Shipped.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOtherInformation_Shipped.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerOtherInformation_Shipped.ButtonDropDown.Visible = True
            Me.DateTimePickerOtherInformation_Shipped.ButtonFreeText.Checked = True
            Me.DateTimePickerOtherInformation_Shipped.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerOtherInformation_Shipped.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerOtherInformation_Shipped.DisplayName = ""
            Me.DateTimePickerOtherInformation_Shipped.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerOtherInformation_Shipped.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerOtherInformation_Shipped.FocusHighlightEnabled = True
            Me.DateTimePickerOtherInformation_Shipped.FreeTextEntryMode = True
            Me.DateTimePickerOtherInformation_Shipped.IsPopupCalendarOpen = False
            Me.DateTimePickerOtherInformation_Shipped.Location = New System.Drawing.Point(97, 4)
            Me.DateTimePickerOtherInformation_Shipped.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerOtherInformation_Shipped.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerOtherInformation_Shipped.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOtherInformation_Shipped.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerOtherInformation_Shipped.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerOtherInformation_Shipped.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerOtherInformation_Shipped.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerOtherInformation_Shipped.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerOtherInformation_Shipped.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerOtherInformation_Shipped.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerOtherInformation_Shipped.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerOtherInformation_Shipped.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOtherInformation_Shipped.MonthCalendar.DisplayMonth = New Date(2013, 10, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerOtherInformation_Shipped.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerOtherInformation_Shipped.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerOtherInformation_Shipped.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerOtherInformation_Shipped.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOtherInformation_Shipped.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerOtherInformation_Shipped.Name = "DateTimePickerOtherInformation_Shipped"
            Me.DateTimePickerOtherInformation_Shipped.ReadOnly = False
            Me.DateTimePickerOtherInformation_Shipped.Size = New System.Drawing.Size(90, 20)
            Me.DateTimePickerOtherInformation_Shipped.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerOtherInformation_Shipped.TabIndex = 1
            Me.DateTimePickerOtherInformation_Shipped.TabOnEnter = True
            Me.DateTimePickerOtherInformation_Shipped.Value = New Date(2013, 11, 27, 14, 22, 27, 761)
            '
            'TextBoxOtherInformation_ReceivedBy
            '
            Me.TextBoxOtherInformation_ReceivedBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxOtherInformation_ReceivedBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxOtherInformation_ReceivedBy.Border.Class = "TextBoxBorder"
            Me.TextBoxOtherInformation_ReceivedBy.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxOtherInformation_ReceivedBy.CheckSpellingOnValidate = False
            Me.TextBoxOtherInformation_ReceivedBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxOtherInformation_ReceivedBy.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxOtherInformation_ReceivedBy.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxOtherInformation_ReceivedBy.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxOtherInformation_ReceivedBy.FocusHighlightEnabled = True
            Me.TextBoxOtherInformation_ReceivedBy.ForeColor = System.Drawing.Color.Black
            Me.TextBoxOtherInformation_ReceivedBy.Location = New System.Drawing.Point(97, 56)
            Me.TextBoxOtherInformation_ReceivedBy.MaxFileSize = CType(0, Long)
            Me.TextBoxOtherInformation_ReceivedBy.Name = "TextBoxOtherInformation_ReceivedBy"
            Me.TextBoxOtherInformation_ReceivedBy.SecurityEnabled = True
            Me.TextBoxOtherInformation_ReceivedBy.ShowSpellCheckCompleteMessage = True
            Me.TextBoxOtherInformation_ReceivedBy.Size = New System.Drawing.Size(578, 20)
            Me.TextBoxOtherInformation_ReceivedBy.StartingFolderName = Nothing
            Me.TextBoxOtherInformation_ReceivedBy.TabIndex = 5
            Me.TextBoxOtherInformation_ReceivedBy.TabOnEnter = True
            '
            'DateTimePickerOtherInformation_Delivered
            '
            Me.DateTimePickerOtherInformation_Delivered.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerOtherInformation_Delivered.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerOtherInformation_Delivered.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOtherInformation_Delivered.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerOtherInformation_Delivered.ButtonDropDown.Visible = True
            Me.DateTimePickerOtherInformation_Delivered.ButtonFreeText.Checked = True
            Me.DateTimePickerOtherInformation_Delivered.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerOtherInformation_Delivered.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerOtherInformation_Delivered.DisplayName = ""
            Me.DateTimePickerOtherInformation_Delivered.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerOtherInformation_Delivered.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerOtherInformation_Delivered.FocusHighlightEnabled = True
            Me.DateTimePickerOtherInformation_Delivered.FreeTextEntryMode = True
            Me.DateTimePickerOtherInformation_Delivered.IsPopupCalendarOpen = False
            Me.DateTimePickerOtherInformation_Delivered.Location = New System.Drawing.Point(97, 30)
            Me.DateTimePickerOtherInformation_Delivered.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerOtherInformation_Delivered.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerOtherInformation_Delivered.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOtherInformation_Delivered.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerOtherInformation_Delivered.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerOtherInformation_Delivered.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerOtherInformation_Delivered.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerOtherInformation_Delivered.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerOtherInformation_Delivered.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerOtherInformation_Delivered.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerOtherInformation_Delivered.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerOtherInformation_Delivered.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOtherInformation_Delivered.MonthCalendar.DisplayMonth = New Date(2013, 10, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerOtherInformation_Delivered.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerOtherInformation_Delivered.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerOtherInformation_Delivered.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerOtherInformation_Delivered.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOtherInformation_Delivered.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerOtherInformation_Delivered.Name = "DateTimePickerOtherInformation_Delivered"
            Me.DateTimePickerOtherInformation_Delivered.ReadOnly = False
            Me.DateTimePickerOtherInformation_Delivered.Size = New System.Drawing.Size(90, 20)
            Me.DateTimePickerOtherInformation_Delivered.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerOtherInformation_Delivered.TabIndex = 3
            Me.DateTimePickerOtherInformation_Delivered.TabOnEnter = True
            Me.DateTimePickerOtherInformation_Delivered.Value = New Date(2013, 11, 27, 14, 22, 27, 742)
            '
            'LabelOtherInformation_ReceivedBy
            '
            Me.LabelOtherInformation_ReceivedBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOtherInformation_ReceivedBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOtherInformation_ReceivedBy.Location = New System.Drawing.Point(4, 56)
            Me.LabelOtherInformation_ReceivedBy.Name = "LabelOtherInformation_ReceivedBy"
            Me.LabelOtherInformation_ReceivedBy.Size = New System.Drawing.Size(87, 20)
            Me.LabelOtherInformation_ReceivedBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOtherInformation_ReceivedBy.TabIndex = 4
            Me.LabelOtherInformation_ReceivedBy.Text = "Received By:"
            '
            'LabelOtherInformation_Reference
            '
            Me.LabelOtherInformation_Reference.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOtherInformation_Reference.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOtherInformation_Reference.Location = New System.Drawing.Point(4, 82)
            Me.LabelOtherInformation_Reference.Name = "LabelOtherInformation_Reference"
            Me.LabelOtherInformation_Reference.Size = New System.Drawing.Size(87, 20)
            Me.LabelOtherInformation_Reference.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOtherInformation_Reference.TabIndex = 6
            Me.LabelOtherInformation_Reference.Text = "Reference:"
            '
            'TabItemProjectScheduleDetails_OtherInformationTab
            '
            Me.TabItemProjectScheduleDetails_OtherInformationTab.AttachedControl = Me.TabControlPanelOtherInformationTab_OtherInformation
            Me.TabItemProjectScheduleDetails_OtherInformationTab.Name = "TabItemProjectScheduleDetails_OtherInformationTab"
            Me.TabItemProjectScheduleDetails_OtherInformationTab.Text = "Other Information"
            '
            'TabControlPanelCommentsTab_Comments
            '
            Me.TabControlPanelCommentsTab_Comments.Controls.Add(Me.TextBoxComments_Comments)
            Me.TabControlPanelCommentsTab_Comments.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCommentsTab_Comments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCommentsTab_Comments.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCommentsTab_Comments.Name = "TabControlPanelCommentsTab_Comments"
            Me.TabControlPanelCommentsTab_Comments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCommentsTab_Comments.Size = New System.Drawing.Size(679, 162)
            Me.TabControlPanelCommentsTab_Comments.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCommentsTab_Comments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCommentsTab_Comments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCommentsTab_Comments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCommentsTab_Comments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCommentsTab_Comments.Style.GradientAngle = 90
            Me.TabControlPanelCommentsTab_Comments.TabIndex = 3
            Me.TabControlPanelCommentsTab_Comments.TabItem = Me.TabItemProjectScheduleDetails_CommentsTab
            '
            'TextBoxComments_Comments
            '
            Me.TextBoxComments_Comments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxComments_Comments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxComments_Comments.Border.Class = "TextBoxBorder"
            Me.TextBoxComments_Comments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxComments_Comments.CheckSpellingOnValidate = False
            Me.TextBoxComments_Comments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxComments_Comments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxComments_Comments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxComments_Comments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxComments_Comments.FocusHighlightEnabled = True
            Me.TextBoxComments_Comments.ForeColor = System.Drawing.Color.Black
            Me.TextBoxComments_Comments.Location = New System.Drawing.Point(4, 4)
            Me.TextBoxComments_Comments.MaxFileSize = CType(0, Long)
            Me.TextBoxComments_Comments.Multiline = True
            Me.TextBoxComments_Comments.Name = "TextBoxComments_Comments"
            Me.TextBoxComments_Comments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxComments_Comments.SecurityEnabled = True
            Me.TextBoxComments_Comments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxComments_Comments.Size = New System.Drawing.Size(671, 154)
            Me.TextBoxComments_Comments.StartingFolderName = Nothing
            Me.TextBoxComments_Comments.TabIndex = 0
            Me.TextBoxComments_Comments.TabOnEnter = False
            '
            'TabItemProjectScheduleDetails_CommentsTab
            '
            Me.TabItemProjectScheduleDetails_CommentsTab.AttachedControl = Me.TabControlPanelCommentsTab_Comments
            Me.TabItemProjectScheduleDetails_CommentsTab.Name = "TabItemProjectScheduleDetails_CommentsTab"
            Me.TabItemProjectScheduleDetails_CommentsTab.Text = "Comments"
            '
            'ToolTipControllerControl_ToolTips
            '
            '
            'DataGridViewControl_Details
            '
            Me.DataGridViewControl_Details.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewControl_Details.AllowDragAndDrop = False
            Me.DataGridViewControl_Details.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewControl_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewControl_Details.AutoFilterLookupColumns = False
            Me.DataGridViewControl_Details.AutoloadRepositoryDatasource = True
            Me.DataGridViewControl_Details.AutoUpdateViewCaption = True
            Me.DataGridViewControl_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewControl_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewControl_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewControl_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_Details.ItemDescription = "Item(s)"
            Me.DataGridViewControl_Details.Location = New System.Drawing.Point(0, 226)
            Me.DataGridViewControl_Details.MultiSelect = True
            Me.DataGridViewControl_Details.Name = "DataGridViewControl_Details"
            Me.DataGridViewControl_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewControl_Details.RunStandardValidation = True
            Me.DataGridViewControl_Details.ShowColumnMenuOnRightClick = False
            Me.DataGridViewControl_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_Details.Size = New System.Drawing.Size(685, 282)
            Me.DataGridViewControl_Details.TabIndex = 5
            Me.DataGridViewControl_Details.UseEmbeddedNavigator = False
            Me.DataGridViewControl_Details.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlControl_TopBottom
            '
            Me.ExpandableSplitterControlControl_TopBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlControl_TopBottom.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlControl_TopBottom.Dock = System.Windows.Forms.DockStyle.Top
            Me.ExpandableSplitterControlControl_TopBottom.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlControl_TopBottom.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlControl_TopBottom.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlControl_TopBottom.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlControl_TopBottom.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlControl_TopBottom.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlControl_TopBottom.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlControl_TopBottom.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlControl_TopBottom.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlControl_TopBottom.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlControl_TopBottom.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlControl_TopBottom.Location = New System.Drawing.Point(0, 220)
            Me.ExpandableSplitterControlControl_TopBottom.Name = "ExpandableSplitterControlControl_TopBottom"
            Me.ExpandableSplitterControlControl_TopBottom.Size = New System.Drawing.Size(685, 6)
            Me.ExpandableSplitterControlControl_TopBottom.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlControl_TopBottom.TabIndex = 4
            Me.ExpandableSplitterControlControl_TopBottom.TabStop = False
            '
            'NumericInputTaskDetails_GutComplete
            '
            Me.NumericInputTaskDetails_GutComplete.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTaskDetails_GutComplete.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTaskDetails_GutComplete.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTaskDetails_GutComplete.EnterMoveNextControl = True
            Me.NumericInputTaskDetails_GutComplete.Location = New System.Drawing.Point(108, 82)
            Me.NumericInputTaskDetails_GutComplete.Name = "NumericInputTaskDetails_GutComplete"
            Me.NumericInputTaskDetails_GutComplete.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputTaskDetails_GutComplete.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputTaskDetails_GutComplete.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTaskDetails_GutComplete.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputTaskDetails_GutComplete.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputTaskDetails_GutComplete.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTaskDetails_GutComplete.Properties.EditFormat.FormatString = "f"
            Me.NumericInputTaskDetails_GutComplete.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTaskDetails_GutComplete.Properties.Mask.EditMask = "f"
            Me.NumericInputTaskDetails_GutComplete.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTaskDetails_GutComplete.SecurityEnabled = True
            Me.NumericInputTaskDetails_GutComplete.Size = New System.Drawing.Size(90, 20)
            Me.NumericInputTaskDetails_GutComplete.TabIndex = 9
            '
            'ProjectScheduleControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.DataGridViewControl_Details)
            Me.Controls.Add(Me.ExpandableSplitterControlControl_TopBottom)
            Me.Controls.Add(Me.ExpandablePanelControl_General)
            Me.Name = "ProjectScheduleControl"
            Me.Size = New System.Drawing.Size(685, 508)
            Me.ExpandablePanelControl_General.ResumeLayout(False)
            CType(Me.TabControlControl_ProjectScheduleDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_ProjectScheduleDetails.ResumeLayout(False)
            Me.TabControlPanelTaskDetailsTab_TaskDetails.ResumeLayout(False)
            CType(Me.DateTimePickerTaskDetails_StartDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTaskDetails_TrafficStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerTaskDetails_DueDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerTaskDetails_CompletedDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelRelatedJobsTab_RelatedJobs.ResumeLayout(False)
            CType(Me.TabControlRelatedJobs_RelatedJobs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlRelatedJobs_RelatedJobs.ResumeLayout(False)
            Me.TabControlPanelJobsThatPrecedeTab_JobsThatPrecede.ResumeLayout(False)
            CType(Me.PanelJobsThatPrecede_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelJobsThatPrecede_RightSection.ResumeLayout(False)
            CType(Me.PanelJobsThatPrecede_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelJobsThatPrecede_LeftSection.ResumeLayout(False)
            Me.TabControlPanelJobsThatFollowTab_JobsThatFollow.ResumeLayout(False)
            Me.TabControlPanelAssignmentsTab_Assignments.ResumeLayout(False)
            Me.TabControlPanelJobInformationTab_JobInformation.ResumeLayout(False)
            CType(Me.SearchableComboBoxJobInformation_AccountExecutive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxJobInformation_Component.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView13, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxJobInformation_Job.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView14, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxJobInformation_Product.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView11, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxJobInformation_Division.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView10, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxJobInformation_Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelOtherInformationTab_OtherInformation.ResumeLayout(False)
            CType(Me.DateTimePickerOtherInformation_Shipped, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerOtherInformation_Delivered, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelCommentsTab_Comments.ResumeLayout(False)
            CType(Me.NumericInputTaskDetails_GutComplete.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelTaskDetails_StartDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlControl_ProjectScheduleDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelAssignmentsTab_Assignments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemProjectScheduleDetails_AssignmentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelTaskDetailsTab_TaskDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TextBoxComments_Comments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabItemProjectScheduleDetails_TaskDetailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCommentsTab_Comments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemProjectScheduleDetails_CommentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelOtherInformation_Reference As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerOtherInformation_Delivered As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerOtherInformation_Shipped As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerTaskDetails_CompletedDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerTaskDetails_DueDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerTaskDetails_StartDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelOtherInformation_ReceivedBy As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelOtherInformation_DateDelivered As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelOtherInformation_DateShipped As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTaskDetails_CompletedDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTaskDetails_Traffic As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTaskDetails_DueDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxOtherInformation_Reference As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxOtherInformation_ReceivedBy As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents SearchableComboBoxJobInformation_Client As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents SearchableComboBoxTaskDetails_TrafficStatus As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents RadioButtonControlTaskDetails_DueDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlTaskDetails_StartDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabControlPanelRelatedJobsTab_RelatedJobs As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemProjectScheduleDetails_RelatedJobsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelJobInformationTab_JobInformation As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemProjectScheduleDetails_JobInformationTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents SearchableComboBoxJobInformation_Component As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView13 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents SearchableComboBoxJobInformation_Job As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView14 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents SearchableComboBoxJobInformation_Product As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView11 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents SearchableComboBoxJobInformation_Division As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView10 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents LabelJobInformation_Component As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelJobInformation_Job As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelJobInformation_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelJobInformation_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelJobInformation_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlPanelOtherInformationTab_OtherInformation As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemProjectScheduleDetails_OtherInformationTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ExpandablePanelControl_General As DevComponents.DotNetBar.ExpandablePanel
        Friend WithEvents ExpandableSplitterControlControl_TopBottom As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents DataGridViewControl_Details As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents SearchableComboBoxJobInformation_AccountExecutive As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents LabelJobInformation_AccountExecutive As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlRelatedJobs_RelatedJobs As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelJobsThatPrecedeTab_JobsThatPrecede As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemRelatedJobs_JobsThatPrecede As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelJobsThatFollowTab_JobsThatFollow As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemRelatedJobs_JobsThatFollowTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelJobsThatPrecede_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewJobsThatPrecede_Jobs As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControlJobsThatPrecede_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelJobsThatPrecede_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewJobsThatPrecede_AvailableJobs As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewJobsThatFollow_Jobs As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonRightSection_RemoveJob As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddJob As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewAssignments_Assignments As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ToolTipControllerControl_ToolTips As DevExpress.Utils.ToolTipController
        Friend WithEvents LabelTaskDetails_GutComplete As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputTaskDetails_GutComplete As NumericInput
    End Class

End Namespace
