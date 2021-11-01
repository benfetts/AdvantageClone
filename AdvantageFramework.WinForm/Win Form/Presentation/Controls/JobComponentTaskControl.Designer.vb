Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class JobComponentTaskControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobComponentTaskControl))
            Me.ExpandablePanelControl_General = New DevComponents.DotNetBar.ExpandablePanel()
            Me.TabControlControl_TaskDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelCommentsTab_Comments = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxCommentLog_Comments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemTaskDetails_CommentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelClientContactsTab_ClientContacts = New DevComponents.DotNetBar.TabControlPanel()
            Me.MultiSelectControlClientContacts_ClientContacts = New AdvantageFramework.WinForm.Presentation.Controls.MultiSelectControl()
            Me.TabItemTaskDetails_ClientContactsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelEmployeesTab_Employees = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemTaskDetails_EmployeesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSettingsTab_Settings = New DevComponents.DotNetBar.TabControlPanel()
            Me.NumericInputSettings_DefaultHoursAllowed = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputSettings_DaysDuration = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputSettings_Order = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxSettings_Milestone = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxSettings_Locked = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DateTimePickerSettings_OriginalDueDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.SearchableComboBoxSettings_EstimateFunction = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView3 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelSettings_Locked = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_OriginalDueDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_EstimateFunction = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_Milestone = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_DefaultHoursAllowed = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_Days = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_Order = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemTaskDetails_SettingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDetailsTab_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.DateTimePickerDetails_TempComplete = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.TextBoxDetails_TaskDescription = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabControlDetails_Comments = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelTaskCommentsTab_TaskComments = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxTaskComments_Comments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemDetails_TaskCommentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDueDateCommentsTab_DueDateComments = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxDueDateComments_Comments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemDetails_DueDateCommentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxRevisedDueDateComments_Comments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemDetails_RevisedDueDateCommentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TextBoxDetails_TimeDue = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.DateTimePickerDetails_CompletedDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerDetails_DueDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerDetails_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.SearchableComboBoxDetails_TaskStatus = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxDetails_Task = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxDetails_Phase = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBox1View = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelDetails_CompletedDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDetails_TimeDue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDetails_TempComplete = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDetails_DueDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDetails_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDetails_TaskStatus = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDetails_Task = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDetails_Phase = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemTaskDetails_DetailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TextBoxGeneralInfo_Comments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.DateTimePickerGeneralInfo_JobDueDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerGeneralInfo_JobStartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.SearchableComboBoxGeneralInfo_JobStatus = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView11 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGeneralInfo_Component = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView8 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGeneralInfo_AccountExecutive = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView9 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGeneralInfo_Job = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView4 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGeneralInfo_Product = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView7 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelGeneralInfo_JobStatus = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInfo_Comments = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInfo_AccountExecutive = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInfo_JobStartDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInfo_JobDueDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInfo_Job = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInfo_Component = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxGeneralInfo_Division = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView5 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGeneralInfo_Client = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView6 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelGeneralInfo_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInfo_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInfo_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewEmployees_Employees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandablePanelControl_General.SuspendLayout()
            CType(Me.TabControlControl_TaskDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_TaskDetails.SuspendLayout()
            Me.TabControlPanelCommentsTab_Comments.SuspendLayout()
            Me.TabControlPanelClientContactsTab_ClientContacts.SuspendLayout()
            Me.TabControlPanelEmployeesTab_Employees.SuspendLayout()
            Me.TabControlPanelSettingsTab_Settings.SuspendLayout()
            CType(Me.NumericInputSettings_DefaultHoursAllowed.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputSettings_DaysDuration.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputSettings_Order.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerSettings_OriginalDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSettings_EstimateFunction.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelDetailsTab_Details.SuspendLayout()
            CType(Me.DateTimePickerDetails_TempComplete, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlDetails_Comments, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlDetails_Comments.SuspendLayout()
            Me.TabControlPanelTaskCommentsTab_TaskComments.SuspendLayout()
            Me.TabControlPanelDueDateCommentsTab_DueDateComments.SuspendLayout()
            Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments.SuspendLayout()
            CType(Me.DateTimePickerDetails_CompletedDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerDetails_DueDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerDetails_StartDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxDetails_TaskStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxDetails_Task.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxDetails_Phase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerGeneralInfo_JobDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerGeneralInfo_JobStartDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneralInfo_JobStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView11, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneralInfo_Component.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneralInfo_AccountExecutive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView9, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneralInfo_Job.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneralInfo_Product.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneralInfo_Division.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneralInfo_Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ExpandablePanelControl_General
            '
            Me.ExpandablePanelControl_General.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.ExpandablePanelControl_General.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ExpandablePanelControl_General.Controls.Add(Me.TextBoxGeneralInfo_Comments)
            Me.ExpandablePanelControl_General.Controls.Add(Me.DateTimePickerGeneralInfo_JobDueDate)
            Me.ExpandablePanelControl_General.Controls.Add(Me.DateTimePickerGeneralInfo_JobStartDate)
            Me.ExpandablePanelControl_General.Controls.Add(Me.SearchableComboBoxGeneralInfo_JobStatus)
            Me.ExpandablePanelControl_General.Controls.Add(Me.SearchableComboBoxGeneralInfo_Component)
            Me.ExpandablePanelControl_General.Controls.Add(Me.SearchableComboBoxGeneralInfo_AccountExecutive)
            Me.ExpandablePanelControl_General.Controls.Add(Me.SearchableComboBoxGeneralInfo_Job)
            Me.ExpandablePanelControl_General.Controls.Add(Me.SearchableComboBoxGeneralInfo_Product)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelGeneralInfo_JobStatus)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelGeneralInfo_Comments)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelGeneralInfo_AccountExecutive)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelGeneralInfo_JobStartDate)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelGeneralInfo_JobDueDate)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelGeneralInfo_Job)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelGeneralInfo_Component)
            Me.ExpandablePanelControl_General.Controls.Add(Me.SearchableComboBoxGeneralInfo_Division)
            Me.ExpandablePanelControl_General.Controls.Add(Me.SearchableComboBoxGeneralInfo_Client)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelGeneralInfo_Client)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelGeneralInfo_Division)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelGeneralInfo_Product)
            Me.ExpandablePanelControl_General.Dock = System.Windows.Forms.DockStyle.Top
            Me.ExpandablePanelControl_General.HideControlsWhenCollapsed = True
            Me.ExpandablePanelControl_General.Location = New System.Drawing.Point(0, 0)
            Me.ExpandablePanelControl_General.Name = "ExpandablePanelControl_General"
            Me.ExpandablePanelControl_General.Size = New System.Drawing.Size(769, 160)
            Me.ExpandablePanelControl_General.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.ExpandablePanelControl_General.Style.BackColor1.Color = System.Drawing.Color.White
            Me.ExpandablePanelControl_General.Style.BackColor2.Color = System.Drawing.Color.White
            Me.ExpandablePanelControl_General.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.ExpandablePanelControl_General.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.ExpandablePanelControl_General.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandablePanelControl_General.Style.GradientAngle = 90
            Me.ExpandablePanelControl_General.TabIndex = 2
            Me.ExpandablePanelControl_General.TextDockConstrained = False
            Me.ExpandablePanelControl_General.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
            Me.ExpandablePanelControl_General.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandablePanelControl_General.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
            Me.ExpandablePanelControl_General.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandablePanelControl_General.TitleStyle.ForeColor.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.ExpandablePanelControl_General.TitleStyle.GradientAngle = 90
            Me.ExpandablePanelControl_General.TitleText = "General Info"
            '
            'TabControlControl_TaskDetails
            '
            Me.TabControlControl_TaskDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlControl_TaskDetails.CanReorderTabs = True
            Me.TabControlControl_TaskDetails.Controls.Add(Me.TabControlPanelEmployeesTab_Employees)
            Me.TabControlControl_TaskDetails.Controls.Add(Me.TabControlPanelDetailsTab_Details)
            Me.TabControlControl_TaskDetails.Controls.Add(Me.TabControlPanelSettingsTab_Settings)
            Me.TabControlControl_TaskDetails.Controls.Add(Me.TabControlPanelClientContactsTab_ClientContacts)
            Me.TabControlControl_TaskDetails.Controls.Add(Me.TabControlPanelCommentsTab_Comments)
            Me.TabControlControl_TaskDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_TaskDetails.ForeColor = System.Drawing.Color.Black
            Me.TabControlControl_TaskDetails.Location = New System.Drawing.Point(0, 160)
            Me.TabControlControl_TaskDetails.Name = "TabControlControl_TaskDetails"
            Me.TabControlControl_TaskDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_TaskDetails.SelectedTabIndex = 0
            Me.TabControlControl_TaskDetails.Size = New System.Drawing.Size(769, 400)
            Me.TabControlControl_TaskDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_TaskDetails.TabIndex = 1
            Me.TabControlControl_TaskDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_TaskDetails.Tabs.Add(Me.TabItemTaskDetails_DetailsTab)
            Me.TabControlControl_TaskDetails.Tabs.Add(Me.TabItemTaskDetails_SettingsTab)
            Me.TabControlControl_TaskDetails.Tabs.Add(Me.TabItemTaskDetails_EmployeesTab)
            Me.TabControlControl_TaskDetails.Tabs.Add(Me.TabItemTaskDetails_ClientContactsTab)
            Me.TabControlControl_TaskDetails.Tabs.Add(Me.TabItemTaskDetails_CommentsTab)
            Me.TabControlControl_TaskDetails.Text = "TabControl1"
            '
            'TabControlPanelCommentsTab_Comments
            '
            Me.TabControlPanelCommentsTab_Comments.Controls.Add(Me.TextBoxCommentLog_Comments)
            Me.TabControlPanelCommentsTab_Comments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCommentsTab_Comments.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCommentsTab_Comments.Name = "TabControlPanelCommentsTab_Comments"
            Me.TabControlPanelCommentsTab_Comments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCommentsTab_Comments.Size = New System.Drawing.Size(769, 373)
            Me.TabControlPanelCommentsTab_Comments.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCommentsTab_Comments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCommentsTab_Comments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCommentsTab_Comments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCommentsTab_Comments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCommentsTab_Comments.Style.GradientAngle = 90
            Me.TabControlPanelCommentsTab_Comments.TabIndex = 3
            Me.TabControlPanelCommentsTab_Comments.TabItem = Me.TabItemTaskDetails_CommentsTab
            '
            'TextBoxCommentLog_Comments
            '
            Me.TextBoxCommentLog_Comments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxCommentLog_Comments.Border.Class = "TextBoxBorder"
            Me.TextBoxCommentLog_Comments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxCommentLog_Comments.CheckSpellingOnValidate = False
            Me.TextBoxCommentLog_Comments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxCommentLog_Comments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxCommentLog_Comments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxCommentLog_Comments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxCommentLog_Comments.FocusHighlightEnabled = True
            Me.TextBoxCommentLog_Comments.Location = New System.Drawing.Point(4, 4)
            Me.TextBoxCommentLog_Comments.MaxFileSize = CType(0, Long)
            Me.TextBoxCommentLog_Comments.Multiline = True
            Me.TextBoxCommentLog_Comments.Name = "TextBoxCommentLog_Comments"
            Me.TextBoxCommentLog_Comments.PreventEnterBeep = False
            Me.TextBoxCommentLog_Comments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxCommentLog_Comments.Size = New System.Drawing.Size(761, 365)
            Me.TextBoxCommentLog_Comments.StartingFolderName = Nothing
            Me.TextBoxCommentLog_Comments.TabIndex = 0
            Me.TextBoxCommentLog_Comments.TabOnEnter = True
            '
            'TabItemTaskDetails_CommentsTab
            '
            Me.TabItemTaskDetails_CommentsTab.AttachedControl = Me.TabControlPanelCommentsTab_Comments
            Me.TabItemTaskDetails_CommentsTab.Name = "TabItemTaskDetails_CommentsTab"
            Me.TabItemTaskDetails_CommentsTab.Text = "Comments"
            '
            'TabControlPanelClientContactsTab_ClientContacts
            '
            Me.TabControlPanelClientContactsTab_ClientContacts.Controls.Add(Me.MultiSelectControlClientContacts_ClientContacts)
            Me.TabControlPanelClientContactsTab_ClientContacts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelClientContactsTab_ClientContacts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelClientContactsTab_ClientContacts.Name = "TabControlPanelClientContactsTab_ClientContacts"
            Me.TabControlPanelClientContactsTab_ClientContacts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelClientContactsTab_ClientContacts.Size = New System.Drawing.Size(769, 373)
            Me.TabControlPanelClientContactsTab_ClientContacts.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelClientContactsTab_ClientContacts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelClientContactsTab_ClientContacts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelClientContactsTab_ClientContacts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelClientContactsTab_ClientContacts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelClientContactsTab_ClientContacts.Style.GradientAngle = 90
            Me.TabControlPanelClientContactsTab_ClientContacts.TabIndex = 4
            Me.TabControlPanelClientContactsTab_ClientContacts.TabItem = Me.TabItemTaskDetails_ClientContactsTab
            '
            'MultiSelectControlClientContacts_ClientContacts
            '
            Me.MultiSelectControlClientContacts_ClientContacts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.MultiSelectControlClientContacts_ClientContacts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.MultiSelectControl.Type.ClientContact
            Me.MultiSelectControlClientContacts_ClientContacts.Location = New System.Drawing.Point(4, 4)
            Me.MultiSelectControlClientContacts_ClientContacts.Name = "MultiSelectControlClientContacts_ClientContacts"
            Me.MultiSelectControlClientContacts_ClientContacts.Session = Nothing
            Me.MultiSelectControlClientContacts_ClientContacts.Size = New System.Drawing.Size(761, 365)
            Me.MultiSelectControlClientContacts_ClientContacts.TabIndex = 0
            Me.MultiSelectControlClientContacts_ClientContacts.ValueMemberColumn = Nothing
            '
            'TabItemTaskDetails_ClientContactsTab
            '
            Me.TabItemTaskDetails_ClientContactsTab.AttachedControl = Me.TabControlPanelClientContactsTab_ClientContacts
            Me.TabItemTaskDetails_ClientContactsTab.Name = "TabItemTaskDetails_ClientContactsTab"
            Me.TabItemTaskDetails_ClientContactsTab.Text = "Client Contacts"
            '
            'TabControlPanelEmployeesTab_Employees
            '
            Me.TabControlPanelEmployeesTab_Employees.Controls.Add(Me.DataGridViewEmployees_Employees)
            Me.TabControlPanelEmployeesTab_Employees.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEmployeesTab_Employees.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEmployeesTab_Employees.Name = "TabControlPanelEmployeesTab_Employees"
            Me.TabControlPanelEmployeesTab_Employees.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEmployeesTab_Employees.Size = New System.Drawing.Size(769, 373)
            Me.TabControlPanelEmployeesTab_Employees.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEmployeesTab_Employees.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEmployeesTab_Employees.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEmployeesTab_Employees.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEmployeesTab_Employees.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEmployeesTab_Employees.Style.GradientAngle = 90
            Me.TabControlPanelEmployeesTab_Employees.TabIndex = 2
            Me.TabControlPanelEmployeesTab_Employees.TabItem = Me.TabItemTaskDetails_EmployeesTab
            '
            'TabItemTaskDetails_EmployeesTab
            '
            Me.TabItemTaskDetails_EmployeesTab.AttachedControl = Me.TabControlPanelEmployeesTab_Employees
            Me.TabItemTaskDetails_EmployeesTab.Name = "TabItemTaskDetails_EmployeesTab"
            Me.TabItemTaskDetails_EmployeesTab.Text = "Employees"
            '
            'TabControlPanelSettingsTab_Settings
            '
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.NumericInputSettings_DefaultHoursAllowed)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.NumericInputSettings_DaysDuration)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.NumericInputSettings_Order)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.CheckBoxSettings_Milestone)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.CheckBoxSettings_Locked)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.DateTimePickerSettings_OriginalDueDate)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.SearchableComboBoxSettings_EstimateFunction)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_Locked)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_OriginalDueDate)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_EstimateFunction)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_Milestone)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_DefaultHoursAllowed)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_Days)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_Order)
            Me.TabControlPanelSettingsTab_Settings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSettingsTab_Settings.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSettingsTab_Settings.Name = "TabControlPanelSettingsTab_Settings"
            Me.TabControlPanelSettingsTab_Settings.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSettingsTab_Settings.Size = New System.Drawing.Size(769, 373)
            Me.TabControlPanelSettingsTab_Settings.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSettingsTab_Settings.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSettingsTab_Settings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSettingsTab_Settings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSettingsTab_Settings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSettingsTab_Settings.Style.GradientAngle = 90
            Me.TabControlPanelSettingsTab_Settings.TabIndex = 1
            Me.TabControlPanelSettingsTab_Settings.TabItem = Me.TabItemTaskDetails_SettingsTab
            '
            'NumericInputSettings_DefaultHoursAllowed
            '
            Me.NumericInputSettings_DefaultHoursAllowed.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputSettings_DefaultHoursAllowed.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputSettings_DefaultHoursAllowed.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputSettings_DefaultHoursAllowed.Location = New System.Drawing.Point(135, 56)
            Me.NumericInputSettings_DefaultHoursAllowed.Name = "NumericInputSettings_DefaultHoursAllowed"
            Me.NumericInputSettings_DefaultHoursAllowed.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputSettings_DefaultHoursAllowed.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputSettings_DefaultHoursAllowed.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSettings_DefaultHoursAllowed.Properties.EditFormat.FormatString = "f"
            Me.NumericInputSettings_DefaultHoursAllowed.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSettings_DefaultHoursAllowed.Properties.Mask.EditMask = "f"
            Me.NumericInputSettings_DefaultHoursAllowed.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputSettings_DefaultHoursAllowed.Size = New System.Drawing.Size(48, 20)
            Me.NumericInputSettings_DefaultHoursAllowed.TabIndex = 21
            '
            'NumericInputSettings_DaysDuration
            '
            Me.NumericInputSettings_DaysDuration.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputSettings_DaysDuration.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputSettings_DaysDuration.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputSettings_DaysDuration.Location = New System.Drawing.Point(135, 30)
            Me.NumericInputSettings_DaysDuration.Name = "NumericInputSettings_DaysDuration"
            Me.NumericInputSettings_DaysDuration.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputSettings_DaysDuration.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputSettings_DaysDuration.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSettings_DaysDuration.Properties.EditFormat.FormatString = "f"
            Me.NumericInputSettings_DaysDuration.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSettings_DaysDuration.Properties.Mask.EditMask = "f"
            Me.NumericInputSettings_DaysDuration.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputSettings_DaysDuration.Size = New System.Drawing.Size(48, 20)
            Me.NumericInputSettings_DaysDuration.TabIndex = 20
            '
            'NumericInputSettings_Order
            '
            Me.NumericInputSettings_Order.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputSettings_Order.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputSettings_Order.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputSettings_Order.Location = New System.Drawing.Point(135, 4)
            Me.NumericInputSettings_Order.Name = "NumericInputSettings_Order"
            Me.NumericInputSettings_Order.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputSettings_Order.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputSettings_Order.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSettings_Order.Properties.EditFormat.FormatString = "f"
            Me.NumericInputSettings_Order.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSettings_Order.Properties.Mask.EditMask = "f"
            Me.NumericInputSettings_Order.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputSettings_Order.Size = New System.Drawing.Size(48, 20)
            Me.NumericInputSettings_Order.TabIndex = 19
            '
            'CheckBoxSettings_Milestone
            '
            Me.CheckBoxSettings_Milestone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSettings_Milestone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSettings_Milestone.CheckValue = 0
            Me.CheckBoxSettings_Milestone.CheckValueChecked = 1
            Me.CheckBoxSettings_Milestone.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSettings_Milestone.CheckValueUnchecked = 0
            Me.CheckBoxSettings_Milestone.ChildControls = CType(resources.GetObject("CheckBoxSettings_Milestone.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettings_Milestone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSettings_Milestone.Location = New System.Drawing.Point(135, 82)
            Me.CheckBoxSettings_Milestone.Name = "CheckBoxSettings_Milestone"
            Me.CheckBoxSettings_Milestone.OldestSibling = Nothing
            Me.CheckBoxSettings_Milestone.SecurityEnabled = True
            Me.CheckBoxSettings_Milestone.SiblingControls = CType(resources.GetObject("CheckBoxSettings_Milestone.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettings_Milestone.Size = New System.Drawing.Size(48, 20)
            Me.CheckBoxSettings_Milestone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSettings_Milestone.TabIndex = 18
            '
            'CheckBoxSettings_Locked
            '
            Me.CheckBoxSettings_Locked.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSettings_Locked.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSettings_Locked.CheckValue = 0
            Me.CheckBoxSettings_Locked.CheckValueChecked = 1
            Me.CheckBoxSettings_Locked.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSettings_Locked.CheckValueUnchecked = 0
            Me.CheckBoxSettings_Locked.ChildControls = CType(resources.GetObject("CheckBoxSettings_Locked.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettings_Locked.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSettings_Locked.Location = New System.Drawing.Point(135, 160)
            Me.CheckBoxSettings_Locked.Name = "CheckBoxSettings_Locked"
            Me.CheckBoxSettings_Locked.OldestSibling = Nothing
            Me.CheckBoxSettings_Locked.SecurityEnabled = True
            Me.CheckBoxSettings_Locked.SiblingControls = CType(resources.GetObject("CheckBoxSettings_Locked.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettings_Locked.Size = New System.Drawing.Size(48, 20)
            Me.CheckBoxSettings_Locked.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSettings_Locked.TabIndex = 17
            '
            'DateTimePickerSettings_OriginalDueDate
            '
            Me.DateTimePickerSettings_OriginalDueDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerSettings_OriginalDueDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerSettings_OriginalDueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSettings_OriginalDueDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerSettings_OriginalDueDate.ButtonDropDown.Visible = True
            Me.DateTimePickerSettings_OriginalDueDate.ButtonFreeText.Checked = True
            Me.DateTimePickerSettings_OriginalDueDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerSettings_OriginalDueDate.CustomFormat = ""
            Me.DateTimePickerSettings_OriginalDueDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerSettings_OriginalDueDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerSettings_OriginalDueDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerSettings_OriginalDueDate.FocusHighlightEnabled = True
            Me.DateTimePickerSettings_OriginalDueDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerSettings_OriginalDueDate.FreeTextEntryMode = True
            Me.DateTimePickerSettings_OriginalDueDate.IsPopupCalendarOpen = False
            Me.DateTimePickerSettings_OriginalDueDate.Location = New System.Drawing.Point(135, 134)
            Me.DateTimePickerSettings_OriginalDueDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.DisplayMonth = New Date(2013, 12, 1, 0, 0, 0, 0)
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerSettings_OriginalDueDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerSettings_OriginalDueDate.Name = "DateTimePickerSettings_OriginalDueDate"
            Me.DateTimePickerSettings_OriginalDueDate.ReadOnly = False
            Me.DateTimePickerSettings_OriginalDueDate.Size = New System.Drawing.Size(94, 20)
            Me.DateTimePickerSettings_OriginalDueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerSettings_OriginalDueDate.TabIndex = 16
            Me.DateTimePickerSettings_OriginalDueDate.Value = New Date(2013, 12, 20, 15, 29, 50, 869)
            '
            'SearchableComboBoxSettings_EstimateFunction
            '
            Me.SearchableComboBoxSettings_EstimateFunction.ActiveFilterString = ""
            Me.SearchableComboBoxSettings_EstimateFunction.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSettings_EstimateFunction.BookmarkingEnabled = False
            Me.SearchableComboBoxSettings_EstimateFunction.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.[Function]
            Me.SearchableComboBoxSettings_EstimateFunction.DataSource = Nothing
            Me.SearchableComboBoxSettings_EstimateFunction.DisableMouseWheel = False
            Me.SearchableComboBoxSettings_EstimateFunction.DisplayName = ""
            Me.SearchableComboBoxSettings_EstimateFunction.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxSettings_EstimateFunction.Location = New System.Drawing.Point(135, 108)
            Me.SearchableComboBoxSettings_EstimateFunction.Name = "SearchableComboBoxSettings_EstimateFunction"
            Me.SearchableComboBoxSettings_EstimateFunction.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSettings_EstimateFunction.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSettings_EstimateFunction.Properties.NullText = "Select Function"
            Me.SearchableComboBoxSettings_EstimateFunction.Properties.ShowClearButton = False
            Me.SearchableComboBoxSettings_EstimateFunction.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSettings_EstimateFunction.Properties.View = Me.GridView3
            Me.SearchableComboBoxSettings_EstimateFunction.SecurityEnabled = True
            Me.SearchableComboBoxSettings_EstimateFunction.SelectedValue = Nothing
            Me.SearchableComboBoxSettings_EstimateFunction.Size = New System.Drawing.Size(287, 20)
            Me.SearchableComboBoxSettings_EstimateFunction.TabIndex = 13
            '
            'GridView3
            '
            Me.GridView3.AFActiveFilterString = ""
            Me.GridView3.AllowExtraItemsInGridLookupEdits = True
            Me.GridView3.AutoFilterLookupColumns = False
            Me.GridView3.AutoloadRepositoryDatasource = True
            Me.GridView3.DataSourceClearing = False
            Me.GridView3.EnableDisabledRows = False
            Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView3.Name = "GridView3"
            Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView3.OptionsView.ShowGroupPanel = False
            Me.GridView3.RunStandardValidation = True
            '
            'LabelSettings_Locked
            '
            Me.LabelSettings_Locked.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_Locked.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_Locked.Location = New System.Drawing.Point(4, 160)
            Me.LabelSettings_Locked.Name = "LabelSettings_Locked"
            Me.LabelSettings_Locked.Size = New System.Drawing.Size(125, 20)
            Me.LabelSettings_Locked.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_Locked.TabIndex = 12
            Me.LabelSettings_Locked.Text = "Locked:"
            '
            'LabelSettings_OriginalDueDate
            '
            Me.LabelSettings_OriginalDueDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_OriginalDueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_OriginalDueDate.Location = New System.Drawing.Point(4, 134)
            Me.LabelSettings_OriginalDueDate.Name = "LabelSettings_OriginalDueDate"
            Me.LabelSettings_OriginalDueDate.Size = New System.Drawing.Size(125, 20)
            Me.LabelSettings_OriginalDueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_OriginalDueDate.TabIndex = 11
            Me.LabelSettings_OriginalDueDate.Text = "Original Due Date:"
            '
            'LabelSettings_EstimateFunction
            '
            Me.LabelSettings_EstimateFunction.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_EstimateFunction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_EstimateFunction.Location = New System.Drawing.Point(4, 108)
            Me.LabelSettings_EstimateFunction.Name = "LabelSettings_EstimateFunction"
            Me.LabelSettings_EstimateFunction.Size = New System.Drawing.Size(125, 20)
            Me.LabelSettings_EstimateFunction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_EstimateFunction.TabIndex = 10
            Me.LabelSettings_EstimateFunction.Text = "Estimate Function:"
            '
            'LabelSettings_Milestone
            '
            Me.LabelSettings_Milestone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_Milestone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_Milestone.Location = New System.Drawing.Point(4, 82)
            Me.LabelSettings_Milestone.Name = "LabelSettings_Milestone"
            Me.LabelSettings_Milestone.Size = New System.Drawing.Size(125, 20)
            Me.LabelSettings_Milestone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_Milestone.TabIndex = 9
            Me.LabelSettings_Milestone.Text = "Milestone:"
            '
            'LabelSettings_DefaultHoursAllowed
            '
            Me.LabelSettings_DefaultHoursAllowed.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_DefaultHoursAllowed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_DefaultHoursAllowed.Location = New System.Drawing.Point(4, 56)
            Me.LabelSettings_DefaultHoursAllowed.Name = "LabelSettings_DefaultHoursAllowed"
            Me.LabelSettings_DefaultHoursAllowed.Size = New System.Drawing.Size(125, 20)
            Me.LabelSettings_DefaultHoursAllowed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_DefaultHoursAllowed.TabIndex = 8
            Me.LabelSettings_DefaultHoursAllowed.Text = "Default Hours Allowed:"
            '
            'LabelSettings_Days
            '
            Me.LabelSettings_Days.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_Days.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_Days.Location = New System.Drawing.Point(4, 30)
            Me.LabelSettings_Days.Name = "LabelSettings_Days"
            Me.LabelSettings_Days.Size = New System.Drawing.Size(125, 20)
            Me.LabelSettings_Days.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_Days.TabIndex = 7
            Me.LabelSettings_Days.Text = "Days (Duration):"
            '
            'LabelSettings_Order
            '
            Me.LabelSettings_Order.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_Order.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_Order.Location = New System.Drawing.Point(4, 4)
            Me.LabelSettings_Order.Name = "LabelSettings_Order"
            Me.LabelSettings_Order.Size = New System.Drawing.Size(125, 20)
            Me.LabelSettings_Order.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_Order.TabIndex = 6
            Me.LabelSettings_Order.Text = "Order:"
            '
            'TabItemTaskDetails_SettingsTab
            '
            Me.TabItemTaskDetails_SettingsTab.AttachedControl = Me.TabControlPanelSettingsTab_Settings
            Me.TabItemTaskDetails_SettingsTab.Name = "TabItemTaskDetails_SettingsTab"
            Me.TabItemTaskDetails_SettingsTab.Text = "Settings"
            '
            'TabControlPanelDetailsTab_Details
            '
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.DateTimePickerDetails_TempComplete)
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.TextBoxDetails_TaskDescription)
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.TabControlDetails_Comments)
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.TextBoxDetails_TimeDue)
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.DateTimePickerDetails_CompletedDate)
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.DateTimePickerDetails_DueDate)
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.DateTimePickerDetails_StartDate)
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.SearchableComboBoxDetails_TaskStatus)
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.SearchableComboBoxDetails_Task)
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.SearchableComboBoxDetails_Phase)
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.LabelDetails_CompletedDate)
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.LabelDetails_TimeDue)
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.LabelDetails_TempComplete)
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.LabelDetails_DueDate)
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.LabelDetails_StartDate)
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.LabelDetails_TaskStatus)
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.LabelDetails_Task)
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.LabelDetails_Phase)
            Me.TabControlPanelDetailsTab_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDetailsTab_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDetailsTab_Details.Name = "TabControlPanelDetailsTab_Details"
            Me.TabControlPanelDetailsTab_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDetailsTab_Details.Size = New System.Drawing.Size(769, 373)
            Me.TabControlPanelDetailsTab_Details.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDetailsTab_Details.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDetailsTab_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDetailsTab_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDetailsTab_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDetailsTab_Details.Style.GradientAngle = 90
            Me.TabControlPanelDetailsTab_Details.TabIndex = 0
            Me.TabControlPanelDetailsTab_Details.TabItem = Me.TabItemTaskDetails_DetailsTab
            '
            'DateTimePickerDetails_TempComplete
            '
            Me.DateTimePickerDetails_TempComplete.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerDetails_TempComplete.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerDetails_TempComplete.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDetails_TempComplete.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerDetails_TempComplete.ButtonDropDown.Visible = True
            Me.DateTimePickerDetails_TempComplete.ButtonFreeText.Checked = True
            Me.DateTimePickerDetails_TempComplete.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerDetails_TempComplete.CustomFormat = ""
            Me.DateTimePickerDetails_TempComplete.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerDetails_TempComplete.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerDetails_TempComplete.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerDetails_TempComplete.FocusHighlightEnabled = True
            Me.DateTimePickerDetails_TempComplete.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerDetails_TempComplete.FreeTextEntryMode = True
            Me.DateTimePickerDetails_TempComplete.IsPopupCalendarOpen = False
            Me.DateTimePickerDetails_TempComplete.Location = New System.Drawing.Point(126, 160)
            Me.DateTimePickerDetails_TempComplete.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.DisplayMonth = New Date(2013, 12, 1, 0, 0, 0, 0)
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerDetails_TempComplete.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerDetails_TempComplete.Name = "DateTimePickerDetails_TempComplete"
            Me.DateTimePickerDetails_TempComplete.ReadOnly = False
            Me.DateTimePickerDetails_TempComplete.Size = New System.Drawing.Size(94, 20)
            Me.DateTimePickerDetails_TempComplete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDetails_TempComplete.TabIndex = 23
            Me.DateTimePickerDetails_TempComplete.Value = New Date(2013, 12, 20, 15, 29, 50, 640)
            '
            'TextBoxDetails_TaskDescription
            '
            '
            '
            '
            Me.TextBoxDetails_TaskDescription.Border.Class = "TextBoxBorder"
            Me.TextBoxDetails_TaskDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDetails_TaskDescription.CheckSpellingOnValidate = False
            Me.TextBoxDetails_TaskDescription.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDetails_TaskDescription.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDetails_TaskDescription.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDetails_TaskDescription.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDetails_TaskDescription.FocusHighlightEnabled = True
            Me.TextBoxDetails_TaskDescription.Location = New System.Drawing.Point(226, 30)
            Me.TextBoxDetails_TaskDescription.MaxFileSize = CType(0, Long)
            Me.TextBoxDetails_TaskDescription.Name = "TextBoxDetails_TaskDescription"
            Me.TextBoxDetails_TaskDescription.PreventEnterBeep = False
            Me.TextBoxDetails_TaskDescription.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDetails_TaskDescription.Size = New System.Drawing.Size(187, 20)
            Me.TextBoxDetails_TaskDescription.StartingFolderName = Nothing
            Me.TextBoxDetails_TaskDescription.TabIndex = 22
            Me.TextBoxDetails_TaskDescription.TabOnEnter = True
            '
            'TabControlDetails_Comments
            '
            Me.TabControlDetails_Comments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlDetails_Comments.CanReorderTabs = True
            Me.TabControlDetails_Comments.Controls.Add(Me.TabControlPanelTaskCommentsTab_TaskComments)
            Me.TabControlDetails_Comments.Controls.Add(Me.TabControlPanelDueDateCommentsTab_DueDateComments)
            Me.TabControlDetails_Comments.Controls.Add(Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments)
            Me.TabControlDetails_Comments.Location = New System.Drawing.Point(4, 209)
            Me.TabControlDetails_Comments.Name = "TabControlDetails_Comments"
            Me.TabControlDetails_Comments.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlDetails_Comments.SelectedTabIndex = 0
            Me.TabControlDetails_Comments.Size = New System.Drawing.Size(761, 160)
            Me.TabControlDetails_Comments.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlDetails_Comments.TabIndex = 21
            Me.TabControlDetails_Comments.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlDetails_Comments.Tabs.Add(Me.TabItemDetails_TaskCommentsTab)
            Me.TabControlDetails_Comments.Tabs.Add(Me.TabItemDetails_DueDateCommentsTab)
            Me.TabControlDetails_Comments.Tabs.Add(Me.TabItemDetails_RevisedDueDateCommentsTab)
            Me.TabControlDetails_Comments.Text = "TabControl1"
            '
            'TabControlPanelTaskCommentsTab_TaskComments
            '
            Me.TabControlPanelTaskCommentsTab_TaskComments.Controls.Add(Me.TextBoxTaskComments_Comments)
            Me.TabControlPanelTaskCommentsTab_TaskComments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTaskCommentsTab_TaskComments.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTaskCommentsTab_TaskComments.Name = "TabControlPanelTaskCommentsTab_TaskComments"
            Me.TabControlPanelTaskCommentsTab_TaskComments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTaskCommentsTab_TaskComments.Size = New System.Drawing.Size(761, 133)
            Me.TabControlPanelTaskCommentsTab_TaskComments.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTaskCommentsTab_TaskComments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTaskCommentsTab_TaskComments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTaskCommentsTab_TaskComments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTaskCommentsTab_TaskComments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTaskCommentsTab_TaskComments.Style.GradientAngle = 90
            Me.TabControlPanelTaskCommentsTab_TaskComments.TabIndex = 1
            Me.TabControlPanelTaskCommentsTab_TaskComments.TabItem = Me.TabItemDetails_TaskCommentsTab
            '
            'TextBoxTaskComments_Comments
            '
            Me.TextBoxTaskComments_Comments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxTaskComments_Comments.Border.Class = "TextBoxBorder"
            Me.TextBoxTaskComments_Comments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTaskComments_Comments.CheckSpellingOnValidate = False
            Me.TextBoxTaskComments_Comments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTaskComments_Comments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxTaskComments_Comments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTaskComments_Comments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTaskComments_Comments.FocusHighlightEnabled = True
            Me.TextBoxTaskComments_Comments.Location = New System.Drawing.Point(4, 4)
            Me.TextBoxTaskComments_Comments.MaxFileSize = CType(0, Long)
            Me.TextBoxTaskComments_Comments.Multiline = True
            Me.TextBoxTaskComments_Comments.Name = "TextBoxTaskComments_Comments"
            Me.TextBoxTaskComments_Comments.PreventEnterBeep = False
            Me.TextBoxTaskComments_Comments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTaskComments_Comments.Size = New System.Drawing.Size(753, 125)
            Me.TextBoxTaskComments_Comments.StartingFolderName = Nothing
            Me.TextBoxTaskComments_Comments.TabIndex = 22
            Me.TextBoxTaskComments_Comments.TabOnEnter = True
            '
            'TabItemDetails_TaskCommentsTab
            '
            Me.TabItemDetails_TaskCommentsTab.AttachedControl = Me.TabControlPanelTaskCommentsTab_TaskComments
            Me.TabItemDetails_TaskCommentsTab.Name = "TabItemDetails_TaskCommentsTab"
            Me.TabItemDetails_TaskCommentsTab.Text = "Task Comments"
            '
            'TabControlPanelDueDateCommentsTab_DueDateComments
            '
            Me.TabControlPanelDueDateCommentsTab_DueDateComments.Controls.Add(Me.TextBoxDueDateComments_Comments)
            Me.TabControlPanelDueDateCommentsTab_DueDateComments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDueDateCommentsTab_DueDateComments.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDueDateCommentsTab_DueDateComments.Name = "TabControlPanelDueDateCommentsTab_DueDateComments"
            Me.TabControlPanelDueDateCommentsTab_DueDateComments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDueDateCommentsTab_DueDateComments.Size = New System.Drawing.Size(761, 133)
            Me.TabControlPanelDueDateCommentsTab_DueDateComments.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDueDateCommentsTab_DueDateComments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDueDateCommentsTab_DueDateComments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDueDateCommentsTab_DueDateComments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDueDateCommentsTab_DueDateComments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDueDateCommentsTab_DueDateComments.Style.GradientAngle = 90
            Me.TabControlPanelDueDateCommentsTab_DueDateComments.TabIndex = 2
            Me.TabControlPanelDueDateCommentsTab_DueDateComments.TabItem = Me.TabItemDetails_DueDateCommentsTab
            '
            'TextBoxDueDateComments_Comments
            '
            Me.TextBoxDueDateComments_Comments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxDueDateComments_Comments.Border.Class = "TextBoxBorder"
            Me.TextBoxDueDateComments_Comments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDueDateComments_Comments.CheckSpellingOnValidate = False
            Me.TextBoxDueDateComments_Comments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDueDateComments_Comments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDueDateComments_Comments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDueDateComments_Comments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDueDateComments_Comments.FocusHighlightEnabled = True
            Me.TextBoxDueDateComments_Comments.Location = New System.Drawing.Point(4, 4)
            Me.TextBoxDueDateComments_Comments.MaxFileSize = CType(0, Long)
            Me.TextBoxDueDateComments_Comments.Multiline = True
            Me.TextBoxDueDateComments_Comments.Name = "TextBoxDueDateComments_Comments"
            Me.TextBoxDueDateComments_Comments.PreventEnterBeep = False
            Me.TextBoxDueDateComments_Comments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDueDateComments_Comments.Size = New System.Drawing.Size(753, 125)
            Me.TextBoxDueDateComments_Comments.StartingFolderName = Nothing
            Me.TextBoxDueDateComments_Comments.TabIndex = 21
            Me.TextBoxDueDateComments_Comments.TabOnEnter = True
            '
            'TabItemDetails_DueDateCommentsTab
            '
            Me.TabItemDetails_DueDateCommentsTab.AttachedControl = Me.TabControlPanelDueDateCommentsTab_DueDateComments
            Me.TabItemDetails_DueDateCommentsTab.Name = "TabItemDetails_DueDateCommentsTab"
            Me.TabItemDetails_DueDateCommentsTab.Text = "Due Date Comments"
            '
            'TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments
            '
            Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments.Controls.Add(Me.TextBoxRevisedDueDateComments_Comments)
            Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments.Name = "TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments"
            Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments.Size = New System.Drawing.Size(761, 133)
            Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments.Style.GradientAngle = 90
            Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments.TabIndex = 3
            Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments.TabItem = Me.TabItemDetails_RevisedDueDateCommentsTab
            '
            'TextBoxRevisedDueDateComments_Comments
            '
            Me.TextBoxRevisedDueDateComments_Comments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxRevisedDueDateComments_Comments.Border.Class = "TextBoxBorder"
            Me.TextBoxRevisedDueDateComments_Comments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxRevisedDueDateComments_Comments.CheckSpellingOnValidate = False
            Me.TextBoxRevisedDueDateComments_Comments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxRevisedDueDateComments_Comments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxRevisedDueDateComments_Comments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxRevisedDueDateComments_Comments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxRevisedDueDateComments_Comments.FocusHighlightEnabled = True
            Me.TextBoxRevisedDueDateComments_Comments.Location = New System.Drawing.Point(4, 4)
            Me.TextBoxRevisedDueDateComments_Comments.MaxFileSize = CType(0, Long)
            Me.TextBoxRevisedDueDateComments_Comments.Multiline = True
            Me.TextBoxRevisedDueDateComments_Comments.Name = "TextBoxRevisedDueDateComments_Comments"
            Me.TextBoxRevisedDueDateComments_Comments.PreventEnterBeep = False
            Me.TextBoxRevisedDueDateComments_Comments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxRevisedDueDateComments_Comments.Size = New System.Drawing.Size(753, 125)
            Me.TextBoxRevisedDueDateComments_Comments.StartingFolderName = Nothing
            Me.TextBoxRevisedDueDateComments_Comments.TabIndex = 22
            Me.TextBoxRevisedDueDateComments_Comments.TabOnEnter = True
            '
            'TabItemDetails_RevisedDueDateCommentsTab
            '
            Me.TabItemDetails_RevisedDueDateCommentsTab.AttachedControl = Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments
            Me.TabItemDetails_RevisedDueDateCommentsTab.Name = "TabItemDetails_RevisedDueDateCommentsTab"
            Me.TabItemDetails_RevisedDueDateCommentsTab.Text = "Revised Due Date Comments"
            '
            'TextBoxDetails_TimeDue
            '
            '
            '
            '
            Me.TextBoxDetails_TimeDue.Border.Class = "TextBoxBorder"
            Me.TextBoxDetails_TimeDue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDetails_TimeDue.CheckSpellingOnValidate = False
            Me.TextBoxDetails_TimeDue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDetails_TimeDue.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDetails_TimeDue.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDetails_TimeDue.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDetails_TimeDue.FocusHighlightEnabled = True
            Me.TextBoxDetails_TimeDue.Location = New System.Drawing.Point(126, 186)
            Me.TextBoxDetails_TimeDue.MaxFileSize = CType(0, Long)
            Me.TextBoxDetails_TimeDue.Name = "TextBoxDetails_TimeDue"
            Me.TextBoxDetails_TimeDue.PreventEnterBeep = False
            Me.TextBoxDetails_TimeDue.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDetails_TimeDue.Size = New System.Drawing.Size(94, 20)
            Me.TextBoxDetails_TimeDue.StartingFolderName = Nothing
            Me.TextBoxDetails_TimeDue.TabIndex = 19
            Me.TextBoxDetails_TimeDue.TabOnEnter = True
            '
            'DateTimePickerDetails_CompletedDate
            '
            Me.DateTimePickerDetails_CompletedDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerDetails_CompletedDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerDetails_CompletedDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDetails_CompletedDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerDetails_CompletedDate.ButtonDropDown.Visible = True
            Me.DateTimePickerDetails_CompletedDate.ButtonFreeText.Checked = True
            Me.DateTimePickerDetails_CompletedDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerDetails_CompletedDate.CustomFormat = ""
            Me.DateTimePickerDetails_CompletedDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerDetails_CompletedDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerDetails_CompletedDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerDetails_CompletedDate.FocusHighlightEnabled = True
            Me.DateTimePickerDetails_CompletedDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerDetails_CompletedDate.FreeTextEntryMode = True
            Me.DateTimePickerDetails_CompletedDate.IsPopupCalendarOpen = False
            Me.DateTimePickerDetails_CompletedDate.Location = New System.Drawing.Point(126, 134)
            Me.DateTimePickerDetails_CompletedDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.DisplayMonth = New Date(2013, 12, 1, 0, 0, 0, 0)
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerDetails_CompletedDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerDetails_CompletedDate.Name = "DateTimePickerDetails_CompletedDate"
            Me.DateTimePickerDetails_CompletedDate.ReadOnly = False
            Me.DateTimePickerDetails_CompletedDate.Size = New System.Drawing.Size(94, 20)
            Me.DateTimePickerDetails_CompletedDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDetails_CompletedDate.TabIndex = 17
            Me.DateTimePickerDetails_CompletedDate.Value = New Date(2013, 12, 20, 15, 29, 50, 640)
            '
            'DateTimePickerDetails_DueDate
            '
            Me.DateTimePickerDetails_DueDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerDetails_DueDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerDetails_DueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDetails_DueDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerDetails_DueDate.ButtonDropDown.Visible = True
            Me.DateTimePickerDetails_DueDate.ButtonFreeText.Checked = True
            Me.DateTimePickerDetails_DueDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerDetails_DueDate.CustomFormat = ""
            Me.DateTimePickerDetails_DueDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerDetails_DueDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerDetails_DueDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerDetails_DueDate.FocusHighlightEnabled = True
            Me.DateTimePickerDetails_DueDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerDetails_DueDate.FreeTextEntryMode = True
            Me.DateTimePickerDetails_DueDate.IsPopupCalendarOpen = False
            Me.DateTimePickerDetails_DueDate.Location = New System.Drawing.Point(126, 108)
            Me.DateTimePickerDetails_DueDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerDetails_DueDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDetails_DueDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDetails_DueDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerDetails_DueDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerDetails_DueDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerDetails_DueDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDetails_DueDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerDetails_DueDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerDetails_DueDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerDetails_DueDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerDetails_DueDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDetails_DueDate.MonthCalendar.DisplayMonth = New Date(2013, 12, 1, 0, 0, 0, 0)
            Me.DateTimePickerDetails_DueDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerDetails_DueDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDetails_DueDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerDetails_DueDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDetails_DueDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerDetails_DueDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDetails_DueDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerDetails_DueDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerDetails_DueDate.Name = "DateTimePickerDetails_DueDate"
            Me.DateTimePickerDetails_DueDate.ReadOnly = False
            Me.DateTimePickerDetails_DueDate.Size = New System.Drawing.Size(94, 20)
            Me.DateTimePickerDetails_DueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDetails_DueDate.TabIndex = 16
            Me.DateTimePickerDetails_DueDate.Value = New Date(2013, 12, 20, 15, 29, 50, 667)
            '
            'DateTimePickerDetails_StartDate
            '
            Me.DateTimePickerDetails_StartDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerDetails_StartDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerDetails_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDetails_StartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerDetails_StartDate.ButtonDropDown.Visible = True
            Me.DateTimePickerDetails_StartDate.ButtonFreeText.Checked = True
            Me.DateTimePickerDetails_StartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerDetails_StartDate.CustomFormat = ""
            Me.DateTimePickerDetails_StartDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerDetails_StartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerDetails_StartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerDetails_StartDate.FocusHighlightEnabled = True
            Me.DateTimePickerDetails_StartDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerDetails_StartDate.FreeTextEntryMode = True
            Me.DateTimePickerDetails_StartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerDetails_StartDate.Location = New System.Drawing.Point(126, 82)
            Me.DateTimePickerDetails_StartDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerDetails_StartDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDetails_StartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDetails_StartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerDetails_StartDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerDetails_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerDetails_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDetails_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerDetails_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerDetails_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerDetails_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerDetails_StartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDetails_StartDate.MonthCalendar.DisplayMonth = New Date(2013, 12, 1, 0, 0, 0, 0)
            Me.DateTimePickerDetails_StartDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerDetails_StartDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDetails_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerDetails_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDetails_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerDetails_StartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDetails_StartDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerDetails_StartDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerDetails_StartDate.Name = "DateTimePickerDetails_StartDate"
            Me.DateTimePickerDetails_StartDate.ReadOnly = False
            Me.DateTimePickerDetails_StartDate.Size = New System.Drawing.Size(94, 20)
            Me.DateTimePickerDetails_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDetails_StartDate.TabIndex = 15
            Me.DateTimePickerDetails_StartDate.Value = New Date(2013, 12, 20, 15, 29, 50, 688)
            '
            'SearchableComboBoxDetails_TaskStatus
            '
            Me.SearchableComboBoxDetails_TaskStatus.ActiveFilterString = ""
            Me.SearchableComboBoxDetails_TaskStatus.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxDetails_TaskStatus.BookmarkingEnabled = False
            Me.SearchableComboBoxDetails_TaskStatus.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.TaskStatus
            Me.SearchableComboBoxDetails_TaskStatus.DataSource = Nothing
            Me.SearchableComboBoxDetails_TaskStatus.DisableMouseWheel = False
            Me.SearchableComboBoxDetails_TaskStatus.DisplayName = ""
            Me.SearchableComboBoxDetails_TaskStatus.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxDetails_TaskStatus.Location = New System.Drawing.Point(126, 56)
            Me.SearchableComboBoxDetails_TaskStatus.Name = "SearchableComboBoxDetails_TaskStatus"
            Me.SearchableComboBoxDetails_TaskStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDetails_TaskStatus.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDetails_TaskStatus.Properties.NullText = "Select Task Status"
            Me.SearchableComboBoxDetails_TaskStatus.Properties.ShowClearButton = False
            Me.SearchableComboBoxDetails_TaskStatus.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDetails_TaskStatus.Properties.View = Me.GridView2
            Me.SearchableComboBoxDetails_TaskStatus.SecurityEnabled = True
            Me.SearchableComboBoxDetails_TaskStatus.SelectedValue = Nothing
            Me.SearchableComboBoxDetails_TaskStatus.Size = New System.Drawing.Size(287, 20)
            Me.SearchableComboBoxDetails_TaskStatus.TabIndex = 14
            '
            'GridView2
            '
            Me.GridView2.AFActiveFilterString = ""
            Me.GridView2.AllowExtraItemsInGridLookupEdits = True
            Me.GridView2.AutoFilterLookupColumns = False
            Me.GridView2.AutoloadRepositoryDatasource = True
            Me.GridView2.DataSourceClearing = False
            Me.GridView2.EnableDisabledRows = False
            Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView2.Name = "GridView2"
            Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView2.OptionsView.ShowGroupPanel = False
            Me.GridView2.RunStandardValidation = True
            '
            'SearchableComboBoxDetails_Task
            '
            Me.SearchableComboBoxDetails_Task.ActiveFilterString = ""
            Me.SearchableComboBoxDetails_Task.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxDetails_Task.BookmarkingEnabled = False
            Me.SearchableComboBoxDetails_Task.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Task
            Me.SearchableComboBoxDetails_Task.DataSource = Nothing
            Me.SearchableComboBoxDetails_Task.DisableMouseWheel = False
            Me.SearchableComboBoxDetails_Task.DisplayName = ""
            Me.SearchableComboBoxDetails_Task.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxDetails_Task.Location = New System.Drawing.Point(126, 30)
            Me.SearchableComboBoxDetails_Task.Name = "SearchableComboBoxDetails_Task"
            Me.SearchableComboBoxDetails_Task.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDetails_Task.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDetails_Task.Properties.NullText = "Select Task"
            Me.SearchableComboBoxDetails_Task.Properties.ShowClearButton = False
            Me.SearchableComboBoxDetails_Task.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDetails_Task.Properties.View = Me.GridView1
            Me.SearchableComboBoxDetails_Task.SecurityEnabled = True
            Me.SearchableComboBoxDetails_Task.SelectedValue = Nothing
            Me.SearchableComboBoxDetails_Task.Size = New System.Drawing.Size(94, 20)
            Me.SearchableComboBoxDetails_Task.TabIndex = 13
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
            Me.GridView1.RunStandardValidation = True
            '
            'SearchableComboBoxDetails_Phase
            '
            Me.SearchableComboBoxDetails_Phase.ActiveFilterString = ""
            Me.SearchableComboBoxDetails_Phase.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxDetails_Phase.BookmarkingEnabled = False
            Me.SearchableComboBoxDetails_Phase.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Phase
            Me.SearchableComboBoxDetails_Phase.DataSource = Nothing
            Me.SearchableComboBoxDetails_Phase.DisableMouseWheel = False
            Me.SearchableComboBoxDetails_Phase.DisplayName = ""
            Me.SearchableComboBoxDetails_Phase.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxDetails_Phase.Location = New System.Drawing.Point(126, 4)
            Me.SearchableComboBoxDetails_Phase.Name = "SearchableComboBoxDetails_Phase"
            Me.SearchableComboBoxDetails_Phase.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDetails_Phase.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDetails_Phase.Properties.NullText = "Select Phase"
            Me.SearchableComboBoxDetails_Phase.Properties.ShowClearButton = False
            Me.SearchableComboBoxDetails_Phase.Properties.ValueMember = "ID"
            Me.SearchableComboBoxDetails_Phase.Properties.View = Me.SearchableComboBox1View
            Me.SearchableComboBoxDetails_Phase.SecurityEnabled = True
            Me.SearchableComboBoxDetails_Phase.SelectedValue = Nothing
            Me.SearchableComboBoxDetails_Phase.Size = New System.Drawing.Size(287, 20)
            Me.SearchableComboBoxDetails_Phase.TabIndex = 12
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
            Me.SearchableComboBox1View.RunStandardValidation = True
            '
            'LabelDetails_CompletedDate
            '
            Me.LabelDetails_CompletedDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetails_CompletedDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetails_CompletedDate.Location = New System.Drawing.Point(4, 134)
            Me.LabelDetails_CompletedDate.Name = "LabelDetails_CompletedDate"
            Me.LabelDetails_CompletedDate.Size = New System.Drawing.Size(116, 20)
            Me.LabelDetails_CompletedDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetails_CompletedDate.TabIndex = 7
            Me.LabelDetails_CompletedDate.Text = "Completed Date:"
            '
            'LabelDetails_TimeDue
            '
            Me.LabelDetails_TimeDue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetails_TimeDue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetails_TimeDue.Location = New System.Drawing.Point(4, 186)
            Me.LabelDetails_TimeDue.Name = "LabelDetails_TimeDue"
            Me.LabelDetails_TimeDue.Size = New System.Drawing.Size(116, 20)
            Me.LabelDetails_TimeDue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetails_TimeDue.TabIndex = 6
            Me.LabelDetails_TimeDue.Text = "Time Due:"
            '
            'LabelDetails_TempComplete
            '
            Me.LabelDetails_TempComplete.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetails_TempComplete.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetails_TempComplete.Location = New System.Drawing.Point(4, 160)
            Me.LabelDetails_TempComplete.Name = "LabelDetails_TempComplete"
            Me.LabelDetails_TempComplete.Size = New System.Drawing.Size(116, 20)
            Me.LabelDetails_TempComplete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetails_TempComplete.TabIndex = 5
            Me.LabelDetails_TempComplete.Text = "Temp Complete (All):"
            '
            'LabelDetails_DueDate
            '
            Me.LabelDetails_DueDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetails_DueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetails_DueDate.Location = New System.Drawing.Point(4, 108)
            Me.LabelDetails_DueDate.Name = "LabelDetails_DueDate"
            Me.LabelDetails_DueDate.Size = New System.Drawing.Size(116, 20)
            Me.LabelDetails_DueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetails_DueDate.TabIndex = 4
            Me.LabelDetails_DueDate.Text = "Due Date:"
            '
            'LabelDetails_StartDate
            '
            Me.LabelDetails_StartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetails_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetails_StartDate.Location = New System.Drawing.Point(4, 82)
            Me.LabelDetails_StartDate.Name = "LabelDetails_StartDate"
            Me.LabelDetails_StartDate.Size = New System.Drawing.Size(116, 20)
            Me.LabelDetails_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetails_StartDate.TabIndex = 3
            Me.LabelDetails_StartDate.Text = "Start Date:"
            '
            'LabelDetails_TaskStatus
            '
            Me.LabelDetails_TaskStatus.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetails_TaskStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetails_TaskStatus.Location = New System.Drawing.Point(4, 56)
            Me.LabelDetails_TaskStatus.Name = "LabelDetails_TaskStatus"
            Me.LabelDetails_TaskStatus.Size = New System.Drawing.Size(116, 20)
            Me.LabelDetails_TaskStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetails_TaskStatus.TabIndex = 2
            Me.LabelDetails_TaskStatus.Text = "Task Status:"
            '
            'LabelDetails_Task
            '
            Me.LabelDetails_Task.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetails_Task.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetails_Task.Location = New System.Drawing.Point(4, 30)
            Me.LabelDetails_Task.Name = "LabelDetails_Task"
            Me.LabelDetails_Task.Size = New System.Drawing.Size(116, 20)
            Me.LabelDetails_Task.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetails_Task.TabIndex = 1
            Me.LabelDetails_Task.Text = "Task:"
            '
            'LabelDetails_Phase
            '
            Me.LabelDetails_Phase.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetails_Phase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetails_Phase.Location = New System.Drawing.Point(4, 4)
            Me.LabelDetails_Phase.Name = "LabelDetails_Phase"
            Me.LabelDetails_Phase.Size = New System.Drawing.Size(116, 20)
            Me.LabelDetails_Phase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetails_Phase.TabIndex = 0
            Me.LabelDetails_Phase.Text = "Phase:"
            '
            'TabItemTaskDetails_DetailsTab
            '
            Me.TabItemTaskDetails_DetailsTab.AttachedControl = Me.TabControlPanelDetailsTab_Details
            Me.TabItemTaskDetails_DetailsTab.Name = "TabItemTaskDetails_DetailsTab"
            Me.TabItemTaskDetails_DetailsTab.Text = "Details"
            '
            'TextBoxGeneralInfo_Comments
            '
            '
            '
            '
            Me.TextBoxGeneralInfo_Comments.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneralInfo_Comments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneralInfo_Comments.CheckSpellingOnValidate = False
            Me.TextBoxGeneralInfo_Comments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneralInfo_Comments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxGeneralInfo_Comments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneralInfo_Comments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneralInfo_Comments.FocusHighlightEnabled = True
            Me.TextBoxGeneralInfo_Comments.Location = New System.Drawing.Point(479, 134)
            Me.TextBoxGeneralInfo_Comments.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneralInfo_Comments.Name = "TextBoxGeneralInfo_Comments"
            Me.TextBoxGeneralInfo_Comments.PreventEnterBeep = False
            Me.TextBoxGeneralInfo_Comments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneralInfo_Comments.Size = New System.Drawing.Size(287, 20)
            Me.TextBoxGeneralInfo_Comments.StartingFolderName = Nothing
            Me.TextBoxGeneralInfo_Comments.TabIndex = 24
            Me.TextBoxGeneralInfo_Comments.TabOnEnter = True
            '
            'DateTimePickerGeneralInfo_JobDueDate
            '
            Me.DateTimePickerGeneralInfo_JobDueDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerGeneralInfo_JobDueDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerGeneralInfo_JobDueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneralInfo_JobDueDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerGeneralInfo_JobDueDate.ButtonDropDown.Visible = True
            Me.DateTimePickerGeneralInfo_JobDueDate.ButtonFreeText.Checked = True
            Me.DateTimePickerGeneralInfo_JobDueDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerGeneralInfo_JobDueDate.CustomFormat = ""
            Me.DateTimePickerGeneralInfo_JobDueDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerGeneralInfo_JobDueDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerGeneralInfo_JobDueDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerGeneralInfo_JobDueDate.FocusHighlightEnabled = True
            Me.DateTimePickerGeneralInfo_JobDueDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerGeneralInfo_JobDueDate.FreeTextEntryMode = True
            Me.DateTimePickerGeneralInfo_JobDueDate.IsPopupCalendarOpen = False
            Me.DateTimePickerGeneralInfo_JobDueDate.Location = New System.Drawing.Point(478, 82)
            Me.DateTimePickerGeneralInfo_JobDueDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.DisplayMonth = New Date(2013, 12, 1, 0, 0, 0, 0)
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerGeneralInfo_JobDueDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerGeneralInfo_JobDueDate.Name = "DateTimePickerGeneralInfo_JobDueDate"
            Me.DateTimePickerGeneralInfo_JobDueDate.ReadOnly = False
            Me.DateTimePickerGeneralInfo_JobDueDate.Size = New System.Drawing.Size(94, 20)
            Me.DateTimePickerGeneralInfo_JobDueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerGeneralInfo_JobDueDate.TabIndex = 23
            Me.DateTimePickerGeneralInfo_JobDueDate.Value = New Date(2013, 12, 20, 15, 29, 50, 667)
            '
            'DateTimePickerGeneralInfo_JobStartDate
            '
            Me.DateTimePickerGeneralInfo_JobStartDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerGeneralInfo_JobStartDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerGeneralInfo_JobStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneralInfo_JobStartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerGeneralInfo_JobStartDate.ButtonDropDown.Visible = True
            Me.DateTimePickerGeneralInfo_JobStartDate.ButtonFreeText.Checked = True
            Me.DateTimePickerGeneralInfo_JobStartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerGeneralInfo_JobStartDate.CustomFormat = ""
            Me.DateTimePickerGeneralInfo_JobStartDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerGeneralInfo_JobStartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerGeneralInfo_JobStartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerGeneralInfo_JobStartDate.FocusHighlightEnabled = True
            Me.DateTimePickerGeneralInfo_JobStartDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerGeneralInfo_JobStartDate.FreeTextEntryMode = True
            Me.DateTimePickerGeneralInfo_JobStartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerGeneralInfo_JobStartDate.Location = New System.Drawing.Point(478, 56)
            Me.DateTimePickerGeneralInfo_JobStartDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.DisplayMonth = New Date(2013, 12, 1, 0, 0, 0, 0)
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerGeneralInfo_JobStartDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerGeneralInfo_JobStartDate.Name = "DateTimePickerGeneralInfo_JobStartDate"
            Me.DateTimePickerGeneralInfo_JobStartDate.ReadOnly = False
            Me.DateTimePickerGeneralInfo_JobStartDate.Size = New System.Drawing.Size(94, 20)
            Me.DateTimePickerGeneralInfo_JobStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerGeneralInfo_JobStartDate.TabIndex = 22
            Me.DateTimePickerGeneralInfo_JobStartDate.Value = New Date(2013, 12, 20, 15, 29, 50, 688)
            '
            'SearchableComboBoxGeneralInfo_JobStatus
            '
            Me.SearchableComboBoxGeneralInfo_JobStatus.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralInfo_JobStatus.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxGeneralInfo_JobStatus.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralInfo_JobStatus.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Status
            Me.SearchableComboBoxGeneralInfo_JobStatus.DataSource = Nothing
            Me.SearchableComboBoxGeneralInfo_JobStatus.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralInfo_JobStatus.DisplayName = ""
            Me.SearchableComboBoxGeneralInfo_JobStatus.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxGeneralInfo_JobStatus.Location = New System.Drawing.Point(479, 108)
            Me.SearchableComboBoxGeneralInfo_JobStatus.Name = "SearchableComboBoxGeneralInfo_JobStatus"
            Me.SearchableComboBoxGeneralInfo_JobStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralInfo_JobStatus.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGeneralInfo_JobStatus.Properties.NullText = "Select Status"
            Me.SearchableComboBoxGeneralInfo_JobStatus.Properties.ShowClearButton = False
            Me.SearchableComboBoxGeneralInfo_JobStatus.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneralInfo_JobStatus.Properties.View = Me.GridView11
            Me.SearchableComboBoxGeneralInfo_JobStatus.SecurityEnabled = True
            Me.SearchableComboBoxGeneralInfo_JobStatus.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralInfo_JobStatus.Size = New System.Drawing.Size(287, 20)
            Me.SearchableComboBoxGeneralInfo_JobStatus.TabIndex = 21
            '
            'GridView11
            '
            Me.GridView11.AFActiveFilterString = ""
            Me.GridView11.AllowExtraItemsInGridLookupEdits = True
            Me.GridView11.AutoFilterLookupColumns = False
            Me.GridView11.AutoloadRepositoryDatasource = True
            Me.GridView11.DataSourceClearing = False
            Me.GridView11.EnableDisabledRows = False
            Me.GridView11.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView11.Name = "GridView11"
            Me.GridView11.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView11.OptionsView.ShowGroupPanel = False
            Me.GridView11.RunStandardValidation = True
            '
            'SearchableComboBoxGeneralInfo_Component
            '
            Me.SearchableComboBoxGeneralInfo_Component.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralInfo_Component.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneralInfo_Component.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralInfo_Component.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.JobComponent
            Me.SearchableComboBoxGeneralInfo_Component.DataSource = Nothing
            Me.SearchableComboBoxGeneralInfo_Component.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralInfo_Component.DisplayName = ""
            Me.SearchableComboBoxGeneralInfo_Component.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxGeneralInfo_Component.Location = New System.Drawing.Point(75, 134)
            Me.SearchableComboBoxGeneralInfo_Component.Name = "SearchableComboBoxGeneralInfo_Component"
            Me.SearchableComboBoxGeneralInfo_Component.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralInfo_Component.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGeneralInfo_Component.Properties.NullText = "Select Job Component"
            Me.SearchableComboBoxGeneralInfo_Component.Properties.ShowClearButton = False
            Me.SearchableComboBoxGeneralInfo_Component.Properties.ValueMember = "Number"
            Me.SearchableComboBoxGeneralInfo_Component.Properties.View = Me.GridView8
            Me.SearchableComboBoxGeneralInfo_Component.SecurityEnabled = True
            Me.SearchableComboBoxGeneralInfo_Component.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralInfo_Component.Size = New System.Drawing.Size(287, 20)
            Me.SearchableComboBoxGeneralInfo_Component.TabIndex = 20
            '
            'GridView8
            '
            Me.GridView8.AFActiveFilterString = ""
            Me.GridView8.AllowExtraItemsInGridLookupEdits = True
            Me.GridView8.AutoFilterLookupColumns = False
            Me.GridView8.AutoloadRepositoryDatasource = True
            Me.GridView8.DataSourceClearing = False
            Me.GridView8.EnableDisabledRows = False
            Me.GridView8.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView8.Name = "GridView8"
            Me.GridView8.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView8.OptionsView.ShowGroupPanel = False
            Me.GridView8.RunStandardValidation = True
            '
            'SearchableComboBoxGeneralInfo_AccountExecutive
            '
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.DataSource = Nothing
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.DisplayName = ""
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.Location = New System.Drawing.Point(479, 30)
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.Name = "SearchableComboBoxGeneralInfo_AccountExecutive"
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.Properties.NullText = "Select Employee"
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.Properties.ShowClearButton = False
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.Properties.View = Me.GridView9
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.SecurityEnabled = True
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.Size = New System.Drawing.Size(287, 20)
            Me.SearchableComboBoxGeneralInfo_AccountExecutive.TabIndex = 19
            '
            'GridView9
            '
            Me.GridView9.AFActiveFilterString = ""
            Me.GridView9.AllowExtraItemsInGridLookupEdits = True
            Me.GridView9.AutoFilterLookupColumns = False
            Me.GridView9.AutoloadRepositoryDatasource = True
            Me.GridView9.DataSourceClearing = False
            Me.GridView9.EnableDisabledRows = False
            Me.GridView9.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView9.Name = "GridView9"
            Me.GridView9.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView9.OptionsView.ShowGroupPanel = False
            Me.GridView9.RunStandardValidation = True
            '
            'SearchableComboBoxGeneralInfo_Job
            '
            Me.SearchableComboBoxGeneralInfo_Job.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralInfo_Job.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneralInfo_Job.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralInfo_Job.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Job
            Me.SearchableComboBoxGeneralInfo_Job.DataSource = Nothing
            Me.SearchableComboBoxGeneralInfo_Job.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralInfo_Job.DisplayName = ""
            Me.SearchableComboBoxGeneralInfo_Job.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxGeneralInfo_Job.Location = New System.Drawing.Point(74, 108)
            Me.SearchableComboBoxGeneralInfo_Job.Name = "SearchableComboBoxGeneralInfo_Job"
            Me.SearchableComboBoxGeneralInfo_Job.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralInfo_Job.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGeneralInfo_Job.Properties.NullText = "Select Job"
            Me.SearchableComboBoxGeneralInfo_Job.Properties.ShowClearButton = False
            Me.SearchableComboBoxGeneralInfo_Job.Properties.ValueMember = "Number"
            Me.SearchableComboBoxGeneralInfo_Job.Properties.View = Me.GridView4
            Me.SearchableComboBoxGeneralInfo_Job.SecurityEnabled = True
            Me.SearchableComboBoxGeneralInfo_Job.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralInfo_Job.Size = New System.Drawing.Size(287, 20)
            Me.SearchableComboBoxGeneralInfo_Job.TabIndex = 18
            '
            'GridView4
            '
            Me.GridView4.AFActiveFilterString = ""
            Me.GridView4.AllowExtraItemsInGridLookupEdits = True
            Me.GridView4.AutoFilterLookupColumns = False
            Me.GridView4.AutoloadRepositoryDatasource = True
            Me.GridView4.DataSourceClearing = False
            Me.GridView4.EnableDisabledRows = False
            Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView4.Name = "GridView4"
            Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView4.OptionsView.ShowGroupPanel = False
            Me.GridView4.RunStandardValidation = True
            '
            'SearchableComboBoxGeneralInfo_Product
            '
            Me.SearchableComboBoxGeneralInfo_Product.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralInfo_Product.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxGeneralInfo_Product.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralInfo_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Product
            Me.SearchableComboBoxGeneralInfo_Product.DataSource = Nothing
            Me.SearchableComboBoxGeneralInfo_Product.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralInfo_Product.DisplayName = ""
            Me.SearchableComboBoxGeneralInfo_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxGeneralInfo_Product.Location = New System.Drawing.Point(74, 82)
            Me.SearchableComboBoxGeneralInfo_Product.Name = "SearchableComboBoxGeneralInfo_Product"
            Me.SearchableComboBoxGeneralInfo_Product.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralInfo_Product.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneralInfo_Product.Properties.NullText = "Select Product"
            Me.SearchableComboBoxGeneralInfo_Product.Properties.ShowClearButton = False
            Me.SearchableComboBoxGeneralInfo_Product.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneralInfo_Product.Properties.View = Me.GridView7
            Me.SearchableComboBoxGeneralInfo_Product.SecurityEnabled = True
            Me.SearchableComboBoxGeneralInfo_Product.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralInfo_Product.Size = New System.Drawing.Size(287, 20)
            Me.SearchableComboBoxGeneralInfo_Product.TabIndex = 17
            '
            'GridView7
            '
            Me.GridView7.AFActiveFilterString = ""
            Me.GridView7.AllowExtraItemsInGridLookupEdits = True
            Me.GridView7.AutoFilterLookupColumns = False
            Me.GridView7.AutoloadRepositoryDatasource = True
            Me.GridView7.DataSourceClearing = False
            Me.GridView7.EnableDisabledRows = False
            Me.GridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView7.Name = "GridView7"
            Me.GridView7.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView7.OptionsView.ShowGroupPanel = False
            Me.GridView7.RunStandardValidation = True
            '
            'LabelGeneralInfo_JobStatus
            '
            Me.LabelGeneralInfo_JobStatus.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInfo_JobStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInfo_JobStatus.Location = New System.Drawing.Point(368, 108)
            Me.LabelGeneralInfo_JobStatus.Name = "LabelGeneralInfo_JobStatus"
            Me.LabelGeneralInfo_JobStatus.Size = New System.Drawing.Size(105, 20)
            Me.LabelGeneralInfo_JobStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInfo_JobStatus.TabIndex = 15
            Me.LabelGeneralInfo_JobStatus.Text = "Job Status:"
            '
            'LabelGeneralInfo_Comments
            '
            Me.LabelGeneralInfo_Comments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInfo_Comments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInfo_Comments.Location = New System.Drawing.Point(368, 134)
            Me.LabelGeneralInfo_Comments.Name = "LabelGeneralInfo_Comments"
            Me.LabelGeneralInfo_Comments.Size = New System.Drawing.Size(105, 20)
            Me.LabelGeneralInfo_Comments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInfo_Comments.TabIndex = 16
            Me.LabelGeneralInfo_Comments.Text = "Comments:"
            '
            'LabelGeneralInfo_AccountExecutive
            '
            Me.LabelGeneralInfo_AccountExecutive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInfo_AccountExecutive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInfo_AccountExecutive.Location = New System.Drawing.Point(367, 30)
            Me.LabelGeneralInfo_AccountExecutive.Name = "LabelGeneralInfo_AccountExecutive"
            Me.LabelGeneralInfo_AccountExecutive.Size = New System.Drawing.Size(105, 20)
            Me.LabelGeneralInfo_AccountExecutive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInfo_AccountExecutive.TabIndex = 12
            Me.LabelGeneralInfo_AccountExecutive.Text = "Account Executive:"
            '
            'LabelGeneralInfo_JobStartDate
            '
            Me.LabelGeneralInfo_JobStartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInfo_JobStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInfo_JobStartDate.Location = New System.Drawing.Point(367, 56)
            Me.LabelGeneralInfo_JobStartDate.Name = "LabelGeneralInfo_JobStartDate"
            Me.LabelGeneralInfo_JobStartDate.Size = New System.Drawing.Size(105, 20)
            Me.LabelGeneralInfo_JobStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInfo_JobStartDate.TabIndex = 13
            Me.LabelGeneralInfo_JobStartDate.Text = "Job Start Date:"
            '
            'LabelGeneralInfo_JobDueDate
            '
            Me.LabelGeneralInfo_JobDueDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInfo_JobDueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInfo_JobDueDate.Location = New System.Drawing.Point(367, 82)
            Me.LabelGeneralInfo_JobDueDate.Name = "LabelGeneralInfo_JobDueDate"
            Me.LabelGeneralInfo_JobDueDate.Size = New System.Drawing.Size(105, 20)
            Me.LabelGeneralInfo_JobDueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInfo_JobDueDate.TabIndex = 14
            Me.LabelGeneralInfo_JobDueDate.Text = "Job Due Date:"
            '
            'LabelGeneralInfo_Job
            '
            Me.LabelGeneralInfo_Job.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInfo_Job.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInfo_Job.Location = New System.Drawing.Point(4, 108)
            Me.LabelGeneralInfo_Job.Name = "LabelGeneralInfo_Job"
            Me.LabelGeneralInfo_Job.Size = New System.Drawing.Size(65, 20)
            Me.LabelGeneralInfo_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInfo_Job.TabIndex = 10
            Me.LabelGeneralInfo_Job.Text = "Job:"
            '
            'LabelGeneralInfo_Component
            '
            Me.LabelGeneralInfo_Component.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInfo_Component.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInfo_Component.Location = New System.Drawing.Point(4, 134)
            Me.LabelGeneralInfo_Component.Name = "LabelGeneralInfo_Component"
            Me.LabelGeneralInfo_Component.Size = New System.Drawing.Size(65, 20)
            Me.LabelGeneralInfo_Component.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInfo_Component.TabIndex = 11
            Me.LabelGeneralInfo_Component.Text = "Component:"
            '
            'SearchableComboBoxGeneralInfo_Division
            '
            Me.SearchableComboBoxGeneralInfo_Division.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralInfo_Division.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneralInfo_Division.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralInfo_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Division
            Me.SearchableComboBoxGeneralInfo_Division.DataSource = Nothing
            Me.SearchableComboBoxGeneralInfo_Division.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralInfo_Division.DisplayName = ""
            Me.SearchableComboBoxGeneralInfo_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxGeneralInfo_Division.Location = New System.Drawing.Point(74, 56)
            Me.SearchableComboBoxGeneralInfo_Division.Name = "SearchableComboBoxGeneralInfo_Division"
            Me.SearchableComboBoxGeneralInfo_Division.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralInfo_Division.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneralInfo_Division.Properties.NullText = "Select Division"
            Me.SearchableComboBoxGeneralInfo_Division.Properties.ShowClearButton = False
            Me.SearchableComboBoxGeneralInfo_Division.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneralInfo_Division.Properties.View = Me.GridView5
            Me.SearchableComboBoxGeneralInfo_Division.SecurityEnabled = True
            Me.SearchableComboBoxGeneralInfo_Division.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralInfo_Division.Size = New System.Drawing.Size(287, 20)
            Me.SearchableComboBoxGeneralInfo_Division.TabIndex = 9
            '
            'GridView5
            '
            Me.GridView5.AFActiveFilterString = ""
            Me.GridView5.AllowExtraItemsInGridLookupEdits = True
            Me.GridView5.AutoFilterLookupColumns = False
            Me.GridView5.AutoloadRepositoryDatasource = True
            Me.GridView5.DataSourceClearing = False
            Me.GridView5.EnableDisabledRows = False
            Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView5.Name = "GridView5"
            Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView5.OptionsView.ShowGroupPanel = False
            Me.GridView5.RunStandardValidation = True
            '
            'SearchableComboBoxGeneralInfo_Client
            '
            Me.SearchableComboBoxGeneralInfo_Client.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralInfo_Client.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxGeneralInfo_Client.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralInfo_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Client
            Me.SearchableComboBoxGeneralInfo_Client.DataSource = Nothing
            Me.SearchableComboBoxGeneralInfo_Client.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralInfo_Client.DisplayName = ""
            Me.SearchableComboBoxGeneralInfo_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxGeneralInfo_Client.Location = New System.Drawing.Point(74, 30)
            Me.SearchableComboBoxGeneralInfo_Client.Name = "SearchableComboBoxGeneralInfo_Client"
            Me.SearchableComboBoxGeneralInfo_Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralInfo_Client.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneralInfo_Client.Properties.NullText = "Select Client"
            Me.SearchableComboBoxGeneralInfo_Client.Properties.ShowClearButton = False
            Me.SearchableComboBoxGeneralInfo_Client.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneralInfo_Client.Properties.View = Me.GridView6
            Me.SearchableComboBoxGeneralInfo_Client.SecurityEnabled = True
            Me.SearchableComboBoxGeneralInfo_Client.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralInfo_Client.Size = New System.Drawing.Size(287, 20)
            Me.SearchableComboBoxGeneralInfo_Client.TabIndex = 7
            '
            'GridView6
            '
            Me.GridView6.AFActiveFilterString = ""
            Me.GridView6.AllowExtraItemsInGridLookupEdits = True
            Me.GridView6.AutoFilterLookupColumns = False
            Me.GridView6.AutoloadRepositoryDatasource = True
            Me.GridView6.DataSourceClearing = False
            Me.GridView6.EnableDisabledRows = False
            Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView6.Name = "GridView6"
            Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView6.OptionsView.ShowGroupPanel = False
            Me.GridView6.RunStandardValidation = True
            '
            'LabelGeneralInfo_Client
            '
            Me.LabelGeneralInfo_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInfo_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInfo_Client.Location = New System.Drawing.Point(3, 30)
            Me.LabelGeneralInfo_Client.Name = "LabelGeneralInfo_Client"
            Me.LabelGeneralInfo_Client.Size = New System.Drawing.Size(65, 20)
            Me.LabelGeneralInfo_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInfo_Client.TabIndex = 0
            Me.LabelGeneralInfo_Client.Text = "Client:"
            '
            'LabelGeneralInfo_Division
            '
            Me.LabelGeneralInfo_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInfo_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInfo_Division.Location = New System.Drawing.Point(3, 56)
            Me.LabelGeneralInfo_Division.Name = "LabelGeneralInfo_Division"
            Me.LabelGeneralInfo_Division.Size = New System.Drawing.Size(65, 20)
            Me.LabelGeneralInfo_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInfo_Division.TabIndex = 6
            Me.LabelGeneralInfo_Division.Text = "Division:"
            '
            'LabelGeneralInfo_Product
            '
            Me.LabelGeneralInfo_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInfo_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInfo_Product.Location = New System.Drawing.Point(3, 82)
            Me.LabelGeneralInfo_Product.Name = "LabelGeneralInfo_Product"
            Me.LabelGeneralInfo_Product.Size = New System.Drawing.Size(65, 20)
            Me.LabelGeneralInfo_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInfo_Product.TabIndex = 8
            Me.LabelGeneralInfo_Product.Text = "Product:"
            '
            'DataGridViewEmployees_Employees
            '
            Me.DataGridViewEmployees_Employees.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewEmployees_Employees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewEmployees_Employees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewEmployees_Employees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewEmployees_Employees.AutoFilterLookupColumns = False
            Me.DataGridViewEmployees_Employees.AutoloadRepositoryDatasource = True
            Me.DataGridViewEmployees_Employees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewEmployees_Employees.DataSource = Nothing
            Me.DataGridViewEmployees_Employees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewEmployees_Employees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewEmployees_Employees.ItemDescription = "Item(s)"
            Me.DataGridViewEmployees_Employees.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewEmployees_Employees.MultiSelect = True
            Me.DataGridViewEmployees_Employees.Name = "DataGridViewEmployees_Employees"
            Me.DataGridViewEmployees_Employees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewEmployees_Employees.RunStandardValidation = True
            Me.DataGridViewEmployees_Employees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewEmployees_Employees.Size = New System.Drawing.Size(761, 365)
            Me.DataGridViewEmployees_Employees.TabIndex = 0
            Me.DataGridViewEmployees_Employees.UseEmbeddedNavigator = False
            Me.DataGridViewEmployees_Employees.ViewCaptionHeight = -1
            '
            'JobComponentTaskControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlControl_TaskDetails)
            Me.Controls.Add(Me.ExpandablePanelControl_General)
            Me.Name = "JobComponentTaskControl"
            Me.Size = New System.Drawing.Size(769, 560)
            Me.ExpandablePanelControl_General.ResumeLayout(False)
            CType(Me.TabControlControl_TaskDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_TaskDetails.ResumeLayout(False)
            Me.TabControlPanelCommentsTab_Comments.ResumeLayout(False)
            Me.TabControlPanelClientContactsTab_ClientContacts.ResumeLayout(False)
            Me.TabControlPanelEmployeesTab_Employees.ResumeLayout(False)
            Me.TabControlPanelSettingsTab_Settings.ResumeLayout(False)
            CType(Me.NumericInputSettings_DefaultHoursAllowed.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputSettings_DaysDuration.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputSettings_Order.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerSettings_OriginalDueDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSettings_EstimateFunction.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelDetailsTab_Details.ResumeLayout(False)
            CType(Me.DateTimePickerDetails_TempComplete, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlDetails_Comments, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlDetails_Comments.ResumeLayout(False)
            Me.TabControlPanelTaskCommentsTab_TaskComments.ResumeLayout(False)
            Me.TabControlPanelDueDateCommentsTab_DueDateComments.ResumeLayout(False)
            Me.TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments.ResumeLayout(False)
            CType(Me.DateTimePickerDetails_CompletedDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerDetails_DueDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerDetails_StartDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxDetails_TaskStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxDetails_Task.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxDetails_Phase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerGeneralInfo_JobDueDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerGeneralInfo_JobStartDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneralInfo_JobStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView11, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneralInfo_Component.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneralInfo_AccountExecutive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView9, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneralInfo_Job.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneralInfo_Product.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneralInfo_Division.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneralInfo_Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlControl_TaskDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelDetailsTab_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTaskDetails_DetailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSettingsTab_Settings As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTaskDetails_SettingsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelDetails_CompletedDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDetails_TimeDue As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDetails_TempComplete As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDetails_DueDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDetails_StartDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDetails_TaskStatus As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDetails_Task As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDetails_Phase As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlPanelEmployeesTab_Employees As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTaskDetails_EmployeesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCommentsTab_Comments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTaskDetails_CommentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlDetails_Comments As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelDueDateCommentsTab_DueDateComments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemDetails_DueDateCommentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelRevisedDueDateCommentsTab_RevisedDueDateComments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemDetails_RevisedDueDateCommentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelTaskCommentsTab_TaskComments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemDetails_TaskCommentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TextBoxDetails_TimeDue As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents DateTimePickerDetails_CompletedDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerDetails_DueDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerDetails_StartDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents SearchableComboBoxDetails_TaskStatus As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxDetails_Task As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxDetails_Phase As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBox1View As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents TabControlPanelClientContactsTab_ClientContacts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTaskDetails_ClientContactsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TextBoxTaskComments_Comments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxDueDateComments_Comments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxRevisedDueDateComments_Comments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxSettings_Milestone As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSettings_Locked As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DateTimePickerSettings_OriginalDueDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents SearchableComboBoxSettings_EstimateFunction As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView3 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelSettings_Locked As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettings_OriginalDueDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettings_EstimateFunction As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettings_Milestone As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettings_DefaultHoursAllowed As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettings_Days As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettings_Order As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputSettings_DefaultHoursAllowed As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputSettings_DaysDuration As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputSettings_Order As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents MultiSelectControlClientContacts_ClientContacts As AdvantageFramework.WinForm.Presentation.Controls.MultiSelectControl
        Friend WithEvents TextBoxCommentLog_Comments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelGeneralInfo_Job As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralInfo_Component As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralInfo_JobStatus As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralInfo_Comments As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralInfo_AccountExecutive As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralInfo_JobStartDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ExpandablePanelControl_General As DevComponents.DotNetBar.ExpandablePanel
        Friend WithEvents SearchableComboBoxGeneralInfo_JobStatus As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView11 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGeneralInfo_Component As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView8 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGeneralInfo_AccountExecutive As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView9 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGeneralInfo_Job As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView4 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGeneralInfo_Product As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView7 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelGeneralInfo_JobDueDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxGeneralInfo_Division As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView5 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGeneralInfo_Client As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView6 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelGeneralInfo_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralInfo_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralInfo_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneralInfo_Comments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents DateTimePickerGeneralInfo_JobDueDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerGeneralInfo_JobStartDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents TextBoxDetails_TaskDescription As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents DateTimePickerDetails_TempComplete As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DataGridViewEmployees_Employees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView

    End Class

End Namespace
