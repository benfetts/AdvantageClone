Namespace Desktop.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CalendarForm
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
            Dim TimeRuler1 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Dim TimeRuler2 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CalendarForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Include = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.SchedulerForm_Calendar = New DevExpress.XtraScheduler.SchedulerControl()
            Me.SchedulerStorage = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
            Me.CalendarItemBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.SchedulerForm_Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SchedulerStorage, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CalendarItemBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Include)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 322)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(676, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 3
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_Include
            '
            Me.RibbonBarOptions_Include.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Include.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Include.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Include.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Include.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Include.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Include.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1, Me.ButtonItem2, Me.ButtonItem3, Me.ButtonItem4, Me.ButtonItem5})
            Me.RibbonBarOptions_Include.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Include.Location = New System.Drawing.Point(76, 0)
            Me.RibbonBarOptions_Include.Name = "RibbonBarOptions_Include"
            Me.RibbonBarOptions_Include.Size = New System.Drawing.Size(268, 98)
            Me.RibbonBarOptions_Include.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Include.TabIndex = 2
            Me.RibbonBarOptions_Include.Text = "Include"
            '
            '
            '
            Me.RibbonBarOptions_Include.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Include.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Include.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItem1
            '
            Me.ButtonItem1.AutoCheckOnClick = True
            Me.ButtonItem1.BeginGroup = True
            Me.ButtonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem1.Name = "ButtonItem1"
            Me.ButtonItem1.RibbonWordWrap = False
            Me.ButtonItem1.SubItemsExpandWidth = 14
            Me.ButtonItem1.Text = "Tasks"
            '
            'ButtonItem2
            '
            Me.ButtonItem2.AutoCheckOnClick = True
            Me.ButtonItem2.BeginGroup = True
            Me.ButtonItem2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem2.Name = "ButtonItem2"
            Me.ButtonItem2.RibbonWordWrap = False
            Me.ButtonItem2.SubItemsExpandWidth = 14
            Me.ButtonItem2.Text = "Holidays"
            '
            'ButtonItem3
            '
            Me.ButtonItem3.AutoCheckOnClick = True
            Me.ButtonItem3.BeginGroup = True
            Me.ButtonItem3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem3.Name = "ButtonItem3"
            Me.ButtonItem3.RibbonWordWrap = False
            Me.ButtonItem3.SubItemsExpandWidth = 14
            Me.ButtonItem3.Text = "Activities"
            '
            'ButtonItem4
            '
            Me.ButtonItem4.AutoCheckOnClick = True
            Me.ButtonItem4.BeginGroup = True
            Me.ButtonItem4.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem4.Name = "ButtonItem4"
            Me.ButtonItem4.RibbonWordWrap = False
            Me.ButtonItem4.SubItemsExpandWidth = 14
            Me.ButtonItem4.Text = "Events"
            '
            'ButtonItem5
            '
            Me.ButtonItem5.AutoCheckOnClick = True
            Me.ButtonItem5.BeginGroup = True
            Me.ButtonItem5.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem5.Name = "ButtonItem5"
            Me.ButtonItem5.RibbonWordWrap = False
            Me.ButtonItem5.SubItemsExpandWidth = 14
            Me.ButtonItem5.Text = "Event Tasks"
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
            Me.RibbonBarOptions_Actions.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(76, 98)
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
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'SchedulerForm_Calendar
            '
            Me.SchedulerForm_Calendar.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month
            Me.SchedulerForm_Calendar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SchedulerForm_Calendar.Location = New System.Drawing.Point(12, 12)
            Me.SchedulerForm_Calendar.Name = "SchedulerForm_Calendar"
            Me.SchedulerForm_Calendar.OptionsBehavior.ShowRemindersForm = False
            Me.SchedulerForm_Calendar.OptionsView.NavigationButtons.Visibility = DevExpress.XtraScheduler.NavigationButtonVisibility.Never
            Me.SchedulerForm_Calendar.Size = New System.Drawing.Size(676, 408)
            Me.SchedulerForm_Calendar.Start = New Date(2013, 10, 20, 0, 0, 0, 0)
            Me.SchedulerForm_Calendar.Storage = Me.SchedulerStorage
            Me.SchedulerForm_Calendar.TabIndex = 4
            Me.SchedulerForm_Calendar.Views.DayView.TimeRulers.Add(TimeRuler1)
            Me.SchedulerForm_Calendar.Views.MonthView.CompressWeekend = False
            Me.SchedulerForm_Calendar.Views.MonthView.DateTimeScrollbarVisible = False
            Me.SchedulerForm_Calendar.Views.MonthView.NavigationButtonVisibility = DevExpress.XtraScheduler.NavigationButtonVisibility.Never
            Me.SchedulerForm_Calendar.Views.WorkWeekView.TimeRulers.Add(TimeRuler2)
            '
            'SchedulerStorage
            '
            Me.SchedulerStorage.Appointments.DataSource = Me.CalendarItemBindingSource
            Me.SchedulerStorage.Appointments.Labels.CreateNewLabel(System.Drawing.SystemColors.Window, "None", "&None")
            Me.SchedulerStorage.Appointments.Labels.CreateNewLabel(System.Drawing.Color.LightSkyBlue, "Activities", "")
            Me.SchedulerStorage.Appointments.Labels.CreateNewLabel(System.Drawing.Color.PaleGreen, "Tasks", "")
            Me.SchedulerStorage.Appointments.Labels.CreateNewLabel(System.Drawing.Color.IndianRed, "Holidays", "")
            Me.SchedulerStorage.Appointments.Labels.CreateNewLabel(System.Drawing.Color.SandyBrown, "Events", "")
            Me.SchedulerStorage.Appointments.Labels.CreateNewLabel(System.Drawing.Color.Purple, "Event Tasks", "")
            Me.SchedulerStorage.Appointments.Mappings.AllDay = "ALL_DAY"
            Me.SchedulerStorage.Appointments.Mappings.AppointmentId = "ID"
            Me.SchedulerStorage.Appointments.Mappings.Description = "TASK_NON_TASK_DISPLAY"
            Me.SchedulerStorage.Appointments.Mappings.End = "END_TIME"
            Me.SchedulerStorage.Appointments.Mappings.Label = "REC_TYPE"
            Me.SchedulerStorage.Appointments.Mappings.Start = "START_TIME"
            Me.SchedulerStorage.Appointments.Mappings.Subject = "TASK_NON_TASK_DESCRIPTION"
            '
            'CalendarItemBindingSource
            '
            Me.CalendarItemBindingSource.DataSource = GetType(AdvantageFramework.Database.Classes.CalendarItem)
            '
            'CalendarForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(700, 432)
            Me.Controls.Add(Me.SchedulerForm_Calendar)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "CalendarForm"
            Me.Text = "Calendar"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.SchedulerForm_Calendar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SchedulerStorage, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CalendarItemBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents SchedulerForm_Calendar As DevExpress.XtraScheduler.SchedulerControl
        Friend WithEvents SchedulerStorage As DevExpress.XtraScheduler.SchedulerStorage
        Friend WithEvents RibbonBarOptions_Include As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents CalendarItemBindingSource As System.Windows.Forms.BindingSource
    End Class

End Namespace