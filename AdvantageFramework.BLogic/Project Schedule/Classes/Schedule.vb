Namespace ProjectSchedule.Classes

    Public Class Schedule

#Region " Constants "

        Const AppVarApplicationName As String = "PROJECT_SCHEDULE"

#End Region

#Region " Enum "

        Public Enum QueryStringVars
            JobNum
            JobComp
            P
            Role
            Task
            Emp
            Cut
            Pend
            Proj
            Comp
            seq
        End Enum

        Public Enum UserSettingCodes
            IncludeCompleted
            GridSort
        End Enum

        Public Enum AgencySettingCodes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TRF_LOCK_DATE", "Lock the schedule calculation options at the header level")>
            IsScheduleCalculationLocked
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TR_TITLE1", "Project Schedule Assignment 1 Title")>
            Assignment1Label
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TR_TITLE2", "Project Schedule Assignment 2 Title")>
            Assignment2Label
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TR_TITLE3", "Project Schedule Assignment 3 Title")>
            Assignment3Label
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TR_TITLE4", "Project Schedule Assignment 4 Title")>
            Assignment4Label
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TR_TITLE5", "Project Schedule Assignment 5 Title")>
            Assignment5Label
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TRAFFIC_MGR_COL", "Manager Stored in Column")>
            ProjectManagerColumn
        End Enum

#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        Public Property JobTraffic As AdvantageFramework.Database.Entities.JobTraffic
        Public Property Assignment1Name As String
        Public Property Assignment2Name As String
        Public Property Assignment3Name As String
        Public Property Assignment4Name As String
        Public Property Assignment5Name As String
        Public Property Assignment1Code As String
        Public Property Assignment2Code As String
        Public Property Assignment3Code As String
        Public Property Assignment4Code As String
        Public Property Assignment5Code As String
        Public Property ClientCode As String
        Public Property DivisionCode As String
        Public Property ProductCode As String
        Public Property JobNumber As Integer
        Public Property JobComponentNumber As Short
        Public Property SequenceNumber As Short?
        Public Property CalculateByPredecessor As Boolean
        Public Property PhaseFilter As String
        Public Property RoleCode As String
        Public Property TaskCode As String
        Public Property EmployeeCode As String
        Public Property CutOffDate As String
        Public Property IncludeOnlyPendingTasks As Boolean
        Public Property ExcludeProjectedTasks As Boolean
        Public ReadOnly Property UsingATaskLevelFilter As Boolean
            Get
                Return IsUsingATaskLevelFilter(Me.PhaseFilter, Me.RoleCode, Me.TaskCode, Me.EmployeeCode, Me.CutOffDate, Me.IncludeOnlyPendingTasks, Me.ExcludeProjectedTasks, Me.UserSettings.IncludeCompletedTasks)
            End Get
        End Property
        Public Property IsJobDashboard As Boolean
        Public Property IsClientPortal As Boolean
        Public Property CanUserEdit As Boolean
        Public Property CanUserView As Boolean
        Public Property CanUserInsert As Boolean
        Public Property CanUserCustom1 As Boolean
        Public Property HasApprovedEstimate As Boolean
        Public Property Columns As ScheduleColumn()
        Public Property AgencySettings As AgencySetting
        Public Property UserSettings As UserSetting
		Public Property IsQuickEdit As Boolean
		Public Property IsTemplate As Boolean
		Public Property JobTypeCode As String
		Public Property JobTypeDescription As String

#End Region

