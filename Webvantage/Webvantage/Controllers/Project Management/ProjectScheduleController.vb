Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Web.Mvc
Imports Webvantage.ViewModels
Imports Kendo.Mvc.Extensions
Imports MvcCodeRouting.Web.Mvc
Imports Webvantage.Controllers
Imports System.Data.SqlClient
Imports AdvantageFramework.ProjectSchedule.Classes
Imports System.Diagnostics

Namespace Controllers.ProjectManagement

    Public Class TasksToDelete
        Property JobNumber As Integer
        Property JobComponentNumber As Short
        Property SequenceNumber As Short
    End Class

    Public Class ProjectScheduleController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "ProjectManagement/ProjectSchedule/"
        Public Const CopyToProjectSchedules_GridJobComponents As String = "CopyToProjectSchedules_GridJobComponents"
        Private Const AutoAlertTaskEmployeesSessionKey As String = "63Tq2K4YJaX2Qf"
        Private Const CompleteScheduleOnLastTaskCompleteSessionKey As String = "4Et5w5atoro7Lz"
        Private Const LockDateSessionKey As String = "HT2QrGUna7qbEWkcK!m"

#End Region

#Region " Views "

        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule")>
        Public Function Index(<FromRoute()> JobNumber As Integer, <FromRoute()> JobComponentNumber As Short) As ActionResult

            'objects
            Dim Schedule As AdvantageFramework.ProjectSchedule.Classes.Schedule = Nothing

            Schedule = New AdvantageFramework.ProjectSchedule.Classes.Schedule(Me.SecuritySession)

            LoadScheduleQueryStringVars(Schedule)

            With Schedule

                .JobNumber = JobNumber
                .JobComponentNumber = JobComponentNumber
                .IsClientPortal = Webvantage.MiscFN.IsClientPortal()

            End With

            Schedule.Load()

            Return View(Schedule)

        End Function
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule")>
        <MvcCodeRouting.Web.Mvc.CustomRoute("~/ProjectManagement_ProjectSchedule_EditView")>
        Public Function EditView(ByVal OfficeCode As String,
                                 ByVal ClientCode As String,
                                 ByVal DivisionCode As String,
                                 ByVal ProductCode As String,
                                 ByVal SalesClassCode As String,
                                 ByVal Campaign As Integer?,
                                 ByVal JobNumber As Integer,
                                 ByVal ComponentNumber As Short,
                                 ByVal AccountExecutiveCode As String,
                                 ByVal JobTypeCode As String,
                                 ByVal StatusCode As String,
                                 ByVal ProjectManagerCode As String,
                                 ByVal PhaseCode As String,
                                 ByVal EmployeeCode As String,
                                 ByVal TaskCode As String,
                                 ByVal RoleCode As String,
                                 ByVal ExcludeCompletedSchedules As Boolean,
                                 ByVal OnlyPendingTasks As Boolean,
                                 ByVal ExcludeProjectedTasks As Boolean,
                                 ByVal IncludeCompletedTasks As Boolean,
                                 ByVal OnlyScheduleTemplates As Boolean,
                                 ByVal CutoffDate As Date?) As ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New Webvantage.ViewModels.AureliaModel

            AureliaModel.App = "modules/project-management/project-schedule/edit-view"

            AureliaModel.Parameters.Add("OfficeCode", OfficeCode)
            AureliaModel.Parameters.Add("ClientCode", ClientCode)
            AureliaModel.Parameters.Add("DivisionCode", DivisionCode)
            AureliaModel.Parameters.Add("ProductCode", ProductCode)
            AureliaModel.Parameters.Add("SalesClassCode", SalesClassCode)
            AureliaModel.Parameters.Add("CampaignID", Campaign)
            AureliaModel.Parameters.Add("JobNumber", JobNumber)
            AureliaModel.Parameters.Add("ComponentNumber", ComponentNumber)
            AureliaModel.Parameters.Add("AccountExecutiveCode", AccountExecutiveCode)
            AureliaModel.Parameters.Add("JobTypeCode", JobTypeCode)
            AureliaModel.Parameters.Add("StatusCode", StatusCode)
            AureliaModel.Parameters.Add("ProjectManagerCode", ProjectManagerCode)
            AureliaModel.Parameters.Add("PhaseCode", PhaseCode)
            AureliaModel.Parameters.Add("EmployeeCode", EmployeeCode)
            AureliaModel.Parameters.Add("TaskCode", TaskCode)
            AureliaModel.Parameters.Add("RoleCode", RoleCode)
            AureliaModel.Parameters.Add("ExcludeCompletedSchedules", ExcludeCompletedSchedules)
            AureliaModel.Parameters.Add("OnlyPendingTasks", OnlyPendingTasks)
            AureliaModel.Parameters.Add("ExcludeProjectedTasks", ExcludeProjectedTasks)
            AureliaModel.Parameters.Add("IncludeCompletedTasks", IncludeCompletedTasks)
            AureliaModel.Parameters.Add("OnlyScheduleTemplates", OnlyScheduleTemplates)
            AureliaModel.Parameters.Add("CutoffDate", CutoffDate)

            EditView = Aurelia(AureliaModel)

        End Function
        Public Function ProjectScheduleDetail(<FromRoute()> JobNumber As Integer, <FromRoute()> JobComponentNumber As Short) As ActionResult

            Dim Schedule As AdvantageFramework.ViewModels.ProjectSchedule.Schedule = Nothing

            Schedule = New AdvantageFramework.ViewModels.ProjectSchedule.Schedule(Me.SecuritySession)

            'LoadScheduleQueryStringVars(Schedule)

            'With Schedule

            '    .JobNumber = JobNumber
            '    .JobComponentNumber = JobComponentNumber
            '    .IsClientPortal = Webvantage.MiscFN.IsClientPortal()

            'End With

            Schedule.IsClientPortal = Webvantage.MiscFN.IsClientPortal()

            Schedule.Load(JobNumber, JobComponentNumber)

            Return View(Schedule)
        End Function

        'Public Function ProjectScheduleGantt(<FromRoute()> JobNumber As Integer, <FromRoute()> JobComponentNumber As Short) As ActionResult

        '    Dim Schedule As AdvantageFramework.ViewModels.ProjectSchedule.Schedule = Nothing

        '    Schedule = New AdvantageFramework.ViewModels.ProjectSchedule.Schedule(Me.SecuritySession)

        '    'LoadScheduleQueryStringVars(Schedule)

        '    'With Schedule

        '    '    .JobNumber = JobNumber
        '    '    .JobComponentNumber = JobComponentNumber
        '    '    .IsClientPortal = Webvantage.MiscFN.IsClientPortal()

        '    'End With

        '    Schedule.Load(JobNumber, JobComponentNumber)

        '    Return View(Schedule)
        'End Function

        Public Function Setup() As ActionResult

            'objects
            Dim SetupModel As Object = Nothing
            Dim AppVars As Webvantage.cAppVars = Nothing
            AppVars = New cAppVars(cAppVars.Application.PROJECT_SCHEDULE)
            AppVars.getAllAppVars()

            SetupModel = New With {
                      .DisablePaging = AppVars.getAppVar("DisablePaging", "Boolean", "False"),
                      .CopyEmployees = CBool(AppVars.getAppVar("CopyEmployees", "Boolean", "False")),
                      .PredecessorDefault = (CInt(AppVars.getAppVar("SCHEDULE_CALC", "Integer", "1")) = 1),
                      .LockedColumns = CInt(AppVars.getAppVar("LockedColumns", "Integer", "0"))
                  }

            Return View(SetupModel)

        End Function
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule")>
        Public Function Create(Optional ClientCode As String = Nothing, Optional DivisionCode As String = Nothing, Optional ProductCode As String = Nothing,
                                   Optional JobNumber As Integer? = Nothing, Optional JobComponentNumber As Short? = Nothing) As ActionResult

            'objects
            Dim InitValues As Object = Nothing
            Dim TrafficStatus As String = Nothing
            Dim ProjectManagerLabel As String = Nothing
            Dim Schedule As AdvantageFramework.ProjectSchedule.Classes.Schedule = Nothing
            Dim ClientName As String = Nothing
            Dim DivisionName As String = Nothing
            Dim ProductName As String = Nothing
            Dim JobDescription As String = Nothing
            Dim JobComponentDescription As String = Nothing

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                TrafficStatus = AdvantageFramework.ProjectSchedule.LoadDefaultStatus(DataContext)
                ProjectManagerLabel = AdvantageFramework.ProjectSchedule.LoadProjectScheduleManagerLabel(DataContext)

            End Using

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                If JobNumber.GetValueOrDefault(0) > 0 AndAlso JobComponentNumber.GetValueOrDefault(0) > 0 Then

                    With AdvantageFramework.Database.Procedures.JobComponentView.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                        ClientCode = .ClientCode
                        ClientName = .ClientName
                        DivisionCode = .DivisionCode
                        DivisionName = .DivisionName
                        ProductCode = .ProductCode
                        ProductName = .ProductDescription
                        JobDescription = .JobDescription
                        JobComponentDescription = .JobComponentDescription

                    End With

                ElseIf JobNumber.GetValueOrDefault(0) > 0 Then

                    With AdvantageFramework.Database.Procedures.JobView.LoadByJobNumber(DbContext, JobNumber)

                        ClientCode = .ClientCode
                        ClientName = .ClientName
                        DivisionCode = .DivisionCode
                        DivisionName = .DivisionName
                        ProductCode = .ProductCode
                        ProductName = .ProductDescription
                        JobDescription = .JobDescription

                    End With

                ElseIf Not String.IsNullOrWhiteSpace(ClientCode) AndAlso Not String.IsNullOrWhiteSpace(DivisionCode) AndAlso Not String.IsNullOrWhiteSpace(ProductCode) Then

                    With AdvantageFramework.Database.Procedures.ProductView.Load(DbContext).Where(Function(p) p.ClientCode = ClientCode AndAlso p.DivisionCode = DivisionCode AndAlso p.ProductCode = ProductCode).SingleOrDefault

                        ClientCode = .ClientCode
                        ClientName = .ClientName
                        DivisionCode = .DivisionCode
                        DivisionName = .DivisionName
                        ProductName = .ProductDescription

                    End With

                ElseIf Not String.IsNullOrWhiteSpace(ClientCode) AndAlso Not String.IsNullOrWhiteSpace(DivisionCode) Then

                    With AdvantageFramework.Database.Procedures.DivisionView.Load(DbContext).Where(Function(d) d.ClientCode = ClientCode AndAlso d.DivisionCode = DivisionCode).SingleOrDefault

                        ClientCode = .ClientCode
                        ClientName = .ClientName
                        DivisionName = .DivisionName

                    End With

                ElseIf Not String.IsNullOrWhiteSpace(ClientCode) Then

                    With AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ClientCode)

                        ClientName = .Name

                    End With

                End If

            End Using

            Schedule = New AdvantageFramework.ProjectSchedule.Classes.Schedule()

            With Schedule

                Schedule.ClientCode = ClientCode
                Schedule.DivisionCode = DivisionCode
                Schedule.ProductCode = ProductCode
                Schedule.JobNumber = JobNumber.GetValueOrDefault(0)
                Schedule.JobComponentNumber = JobComponentNumber.GetValueOrDefault(0)
                Schedule.JobTraffic = New AdvantageFramework.Database.Entities.JobTraffic
                Schedule.JobTraffic.TrafficCode = TrafficStatus
                Schedule.IsJobDashboard = (New AdvantageFramework.Web.QueryString()).FromCurrent.IsJobDashboard

            End With

            ViewData("ProjectManagerLabel") = ProjectManagerLabel
            ViewData("ClientName") = ClientName
            ViewData("DivisionName") = DivisionName
            ViewData("ProductName") = ProductName
            ViewData("JobDescription") = JobDescription
            ViewData("JobComponentDescription") = JobComponentDescription

            Return View(Schedule)

        End Function
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule", CheckCanUpdate:=True)>
        Public Function QuickEdit(JobNumber As Integer, JobComponentNumber As Short) As ActionResult

            'objects
            Dim Schedule As AdvantageFramework.ProjectSchedule.Classes.Schedule = Nothing

            Schedule = New AdvantageFramework.ProjectSchedule.Classes.Schedule(Me.SecuritySession)

            LoadScheduleQueryStringVars(Schedule)

            With Schedule

                .JobNumber = JobNumber
                .JobComponentNumber = JobComponentNumber
                .IsClientPortal = Webvantage.MiscFN.IsClientPortal()
                .IsQuickEdit = True

            End With

            Schedule.Load()

            Return View(Schedule)

        End Function
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule")>
        Public Function CopyToProjectSchedules(JobNumber As Integer, JobComponentNumber As Short, JobTypeCode As String) As ActionResult

            'objects
            Dim CopyToProjectScheduleViewModel As AdvantageFramework.ViewModels.ProjectSchedule.CopyToProjectScheduleViewModel = Nothing

            CopyToProjectScheduleViewModel = New AdvantageFramework.ViewModels.ProjectSchedule.CopyToProjectScheduleViewModel

            CopyToProjectScheduleViewModel.JobNumber = JobNumber
            CopyToProjectScheduleViewModel.JobComponentNumber = JobComponentNumber
            CopyToProjectScheduleViewModel.JobTypeCode = JobTypeCode

            PopulateCopyToProjectScheduleViewModel(CopyToProjectScheduleViewModel)

            Return View(CopyToProjectScheduleViewModel)

        End Function










        <System.Web.Mvc.HttpPost()>
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule")>
        Public Function CopyToProjectSchedules(CopyToProjectScheduleViewModel As AdvantageFramework.ViewModels.ProjectSchedule.CopyToProjectScheduleViewModel) As ActionResult

            'objects
            Dim SelectedJobComponentIDs As Generic.List(Of Integer) = Nothing

            CopyToProjectScheduleViewModel.IsValid = True

            If CopyToProjectScheduleViewModel.JobComponents.Any(Function(Entity) Entity.Selected = True) = False Then

                CopyToProjectScheduleViewModel.IsValid = False

                ModelState.AddModelError("", "Please select at least one job component.")

            End If

            If CopyToProjectScheduleViewModel.AddScheduleIfScheduleDoesntExist = False AndAlso
                          CopyToProjectScheduleViewModel.UpdateScheduleIfExists = False AndAlso
                          CopyToProjectScheduleViewModel.UpdateComponentBudget = False Then

                CopyToProjectScheduleViewModel.IsValid = False

                ModelState.AddModelError("", "Please select at least one add or update option.")

            End If

            If CopyToProjectScheduleViewModel.IncludeScheduleHeaderData = False AndAlso
                          CopyToProjectScheduleViewModel.IncludeScheduleDetailData = False AndAlso
                          CopyToProjectScheduleViewModel.UpdateComponentBudget = False Then

                CopyToProjectScheduleViewModel.IsValid = False

                ModelState.AddModelError("", "Please select at least one header or detail option.")

            End If

            If CopyToProjectScheduleViewModel.IsValid Then

                SelectedJobComponentIDs = CopyToProjectScheduleViewModel.JobComponents.Where(Function(Entity) Entity.Selected = True).Select(Function(Entity) Entity.ID).ToList

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim SqlParameters As New List(Of SqlParameter)

                    SqlParameters.Add(New SqlParameter("@JOB_NUMBER", CopyToProjectScheduleViewModel.JobNumber))
                    SqlParameters.Add(New SqlParameter("@JOB_COMPONENT_NBR", CopyToProjectScheduleViewModel.JobComponentNumber))
                    SqlParameters.Add(New SqlParameter("@SELECTED_JOB_COMPONENT_IDs", Join(SelectedJobComponentIDs.Select(Function(JCID) JCID.ToString).ToArray, ",")))
                    SqlParameters.Add(New SqlParameter("@ADD_SCHEDULE_IF_SCHEDULE_DOESNT_EXIST", If(CopyToProjectScheduleViewModel.AddScheduleIfScheduleDoesntExist, 1, 0)))
                    SqlParameters.Add(New SqlParameter("@UPDATE_SCHEDULE_IF_EXIST", If(CopyToProjectScheduleViewModel.UpdateScheduleIfExists, 1, 0)))
                    SqlParameters.Add(New SqlParameter("@INCLUDE_SCHEDULE_HEADER_DATA", If(CopyToProjectScheduleViewModel.IncludeScheduleHeaderData, 1, 0)))
                    SqlParameters.Add(New SqlParameter("@INCLUDE_SCHEDULE_DETAIL_DATA", If(CopyToProjectScheduleViewModel.IncludeScheduleDetailData, 1, 0)))
                    SqlParameters.Add(New SqlParameter("@INCLUDE_SCHEDULE_DETAIL_SCHEDULE_DATES", If(CopyToProjectScheduleViewModel.IncludeScheduleDetailScheduleDates, 1, 0)))
                    SqlParameters.Add(New SqlParameter("@INCLUDE_SCHEDULE_DETAIL_EMPLOYEE_ASSIGNMENTS", If(CopyToProjectScheduleViewModel.IncludeScheduleDetailEmployeeAssignments, 1, 0)))
                    SqlParameters.Add(New SqlParameter("@INCLUDE_SCHEDULE_DETAIL_TASK_COMMENTS", If(CopyToProjectScheduleViewModel.IncludeScheduleDetailTaskComments, 1, 0)))
                    SqlParameters.Add(New SqlParameter("@INCLUDE_SCHEDULE_DETAIL_DUE_DATE_COMMENTS", If(CopyToProjectScheduleViewModel.IncludeScheduleDetailDueDateComments, 1, 0)))
                    SqlParameters.Add(New SqlParameter("@INCLUDE_SCHEDULE_DETAIL_REVISION_COMMENTS", If(CopyToProjectScheduleViewModel.IncludeScheduleRevsionComments, 1, 0)))
                    SqlParameters.Add(New SqlParameter("@UPDATE_COMPONENT_BUDGET", If(CopyToProjectScheduleViewModel.UpdateComponentBudget, 1, 0)))
                    SqlParameters.Add(New SqlParameter("@USER_CODE", Me.SecuritySession.UserCode))

                    'Dim s As String = "@JOB_NUMBER, @JOB_COMPONENT_NBR, @SELECTED_JOB_COMPONENT_IDs, @ADD_SCHEDULE_IF_SCHEDULE_DOESNT_EXIST, @UPDATE_SCHEDULE_IF_EXIST, @INCLUDE_SCHEDULE_HEADER_DATA, @INCLUDE_SCHEDULE_DETAIL_DATA, @INCLUDE_SCHEDULE_DETAIL_SCHEDULE_DATES, @INCLUDE_SCHEDULE_DETAIL_EMPLOYEE_ASSIGNMENTS, @INCLUDE_SCHEDULE_DETAIL_TASK_COMMENTS, @INCLUDE_SCHEDULE_DETAIL_DUE_DATE_COMMENTS, @INCLUDE_SCHEDULE_DETAIL_REVISION_COMMENTS, @UPDATE_COMPONENT_BUDGET, @USER_CODE"

                    DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_Traffic_Schedule_CopyToJobComponents] @JOB_NUMBER, @JOB_COMPONENT_NBR, @SELECTED_JOB_COMPONENT_IDs, @ADD_SCHEDULE_IF_SCHEDULE_DOESNT_EXIST, @UPDATE_SCHEDULE_IF_EXIST, @INCLUDE_SCHEDULE_HEADER_DATA, @INCLUDE_SCHEDULE_DETAIL_DATA, @INCLUDE_SCHEDULE_DETAIL_SCHEDULE_DATES, @INCLUDE_SCHEDULE_DETAIL_EMPLOYEE_ASSIGNMENTS, @INCLUDE_SCHEDULE_DETAIL_TASK_COMMENTS, @INCLUDE_SCHEDULE_DETAIL_DUE_DATE_COMMENTS, @INCLUDE_SCHEDULE_DETAIL_REVISION_COMMENTS, @UPDATE_COMPONENT_BUDGET, @USER_CODE;", SqlParameters.ToArray)
                    'DbContext.Database.ExecuteSqlCommand("EXEC dbo.usp_wv_Traffic_Schedule_CopyToJobComponents " &
                    '                                     CopyToProjectScheduleViewModel.JobNumber & ", " &
                    '                                    CopyToProjectScheduleViewModel.JobComponentNumber & ", '" &
                    '                                    Join(SelectedJobComponentIDs.Select(Function(JCID) JCID.ToString).ToArray, ",") & "', " &
                    '                                    If(CopyToProjectScheduleViewModel.AddScheduleIfScheduleDoesntExist, 1, 0) & ", " &
                    '                                    If(CopyToProjectScheduleViewModel.UpdateScheduleIfExists, 1, 0) & ", " &
                    '                                    If(CopyToProjectScheduleViewModel.IncludeScheduleHeaderData, 1, 0) & ", " &
                    '                                    If(CopyToProjectScheduleViewModel.IncludeScheduleDetailData, 1, 0) & ", " &
                    '                                    If(CopyToProjectScheduleViewModel.IncludeScheduleDetailScheduleDates, 1, 0) & ", " &
                    '                                    If(CopyToProjectScheduleViewModel.IncludeScheduleDetailEmployeeAssignments, 1, 0) & ", " &
                    '                                    If(CopyToProjectScheduleViewModel.IncludeScheduleDetailTaskComments, 1, 0) & ", " &
                    '                                    If(CopyToProjectScheduleViewModel.IncludeScheduleDetailDueDateComments, 1, 0) & ", " &
                    '                                    If(CopyToProjectScheduleViewModel.IncludeScheduleRevsionComments, 1, 0) & ", " &
                    '                                    If(CopyToProjectScheduleViewModel.UpdateComponentBudget, 1, 0), ", '" &
                    '                                    DbContext.UserCode & "';")

                End Using

                Return View(CopyToProjectScheduleViewModel)

            Else

                PopulateCopyToProjectScheduleViewModel(CopyToProjectScheduleViewModel)

                Return View(CopyToProjectScheduleViewModel)

            End If

        End Function
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule")>
        Public Function FindAndReplace(Components As String) As ActionResult

            'objects
            Dim ViewModel As AdvantageFramework.ViewModels.ProjectSchedule.ProjectScheduleFindAndReplaceViewModel = Nothing
            Dim JobComponentViews As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing
            Dim ComponentArray As String() = Nothing

            ViewModel = New AdvantageFramework.ViewModels.ProjectSchedule.ProjectScheduleFindAndReplaceViewModel

            If Components = "ALL" Then

                ComponentArray = Session("TrafficScheduleMVJobs").Split("|")

            Else

                ComponentArray = Components.Split("|")

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                JobComponentViews = (From Item In AdvantageFramework.Database.Procedures.JobComponentView.Load(DbContext)
                                     Select JobNumber = Item.JobNumber,
                                                        JobComponentNumber = Item.JobComponentNumber,
                                                        ClientCode = Item.ClientCode).ToList.Select(Function(jc) New AdvantageFramework.Database.Views.JobComponentView() With {.JobNumber = jc.JobNumber,
                                                                                                                                                                                .JobComponentNumber = jc.JobComponentNumber,
                                                                                                                                                                                .ClientCode = jc.ClientCode}).ToList

                JobComponentViews = (From Item In JobComponentViews
                                     Let Key = Item.JobNumber.ToString & "," & Item.JobComponentNumber.ToString
                                     Join Comp In ComponentArray On Key Equals Comp
                                     Select Item).ToList

                If JobComponentViews.Select(Function(jc) jc.ClientCode).Distinct.Count = 1 Then

                    ViewModel.ClientCode = JobComponentViews.FirstOrDefault.ClientCode

                End If

                ViewModel.SelectedJobComponents = String.Join("|", ComponentArray)

            End Using

            Return View(ViewModel)

        End Function


#Region " -- Partials -- "

        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule")>
        Public Function ScheduleGrid(JobNumber As Integer, JobComponentNumber As Short) As ActionResult

            'objects
            Dim Schedule As AdvantageFramework.ProjectSchedule.Classes.Schedule = Nothing

            Schedule = New AdvantageFramework.ProjectSchedule.Classes.Schedule(Me.SecuritySession)

            With Schedule

                .JobNumber = JobNumber
                .JobComponentNumber = JobComponentNumber
                .IsClientPortal = Webvantage.MiscFN.IsClientPortal()

            End With

            Schedule.Load()

            Return PartialView(Schedule)

        End Function

#End Region

#End Region

