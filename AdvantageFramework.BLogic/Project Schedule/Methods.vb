Namespace ProjectSchedule

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum LookupSettingsOptions

            No = 0
            Yes = 1
            Prompt = 2

        End Enum
        Public Enum TaskStatus
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("P", "Projected")>
            Projected
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("A", "Active")>
            Active
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("H", "High Priority")>
            HighPriority
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("L", "Low Priority")>
            LowPriority
        End Enum
        Public Enum SummaryLevel
            None = 0
            Day = 1
            Week = 2
            Month = 3
            Year = 4
            Custom = 6
        End Enum
        Public Enum WorkloadType
            StandardHoursAvailable
            AppointmentHours
            HoursOff
            HoursAssignedToTasks
            Variance
        End Enum
        Public Enum FindAndReplaceFields
            StartDate
            DueDate
            TimeDue
            CompletedDate
            EmployeeAssignment
            ClientContactAssignment
            TaskStatus
            Manager
        End Enum
        Public Enum CopyOptions
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("IncludeStartDate", "Include Start Date")>
            IncludeStartDate
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("IncludeDueDate", "Include Due Date")>
            IncludeDueDate
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("IncludeTaskEmployees", "Include Task Employee(s)")>
            IncludeTaskEmployees
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("IncludeTaskComment", "Include Task Comment")>
            IncludeTaskComment
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("IncludeDueDateComment", "Include Due Date Comment")>
            IncludeDueDateComment
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("IncludeTaskStatus", "Include Task Status")>
            IncludeTaskStatus
            '<AdvantageFramework.EnumUtilities.Attributes.EnumObject("ScheduleTemplate", "Schedule Template")>
            'ScheduleTemplate
        End Enum
        Public Enum CompleteTempCompleteActionType

            No = 0
            Yes = 1
            Prompt = 2

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function MarkTaskRead(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                     ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TaskSequenceNumber As Short,
                                     ByVal EmployeeCode As String) As Boolean

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE JOB_TRAFFIC_DET_EMPS WITH(ROWLOCK) SET READ_ALERT = 1 WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2} AND EMP_CODE = '{3}';",
                                                                   JobNumber,
                                                                   JobComponentNumber,
                                                                   TaskSequenceNumber,
                                                                   EmployeeCode))
                Return True

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function MarkTaskNotReadForAll(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TaskSequenceNumber As Short) As Boolean

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE JOB_TRAFFIC_DET_EMPS WITH(ROWLOCK) SET READ_ALERT = NULL WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2};",
                                                                   JobNumber,
                                                                   JobComponentNumber,
                                                                   TaskSequenceNumber))
                Return True

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function MarkTaskNotReadForAllExcept(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TaskSequenceNumber As Short,
                                                    ByVal EmployeeCode As String) As Boolean

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE JOB_TRAFFIC_DET_EMPS WITH(ROWLOCK) SET READ_ALERT = NULL WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2} AND EMP_CODE <> '{3}';",
                                                                   JobNumber,
                                                                   JobComponentNumber,
                                                                   TaskSequenceNumber,
                                                                   EmployeeCode))
                Return True

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function MarkTaskNotRead(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TaskSequenceNumber As Short,
                                        ByVal EmployeeCode As String) As Boolean

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE JOB_TRAFFIC_DET_EMPS WITH(ROWLOCK) SET READ_ALERT = NULL WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2} AND EMP_CODE = '{3}';",
                                                                   JobNumber,
                                                                   JobComponentNumber,
                                                                   TaskSequenceNumber,
                                                                   EmployeeCode))
                Return True

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function MarkTaskCompleteOnAlertDismissed(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                         ByVal UserCode As String, ByVal EmployeeCode As String, ByVal AlertID As Integer, ByVal Complete As Boolean) As Boolean

            'objects
            Dim ConfirmComplete As Boolean = False
            Dim AgencySettingValue As Short = 0

            Try

                If AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID).AlertLevel = "PST" Then

                    Try

                        AgencySettingValue = CShort(AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.TRF_COMP_ALERT))

                    Catch ex As Exception
                        AgencySettingValue = 0
                    End Try

                    If AgencySettingValue = 2 Then

                        ConfirmComplete = AdvantageFramework.ProjectSchedule.CheckCompleteAlertOrAssignment(DbContext, AlertID, UserCode, EmployeeCode, Complete)

                    End If

                End If

            Catch ex As Exception

            End Try

            Return ConfirmComplete

        End Function
        Public Function MarkTaskTempCompleteOnAlertDismissed(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                             ByVal UserCode As String, ByVal EmployeeCode As String,
                                                             ByVal AlertID As Integer, ByVal Complete As Boolean) As Boolean

            'objects
            Dim ConfirmComplete As Boolean = False
            Dim AgencySettingValue As Short = 0

            Try

                If AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID).AlertLevel = "PST" Then

                    Try

                        'AgencySettingValue = CShort(AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.TRF_TEMP_COMP_ALERT))
                        AgencySettingValue = DbContext.Database.SqlQuery(Of Short)("SELECT CAST(ISNULL(AGY_SETTINGS_VALUE, 0) AS SMALLINT) FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_TEMP_COMP_ALERT';").FirstOrDefault

                    Catch ex As Exception
                        AgencySettingValue = 0
                    End Try

                    If AgencySettingValue = 2 Then

                        ConfirmComplete = AdvantageFramework.ProjectSchedule.CheckTempCompleteAlertOrAssignment(DbContext, AlertID, UserCode, EmployeeCode, Complete)

                    End If

                End If

            Catch ex As Exception
                ConfirmComplete = False
            End Try

            Return ConfirmComplete

        End Function

        Public Function AlertManagerOnTempComplete(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Return DbContext.Database.SqlQuery(Of Integer)("SELECT COALESCE(dbo.AGY_SETTINGS.AGY_SETTINGS_VALUE,dbo.AGY_SETTINGS.AGY_SETTINGS_DEF, '0') SETTINGS_DEFAULT FROM dbo.AGY_SETTINGS WITH(NOLOCK) WHERE dbo.AGY_SETTINGS.AGY_SETTINGS_CODE = 'TRF_ALRT_TMP_CMPLT';").FirstOrDefault.ToString() = "1"

        End Function
        Public Function LoadManager(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As AdvantageFramework.Database.Views.Employee

            Dim Manager As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ScheduleHeader As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Dim ManagerFieldName As String = ""
            Dim ManagerEmployeeCode As String = ""


            Try

                ManagerFieldName = DbContext.Database.SqlQuery(Of String)("SELECT dbo.AGY_SETTINGS.AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WITH(NOLOCK) WHERE dbo.AGY_SETTINGS.AGY_SETTINGS_CODE = 'TRAFFIC_MGR_COL';").FirstOrDefault

                ''''' I KEEP GETTING A LOGIN FAILURE WITH THE BELOW!

                '' ''Using DataContext As New AdvantageFramework.Database.DataContext(CType(DbContext.Database.Connection, System.Data.EntityClient.EntityConnection).StoreConnection.ConnectionString(), DbContext.UserCode)

                '' ''    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, "TRAFFIC_MGR_COL")

                '' ''End Using

                '' ''If Not Setting Is Nothing Then

                '' ''    ManagerFieldName = Setting.Value

                '' ''    If ManagerFieldName Is Nothing Then

                '' ''        ManagerFieldName = Setting.DefaultValue

                '' ''    End If

                '' ''End If

            Catch ex As Exception

                ManagerFieldName = ""

            End Try

            If ManagerFieldName <> "" Then

                ScheduleHeader = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                If Not ScheduleHeader Is Nothing Then

                    Select Case ManagerFieldName

                        Case "TR_TITLE1"

                            ManagerEmployeeCode = ScheduleHeader.Assign1

                        Case "TR_TITLE2"

                            ManagerEmployeeCode = ScheduleHeader.Assign2

                        Case "TR_TITLE3"

                            ManagerEmployeeCode = ScheduleHeader.Assign3

                        Case "TR_TITLE4"

                            ManagerEmployeeCode = ScheduleHeader.Assign4

                        Case "TR_TITLE5"

                            ManagerEmployeeCode = ScheduleHeader.Assign5

                    End Select

                    If ManagerEmployeeCode <> "" Then

                        Manager = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ManagerEmployeeCode)

                    End If

                End If

            End If

            Return Manager

        End Function
        Public Function MarkAllEmployeesTempComplete(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal SequenceNumber As Integer) As Boolean

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE JOB_TRAFFIC_DET_EMPS WITH(ROWLOCK) SET TEMP_COMP_DATE = GETDATE() WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2} AND TEMP_COMP_DATE IS NULL;", JobNumber, JobComponentNumber, SequenceNumber))
                Return True

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function MarkTempComplete(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                         ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal SequenceNumber As Integer,
                                         ByVal EmployeeCode As String,
                                         ByVal CompleteDate As DateTime,
                                         Optional ByRef MarkedComplete As Boolean = False) As Boolean

            Dim TaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Task As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim Updated As Boolean = False

            MarkedComplete = False

            TaskEmployee = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeqEmp(DbContext, JobNumber, JobComponentNumber, SequenceNumber, EmployeeCode)

            If Not TaskEmployee Is Nothing Then

                If CompleteDate = Nothing Or CompleteDate = #12:00:00 AM# Then

                    TaskEmployee.TempCompletionDate = Nothing

                Else

                    TaskEmployee.TempCompletionDate = CompleteDate
                    MarkedComplete = True

                End If

                Updated = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Update(DbContext, TaskEmployee)

                If Updated = True And MarkedComplete = True Then

                    If MarkedComplete = True Then

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, TaskEmployee.EmployeeCode)
                        Task = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, JobNumber, JobComponentNumber, SequenceNumber)

                        If Not Employee Is Nothing AndAlso Not Task Is Nothing AndAlso AdvantageFramework.ProjectSchedule.AlertManagerOnTempComplete(DbContext) = True Then

                            Dim Manager As AdvantageFramework.Database.Views.Employee = Nothing
                            Manager = AdvantageFramework.ProjectSchedule.LoadManager(DbContext, JobNumber, JobComponentNumber)

                            If Not Manager Is Nothing AndAlso Manager.Code <> Employee.Code Then

                                AdvantageFramework.AlertSystem.CreateAlertForTaskTempCompleteNotification(DbContext, SecurityDbContext, Employee, Manager, Task)

                            End If

                        End If

                        CheckToCompleteSchedule(DbContext, JobNumber, JobComponentNumber)

                        'AdvantageFramework.ProjectManagement.Agile.ClearAllocatedHours(DbContext, JobNumber, JobComponentNumber, SequenceNumber, TaskEmployee.EmployeeCode, True)

                    End If

                End If

            End If

            MarkTempComplete = Updated

        End Function
        Public Function CheckToCompleteSchedule(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal JobNumber As Integer,
                                                ByVal JobComponentNumber As Short) As Date?

            Dim CompletedDate As Date? = Nothing
            Try

                CompletedDate = DbContext.Database.SqlQuery(Of Date?)(String.Format("EXEC [dbo].[advsp_project_schedule_cmplt_sched_last_cpmlt] {0}, {1};",
                                                                                   JobNumber, JobComponentNumber))?.SingleOrDefault()

            Catch ex As Exception
            End Try

            Return CompletedDate

        End Function

        Public Function CompleteTaskInsteadOfTempCompleteSetting(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.ProjectSchedule.LookupSettingsOptions

            Try

                CompleteTaskInsteadOfTempCompleteSetting = CType(CType(Agency.GetValue(DbContext, Agency.Methods.Settings.TRF_COMP_NO_TMP), Integer), AdvantageFramework.ProjectSchedule.LookupSettingsOptions)

            Catch ex As Exception
                Return LookupSettingsOptions.No
            End Try

        End Function
        Public Function CompleteTaskInsteadOfTempComplete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short,
                                                          ByVal EmployeeCode As String, ByVal IsClientPortal As Boolean) As Boolean

            'objects
            Dim Completed As Boolean = False

            Try

                If {"1", "2"}.Contains(Agency.GetValue(DbContext, Agency.Methods.Settings.TRF_COMP_NO_TMP)) Then

                    Completed = CompleteTaskFrom(DbContext, JobNumber, JobComponentNumber, SequenceNumber, EmployeeCode, IsClientPortal)

                End If

            Catch ex As Exception
                Completed = False
            Finally
                CompleteTaskInsteadOfTempComplete = Completed
            End Try

        End Function
        Public Function CompleteTaskFromAlertOrAssignment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short,
                                                          ByVal EmployeeCode As String, ByVal IsClientPortal As Boolean) As Boolean

            'objects
            Dim Completed As Boolean = False

            Try

                If {"1", "2"}.Contains(Agency.GetValue(DbContext, Agency.Methods.Settings.TRF_COMP_ALERT)) Then

                    Completed = CompleteTaskFrom(DbContext, JobNumber, JobComponentNumber, SequenceNumber, EmployeeCode, IsClientPortal)

                End If

            Catch ex As Exception
                Completed = False
            Finally
                CompleteTaskFromAlertOrAssignment = Completed
            End Try

        End Function
        Public Function CompleteTaskFrom(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short,
                                         ByVal EmployeeCode As String, ByVal IsClientPortal As Boolean) As Boolean

            Dim Completed As Boolean = False
            Try

                If (From Item In AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeq(DbContext, JobNumber, JobComponentNumber, SequenceNumber)
                    Where Item.TempCompletionDate Is Nothing
                    Select Item).Any = False Then

                    Completed = CompleteTask(DbContext, JobNumber, JobComponentNumber, SequenceNumber, EmployeeCode, IsClientPortal)

                End If

            Catch ex As Exception
                Completed = False
            Finally
                CompleteTaskFrom = Completed
            End Try

        End Function
        Public Function CompleteTask(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short, ByVal EmployeeCode As String, ByVal IsClientPortal As Boolean) As Boolean

            'objects
            Dim Completed As Boolean = False
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

            Try

                JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, JobNumber, JobComponentNumber, SequenceNumber)

                If JobComponentTask IsNot Nothing Then

                    Completed = CompleteTask(DbContext, JobComponentTask, EmployeeCode, IsClientPortal)

                End If

            Catch ex As Exception
                Completed = False
            Finally
                CompleteTask = Completed
            End Try

        End Function
        Public Function CompleteTask(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask, ByVal EmployeeCode As String, ByVal IsClientPortal As Boolean) As Boolean

            'objects
            Dim Completed As Boolean = False
            Dim TaskSeqNumsMadeActive As Short() = Nothing
            Dim AlertID As Integer = 0
            Dim EmployeesToNotify As String = ""
            Dim AlertEmail As AdvantageFramework.AlertSystem.Classes.AlertEmail = Nothing
            Dim WebvantageURL As String = Nothing
            Dim ClientPortalURL As String = ""

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim CompleteScheduleOnLastTaskComplete As Boolean = False
            Dim IsUpdatingCompletedDate As Boolean = False
            Dim UpdateScheduleComplete As Boolean = False
            Dim DbTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

            Try

                Using DataContext = New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                    Try

                        Try

                            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.TRF_CMPLT_ON_LAST.ToString)

                            If Setting IsNot Nothing Then

                                CompleteScheduleOnLastTaskComplete = CBool(Setting.Value)

                            End If

                        Catch ex As Exception
                            CompleteScheduleOnLastTaskComplete = False
                        End Try

                        If CompleteScheduleOnLastTaskComplete = True Then

                            DbTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext,
                                                                                                                                                   JobComponentTask.JobNumber,
                                                                                                                                                   JobComponentTask.JobComponentNumber,
                                                                                                                                                   JobComponentTask.SequenceNumber)


                            If DbTask IsNot Nothing Then

                                If AdvantageFramework.StringUtilities.AreDatesEqual(JobComponentTask.CompletedDate, DbTask.CompletedDate) = False Then

                                    Dim TaskList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
                                    Dim IsUpdatingLastTask As Boolean = False

                                    TaskList = AdvantageFramework.ProjectSchedule.GetScheduleTasks(DbContext, JobComponentTask.JobNumber,
                                                                                               JobComponentTask.JobComponentNumber, "",
                                                                                               DbContext.UserCode, "", "", "", True, False, False, "", "", False, False, False, True, -1).ToList

                                    If TaskList IsNot Nothing Then

                                        Try

                                            'LastScheduleTask = TaskList(TaskList.Count - 1)

                                            'If LastScheduleTask IsNot Nothing AndAlso LastScheduleTask.SequenceNumber = ScheduleTask.SequenceNumber Then

                                            '    IsUpdatingLastTask = True

                                            'End If

                                            If JobComponentTask.CompletedDate IsNot Nothing Then

                                                Dim UnCompletedTaskList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)
                                                UnCompletedTaskList = (From Entity In TaskList
                                                                       Where Entity.JobCompletedDate Is Nothing).ToList

                                                If UnCompletedTaskList IsNot Nothing Then

                                                    For Each UncompleteTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask In UnCompletedTaskList

                                                        If UncompleteTask.SequenceNumber = JobComponentTask.SequenceNumber Then 'Completing last task

                                                            IsUpdatingLastTask = True

                                                        End If

                                                    Next

                                                End If

                                            Else

                                                Dim CompletedTaskList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)
                                                CompletedTaskList = (From Entity In TaskList
                                                                     Where Entity.JobCompletedDate IsNot Nothing).ToList

                                                If CompletedTaskList IsNot Nothing AndAlso CompletedTaskList.Count = TaskList.Count Then 'Uncompleting last task

                                                    IsUpdatingLastTask = True

                                                End If

                                            End If

                                        Catch ex As Exception
                                            IsUpdatingLastTask = False
                                        End Try

                                        Dim TasksCheck As Boolean = False

                                        If JobComponentTask.CompletedDate Is Nothing Then

                                            TasksCheck = True

                                        End If

                                        If TasksCheck = False Then

                                            TasksCheck = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumber(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber)
                                                          Where Entity.CompletedDate Is Nothing).Count = 0

                                        End If

                                        If IsUpdatingLastTask = False Then TasksCheck = False

                                        If TasksCheck = True Then

                                            UpdateScheduleComplete = True

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    Catch ex As Exception
                        UpdateScheduleComplete = False
                    End Try

                    Dim Assignment As AdvantageFramework.Database.Entities.Alert = Nothing

                    If JobComponentTask.CompletedDate.HasValue = False Then

                        JobComponentTask.CompletedDate = System.DateTime.Today

                        If AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask) Then

                            If JobIsOnBoard(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber) = False Then

                                CompleteWorkItem(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber, JobComponentTask.SequenceNumber)

                                SetNextTaskActive(DbContext, DataContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber, JobComponentTask.SequenceNumber, TaskSeqNumsMadeActive)

                                AutoUpdateTrafficCode(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber, "", "", "")

                                If Agency.GetValue(DbContext, Agency.Methods.Settings.TRF_NXT_TSK_AUTO_EML) = "1" Then

                                    If TaskSeqNumsMadeActive IsNot Nothing AndAlso TaskSeqNumsMadeActive.Count > 0 Then

                                        LoadWebvantageAndClientPortalURL(DbContext, WebvantageURL, ClientPortalURL)

                                        For Each SeqNum In TaskSeqNumsMadeActive

                                            'AlertID = AdvantageFramework.ProjectSchedule.CreateTaskAlert(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber, SeqNum, EmployeeCode, EmployeesToNotify)
                                            Assignment = AdvantageFramework.Database.Procedures.Alert.LoadTaskWorkItem(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber, SeqNum)

                                            If Assignment.ID > 0 Then

                                                Dim JobCompTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
                                                JobCompTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber, SeqNum)

                                                If JobCompTask IsNot Nothing Then
                                                    For Each emp In JobCompTask.JobComponentTaskEmployee
                                                        emp.ReadAlert = Nothing
                                                        AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Update(DbContext, emp)
                                                    Next
                                                End If

                                                With New AdvantageFramework.AlertSystem.Classes.AlertEmail(DbContext.ConnectionString, DbContext.UserCode)

                                                    .AlertID = Assignment.ID
                                                    .EmployeeCodesToSendEmailTo = EmployeesToNotify
                                                    .ClientPortalEmailAddressessToSendTo = ""
                                                    .Subject = "[Alert Updated]"
                                                    .IsClientPortal = IsClientPortal
                                                    .IncludeOriginator = False

                                                    .Send()

                                                End With

                                            End If

                                            AlertID = Nothing
                                            EmployeesToNotify = ""

                                        Next

                                    End If

                                End If

                            End If

                            'AdvantageFramework.ProjectManagement.Agile.ClearAllocatedHours(DbContext,
                            '                                                               JobComponentTask.JobNumber,
                            '                                                               JobComponentTask.JobComponentNumber,
                            '                                                               JobComponentTask.SequenceNumber, "", False)

                        End If

                        Completed = True

                    End If

                    If UpdateScheduleComplete = True Then

                        Try

                            Dim Schedule As AdvantageFramework.Database.Entities.JobTraffic = Nothing

                            Schedule = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber)

                            If Schedule IsNot Nothing Then

                                Schedule.CompletedDate = JobComponentTask.CompletedDate

                                If AdvantageFramework.Database.Procedures.JobTraffic.Update(DbContext, Schedule) = True Then

                                End If

                            End If

                        Catch ex As Exception
                        End Try

                    End If

                    CheckToCompleteSchedule(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber)

                End Using

            Catch ex As Exception
                Completed = False
            Finally
                CompleteTask = Completed
            End Try

        End Function
        Public Function CompleteWorkItem(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TaskSequenceNumber As Short) As Boolean

            Dim Completed As Boolean = False

            Dim WorkItem As AdvantageFramework.Database.Entities.Alert = Nothing

            Try

                WorkItem = (From Alert In DbContext.GetQuery(Of Database.Entities.Alert)
                            Where Alert.IsWorkItem = True And Alert.JobNumber = JobNumber And Alert.JobComponentNumber = JobComponentNumber And Alert.TaskSequenceNumber = TaskSequenceNumber
                            Select Alert).SingleOrDefault

            Catch ex As Exception
                WorkItem = Nothing
            End Try
            If WorkItem IsNot Nothing Then

                WorkItem.AssignmentCompleted = 1

                Completed = AdvantageFramework.Database.Procedures.Alert.Update(DbContext, WorkItem)

            End If

            Return Completed

        End Function
        Public Function JobIsOnBoard(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As Boolean

            Try

                Return DbContext.Database.SqlQuery(Of Boolean)(String.Format("IF EXISTS (SELECT 1 FROM BOARD_JOB WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1}) SELECT CAST(1 AS BIT) ELSE SELECT CAST(0 AS BIT);",
                                                                             JobNumber, JobComponentNumber)).FirstOrDefault

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function CreateTaskAlert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal TaskSequenceNumber As Integer,
                                        ByVal GeneratedByEmployeeCode As String,
                                        Optional ByRef NotifiedEmployeeCodes As String = "", Optional ByRef ErrorMessage As String = "") As Integer

            Try

                Dim NewAlertId As Integer = 0
                Dim ThisTask As AdvantageFramework.Database.Entities.JobComponentTask

                ThisTask = Nothing
                ThisTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, JobNumber, JobComponentNumber, TaskSequenceNumber)

                If Not ThisTask Is Nothing Then

                    Dim TaskEmployees As New Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTaskEmployee)
                    TaskEmployees = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeq(DbContext, JobNumber, JobComponentNumber, TaskSequenceNumber).ToList()

                    If Not TaskEmployees Is Nothing AndAlso TaskEmployees.Count > 0 Then

                        Dim NewAlert As New AdvantageFramework.Database.Entities.Alert
                        Dim Sb As New System.Text.StringBuilder
                        Dim Subject As String = ""

                        With Sb

                            .Append(ThisTask.Description)
                            .Append("<br />")
                            .Append("Hours allowed:  ")
                            .Append(ThisTask.Hours)
                            .Append("<br />")
                            .Append("Task comments:  ")

                            If ThisTask.Comment Is Nothing Or ThisTask.Comment = "" Then

                                .Append("N/A")

                            Else

                                .Append(ThisTask.Comment)

                            End If

                            .Append("<br />")

                        End With

                        Subject = "[Task Updated] for Job " & JobNumber.ToString().PadLeft(6, "0") & "-" & JobComponentNumber.ToString().PadLeft(2, "0") & " - " &
                            ThisTask.JobComponent.Description & ".  " & ThisTask.Description

                        With NewAlert

                            .AlertTypeID = 6
                            .AlertCategoryID = 25
                            .Subject = Subject
                            .PriorityLevel = 3
                            .Body = Sb.ToString()
                            .EmailBody = .Body
                            .GeneratedDate = System.DateTime.Now
                            .EmployeeCode = GeneratedByEmployeeCode
                            .ClientCode = ThisTask.JobComponent.Job.ClientCode
                            .DivisionCode = ThisTask.JobComponent.Job.DivisionCode
                            .ProductCode = ThisTask.JobComponent.Job.ProductCode
                            .JobNumber = JobNumber
                            .JobComponentNumber = JobComponentNumber
                            .TaskSequenceNumber = TaskSequenceNumber
                            .AlertLevel = "PST"
                            .DueDate = ThisTask.DueDate
                            .UserCode = DbContext.UserCode
                            .LastUpdated = System.DateTime.Now
                            .TimeDue = ThisTask.DueTime

                        End With

                        AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, NewAlert)

                        NewAlertId = NewAlert.ID

                        If NewAlertId > 0 Then

                            Dim Recipient As AdvantageFramework.Database.Entities.AlertRecipient
                            Recipient = Nothing

                            Dim i As Integer = 0
                            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                            Dim SbEmps As New System.Text.StringBuilder

                            For Each TaskEmployee In TaskEmployees

                                i += 1

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, TaskEmployee.EmployeeCode)

                                Recipient = New AdvantageFramework.Database.Entities.AlertRecipient
                                With Recipient

                                    .AlertID = NewAlertId
                                    .EmployeeCode = TaskEmployee.EmployeeCode
                                    .EmployeeEmail = Employee.Email
                                    .ID = i

                                End With

                                AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Recipient)

                                SbEmps.Append(TaskEmployee.EmployeeCode)
                                SbEmps.Append(",")

                                Employee = Nothing

                            Next

                            NotifiedEmployeeCodes = AdvantageFramework.StringUtilities.CleanStringForSplit(SbEmps.ToString(), ",")

                            SbEmps = Nothing

                        End If

                    End If

                End If

                Return NewAlertId

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return -1
            End Try

        End Function
        Public Sub CheckForMissingBRDAlertRecords(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal UserCode As String)

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_agile_check_for_missing_brd_alert] {0}, {1}, '{2}';", JobNumber, JobComponentNumber, UserCode))

            Catch ex As Exception
            End Try

        End Sub
        Public Function GetScheduleTasks(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer,
                                         ByVal Sort As String, ByVal UserCode As String, Optional ByVal EmployeeCode As String = "", Optional ByVal TaskCode As String = "",
                                         Optional ByVal RoleCode As String = "", Optional ByVal IncludeCompletedTasks As Boolean = True, Optional ByVal IncludeOnlyPendingTasks As Boolean = False,
                                         Optional ByVal ExcludeProjectedTasks As Boolean = False, Optional ByVal CutOffDate As String = "", Optional ByVal PhaseFilter As String = "",
                                         Optional ByVal Gantt As Boolean = False, Optional ByVal GetClientContactList As Boolean = True, Optional ByVal GetEmployeeList As Boolean = True,
                                         Optional ByVal LoadPredecessorLevelNotation As Boolean = False, Optional ByVal SequenceNumber As Short = -1) As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
            Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobCompNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim SortSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim TaskCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim RoleCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeCompletedTasksSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeOnlyPendingTasksSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ExcludeProjectedTasksSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim CutOffDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim PhaseFilterSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim GanttSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ScheduleTasks As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
            Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
            Dim PredecessorSequenceNumbers As Short() = Nothing
            Dim ChildTasks As Generic.IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
            Dim ClientContactList As IEnumerable = Nothing
            Dim JobComponentTaskEmployeeList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTaskEmployee) = Nothing
            Dim JobComponentTaskPredecessorList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTaskPredecessor) = Nothing

            Try

                DataTable = New System.Data.DataTable

                SqlConnection = DbContext.Database.Connection
                SqlCommand = New System.Data.SqlClient.SqlCommand("[dbo].[usp_wv_Traffic_Schedule_GetTasks]", SqlConnection)
                SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(SqlCommand)

                Using SqlCommand

                    SqlCommand.CommandType = CommandType.StoredProcedure

                    JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JobNum", SqlDbType.Int) With {.Value = JobNumber}
                    JobCompNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JobCompNum", SqlDbType.Int) With {.Value = JobComponentNumber}
                    SortSqlParameter = New System.Data.SqlClient.SqlParameter("@Sort", SqlDbType.VarChar, 10) With {.Value = Sort}
                    UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar, 100) With {.Value = UserCode}
                    EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6) With {.Value = EmployeeCode}
                    TaskCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@TASK_CODE", SqlDbType.VarChar, 10) With {.Value = TaskCode}
                    RoleCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@ROLE_CODE", SqlDbType.VarChar, 6) With {.Value = RoleCode}
                    IncludeCompletedTasksSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeCompletedTasks", SqlDbType.Char) With {.Value = If(IncludeCompletedTasks, "Y", "N")}
                    IncludeOnlyPendingTasksSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeOnlyPendingTasks", SqlDbType.Char) With {.Value = If(IncludeOnlyPendingTasks, "Y", "N")}
                    ExcludeProjectedTasksSqlParameter = New System.Data.SqlClient.SqlParameter("@ExcludeProjectedTasks", SqlDbType.Char) With {.Value = If(ExcludeProjectedTasks, "Y", "N")}
                    CutOffDateSqlParameter = New System.Data.SqlClient.SqlParameter("@CUT_OFF_DATE", SqlDbType.SmallDateTime)

                    If String.IsNullOrEmpty(CutOffDate) = False Then

                        CutOffDateSqlParameter.Value = CutOffDate

                    Else

                        CutOffDateSqlParameter.Value = DBNull.Value

                    End If

                    PhaseFilterSqlParameter = New System.Data.SqlClient.SqlParameter("@PHASE_FILTER", SqlDbType.VarChar, 10) With {.Value = PhaseFilter}
                    GanttSqlParameter = New System.Data.SqlClient.SqlParameter("@GANTT", SqlDbType.Bit) With {.Value = If(Gantt, 1, 0)}

                    SqlCommand.Parameters.Add(JobNumberSqlParameter)
                    SqlCommand.Parameters.Add(JobCompNumberSqlParameter)
                    SqlCommand.Parameters.Add(SortSqlParameter)
                    SqlCommand.Parameters.Add(UserCodeSqlParameter)
                    SqlCommand.Parameters.Add(EmployeeCodeSqlParameter)
                    SqlCommand.Parameters.Add(TaskCodeSqlParameter)
                    SqlCommand.Parameters.Add(RoleCodeSqlParameter)
                    SqlCommand.Parameters.Add(IncludeCompletedTasksSqlParameter)
                    SqlCommand.Parameters.Add(IncludeOnlyPendingTasksSqlParameter)
                    SqlCommand.Parameters.Add(ExcludeProjectedTasksSqlParameter)
                    SqlCommand.Parameters.Add(CutOffDateSqlParameter)
                    SqlCommand.Parameters.Add(PhaseFilterSqlParameter)
                    SqlCommand.Parameters.Add(GanttSqlParameter)

                    SqlDataAdapter.Fill(DataTable)

                End Using

                ScheduleTasks = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)

                ScheduleTasks = DataTable.AsEnumerable().Select(Function(Row) _
                                    New AdvantageFramework.ProjectSchedule.Classes.ScheduleTask With {
                                            .ID = Row.Field(Of Integer)("ROWID"),
                                            .JobNumber = Row.Field(Of Integer)("JOB_NUMBER"),
                                            .JobComponentNumber = Row.Field(Of Short)("JOB_COMPONENT_NBR"),
                                            .SequenceNumber = Row.Field(Of Short)("SEQ_NBR"),
                                            .TaskCode = Row.Field(Of String)("TASK_CODE"),
                                            .TaskDescription = Row.Field(Of String)("TASK_DESCRIPTION"),
                                            .TaskStatus = Row.Field(Of String)("TASK_STATUS"),
                                            .EstimateFunction = Row.Field(Of String)("FNC_EST"),
                                            .TaskStartDate = Row.Field(Of Date?)("TASK_START_DATE"),
                                            .JobRevisedDate = Row.Field(Of Date?)("JOB_REVISED_DATE"),
                                            .JobCompletedDate = Row.Field(Of Date?)("JOB_COMPLETED_DATE"),'ConvertDataRowStringToDate(Row.Field(Of String)("JOB_COMPLETED_DATE")),
                                            .JobDueDate = Row.Field(Of Date?)("JOB_DUE_DATE"), 'ConvertDataRowStringToDate(Row.Field(Of String)("JOB_DUE_DATE")),
                                            .DueTime = Row.Field(Of String)("DUE_TIME"),
                                            .RevisedDueTime = Row.Field(Of String)("REVISED_DUE_TIME"),
                                            .TemporaryCompleteDate = Row.Field(Of Date?)("TEMP_COMP_DATE"),
                                            .TrafficPhaseID = Row.Field(Of Integer)("TRAFFIC_PHASE_ID"),
                                            .PhaseOrder = Row.Field(Of Integer)("PHASE_ORDER"),
                                            .PhaseDescription = Row.Field(Of String)("PHASE_DESC"),
                                            .JobOrder = Row.Field(Of Short?)("JOB_ORDER"),
                                            .JobDays = Row.Field(Of Short?)("JOB_DAYS"),
                                            .JobHours = Row.Field(Of Decimal?)("JOB_HRS"),
                                            .Milestone = Row.Field(Of Short?)("MILESTONE"),
                                            .Predecessor = Row.Field(Of Integer?)("PREDECESSOR"),
                                            .DueDateLock = Row.Field(Of Short)("DUE_DATE_LOCK"),
                                            .FunctionComments = Row.Field(Of String)("FNC_COMMENTS"),
                                            .DueDateComments = Row.Field(Of String)("DUE_DATE_COMMENTS"),
                                            .RevisionDateComments = Row.Field(Of String)("REV_DATE_COMMENTS"),
                                            .DispersedHours = Row.Field(Of Decimal)("DISPERSED_HOURS"),
                                            .TrafficRole = Row.Field(Of String)("TRF_ROLE"),
                                            .FunctionDescription = Row.Field(Of String)("FNC_DESCRIPTION"),
                                            .HasAssignment = Row.Field(Of Integer)("HAS_ASSIGNMENT"),
                                            .HasAlerts = Row.Field(Of Integer)("HAS_ALERTS"),
                                            .PostedHours = Row.Field(Of Decimal?)("POSTED_HOURS_ASSN"),
                                            .PercentComplete = Row.Field(Of Decimal?)("PERC_COMPLETE_ASSN"),
                                            .PhaseStartDate = Row.Field(Of Date?)("PHASE_START_DATE"),
                                            .PhaseEndDate = Row.Field(Of Date?)("PHASE_END_DATE"),
                                            .ParentTaskSequenceNumber = Row.Field(Of Short?)("PARENT_TASK_SEQ"),
                                            .GridOrder = Row.Field(Of Short?)("GRID_ORDER"),
                                            .Level = Row.Field(Of String)("LEVEL"),
                                            .HasDocuments = Row.Field(Of Boolean)("HAS_DOCUMENTS"),
                                            .HasChildren = Row.Field(Of Boolean)("HAS_CHILDREN"),
                                            .HasPredecessors = Row.Field(Of Boolean)("HAS_PREDECESSORS"),
                                            .Priority = Row.Field(Of Short)("PRIORITY")
                                        }).ToList

                If GetEmployeeList Then

                    If SequenceNumber >= 0 Then

                        JobComponentTaskEmployeeList = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeq(DbContext, JobNumber, JobComponentNumber, SequenceNumber).ToList

                    Else

                        JobComponentTaskEmployeeList = (From Item In AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Load(DbContext)
                                                        Where Item.JobNumber = JobNumber AndAlso Item.JobComponentNumber = JobComponentNumber
                                                        Select Item).ToList

                    End If

                End If

                If GetClientContactList Then

                    If SequenceNumber >= 0 Then

                        ClientContactList = (From Item In AdvantageFramework.Database.Procedures.JobComponentTaskClientContact.LoadByJobCompAndSequence(DbContext, JobNumber, JobComponentNumber, SequenceNumber)
                                             Join ClientContact In AdvantageFramework.Database.Procedures.ClientContact.Load(DbContext) On Item.ClientContactID Equals ClientContact.ContactID
                                             Select New With {.SequenceNumber = Item.SequenceNumber,
                                                              .Code = ClientContact.ContactCode,
                                                            .Name = If(ClientContact.MiddleInitial = Nothing, ClientContact.FirstName + " " + ClientContact.LastName, ClientContact.FirstName + " " + ClientContact.MiddleInitial + ". " + ClientContact.LastName)}).ToList

                    Else

                        ClientContactList = (From Item In AdvantageFramework.Database.Procedures.JobComponentTaskClientContact.Load(DbContext)
                                             Join ClientContact In AdvantageFramework.Database.Procedures.ClientContact.Load(DbContext) On Item.ClientContactID Equals ClientContact.ContactID
                                             Where Item.JobNumber = JobNumber AndAlso Item.JobComponentNumber = JobComponentNumber
                                             Select New With {.SequenceNumber = Item.SequenceNumber,
                                                          .Code = ClientContact.ContactCode,
                                                            .Name = If(ClientContact.MiddleInitial = Nothing, ClientContact.FirstName + " " + ClientContact.LastName, ClientContact.FirstName + " " + ClientContact.MiddleInitial + ". " + ClientContact.LastName)}).ToList

                    End If

                End If

                If LoadPredecessorLevelNotation Then

                    If SequenceNumber >= 0 Then

                        JobComponentTaskPredecessorList = AdvantageFramework.Database.Procedures.JobComponentTaskPredecessor.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, JobNumber, JobComponentNumber, SequenceNumber).ToList

                    Else

                        JobComponentTaskPredecessorList = AdvantageFramework.Database.Procedures.JobComponentTaskPredecessor.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber).ToList

                    End If

                End If

                For Each ScheduleTask In ScheduleTasks.Where(Function(t) t.SequenceNumber = If(SequenceNumber >= 0, SequenceNumber, t.SequenceNumber)).ToList

                    If ScheduleTask.HasChildren Then

                        Try

                            ChildTasks = (From Item In ScheduleTasks
                                          Where Item.Level.StartsWith(ScheduleTask.Level & ".") AndAlso
                                                Item.HasChildren = False
                                          Select Item).ToList

                        Catch ex As Exception
                            ChildTasks = Nothing
                        End Try

                        If ChildTasks IsNot Nothing Then

                            ScheduleTask.PostedHours = ChildTasks.Select(Function(t) t.PostedHours.GetValueOrDefault(0)).Sum
                            ScheduleTask.DispersedHours = ChildTasks.Select(Function(t) t.DispersedHours).Sum

                            If ScheduleTask.DispersedHours > 0 Then

                                ScheduleTask.PercentComplete = Math.Round((ScheduleTask.PostedHours.GetValueOrDefault(0) / ScheduleTask.DispersedHours) * 100, 2, MidpointRounding.AwayFromZero)

                            Else

                                ScheduleTask.PercentComplete = 0

                            End If

                        End If

                    End If

                    If GetClientContactList = True Then

                        Try

                            ScheduleTask.ClientContact = String.Join(",", (From Entity In ClientContactList
                                                                           Where Entity.SequenceNumber = ScheduleTask.SequenceNumber
                                                                           Select Entity.Code).ToArray)

                            ScheduleTask.ClientContactName = String.Join(",", (From Entity In ClientContactList
                                                                               Where Entity.SequenceNumber = ScheduleTask.SequenceNumber
                                                                               Select Entity.Name).ToArray)


                        Catch ex As Exception
                            ScheduleTask.ClientContact = Nothing
                        End Try

                    End If

                    If GetEmployeeList Then

                        Try

                            ScheduleTask.EmployeeCode = String.Join(",", (From Entity In JobComponentTaskEmployeeList
                                                                          Where Entity.SequenceNumber = ScheduleTask.SequenceNumber
                                                                          Select [Emp] = Entity.EmployeeCode).ToArray)

                        Catch ex As Exception
                            ScheduleTask.EmployeeCode = Nothing
                        End Try

                    End If

                    If LoadPredecessorLevelNotation Then

                        If ScheduleTask.HasPredecessors Then

                            Try

                                'PredecessorSequenceNumbers = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT [PREDECESSOR_SEQ_NBR] FROM dbo.JOB_TRAFFIC_DET_PREDS WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2};", ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber)).ToArray

                                PredecessorSequenceNumbers = (From Item In JobComponentTaskPredecessorList
                                                              Where Item.SequenceNumber = ScheduleTask.SequenceNumber
                                                              Select Item.PredecessorSequenceNumber).ToArray

                            Catch ex As Exception
                                PredecessorSequenceNumbers = Nothing
                            End Try

                            If PredecessorSequenceNumbers IsNot Nothing AndAlso PredecessorSequenceNumbers.Count > 0 Then

                                ScheduleTask.PredecessorSequenceNumbers = PredecessorSequenceNumbers

                                Try

                                    ScheduleTask.PredecessorLevelNotation = String.Join(", ", (From Item In ScheduleTasks
                                                                                               Where PredecessorSequenceNumbers.Contains(Item.SequenceNumber)
                                                                                               Select Item.Level).ToArray)

                                Catch ex As Exception

                                End Try

                            End If

                        End If

                    End If

                Next

                If SequenceNumber >= 0 Then

                    ScheduleTasks = ScheduleTasks.Where(Function(t) t.SequenceNumber = SequenceNumber).ToList

                End If

            Catch ex As Exception
                ScheduleTasks = Nothing
            End Try

            GetScheduleTasks = ScheduleTasks

        End Function
        Public Function GetScheduleTaskEmployees(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            'objects
            Dim EmployeeCodes As String() = Nothing

            Try

                EmployeeCodes = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeq(DbContext, JobNumber, JobComponentNumber, SequenceNumber)
                                 Select Entity.EmployeeCode).ToArray

                GetScheduleTaskEmployees = From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                           Where EmployeeCodes.Contains(Entity.Code)
                                           Select Entity

            Catch ex As Exception
                GetScheduleTaskEmployees = Nothing
            End Try

        End Function
        Public Function GetScheduleTaskClientContacts(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ClientContact)

            'objects
            Dim ContactIDs As Integer() = Nothing

            Try

                ContactIDs = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTaskClientContact.LoadByJobCompAndSequence(DbContext, JobNumber, JobComponentNumber, SequenceNumber)
                              Select Entity.ClientContactID).ToArray

                GetScheduleTaskClientContacts = From Entity In AdvantageFramework.Database.Procedures.ClientContact.Load(DbContext)
                                                Where ContactIDs.Contains(Entity.ContactID)
                                                Select Entity

            Catch ex As Exception
                GetScheduleTaskClientContacts = Nothing
            End Try

        End Function
        Private Function GetRowValue(ByVal DataRow As System.Data.DataRow, ByVal ColumnName As String, ByVal Type As System.Type) As Object

            'objects
            Dim RowValue As Object = Nothing

            Try

                If DataRow(ColumnName) IsNot Nothing Then

                    RowValue = DataRow(ColumnName)

                    If TypeOf RowValue Is DBNull Then

                        RowValue = Nothing

                    End If

                End If

                If RowValue IsNot Nothing Then

                    RowValue = Convert.ChangeType(RowValue, Type)

                End If

            Catch ex As Exception
                RowValue = Nothing
            Finally
                GetRowValue = RowValue
            End Try

        End Function
        Public Function LoadEmployeeAvailability(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, ByVal StartDate As DateTime,
                                                 ByVal EndDate As DateTime, ByVal SummaryLevel As AdvantageFramework.ProjectSchedule.SummaryLevel, ByVal Roles As String, ByVal Departments As String,
                                                 Optional ByVal IncludeWeekends As Boolean = False, Optional ByVal EmployeeList As String = "", Optional ByVal Office As String = "",
                                                 Optional ByVal Client As String = "", Optional ByVal Division As String = "", Optional ByVal Product As String = "",
                                                 Optional ByVal Job As String = "", Optional ByVal JobComponent As String = "", Optional ByVal TaskStatus As String = "",
                                                 Optional ByVal ExcludeTempComplete As Boolean = False, Optional ByVal Manager As String = "", Optional ByVal QueryType As String = "",
                                                 Optional ByVal ProjectScheduleJobNumber As Integer = 0, Optional ByVal ProjectScheduleJobComponentNumber As Integer = 0,
                                                 Optional ByVal ProjectScheduleJobComponentWhereClause As String = "", Optional ByVal OverrideEmployeeSecurity As Boolean = False,
                                                 Optional ByRef ResultSet1List As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet1) = Nothing,
                                                 Optional ByRef ResultSet2List As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet2) = Nothing,
                                                 Optional ByRef ResultSet3List As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet3) = Nothing,
                                                 Optional ByRef ResultSet4List As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet4) = Nothing,
                                                 Optional ByRef ResultSet5List As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet5) = Nothing,
                                                 Optional ByRef ResultSet6List As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet6) = Nothing,
                                                 Optional ByRef ResultSet7List As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet7) = Nothing,
                                                 Optional ByRef ResultSet8List As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet8) = Nothing,
                                                 Optional ByRef ResultSet9List As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet9) = Nothing,
                                                 Optional ByRef ResultSet10List As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet10) = Nothing) As Boolean

            'objects
            Dim DataSet As System.Data.DataSet = Nothing
            Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
            Dim FixedEndDate As DateTime = Nothing
            Dim NumberofDays As Integer = 0
            Dim NumberOfWeeks As Integer = 0
            Dim NumberOfMonths As Integer = 0
            Dim NumberOfYears As Integer = 0
            Dim NumberOfEmployees As Integer = 0
            Dim CalculatedStart As DateTime = Nothing
            Dim CalculatedEnd As DateTime = Nothing
            Dim TotalNumberDays As Integer = 0
            Dim FixedTotalNumberOfDays As Integer = 0
            Dim NumberOfDynamicColumns As Integer = 0
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim RolesSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim StartDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EndDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim SummaryLevelSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim DepartmentsSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmployeeListSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim UserIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim OfficeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ClientCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim DivisionCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ProductCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim TaskStatusSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ExcludeTempCompleteSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ManagerSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim QueryTypeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ProjectScheduleJobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ProjectScheduleJobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ProjectScheduleJobComponentWhereClauseSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim OverrideEmployeeSecuritySqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim Loaded As Boolean = True

            Try

                FixedEndDate = Convert.ToDateTime(EndDate.ToShortDateString() & " 11:59:00 PM")
                TotalNumberDays = CType(DateDiff(DateInterval.Day, StartDate, EndDate), Integer)
                FixedTotalNumberOfDays = CType(DateDiff(DateInterval.Day, StartDate, FixedEndDate), Integer)

                DataSet = New System.Data.DataSet

                SqlConnection = DbContext.Database.Connection
                SqlCommand = New System.Data.SqlClient.SqlCommand("[dbo].[usp_wv_RESOURCES_EMP_AVAILABILITY]", SqlConnection)
                SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(SqlCommand)

                Using SqlCommand

                    SqlCommand.CommandType = CommandType.StoredProcedure

                    EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6) With {.Value = EmployeeCode}
                    RolesSqlParameter = New System.Data.SqlClient.SqlParameter("@ROLES", SqlDbType.VarChar, 4000)

                    If String.IsNullOrEmpty(Roles) Then

                        RolesSqlParameter.Value = System.DBNull.Value

                    Else

                        RolesSqlParameter.Value = Roles

                    End If

                    StartDateSqlParameter = New System.Data.SqlClient.SqlParameter("@START_DATE", SqlDbType.SmallDateTime) With {.Value = StartDate}
                    EndDateSqlParameter = New System.Data.SqlClient.SqlParameter("@END_DATE", SqlDbType.SmallDateTime) With {.Value = FixedEndDate}
                    SummaryLevelSqlParameter = New System.Data.SqlClient.SqlParameter("@SUMMARY_LEVEL", SqlDbType.SmallInt) With {.Value = CShort(SummaryLevel)}
                    DepartmentsSqlParameter = New System.Data.SqlClient.SqlParameter("@DEPTS", SqlDbType.VarChar, 4000)

                    If String.IsNullOrEmpty(Departments) Then

                        DepartmentsSqlParameter.Value = System.DBNull.Value

                    Else

                        DepartmentsSqlParameter.Value = Departments

                    End If

                    EmployeeListSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_LIST", SqlDbType.VarChar, 4000)

                    If String.IsNullOrEmpty(EmployeeList) Then

                        EmployeeListSqlParameter.Value = System.DBNull.Value

                    Else

                        EmployeeListSqlParameter.Value = EmployeeList

                    End If

                    UserIDSqlParameter = New System.Data.SqlClient.SqlParameter("@UserID", SqlDbType.VarChar, 100) With {.Value = DbContext.UserCode}
                    OfficeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@OfficeCode", SqlDbType.VarChar, 4) With {.Value = Office}
                    ClientCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@ClientCode", SqlDbType.VarChar, 6) With {.Value = Client}
                    DivisionCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@DivisionCode", SqlDbType.VarChar, 6) With {.Value = Division}
                    ProductCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@ProductCode", SqlDbType.VarChar, 6) With {.Value = Product}
                    JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JobNum", SqlDbType.VarChar, 6) With {.Value = Job}
                    JobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JobComp", SqlDbType.VarChar, 6) With {.Value = JobComponent}
                    TaskStatusSqlParameter = New System.Data.SqlClient.SqlParameter("@TaskStatus", SqlDbType.VarChar, 1) With {.Value = TaskStatus}
                    ExcludeTempCompleteSqlParameter = New System.Data.SqlClient.SqlParameter("@ExcludeTempComplete", SqlDbType.Char, 1)

                    If ExcludeTempComplete = True Then

                        ExcludeTempCompleteSqlParameter.Value = "Y"

                    Else

                        ExcludeTempCompleteSqlParameter.Value = "N"

                    End If

                    ManagerSqlParameter = New System.Data.SqlClient.SqlParameter("@Manager", SqlDbType.VarChar, 6) With {.Value = Manager}
                    QueryTypeSqlParameter = New System.Data.SqlClient.SqlParameter("@QUERY_TYPE", SqlDbType.VarChar, 10) With {.Value = QueryType}
                    ProjectScheduleJobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@PSWL_JOB_NUMBER", SqlDbType.Int)

                    If ProjectScheduleJobNumber = 0 Then

                        ProjectScheduleJobNumberSqlParameter.Value = System.DBNull.Value

                    Else

                        ProjectScheduleJobNumberSqlParameter.Value = ProjectScheduleJobNumber

                    End If

                    ProjectScheduleJobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@PSWL_JOB_COMPONENT_NBR", SqlDbType.SmallInt)

                    If ProjectScheduleJobNumber = 0 Then

                        ProjectScheduleJobComponentNumberSqlParameter.Value = System.DBNull.Value

                    Else

                        ProjectScheduleJobComponentNumberSqlParameter.Value = ProjectScheduleJobComponentNumber

                    End If

                    ProjectScheduleJobComponentWhereClauseSqlParameter = New System.Data.SqlClient.SqlParameter("@JC_LIST", SqlDbType.VarChar, 8000) With {.Value = ProjectScheduleJobComponentWhereClause}
                    OverrideEmployeeSecuritySqlParameter = New System.Data.SqlClient.SqlParameter("@OVERRIDE_EMP_SEC", SqlDbType.SmallInt)

                    If OverrideEmployeeSecurity = True Then

                        OverrideEmployeeSecuritySqlParameter.Value = 1

                    Else

                        OverrideEmployeeSecuritySqlParameter.Value = 0

                    End If

                    SqlCommand.Parameters.Add(EmployeeCodeSqlParameter)
                    SqlCommand.Parameters.Add(RolesSqlParameter)
                    SqlCommand.Parameters.Add(StartDateSqlParameter)
                    SqlCommand.Parameters.Add(EndDateSqlParameter)
                    SqlCommand.Parameters.Add(SummaryLevelSqlParameter)
                    SqlCommand.Parameters.Add(DepartmentsSqlParameter)
                    SqlCommand.Parameters.Add(EmployeeListSqlParameter)
                    SqlCommand.Parameters.Add(UserIDSqlParameter)
                    SqlCommand.Parameters.Add(OfficeCodeSqlParameter)
                    SqlCommand.Parameters.Add(ClientCodeSqlParameter)
                    SqlCommand.Parameters.Add(DivisionCodeSqlParameter)
                    SqlCommand.Parameters.Add(ProductCodeSqlParameter)
                    SqlCommand.Parameters.Add(JobNumberSqlParameter)
                    SqlCommand.Parameters.Add(JobComponentNumberSqlParameter)
                    SqlCommand.Parameters.Add(TaskStatusSqlParameter)
                    SqlCommand.Parameters.Add(ExcludeTempCompleteSqlParameter)
                    SqlCommand.Parameters.Add(ManagerSqlParameter)
                    SqlCommand.Parameters.Add(QueryTypeSqlParameter)
                    SqlCommand.Parameters.Add(ProjectScheduleJobNumberSqlParameter)
                    SqlCommand.Parameters.Add(ProjectScheduleJobComponentNumberSqlParameter)
                    SqlCommand.Parameters.Add(ProjectScheduleJobComponentWhereClauseSqlParameter)
                    SqlCommand.Parameters.Add(OverrideEmployeeSecuritySqlParameter)

                    SqlDataAdapter.Fill(DataSet)

                End Using

                If SummaryLevel = Methods.SummaryLevel.None Then

                    ResultSet1List = CreateResultSet1List(DataSet.Tables(0))

                ElseIf SummaryLevel = Methods.SummaryLevel.Day Then

                    ResultSet2List = CreateResultSet2List(DataSet.Tables(0))
                    ResultSet3List = CreateResultSet3List(DataSet.Tables(1))
                    ResultSet4List = CreateResultSet4List(DataSet.Tables(2))
                    ResultSet5List = CreateResultSet5List(DataSet.Tables(3))
                    ResultSet6List = CreateResultSet6List(DataSet.Tables(4))
                    ResultSet7List = CreateResultSet7List(DataSet.Tables(5))
                    ResultSet8List = CreateResultSet8List(DataSet.Tables(6))
                    ResultSet9List = CreateResultSet9List(DataSet.Tables(7))

                ElseIf SummaryLevel = Methods.SummaryLevel.Week Then

                    ResultSet2List = CreateResultSet2List(DataSet.Tables(0))
                    ResultSet3List = CreateResultSet3List(DataSet.Tables(1))
                    ResultSet4List = CreateResultSet4List(DataSet.Tables(2))
                    ResultSet5List = CreateResultSet5List(DataSet.Tables(3))
                    ResultSet6List = CreateResultSet6List(DataSet.Tables(4))
                    ResultSet7List = CreateResultSet7List(DataSet.Tables(5))
                    ResultSet8List = CreateResultSet8List(DataSet.Tables(6))
                    ResultSet9List = CreateResultSet9List(DataSet.Tables(7))

                ElseIf SummaryLevel = Methods.SummaryLevel.Month Then

                    ResultSet2List = CreateResultSet2List(DataSet.Tables(0))
                    ResultSet3List = CreateResultSet3List(DataSet.Tables(1))
                    ResultSet4List = CreateResultSet4List(DataSet.Tables(2))
                    ResultSet5List = CreateResultSet5List(DataSet.Tables(3))
                    ResultSet6List = CreateResultSet6List(DataSet.Tables(4))
                    ResultSet7List = CreateResultSet7List(DataSet.Tables(5))
                    ResultSet8List = CreateResultSet8List(DataSet.Tables(6))
                    ResultSet9List = CreateResultSet9List(DataSet.Tables(7))

                ElseIf SummaryLevel = Methods.SummaryLevel.Year Then

                    ResultSet2List = CreateResultSet2List(DataSet.Tables(0))
                    ResultSet3List = CreateResultSet3List(DataSet.Tables(1))
                    ResultSet4List = CreateResultSet4List(DataSet.Tables(2))
                    ResultSet5List = CreateResultSet5List(DataSet.Tables(3))
                    ResultSet6List = CreateResultSet6List(DataSet.Tables(4))
                    ResultSet7List = CreateResultSet7List(DataSet.Tables(5))
                    ResultSet8List = CreateResultSet8List(DataSet.Tables(6))
                    ResultSet9List = CreateResultSet9List(DataSet.Tables(7))

                ElseIf SummaryLevel = Methods.SummaryLevel.Custom Then

                    ResultSet10List = CreateResultSet10List(DataSet.Tables(0))
                    ResultSet6List = CreateResultSet6List(DataSet.Tables(1))
                    ResultSet7List = CreateResultSet7List(DataSet.Tables(2))
                    ResultSet8List = CreateResultSet8List(DataSet.Tables(3))
                    ResultSet9List = CreateResultSet9List(DataSet.Tables(4))

                End If

            Catch ex As Exception
                Loaded = False
            End Try

            LoadEmployeeAvailability = Loaded

        End Function
        Public Function CreateResultSet1List(ByVal DataTable As System.Data.DataTable) As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet1)

            'objects
            Dim ResultSet1List As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet1) = Nothing
            Dim ResultSet1 As AdvantageFramework.ProjectSchedule.Classes.ResultSet1 = Nothing

            If DataTable IsNot Nothing Then

                Try

                    ResultSet1List = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet1)

                    For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                        ResultSet1 = New AdvantageFramework.ProjectSchedule.Classes.ResultSet1

                        ResultSet1.ID = GetRowValue(DataRow, "ROW_ID", GetType(Integer))
                        ResultSet1.EmployeeCode = GetRowValue(DataRow, "EMP_CODE", GetType(String))
                        ResultSet1.StartDayOfWeek = GetRowValue(DataRow, "S_DAY_OF_WEEK", GetType(String))
                        ResultSet1.EmployeeStartTime = GetRowValue(DataRow, "EMP_START_TIME", GetType(Date))
                        ResultSet1.EmployeeEndTime = GetRowValue(DataRow, "EMP_END_TIME", GetType(Date))
                        ResultSet1.EmployeeDirectHoursGoalPercent = GetRowValue(DataRow, "EMP_DIRECT_HRS_GOAL_PERC", GetType(Decimal))
                        ResultSet1.EmployeeDate = GetRowValue(DataRow, "DATE", GetType(Date))
                        ResultSet1.DayOfWeek = GetRowValue(DataRow, "DAY_OF_WEEK", GetType(Integer))
                        ResultSet1.DayOfYear = GetRowValue(DataRow, "DAY_OF_YEAR", GetType(Integer))
                        ResultSet1.WeekOfYear = GetRowValue(DataRow, "WEEK_OF_YEAR", GetType(Date))
                        ResultSet1.MonthOfYear = GetRowValue(DataRow, "MONTH_OF_YEAR", GetType(Integer))
                        ResultSet1.Year = GetRowValue(DataRow, "YEAR", GetType(Integer))
                        ResultSet1.StandardHoursAvailable = GetRowValue(DataRow, "STD_HRS_AVAIL", GetType(Decimal))
                        ResultSet1.EmployeeDirectHoursGoalHours = GetRowValue(DataRow, "EMP_DIRECT_HRS_GOAL_HOURS", GetType(Decimal))
                        ResultSet1.HoursUsedNonTask = GetRowValue(DataRow, "HRS_USED_NON_TASK", GetType(Decimal))
                        ResultSet1.HoursAvailable = GetRowValue(DataRow, "HRS_AVAIL", GetType(Decimal))
                        ResultSet1.HoursAssignedTask = GetRowValue(DataRow, "HRS_ASSIGNED_TASK", GetType(Decimal))
                        ResultSet1.HoursAppointments = GetRowValue(DataRow, "HRS_APPTS", GetType(Decimal))
                        ResultSet1.HoursAssignedEvent = GetRowValue(DataRow, "HRS_ASSIGNED_EVENT", GetType(Decimal))
                        ResultSet1.HoursBalanceAvailable = GetRowValue(DataRow, "HRS_BALANCE_AVAIL", GetType(Decimal))
                        ResultSet1.Note = GetRowValue(DataRow, "NOTE", GetType(String))
                        ResultSet1.IsFullDayOff = GetRowValue(DataRow, "IS_FULL_DAY_OFF", GetType(Short))
                        ResultSet1.IsFirstChoice = GetRowValue(DataRow, "IS_FIRST_CHOICE", GetType(Integer))

                        ResultSet1List.Add(ResultSet1)

                    Next

                Catch ex As Exception
                    ResultSet1List = Nothing
                End Try

            End If

            CreateResultSet1List = ResultSet1List

        End Function
        Public Function CreateResultSet2List(ByVal DataTable As System.Data.DataTable) As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet2)

            'objects
            Dim ResultSet2List As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet2) = Nothing
            Dim ResultSet2 As AdvantageFramework.ProjectSchedule.Classes.ResultSet2 = Nothing

            If DataTable IsNot Nothing Then

                Try

                    ResultSet2List = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet2)

                    For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                        ResultSet2 = New AdvantageFramework.ProjectSchedule.Classes.ResultSet2

                        ResultSet2.EnteredStartDate = GetRowValue(DataRow, "ENTERED_START_DATE", GetType(Date))
                        ResultSet2.EnteredEndDate = GetRowValue(DataRow, "ENTERED_END_DATE", GetType(Date))
                        ResultSet2.CalculatedStartDate = GetRowValue(DataRow, "CALCULATED_START_DATE", GetType(Date))
                        ResultSet2.CalculatedEndDate = GetRowValue(DataRow, "CALCULATED_END_DATE", GetType(Date))
                        ResultSet2.NumberOfDays = GetRowValue(DataRow, "NUM_DAYS", GetType(Integer))
                        ResultSet2.NumberoOfWeeks = GetRowValue(DataRow, "NUM_WEEKS", GetType(Integer))
                        ResultSet2.NumberOfMonths = GetRowValue(DataRow, "NUM_MONTHS", GetType(Integer))
                        ResultSet2.NumberOfYears = GetRowValue(DataRow, "NUM_YEARS", GetType(Integer))
                        ResultSet2.NumberOfEmployees = GetRowValue(DataRow, "NUM_EMPS", GetType(Integer))

                        ResultSet2List.Add(ResultSet2)

                    Next

                Catch ex As Exception
                    ResultSet2List = Nothing
                End Try

            End If

            CreateResultSet2List = ResultSet2List

        End Function
        Public Function CreateResultSet3List(ByVal DataTable As System.Data.DataTable) As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet3)

            'objects
            Dim ResultSet3List As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet3) = Nothing
            Dim ResultSet3 As AdvantageFramework.ProjectSchedule.Classes.ResultSet3 = Nothing

            If DataTable IsNot Nothing Then

                Try

                    ResultSet3List = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet3)

                    For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                        ResultSet3 = New AdvantageFramework.ProjectSchedule.Classes.ResultSet3

                        ResultSet3.EmployeeCode = GetRowValue(DataRow, "EMP_CODE", GetType(String))
                        ResultSet3.EmployeeDirectHoursGoalPercent = GetRowValue(DataRow, "EMP_DIRECT_HRS_GOAL_PERC", GetType(Decimal))
                        ResultSet3.StandardHoursAvailable = GetRowValue(DataRow, "STD_HRS_AVAIL", GetType(Decimal))
                        ResultSet3.EmployeeDirectHoursGoalHours = GetRowValue(DataRow, "EMP_DIRECT_HRS_GOAL_HOURS", GetType(Decimal))
                        ResultSet3.HoursAssignedTask = GetRowValue(DataRow, "HRS_ASSIGNED_TASK", GetType(Decimal))
                        ResultSet3.HoursAppointments = GetRowValue(DataRow, "HRS_APPTS", GetType(Decimal))
                        ResultSet3.HoursUsedNonTask = GetRowValue(DataRow, "HRS_USED_NON_TASK", GetType(Decimal))
                        ResultSet3.HoursAvailable = GetRowValue(DataRow, "HRS_AVAIL", GetType(Decimal))
                        ResultSet3.HoursBalanceAvailable = GetRowValue(DataRow, "HRS_BALANCE_AVAIL", GetType(Decimal))
                        ResultSet3.PercentWorked = GetRowValue(DataRow, "PERC_WORKED", GetType(Decimal))
                        ResultSet3.OfficeCode = GetRowValue(DataRow, "OFFICE_CODE", GetType(String))
                        ResultSet3.OfficeName = GetRowValue(DataRow, "OFFICE_NAME", GetType(String))
                        ResultSet3.EmployeeFirstName = GetRowValue(DataRow, "EMP_FNAME", GetType(String))
                        ResultSet3.EmployeeMiddleInitial = GetRowValue(DataRow, "EMP_MI", GetType(String))
                        ResultSet3.EmployeeLastName = GetRowValue(DataRow, "EMP_LNAME", GetType(String))
                        ResultSet3.DepartmentTeamCode = GetRowValue(DataRow, "DP_TM_CODE", GetType(String))
                        ResultSet3.DepartmentTeamDescription = GetRowValue(DataRow, "DP_TM_DESC", GetType(String))
                        ResultSet3.EmployeeName = GetRowValue(DataRow, "EMP_FML_NAME", GetType(String))
                        ResultSet3.IsFirstChoice = GetRowValue(DataRow, "IS_FIRST_CHOICE", GetType(Short))
                        ResultSet3.EmployeeEndTime = GetRowValue(DataRow, "EMP_END_TIME", GetType(Date))
                        ResultSet3.EmployeeStartTime = GetRowValue(DataRow, "EMP_START_TIME", GetType(Date))
                        ResultSet3.EmployeeSeniority = GetRowValue(DataRow, "EMP_SENIORITY", GetType(Short))

                        ResultSet3List.Add(ResultSet3)

                    Next

                Catch ex As Exception
                    ResultSet3List = Nothing
                End Try

            End If

            CreateResultSet3List = ResultSet3List

        End Function
        Public Function CreateResultSet4List(ByVal DataTable As System.Data.DataTable) As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet4)

            'objects
            Dim ResultSet4List As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet4) = Nothing
            Dim ResultSet4 As AdvantageFramework.ProjectSchedule.Classes.ResultSet4 = Nothing

            If DataTable IsNot Nothing Then

                Try

                    ResultSet4List = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet4)

                    For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                        ResultSet4 = New AdvantageFramework.ProjectSchedule.Classes.ResultSet4

                        ResultSet4.CTR = GetRowValue(DataRow, "CTR", GetType(Integer))
                        ResultSet4.Year = GetRowValue(DataRow, "YEAR", GetType(Integer))
                        ResultSet4.WeekOfYear = GetRowValue(DataRow, "WEEK_OF_YEAR", GetType(Date))

                        ResultSet4List.Add(ResultSet4)

                    Next

                Catch ex As Exception
                    ResultSet4List = Nothing
                End Try

            End If

            CreateResultSet4List = ResultSet4List

        End Function
        Public Function CreateResultSet5List(ByVal DataTable As System.Data.DataTable) As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet5)

            'objects
            Dim ResultSet5List As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet5) = Nothing
            Dim ResultSet5 As AdvantageFramework.ProjectSchedule.Classes.ResultSet5 = Nothing

            If DataTable IsNot Nothing Then

                Try

                    ResultSet5List = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet5)

                    For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                        ResultSet5 = New AdvantageFramework.ProjectSchedule.Classes.ResultSet5

                        ResultSet5.EmployeeCode = GetRowValue(DataRow, "EMP_CODE", GetType(String))
                        ResultSet5.EmployeeDirectHoursGoalPercent = GetRowValue(DataRow, "EMP_DIRECT_HRS_GOAL_PERC", GetType(Decimal))
                        ResultSet5.DayOfYear = GetRowValue(DataRow, "DAY_OF_YEAR", GetType(Date)) ' Only for SummaryLevel = Day
                        ResultSet5.WeekOfYear = GetRowValue(DataRow, "WEEK_OF_YEAR", GetType(Date)) ' Only for SummaryLevel = Week
                        ResultSet5.MonthOfYear = GetRowValue(DataRow, "MONTH_OF_YEAR", GetType(Date)) ' Only for SummarLevel = Month
                        ResultSet5.Year = GetRowValue(DataRow, "YEAR", GetType(Date)) ' Only for SummaryLevel = Year
                        ResultSet5.StandardHoursAvailable = GetRowValue(DataRow, "STD_HRS_AVAIL", GetType(Decimal))
                        ResultSet5.EmployeeDirectHoursGoalHours = GetRowValue(DataRow, "EMP_DIRECT_HRS_GOAL_HOURS", GetType(Decimal))
                        ResultSet5.HoursUsedNonTask = GetRowValue(DataRow, "HRS_USED_NON_TASK", GetType(Decimal))
                        ResultSet5.HoursAvailable = GetRowValue(DataRow, "HRS_AVAIL", GetType(Decimal))
                        ResultSet5.HoursAssignedTask = GetRowValue(DataRow, "HRS_ASSIGNED_TASK", GetType(Decimal))
                        ResultSet5.HoursAppointments = GetRowValue(DataRow, "HRS_APPTS", GetType(Decimal))
                        ResultSet5.HoursBalanceAvailable = GetRowValue(DataRow, "HRS_BALANCE_AVAIL", GetType(Decimal))
                        ResultSet5.IsFirstChoice = GetRowValue(DataRow, "IS_FIRST_CHOICE", GetType(Short))
                        ResultSet5.IsOverBooked = GetRowValue(DataRow, "OVER_BOOKED", GetType(Short))

                        ResultSet5List.Add(ResultSet5)

                    Next

                Catch ex As Exception
                    ResultSet5List = Nothing
                End Try

            End If

            CreateResultSet5List = ResultSet5List

        End Function
        Public Function CreateResultSet6List(ByVal DataTable As System.Data.DataTable) As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet6)

            'objects
            Dim ResultSet6List As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet6) = Nothing
            Dim ResultSet6 As AdvantageFramework.ProjectSchedule.Classes.ResultSet6 = Nothing

            If DataTable IsNot Nothing Then

                Try

                    ResultSet6List = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet6)

                    For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                        ResultSet6 = New AdvantageFramework.ProjectSchedule.Classes.ResultSet6

                        ResultSet6.ID = GetRowValue(DataRow, "ROW_ID", GetType(Integer))
                        ResultSet6.JobNumber = GetRowValue(DataRow, "JOB_NUMBER", GetType(Integer))
                        ResultSet6.JobComponentNumber = GetRowValue(DataRow, "JOB_COMPONENT_NBR", GetType(Short))
                        ResultSet6.FunctionCode = GetRowValue(DataRow, "FNC_CODE", GetType(String))
                        ResultSet6.TaskDescription = GetRowValue(DataRow, "TASK_DESCRIPTION", GetType(String))
                        ResultSet6.JobComponentDescription = GetRowValue(DataRow, "JOB_COMP_DESC", GetType(String))
                        ResultSet6.TaskStartDate = GetRowValue(DataRow, "TASK_START_DATE", GetType(Date))
                        ResultSet6.JobRevisedDate = GetRowValue(DataRow, "JOB_REVISED_DATE", GetType(Date))
                        ResultSet6.EmployeeCode = GetRowValue(DataRow, "EMP_CODE", GetType(String))
                        ResultSet6.JobDescription = GetRowValue(DataRow, "JOB_DESC", GetType(String))
                        ResultSet6.OfficeCode = GetRowValue(DataRow, "OFFICE_CODE", GetType(String))
                        ResultSet6.DepartmentTeamCode = GetRowValue(DataRow, "DP_TM_CODE", GetType(String))
                        ResultSet6.ClientCode = GetRowValue(DataRow, "CL_CODE", GetType(String))
                        ResultSet6.DivisionCode = GetRowValue(DataRow, "DIV_CODE", GetType(String))
                        ResultSet6.ProductCode = GetRowValue(DataRow, "PRD_CODE", GetType(String))
                        ResultSet6.Sort = GetRowValue(DataRow, "SORT", GetType(Date))
                        ResultSet6.JobHours = GetRowValue(DataRow, "JOB_HRS", GetType(Decimal))
                        ResultSet6.SequenceNumber = GetRowValue(DataRow, "SEQ_NBR", GetType(Short))
                        ResultSet6.EmployeeName = GetRowValue(DataRow, "EMP_FML_NAME", GetType(String))
                        ResultSet6.IsEventTask = GetRowValue(DataRow, "IS_EVENT_TASK", GetType(Short))
                        ResultSet6.TaskTotalWorkingDays = GetRowValue(DataRow, "TASK_TOTAL_WORKING_DAYS", GetType(Integer))
                        ResultSet6.HoursPerDay = GetRowValue(DataRow, "HOURS_PER_DAY", GetType(Decimal))
                        ResultSet6.AdjustedJobHours = GetRowValue(DataRow, "ADJ_JOB_HRS", GetType(Decimal))
                        ResultSet6.RecType = GetRowValue(DataRow, "REC_TYPE", GetType(String))
                        ResultSet6.NonTaskID = GetRowValue(DataRow, "NON_TASK_ID", GetType(Short))
                        ResultSet6.HoursUsedNonTask = GetRowValue(DataRow, "HRS_USED_NON_TASK", GetType(Decimal))
                        ResultSet6.HoursAvailable = GetRowValue(DataRow, "HRS_AVAIL", GetType(Decimal))
                        ResultSet6.HoursAssignedTask = GetRowValue(DataRow, "HRS_ASSIGNED_TASK", GetType(Decimal))
                        ResultSet6.HoursAssignedEvent = GetRowValue(DataRow, "HRS_ASSIGNED_EVENT", GetType(Decimal))
                        ResultSet6.TotalHoursAssigned = GetRowValue(DataRow, "TOTAL_HRS_ASSIGNED", GetType(Decimal))
                        ResultSet6.HoursBalanceAvailable = GetRowValue(DataRow, "HRS_BALANCE_AVAIL", GetType(Decimal))
                        ResultSet6.Variance = GetRowValue(DataRow, "VARIANCE", GetType(Decimal))
                        ResultSet6.StandardHoursAvailable = GetRowValue(DataRow, "STD_HRS_AVAIL", GetType(Decimal))
                        ResultSet6.RedFlag = GetRowValue(DataRow, "RED_FLAG", GetType(Integer))
                        ResultSet6.HoursPerDayWithAssignment = GetRowValue(DataRow, "HRS_PER_DAY_WITH_ASSN", GetType(Decimal))
                        ResultSet6.AdjustedJobHoursWithAssignment = GetRowValue(DataRow, "ADJ_JOB_HRS_WITH_ASSN", GetType(Decimal))

                        ResultSet6List.Add(ResultSet6)

                    Next

                Catch ex As Exception
                    ResultSet6List = Nothing
                End Try

            End If

            CreateResultSet6List = ResultSet6List

        End Function
        Public Function CreateResultSet7List(ByVal DataTable As System.Data.DataTable) As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet7)

            'objects
            Dim ResultSet7List As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet7) = Nothing
            Dim ResultSet7 As AdvantageFramework.ProjectSchedule.Classes.ResultSet7 = Nothing

            If DataTable IsNot Nothing Then

                Try

                    ResultSet7List = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet7)

                    For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                        ResultSet7 = New AdvantageFramework.ProjectSchedule.Classes.ResultSet7

                        ResultSet7.TotalJobDue = GetRowValue(DataRow, "TOTAL_JOB_DUE", GetType(Integer))
                        ResultSet7.StandardHoursAvailable = GetRowValue(DataRow, "STD_HRS_AVAIL", GetType(Decimal))
                        ResultSet7.AppointmentHours = GetRowValue(DataRow, "APPT_HRS", GetType(Decimal))
                        ResultSet7.HoursOff = GetRowValue(DataRow, "HRS_OFF", GetType(Decimal))
                        ResultSet7.HoursAssignedTask = GetRowValue(DataRow, "HRS_ASSIGNED_TASK", GetType(Decimal))
                        ResultSet7.ShowUnassigned = GetRowValue(DataRow, "SHOW_UNASSIGNED", GetType(Short))

                        ResultSet7List.Add(ResultSet7)

                    Next

                Catch ex As Exception
                    ResultSet7List = Nothing
                End Try

            End If

            CreateResultSet7List = ResultSet7List

        End Function
        Public Function CreateResultSet8List(ByVal DataTable As System.Data.DataTable) As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet8)

            'objects
            Dim ResultSet8List As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet8) = Nothing
            Dim ResultSet8 As AdvantageFramework.ProjectSchedule.Classes.ResultSet8 = Nothing

            If DataTable IsNot Nothing Then

                Try

                    ResultSet8List = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet8)

                    For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                        ResultSet8 = New AdvantageFramework.ProjectSchedule.Classes.ResultSet8

                        ResultSet8.EmployeeCode = GetRowValue(DataRow, "EMP_CODE", GetType(String))
                        ResultSet8.EmployeeName = GetRowValue(DataRow, "EMP_FML_NAME", GetType(String))
                        ResultSet8.MinimumDate = GetRowValue(DataRow, "MIN_DATE", GetType(Date))
                        ResultSet8.MaximumDate = GetRowValue(DataRow, "MAX_DATE", GetType(Date))
                        ResultSet8.StandardHoursAvailable = GetRowValue(DataRow, "STD_HRS_AVAIL", GetType(Decimal))
                        ResultSet8.HoursOff = GetRowValue(DataRow, "HRS_OFF", GetType(Decimal))
                        ResultSet8.AppointmentHours = GetRowValue(DataRow, "APPT_HRS", GetType(Decimal))
                        ResultSet8.AdjustedHoursAssignedTask = GetRowValue(DataRow, "ADJ_HRS_ASSIGNED_TASK", GetType(Decimal))
                        ResultSet8.AdjustedHoursAssignedTask_OTHER = GetRowValue(DataRow, "ADJ_HRS_ASSIGNED_TASK_OTHER", GetType(Decimal))
                        ResultSet8.Variance = GetRowValue(DataRow, "VARIANCE", GetType(Decimal))

                        ResultSet8List.Add(ResultSet8)

                    Next

                Catch ex As Exception
                    ResultSet8List = Nothing
                End Try

            End If

            CreateResultSet8List = ResultSet8List

        End Function
        Public Function CreateResultSet9List(ByVal DataTable As System.Data.DataTable) As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet9)

            'objects
            Dim ResultSet9List As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet9) = Nothing
            Dim ResultSet9 As AdvantageFramework.ProjectSchedule.Classes.ResultSet9 = Nothing

            If DataTable IsNot Nothing Then

                Try

                    ResultSet9List = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet9)

                    For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                        ResultSet9 = New AdvantageFramework.ProjectSchedule.Classes.ResultSet9

                        ResultSet9.EmployeeCode = GetRowValue(DataRow, "EMP_CODE", GetType(String))
                        ResultSet9.IsOverBooked = GetRowValue(DataRow, "OVER_BOOKED", GetType(Integer))

                        ResultSet9List.Add(ResultSet9)

                    Next

                Catch ex As Exception
                    ResultSet9List = Nothing
                End Try

            End If

            CreateResultSet9List = ResultSet9List

        End Function
        Public Function CreateResultSet10List(ByVal DataTable As System.Data.DataTable) As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet10)

            'objects
            Dim ResultSet10List As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet10) = Nothing
            Dim ResultSet10 As AdvantageFramework.ProjectSchedule.Classes.ResultSet10 = Nothing

            If DataTable IsNot Nothing Then

                Try

                    ResultSet10List = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet10)

                    For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                        ResultSet10 = New AdvantageFramework.ProjectSchedule.Classes.ResultSet10

                        ResultSet10.EmployeeCode = GetRowValue(DataRow, "EMP_CODE", GetType(String))
                        ResultSet10.HoursAssignedEvent = GetRowValue(DataRow, "HRS_ASSIGNED_EVENT", GetType(Decimal))
                        ResultSet10.HoursUsedNonTask = GetRowValue(DataRow, "HRS_USED_NON_TASK", GetType(Decimal))
                        ResultSet10.HoursAvailable = GetRowValue(DataRow, "HRS_AVAIL", GetType(Decimal))
                        ResultSet10.HoursAssignedTask = GetRowValue(DataRow, "HRS_ASSIGNED_TASK", GetType(Decimal))
                        ResultSet10.HoursAppointments = GetRowValue(DataRow, "HRS_APPTS", GetType(Decimal))
                        ResultSet10.HoursBalanceAvailable = GetRowValue(DataRow, "HRS_BALANCE_AVAIL", GetType(Decimal))

                        ResultSet10List.Add(ResultSet10)

                    Next

                Catch ex As Exception
                    ResultSet10List = Nothing
                End Try

            End If

            CreateResultSet10List = ResultSet10List

        End Function
        Public Function AddTaskToSchedule(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal TaskDetail As AdvantageFramework.ProjectSchedule.Classes.TaskDetail,
                                          ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                          ByVal RushDelivery As Boolean, ByVal SyncWithOutlook As Boolean) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

            Try

                If TaskDetail IsNot Nothing Then

                    JobComponentTask = New AdvantageFramework.Database.Entities.JobComponentTask

                    JobComponentTask.JobNumber = JobNumber
                    JobComponentTask.JobComponentNumber = JobComponentNumber
                    JobComponentTask.OrderNumber = TaskDetail.ProcessOrderNumber
                    JobComponentTask.PhaseID = TaskDetail.PhaseID
                    JobComponentTask.TaskCode = TaskDetail.TaskCode
                    JobComponentTask.Description = TaskDetail.TaskDescription
                    JobComponentTask.IsMilestone = TaskDetail.IsMilestone
                    JobComponentTask.EmployeeCode = TaskDetail.DefaultEmployeeCode

                    If RushDelivery Then

                        JobComponentTask.Days = TaskDetail.RushDaysToComplete
                        JobComponentTask.Hours = TaskDetail.RushHoursToComplete

                    Else

                        JobComponentTask.Days = TaskDetail.DaysToComplete
                        JobComponentTask.Hours = TaskDetail.HoursAllowed

                    End If

                    JobComponentTask.RoleCode = TaskDetail.RoleCode
                    JobComponentTask.FuctionCode = TaskDetail.FunctionCode
                    JobComponentTask.StatusCode = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.ProjectSchedule.TaskStatus.Projected).Code

                    If AdvantageFramework.Database.Procedures.JobComponentTask.Insert(DbContext, JobComponentTask) = True Then

                        If SyncWithOutlook Then

                            'AdvantageFramework.Calendar.Outlook.SyncJobComponentTask(DbContext, JobComponentTask, False)

                        End If

                        Added = True

                    End If

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddTaskToSchedule = Added
            End Try

        End Function
        Public Function AddTaskToSchedule(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal EstimateTask As AdvantageFramework.Database.Classes.EstimateTask,
                                          ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                          ByVal IncludeEmployees As Boolean, ByVal IncludeHours As Boolean,
                                          ByVal SyncWithOutlook As Boolean) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

            Try

                If EstimateTask IsNot Nothing Then

                    JobComponentTask = New AdvantageFramework.Database.Entities.JobComponentTask

                    JobComponentTask.JobNumber = JobNumber
                    JobComponentTask.JobComponentNumber = JobComponentNumber
                    JobComponentTask.OrderNumber = EstimateTask.TaskOrder
                    JobComponentTask.TaskCode = EstimateTask.TaskCode
                    JobComponentTask.Description = EstimateTask.TaskDescription
                    JobComponentTask.IsMilestone = EstimateTask.IsMilestone
                    JobComponentTask.Days = EstimateTask.DaysToComplete
                    JobComponentTask.Hours = EstimateTask.HoursAllowed
                    JobComponentTask.RoleCode = EstimateTask.DefaultRole
                    JobComponentTask.FuctionCode = EstimateTask.EstimateFunctionCode
                    JobComponentTask.StatusCode = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.ProjectSchedule.TaskStatus.Projected).Code

                    If IncludeEmployees Then

                        JobComponentTask.EmployeeCode = EstimateTask.EmployeeCode

                    End If

                    If IncludeHours Then

                        JobComponentTask.Hours = EstimateTask.EstimateRevisionQuantity

                    End If

                    If AdvantageFramework.Database.Procedures.JobComponentTask.Insert(DbContext, JobComponentTask) = True Then

                        If SyncWithOutlook Then

                            'AdvantageFramework.Calendar.Outlook.SyncJobComponentTask(DbContext, JobComponentTask, False)

                        End If

                        Added = True

                    End If

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddTaskToSchedule = Added
            End Try

        End Function
        Public Function LoadAvailableTasks(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal LoadTemplates As Boolean) As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.TaskDetail)

            Try

                LoadAvailableTasks = DbContext.Database.SqlQuery(Of AdvantageFramework.ProjectSchedule.Classes.TaskDetail)(String.Format("EXEC [dbo].[advsp_Traffic_Schedule_LoadTasksToAdd] {0}", If(LoadTemplates, 1, 0))).ToList

            Catch ex As Exception
                LoadAvailableTasks = Nothing
            End Try

        End Function
        Public Function ApplyTeamByFunction(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Boolean

            'objects
            Dim Applied As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[usp_wv_Traffic_Schedule_ApplyTeam_ByFunction] {0}, {1}", JobNumber, JobComponentNumber))

                Applied = True

            Catch ex As Exception
                Applied = False
            Finally
                ApplyTeamByFunction = Applied
            End Try

        End Function
        Public Function ApplyTeamByRole(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Boolean

            'objects
            Dim Applied As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[usp_wv_Traffic_Schedule_ApplyTeam_ByRole] {0}, {1}", JobNumber, JobComponentNumber))

                Applied = True

            Catch ex As Exception
                Applied = False
            Finally
                ApplyTeamByRole = Applied
            End Try

        End Function
        Public Function ApplyTeam(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ByFunction As Boolean, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Boolean

            If ByFunction Then

                ApplyTeam = ApplyTeamByFunction(DbContext, JobNumber, JobComponentNumber)

            Else

                ApplyTeam = ApplyTeamByRole(DbContext, JobNumber, JobComponentNumber)

            End If

        End Function
        Public Function MarkTempComplete(ByVal Session As AdvantageFramework.Security.Session, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Marked As Boolean = False
            Dim ActivateNextTask As Boolean = False
            Dim AlertNextEmployee As Boolean = False
            Dim JobComponentTasks As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTask) = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim SequenceNumbersToUpdate As Generic.List(Of Short) = Nothing
            Dim NextSequenceNumbers As Short() = Nothing
            Dim AlertID As Integer = Nothing
            Dim EmployeeCodes As String = Nothing

            Try

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        ActivateNextTask = LoadActivateNextTaskSetting(DataContext)

                        AlertNextEmployee = LoadAutoAlertEmployeeSetting(DataContext)

                        SequenceNumbersToUpdate = New Generic.List(Of Short)

                        JobComponentTasks = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTask.Load(DbContext)
                                             Where Entity.JobNumber = JobNumber AndAlso
                                                   Entity.JobComponentNumber = JobComponentNumber AndAlso
                                                   Entity.TempCompletionDate IsNot Nothing AndAlso
                                                   Entity.CompletedDate Is Nothing
                                             Order By Entity.StartDate,
                                                     Entity.DueDate,
                                                     Entity.OriginalDueDate,
                                                     Entity.OrderNumber Ascending,
                                                     Entity.SequenceNumber Ascending).ToList

                        For Each JobComponentTask In JobComponentTasks

                            JobComponentTask.CompletedDate = JobComponentTask.TempCompletionDate

                            If AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask) Then

                                Marked = True

                                If ActivateNextTask Then

                                    If SetNextTaskActive(DbContext, DataContext, JobNumber, JobComponentNumber, JobComponentTask.SequenceNumber, NextSequenceNumbers) Then

                                        If AlertNextEmployee Then

                                            If NextSequenceNumbers.Count > 0 Then

                                                For Each SequenceNumber In NextSequenceNumbers

                                                    If SequenceNumbersToUpdate.Contains(SequenceNumber) = False Then

                                                        SequenceNumbersToUpdate.Add(SequenceNumber)

                                                    End If

                                                Next

                                            End If

                                        End If

                                    End If

                                End If

                                'AdvantageFramework.ProjectManagement.Agile.ClearAllocatedHours(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber,
                                '                                                               JobComponentTask.SequenceNumber, Session.User.EmployeeCode, False)

                            End If

                        Next

                        If AlertNextEmployee Then

                            For Each DistinctSequenceNumber In SequenceNumbersToUpdate.Distinct

                                AlertID = CreateTaskAlert(DbContext, JobNumber, JobComponentNumber, DistinctSequenceNumber, Session.User.EmployeeCode, EmployeeCodes, ErrorMessage)

                                If AlertID > 0 Then

                                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                                    If Alert IsNot Nothing Then

                                        AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session, Alert, "[Alert Updated]", EmployeeCodes, IsClientPortal:=If(Session.ClientPortalUser Is Nothing, False, True))

                                    End If

                                End If

                                EmployeeCodes = ""
                                AlertID = 0

                            Next

                        End If

                    End Using

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message
                Marked = False
            Finally
                MarkTempComplete = Marked
            End Try

        End Function
        Public Function SetNextTaskActive(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal DataContext As AdvantageFramework.Database.DataContext,
                                          ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short, ByRef NextSequenceNumbers() As Short) As Boolean

            'objects
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim NextJobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim SequenceNumberList As Generic.List(Of Short) = Nothing
            Dim Completed As Boolean = False
            Dim ReturnMessage As String = String.Empty
            Try

                Try

                    SequenceNumberList = SetNextTaskActive(DbContext, JobNumber, JobComponentNumber, SequenceNumber, ReturnMessage).Rows.OfType(Of System.Data.DataRow).Select(Function(dr) CShort(dr("SEQ_NBR"))).ToList

                Catch ex As Exception
                    Completed = False
                End Try

                If SequenceNumberList IsNot Nothing AndAlso SequenceNumberList.Count > 0 AndAlso LoadAutoAlertEmployeeSetting(DataContext) = False Then

                    SequenceNumberList.Clear()

                End If

                NextSequenceNumbers = SequenceNumberList.ToArray
                Completed = True

            Catch ex As Exception
                Completed = False
            Finally
                SetNextTaskActive = Completed
            End Try

        End Function
        Private Function SetNextTaskActive(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer,
                                           ByVal SeqNbr As Integer, Optional ByVal ErrorMessage As String = "") As DataTable
            Try
                Dim MyDatatable As New DataTable
                Using MyConn As New SqlClient.SqlConnection(DbContext.ConnectionString)

                    Dim MyCommand As New SqlClient.SqlCommand()

                    With MyCommand

                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_Traffic_Schedule_SetNextTaskActive"
                        .Connection = MyConn

                    End With

                    Dim pJobNumber As New SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                    pJobNumber.Value = JobNumber
                    MyCommand.Parameters.Add(pJobNumber)
                    Dim pJobComponentNbr As New SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                    pJobComponentNbr.Value = JobComponentNbr
                    MyCommand.Parameters.Add(pJobComponentNbr)
                    Dim pSeqNbr As New SqlClient.SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                    pSeqNbr.Value = SeqNbr

                    MyCommand.Parameters.Add(pSeqNbr)
                    MyConn.Open()
                    MyDatatable.Load(MyCommand.ExecuteReader)

                End Using

                ErrorMessage = ""
                Return MyDatatable

            Catch ex As Exception

                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Return Nothing

            End Try
        End Function

        'Public Function LoadNextTask(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal CurrentSequenceNumber As Short) As AdvantageFramework.Database.Entities.JobComponentTask

        '    'objects
        '    Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

        '    Try

        '        JobComponentTask = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTask.Load(DbContext)
        '                            Where Entity.JobNumber = JobNumber AndAlso
        '                                  Entity.JobComponentNumber = JobComponentNumber AndAlso
        '                                  Entity.SequenceNumber > CurrentSequenceNumber
        '                            Order By Entity.SequenceNumber
        '                            Select Entity).FirstOrDefault

        '    Catch ex As Exception
        '        JobComponentTask = Nothing
        '    Finally
        '        LoadNextTask = JobComponentTask
        '    End Try

        'End Function
        Public Function LoadActivateNextTaskSetting(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim ActivateNextTask As Boolean = False

            Try

                ActivateNextTask = CBool(AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.TRF_ACTIVE_NEXT_TASK.ToString).Value)

            Catch ex As Exception
                ActivateNextTask = False
            Finally
                LoadActivateNextTaskSetting = ActivateNextTask
            End Try

        End Function
        Public Function LoadAutoAlertEmployeeSetting(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim AutoAlertEmployee As Boolean = False

            Try

                AutoAlertEmployee = CBool(AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.TRF_NXT_TSK_AUTO_EML.ToString).Value)

            Catch ex As Exception
                AutoAlertEmployee = False
            Finally
                LoadAutoAlertEmployeeSetting = AutoAlertEmployee
            End Try

        End Function
        Public Function LoadClientContacts(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           Optional ByVal JobNumber As Integer = 0, Optional ByVal JobComponentNumber As Short = 0,
                                           Optional ByVal SequenceNumber As Short = -1, Optional ByVal ClientCode As String = Nothing,
                                           Optional ByVal DivisionCode As String = Nothing, Optional ByVal ProductCode As String = Nothing) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ClientContact)

            'objects
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim ClientContactIDs As Integer() = Nothing
            Dim ResultSet As Object = Nothing

            Try

                If JobNumber > 0 AndAlso JobComponentNumber > 0 AndAlso SequenceNumber > -1 Then

                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)

                    If Job IsNot Nothing Then

                        Try

                            ClientContactIDs = (From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext)
                                                Where (Entity.ClientContact.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode AndAlso Entity.ProductCode = ProductCode) OrElse
                                                      (Entity.ClientContact.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode AndAlso Entity.ProductCode Is Nothing) OrElse
                                                      (Entity.ClientContact.ClientCode = ClientCode AndAlso Entity.DivisionCode Is Nothing AndAlso Entity.ProductCode Is Nothing)
                                                Select Entity.ContactID).Distinct.ToArray

                        Catch ex As Exception
                            ClientContactIDs = Nothing
                        End Try

                    End If

                ElseIf String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) AndAlso String.IsNullOrEmpty(ProductCode) Then

                    Try

                        ClientContactIDs = (From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext)
                                            Where Entity.ClientContact.ClientCode = ClientCode
                                            Select Entity.ContactID).Distinct.ToArray

                    Catch ex As Exception
                        ClientContactIDs = Nothing
                    End Try

                Else

                    Try

                        ClientContactIDs = (From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext)
                                            Where (Entity.ClientContact.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode AndAlso Entity.ProductCode = ProductCode) OrElse
                                                  (Entity.ClientContact.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode AndAlso Entity.ProductCode Is Nothing) OrElse
                                                  (Entity.ClientContact.ClientCode = ClientCode AndAlso Entity.DivisionCode Is Nothing AndAlso Entity.ProductCode Is Nothing)
                                            Select Entity.ContactID).Distinct.ToArray

                    Catch ex As Exception
                        ClientContactIDs = Nothing
                    End Try

                End If

                If ClientContactIDs IsNot Nothing AndAlso ClientContactIDs.Count > 0 Then

                    ResultSet = From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadAllActive(DbContext)
                                Where ClientContactIDs.Contains(Entity.ContactID) AndAlso
                                      Entity.ScheduleUser = 1
                                Select Entity

                End If

            Catch ex As Exception
                ResultSet = Nothing
            Finally
                LoadClientContacts = ResultSet
            End Try

        End Function
        Public Function SearchAndReplaceTasks(ByVal Session As AdvantageFramework.Security.Session, ByVal JobTrafficIDs As Integer(),
                                              ByVal FindAndReplaceField As AdvantageFramework.ProjectSchedule.FindAndReplaceFields, ByVal SearchForValue As Object,
                                              ByVal ReplaceWithValue As Object, ByVal AdditionalCriteria As Object, ByRef ReturnMessage As String) As Boolean

            'objects
            Dim Completed As Boolean = False
            Dim RowsChanged As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If ValidateSearchAndReplaceFieldValues(DbContext, FindAndReplaceField, SearchForValue, ReplaceWithValue, AdditionalCriteria, ReturnMessage) Then

                        Select Case FindAndReplaceField

                            Case ProjectSchedule.FindAndReplaceFields.StartDate

                                Completed = SearchAndReplace_StartDate(DbContext, JobTrafficIDs, SearchForValue, AdditionalCriteria, ReplaceWithValue, RowsChanged)

                            Case ProjectSchedule.FindAndReplaceFields.DueDate

                                Completed = SearchAndReplace_DueDate(DbContext, JobTrafficIDs, SearchForValue, AdditionalCriteria, ReplaceWithValue, RowsChanged)

                            Case ProjectSchedule.FindAndReplaceFields.TimeDue

                                Completed = SearchAndReplace_TimeDue(DbContext, JobTrafficIDs, SearchForValue, ReplaceWithValue, RowsChanged)

                            Case ProjectSchedule.FindAndReplaceFields.CompletedDate

                                Completed = SearchAndReplace_CompletedDate(DbContext, JobTrafficIDs, SearchForValue, AdditionalCriteria, ReplaceWithValue, RowsChanged)

                            Case ProjectSchedule.FindAndReplaceFields.EmployeeAssignment

                                Completed = SearchAndReplace_EmployeeAssignment(DbContext, JobTrafficIDs, SearchForValue, ReplaceWithValue, AdditionalCriteria, RowsChanged)

                            Case ProjectSchedule.FindAndReplaceFields.ClientContactAssignment

                                Completed = SearchAndReplace_ClientContactAssignment(DbContext, JobTrafficIDs, SearchForValue, ReplaceWithValue, RowsChanged)

                            Case ProjectSchedule.FindAndReplaceFields.TaskStatus

                                Completed = SearchAndReplace_TaskStatus(DbContext, JobTrafficIDs, SearchForValue, ReplaceWithValue, RowsChanged)

                            Case ProjectSchedule.FindAndReplaceFields.Manager

                                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                                    Completed = SearchAndReplace_Manager(DbContext, DataContext, JobTrafficIDs, SearchForValue, ReplaceWithValue, RowsChanged)

                                End Using

                        End Select

                    End If

                End Using

                If Completed Then

                    ReturnMessage = FormatReturnMessage(FindAndReplaceField, SearchForValue, ReplaceWithValue, AdditionalCriteria, RowsChanged)

                End If

            Catch ex As Exception
                ReturnMessage = "There was an error processing tasks."
                Completed = False
            Finally
                SearchAndReplaceTasks = Completed
            End Try

        End Function
        Private Function SearchAndReplace_StartDate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTrafficIDs As Integer(),
                                                    ByVal SearchForDateFrom As Date, ByVal SearchForDateTo As Date, ByVal ReplaceWithDate As Date, ByRef RowsChanged As Integer) As Boolean

            'objects
            Dim Completed As Boolean = True
            Dim DoUpdate As Boolean = False
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing

            Try

                RowsChanged = 0

                For Each JobTrafficID In JobTrafficIDs

                    JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByID(DbContext, JobTrafficID)

                    If JobTraffic IsNot Nothing Then

                        For Each JobComponentTask In (From Entity In AdvantageFramework.Database.Procedures.JobComponentTask.Load(DbContext)
                                                      Where Entity.JobNumber = JobTraffic.JobNumber AndAlso
                                                            Entity.JobComponentNumber = JobTraffic.JobComponentNumber
                                                      Select Entity).ToList

                            If SearchForDateFrom = Nothing Then

                                If JobComponentTask.StartDate.HasValue = False Then

                                    DoUpdate = True

                                End If

                            ElseIf SearchForDateTo = Nothing Then

                                If JobComponentTask.StartDate = SearchForDateFrom Then

                                    DoUpdate = True

                                End If

                            ElseIf JobComponentTask.StartDate >= SearchForDateFrom AndAlso JobComponentTask.StartDate <= SearchForDateTo Then

                                DoUpdate = True

                            End If

                            If DoUpdate Then

                                JobComponentTask.StartDate = ReplaceWithDate

                                If AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask) Then

                                    RowsChanged = RowsChanged + 1

                                End If

                            End If

                            DoUpdate = False

                        Next

                    End If

                Next

            Catch ex As Exception
                Completed = False
            Finally
                SearchAndReplace_StartDate = Completed
            End Try

        End Function
        Private Function SearchAndReplace_DueDate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTrafficIDs As Integer(),
                                                  ByVal SearchForDateFrom As Date, ByVal SearchForDateTo As Date, ByVal ReplaceWithDate As Date, ByRef RowsChanged As Integer) As Boolean

            'objects
            Dim Completed As Boolean = True
            Dim DoUpdate As Boolean = False
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing

            Try

                RowsChanged = 0

                For Each JobTrafficID In JobTrafficIDs

                    JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByID(DbContext, JobTrafficID)

                    If JobTraffic IsNot Nothing Then

                        For Each JobComponentTask In (From Entity In AdvantageFramework.Database.Procedures.JobComponentTask.Load(DbContext)
                                                      Where Entity.JobNumber = JobTraffic.JobNumber AndAlso
                                                            Entity.JobComponentNumber = JobTraffic.JobComponentNumber
                                                      Select Entity).ToList

                            If SearchForDateFrom = Nothing Then

                                If JobComponentTask.DueDate.HasValue = False Then

                                    DoUpdate = True

                                End If

                            ElseIf SearchForDateTo = Nothing Then

                                If JobComponentTask.DueDate = SearchForDateFrom Then

                                    DoUpdate = True

                                End If

                            ElseIf JobComponentTask.DueDate >= SearchForDateFrom AndAlso JobComponentTask.DueDate <= SearchForDateTo Then

                                DoUpdate = True

                            End If

                            If DoUpdate Then

                                JobComponentTask.DueDate = ReplaceWithDate

                                If AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask) Then

                                    RowsChanged = RowsChanged + 1

                                End If

                            End If

                            DoUpdate = False

                        Next

                    End If

                Next

            Catch ex As Exception
                Completed = False
            Finally
                SearchAndReplace_DueDate = Completed
            End Try

        End Function
        Private Function SearchAndReplace_TimeDue(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTrafficIDs As Integer(),
                                                  ByVal SearchForTimeDue As String, ByVal ReplaceWithTimeDue As String, ByRef RowsChanged As Integer) As Boolean

            'objects
            Dim Completed As Boolean = True
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing

            Try

                RowsChanged = 0

                For Each JobTrafficID In JobTrafficIDs

                    JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByID(DbContext, JobTrafficID)

                    If JobTraffic IsNot Nothing Then

                        For Each JobComponentTask In (From Entity In AdvantageFramework.Database.Procedures.JobComponentTask.Load(DbContext)
                                                      Where Entity.JobNumber = JobTraffic.JobNumber AndAlso
                                                            Entity.JobComponentNumber = JobTraffic.JobComponentNumber AndAlso
                                                            Entity.DueTime = SearchForTimeDue
                                                      Select Entity).ToList

                            JobComponentTask.DueTime = ReplaceWithTimeDue

                            If AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask) Then

                                RowsChanged = RowsChanged + 1

                            End If

                        Next

                    End If

                Next

            Catch ex As Exception
                Completed = False
            Finally
                SearchAndReplace_TimeDue = Completed
            End Try

        End Function
        Private Function SearchAndReplace_CompletedDate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTrafficIDs As Integer(),
                                                        ByVal SearchForDateFrom As Date, ByVal SearchForDateTo As Date, ByVal ReplaceWithDate As Date, ByRef RowsChanged As Integer) As Boolean

            'objects
            Dim Completed As Boolean = True
            Dim DoUpdate As Boolean = False
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing

            Try

                RowsChanged = 0

                For Each JobTrafficID In JobTrafficIDs

                    JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByID(DbContext, JobTrafficID)

                    If JobTraffic IsNot Nothing Then

                        For Each JobComponentTask In (From Entity In AdvantageFramework.Database.Procedures.JobComponentTask.Load(DbContext)
                                                      Where Entity.JobNumber = JobTraffic.JobNumber AndAlso
                                                            Entity.JobComponentNumber = JobTraffic.JobComponentNumber
                                                      Select Entity).ToList

                            If SearchForDateFrom = Nothing Then

                                If JobComponentTask.CompletedDate.HasValue = False Then

                                    DoUpdate = True

                                End If

                            ElseIf SearchForDateTo = Nothing Then

                                If JobComponentTask.CompletedDate = SearchForDateFrom Then

                                    DoUpdate = True

                                End If

                            ElseIf JobComponentTask.CompletedDate >= SearchForDateFrom AndAlso JobComponentTask.CompletedDate <= SearchForDateTo Then

                                DoUpdate = True

                            End If

                            If DoUpdate Then

                                JobComponentTask.CompletedDate = ReplaceWithDate

                                If AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask) Then

                                    RowsChanged = RowsChanged + 1

                                End If

                            End If

                            DoUpdate = False

                        Next

                    End If

                Next

            Catch ex As Exception
                Completed = False
            Finally
                SearchAndReplace_CompletedDate = Completed
            End Try

        End Function
        Private Function SearchAndReplace_EmployeeAssignment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTrafficIDs As Integer(),
                                                             ByVal SearchForEmployeeCode As String, ByVal ReplaceWithEmployeeCode As String, ByVal TaskCode As String, ByRef RowsChanged As Integer) As Boolean

            'objects
            Dim Completed As Boolean = True
            Dim JobComponentTaskEmployeeList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTaskEmployee) = Nothing
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing

            Try

                RowsChanged = 0

                For Each JobTrafficID In JobTrafficIDs

                    JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByID(DbContext, JobTrafficID)

                    If JobTraffic IsNot Nothing Then

                        If String.IsNullOrEmpty(TaskCode) = False Then

                            JobComponentTaskEmployeeList = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Load(DbContext).Include("JobComponetTask")
                                                            Where Entity.JobNumber = JobTraffic.JobNumber AndAlso
                                                                        Entity.JobComponentNumber = JobTraffic.JobComponentNumber AndAlso
                                                                  Entity.EmployeeCode = SearchForEmployeeCode AndAlso
                                                                  Entity.JobComponetTask.TaskCode = TaskCode
                                                            Select Entity).ToList

                        Else

                            JobComponentTaskEmployeeList = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Load(DbContext)
                                                            Where Entity.JobNumber = JobTraffic.JobNumber AndAlso
                                                                    Entity.JobComponentNumber = JobTraffic.JobComponentNumber AndAlso
                                                                    Entity.EmployeeCode = SearchForEmployeeCode
                                                            Select Entity).ToList

                        End If

                        For Each JobComponentTaskEmployee In JobComponentTaskEmployeeList

                            If String.IsNullOrEmpty(ReplaceWithEmployeeCode) Then

                                If AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Delete(DbContext, JobComponentTaskEmployee) Then

                                    RowsChanged = RowsChanged + 1

                                End If

                            Else

                                JobComponentTaskEmployee.EmployeeCode = ReplaceWithEmployeeCode

                                If AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Update(DbContext, JobComponentTaskEmployee) Then

                                    RowsChanged = RowsChanged + 1

                                End If

                            End If

                        Next

                    End If

                Next

            Catch ex As Exception
                Completed = False
            Finally
                SearchAndReplace_EmployeeAssignment = Completed
            End Try

        End Function
        Private Function SearchAndReplace_ClientContactAssignment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTrafficIDs As Integer(),
                                                                  ByVal SearchForClientContactID As Integer, ByVal ReplaceWithClientContactID As Integer, ByRef RowsChanged As Integer) As Boolean

            'objects
            Dim Completed As Boolean = True
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing

            Try

                RowsChanged = 0

                For Each JobTrafficID In JobTrafficIDs

                    JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByID(DbContext, JobTrafficID)

                    If JobTraffic IsNot Nothing Then

                        For Each JobComponentTaskClientContact In (From Entity In AdvantageFramework.Database.Procedures.JobComponentTaskClientContact.Load(DbContext)
                                                                   Where Entity.JobNumber = JobTraffic.JobNumber AndAlso
                                                                 Entity.JobComponentNumber = JobTraffic.JobComponentNumber AndAlso
                                                                 Entity.ClientContactID = SearchForClientContactID
                                                                   Select Entity).ToList

                            If ReplaceWithClientContactID <= 0 Then

                                If AdvantageFramework.Database.Procedures.JobComponentTaskClientContact.Delete(DbContext, JobComponentTaskClientContact) Then

                                    RowsChanged = RowsChanged + 1

                                End If

                            Else

                                JobComponentTaskClientContact.ClientContactID = ReplaceWithClientContactID

                                If AdvantageFramework.Database.Procedures.JobComponentTaskClientContact.Update(DbContext, JobComponentTaskClientContact) Then

                                    RowsChanged = RowsChanged + 1

                                End If

                            End If

                        Next

                    End If

                Next

            Catch ex As Exception
                Completed = False
            Finally
                SearchAndReplace_ClientContactAssignment = Completed
            End Try

        End Function
        Private Function SearchAndReplace_TaskStatus(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTrafficIDs As Integer(),
                                                     ByVal SearchForTaskStatus As String, ByVal ReplaceWithTaskStatus As String, ByRef RowsChanged As Integer) As Boolean

            'objects
            Dim Completed As Boolean = True
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing

            Try

                RowsChanged = 0

                For Each JobTrafficID In JobTrafficIDs

                    JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByID(DbContext, JobTrafficID)

                    If JobTraffic IsNot Nothing Then

                        For Each JobComponentTask In (From Entity In AdvantageFramework.Database.Procedures.JobComponentTask.Load(DbContext)
                                                      Where Entity.JobNumber = JobTraffic.JobNumber AndAlso
                                                            Entity.JobComponentNumber = JobTraffic.JobComponentNumber AndAlso
                                                            Entity.StatusCode = SearchForTaskStatus
                                                      Select Entity).ToList

                            JobComponentTask.StatusCode = ReplaceWithTaskStatus

                            If AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask) Then

                                RowsChanged = RowsChanged + 1

                            End If

                        Next

                    End If

                Next

            Catch ex As Exception
                Completed = False
            Finally
                SearchAndReplace_TaskStatus = Completed
            End Try

        End Function
        Private Function SearchAndReplace_Manager(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                  ByVal JobTrafficIDs As Integer(), ByVal SearchForManagerCode As String,
                                                  ByVal ReplaceWithManagerCode As String, ByRef RowsChanged As Integer) As Boolean

            'objects
            Dim Completed As Boolean = True
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                RowsChanged = 0

                For Each JobTrafficID In JobTrafficIDs

                    JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByID(DbContext, JobTrafficID)

                    If JobTraffic IsNot Nothing Then

                        Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.TRAFFIC_MGR_COL.ToString)

                        PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(JobTraffic).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name.ToUpper = Setting.Value.ToString.Replace("_", "").ToUpper).SingleOrDefault

                        If PropertyDescriptor IsNot Nothing Then

                            If PropertyDescriptor.GetValue(JobTraffic) = SearchForManagerCode Then

                                PropertyDescriptor.SetValue(JobTraffic, ReplaceWithManagerCode)

                                RowsChanged = RowsChanged + 1

                            End If

                        End If

                    End If

                Next

            Catch ex As Exception
                Completed = False
            Finally
                SearchAndReplace_Manager = Completed
            End Try

        End Function
        Private Function FormatReturnMessage(ByVal FindAndReplaceField As AdvantageFramework.ProjectSchedule.FindAndReplaceFields, ByVal SearchedForValue As Object, ByVal ReplacedWithValue As Object, ByVal AdditionalCriteria As Object, ByVal RowsChanged As Integer) As String

            'objects
            Dim ReturnMessage As String = ""

            Try

                ReturnMessage = AdvantageFramework.StringUtilities.GetNameAsWords(FindAndReplaceField.ToString)
                ReturnMessage &= " changed from "

                If SearchedForValue Is Nothing Then

                    ReturnMessage &= "NULL"

                Else

                    If TypeOf SearchedForValue Is Date Then

                        ReturnMessage &= CType(SearchedForValue, Date).ToShortDateString

                    ElseIf FindAndReplaceField = FindAndReplaceFields.TaskStatus Then

                        ReturnMessage &= AdvantageFramework.EnumUtilities.LoadEnumObject(GetType(AdvantageFramework.ProjectSchedule.TaskStatus), SearchedForValue.ToString).Description

                    Else

                        ReturnMessage &= SearchedForValue.ToString

                    End If

                End If

                ReturnMessage &= " to "

                If ReplacedWithValue Is Nothing Then

                    ReturnMessage &= "NULL"

                Else

                    If TypeOf ReplacedWithValue Is Date Then

                        ReturnMessage &= CType(ReplacedWithValue, Date).ToShortDateString

                    ElseIf FindAndReplaceField = FindAndReplaceFields.TaskStatus Then

                        ReturnMessage &= AdvantageFramework.EnumUtilities.LoadEnumObject(GetType(AdvantageFramework.ProjectSchedule.TaskStatus), ReplacedWithValue.ToString).Description

                    Else

                        ReturnMessage &= ReplacedWithValue.ToString

                    End If

                End If

                ReturnMessage &= " for " & RowsChanged.ToString

                If FindAndReplaceField = FindAndReplaceFields.EmployeeAssignment AndAlso AdditionalCriteria IsNot Nothing Then

                    ReturnMessage &= " task(" & AdditionalCriteria.ToString & ")."

                Else

                    ReturnMessage &= " task(s)."

                End If

            Catch ex As Exception
                ReturnMessage = ""
            Finally
                FormatReturnMessage = ReturnMessage
            End Try

        End Function
        Private Function ValidateSearchAndReplaceFieldValues(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FindAndReplaceField As AdvantageFramework.ProjectSchedule.FindAndReplaceFields, SearchForValue As Object, ByVal ReplaceWithValue As Object, ByVal AdditionalCriteria As Object, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True

            Try

                Select Case FindAndReplaceField

                    Case ProjectSchedule.FindAndReplaceFields.StartDate,
                         ProjectSchedule.FindAndReplaceFields.DueDate,
                         ProjectSchedule.FindAndReplaceFields.CompletedDate

                        If SearchForValue IsNot Nothing Then

                            If AdditionalCriteria IsNot Nothing Then

                                Try

                                    If CType(SearchForValue, Date) > CType(AdditionalCriteria, Date) Then

                                        ErrorMessage = "Search for end date is before the Search for start date"

                                    End If

                                Catch ex As Exception

                                End Try

                            End If

                        ElseIf AdditionalCriteria IsNot Nothing Then

                            ErrorMessage = "Cannot use a Search for end date without a Search for start date"

                        End If

                    Case ProjectSchedule.FindAndReplaceFields.TimeDue

                        If String.IsNullOrEmpty(SearchForValue) = False Then

                            If SearchForValue.ToString.Length > 10 Then

                                ErrorMessage = "Invalid Search for Time Due"

                            End If

                        End If

                        If String.IsNullOrEmpty(ReplaceWithValue) = False Then

                            If ReplaceWithValue.ToString.Length > 10 Then

                                ErrorMessage = "Invalid Replace with Time Due"

                            End If

                        End If

                    Case ProjectSchedule.FindAndReplaceFields.EmployeeAssignment

                        If String.IsNullOrEmpty(SearchForValue) Then

                            ErrorMessage = "Invalid Search for Employee"

                        ElseIf AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, SearchForValue.ToString) Is Nothing Then

                            ErrorMessage = "Invalid Search for Employee"

                        ElseIf (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                Where Entity.Code = DirectCast(SearchForValue, String)
                                Select Entity).Any = False Then

                            ErrorMessage = "Invalid Replace with Employee"

                        End If

                        If String.IsNullOrEmpty(AdditionalCriteria) = False Then

                            If AdvantageFramework.Database.Procedures.Task.LoadByTaskCode(DbContext, AdditionalCriteria) Is Nothing Then

                                ErrorMessage = "Invalid Task Code."

                            End If

                        End If

                    Case ProjectSchedule.FindAndReplaceFields.ClientContactAssignment

                        If SearchForValue = Nothing Then

                            ErrorMessage = "Invalid Search for Contact Code"

                        ElseIf AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, CInt(SearchForValue)) Is Nothing Then

                            ErrorMessage = "Invalid Search for Contact Code"

                        ElseIf ReplaceWithValue <> Nothing Then

                            If AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, CInt(ReplaceWithValue)) Is Nothing Then

                                ErrorMessage = "Invalid Replace with Contact Code"

                            End If

                        End If

                    Case ProjectSchedule.FindAndReplaceFields.TaskStatus

                        If String.IsNullOrEmpty(SearchForValue) = False Then

                            If (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.ProjectSchedule.TaskStatus))
                                Where EnumObject.Code = DirectCast(SearchForValue, String)
                                Select EnumObject).Any = False Then

                                ErrorMessage = "Invalid Search for Task Status"

                            End If

                        End If

                        If String.IsNullOrEmpty(ReplaceWithValue) = False Then

                            If (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.ProjectSchedule.TaskStatus))
                                Where EnumObject.Code = DirectCast(ReplaceWithValue, String)
                                Select EnumObject).Any = False Then

                                ErrorMessage = "Invalid Replace with Task Status"

                            End If

                        End If

                    Case ProjectSchedule.FindAndReplaceFields.Manager

                        If String.IsNullOrEmpty(SearchForValue) = False Then

                            If AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, SearchForValue.ToString) Is Nothing Then

                                ErrorMessage = "Invalid Search for Employee"

                            End If

                        End If

                        If String.IsNullOrEmpty(ReplaceWithValue) = False Then

                            If (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                Where Entity.Code = DirectCast(ReplaceWithValue, String)
                                Select Entity).Any = False Then

                                ErrorMessage = "Invalid Replace with Employee"

                            End If

                        End If

                End Select

                If String.IsNullOrEmpty(ErrorMessage) = False Then

                    IsValid = False

                End If

            Catch ex As Exception
                IsValid = False
            Finally
                ValidateSearchAndReplaceFieldValues = IsValid
            End Try

        End Function
        Public Function MoveTask(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MoveUp As Boolean, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As Boolean

            'objects
            Dim Moved As Boolean = False
            Dim JobComponentTaskAboveOrBelow As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

            Try

                JobComponentTask = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTask.Load(DbContext)
                                    Where Entity.JobNumber = JobNumber AndAlso
                                          Entity.JobComponentNumber = JobComponentNumber AndAlso
                                          Entity.SequenceNumber = SequenceNumber
                                    Select Entity).SingleOrDefault

                If MoveUp Then

                    Try

                        JobComponentTaskAboveOrBelow = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTask.Load(DbContext)
                                                        Where Entity.JobNumber = JobNumber AndAlso
                                                              Entity.JobComponentNumber = JobComponentNumber AndAlso
                                                              Entity.SequenceNumber <> SequenceNumber AndAlso
                                                              Entity.OrderNumber < JobComponentTask.OrderNumber
                                                        Order By Entity.OrderNumber Descending
                                                        Select Entity).FirstOrDefault

                    Catch ex As Exception
                        'nothing above 
                        JobComponentTaskAboveOrBelow = Nothing
                    End Try

                Else

                    Try

                        JobComponentTaskAboveOrBelow = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTask.Load(DbContext)
                                                        Where Entity.JobNumber = JobNumber AndAlso
                                                              Entity.JobComponentNumber = JobComponentNumber AndAlso
                                                              Entity.SequenceNumber <> SequenceNumber AndAlso
                                                              Entity.OrderNumber > JobComponentTask.OrderNumber
                                                        Order By Entity.OrderNumber Ascending
                                                        Select Entity).FirstOrDefault

                    Catch ex As Exception
                        'nothing below 
                        JobComponentTaskAboveOrBelow = Nothing
                    End Try

                End If

                If JobComponentTaskAboveOrBelow IsNot Nothing Then

                    JobComponentTask.OrderNumber = JobComponentTaskAboveOrBelow.OrderNumber

                    Moved = AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask)

                End If

            Catch ex As Exception
                Moved = False
            Finally
                MoveTask = Moved
            End Try

        End Function
        Public Function SaveUserColumn(ByVal Session As AdvantageFramework.Security.Session, ByVal ColumnID As Integer, ByVal ShowOnGrid As Boolean, ByVal ShowOnAddNew As Boolean) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim DisplayType As String = Nothing
            Dim JobTrafficSetupDetail As AdvantageFramework.Database.Entities.JobTrafficSetupDetail = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If ShowOnGrid = True AndAlso ShowOnAddNew = True Then

                        DisplayType = "GA"

                    ElseIf ShowOnGrid = True AndAlso ShowOnAddNew = False Then

                        DisplayType = "G"

                    ElseIf ShowOnGrid = False AndAlso ShowOnAddNew = True Then

                        DisplayType = "A"

                    ElseIf ShowOnGrid = False AndAlso ShowOnAddNew = False Then

                        DisplayType = Nothing

                    End If

                    Try

                        JobTrafficSetupDetail = (From Entity In AdvantageFramework.Database.Procedures.JobTrafficSetupDetail.Load(DbContext)
                                                 Where Entity.HeaderCode = Session.User.EmployeeCode AndAlso
                                                       Entity.ColumnID = ColumnID
                                                 Select Entity).SingleOrDefault

                    Catch ex As Exception
                        JobTrafficSetupDetail = Nothing
                    End Try

                    If JobTrafficSetupDetail Is Nothing AndAlso String.IsNullOrEmpty(DisplayType) = False Then

                        JobTrafficSetupDetail = New AdvantageFramework.Database.Entities.JobTrafficSetupDetail
                        JobTrafficSetupDetail.DbContext = DbContext
                        JobTrafficSetupDetail.HeaderCode = Session.User.EmployeeCode
                        JobTrafficSetupDetail.ColumnID = ColumnID
                        JobTrafficSetupDetail.ShowLongDescription = 0

                        Try

                            JobTrafficSetupDetail.SequenceNumber = (From Entity In AdvantageFramework.Database.Procedures.JobTrafficSetupDetail.Load(DbContext)
                                                                    Where Entity.HeaderCode = JobTrafficSetupDetail.HeaderCode
                                                                    Select Entity.SequenceNumber).Max + 1

                        Catch ex As Exception
                            JobTrafficSetupDetail.SequenceNumber = 1
                        End Try

                        JobTrafficSetupDetail.DisplayType = DisplayType

                        Saved = AdvantageFramework.Database.Procedures.JobTrafficSetupDetail.Insert(DbContext, JobTrafficSetupDetail)

                    ElseIf JobTrafficSetupDetail IsNot Nothing AndAlso String.IsNullOrEmpty(DisplayType) = False Then

                        JobTrafficSetupDetail.DisplayType = DisplayType

                        Saved = AdvantageFramework.Database.Procedures.JobTrafficSetupDetail.Update(DbContext, JobTrafficSetupDetail)

                    End If

                    If ShowOnGrid = False AndAlso ShowOnAddNew = False Then

                        For Each JobTrafficSetupDetail In AdvantageFramework.Database.Procedures.JobTrafficSetupDetail.LoadByHeaderCodeAndColumnID(DbContext, Session.User.EmployeeCode, ColumnID).ToList

                            If AdvantageFramework.Database.Procedures.JobTrafficSetupDetail.Delete(DbContext, JobTrafficSetupDetail) Then

                                Saved = True

                            End If

                        Next

                    End If

                    'ID
                    '6 = colJOB_ORDER
                    '7 = colSEQ_NBR
                    '8 = colPREDECESSORS_TEXT

                    If ColumnID = 6 AndAlso ShowOnGrid = True Then

                        SaveUserColumn(Session, 8, False, False)

                    ElseIf ColumnID = 8 AndAlso ShowOnGrid = True Then

                        SaveUserColumn(Session, 6, False, False)
                        SaveUserColumn(Session, 7, True, False)

                    End If

                End Using

            Catch ex As Exception
                Saved = False
            Finally
                SaveUserColumn = Saved
            End Try

        End Function
        Public Function IsUserColumnVisible(ByVal TrafficScheduleUserColumnList As Generic.List(Of AdvantageFramework.Database.Classes.TrafficScheduleUserColumn), ByVal ScheduleTaskProperty As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties)

            'object
            Dim IsVisible As Boolean = True
            Dim TrafficScheduleUserColumn As AdvantageFramework.Database.Classes.TrafficScheduleUserColumn = Nothing
            Dim ColumnName As String = Nothing

            Try

                If TrafficScheduleUserColumnList IsNot Nothing AndAlso TrafficScheduleUserColumnList.Count > 0 Then

                    Select Case ScheduleTaskProperty

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.ID

                            ColumnName = ""

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobNumber

                            ColumnName = ""

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobComponentNumber

                            ColumnName = ""

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskStatus

                            ColumnName = "colTASK_STATUS"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TrafficPhaseID

                            ColumnName = "colPHASE_DESC"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.PhaseDescription

                            ColumnName = "colPHASE_DESC"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskCode

                            ColumnName = "colTASK_CODE,colTASK_CODE_LOOKUP"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskDescription

                            ColumnName = "colTASK_DESCRIPTION"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.Milestone

                            ColumnName = "colMilestone"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.SequenceNumber

                            ColumnName = "colSEQ_NBR"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobOrder

                            ColumnName = "colJOB_ORDER"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.Predecessor

                            ColumnName = "colPREDECESSORS_TEXT"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobDays

                            ColumnName = "colJOB_DAYS"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskStartDate

                            ColumnName = "colTASK_START_DATE"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobRevisedDate

                            ColumnName = "colJOB_REVISED_DATE"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DueDateLock

                            ColumnName = "colLock"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DueTime

                            ColumnName = "colDUE_TIME"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobDueDate

                            ColumnName = "colJOB_DUE_DATE"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobCompletedDate

                            ColumnName = "colJOB_COMPLETED_DATE"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TemporaryCompleteDate

                            ColumnName = "colTEMP_COMP_DATE"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobHours

                            ColumnName = "colJOB_HRS"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DispersedHours

                            ColumnName = "colDISPERSED_JOB_HRS"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.PostedHours

                            ColumnName = "colPOSTED_HOURS"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.PercentComplete

                            ColumnName = "colPERC_COMPLETE"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.EmployeeCode

                            ColumnName = "colEMP_CODE_TEXT"

                            '"ClientContacts")
                            'ColumnName = "colCLI_CONTACT_TEXT"
                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.EstimateFunction

                            ColumnName = "colEstimateFunction"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.FunctionComments

                            ColumnName = "colFNC_COMMENTS"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DueDateComments

                            ColumnName = "colDUE_DATE_COMMENTS"

                        Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.RevisionDateComments

                            ColumnName = "colREV_DATE_COMMENTS"

                        Case Else

                            IsVisible = False

                    End Select

                End If

            Catch ex As Exception
                IsVisible = False
            Finally
                IsUserColumnVisible = IsVisible
            End Try

        End Function
        Public Function GetUserColumnNameByFieldName(ByVal FieldName As String) As String

            'objects
            Dim ColumnName As String = Nothing

            Select Case FieldName

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.ID.ToString

                    ColumnName = ""

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobNumber.ToString

                    ColumnName = ""

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobComponentNumber.ToString

                    ColumnName = ""

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskStatus.ToString

                    ColumnName = "colTASK_STATUS"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TrafficPhaseID.ToString

                    ColumnName = "colPHASE_DESC"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.PhaseDescription.ToString

                    ColumnName = "colPHASE_DESC"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskCode.ToString

                    ColumnName = "colTASK_CODE,colTASK_CODE_LOOKUP"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskDescription.ToString

                    ColumnName = "colTASK_DESCRIPTION"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.Milestone.ToString

                    ColumnName = "colMilestone"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.SequenceNumber.ToString

                    ColumnName = "colSEQ_NBR"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobOrder.ToString

                    ColumnName = "colJOB_ORDER"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.Predecessor.ToString

                    ColumnName = "colPREDECESSORS_TEXT"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobDays.ToString

                    ColumnName = "colJOB_DAYS"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskStartDate.ToString

                    ColumnName = "colTASK_START_DATE"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobRevisedDate.ToString

                    ColumnName = "colJOB_REVISED_DATE"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DueDateLock.ToString

                    ColumnName = "colLock"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DueTime.ToString

                    ColumnName = "colDUE_TIME"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobDueDate.ToString

                    ColumnName = "colJOB_DUE_DATE"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobCompletedDate.ToString

                    ColumnName = "colJOB_COMPLETED_DATE"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TemporaryCompleteDate.ToString

                    ColumnName = "colTEMP_COMP_DATE"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobHours.ToString

                    ColumnName = "colJOB_HRS"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DispersedHours.ToString

                    ColumnName = "colDISPERSED_JOB_HRS"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.PostedHours.ToString

                    ColumnName = "colPOSTED_HOURS"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.PercentComplete.ToString

                    ColumnName = "colPERC_COMPLETE"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.EmployeeCode.ToString

                    ColumnName = "colEMP_CODE_TEXT"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.ClientContact.ToString

                    ColumnName = "colCLI_CONTACT_TEXT"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.EstimateFunction.ToString

                    ColumnName = "colEstimateFunction"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.FunctionComments.ToString

                    ColumnName = "colFNC_COMMENTS"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DueDateComments.ToString

                    ColumnName = "colDUE_DATE_COMMENTS"

                Case AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.RevisionDateComments.ToString

                    ColumnName = "colREV_DATE_COMMENTS"

            End Select

            GetUserColumnNameByFieldName = ColumnName

        End Function
        Public Function LoadTaskEmployees(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short, ByVal EstimateFunctionCode As String) As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.TaskEmployee)

            'objects
            Dim TaskEmployees As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.TaskEmployee) = Nothing


            Try

                TaskEmployees = (From JobComponentTaskEmployee In AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Load(DbContext)
                                 Join Employee In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext) On JobComponentTaskEmployee.EmployeeCode Equals Employee.Code
                                 Where JobComponentTaskEmployee.JobNumber = JobNumber AndAlso
                                       JobComponentTaskEmployee.JobComponentNumber = JobComponentNumber AndAlso
                                       JobComponentTaskEmployee.SequenceNumber = SequenceNumber
                                 Select JobComponentTaskEmployee.ID,
                                        [JobNum] = JobComponentTaskEmployee.JobNumber,
                                        [JobComponentNum] = JobComponentTaskEmployee.JobComponentNumber,
                                        [SequenceNum] = JobComponentTaskEmployee.SequenceNumber,
                                        [EmployeeCode] = JobComponentTaskEmployee.EmployeeCode,
                                        [FirstName] = Employee.FirstName,
                                        [LastName] = Employee.LastName,
                                        [MiddleInitial] = Employee.MiddleInitial,
                                        [Hours] = JobComponentTaskEmployee.Hours,
                                        [TempCompletionDate] = JobComponentTaskEmployee.TempCompletionDate,
                                        [CompletedComments] = JobComponentTaskEmployee.CompletedComments,
                                        [PercentComplete] = JobComponentTaskEmployee.PercentComplete).ToList _
                                .Select(Function(Entity) New AdvantageFramework.ProjectSchedule.Classes.TaskEmployee With {.ID = Entity.ID,
                                                                                                                           .JobNumber = Entity.JobNum,
                                                                                                                           .JobComponentNumber = Entity.JobComponentNum,
                                                                                                                           .SequenceNumber = Entity.SequenceNum,
                                                                                                                           .EmployeeCode = Entity.EmployeeCode,
                                                                                                                           .EmployeeName = Entity.FirstName & If(Entity.MiddleInitial <> "", " " & Entity.MiddleInitial & ". ", " ") & Entity.LastName,
                                                                                                                           .HoursAllowed = Entity.Hours,
                                                                                                                           .TempCompleteDate = Entity.TempCompletionDate,
                                                                                                                           .CompletedComments = Entity.CompletedComments,
                                                                                                                           .PercentComplete = Entity.PercentComplete}).ToList

                If TaskEmployees IsNot Nothing AndAlso TaskEmployees.Count > 0 Then

                    For Each TaskEmployee In TaskEmployees

                        Try

                            TaskEmployee.QuotedHours = LoadQuotedHours(DbContext, TaskEmployee.JobNumber, TaskEmployee.JobComponentNumber, TaskEmployee.EmployeeCode, EstimateFunctionCode)

                        Catch ex As Exception
                            TaskEmployee.QuotedHours = 0.0
                        End Try

                        Try

                            TaskEmployee.HoursPosted = LoadPostedHours(DbContext, TaskEmployee.JobNumber, TaskEmployee.JobComponentNumber, TaskEmployee.EmployeeCode, EstimateFunctionCode)

                        Catch ex As Exception
                            TaskEmployee.HoursPosted = 0.0
                        End Try

                    Next

                End If

            Catch ex As Exception
                TaskEmployees = Nothing
            Finally
                LoadTaskEmployees = TaskEmployees
            End Try

        End Function
        Public Function LoadQuotedHours(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal EmployeeCode As String, ByVal EstimateFunctionCode As String) As Decimal

            'objects
            Dim QuotedHours As Decimal = Nothing

            Try

                QuotedHours = DbContext.Database.SqlQuery(Of Decimal)(String.Format("SELECT [SumOfEST_REF_QUANTITY] FROM [dbo].[WV_ESTIMATED_HOURS] WHERE [JOB_NUMBER] = {0} AND [JOB_COMPONENT_NBR] = {1} AND [EMP_CODE] = '{2}' AND [FNC_CODE] = '{3}'", JobNumber, JobComponentNumber, EmployeeCode, EstimateFunctionCode)).SingleOrDefault

            Catch ex As Exception
                QuotedHours = 0
            Finally
                LoadQuotedHours = QuotedHours
            End Try

        End Function
        Public Function LoadPostedHours(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal EmployeeCode As String, ByVal EstimateFunctionCode As String) As Decimal

            'objects
            Dim PostedHours As Decimal = Nothing

            Try

                PostedHours = DbContext.Database.SqlQuery(Of Decimal)(String.Format(" SELECT SUM(EMP_TIME_DTL.EMP_HOURS) " &
                                                                                        " FROM dbo.EMP_TIME_DTL INNER JOIN " &
                                                                                        "      dbo.EMP_TIME ON EMP_TIME_DTL.ET_ID = EMP_TIME.ET_ID " &
                                                                                        " GROUP BY EMP_TIME_DTL.JOB_NUMBER,  " &
                                                                                        "          EMP_TIME_DTL.JOB_COMPONENT_NBR, " &
                                                                                        "          EMP_TIME_DTL.FNC_CODE, " &
                                                                                        "          EMP_TIME.EMP_CODE " &
                                                                                        " HAVING (dbo.EMP_TIME_DTL.JOB_NUMBER = {0}) AND " &
                                                                                        " 	     (dbo.EMP_TIME_DTL.JOB_COMPONENT_NBR = {1}) AND " &
                                                                                        " 	     (dbo.EMP_TIME_DTL.FNC_CODE = '{3}') AND  " &
                                                                                        "        (EMP_TIME.EMP_CODE = '{2}')", JobNumber, JobComponentNumber, EmployeeCode, EstimateFunctionCode)).SingleOrDefault

            Catch ex As Exception
                PostedHours = 0.0
            Finally
                LoadPostedHours = PostedHours
            End Try

        End Function
        Public Function CopyProjectSchedule(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTrafficIDToCopy As Integer, ByVal NewJobTraffic As AdvantageFramework.Database.Entities.JobTraffic, ByVal IncludeDates As Boolean)

            'objects
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim NewJobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim NewJobComponentTaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing
            Dim Copied As Boolean = False

            Try

                JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByID(DbContext, JobTrafficIDToCopy)

                If JobTraffic IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.JobTraffic.Insert(DbContext, NewJobTraffic) Then

                        If String.IsNullOrEmpty(NewJobTraffic.ManagerEmployeeCode) = False Then

                            UpdateTrafficManagerColumn(DbContext, NewJobTraffic.JobNumber, NewJobTraffic.JobComponentNumber, NewJobTraffic.ManagerEmployeeCode)

                        End If

                        For Each JobComponentTask In (From Entity In AdvantageFramework.Database.Procedures.JobComponentTask.Load(DbContext)
                                                      Where Entity.JobNumber = JobTraffic.JobNumber AndAlso
                                                            Entity.JobComponentNumber = JobTraffic.JobComponentNumber
                                                      Select Entity).ToList

                            NewJobComponentTask = New AdvantageFramework.Database.Entities.JobComponentTask
                            NewJobComponentTask.JobNumber = NewJobTraffic.JobNumber
                            NewJobComponentTask.JobComponentNumber = NewJobTraffic.JobComponentNumber

                            NewJobComponentTask.SequenceNumber = JobComponentTask.SequenceNumber
                            NewJobComponentTask.TaskCode = JobComponentTask.TaskCode
                            NewJobComponentTask.FuctionCode = JobComponentTask.FuctionCode
                            NewJobComponentTask.Description = JobComponentTask.Description
                            NewJobComponentTask.IsDueDateLocked = JobComponentTask.IsDueDateLocked
                            NewJobComponentTask.CompletedDate = JobComponentTask.CompletedDate
                            NewJobComponentTask.OrderNumber = JobComponentTask.OrderNumber
                            NewJobComponentTask.Days = JobComponentTask.Days
                            NewJobComponentTask.ParentTaskCode = JobComponentTask.ParentTaskCode
                            NewJobComponentTask.Comment = JobComponentTask.Comment
                            NewJobComponentTask.DueDateComment = JobComponentTask.DueDateComment
                            NewJobComponentTask.OriginalDueDateComment = JobComponentTask.OriginalDueDateComment
                            NewJobComponentTask.Hours = JobComponentTask.Hours
                            NewJobComponentTask.DueTime = JobComponentTask.DueTime
                            NewJobComponentTask.OriginalDueTime = JobComponentTask.OriginalDueTime
                            NewJobComponentTask.StatusCode = JobComponentTask.StatusCode
                            NewJobComponentTask.IsMilestone = JobComponentTask.IsMilestone
                            NewJobComponentTask.PhaseID = JobComponentTask.PhaseID
                            NewJobComponentTask.RoleCode = JobComponentTask.RoleCode

                            If IncludeDates Then

                                NewJobComponentTask.StartDate = JobComponentTask.StartDate
                                NewJobComponentTask.DueDate = JobComponentTask.DueDate
                                NewJobComponentTask.OriginalDueDate = JobComponentTask.OriginalDueDate

                            End If

                            AdvantageFramework.Database.Procedures.JobComponentTask.Insert(DbContext, NewJobComponentTask)

                        Next

                        For Each JobComponentTaskEmployee In (From Entity In AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Load(DbContext)
                                                              Where Entity.JobNumber = JobTraffic.JobNumber AndAlso
                                                                    Entity.JobComponentNumber = JobTraffic.JobComponentNumber
                                                              Select Entity).ToList

                            NewJobComponentTaskEmployee = New AdvantageFramework.Database.Entities.JobComponentTaskEmployee

                            NewJobComponentTaskEmployee.JobNumber = NewJobTraffic.JobNumber
                            NewJobComponentTaskEmployee.JobComponentNumber = NewJobTraffic.JobComponentNumber
                            NewJobComponentTaskEmployee.SequenceNumber = JobComponentTaskEmployee.SequenceNumber
                            NewJobComponentTaskEmployee.EmployeeCode = JobComponentTaskEmployee.EmployeeCode
                            NewJobComponentTaskEmployee.Hours = JobComponentTaskEmployee.Hours

                            AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Insert(DbContext, NewJobComponentTaskEmployee)

                        Next

                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[JOB_TRAFFIC_DET_PREDS] SELECT {0}, {1}, SEQ_NUM, PREDECESSOR_SEQ_NUM FROM [dbo].[JOB_TRAFFIC_DET_PREDS] WHERE JOB_NUMBER = {2} AND JOB_COMPONENT_NUMBER = {3}", NewJobTraffic.JobNumber, NewJobTraffic.JobComponentNumber, JobTraffic.JobNumber, JobTraffic.JobComponentNumber))

                        Catch ex As Exception

                        End Try

                        Copied = True

                    End If

                End If

            Catch ex As Exception
                Copied = False
            Finally
                CopyProjectSchedule = Copied
            End Try

        End Function
        Public Sub UpdateTrafficManagerColumn(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNUmber As Integer, ByVal ManagerCode As String)

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[usp_wv_Traffic_Schedule_UpdateManager {0}, {1}, '{2}'", JobNumber, JobComponentNUmber, ManagerCode))

            Catch ex As Exception

            End Try

        End Sub
        Public Function ClearEmployeeAssignments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As Boolean

            'objects
            Dim Cleared As Boolean = False
            Dim JobNumberSqlParameter As SqlClient.SqlParameter = Nothing
            Dim JobComponentNumberSqlParameter As SqlClient.SqlParameter = Nothing

            Try

                JobNumberSqlParameter = New SqlClient.SqlParameter("@JobNumber", SqlDbType.Int)
                JobComponentNumberSqlParameter = New SqlClient.SqlParameter("@JobComponentNumber", SqlDbType.SmallInt)

                JobNumberSqlParameter.Value = JobNumber
                JobComponentNumberSqlParameter.Value = JobComponentNumber

                DbContext.Database.ExecuteSqlCommand("DELETE FROM [dbo].[JOB_TRAFFIC_DET_EMPS] WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber", JobNumberSqlParameter, JobComponentNumberSqlParameter)

                Cleared = True

            Catch ex As Exception
                Cleared = False
            Finally
                ClearEmployeeAssignments = Cleared
            End Try

        End Function
        Public Function CalculateJobPredecessor(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal UsePredecessor As Integer, ByVal EmployeeCode As String, ByRef ReturnValue As Integer) As Boolean

            'objects
            Dim Calculated As Boolean = False
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPredecessor As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
            SqlParameterPredecessor = New System.Data.SqlClient.SqlParameter("@use_predecessor", SqlDbType.Bit)
            SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@emp_code", SqlDbType.VarChar)
            SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
            SqlParameterReturnValue.Direction = ParameterDirection.Output
            SqlParameterReturnValue.Value = 0

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterPredecessor.Value = UsePredecessor
            SqlParameterEmployeeCode.Value = EmployeeCode

            Try

                DbContext.Database.ExecuteSqlCommand("EXEC dbo.usp_wv_Traffic_Schedule_Calculate_JobPred @job_number, @job_component_nbr, @use_predecessor, @emp_code, @ret_val OUTPUT",
                    SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterPredecessor, SqlParameterEmployeeCode, SqlParameterReturnValue)

                ReturnValue = SqlParameterReturnValue.Value

                Calculated = True

            Catch ex As Exception
                Calculated = False
            End Try

            CalculateJobPredecessor = Calculated

        End Function
        Public Function CalculateDueDatesPredecessor(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal UsePredecessor As Short, ByRef ReturnValue As Integer) As Boolean

            'objects
            Dim Calculated As Boolean = False
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPredecessor As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
            SqlParameterPredecessor = New System.Data.SqlClient.SqlParameter("@use_predecessor", SqlDbType.Bit)
            SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
            SqlParameterReturnValue.Direction = ParameterDirection.Output
            SqlParameterReturnValue.Value = 0

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterPredecessor.Value = UsePredecessor

            Try

                DbContext.Database.ExecuteSqlCommand("EXEC dbo.usp_wv_Traffic_Schedule_Calculate_Pred @job_number, @job_component_nbr, @use_predecessor, @ret_val OUTPUT",
                    SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterPredecessor, SqlParameterReturnValue)

                ReturnValue = SqlParameterReturnValue.Value

                Calculated = True

            Catch ex As Exception
                Calculated = False
            End Try

            CalculateDueDatesPredecessor = Calculated

        End Function

        Public Function CalculateDueDates(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Boolean

            Dim Calculated As Boolean = False
            Dim Schedule As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim UsePredecessor As Short = 0
            Dim ReturnValue As Integer = 0

            Schedule = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

            If Schedule IsNot Nothing Then

                Try

                    If Schedule.ScheduleCalculation IsNot Nothing Then UsePredecessor = Schedule.ScheduleCalculation

                Catch ex As Exception
                    UsePredecessor = 0
                End Try

                Calculated = CalculateDueDates(DbContext, JobNumber, JobComponentNumber, UsePredecessor, ReturnValue)

            End If

            Return Calculated

        End Function
        Public Function CalculateDueDates(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal UsePredecessor As Short, ByRef ReturnValue As Integer) As Boolean

            'objects
            Dim Calculated As Boolean = False
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPredecessor As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
            SqlParameterPredecessor = New System.Data.SqlClient.SqlParameter("@use_predecessor", SqlDbType.Bit)
            SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
            SqlParameterReturnValue.Direction = ParameterDirection.Output
            SqlParameterReturnValue.Value = 0

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterPredecessor.Value = UsePredecessor

            Try

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_calculate_schedule] @job_number, @job_component_nbr, @use_predecessor, @ret_val OUTPUT;",
                                                      SqlParameterJobNumber,
                                                      SqlParameterJobComponentNumber,
                                                      SqlParameterPredecessor,
                                                      SqlParameterReturnValue)

                ReturnValue = SqlParameterReturnValue.Value

                Calculated = True

            Catch ex As Exception
                Calculated = False
            End Try

            CalculateDueDates = Calculated

        End Function
        Public Function UpdateTaskAlertsDueDate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, Optional ByVal SequenceNumber As Integer = -1, Optional ByVal ErrorMessage As String = "") As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSequenceNumber As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            SqlParameterSequenceNumber = New System.Data.SqlClient.SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)

            If SequenceNumber < 0 Then

                SqlParameterSequenceNumber.Value = System.DBNull.Value

            Else

                SqlParameterSequenceNumber.Value = SequenceNumber

            End If

            Try

                DbContext.Database.ExecuteSqlCommand("EXEC dbo.usp_wv_Traffic_Schedule_UpdateTaskAlertsDueDate @JOB_NUMBER, @JOB_COMPONENT_NBR, @SEQ_NBR",
                    SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterSequenceNumber)

                Updated = True

            Catch ex As Exception
                ErrorMessage = ex.Message
                Updated = False
            End Try

            UpdateTaskAlertsDueDate = Updated

        End Function
        Public Function ConvertDataRowStringToDate(ByVal Value As String) As Date?

            'objects
            Dim ReturnValue As Date? = Nothing

            Try

                If String.IsNullOrWhiteSpace(Value) = False Then

                    If IsDate(Value) Then

                        ReturnValue = CDate(Value)

                    End If

                End If

            Catch ex As Exception
                ReturnValue = Nothing
            Finally
                ConvertDataRowStringToDate = ReturnValue
            End Try

        End Function
        Public Function AutoUpdateTrafficCode(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, Optional ByRef ErrorMessage As String = "",
                                              Optional ByRef NewStatusCode As String = "", Optional ByRef NewStatusDescription As String = "") As Boolean

            Dim DoAutoUpdate As Boolean = False
            Dim UpdateStatusFromScheduleHeader As Boolean? = Nothing
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            'Try

            '    UpdateStatusFromScheduleHeader = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT JOB_TRAFFIC.AUTO_UPDATE_STATUS FROM JOB_TRAFFIC WITH(NOLOCK) WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1};", JobNumber, JobComponentNbr)).FirstOrDefault

            'Catch ex As Exception

            '    UpdateStatusFromScheduleHeader = Nothing

            'End Try

            'If UpdateStatusFromScheduleHeader IsNot Nothing AndAlso UpdateStatusFromScheduleHeader.HasValue Then



            '    DoAutoUpdate = UpdateStatusFromScheduleHeader.Value

            'Else

            If AdvantageFramework.Agency.GetValue(DbContext, Agency.Methods.Settings.TRF_UPDATE_STATUS) = "1" Then

                DoAutoUpdate = True

            End If

            ' End If

            If DoAutoUpdate = True Then

                Return UpdateScheduleStatus(DbContext, JobNumber, JobComponentNbr, True, ErrorMessage, NewStatusCode, NewStatusDescription)

            Else

                Return False

            End If

        End Function
        Public Function UpdateScheduleStatus(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer,
                                             ByVal BoolAutoUpdateTrafficCode As Boolean, Optional ByRef ErrorMessage As String = "",
                                             Optional ByRef NewStatusCode As String = "",
                                             Optional ByRef NewStatusDescription As String = "") As Boolean

            Dim Updated As Boolean = False
            Dim DataTable As System.Data.DataTable = Nothing
            Dim NextStatusCode As String = ""

            Try

                If BoolAutoUpdateTrafficCode = True Then

                    DataTable = GetNextScheduleStatusCode(DbContext, JobNumber, JobComponentNbr)

                    If DataTable IsNot Nothing AndAlso DataTable.Rows.Count > 0 Then

                        If IsDBNull(DataTable.Rows(0)("NEXT_STATUS_CODE")) = False Then

                            NextStatusCode = DataTable.Rows(0)("NEXT_STATUS_CODE").ToString().Trim

                        Else

                            NextStatusCode = ""

                        End If

                        NewStatusCode = NextStatusCode

                        If IsDBNull(DataTable.Rows(0)("NEXT_STATUS_DESCRIPTION")) = False Then

                            NewStatusDescription = DataTable.Rows(0)("NEXT_STATUS_DESCRIPTION").ToString().Trim

                        Else

                            NewStatusDescription = ""

                        End If

                    End If

                    If Not String.IsNullOrWhiteSpace(NextStatusCode) Then

                        Updated = UpdateScheduleTrafficCode(DbContext, JobNumber, JobComponentNbr, NextStatusCode)

                    Else

                        Updated = False

                    End If

                End If

            Catch ex As Exception
                Updated = False
            Finally
                UpdateScheduleStatus = Updated
            End Try

        End Function
        Public Function GetNextScheduleStatusCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As DataTable

            Dim DataTable As System.Data.DataTable = Nothing
            Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
            Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobCompNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            Try

                DataTable = New System.Data.DataTable

                SqlConnection = DbContext.Database.Connection
                SqlCommand = New System.Data.SqlClient.SqlCommand("[dbo].[usp_wv_Traffic_Schedule_GetNextStatus]", SqlConnection)
                SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(SqlCommand)

                Using SqlCommand

                    SqlCommand.CommandType = CommandType.StoredProcedure

                    JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int) With {.Value = JobNumber}
                    JobCompNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt) With {.Value = JobComponentNumber}

                    SqlCommand.Parameters.Add(JobNumberSqlParameter)
                    SqlCommand.Parameters.Add(JobCompNumberSqlParameter)

                    SqlDataAdapter.Fill(DataTable)

                End Using

            Catch ex As Exception
                DataTable = Nothing
            Finally
                GetNextScheduleStatusCode = DataTable
            End Try

        End Function
        Public Function UpdateScheduleTrafficCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal TrafficCode As String) As Boolean

            'objects    
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim Updated As Boolean = False

            Try

                If JobNumber > 0 And JobComponentNumber > 0 Then

                    JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                    If JobTraffic IsNot Nothing Then

                        JobTraffic.TrafficCode = TrafficCode

                    End If

                    Updated = AdvantageFramework.Database.Procedures.JobTraffic.Update(DbContext, JobTraffic)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                UpdateScheduleTrafficCode = Updated
            End Try

        End Function
        Private Sub LoadWebvantageAndClientPortalURL(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef WebvantageURL As String, ByRef ClientPortalURL As String)

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing

            Try

                DataTable = New System.Data.DataTable

                SqlConnection = DbContext.Database.Connection
                SqlCommand = New System.Data.SqlClient.SqlCommand("[dbo].[usp_cp_getSettings]", SqlConnection)
                SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(SqlCommand)

                Using SqlCommand

                    SqlCommand.CommandType = CommandType.StoredProcedure

                    SqlDataAdapter.Fill(DataTable)

                End Using

                If DataTable IsNot Nothing AndAlso DataTable.Rows.Count > 0 Then

                    With DataTable.Rows(0)

                        WebvantageURL = ("WV_APPLICATION_FOLDER")
                        ClientPortalURL = ("CP_APPLICATION_FOLDER")

                    End With

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Function DismissOrCompleteAlertConfirmationMessage(ByVal Completing As Boolean) As String

            'If Completing Then

            '    Return "Completing this assignment will mark the task as complete. Are you sure you want to continue?"

            'Else

            '    Return "Dismissing this alert will mark the task as complete. Are you sure you want to continue?"

            'End If

            'Return String.Format("{0} AND mark the task as complete? (Choose 'No' to complete assignment without completing the task.)", If(Completing = True, "Complete the assignment", "Dismiss the alert"))

            Return "Mark the task complete?"

        End Function
        Public Function TempCompleteAlertConfirmationMessage(ByVal Completing As Boolean) As String

            'If Completing Then

            '    Return "Completing this assignment will mark the task as temp complete. Are you sure you want to continue?"

            'Else

            '    Return "Dismissing this alert will mark the task as temp complete. Are you sure you want to continue?"

            'End If

            'Return String.Format("{0} AND mark the task as TEMP complete? (Choose 'No' to complete assignment without TEMP completing the task.)", If(Completing = True, "Complete the assignment", "Dismiss the alert"))

            Return "Mark the task TEMP complete?"

        End Function
        Public Function CheckCompleteAlertOrAssignment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal UserCode As String, ByVal EmployeeCode As String, ByVal ForceComplete As Boolean) As Boolean

            'objects
            Dim CompleteAlertOrAssignment As Boolean = False

            Try

                CompleteAlertOrAssignment = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT dbo.advfn_traffic_schedule_CheckCompleteTask({0}, '{1}','{2}', {3});", AlertID, UserCode, EmployeeCode, If(ForceComplete, 1, 0))).FirstOrDefault

            Catch ex As Exception
                CompleteAlertOrAssignment = False
            End Try

            Return CompleteAlertOrAssignment

        End Function
        Public Function CheckTempCompleteAlertOrAssignment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal UserCode As String, ByVal EmployeeCode As String, ByVal ForceComplete As Boolean) As Boolean

            'objects
            Dim TempCompleteAlertOrAssignment As Boolean = False

            Try

                TempCompleteAlertOrAssignment = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT dbo.advfn_traffic_schedule_CheckTempCompleteTask({0}, '{1}','{2}', {3});", AlertID, UserCode, EmployeeCode, If(ForceComplete, 1, 0))).FirstOrDefault

            Catch ex As Exception
                TempCompleteAlertOrAssignment = False
            End Try

            Return TempCompleteAlertOrAssignment

        End Function
        Public Function CheckIfPredecessorExists(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short, ByVal PredecessorSequenceNumber As Short) As Boolean

            'objects
            Dim Exists As Boolean = False

            Try

                Exists = GetPredecessorSequenceNumbers(DbContext, JobNumber, JobComponentNumber, SequenceNumber).Contains(PredecessorSequenceNumber)

            Catch ex As Exception
                Exists = False
            Finally
                CheckIfPredecessorExists = Exists
            End Try

        End Function
        Public Function GetPredecessorSequenceNumbers(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As Short()

            'objects
            Dim PredecessorSequenceNumbers As Short() = Nothing

            Try

                PredecessorSequenceNumbers = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT [PREDECESSOR_SEQ_NBR] FROM dbo.JOB_TRAFFIC_DET_PREDS WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2};", JobNumber, JobComponentNumber, SequenceNumber)).ToArray

            Catch ex As Exception
                PredecessorSequenceNumbers = {}
            End Try

            GetPredecessorSequenceNumbers = PredecessorSequenceNumbers

        End Function
        Public Function UpdatePredecessorList(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim CurrentPreds As Short() = Nothing
            Dim MatchingPreds As Integer = Nothing
            Dim Updated As Boolean = False
            Dim Message As String = ""

            Try

                CurrentPreds = GetPredecessorSequenceNumbers(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber)

                If CurrentPreds Is Nothing Then

                    CurrentPreds = {}

                End If

                If ScheduleTask.PredecessorSequenceNumbers Is Nothing Then

                    ScheduleTask.PredecessorSequenceNumbers = {}

                End If

                MatchingPreds = Math.Max(CurrentPreds.Count, ScheduleTask.PredecessorSequenceNumbers.Count)

                If CurrentPreds.Intersect(ScheduleTask.PredecessorSequenceNumbers).Count <> MatchingPreds Then

                    If ValidatePredecessors(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber, CurrentPreds, ErrorMessage) Then

                        For Each PredecessorSequenceNumber In CurrentPreds

                            If Not ScheduleTask.PredecessorSequenceNumbers.Contains(PredecessorSequenceNumber) Then

                                DeletePredecessor(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber, PredecessorSequenceNumber)

                            End If

                        Next

                        For Each PredecessorSequenceNumber In ScheduleTask.PredecessorSequenceNumbers

                            If Not CurrentPreds.Contains(PredecessorSequenceNumber) Then

                                Message = ""

                                If Not CreatePredecessor(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber, PredecessorSequenceNumber, Message) Then

                                    ErrorMessage &= Message

                                End If

                            End If

                        Next

                    End If

                    Updated = True

                End If

            Catch ex As Exception
                Updated = False
            Finally
                UpdatePredecessorList = Updated
            End Try

        End Function
        Private Function CreatePredecessor(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short, ByVal PredecessorSequenceNumber As Short, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Created As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("INSERT INTO dbo.JOB_TRAFFIC_DET_PREDS (JOB_NUMBER, JOB_COMPONENT_NBR, SEQ_NBR, PREDECESSOR_SEQ_NBR) VALUES ({0}, {1}, {2}, {3})", JobNumber, JobComponentNumber, SequenceNumber, PredecessorSequenceNumber)

                DeletePredecessor(DbContext, JobNumber, JobComponentNumber, PredecessorSequenceNumber, SequenceNumber) 'prevents circular predecessor

                Created = True

            Catch ex As Exception
                Created = False
            End Try

            Return Created

        End Function
        Private Sub DeletePredecessor(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short, ByVal PredecessorSequenceNumber As Short)

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.JOB_TRAFFIC_DET_PREDS WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2} AND PREDECESSOR_SEQ_NBR = {3}", JobNumber, JobComponentNumber, SequenceNumber, PredecessorSequenceNumber)

            Catch ex As Exception

            End Try

        End Sub
        Public Function ClearDates(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal IncludeOriginal As Boolean) As Boolean

            'objects
            Dim Cleared As Boolean = False
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            Try

                StringBuilder = New System.Text.StringBuilder

                StringBuilder.Append("UPDATE dbo.JOB_TRAFFIC_DET SET ")
                StringBuilder.Append(" TASK_START_DATE = NULL, ")
                StringBuilder.Append(" JOB_REVISED_DATE = NULL, ")
                StringBuilder.Append(" JOB_COMPLETED_DATE = NULL ")

                If IncludeOriginal Then

                    StringBuilder.Append(", JOB_DUE_DATE = NULL ")

                End If

                StringBuilder.Append(" WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR")

                JobNumberSqlParameter = New SqlClient.SqlParameter("JOB_NUMBER", System.Data.SqlDbType.Int) With {.Value = JobNumber}
                JobComponentNumberSqlParameter = New SqlClient.SqlParameter("JOB_COMPONENT_NBR", System.Data.SqlDbType.SmallInt) With {.Value = JobComponentNumber}

                DbContext.Database.ExecuteSqlCommand(StringBuilder.ToString, JobNumberSqlParameter, JobComponentNumberSqlParameter)

                Cleared = True

            Catch ex As Exception
                Cleared = False
            Finally
                ClearDates = Cleared
            End Try

        End Function
        Public Function SetOriginalDueDateOnlyWhereNotSet(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Boolean

            'objects
            Dim OriginalDueDateSet As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_TRAFFIC_DET WITH(ROWLOCK) SET JOB_DUE_DATE = JOB_REVISED_DATE " &
                                                         "WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} " &
                                                         "AND ((NOT JOB_REVISED_DATE IS NULL) AND (JOB_DUE_DATE IS NULL));", JobNumber, JobComponentNumber))

                OriginalDueDateSet = True

            Catch ex As Exception
                OriginalDueDateSet = False
            Finally
                SetOriginalDueDateOnlyWhereNotSet = OriginalDueDateSet
            End Try

        End Function
        Public Function SetOriginalDueDateForTasks(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumbers As Short()) As Boolean

            'objects
            Dim OriginalDueDateSet As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_TRAFFIC_DET WITH(ROWLOCK) SET JOB_DUE_DATE = JOB_REVISED_DATE " &
                                                                    "WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR IN ({2});", JobNumber, JobComponentNumber, String.Join(",", SequenceNumbers)))

                OriginalDueDateSet = True

            Catch ex As Exception
                OriginalDueDateSet = False
            Finally
                SetOriginalDueDateForTasks = OriginalDueDateSet
            End Try

        End Function
        Public Function SetOriginalDueDate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Boolean

            'objects
            Dim OriginalDueDateSet As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_TRAFFIC_DET WITH(ROWLOCK) SET JOB_DUE_DATE = JOB_REVISED_DATE " &
                                                                "WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1};", JobNumber, JobComponentNumber))

                OriginalDueDateSet = True

            Catch ex As Exception
                OriginalDueDateSet = False
            Finally
                SetOriginalDueDate = OriginalDueDateSet
            End Try

        End Function
        Public Function UpdatePredecessorsByLevelNotation(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short, ByVal PredecessorLevelNotation As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSequenceNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLevels As System.Data.SqlClient.SqlParameter = Nothing
            Dim LevelSequenceNumbers As Short() = Nothing
            Dim Message As String = ""
            Dim arParams2 As New List(Of System.Data.SqlClient.SqlParameter)
            arParams2.Add(New System.Data.SqlClient.SqlParameter("@job_number", JobNumber))
            arParams2.Add(New System.Data.SqlClient.SqlParameter("@job_component_nbr", JobComponentNumber))
            arParams2.Add(New System.Data.SqlClient.SqlParameter("@seq_nbr", SequenceNumber))

            Try

                SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
                SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
                SqlParameterSequenceNumber = New System.Data.SqlClient.SqlParameter("@seq_nbr", SqlDbType.SmallInt)
                SqlParameterLevels = New System.Data.SqlClient.SqlParameter("@level_notation", SqlDbType.VarChar)

                SqlParameterJobNumber.Value = JobNumber
                SqlParameterJobComponentNumber.Value = JobComponentNumber
                SqlParameterSequenceNumber.Value = SequenceNumber

                If Not String.IsNullOrWhiteSpace(PredecessorLevelNotation) Then

                    PredecessorLevelNotation = PredecessorLevelNotation.Replace(" ", "")

                    PredecessorLevelNotation = "," & PredecessorLevelNotation & ","

                    SqlParameterLevels.Value = PredecessorLevelNotation

                    LevelSequenceNumbers = DbContext.Database.SqlQuery(Of Short)("SELECT SEQ_NBR FROM dbo.advtf_traffic_schedule_GetHierarchyDates(@job_number, @job_component_nbr)  WHERE @level_notation LIKE '%,' + [LEVEL] + ',%'", SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterLevels).ToArray

                    'if we are a parent task don't allow us to be a pred
                    If (DbContext.Database.SqlQuery(Of Integer)("select count(*) from JOB_TRAFFIC_DET WHERE PARENT_TASK_SEQ = @seq_nbr AND JOB_NUMBER = @job_number and JOB_COMPONENT_NBR = @job_component_nbr", arParams2.ToArray).FirstOrDefault = 0) Then

                        For Each LevelSequenceNumber In LevelSequenceNumbers
                            Dim arParams As New List(Of System.Data.SqlClient.SqlParameter)
                            arParams.Add(New System.Data.SqlClient.SqlParameter("@job_number", JobNumber))
                            arParams.Add(New System.Data.SqlClient.SqlParameter("@job_component_nbr", JobComponentNumber))
                            arParams.Add(New System.Data.SqlClient.SqlParameter("@seq_nbr", LevelSequenceNumber))

                            Message = ""

                            'if the task we are trying to connect to is a pred dont connect
                            If (DbContext.Database.SqlQuery(Of Integer)("select count(*) from JOB_TRAFFIC_DET WHERE PARENT_TASK_SEQ = @seq_nbr AND JOB_NUMBER = @job_number and JOB_COMPONENT_NBR = @job_component_nbr", arParams.ToArray).FirstOrDefault = 0) Then

                                If Not CreatePredecessor(DbContext, JobNumber, JobComponentNumber, SequenceNumber, LevelSequenceNumber, Message) Then

                                    ErrorMessage &= Message

                                End If
                            End If

                        Next
                    End If
                Else

                    DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.JOB_TRAFFIC_DET_PREDS WHERE JOB_NUMBER = @job_number AND JOB_COMPONENT_NBR = @job_component_nbr AND SEQ_NBR = @seq_nbr", SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterSequenceNumber)

                End If

                Updated = True

            Catch ex As Exception
                Updated = False
            Finally
                UpdatePredecessorsByLevelNotation = Updated
            End Try

        End Function
        Public Function LookupJobComponents(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String, Optional ByVal JobNumber As Integer? = Nothing,
                                            Optional ByVal ClientCode As String = Nothing, Optional ByVal DivisionCode As String = Nothing, Optional ByVal ProductCode As String = Nothing,
                                            Optional ByVal IsCopy As Boolean = False, Optional ByVal ShowClosed As Boolean = False) As List(Of AdvantageFramework.Database.Views.JobComponentView)

            'objects
            Dim JobComponentViews As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing
            Dim OpenComponentOnly As Boolean = True

            Try

                If ShowClosed = True Then
                    OpenComponentOnly = False
                Else
                    OpenComponentOnly = True
                End If

                JobComponentViews = AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, UserCode, ClientCode, DivisionCode, ProductCode, JobNumber.GetValueOrDefault(0), OpenComponentOnly, Nothing)

            Catch ex As Exception
                JobComponentViews = Nothing
            Finally
                LookupJobComponents = JobComponentViews
            End Try

        End Function
        Public Function LookupClients(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Client)

            'objects
            Dim Clients As Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Client) = Nothing

            Try

                Clients = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext)

            Catch ex As Exception
                Clients = Nothing
            Finally
                LookupClients = Clients
            End Try

        End Function
        Public Function LookupDivisions(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, Optional ByVal ClientCode As String = "") As Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.DivisionView)

            'objects
            Dim DivisionViews As Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.DivisionView) = Nothing

            Try

                DivisionViews = AdvantageFramework.Database.Procedures.DivisionView.LoadAllActiveByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext)

                If Not String.IsNullOrWhiteSpace(ClientCode) Then

                    DivisionViews = DivisionViews.Where(Function(d) d.ClientCode = ClientCode)

                End If

            Catch ex As Exception
                DivisionViews = Nothing
            Finally
                LookupDivisions = DivisionViews
            End Try

        End Function
        Public Function LookupProducts(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, Optional ByVal ClientCode As String = "",
                                       Optional ByVal DivisionCode As String = "") As Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.ProductView)

            'objects
            Dim ProductViews As Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.ProductView) = Nothing

            Try

                ProductViews = AdvantageFramework.Database.Procedures.ProductView.LoadAllActiveByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext)

                If Not String.IsNullOrWhiteSpace(ClientCode) OrElse Not String.IsNullOrWhiteSpace(DivisionCode) Then

                    ProductViews = ProductViews.Where(Function(p) p.ClientCode = ClientCode AndAlso p.DivisionCode = DivisionCode)

                End If

            Catch ex As Exception
                ProductViews = Nothing
            Finally
                LookupProducts = ProductViews
            End Try

        End Function
        Public Function CreateSchedule(ByVal Session As AdvantageFramework.Security.Session, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TrafficStatus As String, Optional ByVal ProjectManager As String = Nothing,
                                       Optional ByVal IsCopy As Boolean = False, Optional ByVal CopyJobNumber As Integer? = Nothing, Optional ByVal CopyJobComponentNumber As Short? = Nothing, Optional ByVal IncludeStartDate As Boolean = False,
                                       Optional ByVal IncludeDueDate As Boolean = False, Optional ByVal IncludeTaskEmployee As Boolean = False, Optional ByVal IncludeTaskComment As Boolean = False, Optional ByVal IncludeDueDateComment As Boolean = False,
                                       Optional ByVal ShowClosed As Boolean = False, Optional IncludeTaskStatus As Boolean = False, Optional ByRef ErrorList As Generic.List(Of String) = Nothing) As Boolean

            'objects
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim ErrorMessage As String = ""
            Dim Created As Boolean = False

            Try

                ErrorList = New Generic.List(Of String)

                If JobNumber <= 0 Then

                    ErrorList.Add("Please enter a valid job number.")

                End If

                If JobComponentNumber <= 0 Then

                    ErrorList.Add("Please enter a valid job component number.")

                End If

                If IsCopy = True Then

                    If CopyJobNumber <= 0 Then

                        ErrorList.Add("Invalid job number for copy.")

                    End If

                    If CopyJobComponentNumber <= 0 Then

                        ErrorList.Add("Invalid component number for copy.")

                    End If

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                            With LookupJobComponents(DbContext, Session.UserCode, Nothing, Nothing, Nothing, Nothing, False, ShowClosed)

                                If Not .Where(Function(jc) jc.JobNumber = JobNumber AndAlso jc.JobComponentNumber = JobComponentNumber).Any Then

                                    ErrorList.Add("Access to this job/comp is denied.")

                                End If

                                If IsCopy = True AndAlso CopyJobNumber > 0 AndAlso CopyJobComponentNumber > 0 Then

                                    If Not .Where(Function(jc) jc.JobNumber = CopyJobNumber AndAlso jc.JobComponentNumber = CopyJobComponentNumber).Any Then

                                        ErrorList.Add("This is not a valid job for copying.")

                                    End If

                                End If

                            End With

                            If Not (From Item In AdvantageFramework.Database.Procedures.Status.LoadAllActive(DbContext)
                                    Where Item.Code = TrafficStatus
                                    Select Item).Any Then

                                ErrorList.Add("Invalid Project Schedule Status.")

                            End If

                            If Not String.IsNullOrWhiteSpace(ProjectManager) Then

                                If Not (From Item In AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCodeWithOfficeLimits(Session, DbContext, Nothing)
                                        Where Item.Code = ProjectManager
                                        Select Item).Any Then

                                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                                        ErrorList.Add("Invalid " & LoadProjectScheduleManagerLabel(DataContext) & " code.")

                                    End Using

                                End If

                            End If

                        End If

                        If ErrorList.Count = 0 Then

                            If IsCopy = True Then

                                Created = CopySchedule(DbContext, JobNumber, JobComponentNumber, CopyJobNumber, CopyJobComponentNumber, TrafficStatus, IncludeStartDate, IncludeDueDate, IncludeTaskEmployee, IncludeTaskComment, IncludeDueDateComment, ProjectManager, IncludeTaskStatus, ErrorMessage)

                                If Not Created Then

                                    If Not String.IsNullOrWhiteSpace(ErrorMessage) Then

                                        ErrorList.Add(ErrorMessage)

                                    End If

                                End If

                            Else

                                JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                                If JobComponent IsNot Nothing Then

                                    Created = AddNewSchedule(DbContext, JobNumber, JobComponentNumber, "", TrafficStatus, JobComponent.StartDate, JobComponent.DueDate, ProjectManager, Session.UserCode, ErrorMessage)

                                    If Not Created Then

                                        If Not String.IsNullOrWhiteSpace(ErrorMessage) Then

                                            ErrorList.Add(ErrorMessage)

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    End Using

                End Using

            Catch ex As Exception
                ErrorList.Add(ex.Message.ToString)
            End Try

            Return Created

        End Function
        Private Function AddNewSchedule(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TrafficPresetCode As String,
                                        ByVal TrafficCode As String, ByVal ScheduleStartDate As Date?, ByVal ScheduleDueDate As Date?, ByVal ProjectManagerCode As String, ByVal UserCode As String,
                                        ByRef ErrorMessage As String) As Boolean

            'objects
            Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim TrafficPresetCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim TrafficCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ScheduleStartDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ScheduleDueDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ProjectManagerCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim Added As Boolean = False

            JobNumberSqlParameter = New SqlClient.SqlParameter("@JOB_NUM", SqlDbType.Int)
            JobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            TrafficPresetCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@TRF_PRESET_CODE", SqlDbType.VarChar, 6)
            TrafficCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@TRF_CODE", SqlDbType.VarChar, 10)
            ScheduleStartDateSqlParameter = New System.Data.SqlClient.SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            ScheduleDueDateSqlParameter = New System.Data.SqlClient.SqlParameter("@DUE_DATE", SqlDbType.SmallDateTime)
            ProjectManagerCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@TRAFFIC_MGR_CODE", SqlDbType.VarChar, 6)
            UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)

            JobNumberSqlParameter.Value = JobNumber
            JobComponentNumberSqlParameter.Value = JobComponentNumber
            TrafficPresetCodeSqlParameter.Value = TrafficPresetCode
            TrafficCodeSqlParameter.Value = TrafficCode

            If ScheduleStartDate.HasValue Then

                ScheduleStartDateSqlParameter.Value = ScheduleStartDate

            Else

                ScheduleStartDateSqlParameter.Value = DBNull.Value

            End If

            If ScheduleDueDate.HasValue Then

                ScheduleDueDateSqlParameter.Value = ScheduleDueDate

            Else

                ScheduleDueDateSqlParameter.Value = DBNull.Value

            End If

            If Not String.IsNullOrWhiteSpace(ProjectManagerCode) Then

                ProjectManagerCodeSqlParameter.Value = ProjectManagerCode

            Else

                ProjectManagerCodeSqlParameter.Value = DBNull.Value

            End If

            UserCodeSqlParameter.Value = UserCode

            Try

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_Traffic_Schedule_AddNew_AddSchedule] @JOB_NUM, @JOB_COMPONENT_NBR, @TRF_PRESET_CODE, @TRF_CODE, @START_DATE, @DUE_DATE, @TRAFFIC_MGR_CODE, @USER_CODE",
                                                     JobNumberSqlParameter, JobComponentNumberSqlParameter, TrafficPresetCodeSqlParameter, TrafficCodeSqlParameter,
                                                     ScheduleStartDateSqlParameter, ScheduleDueDateSqlParameter, ProjectManagerCodeSqlParameter, UserCodeSqlParameter)

                Added = True

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Added

        End Function
        Private Function CopySchedule(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobCompNumber As Integer,
                                      ByVal CopyJobNumber As Integer, ByVal CopyJobComponentNumber As Integer, ByVal TrafficCode As String, ByVal IncludeStartDate As Boolean,
                                      ByVal IncludeDueDate As Boolean, ByVal IncludeEmployees As Boolean, ByVal IncludeTaskComment As Boolean, ByVal IncludeDueDateComment As Boolean,
                                      ByVal ProjectManagerCode As String, ByVal IncludeTaskStatus As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim CopyJobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim CopyJobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim TrafficCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeStartDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeDueDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeEmployeesSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeTaskCommentSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeDueDateCommentSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ProjectManagerCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ScheduleTemplateCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeTaskStatusSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            Try

                CopyJobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JobNum", SqlDbType.Int)
                CopyJobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JobCompNum", SqlDbType.Int)
                JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_NUM", SqlDbType.Int)
                JobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_COMP", SqlDbType.Int)
                TrafficCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@TRF_CODE", SqlDbType.VarChar)
                IncludeStartDateSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeStartDate", SqlDbType.SmallInt)
                IncludeDueDateSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeDueDate", SqlDbType.SmallInt)
                IncludeEmployeesSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeEmployees", SqlDbType.SmallInt)
                IncludeTaskCommentSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeTaskComment", SqlDbType.SmallInt)
                IncludeDueDateCommentSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeDueDateComment", SqlDbType.SmallInt)
                ProjectManagerCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@TRAFFIC_MGR_CODE", SqlDbType.VarChar, 6)
                ScheduleTemplateCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@ScheduleTemplate", SqlDbType.SmallInt)
                IncludeTaskStatusSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeTaskStatus", SqlDbType.SmallInt)

                SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
                SqlParameterUserCode.Value = DbContext.UserCode

                CopyJobNumberSqlParameter.Value = CopyJobNumber
                CopyJobComponentNumberSqlParameter.Value = CopyJobComponentNumber
                JobNumberSqlParameter.Value = JobNumber
                JobComponentNumberSqlParameter.Value = JobCompNumber
                TrafficCodeSqlParameter.Value = TrafficCode
                IncludeStartDateSqlParameter.Value = If(IncludeStartDate, 1, 0)
                IncludeDueDateSqlParameter.Value = If(IncludeDueDate, 1, 0)
                IncludeEmployeesSqlParameter.Value = If(IncludeEmployees, 1, 0)
                IncludeTaskCommentSqlParameter.Value = If(IncludeTaskComment, 1, 0)
                IncludeDueDateCommentSqlParameter.Value = If(IncludeDueDateComment, 1, 0)
                ScheduleTemplateCodeSqlParameter.Value = 0
                IncludeTaskStatusSqlParameter.Value = If(IncludeTaskStatus, 1, 0)

                If Not String.IsNullOrWhiteSpace(ProjectManagerCode) Then

                    ProjectManagerCodeSqlParameter.Value = ProjectManagerCode

                Else

                    ProjectManagerCodeSqlParameter.Value = DBNull.Value

                End If

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_Traffic_Schedule_JobCopy] @JobNum, @JobCompNum, @JOB_NUM, @JOB_COMP, @TRF_CODE, @IncludeStartDate, @IncludeDueDate, @IncludeEmployees, @IncludeTaskComment, @IncludeDueDateComment, @TRAFFIC_MGR_CODE, @ScheduleTemplate, @user_id, @IncludeTaskStatus",
                                                     CopyJobNumberSqlParameter, CopyJobComponentNumberSqlParameter, JobNumberSqlParameter, JobComponentNumberSqlParameter, TrafficCodeSqlParameter, IncludeStartDateSqlParameter,
                                                     IncludeDueDateSqlParameter, IncludeEmployeesSqlParameter, IncludeTaskCommentSqlParameter, IncludeDueDateCommentSqlParameter, ProjectManagerCodeSqlParameter, ScheduleTemplateCodeSqlParameter, SqlParameterUserCode, IncludeTaskStatusSqlParameter)

                Copied = True

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Copied

        End Function
        Public Function CopyTask(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                 ByVal FromJobNumber As Integer, ByVal FromJobComponentNumber As Short, ByVal FromTaskSequenceNumber As Short,
                                 ByVal ToJobNumber As Integer, ByVal ToJobComponentNumber As Short,
                                 ByVal CopyEmployees As Boolean, ByVal CopyDates As Boolean, ByVal CopyContacts As Boolean, ByVal CopyDocuments As Boolean,
                                 Optional ByRef ErrorMessage As String = "") As AdvantageFramework.Database.Entities.JobComponentTask

            Dim CopyToSchedule As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim CopyFromTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim NewTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

            Try

                CopyToSchedule = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, ToJobNumber, ToJobComponentNumber)

                If CopyToSchedule IsNot Nothing Then

                    CopyFromTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext,
                                                                                                                                                 FromJobNumber, FromJobComponentNumber, FromTaskSequenceNumber)

                    If CopyFromTask IsNot Nothing Then

                        NewTask = New Database.Entities.JobComponentTask

                        NewTask = CopyFromTask.DuplicateEntity

                        NewTask.JobNumber = ToJobNumber
                        NewTask.JobComponentNumber = ToJobComponentNumber
                        NewTask.CompletedDate = Nothing
                        NewTask.HoursAssigned = Nothing
                        NewTask.EmployeeCode = Nothing
                        NewTask.TempCompletionDate = Nothing
                        'NewTask.TaskCode = CopyFromTask.TaskCode
                        'NewTask.FuctionCode = CopyFromTask.FuctionCode
                        'NewTask.Description = CopyFromTask.Description
                        'NewTask.IsDueDateLocked = CopyFromTask.IsDueDateLocked
                        'NewTask.OrderNumber = CopyFromTask.OrderNumber

                        'If CopyDates = True Then

                        '    NewTask.StartDate = CopyFromTask.StartDate
                        '    NewTask.DueDate = CopyFromTask.DueDate
                        '    NewTask.DueDateComment = CopyFromTask.DueDateComment
                        '    NewTask.DueTime = CopyFromTask.DueTime
                        '    NewTask.OriginalDueDate = CopyFromTask.OriginalDueDate
                        '    NewTask.OriginalDueDateComment = CopyFromTask.OriginalDueDateComment
                        '    NewTask.OriginalDueTime = CopyFromTask.OriginalDueTime

                        'End If
                        If CopyDates = False Then

                            NewTask.StartDate = Nothing
                            NewTask.DueDate = Nothing
                            NewTask.DueDateComment = Nothing
                            NewTask.DueTime = Nothing
                            NewTask.OriginalDueDate = Nothing
                            NewTask.OriginalDueDateComment = Nothing
                            NewTask.OriginalDueTime = Nothing

                        End If

                        If AdvantageFramework.Database.Procedures.JobComponentTask.Insert(DbContext, NewTask) = True Then

                            If CopyEmployees = True Then

                                Dim TaskEmployees As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTaskEmployee) = Nothing

                                TaskEmployees = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeq(DbContext, NewTask.JobNumber, NewTask.JobComponentNumber, NewTask.SequenceNumber).ToList

                                If TaskEmployees IsNot Nothing Then

                                    Dim NewTaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing

                                    For Each TaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee In TaskEmployees

                                        NewTaskEmployee = New Database.Entities.JobComponentTaskEmployee

                                        NewTaskEmployee.JobNumber = TaskEmployee.JobNumber
                                        NewTaskEmployee.JobComponentNumber = TaskEmployee.JobComponentNumber
                                        NewTaskEmployee.SequenceNumber = TaskEmployee.SequenceNumber
                                        NewTaskEmployee.EmployeeCode = TaskEmployee.EmployeeCode
                                        NewTaskEmployee.Hours = TaskEmployee.Hours

                                        AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Insert(DbContext, NewTaskEmployee)
                                        NewTaskEmployee = Nothing

                                    Next

                                End If

                            End If
                            If CopyContacts = True AndAlso FromJobNumber = ToJobNumber AndAlso FromJobComponentNumber = ToJobComponentNumber Then

                                Dim TaskContacts As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTaskClientContact) = Nothing

                                TaskContacts = AdvantageFramework.Database.Procedures.JobComponentTaskClientContact.LoadByJobCompAndSequence(DbContext, NewTask.JobNumber, NewTask.JobComponentNumber, NewTask.SequenceNumber).ToList

                                If TaskContacts IsNot Nothing Then

                                    Dim NewTaskContact As AdvantageFramework.Database.Entities.JobComponentTaskClientContact = Nothing

                                    For Each TaskContact As AdvantageFramework.Database.Entities.JobComponentTaskClientContact In TaskContacts

                                        NewTaskContact = New Database.Entities.JobComponentTaskClientContact

                                        NewTaskContact.JobNumber = TaskContact.JobNumber
                                        NewTaskContact.JobComponentNumber = TaskContact.JobComponentNumber
                                        NewTaskContact.SequenceNumber = TaskContact.SequenceNumber
                                        NewTaskContact.ClientContactID = TaskContact.ClientContactID

                                        AdvantageFramework.Database.Procedures.JobComponentTaskClientContact.Insert(DbContext, NewTaskContact)
                                        NewTaskContact = Nothing

                                    Next

                                End If

                            End If
                            If CopyDocuments = True Then

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return NewTask

        End Function
        Public Function LoadProjectScheduleManageColumn(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Column As String = Nothing

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, "TRAFFIC_MGR_COL")

            If Setting IsNot Nothing Then

                Column = Setting.Value

            End If

            Return Column

        End Function

        Public Function LoadProjectScheduleManageColumnForAlertFilter(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Column As String = Nothing

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, "TRAFFIC_MGR_COL")

            If Setting IsNot Nothing Then

                If Setting.Value IsNot Nothing Then
                    Column = "ASSIGN_" & Setting.Value.Substring(8, 1)
                End If

                If Column = "" Then
                    Column = "ASSIGN_1"
                End If

            End If

            Return Column

        End Function
        Public Function LoadProjectScheduleManagerLabel(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'TRAFFIC_MGR_COL
            'objects
            Dim Column As String = Nothing
            Dim SettingLabel As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim ManagerLabel As String = Nothing

            Column = LoadProjectScheduleManageColumn(DataContext)

            If Not String.IsNullOrWhiteSpace(Column) Then

                SettingLabel = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, Column)

                If SettingLabel IsNot Nothing Then

                    If Not String.IsNullOrWhiteSpace(SettingLabel.Value) Then

                        ManagerLabel = SettingLabel.Value.ToString

                    ElseIf Not String.IsNullOrWhiteSpace(SettingLabel.DefaultValue) Then

                        ManagerLabel = SettingLabel.Value.ToString

                    End If

                End If

            End If

            If String.IsNullOrWhiteSpace(ManagerLabel) Then

                ManagerLabel = "Manager"

            End If

            Return ManagerLabel

        End Function
        Public Function LoadDefaultStatus(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim DefaultStatus As String = Nothing

            Try

                DefaultStatus = (From Item In AdvantageFramework.Database.Procedures.Setting.LoadBySettingModuleID(DataContext, 2)
                                 Where Item.Code = "TRF_DFLT_STATUS"
                                 Select Item.Value).FirstOrDefault

            Catch ex As Exception
                DefaultStatus = Nothing
            End Try

            Return DefaultStatus

        End Function
        Public Function SaveUserColumn(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TrafficScheduleUserColumn As AdvantageFramework.Database.Classes.TrafficScheduleUserColumn) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ColumnIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ShowOnGridSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ShowOnAddNewSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim OrderSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            Try

                EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar) With {.Value = TrafficScheduleUserColumn.HeaderCode}
                ColumnIDSqlParameter = New System.Data.SqlClient.SqlParameter("@COLUMN_ID", SqlDbType.Int) With {.Value = TrafficScheduleUserColumn.ID}
                ShowOnGridSqlParameter = New System.Data.SqlClient.SqlParameter("@SHOW_ON_GRID", SqlDbType.Bit) With {.Value = CBool(TrafficScheduleUserColumn.ShowOnGrid)}
                ShowOnAddNewSqlParameter = New System.Data.SqlClient.SqlParameter("@SHOW_ON_ADDNEW", SqlDbType.Bit) With {.Value = CBool(TrafficScheduleUserColumn.ShowOnAddNew)}
                OrderSqlParameter = New System.Data.SqlClient.SqlParameter("@ORDER", SqlDbType.SmallInt) With {.Value = TrafficScheduleUserColumn.ColumnOrder}

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_project_schedule_SaveUserColumn] @EMP_CODE, @COLUMN_ID, @SHOW_ON_GRID, @SHOW_ON_ADDNEW, @ORDER",
                                                     EmployeeCodeSqlParameter, ColumnIDSqlParameter, ShowOnGridSqlParameter, ShowOnAddNewSqlParameter, OrderSqlParameter)

                Saved = True

            Catch ex As Exception
                Saved = False
            Finally
                SaveUserColumn = Saved
            End Try

        End Function
        Public Function ValidateEmployee(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal EmployeeCode As String) As Boolean

            Return (From Item In LoadEmployees(Session, DbContext, SecurityDbContext)
                    Where Item.Code = EmployeeCode
                    Select Item).Any

        End Function
        Public Function LoadEmployees(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            Return AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveByUserCodeWithOfficeLimitsAndIncludeCurrentUser(Session, DbContext, SecurityDbContext)

        End Function
        Public Function LinkTasks(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short, ByVal PredecessorSequenceNumber As Short, ByVal IsLinking As Boolean, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Linked As Boolean = False
            Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim SequenceNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim PredecessorSequenceNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim LinkSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int) With {.Value = JobNumber}
            JobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt) With {.Value = JobComponentNumber}
            SequenceNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@SEQ_NBR", SqlDbType.SmallInt) With {.Value = SequenceNumber}
            PredecessorSequenceNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@PREDECESSOR_SEQ_NBR", SqlDbType.SmallInt) With {.Value = PredecessorSequenceNumber}
            LinkSqlParameter = New System.Data.SqlClient.SqlParameter("@LINK", SqlDbType.Bit) With {.Value = IsLinking}

            Try

                If IsLinking = True Then

                    If Not ValidatePredecessors(DbContext, JobNumber, JobComponentNumber, SequenceNumber, {PredecessorSequenceNumber}, ErrorMessage) Then

                        Return False

                    End If

                End If

                DbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_traffic_schedule_LinkTasks @JOB_NUMBER, @JOB_COMPONENT_NBR, @SEQ_NBR, @LINK, @PREDECESSOR_SEQ_NBR", JobNumberSqlParameter, JobComponentNumberSqlParameter, SequenceNumberSqlParameter, LinkSqlParameter, PredecessorSequenceNumberSqlParameter)

                Linked = True

            Catch ex As Exception
                Linked = False
            End Try

            LinkTasks = Linked

        End Function
        Public Function ValidatePredecessors(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short, ByVal Predecessors As Short(), ByRef ErrorMessage As String) As Boolean

            'objects
            Dim JobComponentTaskPredecessors As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTaskPredecessor) = Nothing
            Dim PredecessorList As Generic.List(Of Short) = Nothing
            Dim IsValid As Boolean = True

            JobComponentTaskPredecessors = (From Item In AdvantageFramework.Database.Procedures.JobComponentTaskPredecessor.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)
                                            Where Item.SequenceNumber <> SequenceNumber
                                            Select Item).ToList

            PredecessorList = Nothing

            For Each Pred In Predecessors

                If Pred = SequenceNumber Then

                    ErrorMessage = "A task cannot be a predecessor of itself."

                    IsValid = False
                    Exit For

                ElseIf CheckPredecessorsForCircularReference(SequenceNumber, Pred, JobComponentTaskPredecessors) = True Then

                    ErrorMessage = "Selected predecessor(s) will create a circular reference. This is not allowed."

                    IsValid = False
                    Exit For

                End If

            Next

            Return IsValid

        End Function
        Private Function CheckPredecessorsForCircularReference(ByVal SequenceNumber As Short, ByVal PredecessorSequenceNumber As Short, ByVal AllPredecessors As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTaskPredecessor))

            'objects
            Dim IsCircular As Boolean = False

            For Each Predecessor In AllPredecessors.Where(Function(p) p.SequenceNumber = PredecessorSequenceNumber).ToList

                If Predecessor.PredecessorSequenceNumber = SequenceNumber OrElse CheckPredecessorsForCircularReference(SequenceNumber, Predecessor.PredecessorSequenceNumber, AllPredecessors) = True Then

                    IsCircular = True
                    Exit For

                End If

            Next

            Return IsCircular

        End Function
        Public Function AddTask(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer,
                                ByVal JobOrder As Integer, ByVal PhaseID As Integer, ByVal PredString As String, ByVal TaskCode As String, ByVal TaskDescription As String,
                                ByVal Milestone As Integer, ByVal JobDays As Integer, ByVal JobHours As Decimal, ByVal StartDate As String, ByVal RevisedDate As String,
                                ByVal DueTime As String, ByVal DueDate As String, ByVal DueDateLock As Boolean, ByVal JobCompletedDate As String, ByVal EmployeeCodeString As String,
                                ByVal EstimateFunctionCode As String, ByVal TaskComments As String, ByVal DueDateComments As String, ByVal RevisionDateComments As String,
                                ByVal RoleCode As String, ByVal ClientContactCodeString As String, ByVal TaskStatus As String) As String

            Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobOrderSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim TrafficPhaseIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim FunctionCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim TaskDescriptionSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim MilestoneSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobDaysSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobHoursSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim TaskStartDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim TaskDueDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim DueTimeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobDueDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim DueDateLockSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobCompletedDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EstimateFunctionSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim TaskCommentsSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim DueDateCommentsSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim RevisionDateCommentsSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmployeeListSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim PredecessorListSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim TrafficRoleSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim RowIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ContactIDsSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim TaskStatusSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim UserIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            If JobNumber > 0 And JobComponentNumber > 0 Then

                JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                JobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                JobOrderSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_ORDER", SqlDbType.SmallInt)
                TrafficPhaseIDSqlParameter = New System.Data.SqlClient.SqlParameter("@TRAFFIC_PHASE_ID", SqlDbType.Int)
                FunctionCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@FNC_CODE", SqlDbType.VarChar, 10)
                TaskDescriptionSqlParameter = New System.Data.SqlClient.SqlParameter("@TASK_DESCRIPTION", SqlDbType.VarChar, 40)
                MilestoneSqlParameter = New System.Data.SqlClient.SqlParameter("@MILESTONE", SqlDbType.SmallInt)
                JobDaysSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_DAYS", SqlDbType.SmallInt)
                JobHoursSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_HRS", SqlDbType.Decimal)
                TaskStartDateSqlParameter = New System.Data.SqlClient.SqlParameter("@TASK_START_DATE", SqlDbType.SmallDateTime)
                TaskDueDateSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_REVISED_DATE", SqlDbType.SmallDateTime)
                DueTimeSqlParameter = New System.Data.SqlClient.SqlParameter("@DUE_TIME", SqlDbType.VarChar, 10)
                JobDueDateSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_DUE_DATE", SqlDbType.SmallDateTime)
                DueDateLockSqlParameter = New System.Data.SqlClient.SqlParameter("@DUE_DATE_LOCK", SqlDbType.SmallInt)
                JobCompletedDateSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_COMPLETED_DATE", SqlDbType.SmallDateTime)
                EstimateFunctionSqlParameter = New System.Data.SqlClient.SqlParameter("@FNC_EST", SqlDbType.VarChar, 6)
                TaskCommentsSqlParameter = New System.Data.SqlClient.SqlParameter("@FNC_COMMENTS", SqlDbType.Text)
                DueDateCommentsSqlParameter = New System.Data.SqlClient.SqlParameter("@DUE_DATE_COMMENTS", SqlDbType.Text)
                RevisionDateCommentsSqlParameter = New System.Data.SqlClient.SqlParameter("@REV_DATE_COMMENTS", SqlDbType.Text)
                EmployeeListSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_LIST", SqlDbType.VarChar, 2000)
                PredecessorListSqlParameter = New System.Data.SqlClient.SqlParameter("@PRED_LIST", SqlDbType.VarChar, 2000)
                TrafficRoleSqlParameter = New System.Data.SqlClient.SqlParameter("@TRF_ROLE", SqlDbType.VarChar, 6)
                RowIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ROWID", SqlDbType.Int)
                ContactIDsSqlParameter = New System.Data.SqlClient.SqlParameter("@CONTACT_IDS", SqlDbType.VarChar, 2000)
                TaskStatusSqlParameter = New System.Data.SqlClient.SqlParameter("@TASK_STATUS", SqlDbType.VarChar, 1)
                UserIDSqlParameter = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar, 100)

                JobNumberSqlParameter.Value = JobNumber
                JobComponentNumberSqlParameter.Value = JobComponentNumber

                If JobOrder = 0 Then

                    JobOrderSqlParameter.Value = DBNull.Value

                Else

                    JobOrderSqlParameter.Value = JobOrder

                End If

                If PhaseID = 0 Then

                    TrafficPhaseIDSqlParameter.Value = DBNull.Value

                Else

                    TrafficPhaseIDSqlParameter.Value = PhaseID

                End If

                If TaskCode = "" Then

                    FunctionCodeSqlParameter.Value = DBNull.Value

                Else

                    FunctionCodeSqlParameter.Value = TaskCode

                End If

                If TaskDescription = "" Then

                    TaskDescriptionSqlParameter.Value = DBNull.Value

                Else

                    TaskDescriptionSqlParameter.Value = TaskDescription

                End If

                If Milestone = 0 Then

                    MilestoneSqlParameter.Value = 0

                Else

                    MilestoneSqlParameter.Value = 1

                End If

                If JobDays = 0 Then

                    JobDaysSqlParameter.Value = 0

                Else

                    JobDaysSqlParameter.Value = JobDays

                End If

                If JobHours = 0 Then

                    JobHoursSqlParameter.Value = 0

                Else

                    JobHoursSqlParameter.Value = JobHours

                End If

                If DateTime.TryParse(StartDate, TaskStartDateSqlParameter.Value) = False Then

                    TaskStartDateSqlParameter.Value = DBNull.Value

                End If

                If DateTime.TryParse(RevisedDate, TaskDueDateSqlParameter.Value) = False Then

                    TaskDueDateSqlParameter.Value = DBNull.Value

                End If

                If DueTime = "" Then

                    DueTimeSqlParameter.Value = DBNull.Value

                Else

                    DueTimeSqlParameter.Value = DueTime

                End If

                If DateTime.TryParse(DueDate, JobDueDateSqlParameter.Value) = False Then

                    JobDueDateSqlParameter.Value = DBNull.Value

                End If

                If DueDateLock = False Then

                    DueDateLockSqlParameter.Value = DBNull.Value

                Else

                    DueDateLockSqlParameter.Value = 1

                End If

                If DateTime.TryParse(JobCompletedDate, JobCompletedDateSqlParameter.Value) = False Then

                    JobCompletedDateSqlParameter.Value = DBNull.Value

                End If

                If EstimateFunctionCode = "" Or EstimateFunctionCode = "[None]" Then

                    EstimateFunctionSqlParameter.Value = DBNull.Value

                Else

                    EstimateFunctionSqlParameter.Value = EstimateFunctionCode

                End If

                If TaskComments = "" Then

                    TaskCommentsSqlParameter.Value = DBNull.Value

                Else

                    TaskCommentsSqlParameter.Value = TaskComments

                End If

                If DueDateComments = "" Then

                    DueDateCommentsSqlParameter.Value = DBNull.Value

                Else

                    DueDateCommentsSqlParameter.Value = DueDateComments

                End If

                If RevisionDateComments = "" Then

                    RevisionDateCommentsSqlParameter.Value = DBNull.Value

                Else

                    RevisionDateCommentsSqlParameter.Value = RevisionDateComments

                End If

                If EmployeeCodeString = "" Then

                    EmployeeListSqlParameter.Value = DBNull.Value

                Else

                    EmployeeListSqlParameter.Value = String.Join(",", (From Item In EmployeeCodeString.Split(",")
                                                                       Select Item.Trim()).Distinct.ToArray)

                End If

                If PredString = "" Then

                    PredecessorListSqlParameter.Value = DBNull.Value

                Else

                    PredecessorListSqlParameter.Value = PredString

                End If

                If RoleCode = "" Then

                    TrafficRoleSqlParameter.Value = DBNull.Value

                Else

                    TrafficRoleSqlParameter.Value = RoleCode

                End If

                RowIDSqlParameter.Direction = ParameterDirection.Output

                If ClientContactCodeString = "" Then

                    ContactIDsSqlParameter.Value = DBNull.Value

                Else

                    ContactIDsSqlParameter.Value = String.Join(",", (From Item In ClientContactCodeString.Split(",")
                                                                     Select Item.Trim).Distinct.ToArray)

                End If

                If TaskStatus = "" Then

                    TaskStatusSqlParameter.Value = DBNull.Value

                Else

                    TaskStatusSqlParameter.Value = TaskStatus

                End If

                UserIDSqlParameter.Value = DbContext.UserCode

                Try

                    DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_Traffic_Schedule_Add_Task] @JOB_NUMBER, @JOB_COMPONENT_NBR, @JOB_ORDER, @TRAFFIC_PHASE_ID, @FNC_CODE, @TASK_DESCRIPTION, @MILESTONE, @JOB_DAYS, @JOB_HRS, @TASK_START_DATE, @JOB_REVISED_DATE, @DUE_TIME, @JOB_DUE_DATE, @DUE_DATE_LOCK, @JOB_COMPLETED_DATE, @FNC_EST, @FNC_COMMENTS, @DUE_DATE_COMMENTS, @REV_DATE_COMMENTS, @EMP_LIST, @PRED_LIST, @TRF_ROLE, @ROWID, @CONTACT_IDS, @TASK_STATUS",
                                                         JobNumberSqlParameter, JobComponentNumberSqlParameter, JobOrderSqlParameter, TrafficPhaseIDSqlParameter, FunctionCodeSqlParameter,
                                                         TaskDescriptionSqlParameter, MilestoneSqlParameter, JobDaysSqlParameter, JobHoursSqlParameter, TaskStartDateSqlParameter, TaskDueDateSqlParameter,
                                                         DueTimeSqlParameter, JobDueDateSqlParameter, DueDateLockSqlParameter, JobCompletedDateSqlParameter, EstimateFunctionSqlParameter,
                                                         TaskCommentsSqlParameter, DueDateCommentsSqlParameter, RevisionDateCommentsSqlParameter, EmployeeListSqlParameter, PredecessorListSqlParameter,
                                                         TrafficRoleSqlParameter, RowIDSqlParameter, ContactIDsSqlParameter, TaskStatusSqlParameter)
                    Return RowIDSqlParameter.Value

                Catch ex As Exception
                    Return ex.Message.ToString
                End Try

            End If

            Return ""

        End Function
        Public Function QuickAddTask(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                     ByVal JobNumber As Integer,
                                     ByVal JobComponentNumber As Short,
                                     ByVal TaskCode As String,
                                     ByVal TaskDescription As String,
                                     ByVal JobOrder As Short?,
                                     ByVal GridOrder As Short?,
                                     ByVal ParentTaskSequenceNumber As Short?,
                                     ByVal FunctionCode As String) As AdvantageFramework.Database.Entities.JobComponentTask

            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

            Try
                If JobNumber > 0 AndAlso JobComponentNumber > 0 Then
                    JobComponentTask = New AdvantageFramework.Database.Entities.JobComponentTask
                    With JobComponentTask

                        .StatusCode = "P"
                        If String.IsNullOrWhiteSpace(TaskCode) = False Then
                            .TaskCode = TaskCode
                        End If
                        .Description = TaskDescription
                        .JobNumber = JobNumber
                        .JobComponentNumber = JobComponentNumber
                        .OrderNumber = JobOrder
                        .GridOrder = GridOrder
                        .ParentTaskSequenceNumber = ParentTaskSequenceNumber
                        .FuctionCode = FunctionCode
                    End With

                    If AdvantageFramework.Database.Procedures.JobComponentTask.Insert(DbContext, JobComponentTask) = False Then
                        JobComponentTask = Nothing
                    End If

                End If
            Catch ex As Exception
                JobComponentTask = Nothing
            Finally
                QuickAddTask = JobComponentTask
            End Try

        End Function

#Region " Sprint Employee "


#End Region

#Region " Employee "

        'Private Function LoadEmployeeSimple(ByVal Session As AdvantageFramework.Security.Session,
        '                                ByVal EmployeeCode As String,
        '                                ByVal DepartmentTeamCode As String,
        '                                ByVal EmailGroupCode As String,
        '                                ByVal JobNumber As Integer,
        '                                ByVal JobComponentNumber As Short,
        '                                ByVal TaskSequenceNumber As Short,
        '                                ByVal IsLookingUpAccountExecutive As Boolean,
        '                                ByVal FilterByTaskRoles As Boolean,
        '                                ByVal FilterByJobEmailGroup As Boolean,
        '                                ByVal OnlyShowActive As Boolean) As Generic.List(Of AdvantageFramework

        '    Try

        '        Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '            Dim SqlParameterUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 10)
        '            Dim SqlParameterEmployeeCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        '            Dim SqlParameterDepartmentTeamCode As New System.Data.SqlClient.SqlParameter("@DP_TM_CODE", SqlDbType.VarChar, 6)
        '            Dim SqlParameterEmailGroupCode As New System.Data.SqlClient.SqlParameter("@EMAIL_GR_CODE", SqlDbType.VarChar, 50)
        '            Dim SqlParameterJobNumber As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        '            Dim SqlParameterJobComponentNumber As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        '            Dim SqlParameterTaskSequenceNumber As New System.Data.SqlClient.SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
        '            Dim SqlParameterIsLookingUpAccountExecutive As New System.Data.SqlClient.SqlParameter("@IS_AE", SqlDbType.Bit)
        '            Dim SqlParameterFilterByTaskRoles As New System.Data.SqlClient.SqlParameter("@IS_ROLE", SqlDbType.Bit)
        '            Dim SqlParameterFilterByJobEmailGroup As New System.Data.SqlClient.SqlParameter("@IS_EMAIL_GROUP", SqlDbType.Bit)
        '            Dim SqlParameterOnlyShowActive As New System.Data.SqlClient.SqlParameter("@ONLY_ACTIVE", SqlDbType.Bit)

        '            SqlParameterUserCode.Value = _Session.UserCode
        '            If EmployeeCode = "" Then

        '                SqlParameterEmployeeCode.Value = System.DBNull.Value

        '            Else

        '                SqlParameterEmployeeCode.Value = EmployeeCode

        '            End If
        '            If DepartmentTeamCode = "" Then

        '                SqlParameterDepartmentTeamCode.Value = System.DBNull.Value

        '            Else

        '                SqlParameterDepartmentTeamCode.Value = DepartmentTeamCode

        '            End If
        '            If EmailGroupCode = "" Then

        '                SqlParameterEmailGroupCode.Value = System.DBNull.Value

        '            Else

        '                SqlParameterEmailGroupCode.Value = EmailGroupCode

        '            End If
        '            If JobNumber = 0 Then

        '                SqlParameterJobNumber.Value = System.DBNull.Value

        '            Else

        '                SqlParameterJobNumber.Value = JobNumber

        '            End If
        '            If JobComponentNumber = 0 Then

        '                SqlParameterJobComponentNumber.Value = System.DBNull.Value

        '            Else

        '                SqlParameterJobComponentNumber.Value = JobComponentNumber

        '            End If
        '            If TaskSequenceNumber = -1 Then

        '                SqlParameterTaskSequenceNumber.Value = System.DBNull.Value

        '            Else

        '                SqlParameterTaskSequenceNumber.Value = TaskSequenceNumber

        '            End If

        '            SqlParameterIsLookingUpAccountExecutive.Value = IsLookingUpAccountExecutive
        '            SqlParameterFilterByTaskRoles.Value = FilterByTaskRoles
        '            SqlParameterFilterByJobEmailGroup.Value = FilterByJobEmailGroup
        '            SqlParameterOnlyShowActive.Value = OnlyShowActive

        '            LoadEmployeeSimple = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Entities.EmployeeSimple)("EXEC advsp_load_employee_simple @USER_CODE, @EMP_CODE, @DP_TM_CODE, @EMAIL_GR_CODE, @JOB_NUMBER, @JOB_COMPONENT_NBR, @SEQ_NBR, @IS_AE, @IS_ROLE, @IS_EMAIL_GROUP, @ONLY_ACTIVE",
        '                                                                                                                 SqlParameterUserCode,
        '                                                                                                                 SqlParameterEmployeeCode,
        '                                                                                                                 SqlParameterDepartmentTeamCode,
        '                                                                                                                 SqlParameterEmailGroupCode,
        '                                                                                                                 SqlParameterJobNumber,
        '                                                                                                                 SqlParameterJobComponentNumber,
        '                                                                                                                 SqlParameterTaskSequenceNumber,
        '                                                                                                                 SqlParameterIsLookingUpAccountExecutive,
        '                                                                                                                 SqlParameterFilterByTaskRoles,
        '                                                                                                                 SqlParameterFilterByJobEmailGroup,
        '                                                                                                                 SqlParameterOnlyShowActive).ToList

        '        End Using

        '    Catch ex As Exception

        '        Return Nothing

        '    End Try

        'End Function

#End Region

#Region " Boards "

        Public Function UnCompleteBoardTask(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal UserCode As String, ByVal AlertID As Integer,
                                            ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As Boolean

            'objects
            Dim Uncompleted As Boolean = False
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

            Try

                JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, JobNumber, JobComponentNumber, SequenceNumber)

                If JobComponentTask IsNot Nothing Then

                    JobComponentTask.CompletedDate = Nothing
                    JobComponentTask.StatusCode = "P"

                    Uncompleted = AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask)

                    'If Uncompleted = True Then

                    '    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_alert_auto_comment] {0}, '{1}', NULL, 1, 1;", AlertID, UserCode))

                    'End If

                End If

            Catch ex As Exception
                Uncompleted = False
            Finally
                UnCompleteBoardTask = Uncompleted
            End Try

        End Function
        Public Function CompleteBoardTask(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String, ByVal AlertID As Integer,
                                          ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As Boolean

            'objects
            Dim Completed As Boolean = False
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

            Try

                JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, JobNumber, JobComponentNumber, SequenceNumber)

                If JobComponentTask IsNot Nothing Then

                    If JobComponentTask.CompletedDate.HasValue = False Then

                        JobComponentTask.CompletedDate = System.DateTime.Today

                    End If

                    Completed = AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask)

                    'If Completed = True Then

                    '    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_alert_auto_comment] {0}, '{1}', NULL, 1, 0;", AlertID, UserCode))

                    'End If

                End If

            Catch ex As Exception
                Completed = False
            Finally
                CompleteBoardTask = Completed
            End Try

        End Function
        Public Function ActivateBoardTask(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As Boolean

            'objects
            Dim Activated As Boolean = False
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

            Try

                JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, JobNumber, JobComponentNumber, SequenceNumber)

                If JobComponentTask IsNot Nothing Then

                    JobComponentTask.StatusCode = "A"
                    Activated = AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask)

                End If

            Catch ex As Exception
                Activated = False
            Finally
                ActivateBoardTask = Activated
            End Try

        End Function
        Public Function DeactivateBoardTask(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As Boolean

            'objects
            Dim Deactivated As Boolean = False
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

            Try

                JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, JobNumber, JobComponentNumber, SequenceNumber)

                If JobComponentTask IsNot Nothing Then

                    JobComponentTask.StatusCode = "P"
                    Deactivated = AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask)

                End If

            Catch ex As Exception
                Deactivated = False
            Finally
                DeactivateBoardTask = Deactivated
            End Try

        End Function

#End Region

#Region " Helpers "

        Public Function ToShortDateString(ByVal TheDate As Nullable(Of Date)) As String
            Try
                If TheDate IsNot Nothing AndAlso IsDate(TheDate) = True Then
                    Return CDate(TheDate).ToShortDateString
                Else
                    Return "--"
                End If
            Catch ex As Exception
                Return "--"
            End Try
        End Function

#End Region

#End Region

    End Module

End Namespace