#Region " Methods "

        Public Sub Load()

            'objects
            Dim AppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars) = Nothing
            Dim TrafficScheduleUserColumns As Generic.List(Of AdvantageFramework.Database.Classes.TrafficScheduleUserColumn) = Nothing
            Dim Settings As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
            Dim JobType As AdvantageFramework.Database.Entities.JobType = Nothing

            Me.CanUserView = AdvantageFramework.Security.CanUserPrintInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)
            Me.CanUserEdit = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)
            Me.CanUserInsert = AdvantageFramework.Security.CanUserAddInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)
            Me.CanUserCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Me.JobTraffic = Nothing

                '' JobTraffic comes back null for Marriott sometimes...not sure why, load each object separately below
                'Me.JobTraffic = (From Item In DbContext.JobTraffic.Include("Traffic").Include("JobComponent").Include("JobComponent.Job")
                '                 Where Item.JobNumber = JobNumber AndAlso
                '                       Item.JobComponentNumber = JobComponentNumber
                '                 Select Item).SingleOrDefault

                Me.JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                If Me.JobTraffic IsNot Nothing Then

                    '' JobTraffic comes back null for Marriott sometimes...not sure why, load each object separately
                    Me.JobTraffic.JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)
                    Me.JobTraffic.JobComponent.Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)
                    Me.JobTraffic.Traffic = AdvantageFramework.Database.Procedures.Status.LoadByStatusCode(DbContext, JobTraffic.TrafficCode)

                    With Me.JobTraffic

                        Me.JobNumber = .JobNumber
                        Me.JobComponentNumber = .JobComponentNumber
                        Me.CalculateByPredecessor = CBool(.ScheduleCalculation.GetValueOrDefault(0))
                        Me.IsTemplate = .IsTemplate

                        If .JobComponent IsNot Nothing Then

                            Me.ClientCode = .JobComponent.Job.ClientCode
                            Me.DivisionCode = .JobComponent.Job.DivisionCode
                            Me.ProductCode = .JobComponent.Job.ProductCode
                            Me.JobTypeCode = .JobComponent.JobTypeCode

                        End If
                        If String.IsNullOrWhiteSpace(Me.JobTypeCode) = False Then

                            JobType = AdvantageFramework.Database.Procedures.JobType.LoadByJobTypeCode(DbContext, Me.JobTypeCode)

                            If JobType IsNot Nothing Then

                                Me.JobTypeDescription = JobType.Description

                            End If

                        End If

                        If Not String.IsNullOrWhiteSpace(.Assign1) Then

                            Try

                                Me.Assignment1Name = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, .Assign1).ToString
                                Me.Assignment1Code = .Assign1

                            Catch ex As Exception
                            End Try

                        End If
                        If Not String.IsNullOrWhiteSpace(.Assign2) Then

                            Try

                                Me.Assignment2Name = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, .Assign2).ToString
                                Me.Assignment2Code = .Assign2

                            Catch ex As Exception
                            End Try

                        End If
                        If Not String.IsNullOrWhiteSpace(.Assign3) Then

                            Try

                                Me.Assignment3Name = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, .Assign3).ToString
                                Me.Assignment3Code = .Assign3

                            Catch ex As Exception
                            End Try

                        End If
                        If Not String.IsNullOrWhiteSpace(.Assign4) Then

                            Try

                                Me.Assignment4Name = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, .Assign4).ToString
                                Me.Assignment4Code = .Assign4

                            Catch ex As Exception
                            End Try

                        End If
                        If Not String.IsNullOrWhiteSpace(.Assign5) Then

                            Try

                                Me.Assignment5Name = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, .Assign5).ToString
                                Me.Assignment5Code = .Assign5

                            Catch ex As Exception
                            End Try

                        End If

                    End With

                    Me.HasApprovedEstimate = (From Item In AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext)
                                              Where Item.JobNumber = JobNumber AndAlso
                                                    Item.JobComponentNumber = JobComponentNumber
                                              Select Item).Any

                    Me.Columns = AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Load(_Session, DbContext, IsClientPortal, False, False, False).ToArray

                    AppVars = LoadAllAppVars(DbContext, _Session.UserCode)

                    Try

                        If AppVars.Any(Function(appVar) appVar.Name = UserSettingCodes.IncludeCompleted.ToString) Then

                            Me.UserSettings.IncludeCompletedTasks = CBool(AppVars.Where(Function(appVar) appVar.Name = UserSettingCodes.IncludeCompleted.ToString).First.Value)

                        End If

                    Catch ex As Exception
                        Me.UserSettings.IncludeCompletedTasks = False
                    End Try

                    Me.UserSettings.SortString = ""

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        Settings = LoadSettings(DataContext)

                        With Settings

                            Me.AgencySettings.IsScheduleCalculationLocked = CBool(.Where(Function(s) s.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(AgencySettingCodes.IsScheduleCalculationLocked).Code).FirstOrDefault().Value)
                            Me.AgencySettings.Assignment1Label = .Where(Function(s) s.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(AgencySettingCodes.Assignment1Label).Code).FirstOrDefault().Value
                            Me.AgencySettings.Assignment2Label = .Where(Function(s) s.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(AgencySettingCodes.Assignment2Label).Code).FirstOrDefault().Value
                            Me.AgencySettings.Assignment3Label = .Where(Function(s) s.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(AgencySettingCodes.Assignment3Label).Code).FirstOrDefault().Value
                            Me.AgencySettings.Assignment4Label = .Where(Function(s) s.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(AgencySettingCodes.Assignment4Label).Code).FirstOrDefault().Value
                            Me.AgencySettings.Assignment5Label = .Where(Function(s) s.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(AgencySettingCodes.Assignment5Label).Code).FirstOrDefault().Value
                            Me.AgencySettings.ProjectManagerColumn = .Where(Function(s) s.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(AgencySettingCodes.ProjectManagerColumn).Code).FirstOrDefault().Value

                        End With

                    End Using

                End If

                If Me.IsTemplate AndAlso Me.CanUserCustom1 Then

                    Me.CanUserEdit = False
                    Me.CanUserInsert = False

                End If

                If Me.IsClientPortal = True Then

                    Me.CanUserEdit = False
                    Me.CanUserInsert = False

                End If

            End Using

        End Sub
        Private Function LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext) As Generic.List(Of AdvantageFramework.Database.Entities.Setting)

            Return AdvantageFramework.Database.Procedures.Setting.LoadBySettingModuleID(DataContext, 0).ToList

        End Function
        Public Sub New()

            Me.AgencySettings = New AgencySetting()
            Me.UserSettings = New UserSetting()

        End Sub
        Public Sub New(ByVal Session As AdvantageFramework.Security.Session)

            Me.New()

            _Session = Session

        End Sub
        Public Shared Function IsUsingATaskLevelFilter(ByVal PhaseFilter As String, ByVal RoleCode As String, ByVal TaskCode As String, ByVal EmployeeCode As String, ByVal CutOffDate As String,
                                                       ByVal IncludeOnlyPendingTasks As Boolean, ByVal ExcludeProjectedTasks As Boolean, ByVal IncludeCompletedTasks As Boolean) As Boolean

            If (Not String.IsNullOrWhiteSpace(PhaseFilter) AndAlso PhaseFilter <> "no_filter") OrElse
                    Not String.IsNullOrWhiteSpace(RoleCode) OrElse
                    Not String.IsNullOrWhiteSpace(TaskCode) OrElse
                    Not String.IsNullOrWhiteSpace(EmployeeCode) OrElse
                    Not String.IsNullOrWhiteSpace(CutOffDate) OrElse
                    IncludeOnlyPendingTasks OrElse
                    ExcludeProjectedTasks OrElse
                    IncludeCompletedTasks Then

                Return True

            Else

                Return False

            End If

        End Function
        Public Shared Function SaveUserSetting(ByVal Session As AdvantageFramework.Security.Session, ByVal UserSettingCode As UserSettingCodes, ByVal Value As Object) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Saved As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                AppVar = (From Item In LoadAllAppVars(DbContext, Session.UserCode)
                          Where Item.Name = UserSettingCode.ToString
                          Select Item).SingleOrDefault

                If AppVar Is Nothing Then

                    AppVar = New AdvantageFramework.Database.Entities.AppVars

                    With AppVar

                        .Application = AppVarApplicationName
                        .UserCode = Session.UserCode
                        .Group = 0
                        .Name = UserSettingCode.ToString
                        .Value = Value

                    End With

                    Saved = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                Else

                    AppVar.Value = Value

                    Saved = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                End If

            End Using

            Return Saved

        End Function
        Public Shared Function LoadAllAppVars(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String) As IEnumerable(Of AdvantageFramework.Database.Entities.AppVars)

            Return AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, UserCode, AppVarApplicationName).ToList

        End Function
        Public Function IsColumnVisible(ByVal ColumnType As ScheduleColumn.Type) As Boolean

            If Me.Columns IsNot Nothing AndAlso Me.Columns.Count > 0 Then

                Return Me.Columns.Any(Function(c) c.ColumnType = ColumnType AndAlso c.Visible = True)

            Else

                Return False

            End If

        End Function