#Region " Methods "


        <HttpGet>
        Public Function GetStatuses() As JsonResult

            'objects
            Try
                'Dim dt As DataTable = SqlHelper.ExecuteDataTable(Me.SecuritySession.ConnectionString, CommandType.StoredProcedure, "usp_wv_dd_GetTrafficCodes", "dtTrafficStatusCodes")

                Dim StatusCodes As IEnumerable = Nothing

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    StatusCodes = (From Item In AdvantageFramework.Database.Procedures.Status.LoadAllActive(DbContext)
                                   Select [Code] = Item.Code,
                                                [Description] = Item.Description).ToList

                End Using

                Return Json(StatusCodes, JsonRequestBehavior.AllowGet)

            Catch ex As Exception

            End Try

        End Function

        <HttpPost()>
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule")>
        Public Function SaveScheduleHeader(Model As AdvantageFramework.ProjectSchedule.Classes.Schedule) As JsonResult

            'objects
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim Updated As Boolean = False
            Dim Message As String = ""

            Try

                If Model IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                            JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, Model.JobNumber, Model.JobComponentNumber)

                            If JobTraffic IsNot Nothing Then

                                If Model.JobTraffic IsNot Nothing Then

                                    With Model.JobTraffic

                                        JobTraffic.TrafficComments = .TrafficComments
                                        JobTraffic.DateShipped = .DateShipped
                                        JobTraffic.ReceivedBy = .ReceivedBy
                                        JobTraffic.DateDelivered = .DateDelivered
                                        JobTraffic.Reference = .Reference
                                        JobTraffic.PercentComplete = .PercentComplete
                                        JobTraffic.CompletedDate = .CompletedDate
                                        JobTraffic.IsTemplate = .IsTemplate

                                        If JobTraffic.TrafficCode <> .TrafficCode Then

                                            If Not String.IsNullOrWhiteSpace(.TrafficCode) Then

                                                If AdvantageFramework.Database.Procedures.Status.LoadAllActive(DbContext).Where(Function(s) s.Code = .TrafficCode).Any Then

                                                    JobTraffic.TrafficCode = .TrafficCode

                                                End If

                                            End If

                                        End If

                                        If JobTraffic.Assign1 <> .Assign1 Then

                                            If Not String.IsNullOrWhiteSpace(.Assign1) Then

                                                If AdvantageFramework.ProjectSchedule.ValidateEmployee(Me.SecuritySession, DbContext, SecurityDbContext, .Assign1) Then

                                                    JobTraffic.Assign1 = .Assign1

                                                End If

                                            Else

                                                JobTraffic.Assign1 = Nothing

                                            End If

                                        End If

                                        If JobTraffic.Assign2 <> .Assign2 Then

                                            If Not String.IsNullOrWhiteSpace(.Assign2) Then

                                                If AdvantageFramework.ProjectSchedule.ValidateEmployee(Me.SecuritySession, DbContext, SecurityDbContext, .Assign2) Then

                                                    JobTraffic.Assign2 = .Assign2

                                                End If

                                            Else

                                                JobTraffic.Assign2 = Nothing

                                            End If

                                        End If

                                        If JobTraffic.Assign3 <> .Assign3 Then

                                            If Not String.IsNullOrWhiteSpace(.Assign3) Then

                                                If AdvantageFramework.ProjectSchedule.ValidateEmployee(Me.SecuritySession, DbContext, SecurityDbContext, .Assign3) Then

                                                    JobTraffic.Assign3 = .Assign3

                                                End If

                                            Else

                                                JobTraffic.Assign3 = Nothing

                                            End If

                                        End If

                                        If JobTraffic.Assign4 <> .Assign4 Then

                                            If Not String.IsNullOrWhiteSpace(.Assign4) Then

                                                If AdvantageFramework.ProjectSchedule.ValidateEmployee(Me.SecuritySession, DbContext, SecurityDbContext, .Assign4) Then

                                                    JobTraffic.Assign4 = .Assign4

                                                End If

                                            Else

                                                JobTraffic.Assign4 = Nothing

                                            End If

                                        End If

                                        If JobTraffic.Assign5 <> .Assign5 Then

                                            If Not String.IsNullOrWhiteSpace(.Assign5) Then

                                                If AdvantageFramework.ProjectSchedule.ValidateEmployee(Me.SecuritySession, DbContext, SecurityDbContext, .Assign5) Then

                                                    JobTraffic.Assign5 = .Assign5

                                                End If

                                            Else

                                                JobTraffic.Assign5 = Nothing

                                            End If

                                        End If

                                    End With

                                    AdvantageFramework.Database.Procedures.JobTraffic.Update(DbContext, JobTraffic)

                                End If

                            End If

                            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Model.JobNumber, Model.JobComponentNumber)

                            If JobComponent IsNot Nothing Then

                                If Model.JobTraffic.JobComponent IsNot Nothing Then

                                    With Model.JobTraffic.JobComponent

                                        JobComponent.StartDate = .StartDate
                                        JobComponent.DueDate = .DueDate
                                        JobComponent.TrafficScheduleBy = .TrafficScheduleBy

                                    End With

                                    AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent)

                                End If

                            End If

                        End Using

                    End Using

                    Updated = True

                End If

            Catch ex As Exception
                Message = ex.Message
                Updated = False
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Updated, Message, Nothing))

        End Function
        <AcceptVerbs("POST", "DELETE")>
        Public Function DeleteScheduleTasks(Tasks As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)) As ActionResult

            'objects
            Dim Message As String = ""

            If Tasks IsNot Nothing AndAlso Tasks.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    DeleteTasks(DbContext, Tasks.First.JobNumber, Tasks.First.JobComponentNumber, Tasks.Select(Function(t) t.SequenceNumber).ToArray, Message)

                End Using

            End If

            Return Json(New With {.Tasks = Tasks, .Message = Message})

        End Function
        'Optional ByVal JobNumber As Integer = 0, Optional ByVal JobComponentNumber As Short = 0, Optional ByVal SequenceNumber As Short = 0
        <AcceptVerbs("POST", "DELETE", "GET", "PUT")>
        Public Function DeleteTask(Tasks As List(Of TasksToDelete)) As ActionResult

            'objects
            Dim Message As String = ""

            Debug.Write(Request)


            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                For Each Task As TasksToDelete In Tasks

                    DeleteTask(DbContext, Task.JobNumber, Task.JobComponentNumber, Task.SequenceNumber, Message)

                Next

            End Using

            Return MaxJson(New With {.Message = Message}, JsonRequestBehavior.AllowGet)

        End Function

        <AcceptVerbs("POST", "DELETE")>
        Public Function DeleteScheduleTask(ByVal Task As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) As ActionResult

            'objects
            Dim Message As String = ""

            If Task IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    DeleteTask(DbContext, Task.JobNumber, Task.JobComponentNumber, Task.SequenceNumber, Message)

                End Using

            End If

            Return Json(New With {.Task = Task, .Message = Message})

        End Function
        <AcceptVerbs("POST")>
        Public Function ChangeScheduleCalculation(JobNumber As Integer, JobComponentNumber As Short, CalculateByPredecessor As Boolean) As JsonResult

            'objects
            Dim Schedule As Webvantage.cSchedule = Nothing
            Dim ErrorMessage As String = ""

            Schedule = New Webvantage.cSchedule(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

            ErrorMessage = Schedule.UpdateScheduleDetailCalculate(JobNumber, JobComponentNumber, If(CalculateByPredecessor, 1, 0))

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(String.IsNullOrWhiteSpace(ErrorMessage), ErrorMessage))

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateScheduleStatus(JobNumber As Integer, JobComponentNumber As Integer) As JsonResult

            'objects
            Dim Schedule As Webvantage.cSchedule = Nothing
            Dim ErrorMessage As String = ""
            Dim Updated As Boolean = False

            If MiscFN.IsClientPortal = False Then

                Try

                    Schedule = New Webvantage.cSchedule

                    Updated = Schedule.UpdateScheduleStatus(JobNumber, JobComponentNumber, True, ErrorMessage)

                Catch ex As Exception

                End Try

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Updated, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("POST")>
        Public Function LinkItem(JobNumber As Integer, JobComponentNumber As Short, SequenceNumber As Integer, Linked As Boolean, Optional LinkToSequenceNumber As Integer = -1) As JsonResult

            'objects
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim Updated As Boolean = False
            Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
            Dim ErrorMessage As String = ""

            If MiscFN.IsClientPortal = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Updated = AdvantageFramework.ProjectSchedule.LinkTasks(DbContext, JobNumber, JobComponentNumber, SequenceNumber, LinkToSequenceNumber, Linked, ErrorMessage)

                    ScheduleTask = AdvantageFramework.ProjectSchedule.GetScheduleTasks(DbContext, JobNumber, JobComponentNumber, "", Me.SecuritySession.UserCode, "", "", "", True, False, False, "", "", False, True, True, True, SequenceNumber).FirstOrDefault

                End Using

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Updated, ErrorMessage, ScheduleTask))

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateOrder(JobNumber As Integer, JobComponentNumber As Short, Items As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)) As JsonResult

            'objects
            Dim ParentTaskSequenceNumber As Integer? = Nothing
            Dim ItemData As String() = Nothing
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim Schedule As Webvantage.cSchedule = Nothing
            Dim Updated As Boolean = False
            Dim JobComponentTasks As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTask) = Nothing
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

            If MiscFN.IsClientPortal = False Then

                StringBuilder = New Text.StringBuilder

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    JobComponentTasks = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber).ToList

                    For Each Item In Items

                        JobComponentTask = JobComponentTasks.Where(Function(jct) jct.SequenceNumber = Item.SequenceNumber).SingleOrDefault

                        If Item.ParentTaskSequenceNumber.HasValue Then

                            If Item.ParentTaskSequenceNumber = -1 Then

                                Item.ParentTaskSequenceNumber = Nothing

                            End If

                            If JobComponentTask.ParentTaskSequenceNumber.GetValueOrDefault(-1) <> Item.ParentTaskSequenceNumber.GetValueOrDefault(-1) AndAlso JobComponentTask.SequenceNumber <> Item.ParentTaskSequenceNumber.GetValueOrDefault(-1) Then

                                If Schedule Is Nothing Then

                                    Schedule = New Webvantage.cSchedule(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                                End If

                                Try

                                    Schedule.MoveTaskHierarchy(JobNumber, JobComponentNumber, Item.SequenceNumber, Item.ParentTaskSequenceNumber)

                                Catch ex As Exception

                                End Try

                            End If

                        End If

                        StringBuilder.AppendLine(String.Format("UPDATE [dbo].[JOB_TRAFFIC_DET] SET [GRID_ORDER] = {0}, [JOB_ORDER] = {1} WHERE [JOB_NUMBER] = {2} AND [JOB_COMPONENT_NBR] = {3} AND [SEQ_NBR] = {4}; ", Items.IndexOf(Item) + 1, If(Item.JobOrder.HasValue, Item.JobOrder, "NULL"), JobNumber, JobComponentNumber, Item.SequenceNumber))

                    Next

                    Try

                        DbContext.Database.ExecuteSqlCommand(StringBuilder.ToString())

                        Updated = True

                    Catch ex As Exception

                    End Try

                End Using

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Updated))
        End Function

        Function UpdateEmployees(DbContext As AdvantageFramework.Database.DbContext,
                                 ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) As String
            Dim Emps As String()
            Dim EmpsList As Generic.List(Of String) = Nothing

            If String.IsNullOrWhiteSpace(ScheduleTask.EmployeeCode) = False Then

                If ScheduleTask.EmployeeCode.Contains(",") = True Then

                    Emps = MiscFN.CleanStringForSplit(ScheduleTask.EmployeeCode, ",").Split(",")
                    EmpsList = Emps.ToList

                Else

                    EmpsList = New List(Of String)
                    EmpsList.Add(ScheduleTask.EmployeeCode)

                End If

            End If

            If EmpsList Is Nothing Then EmpsList = New List(Of String)

            If EmpsList IsNot Nothing Then

                Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadTaskWorkItem(DbContext,
                                                                                                                  ScheduleTask.JobNumber,
                                                                                                                  ScheduleTask.JobComponentNumber,
                                                                                                                  ScheduleTask.SequenceNumber)

                If Alert IsNot Nothing Then

                    Dim Message As String = String.Empty

                    If AdvantageFramework.AlertSystem.ProcessTaskEmployees(DbContext, Alert, EmpsList, Now, "", Message) = False Then

                        If String.IsNullOrWhiteSpace(Message) = False Then

                            UpdateEmployees = Message

                        End If

                    End If

                End If

            End If

            UpdateEmployees = String.Empty
        End Function

        Public Function UpdateScheduleTask(ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask,
                                                  Optional ShowingClientContacts As Boolean = True, Optional ShowingEmployees As Boolean = True) As Object

            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim DbScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
            Dim LastScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Validator As Webvantage.cValidations = Nothing
            Dim IsValid As Boolean = True
            Dim IsUpdatingDates As Boolean = False
            Dim UpdateAlertDueDates As Boolean = False
            Dim IsUpdatingCompletedDate As Boolean = False
            Dim LegacySchedule As Webvantage.cSchedule = Nothing
            Dim Message As String = ""
            Dim ReturnMessage As String = ""
            Dim AutoAlertTaskEmployees As Boolean = False
            Dim TasksMadeActive As Generic.List(Of Short) = Nothing
            Dim NewCode As String = Nothing
            Dim NewDesc As String = Nothing
            Dim AlertID As Integer = Nothing
            Dim EmployeeCodeString As String = Nothing
            Dim ESO As EmailSessionObject = Nothing
            Dim ReturnObject As Object = Nothing
            Dim Updated As Boolean = False
            Dim ClientContacts As String = ""
            Dim TaskList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)
            Dim IsUpdatingLastTask As Boolean = False
            Dim CompleteScheduleOnLastTaskComplete As Boolean = False
            Dim ScheduleWasCompleted As Boolean = False
            Dim JobIsInOnBoard As Boolean = False
            Dim Assignment As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim IsCompleting As Boolean = False
            Dim IsUnCompleting As Boolean = False
            Dim SbEmps As New System.Text.StringBuilder

            Try

                If ScheduleTask IsNot Nothing Then
                    ReturnObject = New With {.Task = Nothing, .TasksMadeActive = Nothing, .TrafficStatus = Nothing, .ErrorMessage = "", .ScheduleWasCompleted = Nothing, .ScheduleCompletedDate = Nothing}

                    Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)
                        Dim Offset As Decimal = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, Me.SecuritySession.User.EmployeeCode)

                        If Offset < 0 Then

                            If (ScheduleTask.JobRevisedDate IsNot Nothing) Then
                                ScheduleTask.JobRevisedDate = ScheduleTask.JobRevisedDate.Value.AddHours(-Offset)
                            End If
                            If (ScheduleTask.TaskStartDate IsNot Nothing) Then
                                ScheduleTask.TaskStartDate = ScheduleTask.TaskStartDate.Value.AddHours(-Offset)
                            End If
                            If (ScheduleTask.JobCompletedDate IsNot Nothing) Then
                                ScheduleTask.JobCompletedDate = ScheduleTask.JobCompletedDate.Value.AddHours(-Offset)
                            End If

                            If (ScheduleTask.TemporaryCompleteDate IsNot Nothing) Then
                                ScheduleTask.TemporaryCompleteDate = ScheduleTask.TemporaryCompleteDate.Value.AddHours(-Offset)
                            End If

                        Else

                            If (ScheduleTask.JobRevisedDate IsNot Nothing) Then
                                ScheduleTask.JobRevisedDate = ScheduleTask.JobRevisedDate.Value.AddHours(Offset)
                            End If
                            If (ScheduleTask.TaskStartDate IsNot Nothing) Then
                                ScheduleTask.TaskStartDate = ScheduleTask.TaskStartDate.Value.AddHours(Offset)
                            End If
                            If (ScheduleTask.JobCompletedDate IsNot Nothing) Then
                                ScheduleTask.JobCompletedDate = ScheduleTask.JobCompletedDate.Value.AddHours(Offset)
                            End If

                            If (ScheduleTask.TemporaryCompleteDate IsNot Nothing) Then
                                ScheduleTask.TemporaryCompleteDate = ScheduleTask.TemporaryCompleteDate.Value.AddHours(Offset)
                            End If

                        End If


                        TaskList = AdvantageFramework.ProjectSchedule.GetScheduleTasks(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, "", Me.SecuritySession.UserCode, "", "", "", True, False, False, "", "", False, ShowingClientContacts, ShowingEmployees, True, -1).ToList
                        JobIsInOnBoard = AdvantageFramework.ProjectSchedule.JobIsOnBoard(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber)

                        If TaskList IsNot Nothing Then

                            Try
                                If ScheduleTask.JobCompletedDate IsNot Nothing Then

                                    Dim UnCompletedTaskList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)
                                    UnCompletedTaskList = (From Entity In TaskList
                                                           Where Entity.JobCompletedDate Is Nothing).ToList

                                    If UnCompletedTaskList IsNot Nothing Then

                                        For Each UncompleteTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask In UnCompletedTaskList

                                            If UncompleteTask.SequenceNumber = ScheduleTask.SequenceNumber Then 'Completing last task

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
                            End Try

                            DbScheduleTask = (From Entity In TaskList
                                              Where Entity.SequenceNumber = ScheduleTask.SequenceNumber
                                              Select Entity).FirstOrDefault

                            If DbScheduleTask IsNot Nothing Then

                                If Session(AutoAlertTaskEmployeesSessionKey) Is Nothing OrElse Session(CompleteScheduleOnLastTaskCompleteSessionKey) Is Nothing Then

                                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                                        Try

                                            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.TRF_NXT_TSK_AUTO_EML.ToString)

                                            If Setting IsNot Nothing Then

                                                AutoAlertTaskEmployees = CBool(Setting.Value)

                                            End If

                                        Catch ex As Exception
                                            AutoAlertTaskEmployees = False
                                        End Try

                                        Session(AutoAlertTaskEmployeesSessionKey) = AutoAlertTaskEmployees

                                        Setting = Nothing

                                        Try

                                            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.TRF_CMPLT_ON_LAST.ToString)

                                            If Setting IsNot Nothing Then

                                                CompleteScheduleOnLastTaskComplete = CBool(Setting.Value)

                                            End If

                                        Catch ex As Exception
                                            CompleteScheduleOnLastTaskComplete = False
                                        End Try

                                        Session(CompleteScheduleOnLastTaskCompleteSessionKey) = CompleteScheduleOnLastTaskComplete

                                        Setting = Nothing

                                    End Using

                                Else

                                    AutoAlertTaskEmployees = Session(AutoAlertTaskEmployeesSessionKey)
                                    CompleteScheduleOnLastTaskComplete = Session(CompleteScheduleOnLastTaskCompleteSessionKey)

                                End If

                                LegacySchedule = New cSchedule()
                                TasksMadeActive = New List(Of Short)

                                If Not Integer.Equals(DbScheduleTask.TrafficPhaseID.GetValueOrDefault(0), ScheduleTask.TrafficPhaseID.GetValueOrDefault(0)) Then

                                    If ScheduleTask.TrafficPhaseID.GetValueOrDefault(0) = 0 Then

                                        ScheduleTask.TrafficPhaseID = Nothing
                                        ScheduleTask.PhaseDescription = "[None]"
                                        ScheduleTask.PhaseOrder = Nothing

                                    Else

                                        With AdvantageFramework.Database.Procedures.Phase.LoadByPhaseID(DbContext, ScheduleTask.TrafficPhaseID.GetValueOrDefault(0))

                                            ScheduleTask.PhaseDescription = .Description
                                            ScheduleTask.PhaseOrder = .OrderNumber

                                        End With

                                    End If

                                End If

                                If Not String.Equals(DbScheduleTask.TaskCode, ScheduleTask.TaskCode) Then

                                    If Not String.IsNullOrWhiteSpace(ScheduleTask.TaskCode) Then

                                        Validator = New cValidations(Me.SecuritySession.ConnectionString)

                                        If Not Validator.ValidateTaskCode(ScheduleTask.TaskCode.Trim) Then

                                            IsValid = False
                                            ReturnMessage = "Please enter a valid task code."

                                        Else

                                            ScheduleTask.TaskCode = ScheduleTask.TaskCode.Trim
                                            ScheduleTask.TaskDescription = AdvantageFramework.Database.Procedures.Task.LoadByTaskCode(DbContext, ScheduleTask.TaskCode).Description
                                            DbScheduleTask.TaskDescription = ScheduleTask.TaskDescription 'prevents from checking against task description in next If statement

                                        End If

                                    Else

                                        ScheduleTask.TaskCode = Nothing

                                    End If

                                End If

                                If Not String.Equals(DbScheduleTask.TaskDescription, ScheduleTask.TaskDescription) Then

                                    With AdvantageFramework.Database.Procedures.Task.Load(DbContext).Where(Function(t) t.Description = ScheduleTask.TaskDescription)

                                        If .Any() Then

                                            ScheduleTask.TaskCode = .FirstOrDefault().Code

                                        Else

                                            ScheduleTask.TaskCode = Nothing

                                        End If

                                    End With

                                End If

                                If Not AreDatesEqual(DbScheduleTask.TaskStartDate, ScheduleTask.TaskStartDate) Then

                                    IsUpdatingDates = True

                                End If

                                If Not AreDatesEqual(DbScheduleTask.JobRevisedDate, ScheduleTask.JobRevisedDate) Then

                                    IsUpdatingDates = True

                                    If SaveDateRevisedData(ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber, 0, Nothing, ScheduleTask.JobRevisedDate) Then

                                        UpdateAlertDueDates = True

                                        If ScheduleTask.JobDueDate.HasValue = False Then

                                            ScheduleTask.JobDueDate = ScheduleTask.JobRevisedDate

                                        End If

                                    End If

                                End If

                                If Not String.Equals(DbScheduleTask.RevisedDueTime, ScheduleTask.RevisedDueTime) Then

                                    SaveDateRevisedData(ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber, 1, ScheduleTask.RevisedDueTime, Nothing)

                                End If

                                '' Task Detail always updates DueTime to match RevisedDueTime...
                                ScheduleTask.DueTime = ScheduleTask.RevisedDueTime

                                If Not AreDatesEqual(DbScheduleTask.JobDueDate, ScheduleTask.JobDueDate) Then

                                    IsUpdatingDates = True

                                End If

                                If Not AreDatesEqual(DbScheduleTask.JobCompletedDate, ScheduleTask.JobCompletedDate) Then

                                    IsUpdatingDates = True
                                    IsUpdatingCompletedDate = True

                                    If DbScheduleTask.JobCompletedDate Is Nothing AndAlso ScheduleTask.JobCompletedDate IsNot Nothing Then

                                        IsCompleting = True

                                    End If
                                    If DbScheduleTask.JobCompletedDate IsNot Nothing AndAlso ScheduleTask.JobCompletedDate Is Nothing Then

                                        IsUnCompleting = True

                                    End If

                                End If

                                If IsUpdatingDates = True Then

                                    If (ScheduleTask.JobRevisedDate IsNot Nothing AndAlso ScheduleTask.TaskStartDate IsNot Nothing) Then

                                        If ScheduleTask.JobRevisedDate.Value.Date < ScheduleTask.TaskStartDate.Value.Date Then

                                            IsValid = False
                                            ReturnMessage = "Due Date must be after Start Date."

                                        End If

                                    End If
                                End If

                                If Not Decimal.Equals(DbScheduleTask.JobHours.GetValueOrDefault(0), ScheduleTask.JobHours.GetValueOrDefault(0)) Then

                                    Message = LegacySchedule.UpdateTaskEmployeeHours(ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber, ScheduleTask.JobHours)

                                    If Not String.IsNullOrWhiteSpace(Message) Then

                                        ReturnMessage = Message

                                    End If

                                End If

                                If Not String.Equals(DbScheduleTask.TaskStatus, ScheduleTask.TaskStatus) Then

                                    If AutoAlertTaskEmployees AndAlso ScheduleTask.TaskStatus = "A" Then

                                        TasksMadeActive.Add(ScheduleTask.SequenceNumber)

                                    End If

                                End If



                                If ShowingClientContacts Then

                                    If String.IsNullOrWhiteSpace(DbScheduleTask.ClientContact) Then

                                        DbScheduleTask.ClientContact = ""

                                    End If

                                    If String.IsNullOrWhiteSpace(ScheduleTask.ClientContact) Then

                                        ScheduleTask.ClientContact = ""

                                    End If

                                    If Not String.Equals(DbScheduleTask.ClientContact, ScheduleTask.ClientContact) Then

                                        Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, ScheduleTask.JobNumber)

                                        If Job IsNot Nothing Then

                                            ClientContacts = String.Join(",", (From Item In MiscFN.CleanStringForSplit(ScheduleTask.ClientContact, ",").Split(",")
                                                                               Let ContactID = LegacySchedule.WVGetContactCodeID(Item, Job.ClientCode, Job.DivisionCode, Job.ProductCode)
                                                                               Where ContactID <> 0 AndAlso
                                                                                    LegacySchedule.WVCheckContactCodeIDScheduleUser(ContactID) = 1 AndAlso
                                                                                    LegacySchedule.WVCheckContactCodeIDInactive(ContactID) = 0 Select ContactID).ToArray)

                                            ReturnMessage = LegacySchedule.UpdateTaskContactListFromString(ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber, ClientContacts)

                                        End If

                                    End If

                                End If
                                If Not String.Equals(ScheduleTask.PredecessorLevelNotation, DbScheduleTask.PredecessorLevelNotation) Then

                                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                                        'clean up existing preds so any that we deleted are removed.
                                        DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.JOB_TRAFFIC_DET_PREDS WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2} ",
                                                                             ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber)
                                    End Using

                                    AdvantageFramework.ProjectSchedule.UpdatePredecessorsByLevelNotation(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber, ScheduleTask.PredecessorLevelNotation, ReturnMessage)

                                    'ElseIf AdvantageFramework.ProjectSchedule.UpdatePredecessorList(DbContext, ScheduleTask, ReturnMessage) Then

                                    'ScheduleTask = AdvantageFramework.ProjectSchedule.GetScheduleTasks(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, "", Me.SecuritySession.UserCode, "", "", "", True, False, False, "", "", False, False, False, True, ScheduleTask.SequenceNumber).FirstOrDefault

                                End If
                                If Not ScheduleTask.DueDateLock = DbScheduleTask.DueDateLock Then

                                    If ScheduleTask.DueDateLock = 1 Then

                                        If Not ScheduleTask.TaskStartDate.HasValue OrElse Not ScheduleTask.JobRevisedDate.HasValue Then

                                            ScheduleTask.DueDateLock = 0
                                            ReturnMessage = "Start date & due date are required to lock a task."

                                        End If

                                    End If

                                End If

                                If IsValid Then

                                    JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber)

                                    If JobComponentTask IsNot Nothing Then

                                        If IsUpdatingCompletedDate = True AndAlso (ScheduleTask.JobCompletedDate Is Nothing AndAlso JobComponentTask.CompletedDate IsNot Nothing) Then

                                            IsUnCompleting = True

                                        End If

                                        With JobComponentTask

                                            .TaskCode = ScheduleTask.TaskCode
                                            .FuctionCode = ScheduleTask.EstimateFunction
                                            .Description = ScheduleTask.TaskDescription
                                            .StartDate = ScheduleTask.TaskStartDate
                                            .OriginalDueDate = ScheduleTask.JobDueDate
                                            .DueDate = ScheduleTask.JobRevisedDate
                                            .IsDueDateLocked = ScheduleTask.DueDateLock
                                            .CompletedDate = ScheduleTask.JobCompletedDate
                                            .OrderNumber = ScheduleTask.JobOrder
                                            .Days = ScheduleTask.JobDays
                                            .Comment = ScheduleTask.FunctionComments
                                            .OriginalDueDateComment = ScheduleTask.DueDateComments
                                            .DueDateComment = ScheduleTask.RevisionDateComments
                                            .Hours = ScheduleTask.JobHours
                                            .OriginalDueTime = ScheduleTask.DueTime
                                            .DueTime = ScheduleTask.RevisedDueTime
                                            .StatusCode = ScheduleTask.TaskStatus
                                            .IsMilestone = ScheduleTask.Milestone
                                            .PhaseID = ScheduleTask.TrafficPhaseID
                                            .GridOrder = ScheduleTask.GridOrder

                                            '.ID = ScheduleTask.ID
                                            '.AltSequenceNumber = ScheduleTask.
                                            .RoleCode = ScheduleTask.TrafficRole
                                            .ParentTaskSequenceNumber = ScheduleTask.ParentTaskSequenceNumber

                                        End With

                                        Updated = AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask)

                                        If Not Updated Then
                                            ReturnObject.ErrorMessage = "Error updating Task"
                                        End If

                                        If ScheduleTask.Priority <> DbScheduleTask.Priority Then
                                            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                                            Alert = AdvantageFramework.Database.Procedures.Alert.LoadTaskWorkItem(DbContext,
                                                                                                                  ScheduleTask.JobNumber,
                                                                                                                  ScheduleTask.JobComponentNumber,
                                                                                                                  ScheduleTask.SequenceNumber)

                                            Alert.PriorityLevel = ScheduleTask.Priority

                                            Using DataContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                                                AdvantageFramework.Database.Procedures.Alert.Update(DataContext, Alert)
                                            End Using



                                        End If

                                        If ScheduleTask.DueTime <> DbScheduleTask.DueTime Then
                                            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                                            Alert = AdvantageFramework.Database.Procedures.Alert.LoadTaskWorkItem(DbContext,
                                                                                                                  ScheduleTask.JobNumber,
                                                                                                                  ScheduleTask.JobComponentNumber,
                                                                                                                  ScheduleTask.SequenceNumber)

                                            Alert.TimeDue = ScheduleTask.DueTime

                                            Using DataContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                                                AdvantageFramework.Database.Procedures.Alert.Update(DataContext, Alert)
                                            End Using



                                        End If

                                        'If IsUncompleting = True Then

                                        '    Try

                                        '        Dim TaskWorkItem As AdvantageFramework.Database.Entities.Alert = Nothing

                                        '        TaskWorkItem = AdvantageFramework.Database.Procedures.Alert.LoadTaskWorkItem(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber)

                                        '        If TaskWorkItem IsNot Nothing Then

                                        '            TaskWorkItem.AssignmentCompleted = False

                                        '            AdvantageFramework.Database.Procedures.Alert.Update(DbContext, TaskWorkItem)

                                        '        End If

                                        '    Catch ex As Exception
                                        '    End Try

                                        'End If

                                    End If

                                    If ShowingEmployees Then

                                        Try

                                            If Not String.Equals(DbScheduleTask.EmployeeCode, ScheduleTask.EmployeeCode) Then
                                                Message = UpdateEmployees(DbContext, ScheduleTask)

                                                If Message <> String.Empty Then
                                                    ReturnMessage = Message
                                                End If
                                            End If

                                        Catch ex As Exception
                                            ReturnObject.ErrorMessage = ex.Message
                                        End Try

                                    End If

                                    If UpdateAlertDueDates Then

                                        LegacySchedule.UpdateTaskAlertsDueDate(JobComponentTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber, ReturnMessage)

                                    End If

                                    If IsUpdatingCompletedDate Then

                                        If JobIsInOnBoard = False Then

                                            TasksMadeActive = LegacySchedule.SetNextTaskActive(JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber, JobComponentTask.SequenceNumber, ReturnMessage).Rows.OfType(Of System.Data.DataRow).Select(Function(dr) CShort(dr("SEQ_NBR"))).ToList

                                        End If

                                        If AdvantageFramework.ProjectSchedule.AutoUpdateTrafficCode(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber, ReturnMessage, NewCode, NewDesc) = False Then

                                            NewDesc = Nothing
                                            NewCode = Nothing

                                        End If

                                    End If

                                    If IsUpdatingDates Then

                                        LegacySchedule.UpdateScheduleHierarchyDates(JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber)

                                    End If

                                    If AutoAlertTaskEmployees = True AndAlso JobIsInOnBoard = False Then

                                        If TasksMadeActive IsNot Nothing AndAlso TasksMadeActive.Any Then

                                            For Each TaskMadeActive In TasksMadeActive

                                                'AlertID = AdvantageFramework.ProjectSchedule.CreateTaskAlert(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber, TaskMadeActive, Me.SecuritySession.User.EmployeeCode, EmployeeCodeString)

                                                Assignment = AdvantageFramework.Database.Procedures.Alert.LoadTaskWorkItem(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber, TaskMadeActive)

                                                If Assignment.ID > 0 Then

                                                    If IsUpdatingCompletedDate Then

                                                        Dim JobCompTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
                                                        JobCompTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber, TaskMadeActive)

                                                        If JobCompTask IsNot Nothing Then
                                                            For Each emp In JobCompTask.JobComponentTaskEmployee
                                                                emp.ReadAlert = Nothing
                                                                AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Update(DbContext, emp)

                                                                SbEmps.Append(emp.EmployeeCode)
                                                                SbEmps.Append(",")

                                                            Next
                                                        End If

                                                    Else

                                                        For Each emp In JobComponentTask.JobComponentTaskEmployee
                                                            emp.ReadAlert = Nothing
                                                            AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Update(DbContext, emp)

                                                            SbEmps.Append(emp.EmployeeCode)
                                                            SbEmps.Append(",")

                                                        Next

                                                    End If

                                                    EmployeeCodeString = AdvantageFramework.StringUtilities.CleanStringForSplit(SbEmps.ToString(), ",")

                                                    ESO = New EmailSessionObject(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode, Me.SecuritySession, Session("WebvantageURL"), Session("ClientPortalURL"))

                                                    With ESO

                                                        .AlertId = Assignment.ID
                                                        .Subject = "[Alert Updated]"
                                                        .EmployeeCodesToSendEmailTo = EmployeeCodeString
                                                        .IsClientPortal = MiscFN.IsClientPortal
                                                        .IncludeOriginator = False
                                                        .InsertEmailBodyAsAlertDescription = False
                                                        .SessionID = Session.SessionID.ToString
                                                        .PhysicalApplicationPath = HttpContext.ApplicationInstance.Request.PhysicalApplicationPath
                                                        .Send()

                                                    End With

                                                    Try

                                                        SignalR.Classes.NotificationHub.NotifyRecipientsAll(Assignment.ID, Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                                                    Catch ex As Exception

                                                    End Try

                                                End If

                                                AlertID = Nothing
                                                EmployeeCodeString = Nothing

                                            Next

                                        End If

                                    End If

                                End If

                                If Updated Then

                                    'If ScheduleTask.TaskCode = Nothing Then

                                    Try

                                        Dim TaskWorkItem As AdvantageFramework.Database.Entities.Alert = Nothing

                                        TaskWorkItem = AdvantageFramework.Database.Procedures.Alert.LoadTaskWorkItem(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber)

                                        If TaskWorkItem IsNot Nothing Then

                                            TaskWorkItem.Subject = ScheduleTask.TaskDescription

                                            Try

                                                If IsCompleting = True Then

                                                    TaskWorkItem.AssignmentCompleted = True

                                                Else

                                                    If IsUnCompleting = True Then

                                                        TaskWorkItem.AssignmentCompleted = Nothing

                                                    End If

                                                End If

                                            Catch ex As Exception
                                                ReturnObject.ErrorMessage = ex.Message
                                            End Try

                                            TaskWorkItem.DueDate = ScheduleTask.JobRevisedDate
                                            TaskWorkItem.StartDate = ScheduleTask.TaskStartDate
                                            TaskWorkItem.HoursAllowed = ScheduleTask.JobHours

                                            AdvantageFramework.Database.Procedures.Alert.Update(DbContext, TaskWorkItem)

                                        End If

                                    Catch ex As Exception
                                        ReturnObject.ErrorMessage = ex.Message
                                    End Try

                                    'End If

                                    Dim FUBAR As String = ScheduleTask.EmployeeName
                                    Dim Alert_Id As Integer = ScheduleTask.AlertId

                                    ScheduleTask = AdvantageFramework.ProjectSchedule.GetScheduleTasks(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, "", Me.SecuritySession.UserCode, "", "", "", True, False, False, "", "", False, True, True, True, ScheduleTask.SequenceNumber).FirstOrDefault
                                    ScheduleTask.EmployeeName = FUBAR
                                    ScheduleTask.AlertId = Alert_Id
                                    ReturnObject.Task = ScheduleTask

                                    If Offset < 0 Then

                                        If (ScheduleTask.JobRevisedDate IsNot Nothing) Then
                                            ScheduleTask.JobRevisedDate = ScheduleTask.JobRevisedDate.Value.AddHours(-Offset)
                                        End If
                                        If (ScheduleTask.TaskStartDate IsNot Nothing) Then
                                            ScheduleTask.TaskStartDate = ScheduleTask.TaskStartDate.Value.AddHours(-Offset)
                                        End If
                                        If (ScheduleTask.JobCompletedDate IsNot Nothing) Then
                                            ScheduleTask.JobCompletedDate = ScheduleTask.JobCompletedDate.Value.AddHours(-Offset)
                                        End If

                                        If (ScheduleTask.TemporaryCompleteDate IsNot Nothing) Then
                                            ScheduleTask.TemporaryCompleteDate = ScheduleTask.TemporaryCompleteDate.Value.AddHours(-Offset)
                                        End If

                                    Else

                                        If (ScheduleTask.JobRevisedDate IsNot Nothing) Then
                                            ScheduleTask.JobRevisedDate = ScheduleTask.JobRevisedDate.Value.AddHours(Offset)
                                        End If
                                        If (ScheduleTask.TaskStartDate IsNot Nothing) Then
                                            ScheduleTask.TaskStartDate = ScheduleTask.TaskStartDate.Value.AddHours(Offset)
                                        End If
                                        If (ScheduleTask.JobCompletedDate IsNot Nothing) Then
                                            ScheduleTask.JobCompletedDate = ScheduleTask.JobCompletedDate.Value.AddHours(Offset)
                                        End If

                                        If (ScheduleTask.TemporaryCompleteDate IsNot Nothing) Then
                                            ScheduleTask.TemporaryCompleteDate = ScheduleTask.TemporaryCompleteDate.Value.AddHours(Offset)
                                        End If

                                    End If
                                    ReturnObject.Task = ScheduleTask
                                End If

                                ReturnObject.ErrorMessage = ReturnMessage
                                ReturnObject.TasksMadeActive = TasksMadeActive
                                ReturnObject.TrafficStatus = New With {.Code = NewCode, .Description = NewDesc}

                                If IsUpdatingCompletedDate = True AndAlso IsUpdatingLastTask = True AndAlso CompleteScheduleOnLastTaskComplete = True Then

                                    Dim TasksCheck As Boolean = False

                                    If ScheduleTask.JobCompletedDate Is Nothing Then

                                        TasksCheck = True

                                    End If

                                    If TasksCheck = False Then

                                        TasksCheck = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumber(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber)
                                                      Where Entity.CompletedDate Is Nothing).Count = 0

                                    End If

                                    If TasksCheck = True Then

                                        Dim Schedule As AdvantageFramework.Database.Entities.JobTraffic = Nothing

                                        Schedule = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber)

                                        If Schedule IsNot Nothing Then

                                            Schedule.CompletedDate = ScheduleTask.JobCompletedDate

                                            If AdvantageFramework.Database.Procedures.JobTraffic.Update(DbContext, Schedule) = True Then

                                                ReturnObject.ScheduleCompletedDate = Schedule.CompletedDate
                                                ScheduleWasCompleted = True

                                            End If

                                        End If

                                    End If

                                End If

                                ReturnObject.ScheduleWasCompleted = ScheduleWasCompleted

                            End If

                        End If

                        AdvantageFramework.ProjectSchedule.CheckToCompleteSchedule(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber)

                    End Using

                End If

            Catch ex As Exception
                ReturnObject.ErrorMessage = "Something went wrong. " + ex.Message
            End Try

            Return ReturnObject

        End Function


        <AcceptVerbs("POST")>
        Public Function UpdateProjectScheduleTask(ScheduleTasks As List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)) As ActionResult
            Dim ReturnObjects As List(Of Object) = New List(Of Object)

            For Each Task In ScheduleTasks
                ReturnObjects.Add(UpdateScheduleTask(Task))
            Next

            Return MaxJson(ReturnObjects, JsonRequestBehavior.AllowGet)

        End Function

        Public Function CreateScheduleTask(ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim AppVars As Webvantage.cAppVars = Nothing
            AppVars = New cAppVars(cAppVars.Application.PROJECT_SCHEDULE)
            AppVars.getAllAppVars()

            Dim CopyEmployees As Boolean = CBool(AppVars.getAppVar("CopyEmployees", "Boolean", "False"))


            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                JobComponentTask = AdvantageFramework.ProjectSchedule.QuickAddTask(DbContext,
                                                                                   ScheduleTask.JobNumber,
                                                                                   ScheduleTask.JobComponentNumber,
                                                                                   ScheduleTask.TaskCode,
                                                                                   ScheduleTask.TaskDescription,
                                                                                   ScheduleTask.JobOrder,
                                                                                   ScheduleTask.GridOrder,
                                                                                   ScheduleTask.ParentTaskSequenceNumber,
                                                                                   ScheduleTask.EstimateFunction)

                If CopyEmployees = True And Not String.IsNullOrEmpty(ScheduleTask.EmployeeCode) Then
                    ScheduleTask.SequenceNumber = JobComponentTask.SequenceNumber
                    UpdateEmployees(DbContext, ScheduleTask)
                End If

                If JobComponentTask IsNot Nothing Then

                    ScheduleTask.SequenceNumber = JobComponentTask.SequenceNumber
                    ScheduleTask = AdvantageFramework.ProjectSchedule.GetScheduleTasks(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, "", Me.SecuritySession.UserCode, "", "", "", True, False, False, "", "", False, False, False, False, ScheduleTask.SequenceNumber).FirstOrDefault

                Else

                    ScheduleTask = Nothing

                End If

            End Using

            Return ScheduleTask

        End Function

        <AcceptVerbs("POST", "PUT")>
        Public Function CreateProjectScheduleTask(ScheduleTasks As List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)) As ActionResult

            Dim NewTasks As List(Of ScheduleTask) = New List(Of ScheduleTask)

            'objects
            For Each task In ScheduleTasks
                NewTasks.Add(CreateScheduleTask(task))
            Next

            Return MaxJson(NewTasks, JsonRequestBehavior.AllowGet)

        End Function

        Private Function GetPredecessors(DbContext As AdvantageFramework.Database.DbContext, JobNumber As Integer, JobComponentNumber As Short, SequenceNumber As Integer) As IEnumerable

            Try

                Return DbContext.Database.SqlQuery(Of String)(String.Format("SELECT
	                                                                                 [LEVEL]
                                                                                 FROM
	                                                                                 dbo.JOB_TRAFFIC_DET_PREDS JTDP JOIN
	                                                                                 dbo.advtf_traffic_schedule_GetHierarchyDates({0}, {1}) HD ON JTDP.JOB_NUMBER = HD.JOB_NUMBER AND
																                                                                                 JTDP.JOB_COMPONENT_NBR = HD.JOB_COMPONENT_NBR AND
																                                                                                 JTDP.PREDECESSOR_SEQ_NBR = HD.SEQ_NBR
                                                                                 WHERE
	                                                                                 JTDP.JOB_NUMBER = {0} AND
	                                                                                 JTDP.JOB_COMPONENT_NBR = {1} AND
	                                                                                 JTDP.SEQ_NBR = {2}", JobNumber, JobComponentNumber, SequenceNumber)).ToList

            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Private Function SaveDateRevisedData(JobNumber As Integer, JobComponentNumber As Short, SequenceNumber As Short, Type As Short, DueTime As String, JobRevisedDate As Date?) As Boolean

            'objects
            Dim SqlParameters As System.Data.SqlClient.SqlParameter() = Nothing
            Dim Saved As Boolean = False

            Try

                If Type = 0 Then

                    DueTime = Nothing

                ElseIf Type = 1 Then

                    JobRevisedDate = Nothing

                Else

                    Return False

                End If

                SqlParameters = {New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int) With {.Value = JobNumber},
                                 New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt) With {.Value = JobComponentNumber},
                                 New System.Data.SqlClient.SqlParameter("@SEQ_NBR", SqlDbType.SmallInt) With {.Value = SequenceNumber},
                                 New System.Data.SqlClient.SqlParameter("@TYPE", SqlDbType.SmallInt) With {.Value = 0},
                                 New System.Data.SqlClient.SqlParameter("@DUE_TIME", SqlDbType.VarChar, 10) With {.Value = If(DueTime.HasValue, DueTime, System.DBNull.Value)},
                                 New System.Data.SqlClient.SqlParameter("@JOB_REVISED_DATE", SqlDbType.SmallDateTime) With {.Value = If(JobRevisedDate.HasValue, JobRevisedDate.Value.Date, System.DBNull.Value)}}

                SqlHelper.ExecuteNonQuery(Me.SecuritySession.ConnectionString, CommandType.StoredProcedure, "usp_wv_JOB_TRAFFIC_DET_SAVE_REVISED_COLS", SqlParameters)
                Saved = True

            Catch ex As Exception

            End Try

            Return Saved

        End Function
        Public Function LoadAvailableEmployees(JobNumber As Integer, JobComponentNumber As Short, Optional SequenceNumber As Short = -1, Optional FilterByTrafficCode As Boolean = False, Optional TrafficCode As String = "", Optional MustIncludeEmployees As String = "") As JsonResult

            'objects
            Dim Schedule As Webvantage.cSchedule = Nothing
            Dim Employees As IEnumerable = Nothing
            Dim EmployeeDictionary As Dictionary(Of String, String) = Nothing
            Dim EmployeeArray As String() = Nothing
            Dim MissingEmployees As String() = Nothing

            Schedule = New cSchedule(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

            EmployeeDictionary = (From Item In Schedule.GetAvailableEmpList(JobNumber, JobComponentNumber, SequenceNumber, FilterByTrafficCode, TrafficCode, Me.SecuritySession.UserCode).Rows.OfType(Of System.Data.DataRow)
                                  Select [EmployeeCode] = CStr(Item("EMPCODE")),
                                   [EmployeeName] = CStr(Item("EMP_NAME"))).ToDictionary(Function(k) k.EmployeeCode, Function(k) k.EmployeeName)

            If Not String.IsNullOrWhiteSpace(MustIncludeEmployees) Then

                MustIncludeEmployees = MustIncludeEmployees.Replace(" ", "")
                EmployeeArray = MustIncludeEmployees.Split(",")

                MissingEmployees = EmployeeArray.Where(Function(e) EmployeeDictionary.ContainsKey(e) = False).ToArray

                If MissingEmployees IsNot Nothing AndAlso MissingEmployees.Count > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Try

                            EmployeeDictionary.AddRange((From Item In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                                         Where MissingEmployees.Contains(Item.Code)
                                                         Select Item).ToList.Select(Function(e) New With {.Code = e.Code, .Name = e.ToString}).ToDictionary(Function(e) e.Code, Function(e) e.Name))

                        Catch ex As Exception

                        End Try

                    End Using

                End If

            End If

            Employees = EmployeeDictionary.Select(Function(i) New With {.EmployeeCode = i.Key, .EmployeeName = i.Value}).ToList

            Return Json(Employees, JsonRequestBehavior.AllowGet)

        End Function
        Public Function ReadProjectScheduleTasks(DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest, JobNumber As Integer, JobComponentNumber As Short,
                                                 SortString As String, EmployeeCode As String, TaskCode As String, RoleCode As String,
                                                 IncludeCompletedTasks As Boolean, IncludeOnlyPendingTasks As Boolean, ExcludeProjectedTasks As Boolean,
                                                 CutOffDate As String, PhaseFilter As String, CalculateByPredecessor As Boolean,
                                                 ShowingClientContacts As Boolean, ShowingEmployees As Boolean) As JsonResult

            'objects
            Dim ScheduleTasks As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
            Dim FilterValue As String = ""
            Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    If AdvantageFramework.ProjectSchedule.Classes.Schedule.IsUsingATaskLevelFilter(PhaseFilter, RoleCode, TaskCode, EmployeeCode, CutOffDate,
                                                                                      IncludeOnlyPendingTasks, ExcludeProjectedTasks, IncludeCompletedTasks) AndAlso Session("PS_Ignore_Filter") = "0" Then

                        ScheduleTasks = AdvantageFramework.ProjectSchedule.GetScheduleTasks(DbContext, JobNumber, JobComponentNumber, SortString, Me.SecuritySession.UserCode, EmployeeCode, TaskCode, RoleCode, IncludeCompletedTasks, IncludeOnlyPendingTasks, ExcludeProjectedTasks, CutOffDate, PhaseFilter, False, ShowingClientContacts, ShowingEmployees, CalculateByPredecessor)

                    Else

                        FilterValue = PhaseFilter

                        If FilterValue = "0" Then

                            FilterValue = "is_null"

                        End If

                        ScheduleTasks = AdvantageFramework.ProjectSchedule.GetScheduleTasks(DbContext, JobNumber, JobComponentNumber, SortString, Me.SecuritySession.UserCode, "", "", "", IncludeCompletedTasks, False, False, "", FilterValue, False, ShowingClientContacts, ShowingEmployees, CalculateByPredecessor)

                    End If

                    Try

                        If ScheduleTasks IsNot Nothing Then

                            AdvantageFramework.ProjectSchedule.CheckForMissingBRDAlertRecords(DbContext, JobNumber, JobComponentNumber, Me.SecuritySession.UserCode)

                        End If

                    Catch ex As Exception
                    End Try

                    DataSourceResult = ScheduleTasks.ToDataSourceResult(DataSourceRequest)

                Catch ex As Exception
                    ScheduleTasks = Nothing
                End Try

            End Using

            Return Json(DataSourceResult, JsonRequestBehavior.AllowGet)

        End Function
        Public Function ReadJobsThatPrecede(JobNumber As Integer, JobComponentNumber As Short) As JsonResult

            'objects
            Dim JobsThatPrecede As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                JobsThatPrecede = (From JobTrfPredecessor In AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber).Include("JobTraffic").ToList
                                   Select [Description] = JobTrfPredecessor.JobPredecessor & "/" & JobTrfPredecessor.JobComponentPredecessor & " - " & AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobTrfPredecessor.JobPredecessor, JobTrfPredecessor.JobComponentPredecessor).Description,
                                          [Code] = JobTrfPredecessor.JobPredecessor & "/" & JobTrfPredecessor.JobComponentPredecessor,
                                          [ID] = JobTrfPredecessor.ID
                                   Order By [Description]).ToList

            End Using

            Return Json(JobsThatPrecede, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("POST")>
        Public Function DestroyJobThatPrecedes(JobNumber As Integer, JobComponentNumber As Short, IDs As Integer()) As JsonResult

            'objects
            Dim JobTrafficPredecessorsToDelete As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
            Dim Deleted As Boolean = False
            Dim Message As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    JobTrafficPredecessorsToDelete = (From Item In AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)
                                                      Where IDs.Contains(Item.ID)
                                                      Select Item).ToList

                    If JobTrafficPredecessorsToDelete IsNot Nothing AndAlso JobTrafficPredecessorsToDelete.Count > 0 Then

                        For Each JobTrafficPredecessorToDelete In JobTrafficPredecessorsToDelete

                            If AdvantageFramework.Database.Procedures.JobTrafficPredecessors.Delete(DbContext, JobTrafficPredecessorToDelete) Then

                                Deleted = True

                            End If

                        Next

                    Else

                        Message = "Selected job(s) that precede could not be deleted."

                    End If

                End Using

            Catch ex As Exception
                Message = ex.Message
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Deleted, Message))

        End Function
        Public Function ReadJobsThatFollow(JobNumber As Integer, JobComponentNumber As Short) As JsonResult

            'objects
            Dim JobsThatFollow As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                JobsThatFollow = (From JobTrfPredecessor In AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, JobNumber, JobComponentNumber).Include("JobTraffic").ToList
                                  Select [Description] = JobTrfPredecessor.JobNumber & "/" & JobTrfPredecessor.JobComponentNumber & " - " & JobTrfPredecessor.JobTraffic.JobComponent.Description,
                                         [Code] = JobTrfPredecessor.JobNumber & "/" & JobTrfPredecessor.JobComponentNumber,
                                         [ID] = JobTrfPredecessor.ID
                                  Order By [Description]).ToList

            End Using

            Return Json(JobsThatFollow, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("POST")>
        Public Function DestroyJobThatFollows(JobNumber As Integer, JobComponentNumber As Short, IDs As Integer()) As JsonResult

            'objects
            Dim JobTrafficPredecessorsToDelete As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
            Dim Deleted As Boolean = False
            Dim Message As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    JobTrafficPredecessorsToDelete = (From Item In AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, JobNumber, JobComponentNumber)
                                                      Where IDs.Contains(Item.ID)
                                                      Select Item).ToList

                    If JobTrafficPredecessorsToDelete IsNot Nothing AndAlso JobTrafficPredecessorsToDelete.Count > 0 Then

                        For Each JobTrafficPredecessorToDelete In JobTrafficPredecessorsToDelete

                            If AdvantageFramework.Database.Procedures.JobTrafficPredecessors.Delete(DbContext, JobTrafficPredecessorToDelete) Then

                                Deleted = True

                            End If

                        Next

                    Else

                        Message = "Selected job(s) that follow could not be deleted."

                    End If

                End Using

            Catch ex As Exception
                Message = ex.Message
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Deleted, Message))

        End Function
        Private Function DeleteTask(DbContext As AdvantageFramework.Database.DbContext, JobNumber As Integer, JobComponentNumber As Short, SequenceNumber As Short, Optional ByRef ErrorMessage As String = "")

            DeleteTask = DeleteTasks(DbContext, JobNumber, JobComponentNumber, {SequenceNumber}, ErrorMessage)

        End Function
        Private Function DeleteTasks(DbContext As AdvantageFramework.Database.DbContext, JobNumber As Integer, JobComponentNumber As Short, SequenceNumbers As Short(), Optional ByRef ErrorMessage As String = "")

            'objects
            Dim Schedule As Webvantage.cSchedule = Nothing
            Dim DocumentIDs As Integer() = Nothing
            Dim AllDocumentIDs As Generic.List(Of Integer) = New Generic.List(Of Integer)
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim DocumentsToDelete As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim CheckForTime As Boolean = False
            Dim CanDeleteTask As Boolean = False


            Schedule = New Webvantage.cSchedule(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

            CheckForTime = DbContext.Database.SqlQuery(Of Boolean)("SELECT CONVERT(BIT, ISNULL(TIME_REQ_ASSN, 0)) FROM dbo.AGENCY").SingleOrDefault()

            For Each SequenceNumber In SequenceNumbers

                CanDeleteTask = True

                If CheckForTime Then

                    If (From Item In AdvantageFramework.Database.Procedures.Alert.Load(DbContext)
                        Join Time In AdvantageFramework.Database.Procedures.EmployeeTimeDetail.Load(DbContext) On Item.ID Equals Time.AlertID
                        Where Item.JobNumber = JobNumber AndAlso
                              Item.JobComponentNumber = JobComponentNumber AndAlso
                              Item.TaskSequenceNumber = SequenceNumber AndAlso
                              (Item.AlertLevel = "BRD" OrElse Item.AlertLevel = "PST")
                        Select Item).Any Then

                        CanDeleteTask = False

                    End If

                End If

                If CanDeleteTask Then

                    Schedule.DeleteTask(JobNumber, JobComponentNumber, SequenceNumber)

                    Try

                        DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.JOB_TRAFFIC_DET_DOCS WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2}", JobNumber, JobComponentNumber, SequenceNumber)).ToArray

                    Catch ex As Exception

                    End Try

                    If DocumentIDs IsNot Nothing AndAlso DocumentIDs.Count > 0 Then

                        AllDocumentIDs.AddRange(DocumentIDs)

                    End If

                Else

                    ErrorMessage = "Tasks with time entered cannot be deleted."

                End If

            Next

            If AllDocumentIDs IsNot Nothing AndAlso AllDocumentIDs.Count > 0 Then

                DocumentsToDelete = New Generic.List(Of AdvantageFramework.Database.Entities.Document)

                For Each DocumentID In AllDocumentIDs

                    Document = Nothing

                    Try

                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.JOB_TRAFFIC_VER_DET_DOCS WHERE DOCUMENT_ID = {0}", DocumentID)).FirstOrDefault = 0 Then

                            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                            If Document IsNot Nothing Then

                                DocumentsToDelete.Add(Document)

                            End If

                        End If

                    Catch ex As Exception

                    End Try

                Next

                If DocumentsToDelete IsNot Nothing AndAlso DocumentsToDelete.Count > 0 Then

                    AdvantageFramework.Database.Procedures.Document.Delete(DbContext, DocumentsToDelete)

                End If

            End If

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateAutoStatus(JobNumber As Integer, JobComponentNumber As Short, AutoStatus As Boolean) As JsonResult

            'objects
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim Updated As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                If JobTraffic IsNot Nothing Then

                    JobTraffic.AutoUpdateStatus = AutoStatus

                    Updated = AdvantageFramework.Database.Procedures.JobTraffic.Update(DbContext, JobTraffic)

                End If

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Updated))

        End Function

        <HttpGet>
        Public Function GetAutoStatus(JobNumber As Integer, JobComponentNumber As Short) As JsonResult

            'objects
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim AutoSave As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                If JobTraffic IsNot Nothing Then

                    AutoSave = If(JobTraffic.AutoUpdateStatus Is Nothing, 0, JobTraffic.AutoUpdateStatus)

                End If

            End Using

            Return Json(AutoSave, JsonRequestBehavior.AllowGet)

        End Function



        <AcceptVerbs("POST")>
        Public Function UpdateStatusCode(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As JsonResult
            Try

                Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                Dim dt As New DataTable
                Dim Updated As Boolean = False
                Dim NextStatusCode As String = ""

                dt = s.GetNextScheduleStatusCode(JobNumber, JobComponentNumber)

                If dt.Rows.Count > 0 Then

                    If IsDBNull(dt.Rows(0)("NEXT_STATUS_CODE")) = False Then

                        NextStatusCode = dt.Rows(0)("NEXT_STATUS_CODE").ToString().Trim

                    Else

                        NextStatusCode = ""

                    End If
                End If
                If NextStatusCode <> "" Then

                    If s.UpdateScheduleTrafficCode(JobNumber, JobComponentNumber, NextStatusCode) = "" Then

                        Updated = True

                    End If

                End If

                Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Updated))

            Catch ex As Exception

                'Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

            End Try
        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateStatusCodeMV(JCS As String) As JsonResult
            Try

                Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                Dim dt As New DataTable
                Dim Updated As Boolean = False
                Dim NextStatusCode As String = ""
                Dim Jobcomps() As String
                Dim JobNumber As Integer = 0
                Dim JobComponentNumber As Integer = 0

                If JCS <> "" Then

                    Jobcomps = JCS.Split("|")

                    If Jobcomps.Length > 0 Then
                        For k As Integer = 0 To Jobcomps.Length - 1
                            Dim strJC() As String = Jobcomps(k).Split(",")
                            If strJC(0) <> "" AndAlso IsNumeric(strJC(0)) = True Then
                                JobNumber = strJC(0)
                            End If
                            If strJC(0) <> "" AndAlso IsNumeric(strJC(1)) = True Then
                                JobComponentNumber = strJC(1)
                            End If

                            If JobNumber > 0 And JobComponentNumber > 0 Then

                                dt = s.GetNextScheduleStatusCode(JobNumber, JobComponentNumber)

                                If dt.Rows.Count > 0 Then

                                    If IsDBNull(dt.Rows(0)("NEXT_STATUS_CODE")) = False Then

                                        NextStatusCode = dt.Rows(0)("NEXT_STATUS_CODE").ToString().Trim

                                    Else

                                        NextStatusCode = ""

                                    End If
                                End If
                                If NextStatusCode <> "" Then

                                    If s.UpdateScheduleTrafficCode(JobNumber, JobComponentNumber, NextStatusCode) = "" Then

                                        Updated = True

                                    End If

                                End If

                            End If

                        Next
                    End If

                End If

                Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Updated))

            Catch ex As Exception

                'Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

            End Try
        End Function
        <AcceptVerbs("POST")>
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule", CheckCanUpdate:=True)>
        Public Function CalculateScheduleDates(JobNumber As Integer, JobComponentNumber As Short) As JsonResult

            'objects
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim Schedule As Webvantage.cSchedule = Nothing
            Dim Result As String = Nothing
            Dim ErrorMessage As String = ""
            Dim Calculated As Boolean = False
            Dim ResponseData As Object = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                If JobTraffic IsNot Nothing Then

                    Schedule = New Webvantage.cSchedule(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    If JobTraffic.ScheduleCalculation.GetValueOrDefault(0) = 0 Then

                        Result = Schedule.CalculateDueDates(JobNumber, JobComponentNumber, 0)

                    Else

                        Result = Schedule.CalculateDueDatesPred(JobNumber, JobComponentNumber, 1)

                    End If

                    Select Case Result

                        Case -1

                            ErrorMessage = "Could not get start date."

                        Case -2

                            ErrorMessage = "Schedule is not feasible for calculation."

                    End Select

                    If Result <> -1 AndAlso Result <> -2 Then

                        Calculated = True

                    End If

                    If Calculated Then

                        If AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, JobNumber, JobComponentNumber).Any Then

                            Result = Schedule.CalculateJobPreds(JobNumber, JobComponentNumber, 0, Session("EmpCode"))

                        End If

                        Schedule.UpdateTaskAlertsDueDate(JobNumber, JobComponentNumber)

                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                        If JobComponent IsNot Nothing Then
                            Dim Offset As Decimal = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, Me.SecuritySession.User.EmployeeCode)

                            If Offset < 0 Then
                                JobComponent.StartDate = JobComponent.StartDate.Value.AddHours(-Offset)
                                JobComponent.DueDate = JobComponent.DueDate.Value.AddHours(-Offset)
                            Else
                                JobComponent.StartDate = JobComponent.StartDate.Value.AddHours(Offset)
                                JobComponent.DueDate = JobComponent.DueDate.Value.AddHours(Offset)
                            End If

                            ResponseData = New With {
                                                .StartDate = JobComponent.StartDate,
                                                .DueDate = JobComponent.DueDate
                                            }

                        End If

                    End If

                End If

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Calculated, ErrorMessage, ResponseData))

        End Function

        <AcceptVerbs("POST")>
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule", CheckCanUpdate:=True)>
        Public Function CalculateScheduleDatesMV(JCS As String) As JsonResult

            'objects
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim Schedule As Webvantage.cSchedule = Nothing
            Dim Result As String = Nothing
            Dim ErrorMessage As String = ""
            Dim Calculated As Boolean = False
            Dim ResponseData As Object = Nothing
            Dim Jobcomps() As String
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Integer = 0

            If JCS <> "" Then

                Jobcomps = JCS.Split("|")

                If Jobcomps.Length > 0 Then
                    For k As Integer = 0 To Jobcomps.Length - 1
                        Dim strJC() As String = Jobcomps(k).Split(",")
                        If strJC(0) <> "" AndAlso IsNumeric(strJC(0)) = True Then
                            JobNumber = strJC(0)
                        End If
                        If strJC(0) <> "" AndAlso IsNumeric(strJC(1)) = True Then
                            JobComponentNumber = strJC(1)
                        End If

                        If JobNumber > 0 And JobComponentNumber > 0 Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                                JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                                If JobTraffic IsNot Nothing Then

                                    Schedule = New Webvantage.cSchedule(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                                    If JobTraffic.ScheduleCalculation.GetValueOrDefault(0) = 0 Then

                                        Result = Schedule.CalculateDueDates(JobNumber, JobComponentNumber, 0)

                                    Else

                                        Result = Schedule.CalculateDueDatesPred(JobNumber, JobComponentNumber, 1)

                                    End If

                                    Select Case Result

                                        Case -1

                                            ErrorMessage = "Could not get start date."

                                        Case -2

                                            ErrorMessage = "Schedule is not feasible for calculation."

                                    End Select

                                    If Result <> -1 AndAlso Result <> -2 Then

                                        Calculated = True

                                    End If

                                    If Calculated Then

                                        If AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, JobNumber, JobComponentNumber).Any Then

                                            Result = Schedule.CalculateJobPreds(JobNumber, JobComponentNumber, 0, Session("EmpCode"))

                                        End If

                                        Schedule.UpdateTaskAlertsDueDate(JobNumber, JobComponentNumber)

                                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                                        If JobComponent IsNot Nothing Then

                                            ResponseData = New With {
                                                .StartDate = JobComponent.StartDate,
                                                .DueDate = JobComponent.DueDate
                                            }

                                        End If

                                    End If

                                End If

                            End Using

                        End If

                    Next
                End If

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Calculated, ErrorMessage, ResponseData))

        End Function

        <AcceptVerbs("POST")>
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule")>
        Public Function SetPSMultiviewSession(JCS As String) As JsonResult

            Session("TrafficScheduleMVJobs") = JCS

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(True))

        End Function
        <AcceptVerbs("POST")>
        Public Function MarkTempComplete(JobNumber As Integer, JobComponentNumber As Short) As JsonResult

            'objects
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim Schedule As Webvantage.cSchedule = Nothing
            Dim Updated As Boolean = False
            Dim ErrorMessage As String = ""
            Dim ScheduleCompleteDate As Date?
            Dim ReturnObject As Object = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                If JobTraffic IsNot Nothing Then

                    Schedule = New Webvantage.cSchedule(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    ErrorMessage = Schedule.MarkTempComplete(JobNumber, JobComponentNumber)

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        Updated = True

                    End If

                End If

                If Updated = True Then

                    AdvantageFramework.ProjectSchedule.CheckToCompleteSchedule(DbContext, JobNumber, JobComponentNumber)

                    Try

                        ScheduleCompleteDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT COMPLETED_DATE FROM JOB_TRAFFIC WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1};", JobNumber, JobComponentNumber)).SingleOrDefault
                        ReturnObject = New With {.ScheduleCompletedDate = ScheduleCompleteDate}

                    Catch ex As Exception
                    End Try

                End If

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Updated, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("POST")>
        Public Function MarkTempCompleteMV(JCS As String) As JsonResult

            'objects
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim Schedule As Webvantage.cSchedule = Nothing
            Dim Updated As Boolean = False
            Dim ErrorMessage As String = ""
            Dim ScheduleCompleteDate As Date?
            Dim ReturnObject As Object = Nothing
            Dim Jobcomps() As String
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Integer = 0

            If JCS <> "" Then

                Jobcomps = JCS.Split("|")

                If Jobcomps.Length > 0 Then
                    For k As Integer = 0 To Jobcomps.Length - 1
                        Dim strJC() As String = Jobcomps(k).Split(",")
                        If strJC(0) <> "" AndAlso IsNumeric(strJC(0)) = True Then
                            JobNumber = strJC(0)
                        End If
                        If strJC(0) <> "" AndAlso IsNumeric(strJC(1)) = True Then
                            JobComponentNumber = strJC(1)
                        End If

                        If JobNumber > 0 And JobComponentNumber > 0 Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                                JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                                If JobTraffic IsNot Nothing Then

                                    Schedule = New Webvantage.cSchedule(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                                    ErrorMessage = Schedule.MarkTempComplete(JobNumber, JobComponentNumber)

                                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                        Updated = True

                                    End If

                                End If

                                If Updated = True Then

                                    Try

                                        AdvantageFramework.ProjectSchedule.CheckToCompleteSchedule(DbContext, JobNumber, JobComponentNumber)

                                        Try

                                            ScheduleCompleteDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT COMPLETED_DATE FROM JOB_TRAFFIC WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1};", JobNumber, JobComponentNumber)).SingleOrDefault
                                            ReturnObject = New With {.ScheduleCompletedDate = ScheduleCompleteDate}

                                        Catch ex As Exception
                                        End Try

                                    Catch ex As Exception
                                    End Try

                                End If

                            End Using

                        End If

                    Next
                End If

            End If



            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Updated, ErrorMessage, ReturnObject))

        End Function

        <AcceptVerbs("POST")>
        Public Function ClearDates(JobNumber As Integer, JobComponentNumber As Short, Optional IncludeOriginal As Boolean = False) As JsonResult

            'objects
            Dim Cleared As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                    Cleared = AdvantageFramework.ProjectSchedule.ClearDates(DbContext, JobNumber, JobComponentNumber, IncludeOriginal)

                End If

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Cleared))

        End Function
        <AcceptVerbs("POST")>
        Public Function SetOriginalDueDateOnlyWhereNotSet(JobNumber As Integer, JobComponentNumber As Short) As JsonResult

            'objects
            Dim Success As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                    Success = AdvantageFramework.ProjectSchedule.SetOriginalDueDateOnlyWhereNotSet(DbContext, JobNumber, JobComponentNumber)

                End If

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success))

        End Function
        <AcceptVerbs("POST")>
        Public Function SetOriginalDueDateForTasks(JobNumber As Integer, JobComponentNumber As Short, SequenceNumbers As Short()) As JsonResult

            'objects
            Dim Success As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                If JobNumber > 0 AndAlso JobComponentNumber > 0 AndAlso (SequenceNumbers IsNot Nothing And SequenceNumbers.Length > 0) Then

                    Success = AdvantageFramework.ProjectSchedule.SetOriginalDueDateForTasks(DbContext, JobNumber, JobComponentNumber, SequenceNumbers)

                End If

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success))

        End Function
        <AcceptVerbs("POST")>
        Public Function SetOriginalDueDate(JobNumber As Integer, JobComponentNumber As Short) As JsonResult

            'objects
            Dim Success As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                    Success = AdvantageFramework.ProjectSchedule.SetOriginalDueDate(DbContext, JobNumber, JobComponentNumber)

                End If

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success))

        End Function
        <AcceptVerbs("POST")>
        Public Function SetEmployeeTeam(JobNumber As Integer, JobComponentNumber As Short, Optional ByFunction As Boolean = False) As JsonResult

            'objects
            Dim Schedule As Webvantage.cSchedule = Nothing
            Dim Success As Boolean = False
            Dim ErrorMessage As String = ""

            If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                Schedule = New Webvantage.cSchedule(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                ErrorMessage = Schedule.ApplyTeam(ByFunction, JobNumber, JobComponentNumber)

                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                    Success = True

                End If

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success))

        End Function
        <AcceptVerbs("POST")>
        Public Function SetEmployeeTeamMV(JCS As String, Optional ByFunction As Boolean = False) As JsonResult

            'objects
            Dim Schedule As Webvantage.cSchedule = Nothing
            Dim Success As Boolean = False
            Dim ErrorMessage As String = ""
            Dim Jobcomps() As String
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Integer = 0

            If JCS <> "" Then

                Jobcomps = JCS.Split("|")

                If Jobcomps.Length > 0 Then
                    For k As Integer = 0 To Jobcomps.Length - 1
                        Dim strJC() As String = Jobcomps(k).Split(",")
                        If strJC(0) <> "" AndAlso IsNumeric(strJC(0)) = True Then
                            JobNumber = strJC(0)
                        End If
                        If strJC(0) <> "" AndAlso IsNumeric(strJC(1)) = True Then
                            JobComponentNumber = strJC(1)
                        End If

                        If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                            Schedule = New Webvantage.cSchedule(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                            ErrorMessage = Schedule.ApplyTeam(ByFunction, JobNumber, JobComponentNumber)

                            If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                Success = True

                            End If

                        End If

                    Next
                End If

            End If



            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success))

        End Function
        <AcceptVerbs("POST")>
        Public Function ClearEmployeeAssignments(JobNumber As Integer, JobComponentNumber As Short) As JsonResult

            'objects
            Dim Schedule As Webvantage.cSchedule = Nothing
            Dim Updated As Boolean = False

            If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Updated = AdvantageFramework.ProjectSchedule.ClearEmployeeAssignments(DbContext, JobNumber, JobComponentNumber)

                End Using

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Updated))

        End Function
        Public Function ReadEstimateFunctions() As JsonResult

            'objects
            Dim EstimateFunctions As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                EstimateFunctions = (From Item In AdvantageFramework.Database.Procedures.Function.LoadAllActive(DbContext)
                                     Where Item.Type = "E"
                                     Select [Code] = Item.Code,
                                            [Description] = Item.Description).ToList

            End Using

            Return Json(EstimateFunctions, JsonRequestBehavior.AllowGet)

        End Function
        Public Function ReadPhases(IncludeNoFilter As Boolean, IncludeNone As Boolean) As JsonResult

            'objects
            Dim Phases As IEnumerable = Nothing
            Dim ExtraPhases As Generic.Dictionary(Of Integer, String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                ExtraPhases = New Dictionary(Of Integer, String)

                If IncludeNoFilter Then

                    ExtraPhases.Add(-1, "[No Filter]")

                End If

                If IncludeNone Then

                    ExtraPhases.Add(0, "[None]")

                End If

                Phases = (From Item In ExtraPhases
                          Select [ID] = Item.Key,
                                      [Description] = Item.Value).ToList.Union(From Item In AdvantageFramework.Database.Procedures.Phase.LoadAllActive(DbContext)
                                                                               Order By Item.OrderNumber
                                                                               Select [ID] = Item.ID,
                                                                                      [Description] = Item.Description).ToList

            End Using

            Return Json(Phases, JsonRequestBehavior.AllowGet)

        End Function
        Public Function ReadSetupUserColumns(DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest) As JsonResult

            'objects
            Dim TrafficScheduleUserColumns As Generic.List(Of AdvantageFramework.Database.Classes.TrafficScheduleUserColumn) = Nothing
            Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                TrafficScheduleUserColumns = AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.LoadTrafficScheduleUserColumns(Me.SecuritySession, DbContext, Webvantage.MiscFN.IsClientPortal(), True, True, False)

            End Using

            DataSourceResult = TrafficScheduleUserColumns.ToDataSourceResult(DataSourceRequest)

            Return Json(DataSourceResult, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateSetupUserColumns(TrafficScheduleUserColumn As AdvantageFramework.Database.Classes.TrafficScheduleUserColumn) As JsonResult

            'objects
            Dim HeaderCode As String = Nothing

            If TrafficScheduleUserColumn IsNot Nothing Then

                If MiscFN.IsClientPortal Then

                    HeaderCode = Me.SecuritySession.ClientPortalUser.UserName

                Else

                    HeaderCode = Me.SecuritySession.User.EmployeeCode

                End If

                If String.IsNullOrWhiteSpace(TrafficScheduleUserColumn.HeaderCode) Then

                    TrafficScheduleUserColumn.HeaderCode = HeaderCode

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    AdvantageFramework.ProjectSchedule.SaveUserColumn(DbContext, TrafficScheduleUserColumn)

                End Using

            End If

            Return Json(TrafficScheduleUserColumn)

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateDefaultScheduleSetting(SettingCode As String, SettingValue As String) As JsonResult

            'objects
            Dim Updated As Boolean = False
            Dim ErrorMessage As String = Nothing
            Dim AppVars As Webvantage.cAppVars = Nothing
            AppVars = New cAppVars(cAppVars.Application.PROJECT_SCHEDULE)
            AppVars.getAllAppVars()

            Select Case SettingCode

                Case "DisablePaging"

                    AppVars.setAppVar(SettingCode, CBool(SettingValue), "Boolean")
                    ErrorMessage = AppVars.SaveAllAppVars()

                Case "SCHEDULE_CALC"

                    AppVars.setAppVar(SettingCode, CInt(SettingValue), "Integer")
                    ErrorMessage = AppVars.SaveAllAppVars()

                Case "LockedColumns"

                    AppVars.setAppVar(SettingCode, CInt(SettingValue), "Integer")
                    ErrorMessage = AppVars.SaveAllAppVars()

                Case "CopyEmployees"

                    AppVars.setAppVar(SettingCode, CBool(SettingValue), "Boolean")
                    ErrorMessage = AppVars.SaveAllAppVars()

                Case "GANTT_VIEW"

                    AppVars.setAppVar(SettingCode, SettingValue, "String")
                    ErrorMessage = AppVars.SaveAllAppVars()
            End Select

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Updated, ErrorMessage))

        End Function
        <HttpGet>
        Public Function GetGanttView() As JsonResult

            'objects
            Try
                Dim view As String = "month"

                Dim AppVars As Webvantage.cAppVars = Nothing

                AppVars = New cAppVars(cAppVars.Application.PROJECT_SCHEDULE)
                AppVars.getAllAppVars()

                view = AppVars.getAppVar("GANTT_VIEW", "String", "month")

                Return Json(view, JsonRequestBehavior.AllowGet)

            Catch ex As Exception

            End Try

        End Function
        Public Function LookupEntity(Type As String, Optional ClientCode As String = "", Optional DivisionCode As String = "", Optional ProductCode As String = "", Optional JobNumber As Integer? = Nothing, Optional JobComponentNumber As Short? = Nothing, Optional EntityCode As String = "", Optional EntityDescription As String = "") As JsonResult

            'objects
            Dim Entity As Object = Nothing
            Dim Success As Boolean = False
            Dim Message As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Select Case Type

                            Case "Client"

                                If Not String.IsNullOrWhiteSpace(ClientCode) Then

                                    Entity = (From Item In AdvantageFramework.ProjectSchedule.LookupClients(Me.SecuritySession, DbContext, SecurityDbContext)
                                              Where Item.Code = ClientCode
                                              Select [Code] = Item.Code,
                                                     [Name] = Item.Name).SingleOrDefault

                                    If Entity Is Nothing Then

                                        Message = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(AdvantageFramework.BaseClasses.Methods.PropertyTypes.ClientCode)

                                    Else

                                        Success = True

                                    End If

                                End If

                            Case "Division"

                                If Not String.IsNullOrWhiteSpace(ClientCode) AndAlso Not String.IsNullOrWhiteSpace(DivisionCode) Then

                                    Entity = (From Item In AdvantageFramework.ProjectSchedule.LookupDivisions(Me.SecuritySession, DbContext, SecurityDbContext)
                                              Where Item.ClientCode = ClientCode AndAlso
                                                    Item.DivisionCode = DivisionCode
                                              Select [Code] = Item.DivisionCode,
                                                     [Name] = Item.DivisionName).SingleOrDefault

                                    If Entity Is Nothing Then

                                        Message = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(AdvantageFramework.BaseClasses.Methods.PropertyTypes.DivisionCode)

                                    Else

                                        Success = True

                                    End If

                                End If

                            Case "Product"

                                If Not String.IsNullOrWhiteSpace(ClientCode) AndAlso Not String.IsNullOrWhiteSpace(DivisionCode) AndAlso Not String.IsNullOrWhiteSpace(ProductCode) Then

                                    Entity = (From Item In AdvantageFramework.ProjectSchedule.LookupProducts(Me.SecuritySession, DbContext, SecurityDbContext)
                                              Where Item.ClientCode = ClientCode AndAlso
                                                    Item.DivisionCode = DivisionCode AndAlso
                                                    Item.ProductCode = ProductCode
                                              Select [Code] = Item.ProductCode,
                                                     [Name] = Item.ProductDescription).SingleOrDefault

                                    If Entity Is Nothing Then

                                        Message = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(AdvantageFramework.BaseClasses.Methods.PropertyTypes.ProductCode)

                                    Else

                                        Success = True

                                    End If

                                End If

                            Case "Job"

                                If JobNumber.GetValueOrDefault(0) > 0 Then

                                    Entity = (From Item In AdvantageFramework.ProjectSchedule.LookupJobComponents(DbContext, Me.SecuritySession.UserCode, JobNumber, ClientCode, DivisionCode, ProductCode, IsCopy:=False, ShowClosed:=False)
                                              Group Item By [JN] = Item.JobNumber Into Group
                                              Select New With {.[Number] = Group.First.JobNumber,
                                                                .[Description] = Group.First.JobDescription,
                                                                .[ClientCode] = Group.First.ClientCode,
                                                                .[ClientName] = Group.First.ClientName,
                                                                .[DivisionCode] = Group.First.DivisionCode,
                                                                .[DivisionName] = Group.First.DivisionName,
                                                                .[ProductCode] = Group.First.ProductCode,
                                                                .[ProductName] = Group.First.ProductDescription,
                                                                .[JobComponentNumber] = If(Group.Count = 1, Group.First.JobComponentNumber, Nothing),
                                                                .[JobComponentDescription] = If(Group.Count = 1, Group.First.JobComponentDescription, Nothing)}).SingleOrDefault

                                    If Entity Is Nothing Then

                                        Message = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(AdvantageFramework.BaseClasses.Methods.PropertyTypes.JobNumber)

                                    Else

                                        Success = True

                                    End If

                                End If

                            Case "Component"

                                If JobNumber.GetValueOrDefault(0) > 0 Then

                                    Entity = (From Item In AdvantageFramework.ProjectSchedule.LookupJobComponents(DbContext, Me.SecuritySession.UserCode, JobNumber, ClientCode, DivisionCode, ProductCode, IsCopy:=False, ShowClosed:=False)
                                              Select [Number] = Item.JobComponentNumber,
                                                     [Description] = Item.JobComponentDescription).SingleOrDefault

                                    If Entity Is Nothing Then

                                        Message = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(AdvantageFramework.BaseClasses.Methods.PropertyTypes.JobComponent)

                                    Else

                                        Success = True

                                    End If

                                End If

                            Case "Task"

                                If Not String.IsNullOrWhiteSpace(EntityCode) Then

                                    Entity = (From Item In AdvantageFramework.Database.Procedures.Task.LoadAllActive(DbContext)
                                              Where Item.Code = EntityCode
                                              Select [Code] = Item.Code,
                                                     [Description] = Item.Description).SingleOrDefault

                                    If Entity Is Nothing Then

                                        Message = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(AdvantageFramework.BaseClasses.Methods.PropertyTypes.TaskCode)

                                    Else

                                        Success = True

                                    End If

                                ElseIf Not String.IsNullOrWhiteSpace(EntityDescription) Then

                                    Entity = (From Item In AdvantageFramework.Database.Procedures.Task.LoadAllActive(DbContext)
                                              Where Item.Description = EntityDescription
                                              Select [Code] = Item.Code,
                                                     [Description] = Item.Description).FirstOrDefault

                                    Success = True

                                End If

                            Case "Employee"

                                If Not String.IsNullOrWhiteSpace(EntityCode) Then

                                    Entity = (From Item In AdvantageFramework.ProjectSchedule.LoadEmployees(Me.SecuritySession, DbContext, SecurityDbContext)
                                              Where Item.Code = EntityCode
                                              Select Item).ToList.Select(Function(e) New With {.Code = e.Code, .Description = e.ToString}).SingleOrDefault

                                    If Entity Is Nothing Then

                                        Message = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(AdvantageFramework.BaseClasses.Methods.PropertyTypes.EmployeeCode)

                                    Else

                                        Success = True

                                    End If

                                End If

                        End Select

                    End Using

                End Using

            Catch ex As Exception
                Entity = Nothing
                Success = False
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, Message, Entity), JsonRequestBehavior.AllowGet)

        End Function
        Public Function SaveApplicationVar(Key As String, Value As String) As JsonResult

            'objects
            Dim Saved As Boolean = False
            Dim UserSettingCode As AdvantageFramework.ProjectSchedule.Classes.Schedule.UserSettingCodes = Nothing

            If System.Enum.TryParse(Of AdvantageFramework.ProjectSchedule.Classes.Schedule.UserSettingCodes)(Key, UserSettingCode) Then

                Saved = AdvantageFramework.ProjectSchedule.Classes.Schedule.SaveUserSetting(Me.SecuritySession, UserSettingCode, Value)

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Saved))

        End Function
        <OutputCache(Duration:=60, VaryByParam:="EmployeeCode")>
        Public Function ValidateAssignment(EmployeeCode As String) As JsonResult

            'objects
            Dim IsValidAssignment As Boolean = False
            Dim Employee As Object = Nothing

            If Not String.IsNullOrWhiteSpace(EmployeeCode) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Employee = (From Item In AdvantageFramework.ProjectSchedule.LoadEmployees(Me.SecuritySession, DbContext, SecurityDbContext)
                                    Where Item.Code = EmployeeCode
                                    Select Item).ToList.Select(Function(e) New With {.Code = e.Code, .Name = e.ToString}).SingleOrDefault

                        If Employee IsNot Nothing Then

                            IsValidAssignment = True

                        End If

                    End Using

                End Using

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(IsValidAssignment, "", Employee), JsonRequestBehavior.AllowGet)

        End Function
        <OutputCache(Duration:=60, VaryByParam:="StatusCode")>
        Public Function ValidateStatus(StatusCode As String) As JsonResult

            'objects
            Dim IsValidStatus As Boolean = False
            Dim Status As Object = Nothing

            If Not String.IsNullOrWhiteSpace(StatusCode) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Status = (From Item In AdvantageFramework.Database.Procedures.Status.LoadAllActive(DbContext)
                                  Where Item.Code = StatusCode
                                  Select [Code] = Item.Code,
                                         [Description] = Item.Description).SingleOrDefault

                        If Status IsNot Nothing Then

                            IsValidStatus = True

                        End If

                    End Using

                End Using

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(IsValidStatus, "", Status), JsonRequestBehavior.AllowGet)

        End Function
        <OutputCache(Duration:=60, VaryByParam:="FunctionCode")>
        Public Function ValidateFunction(FunctionCode As String) As JsonResult

            'objects
            Dim IsValidFunction As Boolean = False
            Dim [Function] As Object = Nothing

            If Not String.IsNullOrWhiteSpace(FunctionCode) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        [Function] = (From Item In AdvantageFramework.Database.Procedures.Function.LoadAllActive(DbContext)
                                      Where Item.Type = "E" AndAlso
                                            Item.Code = FunctionCode
                                      Select [Code] = Item.Code,
                                             [Description] = Item.Description).SingleOrDefault

                        If [Function] IsNot Nothing Then

                            IsValidFunction = True

                        End If

                    End Using

                End Using

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(IsValidFunction, "", [Function]), JsonRequestBehavior.AllowGet)

        End Function
        <OutputCache(Duration:=60, VaryByParam:="TaskCode")>
        Public Function ValidateTask(TaskCode As String) As JsonResult

            'objects
            Dim IsValidTask As Boolean = False
            Dim Task As Object = Nothing

            If Not String.IsNullOrWhiteSpace(TaskCode) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Task = (From Item In AdvantageFramework.Database.Procedures.Task.LoadAllActive(DbContext)
                                Where Item.Code = TaskCode
                                Select [Code] = Item.Code,
                                       [Description] = Item.Description,
                                       [Order] = Item.ProcessOrderNumber).SingleOrDefault

                        If Task IsNot Nothing Then

                            IsValidTask = True

                        End If

                    End Using

                End Using

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(IsValidTask, "", Task), JsonRequestBehavior.AllowGet)

        End Function
        <OutputCache(Duration:=60, VaryByParam:="PhaseDescription")>
        Public Function ValidatePhase(PhaseDescription As String) As JsonResult

            'objects
            Dim IsValidPhase As Boolean = False
            Dim Phase As Object = Nothing

            If Not String.IsNullOrWhiteSpace(PhaseDescription) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Phase = (From Item In AdvantageFramework.Database.Procedures.Phase.LoadAllActive(DbContext)
                                 Where Item.Description = PhaseDescription
                                 Select [ID] = Item.ID,
                                        [Description] = Item.Description).SingleOrDefault

                        If Phase IsNot Nothing Then

                            IsValidPhase = True

                        End If

                    End Using

                End Using

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(IsValidPhase, "", Phase), JsonRequestBehavior.AllowGet)

        End Function
        Public Function ValidatePredecessors(JobNumber As Integer, JobComponentNumber As Short, SequenceNumber As Short, PredecessorSequenceNumbers As Short()) As JsonResult

            'objects
            Dim IsValidPredecessor As Boolean = False
            Dim Message As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                IsValidPredecessor = AdvantageFramework.ProjectSchedule.ValidatePredecessors(DbContext, JobNumber, JobComponentNumber, SequenceNumber, PredecessorSequenceNumbers, Message)

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(IsValidPredecessor, Message, Nothing), JsonRequestBehavior.AllowGet)

        End Function

        <AcceptVerbs("POST")>
        Public Function GanttTasksListPost(JobNumber As Integer, JobComponentNumber As Integer) As ActionResult
            Dim Results As List(Of Gantt.GanttTask) = Nothing
            Dim GanttTaskRepo As Repositories.GanttTaskRepository = Nothing

            Try
                GanttTaskRepo = New Repositories.GanttTaskRepository(Me.SecuritySession)
                Results = GanttTaskRepo.All(JobNumber, JobComponentNumber)
            Catch ex As Exception
                Results = New List(Of Gantt.GanttTask)
                Me.LogError(ex)
            End Try

            GanttTasksListPost = Json(Results)
        End Function

        Public Function GanttTasksList(JobNumber As Integer, JobComponentNumber As Integer, ShowPhases As Boolean) As ActionResult
            Dim Results As List(Of Gantt.GanttTask) = Nothing
            Dim GanttTaskRepo As Repositories.GanttTaskRepository = Nothing

            Try
                GanttTaskRepo = New Repositories.GanttTaskRepository(Me.SecuritySession)
                Results = GanttTaskRepo.All(JobNumber, JobComponentNumber, CBool(ShowPhases))
            Catch ex As Exception
                Results = New List(Of Gantt.GanttTask)
                Me.LogError(ex)
            End Try

            GanttTasksList = Me.Jsonp(Results)
        End Function

        'Public Function GanttTasksCreate(JobNumber As String, JobComponentNumber As String) As ActionResult
        '    Dim GanttTaskRepo As Repositories.GanttTaskRepository = Nothing
        '    GanttTaskRepo = New Repositories.GanttTaskRepository(Me.SecuritySession)

        '    Dim Tasks = Me.DeserializeObject(Of IEnumerable(Of Gantt.GanttTask))("models")

        '    If Tasks IsNot Nothing Then
        '        For Each Task In Tasks
        '            GanttTaskRepo.Insert(CInt(JobNumber), CInt(JobComponentNumber), Task)
        '        Next
        '    End If

        '    Return Me.Jsonp(Tasks)
        'End Function

        'Public Function GanttTasksDelete(JobNumber As String, JobComponentNumber As String) As ActionResult
        '    Dim GanttTaskRepo As Repositories.GanttTaskRepository = Nothing
        '    Dim Tasks As IEnumerable(Of Gantt.GanttTask) = Nothing

        '    Try
        '        GanttTaskRepo = New Repositories.GanttTaskRepository(Me.SecuritySession)
        '        Tasks = Me.DeserializeObject(Of IEnumerable(Of Gantt.GanttTask))("models")

        '        If Tasks IsNot Nothing Then
        '            For Each Task In Tasks
        '                GanttTaskRepo.Delete(CInt(JobNumber), CInt(JobComponentNumber), Task)
        '            Next
        '        End If
        '    Catch ex As Exception
        '        Me.LogError(ex)
        '        Tasks = New List(Of Gantt.GanttTask)()
        '    End Try

        '    GanttTasksDelete = Me.Jsonp(Tasks)
        'End Function

        Public Function GanttTasksUpdate(JobNumber As Integer, JobComponentNumber As Integer) As ActionResult
            Dim GanttTaskRepo As Repositories.GanttTaskRepository = Nothing
            Dim Tasks As IEnumerable(Of Gantt.GanttTask) = Nothing
            Try
                GanttTaskRepo = New Repositories.GanttTaskRepository(Me.SecuritySession)

                Tasks = Me.DeserializeObject(Of IEnumerable(Of Gantt.GanttTask))("models")

                If Tasks IsNot Nothing Then
                    For Each Task In Tasks
                        Try
                            Task.End = Task.End.GetValueOrDefault().Date
                        Catch ex As Exception
                        End Try
                        GanttTaskRepo.Update(CInt(JobNumber), CInt(JobComponentNumber), Task)
                    Next
                End If
            Catch ex As Exception
                Me.LogError(ex)
                Tasks = New List(Of Gantt.GanttTask)()
            End Try

            GanttTasksUpdate = Me.Jsonp(Tasks)
        End Function

        <AcceptVerbs("POST")>
        Public Function GetJobDescriptions(JobComponents As String) As ActionResult
            Dim GanttTaskRepo As Repositories.GanttTaskRepository = Nothing
            Dim JobComponentInfoList As List(Of Gantt.GanttJobInfo) = Nothing
            Try
                GanttTaskRepo = New Repositories.GanttTaskRepository(Me.SecuritySession)
                JobComponentInfoList = JsonConvert.DeserializeObject(Of List(Of Gantt.GanttJobInfo))(JobComponents)

                For Each ComponentItem In JobComponentInfoList
                    ComponentItem.JobDescription = GanttTaskRepo.GetJobDescription(ComponentItem)
                Next

            Catch ex As Exception
                Me.LogError(ex)
                JobComponentInfoList = New List(Of Gantt.GanttJobInfo)()
            End Try

            GetJobDescriptions = Json(JobComponentInfoList)
        End Function

        <AcceptVerbs("POST")>
        Public Function GetRelatedJobs(JobInfo As String) As ActionResult
            Dim GanttTaskRepo As Repositories.GanttTaskRepository = Nothing
            Dim JobComponentInfo As Gantt.GanttJobInfo = Nothing
            Dim Results As List(Of Gantt.GanttJobInfo) = Nothing

            Try
                GanttTaskRepo = New Repositories.GanttTaskRepository(Me.SecuritySession)
                JobComponentInfo = JsonConvert.DeserializeObject(Of Gantt.GanttJobInfo)(JobInfo)

                Results = GanttTaskRepo.GetRelatedJobs(JobComponentInfo)
            Catch ex As Exception
                Me.LogError(ex)
                Results = New List(Of Gantt.GanttJobInfo)()
            End Try

            GetRelatedJobs = Json(Results)
        End Function

        <AcceptVerbs("POST")>
        Public Function RecalculateScheduleDates(RecalculationRequest As String) As ActionResult
            Dim CurrentRecalculationRequest As ViewModels.Gantt.RecalculationRequest = Nothing
            Dim ScheduleRepo As Repositories.ScheduleRepository = Nothing
            Dim FrameworkScheduleObject As cSchedule = New cSchedule(SecuritySession.ConnectionString, SecuritySession.UserCode)
            Dim DataTableHeader As DataTable
            Dim IsPredecessor As Integer
            Dim ReturnCode As Integer = 0
            Dim JobPred As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
            Dim DataTableGridColumnsToDisplay As System.Data.DataTable = Nothing
            Dim CalculateByDueDate As Boolean = False
            Dim CalculateBy As Integer = 0 '1 is start, zero/null is due

            Try

                CurrentRecalculationRequest = JsonConvert.DeserializeObject(Of Gantt.RecalculationRequest)(RecalculationRequest)
                ScheduleRepo = New Repositories.ScheduleRepository(Me.SecuritySession)

                DataTableGridColumnsToDisplay = FrameworkScheduleObject.GetScheduleColumns(Session("EmpCode"), False, False, False)

                'IsPredecessor = ScheduleRepo.GetFollowingJobs(CurrentRecalculationRequest.JobNumber, CurrentRecalculationRequest.JobComponentNumber).Any()

                If CurrentRecalculationRequest.RequestFrom = "ps" Then

                    DataTableHeader = FrameworkScheduleObject.GetScheduleHeader(CurrentRecalculationRequest.JobNumber, CurrentRecalculationRequest.JobComponentNumber, Session("UserCode").ToString(), False).Tables(0)

                    If IsDBNull(DataTableHeader.Rows(0)("TRF_SCHEDULE_BY")) = False Then

                        CalculateBy = CType(DataTableHeader.Rows(0)("TRF_SCHEDULE_BY"), Integer)

                        If CalculateBy = 0 Then

                            CalculateByDueDate = True

                        Else

                            CalculateByDueDate = False

                        End If

                    Else

                        CalculateByDueDate = True

                    End If

                    If CalculateByDueDate = True Then

                        If IsDBNull(DataTableHeader.Rows(0)("JOB_FIRST_USE_DATE")) = True Then

                            CurrentRecalculationRequest.ErrorMessage = "Due date required."

                        End If

                    Else

                        If String.IsNullOrEmpty(CurrentRecalculationRequest.ErrorMessage) AndAlso IsDBNull(DataTableHeader.Rows(0)("START_DATE")) = True Then

                            CurrentRecalculationRequest.ErrorMessage = "Start date required."

                        End If

                    End If

                    If (String.IsNullOrEmpty(CurrentRecalculationRequest.ErrorMessage)) Then

                        If DataTableHeader.Rows(0)("SCHEDULE_CALC") = 1 Then

                            IsPredecessor = 1

                        ElseIf DataTableHeader.Rows(0)("SCHEDULE_CALC") = 0 Then

                            IsPredecessor = 0

                        Else

                            For Each DataRow In DataTableGridColumnsToDisplay.Rows.OfType(Of System.Data.DataRow)()

                                If DataRow("ColumnName") = "colPREDECESSORS_TEXT" AndAlso DataRow("ShowOnGrid") = "True" Then

                                    IsPredecessor = 1

                                End If

                            Next

                        End If

                        If IsPredecessor = 1 Then

                            ReturnCode = FrameworkScheduleObject.CalculateDueDatesPred(CurrentRecalculationRequest.JobNumber, CurrentRecalculationRequest.JobComponentNumber, IsPredecessor)

                        Else

                            ReturnCode = FrameworkScheduleObject.CalculateDueDates(CurrentRecalculationRequest.JobNumber, CurrentRecalculationRequest.JobComponentNumber, 0)

                        End If

                        Select Case ReturnCode

                            Case -1
                                CurrentRecalculationRequest.ErrorMessage = "Could not get start date."

                            Case -2
                                CurrentRecalculationRequest.ErrorMessage = "Schedule is not feasible for calculation."

                        End Select

                        If CurrentRecalculationRequest.ErrorMessage = String.Empty Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                                JobPred = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, CurrentRecalculationRequest.JobNumber, CurrentRecalculationRequest.JobComponentNumber).ToList

                                If JobPred.Count > 0 Then

                                    ReturnCode = FrameworkScheduleObject.CalculateJobPreds(CurrentRecalculationRequest.JobNumber, CurrentRecalculationRequest.JobComponentNumber, 0, Session("EmpCode"))

                                End If

                            End Using

                        End If

                    End If

                Else

                    Dim TrafficScheduleJobs() As String = Session("TrafficScheduleMVJobs").ToString.Split("|")
                    For TrafficScheduleJobIndex As Integer = 0 To TrafficScheduleJobs.Length - 1

                        Dim TrafficScheduleJobDetailItems() As String = TrafficScheduleJobs(TrafficScheduleJobIndex).Split(",")
                        If TrafficScheduleJobDetailItems(0) <> "" Then
                            DataTableHeader = FrameworkScheduleObject.GetScheduleHeader(TrafficScheduleJobDetailItems(0), TrafficScheduleJobDetailItems(1), Session("UserCode").ToString(), False).Tables(0)

                            If DataTableHeader.Rows(0)("SCHEDULE_CALC") = 1 Then
                                IsPredecessor = 1
                            ElseIf DataTableHeader.Rows(0)("SCHEDULE_CALC") = 0 Then
                                IsPredecessor = 0
                            Else
                                For Each DataRow In DataTableGridColumnsToDisplay.Rows.OfType(Of System.Data.DataRow)()
                                    If DataRow("ColumnName") = "colPREDECESSORS_TEXT" AndAlso DataRow("ShowOnGrid") = "True" Then
                                        IsPredecessor = 1
                                    End If
                                Next
                            End If

                            If IsPredecessor = 1 Then
                                ReturnCode = FrameworkScheduleObject.CalculateDueDatesPred(TrafficScheduleJobDetailItems(0), TrafficScheduleJobDetailItems(1), 1)
                            Else
                                ReturnCode = FrameworkScheduleObject.CalculateDueDates(TrafficScheduleJobDetailItems(0), TrafficScheduleJobDetailItems(1), 0)
                            End If

                            Select Case ReturnCode
                                Case -1
                                    CurrentRecalculationRequest.ErrorMessage = "Could not get start date."
                                Case -2
                                    CurrentRecalculationRequest.ErrorMessage = "Schedule is not feasible for calculation."
                            End Select

                            If Not String.IsNullOrEmpty(CurrentRecalculationRequest.ErrorMessage) Then
                                Exit For
                            End If

                            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)
                                JobPred = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, TrafficScheduleJobDetailItems(0), TrafficScheduleJobDetailItems(1)).ToList
                                If JobPred.Count > 0 Then
                                    ReturnCode = FrameworkScheduleObject.CalculateJobPreds(TrafficScheduleJobDetailItems(0), TrafficScheduleJobDetailItems(1), 0, Session("EmpCode"))
                                End If
                            End Using
                        End If
                    Next

                End If

            Catch ex As Exception
                CurrentRecalculationRequest.ErrorMessage = ex.Message
                Me.LogError(ex)
            End Try

            RecalculateScheduleDates = Json(CurrentRecalculationRequest)
        End Function

        Private Sub LoadScheduleQueryStringVars(Schedule As AdvantageFramework.ProjectSchedule.Classes.Schedule)

            'objects
            Dim QueryString As AdvantageFramework.Web.QueryString = New AdvantageFramework.Web.QueryString

            QueryString = QueryString.FromCurrent

            Schedule.IsJobDashboard = QueryString.IsJobDashboard

            Try

                If IsNumeric(GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.JobNum)) Then

                    Schedule.JobNumber = CType(GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.JobNum), Integer)

                End If

            Catch ex As Exception
                Schedule.JobNumber = 0
            End Try

            Try

                If IsNumeric(GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.JobComp)) Then

                    Schedule.JobComponentNumber = CType(GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.JobComp), Integer)

                End If

            Catch ex As Exception
                Schedule.JobComponentNumber = 0
            End Try

            Try

                If Not GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.P) = Nothing Then

                    Schedule.PhaseFilter = GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.P).ToString()

                End If

            Catch ex As Exception

            End Try

            Try

                If Not GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.Role) = Nothing Then

                    Schedule.RoleCode = GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.Role).ToString()

                End If

            Catch ex As Exception

            End Try

            Try

                If Not GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.Task) = Nothing Then

                    Schedule.TaskCode = GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.Task).ToString()

                End If

            Catch ex As Exception

            End Try

            Try

                If Not GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.Emp) = Nothing Then

                    Schedule.EmployeeCode = GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.Emp).ToString()

                End If

            Catch ex As Exception

            End Try

            Try

                If Not GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.Cut) = Nothing Then

                    Schedule.CutOffDate = GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.Cut).ToString()

                End If

            Catch ex As Exception

            End Try

            Try

                If Not GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.Pend) = Nothing Then

                    Schedule.IncludeOnlyPendingTasks = CType(GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.Pend).ToString(), Boolean)

                End If

            Catch ex As Exception

            End Try

            Try

                If Not GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.Proj) = Nothing Then

                    Schedule.ExcludeProjectedTasks = CType(GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.Proj).ToString(), Boolean)

                End If

            Catch ex As Exception

            End Try

            Try

                If Not GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.Comp) = Nothing Then

                    Schedule.UserSettings.IncludeCompletedTasks = CType(GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.Comp).ToString(), Boolean)

                End If

            Catch ex As Exception

            End Try

            Try

                If Not GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.seq) = Nothing Then

                    Schedule.SequenceNumber = CType(GetQueryStringVariable(AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars.seq), Integer)

                End If

            Catch ex As Exception
                Schedule.SequenceNumber = -1
            End Try

            Try

                If Me.Session("PS_Ignore_Filter") = Nothing Then

                    Me.Session("PS_Ignore_Filter") = "0"

                End If

            Catch ex As Exception

            End Try

            With QueryString

                If .JobNumber > 0 Then

                    Schedule.JobNumber = .JobNumber

                End If

                If .JobComponentNumber > 0 Then

                    Schedule.JobComponentNumber = .JobComponentNumber

                End If

                'Me.IsLoadedIntoDashboard = QueryString.IsJobDashboard

                If .PhaseFilter <> "" Then

                    Schedule.PhaseFilter = .PhaseFilter

                End If

                If .RoleCode <> "" Then

                    Schedule.RoleCode = .RoleCode

                End If

                If .TaskCode <> "" Then

                    Schedule.TaskCode = .TaskCode

                End If

                If .EmployeeCode <> "" Then

                    Schedule.EmployeeCode = .EmployeeCode

                End If

                If .CutOffDate <> "" Then

                    Schedule.CutOffDate = .CutOffDate

                End If

                If .IncludeOnlyPendingTasks = True Then

                    Schedule.IncludeOnlyPendingTasks = .IncludeOnlyPendingTasks

                End If

                If .ExcludeProjectedTasks = True Then

                    Schedule.ExcludeProjectedTasks = .ExcludeProjectedTasks

                End If

                If .IncludeCompletedTasks = True Then

                    Schedule.UserSettings.IncludeCompletedTasks = .IncludeCompletedTasks

                End If

                If .TaskSequenceNumber > 0 Then

                    Schedule.SequenceNumber = .TaskSequenceNumber

                End If

                'TP _TaskFilterIndex = _TaskPhaseFilter

            End With


        End Sub
        Private Function GetQueryStringVariable(QueryStringVar As AdvantageFramework.ProjectSchedule.Classes.Schedule.QueryStringVars) As Object

            'objects
            Dim Value As Object = Nothing

            Try

                If Request.QueryString(QueryStringVar.ToString) IsNot Nothing Then

                    Value = Request.QueryString(QueryStringVar.ToString)

                End If

            Catch ex As Exception
                Value = Nothing
            Finally
                GetQueryStringVariable = Value
            End Try

        End Function
        Private Sub PopulateCopyToProjectScheduleViewModel(CopyToProjectScheduleViewModel As AdvantageFramework.ViewModels.ProjectSchedule.CopyToProjectScheduleViewModel)

            'objects
            'Dim JobComponents As Generic.List(Of AdvantageFramework.ViewModels.ProjectSchedule.CopyToProjectScheduleJobComponentViewModel) = Nothing

            Try

                'Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                '    JobComponents = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.ProjectSchedule.CopyToProjectScheduleJobComponentViewModel)("EXEC dbo.advsp_project_schedule_copyto_load_jobcomp '" & Me.SecuritySession.UserCode & "'").Where(Function(Entity) Not (Entity.JobNumber = CopyToProjectScheduleViewModel.JobNumber AndAlso
                '                                                                                                                                                                                                                                                                      Entity.JobComponentNumber = CopyToProjectScheduleViewModel.JobComponentNumber)).ToList

                '    CopyToProjectScheduleViewModel.JobComponents.AddRange(JobComponents)

                'End Using

                CopyToProjectScheduleViewModel.PageSize = MiscFN.LoadPageSize(CopyToProjectSchedules_GridJobComponents)

            Catch ex As Exception

            End Try

        End Sub
        Private Function AreDatesEqual(Date1 As Date?, Date2 As Date?) As Boolean

            'objects
            Dim DatesEqual As Boolean = True

            If Not Date.Equals(Date1, Date2) Then

                If Not (Date1.HasValue AndAlso Date2.HasValue AndAlso Date.Equals(Date1.Value.Date, Date2.Value.Date)) Then

                    DatesEqual = False

                End If

            End If

            AreDatesEqual = DatesEqual

        End Function


        <AcceptVerbs("POST")>
        Public Function Replace(ByVal JobComps As String) As JsonResult
            Try

                Dim Updated As Boolean = False

                Session("PS_FIND_REPLACE_COMPONENTS") = JobComps

                If Not String.IsNullOrWhiteSpace(JobComps) Then

                    'Me.OpenWindow("Search and Replace", "ProjectManagement/ProjectSchedule/FindAndReplace?wm=1&Components=ALL", 0, 0, False, True)

                End If

                Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Updated))

            Catch ex As Exception

                'Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

            End Try
        End Function

        <AcceptVerbs("POST")>
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule", CheckCanUpdate:=True)>
        Public Function SaveSchedules(JobNumber As Integer, JobComponentNumber As Short, StatusCode As String, StartDate As Date?, DueDate As Date?, CompletedDate As Date?, GutPercent As Decimal, Comments As String) As JsonResult

            'objects
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim Schedule As Webvantage.cSchedule = Nothing
            Dim Result As String = Nothing
            Dim ErrorMessage As String = ""
            Dim Updated As Boolean = False
            Dim ResponseData As Object = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)
                JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                If JobTraffic IsNot Nothing Then

                    With JobTraffic
                        .TrafficCode = StatusCode
                        .PercentComplete = GutPercent
                        .CompletedDate = CompletedDate
                        .TrafficComments = Comments
                    End With

                    Updated = AdvantageFramework.Database.Procedures.JobTraffic.Update(DbContext, JobTraffic)

                End If

                If JobComponent IsNot Nothing Then

                    With JobComponent
                        .StartDate = StartDate
                        .DueDate = DueDate
                    End With

                    Updated = AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent)

                End If

                AdvantageFramework.ProjectSchedule.CheckToCompleteSchedule(DbContext, JobNumber, JobComponentNumber)

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Updated, ErrorMessage, ResponseData))

        End Function


        <HttpGet>
        Public Function CheckJobTaskCount(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As JsonResult
            Dim Count As Integer = 0
            Dim s As String

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Count = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber).Count()

            End Using

            Return MaxJson(Count, JsonRequestBehavior.AllowGet)

        End Function

