Namespace ProjectManagement.Presentation

    Public Class ProjectScheduleGanttViewDialog2

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _JobTrafficID As Integer = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property JobTrafficID As Integer
            Get
                JobTrafficID = _JobTrafficID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal JobTrafficID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _JobTrafficID = JobTrafficID

        End Sub
        Private Sub MapResources()

            'objects
            Dim ResourceMappingInfo As DevExpress.XtraScheduler.ResourceMappingInfo = Nothing

            ResourceMappingInfo = SchedulerStorageForm_Storage.Resources.Mappings

            ResourceMappingInfo.Id = AdvantageFramework.ProjectSchedule.Classes.CustomResource.Properties.ID.ToString
            'ResourceMappingInfo. = AdvantageFramework.ProjectSchedule.Classes.CustomResource.Properties.IDSort.ToString
            ResourceMappingInfo.ParentId = AdvantageFramework.ProjectSchedule.Classes.CustomResource.Properties.ParentID.ToString
            ResourceMappingInfo.Caption = AdvantageFramework.ProjectSchedule.Classes.CustomResource.Properties.Description.ToString
            ResourceMappingInfo.Color = AdvantageFramework.ProjectSchedule.Classes.CustomResource.Properties.Color.ToString
            ResourceMappingInfo.Image = AdvantageFramework.ProjectSchedule.Classes.CustomResource.Properties.Image.ToString
            'ResourceMappingInfo. = AdvantageFramework.ProjectSchedule.Classes.CustomResource.Properties.CustomField1.ToString

            If ResourcesTree1.Columns("Description") Is Nothing Then

                Dim DescriptionField As DevExpress.XtraTreeList.Columns.TreeListColumn = Nothing

                DescriptionField = ResourcesTree1.Columns.AddField("Description")
                DescriptionField.Visible = True

            End If

            If ResourcesTree1.Columns("ID") Is Nothing Then

                Dim IDField As DevExpress.XtraTreeList.Columns.TreeListColumn = Nothing

                IDField = ResourcesTree1.Columns.AddField("ID")
                IDField.Visible = False

            End If

        End Sub
        Private Sub MapAppointments()

            'objects
            Dim AppointmentMappingInfo As DevExpress.XtraScheduler.AppointmentMappingInfo = Nothing

            AppointmentMappingInfo = SchedulerStorageForm_Storage.Appointments.Mappings

            AppointmentMappingInfo.AppointmentId = AdvantageFramework.ProjectSchedule.Classes.CustomAppointment.Properties.ID.ToString
            AppointmentMappingInfo.Type = AdvantageFramework.ProjectSchedule.Classes.CustomAppointment.Properties.Type.ToString
            AppointmentMappingInfo.Start = AdvantageFramework.ProjectSchedule.Classes.CustomAppointment.Properties.StartDate.ToString
            AppointmentMappingInfo.End = AdvantageFramework.ProjectSchedule.Classes.CustomAppointment.Properties.EndDate.ToString
            AppointmentMappingInfo.AllDay = AdvantageFramework.ProjectSchedule.Classes.CustomAppointment.Properties.AllDay.ToString
            AppointmentMappingInfo.Subject = AdvantageFramework.ProjectSchedule.Classes.CustomAppointment.Properties.Subject.ToString
            AppointmentMappingInfo.Location = AdvantageFramework.ProjectSchedule.Classes.CustomAppointment.Properties.Location.ToString
            AppointmentMappingInfo.Description = AdvantageFramework.ProjectSchedule.Classes.CustomAppointment.Properties.Description.ToString
            AppointmentMappingInfo.Status = AdvantageFramework.ProjectSchedule.Classes.CustomAppointment.Properties.Status.ToString
            AppointmentMappingInfo.Label = AdvantageFramework.ProjectSchedule.Classes.CustomAppointment.Properties.Label.ToString
            AppointmentMappingInfo.ResourceId = AdvantageFramework.ProjectSchedule.Classes.CustomAppointment.Properties.ResourceID.ToString
            'AppointmentMappingInfo. = AdvantageFramework.ProjectSchedule.Classes.CustomAppointment.Properties.ResourceIDs.ToString
            AppointmentMappingInfo.ReminderInfo = AdvantageFramework.ProjectSchedule.Classes.CustomAppointment.Properties.ReminderInfo.ToString
            AppointmentMappingInfo.RecurrenceInfo = AdvantageFramework.ProjectSchedule.Classes.CustomAppointment.Properties.RecurrenceInfo.ToString
            AppointmentMappingInfo.PercentComplete = AdvantageFramework.ProjectSchedule.Classes.CustomAppointment.Properties.PercentComplete.ToString
            'AppointmentMappingInfo. = AdvantageFramework.ProjectSchedule.Classes.CustomAppointment.Properties.CustomField1.ToString

            If SchedulerStorageForm_Storage.Appointments.CustomFieldMappings(AdvantageFramework.ProjectSchedule.Classes.CustomAppointment.Properties.CustomField1.ToString) Is Nothing Then

                SchedulerStorageForm_Storage.Appointments.CustomFieldMappings.Add(New DevExpress.XtraScheduler.AppointmentCustomFieldMapping("CustomField1", "CustomField1"))

            End If

        End Sub
        Private Sub MapDependencies()

            'objects
            Dim AppointmentDependencyMappingInfo As DevExpress.XtraScheduler.AppointmentDependencyMappingInfo = Nothing

            AppointmentDependencyMappingInfo = SchedulerStorageForm_Storage.AppointmentDependencies.Mappings

            AppointmentDependencyMappingInfo.DependentId = AdvantageFramework.ProjectSchedule.Classes.CustomDependency.Properties.DependentID.ToString
            AppointmentDependencyMappingInfo.ParentId = AdvantageFramework.ProjectSchedule.Classes.CustomDependency.Properties.ParentID.ToString
            AppointmentDependencyMappingInfo.Type = AdvantageFramework.ProjectSchedule.Classes.CustomDependency.Properties.Type.ToString

        End Sub
        Private Sub MapSchedule()

            MapResources()
            MapAppointments()
            MapDependencies()

        End Sub
        Private Sub LoadChart()

            'objects
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim CustomResource As AdvantageFramework.ProjectSchedule.Classes.CustomResource = Nothing
            Dim Resources As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.CustomResource) = Nothing
            Dim CustomAppointment As AdvantageFramework.ProjectSchedule.Classes.CustomAppointment = Nothing
            Dim Appointments As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.CustomAppointment) = Nothing
            Dim CustomDependency As AdvantageFramework.ProjectSchedule.Classes.CustomDependency = Nothing
            Dim Dependencies As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.CustomDependency) = Nothing
            Dim ScheduleTasks As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
            Dim JobComponentList As Generic.List(Of String) = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Integer = Nothing

            Dim CurrentJobID As Integer = 0
            Dim CurrentPhaseID As Integer = 0
            Dim CurrentTaskID As Integer = 0

            Dim CurrentResourceID As Integer = 0
            Dim CurrentAppointmentID As Integer = 0
            Dim CurrentDependencyID As Integer = 0
            Dim ParentID As Integer = 0

            Dim StartDate As Date = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByID(DbContext, _JobTrafficID)

                If JobTraffic IsNot Nothing Then

                    Resources = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.CustomResource)
                    Appointments = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.CustomAppointment)
                    Dependencies = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.CustomDependency)

                    JobComponentList = New Generic.List(Of String)

                    JobComponentList.Add(JobTraffic.JobNumber.ToString & "," & JobTraffic.JobComponentNumber.ToString)

                    If CheckBoxItemOptions_RelatedJobs.Checked Then

                        For Each JobTrafficPredecessor In AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumber(DbContext, JobTraffic.JobNumber, JobTraffic.JobComponentNumber)

                            JobComponentList.Add(JobTrafficPredecessor.JobPredecessor.ToString & "," & JobTrafficPredecessor.JobComponentPredecessor.ToString)

                        Next

                    End If

                    For Each JobComponentString In JobComponentList

                        JobNumber = CInt(JobComponentString.Split(",").FirstOrDefault)
                        JobComponentNumber = CShort(JobComponentString.Split(",").Last)

                        JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                        If JobTraffic IsNot Nothing Then

                            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobTraffic.JobNumber, JobTraffic.JobComponentNumber)

                            If StartDate = Nothing OrElse (JobComponent.StartDate.HasValue AndAlso JobComponent.StartDate < StartDate) Then

                                StartDate = JobComponent.StartDate

                            End If

                            CustomResource = CreateCustomResource(CurrentResourceID, GetJobComponentDescription(JobComponent.JobNumber, JobComponent.Number, JobComponent.Description))
                            CustomAppointment = CreateCustomAppointment(CurrentResourceID, CurrentResourceID, GetJobComponentDescription(JobComponent.JobNumber, JobComponent.Number, JobComponent.Description), JobComponent.StartDate, JobComponent.DueDate)
                            CustomDependency = CreateCustomDependency(CurrentResourceID)

                            Resources.Add(CustomResource)
                            Appointments.Add(CustomAppointment)
                            Dependencies.Add(CustomDependency)

                            CurrentResourceID += 1
                            CurrentAppointmentID += 1
                            CurrentDependencyID += 1

                            ScheduleTasks = LoadScheduleTasks(JobNumber, JobComponentNumber)

                            For Each ScheduleTask In ScheduleTasks

                                ParentID = CurrentJobID

                                If CheckBoxItemOptions_Phase.Checked Then

                                    If ScheduleTask.PhaseStartDate.HasValue Then

                                        If CurrentPhaseID = 0 OrElse CurrentPhaseID <> ScheduleTask.TrafficPhaseID Then

                                            CurrentPhaseID = ScheduleTask.TrafficPhaseID
                                            ParentID = CurrentResourceID

                                            CustomResource = CreateCustomResource(CurrentResourceID, ScheduleTask.PhaseDescription, CurrentJobID)
                                            'CustomAppointment = CreateCustomAppointment(CurrentAppointmentID, CurrentResourceID, ScheduleTask.PhaseDescription, ScheduleTask.PhaseStartDate, If(ScheduleTask.PhaseEndDate.HasValue, ScheduleTask.PhaseEndDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59), Nothing))
                                            CustomAppointment = CreateCustomAppointment(CurrentAppointmentID, CurrentResourceID, ScheduleTask.PhaseDescription, ScheduleTask.PhaseStartDate, ScheduleTask.PhaseEndDate)
                                            CustomDependency = CreateCustomDependency(CurrentDependencyID)

                                            Resources.Add(CustomResource)
                                            Appointments.Add(CustomAppointment)
                                            Dependencies.Add(CustomDependency)

                                            CurrentResourceID += 1
                                            CurrentAppointmentID += 1
                                            CurrentDependencyID += 1

                                        End If

                                    End If

                                End If

                                CustomResource = CreateCustomResource(CurrentResourceID, ScheduleTask.TaskDescription, ParentID)
                                'CustomAppointment = CreateCustomAppointment(CurrentAppointmentID, CurrentResourceID, ScheduleTask.TaskDescription, ScheduleTask.TaskStartDate, If(ScheduleTask.JobRevisedDate.HasValue, ScheduleTask.JobRevisedDate.Value.AddDays(1).AddSeconds(-1), Nothing))
                                CustomAppointment = CreateCustomAppointment(CurrentAppointmentID, CurrentResourceID, ScheduleTask.TaskDescription, ScheduleTask.TaskStartDate, ScheduleTask.JobRevisedDate)
                                CustomAppointment.CustomField1 = ScheduleTask
                                CustomDependency = CreateCustomDependency(CurrentDependencyID)

                                Resources.Add(CustomResource)
                                Appointments.Add(CustomAppointment)
                                Dependencies.Add(CustomDependency)

                                CurrentResourceID += 1
                                CurrentAppointmentID += 1
                                CurrentDependencyID += 1

                            Next

                        End If

                        CurrentJobID += 1

                    Next

                    SchedulerStorageForm_Storage.Resources.DataSource = Resources
                    SchedulerStorageForm_Storage.Appointments.DataSource = Appointments
                    SchedulerStorageForm_Storage.AppointmentDependencies.DataSource = Dependencies
                    SchedulerControlForm_Scheduler.OptionsView.ResourceHeaders.RotateCaption = False
                    SchedulerControlForm_Scheduler.Start = StartDate



                End If

            End Using

        End Sub
        Private Sub LoadChart(ByVal asdf As Boolean)

            'objects
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim ScheduleTasks As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
            Dim CustomResource As AdvantageFramework.ProjectSchedule.Classes.CustomResource = Nothing
            Dim Resources As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.CustomResource) = Nothing
            Dim CustomAppointment As AdvantageFramework.ProjectSchedule.Classes.CustomAppointment = Nothing
            Dim Appointments As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.CustomAppointment) = Nothing
            Dim CustomDependency As AdvantageFramework.ProjectSchedule.Classes.CustomDependency = Nothing
            Dim CustomDependencies As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.CustomDependency) = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim PhaseID As Integer = 0
            Dim CustomID As Integer = -1000

            Dim CurrentResourceID As Integer = 0
            Dim CurrentAppointmentID As Integer = 0
            Dim CurrentDependencyID As Integer = 0
            Dim ParentID As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByID(DbContext, _JobTrafficID)

                If JobTraffic IsNot Nothing Then

                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobTraffic.JobNumber, JobTraffic.JobComponentNumber)

                    SchedulerControlForm_Scheduler.Start = JobComponent.StartDate

                    Resources = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.CustomResource)
                    Appointments = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.CustomAppointment)
                    CustomDependencies = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.CustomDependency)

                    CustomResource = CreateCustomResource(CurrentResourceID, GetJobComponentDescription(JobComponent.JobNumber, JobComponent.Number, JobComponent.Description))
                    CustomAppointment = CreateCustomAppointment(CurrentAppointmentID, CurrentResourceID, GetJobComponentDescription(JobComponent.JobNumber, JobComponent.Number, JobComponent.Description), JobComponent.StartDate, JobComponent.DueDate)
                    CustomDependency = CreateCustomDependency(CurrentDependencyID)

                    Resources.Add(CustomResource)
                    Appointments.Add(CustomAppointment)
                    CustomDependencies.Add(CustomDependency)

                    ScheduleTasks = LoadScheduleTasks(JobTraffic.JobNumber, JobTraffic.JobComponentNumber)

                    For Each ScheduleTask In ScheduleTasks

                        CurrentResourceID += 1
                        CurrentAppointmentID += 1
                        CurrentDependencyID += 1

                        If CheckBoxItemOptions_Phase.Checked Then

                            If ScheduleTask.PhaseStartDate.HasValue Then

                                If PhaseID = 0 OrElse PhaseID <> ScheduleTask.TrafficPhaseID Then

                                    CustomResource = CreateCustomResource(CurrentResourceID, ScheduleTask.PhaseDescription, CurrentResourceID - 1)
                                    CustomAppointment = CreateCustomAppointment(CurrentAppointmentID, CurrentResourceID, ScheduleTask.PhaseDescription, ScheduleTask.PhaseStartDate, ScheduleTask.PhaseEndDate)
                                    CustomDependency = CreateCustomDependency(CurrentDependencyID)

                                    Resources.Add(CustomResource)
                                    Appointments.Add(CustomAppointment)
                                    CustomDependencies.Add(CustomDependency)

                                    CurrentResourceID += 1
                                    CurrentAppointmentID += 1
                                    CurrentDependencyID += 1

                                End If

                            End If

                        End If

                        CustomResource = CreateCustomResource(CurrentResourceID, ScheduleTask.TaskDescription, CurrentResourceID - 1)
                        CustomAppointment = CreateCustomAppointment(CurrentAppointmentID, CurrentResourceID, ScheduleTask.TaskDescription, ScheduleTask.TaskStartDate, ScheduleTask.JobRevisedDate)
                        CustomDependency = CreateCustomDependency(CurrentDependencyID)

                        Resources.Add(CustomResource)
                        Appointments.Add(CustomAppointment)
                        CustomDependencies.Add(CustomDependency)

                    Next

                    SchedulerStorageForm_Storage.Resources.DataSource = Resources
                    SchedulerStorageForm_Storage.Appointments.DataSource = Appointments
                    SchedulerStorageForm_Storage.AppointmentDependencies.DataSource = CustomDependencies
                    SchedulerControlForm_Scheduler.OptionsView.ResourceHeaders.RotateCaption = False

                    ResourcesTree1.SchedulerControl = SchedulerControlForm_Scheduler

                End If

            End Using

        End Sub
        Private Function LoadScheduleTasks(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If CheckBoxItemOptions_Phase.Checked Then

                    LoadScheduleTasks = AdvantageFramework.ProjectSchedule.GetScheduleTasks(DbContext, JobNumber, JobComponentNumber, "phase", Me.Session.UserCode, "", "", "", True, False, False, "", "", True).ToList

                Else

                    LoadScheduleTasks = AdvantageFramework.ProjectSchedule.GetScheduleTasks(DbContext, JobNumber, JobComponentNumber, "", Me.Session.UserCode, "", "", "", True, False, False, "", "", True).ToList

                End If

            End Using

        End Function
        Private Function CreateCustomResource(ByVal ID As Integer, ByVal Description As String, Optional ByVal ParentID As Integer = -1) As AdvantageFramework.ProjectSchedule.Classes.CustomResource

            'objects
            Dim CustomResource As AdvantageFramework.ProjectSchedule.Classes.CustomResource = Nothing

            Try

                CustomResource = New AdvantageFramework.ProjectSchedule.Classes.CustomResource

                CustomResource.ID = ID
                CustomResource.Description = Description

                If ParentID >= 0 Then

                    CustomResource.ParentID = ParentID

                Else

                    CustomResource.Color = Drawing.Color.Red

                End If

            Catch ex As Exception
                CustomResource = Nothing
            Finally
                CreateCustomResource = CustomResource
            End Try

        End Function
        Private Function CreateCustomAppointment(ByVal ID As Integer, ByVal ResourceID As Integer, ByVal Subject As String, ByVal StartDate As String, ByVal EndDate As String) As AdvantageFramework.ProjectSchedule.Classes.CustomAppointment

            'objects
            Dim CustomAppointment As AdvantageFramework.ProjectSchedule.Classes.CustomAppointment = Nothing
            Try

                CustomAppointment = New AdvantageFramework.ProjectSchedule.Classes.CustomAppointment

                CustomAppointment.ID = ID
                CustomAppointment.ResourceID = ResourceID
                CustomAppointment.Subject = Subject
                CustomAppointment.StartDate = StartDate
                CustomAppointment.EndDate = EndDate
                CustomAppointment.AllDay = True

            Catch ex As Exception
                CustomAppointment = Nothing
            Finally
                CreateCustomAppointment = CustomAppointment
            End Try

        End Function
        Private Function CreateCustomDependency(ByVal DependentID As Integer) As AdvantageFramework.ProjectSchedule.Classes.CustomDependency

            'objects
            Dim CustomDependency As AdvantageFramework.ProjectSchedule.Classes.CustomDependency = Nothing
            Try

                CustomDependency = New AdvantageFramework.ProjectSchedule.Classes.CustomDependency

                CustomDependency.DependentID = DependentID

            Catch ex As Exception
                CustomDependency = Nothing
            Finally
                CreateCustomDependency = CustomDependency
            End Try

        End Function
        Private Function GetJobComponentDescription(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal JobComponentDescription As String) As String

            GetJobComponentDescription = AdvantageFramework.StringUtilities.PadWithCharacter(JobNumber.ToString, 6, "0", True) & " - " & AdvantageFramework.StringUtilities.PadWithCharacter(JobComponentNumber.ToString, 2, "0", True) & " " & JobComponentDescription

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal JobTrafficID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim ProjectScheduleGanttViewDialog2 As AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleGanttViewDialog2 = Nothing

            ProjectScheduleGanttViewDialog2 = New AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleGanttViewDialog2(JobTrafficID)

            ShowFormDialog = ProjectScheduleGanttViewDialog2.ShowDialog()

            JobTrafficID = ProjectScheduleGanttViewDialog2.JobTrafficID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ProjectScheduleGanttViewDialog2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Loaded As Boolean = True

            ButtonItemOptions_Day.Image = AdvantageFramework.My.Resources.CalendarDayImage
            ButtonItemOptions_Month.Image = AdvantageFramework.My.Resources.CalendarImage
            ButtonItemOptions_Week.Image = AdvantageFramework.My.Resources.CalendarWeekImage
            ButtonItemOptions_Calculate.Image = AdvantageFramework.My.Resources.PercentageImage

            SchedulerControlForm_Scheduler.OptionsCustomization.AllowAppointmentCopy = DevExpress.XtraScheduler.UsedAppointmentType.None
            SchedulerControlForm_Scheduler.OptionsCustomization.AllowAppointmentCreate = DevExpress.XtraScheduler.UsedAppointmentType.None
            SchedulerControlForm_Scheduler.OptionsCustomization.AllowAppointmentEdit = DevExpress.XtraScheduler.UsedAppointmentType.All
            SchedulerControlForm_Scheduler.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.None
            SchedulerControlForm_Scheduler.OptionsCustomization.AllowAppointmentMultiSelect = False
            SchedulerControlForm_Scheduler.OptionsCustomization.AllowAppointmentDragBetweenResources = DevExpress.XtraScheduler.UsedAppointmentType.None
            SchedulerControlForm_Scheduler.OptionsCustomization.AllowInplaceEditor = DevExpress.XtraScheduler.UsedAppointmentType.None
            SchedulerControlForm_Scheduler.OptionsCustomization.AllowAppointmentConflicts = DevExpress.XtraScheduler.AppointmentConflictsMode.Forbidden
            SchedulerControlForm_Scheduler.OptionsCustomization.AllowAppointmentResize = DevExpress.XtraScheduler.UsedAppointmentType.Custom
            SchedulerControlForm_Scheduler.ResourceNavigator.Visibility = DevExpress.XtraScheduler.ResourceNavigatorVisibility.Never

            SchedulerControlForm_Scheduler.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Gantt

            SchedulerControlForm_Scheduler.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource
            SchedulerStorageForm_Storage.Appointments.CommitIdToDataSource = False

            If _JobTrafficID > 0 Then

                SchedulerControlForm_Scheduler.Storage = SchedulerStorageForm_Storage

                MapSchedule()
                LoadChart()

            Else

                Loaded = False

            End If

            If Loaded = False Then

                AdvantageFramework.Navigation.ShowMessageBox("There was a problem loading the project schedule.")
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemOptions_Day_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemOptions_Day.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                If ButtonItemOptions_Day.Checked Then

                    ButtonItemOptions_Week.Checked = False
                    ButtonItemOptions_Month.Checked = False

                End If

                LoadChart()

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemOptions_Week_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemOptions_Week.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                If ButtonItemOptions_Week.Checked Then

                    ButtonItemOptions_Day.Checked = False
                    ButtonItemOptions_Month.Checked = False

                End If

                LoadChart()

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemOptions_Month_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemOptions_Month.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                If ButtonItemOptions_Month.Checked Then

                    ButtonItemOptions_Week.Checked = False
                    ButtonItemOptions_Day.Checked = False

                End If

                LoadChart()

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub CheckBoxItemOptions_Labels_CheckedChanged(sender As Object, e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItemOptions_Labels.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                LoadChart()

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub CheckBoxItemOptions_Phase_CheckedChanged(sender As Object, e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItemOptions_Phase.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                LoadChart()

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub CheckBoxItemOptions_RelatedJobs_CheckedChanged(sender As Object, e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItemOptions_RelatedJobs.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                LoadChart()

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub

#End Region

#End Region

        Private Sub SchedulerControlForm_Scheduler_AllowAppointmentResize(sender As Object, e As DevExpress.XtraScheduler.AppointmentOperationEventArgs) Handles SchedulerControlForm_Scheduler.AllowAppointmentResize

            'objects
            Dim Appointment As DevExpress.XtraScheduler.Appointment = Nothing
            Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
            Dim Allow As Boolean = False

            Appointment = e.Appointment

            If Appointment.CustomFields("CustomField1") IsNot Nothing Then

                If TypeOf Appointment.CustomFields("CustomField1") Is AdvantageFramework.ProjectSchedule.Classes.ScheduleTask Then

                    Allow = True

                End If

            End If

            e.Allow = Allow

        End Sub
        Private Sub SchedulerControlForm_Scheduler_AppointmentResized(sender As Object, e As DevExpress.XtraScheduler.AppointmentResizeEventArgs) Handles SchedulerControlForm_Scheduler.AppointmentResized

            'objects
            Dim Appointment As DevExpress.XtraScheduler.Appointment = Nothing
            Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim Saved As Boolean = False

            Appointment = e.EditedAppointment

            Try

                ScheduleTask = DirectCast(Appointment.CustomFields("CustomField1"), AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)

            Catch ex As Exception
                ScheduleTask = Nothing
            End Try

            If ScheduleTask IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobComponentTaskID(DbContext, ScheduleTask.ID)

                    If JobComponentTask IsNot Nothing Then

                        JobComponentTask.StartDate = Appointment.Start
                        JobComponentTask.DueDate = Appointment.End

                        Saved = AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask)

                    End If

                End Using

            End If

            If Saved = False Then

                LoadChart()

            End If

        End Sub
        Private Sub SchedulerControlForm_Scheduler_EditAppointmentFormShowing(sender As Object, e As DevExpress.XtraScheduler.AppointmentFormEventArgs) Handles SchedulerControlForm_Scheduler.EditAppointmentFormShowing

            'objects
            Dim Appointment As DevExpress.XtraScheduler.Appointment = Nothing
            Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing

            Appointment = e.Appointment

            Try

                If Appointment.CustomFields("CustomField1") IsNot Nothing Then

                    If TypeOf Appointment.CustomFields("CustomField1") Is AdvantageFramework.ProjectSchedule.Classes.ScheduleTask Then

                        ScheduleTask = DirectCast(Appointment.CustomFields("CustomField1"), AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)

                        If AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleTaskEditDialog.ShowFormDialog(ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber) = Windows.Forms.DialogResult.OK Then

                            LoadChart()

                        End If

                    End If

                End If

                e.Handled = True

            Catch ex As Exception

            End Try

        End Sub
        Private Sub SchedulerControlForm_Scheduler_PopupMenuShowing(sender As Object, e As DevExpress.XtraScheduler.PopupMenuShowingEventArgs) Handles SchedulerControlForm_Scheduler.PopupMenuShowing

            If e.Menu.Id = DevExpress.XtraScheduler.SchedulerMenuItemId.DefaultMenu Then

                e.Menu.GetPopupMenuById(DevExpress.XtraScheduler.SchedulerMenuItemId.SwitchViewMenu).Visible = False

                e.Menu.RemoveMenuItem(DevExpress.XtraScheduler.SchedulerMenuItemId.NewAllDayEvent)

            ElseIf e.Menu.Id = DevExpress.XtraScheduler.SchedulerMenuItemId.AppointmentMenu Then

                e.Menu.RemoveMenuItem(DevExpress.XtraScheduler.SchedulerMenuItemId.AppointmentDependencyCreation)
                e.Menu.RemoveMenuItem(DevExpress.XtraScheduler.SchedulerMenuItemId.EditSeries)
                e.Menu.RemoveMenuItem(DevExpress.XtraScheduler.SchedulerMenuItemId.StatusSubMenu)
                e.Menu.RemoveMenuItem(DevExpress.XtraScheduler.SchedulerMenuItemId.LabelSubMenu)
                e.Menu.RemoveMenuItem(DevExpress.XtraScheduler.SchedulerMenuItemId.DeleteAppointment)

            End If

        End Sub
        Private Sub SchedulerControlForm_Scheduler_QueryResourceColorSchema(sender As Object, e As DevExpress.XtraScheduler.QueryResourceColorSchemaEventArgs) Handles SchedulerControlForm_Scheduler.QueryResourceColorSchema

            'objects
            Dim ResourceLevel As Integer = 0
            Dim Resource As DevExpress.XtraScheduler.Resource = Nothing
            Dim ParentID As Integer = -1

            Try

                If e.Resource IsNot Nothing Then

                    ParentID = e.Resource.ParentId

                    If ParentID > -1 Then

                        While ParentID > -1

                            Resource = SchedulerControlForm_Scheduler.ActiveView.GetResources().Where(Function(r) r.Id = ParentID).SingleOrDefault()

                            If Resource IsNot Nothing AndAlso Resource.ParentId IsNot Nothing Then

                                ParentID = Resource.ParentId

                            Else

                                ParentID = -1

                            End If

                            ResourceLevel = ResourceLevel + 1

                        End While

                    End If

                    If ResourceLevel = 0 Then

                        e.ResourceColorSchema = New DevExpress.XtraScheduler.SchedulerColorSchema(Drawing.Color.Red)

                    ElseIf ResourceLevel = 1 Then

                        e.ResourceColorSchema = New DevExpress.XtraScheduler.SchedulerColorSchema(Drawing.Color.Blue)

                    Else

                        e.ResourceColorSchema = New DevExpress.XtraScheduler.SchedulerColorSchema(Drawing.Color.Green)

                    End If

                End If

            Catch ex As Exception
                Dim asdf As Object = Nothing
            End Try
            

        End Sub

    End Class

End Namespace