#End Region

#Region " Classes "

        Public Class ScheduleColumn

            Public Enum Type
                MoveLeftOrRight
                TaskStatus
                Phase
                PredecessorsList
                TaskCode
                TaskDescription
                JobDays
                TaskStartDate
                TaskDueDate
                DueDateLock
                DueTime
                OriginalDueDate
                CompletedDate
                TempCompletedDate
                JobHours
                DispersedHours
                EmployeesTextbox
                EmployeesLink
                EmployeesImage
                ClientContactsTextbox
                ClientContactsLink
                ClientContactsImage
                EstimateFunction
                Milestone
                TaskCommentsImage
                TaskCommentsTextbox
                DueDateComments
                RevisionComments
                PostedHours
                PercentComplete
                TaskDocuments
                EmployeesAutoComplete
                PredecessorsTextbox
                JobOrder
                Linked
                SelectPreds
                Priority
            End Enum

            Public Property ColumnType As Type
            Public Property Visible As Boolean
            Public Property HeaderText As String
            Public Property LongDescription As String
            Public Property Order As Short

            Public Shared Function LoadTrafficScheduleUserColumns(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IsClientPortal As Boolean, ByVal ShowAll As Boolean, ByVal IsSetup As Boolean, ByVal IsAddNew As Boolean) As Object

                'objects
                Dim TrafficScheduleUserColumns As Generic.List(Of AdvantageFramework.Database.Classes.TrafficScheduleUserColumn) = Nothing

                If IsClientPortal Then

                    TrafficScheduleUserColumns = AdvantageFramework.Database.Procedures.TrafficScheduleUserColumnComplexType.Load(DbContext, Session.ClientPortalUser.UserName, ShowAll, IsSetup, IsAddNew)

                Else

                    TrafficScheduleUserColumns = AdvantageFramework.Database.Procedures.TrafficScheduleUserColumnComplexType.Load(DbContext, Session.User.EmployeeCode, ShowAll, IsSetup, IsAddNew)

                End If

                Return TrafficScheduleUserColumns

            End Function
            Public Shared Function Load(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IsClientPortal As Boolean, ByVal ShowAll As Boolean, ByVal IsSetup As Boolean, ByVal IsAddNew As Boolean) As IEnumerable(Of ScheduleColumn)

                'objects
                Dim TrafficScheduleUserColumns As Generic.List(Of AdvantageFramework.Database.Classes.TrafficScheduleUserColumn) = Nothing
                Dim ShowColumn As Boolean = False
                Dim Column As ScheduleColumn = Nothing
                Dim Columns As Generic.List(Of ScheduleColumn) = Nothing

                TrafficScheduleUserColumns = LoadTrafficScheduleUserColumns(Session, DbContext, IsClientPortal, ShowAll, IsSetup, IsAddNew)
                Columns = New List(Of ScheduleColumn)

                For Each TrafficScheduleUserColumn In TrafficScheduleUserColumns

                    Column = New ScheduleColumn

                    Column.Visible = CBool(TrafficScheduleUserColumn.ShowOnGrid)
                    Column.HeaderText = TrafficScheduleUserColumn.HeaderText
                    Column.Order = TrafficScheduleUserColumn.ColumnOrder

                    Select Case TrafficScheduleUserColumn.ColumnName

                        Case "ColumnMove"

                            Column.ColumnType = Type.MoveLeftOrRight

                        Case "colTASK_STATUS"

                            Column.ColumnType = Type.TaskStatus

                        Case "colPHASE_DESC"

                            Column.ColumnType = Type.Phase

                        Case "GridTemplateColumnPreds"

                            Column.ColumnType = Type.PredecessorsList

                        Case "colTASK_CODE"

                            Column.ColumnType = Type.TaskCode

                        Case "colTASK_DESCRIPTION"

                            Column.ColumnType = Type.TaskDescription

                        Case "colJOB_DAYS"

                            Column.ColumnType = Type.JobDays

                        Case "colTASK_START_DATE"

                            Column.ColumnType = Type.TaskStartDate

                        Case "colJOB_REVISED_DATE"

                            Column.ColumnType = Type.TaskDueDate

                        Case "colLock"

                            Column.ColumnType = Type.DueDateLock

                        Case "colDUE_TIME"

                            Column.ColumnType = Type.DueTime

                        Case "colJOB_DUE_DATE"

                            Column.ColumnType = Type.OriginalDueDate

                        Case "colJOB_COMPLETED_DATE"

                            Column.ColumnType = Type.CompletedDate

                        Case "colTEMP_COMP_DATE"

                            Column.ColumnType = Type.TempCompletedDate

                        Case "colJOB_HRS"

                            Column.ColumnType = Type.JobHours

                        Case "colDISPERSED_JOB_HRS"

                            Column.ColumnType = Type.DispersedHours

                        Case "colEMP_CODE_TEXT"

                            Column.ColumnType = Type.EmployeesTextbox

                        Case "colEMP_CODE"

                            Column.ColumnType = Type.EmployeesLink

                        Case "colEMP_CODE_IMGBTN"

                            Column.ColumnType = Type.EmployeesImage

                        Case "colCLI_CONTACT_TEXT"

                            Column.ColumnType = Type.ClientContactsTextbox

                        Case "colCLI_CONTACT"

                            Column.ColumnType = Type.ClientContactsLink

                        Case "colCLI_CONTACT_IMGBTN"

                            Column.ColumnType = Type.ClientContactsImage

                        Case "colEstimateFunction"

                            Column.ColumnType = Type.EstimateFunction

                        Case "colMilestone"

                            Column.ColumnType = Type.Milestone

                        Case "colComments"

                            Column.ColumnType = Type.TaskCommentsImage

                        Case "colFNC_COMMENTS"

                            Column.ColumnType = Type.TaskCommentsTextbox

                        Case "colDUE_DATE_COMMENTS"

                            Column.ColumnType = Type.DueDateComments

                        Case "colREV_DATE_COMMENTS"

                            Column.ColumnType = Type.RevisionComments

                        Case "colPOSTED_HOURS"

                            Column.ColumnType = Type.PostedHours

                        Case "colPERC_COMPLETE"

                            Column.ColumnType = Type.PercentComplete

                        Case "ColumnDocuments"

                            Column.ColumnType = Type.TaskDocuments

                        Case "colEMP_CODE_TEXT_AUTO"

                            Column.ColumnType = Type.EmployeesAutoComplete

                        Case "GridTemplateColumnInputPreds"

                            Column.ColumnType = Type.PredecessorsTextbox

                        Case "JobOrder"

                            Column.ColumnType = Type.JobOrder

                        Case "Linked"

                            Column.ColumnType = Type.Linked

                        Case "SelectPreds"

                            Column.ColumnType = Type.SelectPreds

                        Case "Priority"

                            Column.ColumnType = Type.Priority

                    End Select

                    Columns.Add(Column)

                Next

                Return Columns

            End Function
            Public Sub New()

            End Sub

        End Class

        Public Class AgencySetting

            Public Property IsScheduleCalculationLocked As Boolean
            Public Property Assignment1Label As String
            Public Property Assignment2Label As String
            Public Property Assignment3Label As String
            Public Property Assignment4Label As String
            Public Property Assignment5Label As String
            Public Property ProjectManagerColumn As String

            Public Function ProjectManagerLabel(ByVal AgencySettingCode As AgencySettingCodes) As String

                'objects
                Dim Marker As String = ""

                If Not String.IsNullOrWhiteSpace(Me.ProjectManagerColumn) Then

                    If ProjectManagerColumn = AdvantageFramework.EnumUtilities.LoadEnumObject(AgencySettingCode).Code Then

                        Marker = "(Manager)"

                    End If

                End If

                Return Marker

            End Function

            Public Sub New()



            End Sub

        End Class

        Public Class UserSetting

            Public Property SortString As String
            Public Property IncludeCompletedTasks As Boolean

            Public Sub New()

            End Sub

        End Class

#End Region

    End Class

End Namespace