#End Region

#Region " API "
        <HttpPost()>
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule")>
        Public Function FindAndReplace(Model As AdvantageFramework.ViewModels.ProjectSchedule.ProjectScheduleFindAndReplaceViewModel) As ActionResult

            'objects
            Dim Validator As Webvantage.cValidations = New cValidations(Me.SecuritySession.ConnectionString)
            Dim Controller As AdvantageFramework.Controller.ProjectManagement.ProjectScheduleController = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Select Case Model.SelectedCriteria

                    Case "StartDate", "DueDate", "CompletedDate"

                        'If Model.FromDateSearchFor.HasValue = False Then

                        'ModelState.AddModelError("FromDateSearchFor", "Search for start date is required.")

                        'End If

                        If Model.FromDateSearchFor.HasValue = True AndAlso Model.ToDateSearchFor.HasValue = True Then

                            If Model.FromDateSearchFor.Value > Model.ToDateSearchFor.Value Then

                                ModelState.AddModelError("ToDateSearchFor", "Search for end date is before the search for start date.")

                            End If

                        End If

                    Case "HeaderStartDate", "HeaderDueDate", "HeaderCompletedDate"

                        If Model.FromDateSearchFor.HasValue = False AndAlso Model.ToDateSearchFor.HasValue = True Then

                            ModelState.AddModelError("FromDateSearchFor", "Search for start date is required.")

                        End If

                        If Model.FromDateSearchFor.HasValue = True AndAlso Model.ToDateSearchFor.HasValue = False Then

                            ModelState.AddModelError("FromDateSearchFor", "Search for end date is required.")

                        End If

                        If Model.FromDateSearchFor.HasValue = True AndAlso Model.ToDateSearchFor.HasValue = True Then

                            If Model.FromDateSearchFor.Value > Model.ToDateSearchFor.Value Then

                                ModelState.AddModelError("ToDateSearchFor", "Search for end date is before the search for start date.")

                            End If

                        End If

                    Case "TimeDue"

                        If String.IsNullOrWhiteSpace(Model.TimeDueSearchFor) = False Then

                            If Model.TimeDueSearchFor.Length > 10 Then

                                ModelState.AddModelError("TimeDueSearchFor", "Invalid search for time due.")

                            End If

                        End If

                        If String.IsNullOrWhiteSpace(Model.TimeDueReplaceWith) = False Then

                            If Model.TimeDueReplaceWith.Length > 10 Then

                                ModelState.AddModelError("TimeDueReplaceWith", "Invalid replace with time due.")

                            End If

                        End If

                    Case "EmployeeAssignment"

                        If String.IsNullOrWhiteSpace(Model.EmployeeCodeSearchFor) AndAlso String.IsNullOrWhiteSpace(Model.EmployeeCodeReplaceWith) Then

                            ModelState.AddModelError("EmployeeCodeSearchFor", "Please enter an employee to search for or replace with.")

                        End If

                        If String.IsNullOrWhiteSpace(Model.EmployeeCodeSearchFor) = False Then

                            If Validator.ValidateEmpCode(Model.EmployeeCodeSearchFor) = False Then

                                ModelState.AddModelError("EmployeeCodeSearchFor", "Invalid search for employee.")

                            End If

                        End If

                        If String.IsNullOrWhiteSpace(Model.EmployeeCodeReplaceWith) = False Then

                            If Validator.ValidateEmpCodetd(Model.EmployeeCodeReplaceWith) = False Then

                                ModelState.AddModelError("EmployeeCodeReplaceWith", "Invalid replace with employee.")

                            End If

                        End If

                        If String.IsNullOrWhiteSpace(Model.TaskCodeSearchFor) = False Then

                            If Validator.ValidateTaskCode(Model.TaskCodeSearchFor) = False Then

                                ModelState.AddModelError("TaskCodeSearchFor", "Invalid task code.")

                            End If

                        End If

                    Case "ClientContactAssignment"

                        If String.IsNullOrWhiteSpace(Model.ClientContactCodeSearchFor) Then

                            ModelState.AddModelError("ClientContactCodeSearchFor", "Invalid search for client contact.")

                        ElseIf AdvantageFramework.Database.Procedures.ClientContact.LoadByClientAndContactCode(DbContext, Model.ClientCode, Model.ClientContactCodeSearchFor) Is Nothing Then

                            ModelState.AddModelError("ClientContactCodeSearchFor", "Invalid search for client contact.")

                        End If

                        If String.IsNullOrWhiteSpace(Model.ClientContactCodeReplaceWith) = False Then

                            If AdvantageFramework.Database.Procedures.ClientContact.LoadByClientAndContactCode(DbContext, Model.ClientCode, Model.ClientContactCodeReplaceWith) Is Nothing Then

                                ModelState.AddModelError("ClientContactCodeReplaceWith", "Invalid replace with client contact.")

                            End If

                        End If

                    Case "TaskStatus"

                        If (From item In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.ProjectSchedule.TaskStatus))
                            Where item.Code = Model.TaskStatusSearchFor
                            Select item).Any = False Then

                            ModelState.AddModelError("TaskStatusSearchFor", "Invalid search for task status.")

                        End If

                        If (From item In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.ProjectSchedule.TaskStatus))
                            Where item.Code = Model.TaskStatusReplaceWith
                            Select item).Any = False Then

                            ModelState.AddModelError("TaskStatusReplaceWith", "Invalid replace with task status.")

                        End If

                    Case "Manager"

                        If String.IsNullOrWhiteSpace(Model.ManagerCodeSearchFor) = False Then

                            If Validator.ValidateEmpCode(Model.ManagerCodeSearchFor) = False Then

                                ModelState.AddModelError("ManagerCodeSearchFor", "Invalid search for employee.")

                            End If

                        End If

                        If String.IsNullOrWhiteSpace(Model.ManagerCodeReplaceWith) = False Then

                            If Validator.ValidateEmpCode(Model.ManagerCodeReplaceWith) = False Then

                                ModelState.AddModelError("ManagerCodeReplaceWith", "Invalid replace with employee.")

                            End If

                        End If

                    Case "TaskComment"

                        If String.IsNullOrWhiteSpace(Model.TaskCodeSearchFor) = False Then

                            If Validator.ValidateTaskCode(Model.TaskCodeSearchFor) = False Then

                                ModelState.AddModelError("TaskCodeSearchFor", "Invalid task code.")

                            End If

                        Else

                            ModelState.AddModelError("TaskCodeSearchFor", "Task Code is required.")

                        End If

                End Select

            End Using

            If ModelState.IsValid Then

                Controller = New AdvantageFramework.Controller.ProjectManagement.ProjectScheduleController(Me.SecuritySession)

                If Controller.FindAndReplace(Model) = False Then

                    ModelState.AddModelError("InternalError", "Something went wrong.")

                End If

            End If

            If ModelState.IsValid Then

                Return Json(New With {.Success = True, .Data = Model})

            Else


                Return Json(New With {.Success = False, .Data = ModelState.SerializeErrors()})

            End If

        End Function
        <System.Web.Mvc.HttpPost()>
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule")>
        Public Function SavePageSize(PageSize As Integer) As ActionResult

            MiscFN.SavePageSize(CopyToProjectSchedules_GridJobComponents, PageSize)

        End Function

        <HttpGet>
        Public Function LookupTasks() As ActionResult

            'objects
            Dim LookupModel As Webvantage.Models.LookupModel = Nothing

            LookupModel = New Models.LookupModel(Models.LookupModel.Types.Task)
            LookupModel.SetDefaultFilter(Models.LookupModel.Filters.Contains)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                With LookupModel

                    .DataItems = (From Item In AdvantageFramework.Database.Procedures.Task.LoadAllActive(DbContext)
                                  Order By Item.Description Ascending
                                  Select [Code] = Item.Code,
                                                   [Description] = Item.Description,
                                                   [CodeAndDescription] = Item.Description & " (" & Item.Code & ")").ToList

                End With

            End Using

            Return Lookup(LookupModel)

        End Function
        <HttpGet>
        Public Function LookupFunctions() As ActionResult

            'objects
            Dim LookupModel As Webvantage.Models.LookupModel = Nothing

            LookupModel = New Models.LookupModel(Models.LookupModel.Types.Function)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                With LookupModel

                    .DataItems = (From Item In AdvantageFramework.Database.Procedures.Function.LoadAllActive(DbContext)
                                  Where Item.Type = "E"
                                  Select [Code] = Item.Code,
                                                   [CodeAndDescription] = Item.Description & " (" & Item.Code & ")").ToList

                End With

            End Using

            Return Lookup(LookupModel)

        End Function
        <HttpGet>
        Public Function LookupStatus() As ActionResult

            'objects
            Dim LookupModel As Webvantage.Models.LookupModel = Nothing

            LookupModel = New Models.LookupModel(Models.LookupModel.Types.ProjectScheduleStatus)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                With LookupModel

                    .DataItems = (From Item In AdvantageFramework.Database.Procedures.Status.LoadAllActive(DbContext)
                                  Select [Code] = Item.Code,
                                                   [Description] = Item.Description,
                                                   [CodeAndDescription] = Item.Description & " (" & Item.Code & ")").ToList

                End With

            End Using

            Return Lookup(LookupModel)

        End Function
        <HttpGet>
        Public Function LookupClients() As ActionResult

            'objects
            Dim LookupModel As Webvantage.Models.LookupModel = Nothing

            LookupModel = New Models.LookupModel(Models.LookupModel.Types.Client)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    With LookupModel

                        .DataItems = (From Item In AdvantageFramework.ProjectSchedule.LookupClients(Me.SecuritySession, DbContext, SecurityDbContext)
                                      Select [Code] = Item.Code,
                                                         [Name] = Item.Name,
                                                         [CodeAndDescription] = Item.Name & " (" & Item.Code & ")").ToList

                    End With

                End Using

            End Using

            Return Lookup(LookupModel)

        End Function
        <HttpGet>
        Public Function LookupDivisions(Optional ClientCode As String = Nothing) As ActionResult

            'objects
            Dim LookupModel As Webvantage.Models.LookupModel = Nothing
            Dim Divisions As Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.DivisionView) = Nothing
            Dim AppendData As Boolean = True

            LookupModel = New Models.LookupModel(Models.LookupModel.Types.Division)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Divisions = AdvantageFramework.ProjectSchedule.LookupDivisions(Me.SecuritySession, DbContext, SecurityDbContext, ClientCode)

                    If Not String.IsNullOrWhiteSpace(ClientCode) Then

                        AppendData = False

                    End If

                    With LookupModel

                        .DataItems = (From Item In Divisions
                                      Let CodeAndDesc = Item.DivisionName & " (" & Item.DivisionCode & ")",
                                                      DataToAppend = If(AppendData, " | " & Item.ClientCode, "")
                                      Select New With {
                                                        .[ClientCode] = Item.ClientCode,
                                                        .[ClientName] = Item.ClientName,
                                                        .[Code] = Item.DivisionCode,
                                                        .[Name] = Item.DivisionName,
                                                        .[CodeAndDescription] = CodeAndDesc & DataToAppend
                                                      }).ToList

                    End With

                End Using

            End Using

            Return Lookup(LookupModel)

        End Function
        <HttpGet>
        Public Function LookupProducts(Optional ClientCode As String = Nothing, Optional DivisionCode As String = Nothing) As ActionResult

            'objects
            Dim LookupModel As Webvantage.Models.LookupModel = Nothing
            Dim Products As Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.ProductView) = Nothing
            Dim AppendData As Boolean = True

            LookupModel = New Models.LookupModel(Models.LookupModel.Types.Product)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Products = AdvantageFramework.ProjectSchedule.LookupProducts(Me.SecuritySession, DbContext, SecurityDbContext, ClientCode, DivisionCode)

                    If Not String.IsNullOrWhiteSpace(ClientCode) OrElse Not String.IsNullOrWhiteSpace(DivisionCode) Then

                        AppendData = False

                    End If

                    With LookupModel

                        .DataItems = (From Item In Products
                                      Let DataToAppend = If(AppendData, " | " & Item.ClientCode & " - " & Item.DivisionCode, ""),
                                                      CodeAndDesc = Item.ProductDescription & " (" & Item.ProductCode & ")" & DataToAppend
                                      Select New With {
                                                        .[ClientCode] = Item.ClientCode,
                                                        .[ClientName] = Item.ClientName,
                                                        .[DivisionCode] = Item.DivisionCode,
                                                        .[DivisionName] = Item.DivisionName,
                                                        .[Code] = Item.ProductCode,
                                                        .[Name] = Item.ProductDescription,
                                                        .[CodeAndDescription] = CodeAndDesc
                                                      }).ToList

                    End With

                End Using

            End Using

            Return Lookup(LookupModel)

        End Function
        <HttpGet>
        Public Function LookupJobs(Optional ClientCode As String = Nothing, Optional DivisionCode As String = Nothing, Optional ProductCode As String = Nothing, Optional IsCopy As Boolean = False, Optional ShowClosed As Boolean = False) As ActionResult

            'objects
            Dim LookupModel As Webvantage.Models.LookupModel = Nothing
            Dim JobComponentViews As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing
            Dim JobTraffics As Generic.List(Of AdvantageFramework.Database.Entities.JobTraffic) = Nothing

            LookupModel = New Models.LookupModel(Models.LookupModel.Types.Job)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                If Not IsCopy Then

                    ShowClosed = False

                End If

                JobComponentViews = AdvantageFramework.ProjectSchedule.LookupJobComponents(DbContext, Me.SecuritySession.UserCode, Nothing, ClientCode, DivisionCode, ProductCode, IsCopy, ShowClosed)

                JobTraffics = AdvantageFramework.Database.Procedures.JobTraffic.Load(DbContext).ToList

                If IsCopy = True Then

                    JobComponentViews = (From Item In JobComponentViews
                                         Join Schedule In JobTraffics On Item.JobNumber Equals Schedule.JobNumber And Item.JobComponentNumber Equals Schedule.JobComponentNumber
                                         Select Item).ToList

                Else

                    JobComponentViews = (From Item In JobComponentViews
                                         Group Join JobTrf In JobTraffics On Item.JobNumber Equals JobTrf.JobNumber And Item.JobComponentNumber Equals JobTrf.JobComponentNumber Into Group
                                         From Trf In Group.DefaultIfEmpty
                                         Where Trf Is Nothing
                                         Select Item).Distinct.ToList

                End If

                With LookupModel

                    .DataItems = (From Item In JobComponentViews.ToList
                                  Order By Item.JobNumber Descending
                                  Group By JobNumber = Item.JobNumber Into Group
                                  Select New With {
                                                      .[ClientCode] = Group.First.ClientCode,
                                                      .[ClientName] = Group.First.ClientName,
                                                      .[DivisionCode] = Group.First.DivisionCode,
                                                      .[DivisionName] = Group.First.DivisionName,
                                                      .[ProductCode] = Group.First.ProductCode,
                                                      .[ProductName] = Group.First.ProductDescription,
                                                      .[Number] = Group.First.JobNumber,
                                                      .[Description] = Group.First.JobDescription,
                                                      .[CodeAndDescription] = Group.First.JobNumber.ToString & " - " & Group.First.JobDescription & " | " & Group.First.ClientCode & " - " & Group.First.DivisionCode & " - " & Group.First.ProductCode,
                                                      .[JobComponentNumber] = If(Group.Count = 1, Group.First.JobComponentNumber, Nothing),
                                                      .[JobComponentDescription] = If(Group.Count = 1, Group.First.JobComponentDescription, Nothing)
                                                    }).ToList

                End With

            End Using

            Return Lookup(LookupModel)

        End Function
        <HttpGet>
        Public Function LookupJobComponents(IsCopy As Boolean, Optional JobNumber As Integer? = Nothing, Optional ClientCode As String = Nothing, Optional DivisionCode As String = Nothing, Optional ProductCode As String = Nothing, Optional ShowClosed As Boolean = False) As ActionResult

            'objects
            Dim LookupModel As Webvantage.Models.LookupModel = Nothing
            Dim JobComponentViews As List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing
            Dim JobTraffics As List(Of AdvantageFramework.Database.Entities.JobTraffic) = Nothing

            LookupModel = New Models.LookupModel(Models.LookupModel.Types.JobComponent)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                If Not IsCopy Then

                    ShowClosed = False

                    JobComponentViews = AdvantageFramework.ProjectSchedule.LookupJobComponents(DbContext, Me.SecuritySession.UserCode, JobNumber, ClientCode, DivisionCode, ProductCode, IsCopy, ShowClosed)
                    JobTraffics = AdvantageFramework.Database.Procedures.JobTraffic.Load(DbContext).ToList

                    With LookupModel

                        .DataItems = (From Item In JobComponentViews
                                      Join comp In (From jc In AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext)
                                                    Select New With {.JobNumber = jc.JobNumber,
                                                                           .JobComponentNumber = jc.Number,
                                                                           .TrafficScheduleRequired = jc.TrafficScheduleRequired}).ToList On Item.JobNumber Equals comp.JobNumber And Item.JobComponentNumber Equals comp.JobComponentNumber
                                      Where Not JobTraffics.Any(Function(jt) jt.JobNumber = Item.JobNumber AndAlso jt.JobComponentNumber = Item.JobComponentNumber)
                                      Order By Item.JobNumber Descending, Item.JobComponentNumber Ascending
                                      Select New With {
                                                      .[ClientCode] = Item.ClientCode,
                                                      .[ClientName] = Item.ClientName,
                                                      .[DivisionCode] = Item.DivisionCode,
                                                      .[DivisionName] = Item.DivisionName,
                                                      .[ProductCode] = Item.ProductCode,
                                                      .[ProductName] = Item.ProductDescription,
                                                      .[JobNumber] = Item.JobNumber,
                                                      .[JobDescription] = Item.JobDescription,
                                                      .[Number] = Item.JobComponentNumber,
                                                      .[Description] = Item.JobComponentDescription,
                                                      .[CodeAndDescription] = Item.JobNumber.ToString & "-" & Item.JobComponentNumber & " | " & Item.JobComponentDescription & " | " & Item.ClientCode & " - " & Item.DivisionCode & " - " & Item.ProductCode,
                                                      .[OnlyNeedsProjectSchedule] = comp.TrafficScheduleRequired.GetValueOrDefault(0) = 1 AndAlso Not JobTraffics.Any(Function(jt) jt.JobNumber = Item.JobNumber AndAlso jt.JobComponentNumber = Item.JobComponentNumber)
                                          }).ToList

                        If Not IsCopy Then

                            .SearchOptions.Add(New Models.LookupModel.SearchOption("OnlyNeedsProjectSchedule", "Only project schedule needed.", False))

                        End If

                    End With

                Else

                    JobComponentViews = AdvantageFramework.ProjectSchedule.LookupJobComponents(DbContext, Me.SecuritySession.UserCode, JobNumber, ClientCode, DivisionCode, ProductCode, IsCopy, ShowClosed)
                    JobTraffics = AdvantageFramework.Database.Procedures.JobTraffic.Load(DbContext).ToList

                    With LookupModel

                        .DataItems = (From Item In JobComponentViews
                                      Join comp In (From jc In AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext)
                                                    Select New With {.JobNumber = jc.JobNumber,
                                                                               .JobComponentNumber = jc.Number,
                                                                               .TrafficScheduleRequired = jc.TrafficScheduleRequired}).ToList On Item.JobNumber Equals comp.JobNumber And Item.JobComponentNumber Equals comp.JobComponentNumber
                                      Where JobTraffics.Any(Function(jt) jt.JobNumber = Item.JobNumber AndAlso jt.JobComponentNumber = Item.JobComponentNumber)
                                      Order By Item.JobNumber Descending, Item.JobComponentNumber Ascending
                                      Select New With {
                                                          .[ClientCode] = Item.ClientCode,
                                                          .[ClientName] = Item.ClientName,
                                                          .[DivisionCode] = Item.DivisionCode,
                                                          .[DivisionName] = Item.DivisionName,
                                                          .[ProductCode] = Item.ProductCode,
                                                          .[ProductName] = Item.ProductDescription,
                                                          .[JobNumber] = Item.JobNumber,
                                                          .[JobDescription] = Item.JobDescription,
                                                          .[Number] = Item.JobComponentNumber,
                                                          .[Description] = Item.JobComponentDescription,
                                                          .[CodeAndDescription] = Item.JobNumber.ToString & "-" & Item.JobComponentNumber & " | " & Item.JobComponentDescription & " | " & Item.ClientCode & " - " & Item.DivisionCode & " - " & Item.ProductCode,
                                                          .[OnlyNeedsProjectSchedule] = comp.TrafficScheduleRequired.GetValueOrDefault(0) = 1 AndAlso Not JobTraffics.Any(Function(jt) jt.JobNumber = Item.JobNumber AndAlso jt.JobComponentNumber = Item.JobComponentNumber)
                                              }).ToList

                        If Not IsCopy Then

                            .SearchOptions.Add(New Models.LookupModel.SearchOption("OnlyNeedsProjectSchedule", "Only project schedule needed.", False))

                        End If

                    End With

                End If



            End Using

            Return Lookup(LookupModel)

        End Function
        <HttpGet>
        Public Function LookupProjectManagers() As ActionResult

            'objects
            Dim LookupModel As Webvantage.Models.LookupModel = Nothing

            LookupModel = New Models.LookupModel(Models.LookupModel.Types.ProjectManager)
            LookupModel.SetDefaultFilter(Models.LookupModel.Filters.Contains)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    With LookupModel

                        .DataItems = (From Item In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveByUserCodeWithOfficeLimitsAndIncludeCurrentUser(Me.SecuritySession, DbContext, SecurityDbContext)
                                      Order By Item.LastName Ascending, Item.FirstName Ascending, Item.Code Ascending
                                      Select [Code] = Item.Code,
                                             [FirstName] = Item.FirstName,
                                             [LastName] = Item.LastName,
                                             [MiddleInitial] = Item.MiddleInitial).ToList _
                                      .Select(Function(e) New With {.Code = e.Code,
                                                                    .CodeAndDescription = e.LastName & ", " & e.FirstName & If(String.IsNullOrWhiteSpace(e.MiddleInitial), "", " " & e.MiddleInitial & ".") & " (" & e.Code & ")",
                                                                    .FullName = e.FirstName & " " & If(String.IsNullOrWhiteSpace(e.MiddleInitial), "", e.MiddleInitial & ". ") & e.LastName}).ToList

                    End With

                End Using

            End Using

            Return Lookup(LookupModel)

        End Function
        <HttpGet>
        Public Function LookupEmployees(Optional ShowAll As Boolean = False) As ActionResult

            'objects
            Dim LookupModel As Webvantage.Models.LookupModel = Nothing

            LookupModel = New Models.LookupModel(Models.LookupModel.Types.Employee)
            LookupModel.SetDefaultFilter(Models.LookupModel.Filters.Contains)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    With LookupModel

                        .DataItems = (From Item In AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCodeWithOfficeLimits(Me.SecuritySession, DbContext, SecurityDbContext)
                                      Where If(ShowAll = False, Item.TerminationDate Is Nothing, True)
                                      Order By Item.LastName Ascending, Item.FirstName Ascending, Item.Code Ascending
                                      Select [Code] = Item.Code,
                                             [FirstName] = Item.FirstName,
                                             [LastName] = Item.LastName,
                                             [MiddleInitial] = Item.MiddleInitial).ToList _
                                      .Select(Function(e) New With {.Code = e.Code,
                                                                    .CodeAndDescription = e.LastName & ", " & e.FirstName & If(String.IsNullOrWhiteSpace(e.MiddleInitial), "", " " & e.MiddleInitial & ".") & " (" & e.Code & ")",
                                                                    .FullName = e.FirstName & " " & If(String.IsNullOrWhiteSpace(e.MiddleInitial), "", e.MiddleInitial & ". ") & e.LastName}).ToList

                    End With

                End Using

            End Using

            Return Lookup(LookupModel)

        End Function
        <HttpGet>
        Public Function LookupClientContacts(ClientCode As String, Optional ShowAll As Boolean = False) As ActionResult

            'objects
            Dim LookupModel As Webvantage.Models.LookupModel = Nothing

            LookupModel = New Models.LookupModel(Models.LookupModel.Types.ClientContact)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    With LookupModel

                        .DataItems = (From Item In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, ClientCode).ToList
                                      Where If(ShowAll = False, (Item.IsInactive Is Nothing OrElse Item.IsInactive = 0), True) AndAlso
                                                        Item.ScheduleUser = 1
                                      Order By Item.LastName, Item.FirstName, Item.ContactCode
                                      Select New With {.Code = Item.ContactCode,
                                                                   .Description = Item.ToString(),
                                                                   .CodeAndDescription = Item.LastName & ", " & Item.FirstName & If(String.IsNullOrWhiteSpace(Item.MiddleInitial), "", " " & Item.MiddleInitial & ".") & " (" & Item.ContactCode & ")",
                                                                   .ID = Item.ContactID}).ToList

                    End With

                End Using

            End Using

            Return Lookup(LookupModel)

        End Function
        <HttpGet>
        Public Function LookupPhases() As ActionResult

            'objects
            Dim LookupModel As Webvantage.Models.LookupModel = Nothing

            LookupModel = New Models.LookupModel(Models.LookupModel.Types.Employee)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    With LookupModel

                        .DataItems = (From Item In AdvantageFramework.Database.Procedures.Phase.LoadAllActive(DbContext)
                                      Order By Item.OrderNumber Ascending
                                      Select [Code] = Item.ID,
                                                         [CodeAndDescription] = Item.Description).ToList

                    End With

                End Using

            End Using

            Return Lookup(LookupModel)

        End Function
        <AcceptVerbs("POST")>
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule")>
        Public Function Create(JobNumber As Integer, JobComponentNumber As Short, TrafficStatus As String, Optional ProjectManager As String = Nothing, Optional IsCopy As Boolean = False,
                                   Optional CopyJobNumber As Integer? = Nothing, Optional CopyJobComponentNumber As Short? = Nothing, Optional IncludeStartDate As Boolean = False,
                                   Optional IncludeDueDate As Boolean = False, Optional IncludeTaskEmployees As Boolean = False, Optional IncludeTaskComment As Boolean = False,
                                   Optional IncludeDueDateComment As Boolean = False, Optional ShowClosed As Boolean = False, Optional IncludeTaskStatus As Boolean = False) As JsonResult

            'objects
            Dim ErrorList As Generic.List(Of String) = Nothing
            Dim ReturnObject As Object = Nothing
            Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
            Dim Success As Boolean = False

            If AdvantageFramework.ProjectSchedule.CreateSchedule(Me.SecuritySession, JobNumber, JobComponentNumber, TrafficStatus, ProjectManager, IsCopy, CopyJobNumber, CopyJobComponentNumber, IncludeStartDate,
                                                                       IncludeDueDate, IncludeTaskEmployees, IncludeTaskComment, IncludeDueDateComment, ShowClosed, IncludeTaskStatus, ErrorList) Then


                QueryString = New AdvantageFramework.Web.QueryString

                With QueryString

                    .Page = "Content.aspx"
                    .JobNumber = JobNumber
                    .JobComponentNumber = JobComponentNumber
                    .ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule

                End With

                Success = True

                ReturnObject = New With {
                            .URL = QueryString.ToString(True)
                        }

            Else

                Success = False

                ReturnObject = New With {
                                .Errors = ErrorList
                            }

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, Nothing, ReturnObject))

        End Function
        <HttpPost>
        Public Function ReorderColumns(Columns As IEnumerable(Of AdvantageFramework.Database.Classes.TrafficScheduleUserColumn)) As JsonResult

            'objects
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim HeaderCode As String = Nothing

            If Columns IsNot Nothing AndAlso Columns.Count > 0 Then

                StringBuilder = New Text.StringBuilder

                If MiscFN.IsClientPortal Then

                    HeaderCode = Me.SecuritySession.ClientPortalUser.UserName

                Else

                    HeaderCode = Me.SecuritySession.User.EmployeeCode

                End If

                For Each Column In Columns

                    StringBuilder.AppendLine(String.Format("UPDATE dbo.JOB_TRAFFIC_SETUP_DTL SET COLUMN_ORDER = {0} WHERE COLUMN_ID = {1} And HDR_CODE = '{2}'; ", Column.ColumnOrder, Column.ID, HeaderCode))

                Next

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Try

                        DbContext.Database.ExecuteSqlCommand(StringBuilder.ToString)

                    Catch ex As Exception

                    End Try

                End Using

            End If

        End Function
        Public Function CopyToJobComponents_Read(<Kendo.Mvc.UI.DataSourceRequest> DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest,
                                                     JobNumber As Integer, JobComponentNumber As Short) As ActionResult

            'objects
            Dim JobComponents As Generic.List(Of AdvantageFramework.ViewModels.ProjectSchedule.CopyToProjectScheduleJobComponentViewModel) = Nothing
            Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing
            Dim JsonResult As JsonResult = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                JobComponents = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.ProjectSchedule.CopyToProjectScheduleJobComponentViewModel)("EXEC dbo.advsp_project_schedule_copyto_load_jobcomp '" & Me.SecuritySession.UserCode & "'").Where(Function(Entity) Not (Entity.JobNumber = JobNumber AndAlso
                                                                                                                                                                                                                                                                                          Entity.JobComponentNumber = JobComponentNumber)).ToList

            End Using

            DataSourceResult = JobComponents.ToDataSourceResult(DataSourceRequest)
            JsonResult = Json(DataSourceResult, JsonRequestBehavior.AllowGet)
            JsonResult.MaxJsonLength = Integer.MaxValue

            Return JsonResult

        End Function
        Public Function CopyToJobComponents_GetJobComponentIDs(<Kendo.Mvc.UI.DataSourceRequest> DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest,
                                                                    JobNumber As Integer, JobComponentNumber As Short) As ActionResult

            'objects
            Dim JobComponents As Generic.List(Of AdvantageFramework.ViewModels.ProjectSchedule.CopyToProjectScheduleJobComponentViewModel) = Nothing
            Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing
            Dim JsonResult As JsonResult = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                JobComponents = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.ProjectSchedule.CopyToProjectScheduleJobComponentViewModel)("EXEC dbo.advsp_project_schedule_copyto_load_jobcomp '" & Me.SecuritySession.UserCode & "'").Where(Function(Entity) Not (Entity.JobNumber = JobNumber AndAlso
                                                                                                                                                                                                                                                                                          Entity.JobComponentNumber = JobComponentNumber)).ToList

            End Using

            DataSourceResult = JobComponents.ToDataSourceResult(DataSourceRequest)

            DataSourceResult.Data = DataSourceResult.Data.OfType(Of AdvantageFramework.ViewModels.ProjectSchedule.CopyToProjectScheduleJobComponentViewModel).Select(Function(Entity) New With {.ID = Entity.ID})
            JsonResult = Json(DataSourceResult, JsonRequestBehavior.AllowGet)
            JsonResult.MaxJsonLength = Integer.MaxValue

            Return JsonResult

        End Function


        <HttpPost>
        Public Function BookMarkPage(ByVal Office As String,
                                     ByVal Client As String,
                                     ByVal Division As String,
                                     ByVal Product As String,
                                     ByVal SalesClass As String,
                                     ByVal Campaign As Integer?,
                                     ByVal JobNumber As Integer?,
                                     ByVal ComponentNumber As Integer?,
                                     ByVal AccountExecutive As String,
                                     ByVal JobType As String,
                                     ByVal JobStatus As String,
                                     ByVal projectManagerCode As String,
                                     ByVal phaseCode As String,
                                     ByVal roleCode As String,
                                     ByVal taskCode As String,
                                     ByVal employeeCode As String,
                                     Optional ByVal dateCutoff As Date? = Nothing
                                     ) As JsonResult
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            With qs
                .OfficeCode = Office
                .ClientCode = Client
                .DivisionCode = Division
                .ProductCode = Product
                .SalesClassCode = SalesClass
                .CampaignIdentifier = Campaign
                If JobNumber IsNot Nothing Then
                    .JobNumber = JobNumber
                End If
                If ComponentNumber IsNot Nothing Then
                    .JobComponentNumber = ComponentNumber
                End If
                .AccountExecutiveCode = AccountExecutive
                .Add("jt", JobType)
                .Add("js", JobStatus)
                .Add("isbookmark", "1")
                .Add("projectManagerCode", projectManagerCode)
                .Add("phaseCode", phaseCode)
                .Add("roleCode", roleCode)
                .Add("taskCode", taskCode)
                .Add("employeeCode", employeeCode)
                If (dateCutoff IsNot Nothing) Then
                    .Add("dateCutoff", dateCutoff.Value.ToShortDateString)
                End If
                .Build()
            End With

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule
                .UserCode = Session("UserCode")
                .Name = "Project Schedule Search"
                .PageURL = "modules/project-management/project-schedule/project-schedule-search" & qs.ToString()

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                'Me.ShowMessage(s)
            End If

        End Function

        <HttpPost>
        Public Function BookMarkPagePSEdit(ByVal Office As String,
                                         ByVal Client As String,
                                         ByVal Division As String,
                                         ByVal Product As String,
                                         ByVal SalesClass As String,
                                         ByVal Campaign As Integer,
                                         ByVal JobNumber As Integer?,
                                         ByVal ComponentNumber As Integer?,
                                         ByVal AccountExecutive As String,
                                         ByVal JobTypeCode As String,
                                         ByVal StatusCode As String,
                                         ByVal ProjectManagerCode As String,
                                         ByVal PhaseCode As String,
                                         ByVal EmployeeCode As String,
                                         ByVal TaskCode As String,
                                         ByVal RoleCode As String,
                                         ByVal ExcludeCompletedSchedules As Boolean,
                                         ByVal OnlyPendingTasks As Boolean,
                                         ByVal ExcludeProjectedTasks As Boolean,
                                         ByVal IncludeCompletedTasks As Boolean,
                                         ByVal OnlyScheduleTemplates As Boolean,
                                         ByVal CutOffDate As Date?
                                         ) As JsonResult
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            With qs
                .Add("OfficeCode", Office)
                .Add("ClientCode", Client)
                .Add("DivisionCode", Division)
                .Add("ProductCode", Product)
                .Add("SalesClassCode", SalesClass)
                .Add("CampaignID", Campaign)
                If JobNumber IsNot Nothing Then
                    .Add("JobNumber", JobNumber)
                End If
                If ComponentNumber IsNot Nothing Then
                    .Add("JobComponentNbr", ComponentNumber)
                End If
                .Add("AccountExecutiveCode", AccountExecutive)
                .Add("JobTypeCode", JobTypeCode)
                .Add("StatusCode", JobTypeCode)
                .Add("ProjectManagerCode", JobTypeCode)
                .Add("PhaseCode", JobTypeCode)
                .Add("EmployeeCode", EmployeeCode)
                .Add("TaskCode", TaskCode)
                .Add("RoleCode", RoleCode)
                .Add("ExcludeCompletedSchedules", ExcludeCompletedSchedules)
                .Add("OnlyPendingTasks", OnlyPendingTasks)
                .Add("ExcludeProjectedTasks", ExcludeProjectedTasks)
                .Add("IncludeCompletedTasks", IncludeCompletedTasks)
                .Add("OnlyScheduleTemplates", OnlyScheduleTemplates)
                .Add("CutoffDate", CutOffDate)
                .Add("isbookmark", "1")
                .Build()
            End With

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule
                .UserCode = Session("UserCode")
                .Name = "Project Schedule Multi Edit"
                .PageURL = "ProjectManagement_ProjectSchedule_EditView" & qs.ToString()

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                'Me.ShowMessage(s)
            End If

        End Function

        <HttpPost>
        Public Function BookMarkPagePS(ByVal JobNumber? As Integer, ByVal JobComponentNumber? As Integer) As JsonResult
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            With qs
                If JobNumber IsNot Nothing Then
                    .JobNumber = JobNumber
                End If
                If JobComponentNumber IsNot Nothing Then
                    .JobComponentNumber = JobComponentNumber
                End If
                .Add("isbookmark", "1")
                .Add("contaid", "15")
                .Build()
            End With

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule
                .UserCode = Session("UserCode")
                .Name = JobNumber.ToString().PadLeft(6, "0") & "-" & JobComponentNumber.ToString().PadLeft(2, "0") & " - Schedule"
                .Description = JobNumber.ToString().PadLeft(6, "0") & "-" & JobComponentNumber.ToString().PadLeft(2, "0") & " - Schedule"
                .PageURL = "Content.aspx" & qs.ToString()

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                'Me.ShowMessage(s)
            End If

        End Function

        <HttpPost>
        Public Function PrintProjectScheduleEdit(ByVal JobComps As String, ByVal JobCompCount As Integer) As JsonResult

            Try
                Dim filename As String
                Dim StrFilePrefix As String = Request.PhysicalApplicationPath & "TEMP\"

                Select Case JobCompCount
                    Case 0
                       ' Me.ShowMessage("No file(s) selected.")
                    Case 1
                        'Dim jc() As String = JobComps.Split("/")
                        'Dim j As String = jc(0)
                        'Dim c As String = MiscFN.RemoveTrailingDelimiter(jc(1), ",")

                        'Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
                        'oAppVars.getAllAppVars()
                        'Dim s As String = ""
                        's = oAppVars.getAppVar("Location")

                        'Dim ar() As String
                        'Try
                        '    If s = "[None]" Then
                        '        Session("PSLogoLocation") = ""
                        '        Session("PSLogoLocationID") = "None"
                        '    Else
                        '        ar = s.ToString.Split("|")
                        '        Session("PSLogoLocation") = ar(1)
                        '        Session("PSLogoLocationID") = ar(0)
                        '    End If

                        'Catch ex As Exception
                        '    Session("PSLogoLocation") = ""
                        'End Try

                        'Dim strURL As String = "popReportViewer.aspx?job= " & j & " & jobcomp = " & c & " & MS = False&Type=1&Report=TrafficDetailByJob"
                        'Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
                        'strBuilder.Append("<script language='javascript'>")
                        'strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                        'strBuilder.Append("</")
                        'strBuilder.Append("script>")
                        'Page.RegisterStartupScript("newpage", strBuilder.ToString())
                    Case Is > 1
                        Try
                            Dim outputStream As New System.IO.MemoryStream
                            Dim strfiles As String

                            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
                            oAppVars.getAllAppVars()
                            Dim s As String = ""
                            s = oAppVars.getAppVar("Location")

                            Dim ar() As String
                            Try
                                If s = "[None]" Then
                                    Session("PSLogoLocation") = ""
                                    Session("PSLogoLocationID") = "None"
                                Else
                                    ar = s.ToString.Split("|")
                                    Session("PSLogoLocation") = ar(1)
                                    Session("PSLogoLocationID") = ar(0)
                                End If

                            Catch ex As Exception
                                Session("PSLogoLocation") = ""
                            End Try

                            'Dim zipOutStream As New ZipOutputStream(outputStream)
                            'zipOutStream.SetLevel(5) ' Medium compression

                            'Dim RepositorySecuritySettings As New vDocumentRepositorySettings(Session("ConnString"))
                            'RepositorySecuritySettings.LoadAll()
                            'Dim ThisUserDomain As String = RepositorySecuritySettings.DOC_REPOSITORY_USER_DOMAIN
                            'Dim ThisUserName As String = RepositorySecuritySettings.DOC_REPOSITORY_USER_NAME

                            'Dim ThisUserPassword As String = AdvantageFramework.Security.Encryption.Decrypt(RepositorySecuritySettings.DOC_REPOSITORY_USER_PASSWORD)
                            'Dim ThisPath = RepositorySecuritySettings.DOC_REPOSITORY_PATH

                            'Dim impersonateUser As Boolean = False
                            'Dim AliasAccount As AliasAccount
                            'impersonateUser = ThisUserName <> ""

                            'If impersonateUser = True Then
                            '    AliasAccount.BeginImpersonation(ThisUserName, ThisUserDomain, ThisUserPassword)
                            'End If

                            Dim zip As New Ionic.Zip.ZipFile

                            Dim jc() As String = JobComps.Split(",")
                            For i As Integer = 0 To jc.Length - 1
                                Dim jobc As String
                                jobc = jc(i)
                                If jobc <> "" Then
                                    Dim jobcomp() As String = jobc.Split("/")

                                    filename = Me.OutputReportFile(jobcomp(0), jobcomp(1))
                                    Dim f As New IO.FileInfo(StrFilePrefix & filename)
                                    If f.Exists Then


                                        zip.AddFile(StrFilePrefix & filename, "")
                                        strfiles &= filename & "|"
                                        'Dim Repository As New DocumentRepository(Session("ConnString"))
                                        'Dim FileBytes() As Byte
                                        'FileBytes = Repository.GetDocumentByteArray(StrFilePrefix, filename, True)

                                        'Dim ZipEntry As New ZipEntry(filename)
                                        'ZipEntry.DateTime = Now.Date
                                        'zipOutStream.PutNextEntry(ZipEntry)
                                        'zipOutStream.Write(FileBytes, 0, FileBytes.Length)
                                        'zipOutStream.Flush()



                                    End If
                                End If
                            Next

                            zip.Save(Response.OutputStream)

                            Dim str() As String = strfiles.Split("|")
                            For x As Integer = 0 To str.Length - 1
                                If str(x) <> "" Then
                                    Try
                                        My.Computer.FileSystem.DeleteFile(StrFilePrefix & str(x).Trim)
                                    Catch ex As Exception
                                        'lbl_msg.Text = ex.Message.ToString
                                    End Try
                                    Try
                                        Kill(StrFilePrefix & str(x).Trim)
                                    Catch ex As Exception
                                        'lbl_msg.Text = ex.Message.ToString
                                    End Try
                                End If
                            Next

                            'If impersonateUser = True Then
                            '    AliasAccount.EndImpersonation()
                            'End If

                            'zipOutStream.Finish()
                            'outputStream.Flush()
                            'OutputStream.Close()

                            'OutputStream = New System.IO.FileStream(TempFilename, IO.FileMode.Open, IO.FileAccess.Read)
                            'Dim OutputBytes(outputStream.Length) As Byte

                            'OutputBytes = outputStream.ToArray
                            'outputStream.Read(OutputBytes, 0, outputStream.Length)
                            'outputStream.Close()
                            'zipOutStream.Close()

                            'Response.Buffer = True
                            Response.AddHeader("Content-Disposition", "filename=Webvantage_Project_Schedules__" & Today.Year.ToString() & Today.Month.ToString() & Today.Day.ToString() & ".zip")
                            'Response.ContentType = "application/x-zip-compressed"
                            Response.ContentType = "application/zip"
                            'Response.AddHeader("Content-Length", OutputBytes.Length.ToString())

                            'Response.BinaryWrite(OutputBytes)
                            'Response.Flush()
                            Response.End()


                        Catch ex As Exception

                        End Try
                End Select
            Catch ex As Exception

            End Try

        End Function

        Private Function OutputReportFile(ByVal job As String, ByVal comp As String) As String
            Dim StrFileName As String = ""
            'Dim StrImagePath As String = Request.PhysicalApplicationPath & "\Images\logo_print.gif"
            Dim r As cReports = New cReports(Session("ConnString"))
            Dim StrFilePrefix As String = Request.PhysicalApplicationPath.Trim & "TEMP\"
            Dim StrFileDate As String = "__" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString() & Now.Hour.ToString() & Now.Minute.ToString
            Dim StrFileType As String = ".PDF"
            StrFileName = "Project_Schedule_" & job & "_" & comp & StrFileDate & StrFileType

            Dim rpt As New popReportViewer
            Try
                Dim ThisOptions As String = job & "|" & comp
                rpt.renderDoc(StrFilePrefix & StrFileName, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions)
            Catch ex As Exception
                StrFileName = ""
            End Try
            Return StrFileName
        End Function

        <HttpGet>
        Public Function Search(ByVal OfficeCode As String,
                                        ByVal ClientCode As String,
                                        ByVal DivisionCode As String,
                                        ByVal ProductCode As String,
                                        ByVal SalesClassCode As String,
                                        ByVal CampaignID As Integer,
                                        ByVal JobNumber As Integer,
                                        ByVal ComponentNumber As Integer,
                                        ByVal AccountExecutiveCode As String,
                                        ByVal JobTypeCode As String,
                                        ByVal StatusCode As String,
                                        ByVal ProjectManagerCode As String,
                                        ByVal PhaseCode As String,
                                        ByVal EmployeeCode As String,
                                        ByVal TaskCode As String,
                                        ByVal RoleCode As String,
                                        ByVal ExcludeCompletedSchedules As Boolean,
                                        ByVal OnlyPendingTasks As Boolean,
                                        ByVal ExcludeProjectedTasks As Boolean,
                                        ByVal IncludeCompletedTasks As Boolean,
                                        ByVal OnlyScheduleTemplates As Boolean,
                                        ByVal DateCutoff As Date?,
                                        Optional ByVal Skip As Integer = 0,
                                        Optional ByVal Take As Integer = 0
                                        ) As JsonResult

            'objects
            Dim Schedules As IEnumerable = Nothing
            Dim totalRows As Integer

            Try


                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim arParams As New List(Of SqlParameter)
                    arParams.Add(New SqlParameter("@JOB_NUMBER", JobNumber))
                    arParams.Add(New SqlParameter("@JOB_COMPONENT_NBR", ComponentNumber))
                    arParams.Add(New SqlParameter("@USER_ID", Me.SecuritySession.UserCode))
                    arParams.Add(New SqlParameter("@CL_CODE", ClientCode))
                    arParams.Add(New SqlParameter("@DIV_CODE", DivisionCode))
                    arParams.Add(New SqlParameter("@PRD_CODE", ProductCode))
                    arParams.Add(New SqlParameter("@EMP_CODE", EmployeeCode))
                    arParams.Add(New SqlParameter("@MGR_CODE", ProjectManagerCode))
                    arParams.Add(New SqlParameter("@AE_CODE", AccountExecutiveCode))
                    arParams.Add(New SqlParameter("@TASK_CODE", TaskCode))
                    arParams.Add(New SqlParameter("@ROLE_CODE", RoleCode))
                    arParams.Add(New SqlParameter("@SHOW_ONLY_OPEN_SCHEDS", If(ExcludeCompletedSchedules = True, 1, 0)))
                    arParams.Add(New SqlParameter("@IncludeCompletedTasks", If(IncludeCompletedTasks = True, 1, 0)))
                    arParams.Add(New SqlParameter("@IncludeOnlyPendingTasks", If(OnlyPendingTasks = True, 1, 0)))
                    arParams.Add(New SqlParameter("@ExcludeProjectedTasks", If(ExcludeProjectedTasks = True, 1, 0)))
                    arParams.Add(New SqlParameter("@CMP_ID", CampaignID))
                    arParams.Add(New SqlParameter("@INCLUDE_CLOSE_JOBS", 0))
                    arParams.Add(New SqlParameter("@MILESTONES_ONLY", 0))
                    arParams.Add(New SqlParameter("@TRAFFIC_STATUS_CODE", StatusCode))
                    arParams.Add(New SqlParameter("@GANTT", 0))
                    arParams.Add(New SqlParameter("@OFFICE_CODE", OfficeCode))
                    arParams.Add(New SqlParameter("@SC_CODE", SalesClassCode))
                    arParams.Add(New SqlParameter("@JT_CODE", JobTypeCode))
                    arParams.Add(New SqlParameter("@ONLY_SCHEDULE_TEMPLATES", If(OnlyScheduleTemplates = True, 1, 0)))
                    arParams.Add(New SqlParameter("@TRAFFIC_PHASE_ID", PhaseCode))

                    Dim DateCutofParamater As SqlParameter = New SqlParameter("@CUT_OFF_DATE", DbType.Date)
                    DateCutofParamater.Value = If(DateCutoff Is Nothing, DBNull.Value, DateCutoff)
                    arParams.Add(DateCutofParamater)

                    arParams.Add(New SqlParameter("@Skip", Skip))
                    arParams.Add(New SqlParameter("@Take", Take))
                    Dim outParam As SqlParameter = New SqlParameter()
                    outParam.SqlDbType = System.Data.SqlDbType.Int
                    outParam.ParameterName = "@TotalRows"
                    outParam.Value = 0
                    outParam.Direction = System.Data.ParameterDirection.Output
                    arParams.Add(outParam)


                    '@CUT_OFF_DATE,,@TRAFFIC_PHASE_ID
                    Dim Command As String = "EXEC [dbo].[usp_wv_Traffic_Schedule_GetScheduleHeader_V3] @JOB_NUMBER, @JOB_COMPONENT_NBR, @USER_ID, @CL_CODE, @DIV_CODE, @PRD_CODE, @EMP_CODE, @MGR_CODE,@AE_CODE, @TASK_CODE, @ROLE_CODE, @CUT_OFF_DATE,@SHOW_ONLY_OPEN_SCHEDS, @IncludeCompletedTasks, @IncludeOnlyPendingTasks,@ExcludeProjectedTasks,@CMP_ID,@INCLUDE_CLOSE_JOBS,@MILESTONES_ONLY, @TRAFFIC_STATUS_CODE,@GANTT,@OFFICE_CODE,@SC_CODE,@JT_CODE,@ONLY_SCHEDULE_TEMPLATES,@TRAFFIC_PHASE_ID, @Skip, @Take, @TotalRows out;"

                    Try
                        Schedules = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.ProjectManagement.ProjectSchedule.ProjectScheduleSearchDTO)(Command, arParams.ToArray).ToList
                    Catch ex As Exception

                    End Try

                    If Not IsDBNull(outParam.Value) Then
                        totalRows = outParam.Value
                    End If


                End Using

            Catch ex As Exception

            End Try

            Return MaxJson(New With {.total = totalRows, .data = Schedules}, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function CanAdd() As JsonResult

            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission
            Dim HasAccess As Boolean = False

            Dim _Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, Session("ConnString"), Session("UserCode"), CInt(Session("AdvantageUserLicenseInUseID")), Session("ConnString"))


            Using DbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext,
                                                                                                                     AdvantageFramework.Security.Application.Webvantage,
                                                                                                                     AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule.ToString("F"),
                                                                                                                     _Session.User.ID)

                HasAccess = UserPermission.CanAdd

            End Using

            Return Json(HasAccess, JsonRequestBehavior.AllowGet)

        End Function

        <HttpPost>
        Function Update(ByVal ProjectSchedule As AdvantageFramework.ViewModels.ProjectManagement.ProjectSchedule.ProjectScheduleSearchDTO) As JsonResult
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            Dim Updated As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, ProjectSchedule.JobNumber, ProjectSchedule.JobComponentNumber)
                JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, ProjectSchedule.JobNumber, ProjectSchedule.JobComponentNumber)

                If JobTraffic IsNot Nothing Then

                    With JobTraffic
                        .TrafficCode = ProjectSchedule.StatusCode
                        .PercentComplete = ProjectSchedule.GutPercent
                        .CompletedDate = ProjectSchedule.CompletedDate
                        .TrafficComments = ProjectSchedule.Comments
                    End With

                    Updated = AdvantageFramework.Database.Procedures.JobTraffic.Update(DbContext, JobTraffic)

                End If

                If JobComponent IsNot Nothing Then

                    With JobComponent
                        .StartDate = ProjectSchedule.StartDate
                        .DueDate = ProjectSchedule.DueDate
                    End With

                    Updated = AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent)

                End If

            End Using


            Return Json(ProjectSchedule, "application/json", JsonRequestBehavior.AllowGet)
        End Function


        <HttpGet>
        Public Function SearchCampaignByClient(ClientCode As String) As JsonResult

            'objects
            Dim Campaigns As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Campaigns = (From Item In DbContext.Campaigns
                             Where Item.ClientCode = ClientCode AndAlso
                                   (Item.IsClosed Is Nothing OrElse Item.IsClosed = 0)
                             Select New With {.Code = Item.ID, .Name = Item.Name}).ToList

            End Using

            Return MaxJson(Campaigns, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Function SearchContacts(ByVal ClientCode As String, ByVal DivCode As String, ByVal ProdCode As String) As JsonResult
            Dim Tasks As IEnumerable = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@ClientCode", ClientCode))
                arParams.Add(New SqlParameter("@DivCode", DivCode))
                arParams.Add(New SqlParameter("@ProdCode", ProdCode))

                Tasks = (From Task In DbContext.Database.SqlQuery(Of IDCodeName)("select CDP_CONTACT_HDR.CDP_CONTACT_ID ID, CONT_CODE Code, CONT_FML Name from CDP_CONTACT_HDR 
                    left join CDP_CONTACT_DTL on CDP_CONTACT_HDR.CDP_CONTACT_ID = CDP_CONTACT_DTL.CDP_CONTACT_ID
                    where ISNULL(CDP_CONTACT_HDR.INACTIVE_FLAG,0) = 0 and CDP_CONTACT_HDR.SCHEDULE_USER = 1 AND
					CL_CODE = @ClientCode and (DIV_CODE = @DivCode or DIV_CODE is null) and (PRD_CODE=@ProdCode or PRD_CODE is null)", arParams.ToArray)
                         Select New With {.Code = Task.Code, .Name = Task.Name, .ID = Task.ID}
                                 ).ToList

            End Using

            Return MaxJson(Tasks, JsonRequestBehavior.AllowGet)
        End Function


        Public Function SearchPhases(Optional IncludeNoFilter As Boolean = False, Optional IncludeNone As Boolean = False) As JsonResult

            'objects
            Dim Phases As IEnumerable = Nothing
            Dim ExtraPhases As Generic.Dictionary(Of Integer, String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                'ExtraPhases = New Dictionary(Of Integer, String)

                'If IncludeNoFilter Then

                '    ExtraPhases.Add(-1, "[No Filter]")

                'End If

                'If IncludeNone Then

                '    ExtraPhases.Add(0, "[None]")

                'End If

                Phases = (From Item In AdvantageFramework.Database.Procedures.Phase.LoadAllActive(DbContext)
                          Order By Item.Description
                          Select Code = Item.ID, Name = Item.Description
                          ).ToList

            End Using

            Return Json(Phases, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchRole() As JsonResult

            Dim Roles As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                Roles = (From Role In AdvantageFramework.Database.Procedures.Role.LoadAllActive(DbContext)
                         Select New With {.Code = Role.Code,
                                    .Name = Role.Description}).ToList

            End Using

            Return MaxJson(Roles, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchTask() As JsonResult

            Dim Tasks As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                Tasks = (From Task In AdvantageFramework.Database.Procedures.Task.LoadAllActive(DbContext)
                         Order By Task.Description
                         Select New With {.Code = Task.Code,
                                    .Name = Task.Description}).ToList

            End Using

            Return MaxJson(Tasks, JsonRequestBehavior.AllowGet)

        End Function

        Public Class FUBAR
            Public Property [End] As Date
            Public Property Start As Date
            Public Property Title As String
            Public Property TaskDescription As String
            Public Property SequenceNumber As Short
            Public Property ID As Short
            Public Property PercentComplete As Decimal?
        End Class

        Public Function ReadGanttTask(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, Optional ByVal Sort As String = "", Optional ByVal Gantt As Integer = 0) As JsonResult

            Dim Tasks As List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = New List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                Dim Offset As Decimal = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, Me.SecuritySession.User.EmployeeCode)

                ' lets forget all the bs and just load what we need.
                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@JOB_NUMBER", JobNumber))
                arParams.Add(New SqlParameter("@JOB_COMPONENT_NBR", JobComponentNumber))
                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@Sort", Sort))
                arParams.Add(New SqlParameter("@Gantt", Gantt))

                DbContext.Database.ExecuteSqlCommand("EXEC advsp_agile_add_task_assignments_for_job @JOB_NUMBER, @JOB_COMPONENT_NBR,@UserID", arParams.ToArray)


                Tasks = DbContext.Database.SqlQuery(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)("exec usp_wv_Traffic_Schedule_GetTasks_V2
                                                                                                                    @JOB_NUMBER,
                                                                                                                    @JOB_COMPONENT_NBR,
                                                                                                                    @Sort,
                                                                                                                    @UserID,
                                                                                                                    '',
                                                                                                                    '',
                                                                                                                    '',
                                                                                                                    'Y',
                                                                                                                    'N',
                                                                                                                    'N',
                                                                                                                    null,
                                                                                                                    '',
                                                                                                                    @Gantt",
                                                                                                                    arParams.ToArray).ToList


                For Each Task In Tasks
                    Dim arParams2 As New List(Of SqlParameter)
                    arParams2.Add(New SqlParameter("@JOB_NUMBER", JobNumber))
                    arParams2.Add(New SqlParameter("@JOB_COMPONENT_NBR", JobComponentNumber))
                    arParams2.Add(New SqlParameter("@SequenceNumber", Task.SequenceNumber))
                    Task.PredecessorSequenceNumbers = DbContext.Database.SqlQuery(Of Short)("SELECT [PREDECESSOR_SEQ_NBR] FROM dbo.JOB_TRAFFIC_DET_PREDS WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND SEQ_NBR=@SequenceNumber", arParams2.ToArray).ToArray

                    Task.PredecessorLevelNotation = String.Join(", ", (From Item In Tasks
                                                                       Where Task.PredecessorSequenceNumbers.Contains(Item.SequenceNumber)
                                                                       Select Item.Level).ToArray)

                    If Offset < 0 Then

                        If (Task.JobCompletedDate IsNot Nothing) Then
                            Task.JobCompletedDate = Task.JobCompletedDate.Value.AddHours(-Offset)
                        End If

                        If (Task.JobDueDate IsNot Nothing) Then
                            Task.JobDueDate = Task.JobDueDate.Value.AddHours(-Offset)
                        End If

                        If (Task.JobRevisedDate IsNot Nothing) Then
                            Task.JobRevisedDate = Task.JobRevisedDate.Value.AddHours(-Offset)
                        End If

                        If (Task.PhaseEndDate IsNot Nothing) Then
                            Task.PhaseEndDate = Task.PhaseEndDate.Value.AddHours(-Offset)
                        End If

                        If (Task.PhaseStartDate IsNot Nothing) Then
                            Task.PhaseStartDate = Task.PhaseStartDate.Value.AddHours(-Offset)
                        End If

                        If (Task.TaskStartDate IsNot Nothing) Then
                            Task.TaskStartDate = Task.TaskStartDate.Value.AddHours(-Offset)
                        End If

                    Else

                        If (Task.JobCompletedDate IsNot Nothing) Then
                            Task.JobCompletedDate = Task.JobCompletedDate.Value.AddHours(Offset)
                        End If

                        If (Task.JobDueDate IsNot Nothing) Then
                            Task.JobDueDate = Task.JobDueDate.Value.AddHours(Offset)
                        End If

                        If (Task.JobRevisedDate IsNot Nothing) Then
                            Task.JobRevisedDate = Task.JobRevisedDate.Value.AddHours(Offset)
                        End If

                        If (Task.PhaseEndDate IsNot Nothing) Then
                            Task.PhaseEndDate = Task.PhaseEndDate.Value.AddHours(Offset)
                        End If

                        If (Task.PhaseStartDate IsNot Nothing) Then
                            Task.PhaseStartDate = Task.PhaseStartDate.Value.AddHours(Offset)
                        End If

                        If (Task.TaskStartDate IsNot Nothing) Then
                            Task.TaskStartDate = Task.TaskStartDate.Value.AddHours(Offset)
                        End If

                    End If



                Next

                'Dim arParams As New List(Of SqlParameter)
                'arParams.Add(New SqlParameter("@JOB_NUMBER", JobNumber))
                'arParams.Add(New SqlParameter("@JOB_COMPONENT_NBR", JobComponentNumber))

                'Tasks = DbContext.Database.SqlQuery(Of FUBAR)("select ISNULL(FNC_DESCRIPTION,TASK_DESCRIPTION) Title, TASK_DESCRIPTION [TaskDescription], TASK_START_DATE Start, JOB_DUE_DATE [End], 
                '                                                        JOB_TRAFFIC_DET.SEQ_NBR SequenceNumber, JOB_TRAFFIC_DET.SEQ_NBR ID, 
                '		ISNULL(SUM(EMP_TIME_DTL.EMP_HOURS),0) HoursUsed,
                '                                                        MAX(JOB_TRAFFIC_DET_EMPS.HOURS_ALLOWED) HourdsAllowed,
                '                                                        ISNULL(ISNULL(SUM(EMP_TIME_DTL.EMP_HOURS),0)/NULLIF(MAX(JOB_TRAFFIC_DET_EMPS.HOURS_ALLOWED),0),0) PercentComplete
                '                                                 from JOB_TRAFFIC_DET
                '                                                  left join FUNCTIONS on JOB_TRAFFIC_DET.FNC_CODE = FUNCTIONS.FNC_CODE
                '                                                  left join JOB_TRAFFIC_DET_EMPS ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC_DET_EMPS.JOB_NUMBER AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR
                '                                                     AND JOB_TRAFFIC_DET.SEQ_NBR = JOB_TRAFFIC_DET_EMPS.SEQ_NBR
                '                                                  left JOIN ALERT ON JOB_TRAFFIC_DET.JOB_NUMBER = ALERT.JOB_NUMBER AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = ALERT.JOB_COMPONENT_NBR  AND JOB_TRAFFIC_DET.SEQ_NBR = ALERT.TASK_SEQ_NBR
                '                                                  left join EMP_TIME_DTL ON ALERT.ALERT_ID = EMP_TIME_DTL.ALERT_ID
                '                                                  left JOIN EMP_TIME ON EMP_TIME_DTL.ET_ID = EMP_TIME.ET_ID
                '                                                    where JOB_TRAFFIC_DET.JOB_NUMBER = @JOB_NUMBER AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
                '                                                 GROUP BY FNC_DESCRIPTION,TASK_DESCRIPTION,TASK_START_DATE,JOB_DUE_DATE,JOB_TRAFFIC_DET.SEQ_NBR
                '                                                    ", arParams.ToArray).ToList

            End Using

            If Gantt = 0 Then

                Return MaxJson(JsonConvert.SerializeObject(Tasks, Formatting.None, New JsonSerializerSettings With {.DateFormatString = "yyyy-MM-ddTHH:mm:ss"}), JsonRequestBehavior.AllowGet)

            Else

                Return MaxJson(Tasks, JsonRequestBehavior.AllowGet)

            End If


        End Function

        Public Function CreateGanttTask(ByVal task As TaskDetailGantt, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As JsonResult
            Return MaxJson("FUBAR", JsonRequestBehavior.AllowGet)
        End Function

        Public Function UpdateGanttTask(ByVal task As TaskDetailGantt, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As JsonResult

            If (task.PredecessorLevelNotation Is Nothing) Then
                task.PredecessorLevelNotation = ""
            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@JOB_NUMBER", JobNumber))
                arParams.Add(New SqlParameter("@JOB_COMPONENT_NBR", JobComponentNumber))
                arParams.Add(New SqlParameter("@SEQ_NBR", task.SequenceNumber))
                arParams.Add(New SqlParameter("@TASK_START_DATE", task.TaskStartDate))
                arParams.Add(New SqlParameter("@JOB_DUE_DATE", task.JobRevisedDate))
                If (task.ParentTaskSequenceNumber IsNot Nothing) Then
                    arParams.Add(New SqlParameter("@PARENT_TASK_SEQ", task.ParentTaskSequenceNumber))
                Else
                    Dim param As New SqlParameter("@PARENT_TASK_SEQ", SqlDbType.Int)
                    param.Value = DBNull.Value
                    arParams.Add(param)
                End If
                arParams.Add(New SqlParameter("@GRID_ORDER", task.GridOrder))
                arParams.Add(New SqlParameter("@TASK_DESCRIPTION", If(task.TaskDescription Is Nothing, DBNull.Value, task.TaskDescription)))
                arParams.Add(New SqlParameter("@JOB_DAYS", task.JobDays))

                DbContext.Database.ExecuteSqlCommand("UPDATE JOB_TRAFFIC_DET SET TASK_START_DATE = @TASK_START_DATE, JOB_REVISED_DATE = @JOB_DUE_DATE, PARENT_TASK_SEQ = @PARENT_TASK_SEQ, GRID_ORDER = @GRID_ORDER, TASK_DESCRIPTION = @TASK_DESCRIPTION, JOB_DAYS = @JOB_DAYS  where JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND SEQ_NBR = @SEQ_NBR", arParams.ToArray)
                DbContext.Database.ExecuteSqlCommand("UPDATE ALERT SET START_DATE = @TASK_START_DATE, DUE_DATE = @JOB_DUE_DATE  where JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND TASK_SEQ_NBR = @SEQ_NBR", arParams.ToArray)

            End Using
            Return MaxJson(task, JsonRequestBehavior.AllowGet)
        End Function

        Public Function GanttDependencies(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult
            Dim TaskDependencies As List(Of TaskDetailGanttDependency) = New List(Of TaskDetailGanttDependency)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@JOB_NUMBER", JobNumber))
                arParams.Add(New SqlParameter("@JOB_COMPONENT_NBR", JobComponentNumber))

                TaskDependencies = DbContext.Database.SqlQuery(Of TaskDetailGanttDependency)("select 1 Type, ID, PREDECESSOR_SEQ_NBR PredecessorID,SEQ_NBR SuccessorID from JOB_TRAFFIC_DET_PREDS
	                                                                                                where JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR", arParams.ToArray).ToList

            End Using

            Return MaxJson(TaskDependencies, JsonRequestBehavior.AllowGet)

        End Function

        Public Function UpdateGanttDependencies(Optional ByVal dependency As TaskDetailGanttDependency = Nothing) As JsonResult

            Return MaxJson(dependency, JsonRequestBehavior.AllowGet)
        End Function

        Public Function DestroyGanttDependencies(ByVal dependency As TaskDetailGanttDependency) As JsonResult
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@ID", dependency.ID))

                DbContext.Database.ExecuteSqlCommand("DELETE FROM JOB_TRAFFIC_DET_PREDS WHERE ID = @ID", arParams.ToArray)
            End Using

        End Function

        Public Function CreateGanttDependencies(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal dependency As TaskDetailGanttDependency) As JsonResult
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@JOB_NUMBER", JobNumber))
                arParams.Add(New SqlParameter("@JOB_COMPONENT_NBR", JobComponentNumber))
                arParams.Add(New SqlParameter("@SEQ_NBR", dependency.SuccessorID))
                arParams.Add(New SqlParameter("@PREDECESSOR_SEQ_NBR", dependency.PredecessorID))

                dependency.ID = DbContext.Database.SqlQuery(Of Integer)("insert into JOB_TRAFFIC_DET_PREDS (JOB_NUMBER,JOB_COMPONENT_NBR,SEQ_NBR,PREDECESSOR_SEQ_NBR)
	                                                        OUTPUT Inserted.ID
	                                                        VALUES(@JOB_NUMBER,@JOB_COMPONENT_NBR,@SEQ_NBR,@PREDECESSOR_SEQ_NBR)", arParams.ToArray).FirstOrDefault
            End Using


            Return MaxJson(dependency, JsonRequestBehavior.AllowGet)
        End Function


        Public Function Destroy_Task(ByVal request As Kendo.Mvc.UI.DataSourceRequest, ByVal task As TaskDetailGantt) As JsonResult
            Return MaxJson(task, JsonRequestBehavior.AllowGet)
        End Function

        Public Class EstamatedSchedule
            Public Property JobNumber As Integer
            Public Property JobCompenentNumber As Short
            Public Property FunctionCode As String
            Public Property Description As String
            Public Property EMP_CODE As String
            Public Property EmployeeName As String
            Public Property Hours As Decimal
            Public Property Rate As Decimal
            Public Property Amount As Decimal
        End Class

        <HttpGet>
        Public Function GetEstamatedSchedule(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal IncludeEmployee As Short) As JsonResult
            Dim results As IEnumerable
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim aParam As List(Of SqlParameter) = New List(Of SqlParameter)

                aParam.Add(New SqlParameter("@JobNumber", JobNumber))
                aParam.Add(New SqlParameter("@JobComponentNumber", JobComponentNumber))
                aParam.Add(New SqlParameter("@IncludeEmployee", IncludeEmployee))

                results = DbContext.Database.SqlQuery(Of EstamatedSchedule)("exec GetEstimatedSchedule @JobNumber, @JobComponentNumber, @IncludeEmployee", aParam.ToArray).ToList

            End Using

            Return MaxJson(results, JsonRequestBehavior.AllowGet)
        End Function

        Class ProjectManager
            Public Property EmpFName As String
            Public Property EmpMI As String
            Public Property EmpLName As String
            Public Property EmpCode As String

        End Class

        <HttpGet>
        Public Function GetProjectManager(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult
            Dim results As ProjectManager
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim aParam As List(Of SqlParameter) = New List(Of SqlParameter)

                aParam.Add(New SqlParameter("@JobNumber", JobNumber))
                aParam.Add(New SqlParameter("@JobComponentNumber", JobComponentNumber))

                results = DbContext.Database.SqlQuery(Of ProjectManager)("exec usp_wv_GetProjectManager @JobNumber, @JobComponentNumber", aParam.ToArray).FirstOrDefault

                If IsNothing(results) Then
                    results = New ProjectManager
                End If

            End Using

            Return MaxJson(results, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function GetJobTraffic(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult
            Dim Schedule As AdvantageFramework.ProjectSchedule.Classes.Schedule = New Schedule(Me.SecuritySession)

            Schedule.JobNumber = JobNumber
            Schedule.JobComponentNumber = JobComponentNumber

            Schedule.Load()


            Return MaxJson(New With {.Assignment1Name = Schedule.Assignment1Name,
                           .Assignment2Name = Schedule.Assignment2Name,
                           .Assignment3Name = Schedule.Assignment3Name,
                           .Assignment4Name = Schedule.Assignment4Name,
                           .Assignment5Name = Schedule.Assignment5Name,
                           .Assignment1Code = Schedule.Assignment1Code,
                           .Assignment2Code = Schedule.Assignment2Code,
                           .Assignment3Code = Schedule.Assignment3Code,
                           .Assignment4Code = Schedule.Assignment4Code,
                           .Assignment5Code = Schedule.Assignment5Code}, JsonRequestBehavior.AllowGet)
        End Function

        Class Assignments
            Public Property Assignment1Code As String
            Public Property Assignment2Code As String
            Public Property Assignment3Code As String
            Public Property Assignment4Code As String
            Public Property Assignment5Code As String
            Public Property TrafficComments As String
        End Class

        <HttpGet>
        Public Function GetAssigments(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult
            Dim Assignments As Assignments
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                Dim aParam As List(Of SqlParameter) = New List(Of SqlParameter)

                aParam.Add(New SqlParameter("@JobNumber", JobNumber))
                aParam.Add(New SqlParameter("@JobComponentNumber", JobComponentNumber))

                Assignments = DbContext.Database.SqlQuery(Of Assignments)("select ASSIGN_1 Assignment1Code,ASSIGN_2 Assignment2Code,ASSIGN_3 Assignment3Code,ASSIGN_4 Assignment4Code,ASSIGN_5 Assignment5Code, TRF_COMMENTS TrafficComments from JOB_TRAFFIC where JOB_NUMBER = @JobNumber AND JOB_COMPONENT_NBR = @JobComponentNumber", aParam.ToArray).FirstOrDefault
            End Using

            Return MaxJson(Assignments, JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost>
        Public Function PutAssigments(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, Optional Assignment1Code As String = "",
                                      Optional Assignment2Code As String = "", Optional Assignment3Code As String = "", Optional Assignment4Code As String = "",
                                      Optional Assignment5Code As String = "", Optional TrafficComments As String = "") As JsonResult

            Dim Assignments As Assignments = New Assignments() With {.Assignment1Code = Assignment1Code,
                .Assignment2Code = Assignment2Code,
                .Assignment3Code = Assignment3Code,
                .Assignment4Code = Assignment4Code,
                .Assignment5Code = Assignment5Code,
                .TrafficComments = TrafficComments}

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                Dim aParam As List(Of SqlParameter) = New List(Of SqlParameter)

                aParam.Add(New SqlParameter("@JobNumber", JobNumber))
                aParam.Add(New SqlParameter("@JobComponentNumber", JobComponentNumber))
                aParam.Add(New SqlParameter("@Assignment1Code", If(String.IsNullOrEmpty(Assignment1Code), DBNull.Value, Assignment1Code)))
                aParam.Add(New SqlParameter("@Assignment2Code", If(String.IsNullOrEmpty(Assignment2Code), DBNull.Value, Assignment2Code)))
                aParam.Add(New SqlParameter("@Assignment3Code", If(String.IsNullOrEmpty(Assignment3Code), DBNull.Value, Assignment3Code)))
                aParam.Add(New SqlParameter("@Assignment4Code", If(String.IsNullOrEmpty(Assignment4Code), DBNull.Value, Assignment4Code)))
                aParam.Add(New SqlParameter("@Assignment5Code", If(String.IsNullOrEmpty(Assignment5Code), DBNull.Value, Assignment5Code)))
                aParam.Add(New SqlParameter("@TrafficComments", TrafficComments))

                DbContext.Database.ExecuteSqlCommand("UPDATE JOB_TRAFFIC SET ASSIGN_1 = @Assignment1Code,ASSIGN_2 = @Assignment2Code,
                        ASSIGN_3 = @Assignment3Code,ASSIGN_4 = @Assignment4Code,ASSIGN_5 = @Assignment5Code, TRF_COMMENTS = @TrafficComments where JOB_NUMBER = @JobNumber AND JOB_COMPONENT_NBR = @JobComponentNumber", aParam.ToArray)
            End Using

            Return MaxJson(Assignments, JsonRequestBehavior.AllowGet)

        End Function

        <HttpPost>
        Public Function PutJobInfo(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal PercentComplete As Decimal, ByVal StatusCode As String, ByVal DueDate As Date?, ByVal StartDate As Date?, ByVal CompletedDate As Date?, ByVal Template As Boolean) As JsonResult

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim aParam As List(Of SqlParameter) = New List(Of SqlParameter)
                aParam.Add(New SqlParameter("@JobNumber", JobNumber))
                aParam.Add(New SqlParameter("@JobComponentNumber", JobComponentNumber))
                aParam.Add(New SqlParameter("@PercentComplete", PercentComplete))
                aParam.Add(New SqlParameter("@StatusCode", If(String.IsNullOrEmpty(StatusCode), DBNull.Value, StatusCode)))
                aParam.Add(New SqlParameter("@DueDate", If(IsNothing(DueDate), DBNull.Value, DueDate)))
                aParam.Add(New SqlParameter("@StartDate", If(IsNothing(StartDate), DBNull.Value, StartDate)))
                aParam.Add(New SqlParameter("@CompletedDate", If(IsNothing(CompletedDate), DBNull.Value, CompletedDate)))
                'aParam.Add(New SqlParameter("@TrafficComments", TrafficComments))
                aParam.Add(New SqlParameter("@Template", Template))

                DbContext.Database.ExecuteSqlCommand("UPDATE JOB_TRAFFIC SET PERCENT_COMPLETE = @PercentComplete, TRF_CODE = @StatusCode, IS_TEMPLATE=@Template, COMPLETED_DATE = @CompletedDate where JOB_NUMBER = @JobNumber AND JOB_COMPONENT_NBR = @JobComponentNumber", aParam.ToArray)

                DbContext.Database.ExecuteSqlCommand("UPDATE JOB_COMPONENT SET JOB_FIRST_USE_DATE = @DueDate,START_DATE = @StartDate where JOB_NUMBER = @JobNumber  AND JOB_COMPONENT_NBR = @JobComponentNumber", aParam.ToArray)

                AdvantageFramework.ProjectSchedule.CheckToCompleteSchedule(DbContext, JobNumber, JobComponentNumber)

            End Using

            Return MaxJson(New With {.Status = "Success"}, JsonRequestBehavior.AllowGet)

        End Function

        <HttpPost>
        Public Function PutOtherInformation(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                            ByVal DateShipped As Date?,
                                            ByVal ReceivedBy As String,
                                            ByVal DateDelivered As Date?,
                                            ByVal Reference As String) As JsonResult

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim aParam As List(Of SqlParameter) = New List(Of SqlParameter)
                aParam.Add(New SqlParameter("@JobNumber", JobNumber))
                aParam.Add(New SqlParameter("@JobComponentNumber", JobComponentNumber))
                aParam.Add(New SqlParameter("@DateShipped", If(IsNothing(DateShipped), DBNull.Value, DateShipped)))
                aParam.Add(New SqlParameter("@ReceivedBy", ReceivedBy))
                aParam.Add(New SqlParameter("@DateDelivered", If(IsNothing(DateDelivered), DBNull.Value, DateDelivered)))
                aParam.Add(New SqlParameter("@Reference", Reference))

                DbContext.Database.ExecuteSqlCommand("UPDATE JOB_TRAFFIC SET DATE_DELIVERED=@DateDelivered, DATE_SHIPPED=@DateShipped,RECEIVED_BY=@ReceivedBy,REFERENCE=@Reference where JOB_NUMBER = @JobNumber AND JOB_COMPONENT_NBR = @JobComponentNumber", aParam.ToArray)

                AdvantageFramework.ProjectSchedule.CheckToCompleteSchedule(DbContext, JobNumber, JobComponentNumber)

            End Using

            Return MaxJson(New With {.Status = "Success"}, JsonRequestBehavior.AllowGet)

        End Function

        Class OtherInfo
            Public Property JobNumber As Integer
            Public Property JobComponentNumber As Short
            Public Property DateShipped As Date?
            Public Property ReceivedBy As String
            Public Property DateDelivered As Date?
            Public Property Reference As String
        End Class

        <HttpGet>
        Function GetOtherInformation(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult
            Dim OtherInfo As OtherInfo

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                Dim aParam As List(Of SqlParameter) = New List(Of SqlParameter)
                aParam.Add(New SqlParameter("@JobNumber", JobNumber))
                aParam.Add(New SqlParameter("@JobComponentNumber", JobComponentNumber))

                OtherInfo = DbContext.Database.SqlQuery(Of OtherInfo)("select DATE_DELIVERED DateDelivered,DATE_SHIPPED DateShipped,RECEIVED_BY ReceivedBy,REFERENCE Reference from JOB_TRAFFIC
		                        WHERE JOB_TRAFFIC.JOB_NUMBER = @JobNumber AND JOB_TRAFFIC.JOB_COMPONENT_NBR = @JobComponentNumber", aParam.ToArray).FirstOrDefault

            End Using

            Return MaxJson(OtherInfo, JsonRequestBehavior.AllowGet)

        End Function

        Function GetTasks(ByVal dataObj As JobDataManager) As JsonResult
            Dim Tasks As List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = New List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)
            Dim FilteredTasks As List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = New List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                ' lets forget all the bs and just load what we need.
                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@JOB_NUMBER", dataObj.JobNumber))
                arParams.Add(New SqlParameter("@JOB_COMPONENT_NBR", dataObj.JobComponentNumber))
                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))

                Tasks = DbContext.Database.SqlQuery(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)("exec usp_wv_Traffic_Schedule_GetTasks_V2
                                                                                                                    @JOB_NUMBER,
                                                                                                                    @JOB_COMPONENT_NBR,
                                                                                                                    '',
                                                                                                                    @UserID,
                                                                                                                    '',
                                                                                                                    '',
                                                                                                                    '',
                                                                                                                    'Y',
                                                                                                                    'N',
                                                                                                                    'N',
                                                                                                                    null,
                                                                                                                    '',
                                                                                                                    0",
                                                                                                                    arParams.ToArray).ToList


                For Each Task In Tasks
                    Dim arParams2 As New List(Of SqlParameter)
                    arParams2.Add(New SqlParameter("@JOB_NUMBER", dataObj.JobNumber))
                    arParams2.Add(New SqlParameter("@JOB_COMPONENT_NBR", dataObj.JobComponentNumber))
                    arParams2.Add(New SqlParameter("@SequenceNumber", Task.SequenceNumber))
                    Task.PredecessorSequenceNumbers = DbContext.Database.SqlQuery(Of Short)("SELECT [PREDECESSOR_SEQ_NBR] FROM dbo.JOB_TRAFFIC_DET_PREDS WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND SEQ_NBR=@SequenceNumber", arParams2.ToArray).ToArray

                    Task.PredecessorLevelNotation = String.Join(", ", (From Item In Tasks
                                                                       Where Task.PredecessorSequenceNumbers.Contains(Item.SequenceNumber)
                                                                       Select Item.Level).ToArray)

                Next
            End Using

            Dim operations As Syncfusion.JavaScript.DataSources.DataOperations = New Syncfusion.JavaScript.DataSources.DataOperations

            Try
                FilteredTasks = operations.PerformWhereFilter(Tasks, dataObj.Where, "equal").ToList
            Catch ex As Exception

            End Try

            If (dataObj.RequiresCounts = True) Then
                Return Json(New With {.result = FilteredTasks, .count = FilteredTasks.Count}, JsonRequestBehavior.AllowGet)
            Else
                Return Json(FilteredTasks, JsonRequestBehavior.AllowGet)
            End If

        End Function

        Function GetTaskList(ByVal dataObj As Syncfusion.JavaScript.DataManager) As JsonResult
            Dim Tasks As List(Of CodeName) = New List(Of CodeName)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@JobNumber", 0))
                arParams.Add(New SqlParameter("@JobComponentNumber", 0))

                Tasks = DbContext.Database.SqlQuery(Of CodeName)("usp_wv_dd_GetTasks @JobNumber, @JobComponentNumber", arParams.ToArray).ToList

            End Using

            Dim operations As Syncfusion.JavaScript.DataSources.DataOperations = New Syncfusion.JavaScript.DataSources.DataOperations

            Dim FilteredTasks As List(Of CodeName) = Nothing

            If (dataObj.Where IsNot Nothing) Then
                FilteredTasks = operations.PerformWhereFilter(Tasks, dataObj.Where, "equal").ToList
            Else
                FilteredTasks = Tasks
            End If

            If (dataObj.RequiresCounts = True) Then
                Return Json(New With {.result = FilteredTasks, .count = FilteredTasks.Count}, JsonRequestBehavior.AllowGet)
            Else
                Return Json(FilteredTasks, JsonRequestBehavior.AllowGet)
            End If
        End Function

        Public Function GetPhases(ByVal dataObj As Syncfusion.JavaScript.DataManager) As JsonResult

            'objects
            Dim Phases As List(Of CodeName) = Nothing
            Dim FilteredPhases As List(Of CodeName) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Phases = (From Item In AdvantageFramework.Database.Procedures.Phase.LoadAllActive(DbContext)
                          Order By Item.Description
                          Select New CodeName With {
                              .Code = Item.ID,
                              .Name = Item.Description
                              }
                          ).ToList

            End Using

            Dim operations As Syncfusion.JavaScript.DataSources.DataOperations = New Syncfusion.JavaScript.DataSources.DataOperations

            If (dataObj.Where IsNot Nothing) Then
                FilteredPhases = operations.PerformWhereFilter(Phases, dataObj.Where, "equal").ToList
            Else
                FilteredPhases = Phases
            End If

            If (dataObj.RequiresCounts = True) Then
                Return Json(New With {.result = FilteredPhases, .count = FilteredPhases.Count}, JsonRequestBehavior.AllowGet)
            Else
                Return Json(FilteredPhases, JsonRequestBehavior.AllowGet)
            End If


            Return Json(Phases, JsonRequestBehavior.AllowGet)

        End Function

        Public Function GetEmployees(ByVal dataObj As Syncfusion.JavaScript.DataManager) As JsonResult

            Dim Employees As List(Of EmployeeItem) = Nothing
            Dim FilteredEmployees As List(Of EmployeeItem) = Nothing

            Dim arParams As New List(Of SqlParameter)

            If (String.IsNullOrWhiteSpace("")) Then

                arParams.Add(New SqlParameter("@USER_CODE", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@SHOW_ALL", If(True, 1, 0)))
                arParams.Add(New SqlParameter("@OVERRIDE_SEC_EMP", 0))
                arParams.Add(New SqlParameter("@FROM_TS", 0))

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                    Employees = (From Item In DbContext.Database.SqlQuery(Of EmployeeDDDTO)("exec usp_wv_dd_GetEmpCodes @USER_CODE, @SHOW_ALL, @OVERRIDE_SEC_EMP, @FROM_TS", arParams.ToArray)
                                 Select New EmployeeItem With {
                                     .Code = Item.Code,
                                     .Name = Item.FirstName + " " + If(String.IsNullOrWhiteSpace(Item.MiddleInitial), "", Item.MiddleInitial + ". ") + Item.LastName + " (" + Item.Code + ")",
                                     .NameOnly = Item.FirstName + " " + If(String.IsNullOrWhiteSpace(Item.MiddleInitial), "", Item.MiddleInitial + ". ") + Item.LastName,
                                     .Title = Item.Title
                                         }
                                     ).ToList

                End Using
            Else
                arParams.Add(New SqlParameter("@USER_CODE", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@Role", DBNull.Value))

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                    Employees = (From Item In DbContext.Database.SqlQuery(Of EmployeeDDDTO)("exec usp_wv_dd_GetEmpCodesByRole @USER_CODE, @Role", arParams.ToArray)
                                 Select New EmployeeItem With {
                                     .Code = Item.Code,
                                     .Name = Item.FirstName + " " + If(String.IsNullOrWhiteSpace(Item.MiddleInitial), "", Item.MiddleInitial + ". ") + Item.LastName + " (" + Item.Code + ")",
                                     .NameOnly = Item.FirstName + " " + If(String.IsNullOrWhiteSpace(Item.MiddleInitial), "", Item.MiddleInitial + ". ") + Item.LastName,
                                     .Title = Item.Title
                                         }
                                     ).ToList
                End Using
            End If

            Dim operations As Syncfusion.JavaScript.DataSources.DataOperations = New Syncfusion.JavaScript.DataSources.DataOperations

            If (dataObj.Where IsNot Nothing) Then
                FilteredEmployees = operations.PerformWhereFilter(Employees, dataObj.Where, "equal").ToList
            Else
                FilteredEmployees = Employees
            End If

            If (dataObj.RequiresCounts = True) Then
                Return Json(New With {.result = FilteredEmployees, .count = FilteredEmployees.Count}, JsonRequestBehavior.AllowGet)
            Else
                Return Json(FilteredEmployees, JsonRequestBehavior.AllowGet)
            End If

        End Function

        Public Function InsertTask(ByVal updateParameters As JobDataCRUDModel(Of ScheduleTask)) As JsonResult
            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

            End Using

            'Dim Task As ScheduleTask = updateParameters.Value

            'CreateProjectScheduleTask(Nothing, Task)

        End Function

        Public Function UpdateTask(ByVal updateParameters As JobDataCRUDModel(Of ScheduleTask)) As JsonResult

            Dim Tasks As List(Of ScheduleTask)
            Dim Task As ScheduleTask = updateParameters.Value

            Tasks.Add(Task)

            Me.UpdateProjectScheduleTask(Tasks)

        End Function

        Public Function RemoveTask(ByVal updateParameters As JobDataCRUDModel(Of ScheduleTask)) As JsonResult
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim Message As String = String.Empty

                If (updateParameters.Deleted IsNot Nothing AndAlso updateParameters.Deleted.Count > 0) Then

                    DeleteTasks(DbContext, updateParameters.JobNumber, updateParameters.JobComponentNumber, updateParameters.Deleted.Select(Function(t) t.SequenceNumber).ToArray, Message)

                End If
                If (updateParameters.Added IsNot Nothing AndAlso updateParameters.Added.Count > 0) Then
                    For Each ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask In updateParameters.Added

                        If (ScheduleTask.JobNumber = 0) Then
                            ScheduleTask.JobNumber = updateParameters.JobNumber
                        End If
                        If (ScheduleTask.JobComponentNumber = 0) Then
                            ScheduleTask.JobComponentNumber = updateParameters.JobComponentNumber
                        End If

                        CreateScheduleTask(ScheduleTask)

                    Next

                End If

                AdvantageFramework.ProjectSchedule.CheckToCompleteSchedule(DbContext, updateParameters.JobNumber, updateParameters.JobComponentNumber)

            End Using

        End Function

        <HttpPost>
        Function CalcByStartDate(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal ByStartDate As Short) As JsonResult
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@JOB_NUMBER", JobNumber))
                arParams.Add(New SqlParameter("@JOB_COMPONENT_NBR", JobComponentNumber))
                arParams.Add(New SqlParameter("@TRF_SCHEDULE_BY", ByStartDate))

                DbContext.Database.ExecuteSqlCommand("UPDATE JOB_COMPONENT SET TRF_SCHEDULE_BY=@TRF_SCHEDULE_BY WHERE JOB_NUMBER=@JOB_NUMBER AND JOB_COMPONENT_NBR=@JOB_COMPONENT_NBR", arParams.ToArray)
            End Using
            Return MaxJson(ByStartDate, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Function GetHeaderLock()

            Dim HeaderLock As Boolean = True

            If Session(LockDateSessionKey) Is Nothing Then

                Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.TRF_LOCK_DATE.ToString)

                    If Setting IsNot Nothing Then

                        HeaderLock = CBool(Setting.Value)

                    End If

                End Using

                Session(LockDateSessionKey) = HeaderLock

            Else

                HeaderLock = Session(LockDateSessionKey)

            End If

            Return MaxJson(HeaderLock, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Function GetDays(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As JsonResult
            Dim Days As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@start", StartDate))
                arParams.Add(New SqlParameter("@end", EndDate))
                Try

                    Days = DbContext.Database.SqlQuery(Of Integer)("exec usp_wv_Get_WorkDays @start, @end, 1", arParams.ToArray).FirstOrDefault()
                Catch ex As Exception
                    Diagnostics.Debug.WriteLine(ex.Message)
                End Try
            End Using

            Return MaxJson(Days, JsonRequestBehavior.AllowGet)
        End Function

#End Region

    End Class

    Public Class CodeName
        Public Property Code As String
        Public Property Name As String
    End Class

    Public Class EmployeeItem
        Inherits CodeName
        Public Property NameOnly As String
        Public Property Title As String
    End Class

    Public Class JobDataManager
        Inherits Syncfusion.JavaScript.DataManager

        Public Property JobNumber As Integer
        Public Property JobComponentNumber As Short
    End Class

    Public Class JobDataCRUDModel(Of T As Class)
        Inherits Syncfusion.JavaScript.CRUDModel(Of T)
        Public Property JobNumber As Integer
        Public Property JobComponentNumber As Short
    End Class

    Public Class SimpleTask
        Public Property Level As String
        Public Property SequenceNumber As Short
        Public Property HasChildren As Boolean
        Public Property ParentTaskSequenceNumber As Short?
        Public Property TaskDescription As String
        Public Property PhaseDescription As String
    End Class

End Namespace

