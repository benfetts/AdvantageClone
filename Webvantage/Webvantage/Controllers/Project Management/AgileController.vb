Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Web.Mvc
Imports Webvantage.ViewModels
Imports Kendo.Mvc.Extensions
Imports MvcCodeRouting.Web.Mvc
Imports Webvantage.Controllers
Imports System.Globalization
Imports System.Web.Routing

Namespace Controllers.ProjectManagement

    <Serializable()>
    Public Class AgileController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "ProjectManagement/Agile/"
        Public Const BoardColumnWidth As Integer = 100
        Public Const BoardSystemColumnWidth As Integer = 110
        Public Const SwimlaneCollapseSettingSessionKey As String = "SPT_SLCSSK"
        Public Const SwimlaneBySessionKey As String = "SPT_SLBSK"
        Public Const WeeklyHoursSessionKey As String = "SPT_WKLYHRSSK"
        Public Const FilterCardSessionKey As String = "SPT_FCOK"
        Public Const FilterCardOnlyBacklogSessionKey As String = "SPT_FCOBLK"
        Public Const FilterEmployeeSessionKey As String = "SPT_FEK"
        Public Const FilterEmployeeBacklogSessionKey As String = "SPT_FEBLK"
        Public Const FilterBacklogSortSessionKey As String = "SPT_FBLSLK"
        Public Const FilterBacklogSortTypeSessionKey As String = "SPT_FBLSTLK"

#End Region

#Region " Enums "

        Public Enum CompleteOption

            BackToBacklog = 1
            LeaveInCurrentState = 2

        End Enum

#End Region

#Region " Properties "

        Private _Controller As AdvantageFramework.Controller.ProjectManagement.AgileController = Nothing

#End Region

#Region " Initialize "

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.ProjectManagement.AgileController(Me.SecuritySession)

        End Sub

#End Region

        ''''<MvcCodeRouting.Web.Mvc.CustomRoute("~/Desktop_AlertView")>
        ''<MvcCodeRouting.Web.Mvc.CustomRoute("~/ProjectManagement_GridTest")>
        ''Public Function AlertView() As ActionResult

        ''    'objects
        ''    Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

        ''    AureliaModel = New Webvantage.ViewModels.AureliaModel

        ''    AureliaModel.App = "modules/project-management/grid-test/grid-test"

        ''    Return Aurelia(AureliaModel)

        ''End Function

#Region " Views "

        Public Function Index(<FromRoute()> ByVal JobNumber As Integer, <FromRoute()> ByVal JobComponentNumber As Short) As ActionResult

            Dim Pb As New AdvantageFramework.ProjectSchedule.Classes.ProjectBoard(SecuritySession)

            Pb.JobNumber = JobNumber
            Pb.JobComponentNumber = JobComponentNumber
            Pb.IsClientPortal = MiscFN.IsClientPortal

            Pb.Load()

            Return View(Pb)

        End Function
        <MvcCodeRouting.Web.Mvc.CustomRoute("~/ProjectManagement_Agile_SprintDashboard")>
        Public Function SprintDashboard() As ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New Webvantage.ViewModels.AureliaModel

            AureliaModel.App = "modules/project-management/sprint-dashboard/sprint-dashboard"
            AureliaModel.Parameters.Add("SprintID", 12345)

            Return Aurelia(AureliaModel)

        End Function

#Region " Agile Board Views "

        Public Function AddJobToBoards() As ActionResult

            Dim Boards As Generic.List(Of Webvantage.Controllers.ProjectManagement.AgileController.BoardDisplay)
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0
            Dim IsPMD As Boolean = False

            Boards = Nothing
            JobNumber = Me.CurrentQueryString.JobNumber
            JobComponentNumber = Me.CurrentQueryString.JobComponentNumber
            IsPMD = Me.CurrentQueryString.IsJobDashboard

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    Boards = DbContext.Database.SqlQuery(Of Webvantage.Controllers.ProjectManagement.AgileController.BoardDisplay)(String.Format("EXEC [dbo].[advsp_agile_load_agile_boards] {0}, {1}, 1, '{2}';",
                                                                                                                                                 JobNumber, JobComponentNumber, Me.SecuritySession.UserCode)).ToList

                Catch ex As Exception
                    Boards = Nothing
                End Try

            End Using

            If Boards Is Nothing Then Boards = New List(Of Webvantage.Controllers.ProjectManagement.AgileController.BoardDisplay)

            ViewData("IsPMD") = IsPMD
            ViewData("NewAgileBoardURL") = Me.NewAgileBoardURL

            Me.CanAdd()
            Me.CanUpdate()

            Return View(Boards)

        End Function

        Public Function AgileBoards() As ActionResult

            Dim qs As New AdvantageFramework.Web.QueryString
            Dim Boards As Generic.List(Of Webvantage.Controllers.ProjectManagement.AgileController.BoardDisplay)
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0
            Dim ExtraSQL As String = String.Empty
            Dim IsPMD As Boolean = False

            Boards = Nothing

            qs = qs.FromCurrent

            JobNumber = qs.JobNumber
            JobComponentNumber = qs.JobComponentNumber
            IsPMD = qs.IsJobDashboard

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    Boards = DbContext.Database.SqlQuery(Of Webvantage.Controllers.ProjectManagement.AgileController.BoardDisplay)(String.Format("EXEC [dbo].[advsp_agile_load_agile_boards] {0}, {1}, 0, '{2}';",
                                                                                                                                                 JobNumber, JobComponentNumber, Me.SecuritySession.UserCode)).ToList

                Catch ex As Exception
                    Boards = Nothing
                End Try

            End Using

            If Boards Is Nothing Then Boards = New List(Of Webvantage.Controllers.ProjectManagement.AgileController.BoardDisplay)

            ViewData("IsPMD") = IsPMD
            ViewData("NewAgileBoardURL") = Me.NewAgileBoardURL
            Me.CanAdd()
            Me.CanUpdate()

            Return View(Boards)


        End Function
        Public Function AgileBoard(<FromRoute()> ByVal BoardID As Integer) As ActionResult

            Dim BoardView As New BoardView

            BoardView = LoadBoardView(BoardID, False)

            ViewData("BoardID") = BoardID
            ViewData("Title") = BoardView.Header.Name
            ViewData("NewSprintURL") = Me.NewSprintURL(BoardID)
            ViewData("EditSprintURL") = Me.EditSprintURL(BoardID)
            ViewData("EditAgileBoardURL") = Me.EditAgileBoardURL(BoardID)
            Me.CanAdd()
            Me.CanUpdate()

            Return View(BoardView)

        End Function
        Public Function NewAgileBoard(<FromRoute()> ByVal BoardID As Integer?) As ActionResult

            Dim Board As New AdvantageFramework.ProjectManagement.Agile.Classes.Board(Me.SecuritySession)
            Dim Enabled As Boolean = True

            If Board IsNot Nothing AndAlso BoardID > 0 Then

                Board.BoardID = BoardID
                ViewData("BoardID") = BoardID
                ViewData("IsEdit") = True

                If Me.CanUpdate() = False Then

                    Enabled = False

                End If

            Else

                Board.Header.BoardHeaderID = 0
                ViewData("BoardID") = 0
                ViewData("IsEdit") = False

                If Me.CanAdd() = False Then

                    Enabled = False

                End If

            End If

            Board.Load()

            ViewData("Enabled") = Enabled

            Return View(Board)

        End Function

        <MvcCodeRouting.Web.Mvc.CustomRoute("~/ProjectManagement_Agile_SelectBoardJobs")>
        Public Function SelectBoardJobs(BoardID As Integer) As ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New Webvantage.ViewModels.AureliaModel

            AureliaModel.App = "modules/project-management/agile/select-board-jobs"
            AureliaModel.Parameters.Add("BoardID", BoardID)

            Return Aurelia(AureliaModel)

        End Function

#End Region

#Region " Epics "

        Public Function Epics() As ActionResult

            Return View()

        End Function

#End Region

#Region " Card Views "

        Public Function CardDetail(<FromRoute()> ByVal AlertID As Integer, <FromRoute()> ByVal SprintDetailID As Integer) As ActionResult

            Dim CardDetails As New AdvantageFramework.ProjectManagement.Agile.Classes.CardDetail(Me.SecuritySession)

            CardDetails.AlertID = AlertID
            CardDetails.SprintDetailID = SprintDetailID

            CardDetails.Load()

            Return View(CardDetails)

        End Function

#Region " Partial "

        Public Function _CardDetail(ByVal AlertID As Integer, ByVal SprintDetailID As Integer) As ActionResult

            Dim CardDetails As New AdvantageFramework.ProjectManagement.Agile.Classes.CardDetail(Me.SecuritySession)

            CardDetails.AlertID = AlertID
            CardDetails.SprintDetailID = SprintDetailID

            CardDetails.Load()

            Return PartialView(CardDetails)

        End Function

#End Region

#End Region

#Region " Board Views "

        Public Function Boards() As ActionResult

            Return View(LoadBoardList())

        End Function


        '<AcceptVerbs("POST")>
        'Public Function DesignFilter(<FromRoute()> ByVal BoardID As Integer?,
        '                             <FromRoute()> ByVal JobNumber As Integer?,
        '                             <FromRoute()> ByVal JobComponentNumber As Short?,
        '                             <FromRoute()> ByVal FromViewName As String,
        '                             <FromRoute()> ByVal AlertTemplateID As Integer?) As ActionResult

        '    Dim DesignBoard As New AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner(Me.SecuritySession)

        '    DesignBoard.BoardHeaderID = BoardID
        '    DesignBoard.FilterAlertTemplateID = AlertTemplateID
        '    DesignBoard.Load()

        '    ViewData("FromViewName") = FromViewName

        '    Return View("Design", DesignBoard)

        'End Function

        <AcceptVerbs("POST")>
        Public Function LoadSprintData(ByVal value As Syncfusion.JavaScript.DataManager, ByVal SearchText As String,
                                       ByVal OnlyBacklog As Boolean?, ByVal Employees As String(), ByVal SortBacklog As Short?, ByVal EmployeeBacklog As Boolean?) As JsonResult

            Dim ErrorMessage As String = String.Empty
            Dim Results As New DataResult
            Dim SprintID As Integer = 0

            If Request.QueryString("SprintID") IsNot Nothing Then

                SprintID = Request.QueryString("SprintID")

            End If
            Try

                If SprintID > 0 Then

                    Me.SetSprintBacklogIsSorted(SprintID, SortBacklog)

                    Dim Success As Boolean = False
                    Dim EmployeeFilteredData As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard)
                    Dim Data As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard) = Nothing

                    If OnlyBacklog Is Nothing Then OnlyBacklog = False
                    If EmployeeBacklog Is Nothing Then EmployeeBacklog = False
                    If SortBacklog Is Nothing Then SortBacklog = 0

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        If String.IsNullOrWhiteSpace(SearchText) = True Then

                            Data = AdvantageFramework.ProjectManagement.Agile.LoadBoardTaskAssignmentCards(DbContext, SprintID, Me.SecuritySession.UserCode,
                                                                                                       CType(SortBacklog, AdvantageFramework.ProjectManagement.Agile.Methods.BacklogSort))

                        Else

                            SearchText = SearchText.ToUpper

                            Try

                                If OnlyBacklog = True Then

                                    Data = (From Entity In AdvantageFramework.ProjectManagement.Agile.LoadBoardTaskAssignmentCards(DbContext, SprintID, Me.SecuritySession.UserCode,
                                                                                                       CType(SortBacklog, AdvantageFramework.ProjectManagement.Agile.Methods.BacklogSort))
                                            Where (((String.IsNullOrWhiteSpace(Entity.Title) = False AndAlso Entity.Title.ToUpper.Contains(SearchText)) OrElse
                                                (String.IsNullOrWhiteSpace(Entity.Description) = False AndAlso Entity.Description.ToUpper.Contains(SearchText)) OrElse
                                                (String.IsNullOrWhiteSpace(Entity.JobName) = False AndAlso Entity.JobName.ToUpper.Contains(SearchText)) OrElse
                                                (String.IsNullOrWhiteSpace(Entity.TaskDescription) = False AndAlso Entity.TaskDescription.ToUpper.Contains(SearchText)) OrElse
                                                (String.IsNullOrWhiteSpace(Entity.BoardStateName) = False AndAlso Entity.BoardStateName.ToUpper.Contains(SearchText)) OrElse
                                                (String.IsNullOrWhiteSpace(Entity.AlertStateName) = False AndAlso Entity.AlertStateName.ToUpper.Contains(SearchText)) OrElse
                                                (String.IsNullOrWhiteSpace(Entity.AlertCategoryName) = False AndAlso Entity.AlertCategoryName.ToUpper.Contains(SearchText)) OrElse
                                                (Entity.AssignNumber IsNot Nothing AndAlso Entity.AssignNumber.ToString.Contains(SearchText)) OrElse
                                                (String.IsNullOrWhiteSpace(Entity.ClientName) = False AndAlso Entity.ClientName.ToUpper.Contains(SearchText)) AndAlso Entity.SprintDetailID = -1)) OrElse
                                            Entity.SprintDetailID > 0
                                            Select Entity).ToList

                                Else

                                    Data = (From Entity In AdvantageFramework.ProjectManagement.Agile.LoadBoardTaskAssignmentCards(DbContext, SprintID, Me.SecuritySession.UserCode,
                                                                                                       CType(SortBacklog, AdvantageFramework.ProjectManagement.Agile.Methods.BacklogSort))
                                            Where (String.IsNullOrWhiteSpace(Entity.Title) = False AndAlso Entity.Title.ToUpper.Contains(SearchText)) OrElse
                                              (String.IsNullOrWhiteSpace(Entity.Description) = False AndAlso Entity.Description.ToUpper.Contains(SearchText)) OrElse
                                              (String.IsNullOrWhiteSpace(Entity.JobName) = False AndAlso Entity.JobName.ToUpper.Contains(SearchText)) OrElse
                                              (String.IsNullOrWhiteSpace(Entity.TaskDescription) = False AndAlso Entity.TaskDescription.ToUpper.Contains(SearchText)) OrElse
                                              (String.IsNullOrWhiteSpace(Entity.BoardStateName) = False AndAlso Entity.BoardStateName.ToUpper.Contains(SearchText)) OrElse
                                              (String.IsNullOrWhiteSpace(Entity.AlertStateName) = False AndAlso Entity.AlertStateName.ToUpper.Contains(SearchText)) OrElse
                                              (String.IsNullOrWhiteSpace(Entity.AlertCategoryName) = False AndAlso Entity.AlertCategoryName.ToUpper.Contains(SearchText)) OrElse
                                              (Entity.AssignNumber IsNot Nothing AndAlso Entity.AssignNumber.ToString.Contains(SearchText)) OrElse
                                              (String.IsNullOrWhiteSpace(Entity.ClientName) = False AndAlso Entity.ClientName.ToUpper.Contains(SearchText))
                                            Select Entity).ToList

                                End If

                            Catch ex As Exception
                                Data = Nothing
                            End Try

                        End If

                        If Data IsNot Nothing Then

                            If Employees IsNot Nothing AndAlso Employees.Count > 0 Then

                                EmployeeFilteredData = New List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard)

                                If EmployeeBacklog = True Then

                                    For Each TaskAssignmentCard In Data

                                        If TaskAssignmentCard.Assignees IsNot Nothing Then

                                            For Each Assignee In TaskAssignmentCard.Assignees.Where(Function(assign) assign.IsCurrentNotify = True).ToList

                                                If Employees.Contains(Assignee.EmployeeCode) Then

                                                    EmployeeFilteredData.Add(TaskAssignmentCard)
                                                    Exit For

                                                End If

                                            Next

                                        End If

                                    Next

                                Else

                                    For Each TaskAssignmentCard In Data

                                        If TaskAssignmentCard.BoardColumnID = -1 OrElse TaskAssignmentCard.SprintDetailID = -1 Then

                                            EmployeeFilteredData.Add(TaskAssignmentCard)

                                        Else

                                            If TaskAssignmentCard.Assignees IsNot Nothing Then

                                                For Each Assignee In TaskAssignmentCard.Assignees.Where(Function(assign) assign.IsCurrentNotify = True).ToList

                                                    If Employees.Contains(Assignee.EmployeeCode) Then

                                                        EmployeeFilteredData.Add(TaskAssignmentCard)
                                                        Exit For

                                                    End If

                                                Next

                                            End If

                                        End If

                                    Next

                                End If

                                Data = EmployeeFilteredData

                            End If

                            Results.result = Data
                            Results.count = Data.Count

                        Else

                            Results.result = New List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard)
                            Results.count = 0

                        End If

                    End Using

                End If

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return MaxJson(Results, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("POST")>
        Public Function SprintFilter(ByVal SprintID As Integer,
                                     ByVal SearchText As String,
                                     ByVal OnlyBacklog As Boolean,
                                     ByVal Employees As String()) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim EmployeeFilteredData As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard)

            Dim Data As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard) = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    If String.IsNullOrEmpty(SearchText) = True Then

                        Data = AdvantageFramework.ProjectManagement.Agile.LoadBoardTaskAssignmentCards(DbContext, SprintID, Me.SecuritySession.UserCode,
                                                                                                       AdvantageFramework.ProjectManagement.Agile.Methods.BacklogSort.None)

                    Else

                        SearchText = SearchText.ToUpper

                        Try

                            If OnlyBacklog = True Then

                                Data = (From Entity In AdvantageFramework.ProjectManagement.Agile.LoadBoardTaskAssignmentCards(DbContext, SprintID, Me.SecuritySession.UserCode,
                                                                                                       AdvantageFramework.ProjectManagement.Agile.Methods.BacklogSort.None)
                                        Where (((String.IsNullOrWhiteSpace(Entity.Title) = False AndAlso Entity.Title.ToUpper.Contains(SearchText)) OrElse
                                                (String.IsNullOrWhiteSpace(Entity.Description) = False AndAlso Entity.Description.ToUpper.Contains(SearchText)) OrElse
                                                (String.IsNullOrWhiteSpace(Entity.JobName) = False AndAlso Entity.JobName.ToUpper.Contains(SearchText)) OrElse
                                                (String.IsNullOrWhiteSpace(Entity.TaskDescription) = False AndAlso Entity.TaskDescription.ToUpper.Contains(SearchText)) OrElse
                                                (String.IsNullOrWhiteSpace(Entity.BoardStateName) = False AndAlso Entity.BoardStateName.ToUpper.Contains(SearchText)) OrElse
                                                (String.IsNullOrWhiteSpace(Entity.AlertStateName) = False AndAlso Entity.AlertStateName.ToUpper.Contains(SearchText)) OrElse
                                                (String.IsNullOrWhiteSpace(Entity.AlertCategoryName) = False AndAlso Entity.AlertCategoryName.ToUpper.Contains(SearchText)) OrElse
                                                (Entity.AssignNumber IsNot Nothing AndAlso Entity.AssignNumber.ToString.Contains(SearchText)) OrElse
                                                (String.IsNullOrWhiteSpace(Entity.ClientName) = False AndAlso Entity.ClientName.ToUpper.Contains(SearchText)) AndAlso Entity.SprintDetailID = -1)) OrElse
                                            Entity.SprintDetailID > 0
                                        Select Entity).ToList

                            Else

                                Data = (From Entity In AdvantageFramework.ProjectManagement.Agile.LoadBoardTaskAssignmentCards(DbContext, SprintID, Me.SecuritySession.UserCode,
                                                                                                       AdvantageFramework.ProjectManagement.Agile.Methods.BacklogSort.None)
                                        Where (String.IsNullOrWhiteSpace(Entity.Title) = False AndAlso Entity.Title.ToUpper.Contains(SearchText)) OrElse
                                              (String.IsNullOrWhiteSpace(Entity.Description) = False AndAlso Entity.Description.ToUpper.Contains(SearchText)) OrElse
                                              (String.IsNullOrWhiteSpace(Entity.JobName) = False AndAlso Entity.JobName.ToUpper.Contains(SearchText)) OrElse
                                              (String.IsNullOrWhiteSpace(Entity.TaskDescription) = False AndAlso Entity.TaskDescription.ToUpper.Contains(SearchText)) OrElse
                                              (String.IsNullOrWhiteSpace(Entity.BoardStateName) = False AndAlso Entity.BoardStateName.ToUpper.Contains(SearchText)) OrElse
                                              (String.IsNullOrWhiteSpace(Entity.AlertStateName) = False AndAlso Entity.AlertStateName.ToUpper.Contains(SearchText)) OrElse
                                              (String.IsNullOrWhiteSpace(Entity.AlertCategoryName) = False AndAlso Entity.AlertCategoryName.ToUpper.Contains(SearchText)) OrElse
                                              (Entity.AssignNumber IsNot Nothing AndAlso Entity.AssignNumber.ToString.Contains(SearchText)) OrElse
                                              (String.IsNullOrWhiteSpace(Entity.ClientName) = False AndAlso Entity.ClientName.ToUpper.Contains(SearchText))
                                        Select Entity).ToList

                            End If

                        Catch ex As Exception
                            Data = Nothing
                        End Try

                    End If

                    If Data IsNot Nothing Then

                        If Employees IsNot Nothing AndAlso Employees.Count > 0 Then

                            EmployeeFilteredData = New List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard)

                            For Each TaskAssignmentCard In Data

                                If TaskAssignmentCard.BoardColumnID = -1 OrElse TaskAssignmentCard.SprintDetailID = -1 Then

                                    EmployeeFilteredData.Add(TaskAssignmentCard)


                                Else

                                    If TaskAssignmentCard.Assignees IsNot Nothing Then

                                        For Each Assignee In TaskAssignmentCard.Assignees.Where(Function(assign) assign.IsCurrentNotify = True).ToList

                                            If Employees.Contains(Assignee.EmployeeCode) Then

                                                EmployeeFilteredData.Add(TaskAssignmentCard)
                                                Exit For

                                            End If

                                        Next

                                    End If

                                End If

                            Next

                            Data = EmployeeFilteredData

                        End If

                    End If

                End Using

                If Data Is Nothing Then Data = New List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard)

            Catch ex As Exception
                Data = Nothing
                ErrorMessage = ex.Message.ToString
            End Try

            Return MaxJson(Data, JsonRequestBehavior.AllowGet)

        End Function


        <AcceptVerbs("POST")>
        Public Function DesignDeleteBoard(ByVal BoardHeaderID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim UsedOnBoardsCount As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    UsedOnBoardsCount = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM BOARD WHERE BOARD_HDR_ID = {0};", BoardHeaderID)).SingleOrDefault

                    If UsedOnBoardsCount = 0 Then

                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM BOARD_DTL WITH(ROWLOCK) WHERE BOARD_HDR_ID = {0}; DELETE FROM BOARD_COL WITH(ROWLOCK) WHERE BOARD_HDR_ID = {0}; DELETE FROM BOARD_HDR WITH(ROWLOCK) WHERE ID = {0};", BoardHeaderID))

                        Catch ex As Exception
                            ErrorMessage = ex.Message.ToString
                        End Try

                    Else

                        ErrorMessage = AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.DeleteBoardLayoutMessage(UsedOnBoardsCount)

                    End If
                    If String.IsNullOrWhiteSpace(ErrorMessage) = True Then

                        Success = True

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("POST")>
        Public Function DesignDeleteState(ByVal BoardHeaderID As Integer, ByVal BoardColumnID As Integer,
                                          ByVal StateID As Integer, ByVal AlertTemplateID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)


                    If BoardColumnID = -3 Then

                        If AlertTemplateID = -1 Then

                            ErrorMessage = DbContext.Database.SqlQuery(Of String)(String.Format("EXEC [dbo].[usp_wv_ALERT_STATES_DELETE] {0}, 1;", StateID)).SingleOrDefault

                        Else

                            Dim UsageCount As Integer = 0

                            Try

                                UsageCount = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ALERT_ID FROM ALERT WHERE ALRT_NOTIFY_HDR_ID = {0} AND ALERT_STATE_ID = {1};", AlertTemplateID, StateID)).Count

                            Catch ex As Exception
                                UsageCount = 1
                            End Try

                            If UsageCount = 0 Then

                                Dim AlertNotifyState As AdvantageFramework.Database.Entities.AlertAssignmentTemplateState = Nothing

                                AlertNotifyState = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext, AlertTemplateID, StateID)

                                If AlertNotifyState IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.Delete(DbContext, AlertNotifyState) = True Then

                                        ErrorMessage = String.Empty

                                    End If

                                End If

                            Else

                                ErrorMessage = "State is on an assignment and cannot be removed from template"

                            End If

                        End If

                    Else

                        Dim BoardDetail As AdvantageFramework.Database.Entities.BoardDetail = Nothing

                        BoardDetail = AdvantageFramework.Database.Procedures.BoardDetail.LoadByBoardHeaderIDandBoardColumnIDandAlertStateID(DbContext, BoardHeaderID, BoardColumnID, StateID)

                        If BoardDetail IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.BoardDetail.Delete(DbContext, BoardDetail) = True Then

                                ErrorMessage = String.Empty
                                'Try

                                '    Dim DetailCount As Integer = 0

                                '    DetailCount = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ID FROM BOARD_DTL WHERE BOARD_HDR_ID = {0} AND BOARD_COL_ID = {1};", BoardHeaderID, BoardColumnID)).Count

                                'Catch ex As Exception
                                'End Try


                            End If

                        End If

                    End If

                    If String.IsNullOrWhiteSpace(ErrorMessage) = True Then

                        Success = True

                    End If
                    If Success = True Then

                        ViewData("FilteredAlertTemplateID") = AlertTemplateID
                        ReturnObject = LoadDesignCards(BoardHeaderID, AlertTemplateID, ErrorMessage)

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("POST")>
        Public Function DesignFilter(ByVal BoardID As Integer,
                                     ByVal AlertTemplateID As Integer) As JsonResult

            Dim ErrorMessage As String = String.Empty

            Dim DesignCards As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.DesignCard) = Nothing

            ViewData("FilteredAlertTemplateID") = AlertTemplateID
            DesignCards = LoadDesignCards(BoardID, AlertTemplateID, ErrorMessage)

            Return Json(DesignCards, JsonRequestBehavior.AllowGet)

        End Function
        Private Function LoadDesignCards(ByVal BoardID As Integer,
                                         ByVal AlertTemplateID As Integer,
                                         ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.DesignCard)

            Dim DesignBoard As New AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner(Me.SecuritySession)
            Dim DesignCards As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.DesignCard) = Nothing

            Try

                DesignBoard.BoardHeaderID = BoardID
                DesignBoard.FilterStates = True
                DesignBoard.FilterAlertTemplateID = AlertTemplateID
                DesignBoard.Load()

            Catch ex As Exception
                DesignBoard = Nothing
                ErrorMessage = ex.Message.ToString
            End Try

            If DesignBoard IsNot Nothing AndAlso DesignBoard.Cards IsNot Nothing Then

                DesignCards = DesignBoard.Cards

            Else

                DesignCards = New List(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.DesignCard)

            End If

            Return DesignCards

        End Function

        Public Function Design(<FromRoute()> ByVal BoardID As Integer?,
                               <FromRoute()> ByVal JobNumber As Integer?,
                               <FromRoute()> ByVal JobComponentNumber As Short?,
                               <FromRoute()> ByVal FromViewName As String) As ActionResult

            Dim DesignBoard As New AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner(Me.SecuritySession)

            DesignBoard.BoardHeaderID = BoardID
            DesignBoard.Load()

            ViewData("FromViewName") = FromViewName

            If DesignBoard.Header.AlertTemplateID IsNot Nothing Then

                ViewData("FilteredAlertTemplateID") = DesignBoard.Header.AlertTemplateID

            Else

                ViewData("FilteredAlertTemplateID") = -1

            End If

            Return View(DesignBoard)

        End Function

        Public Function NewBoard(<FromRoute()> ByVal JobNumber As Integer?,
                                 <FromRoute()> ByVal JobComponentNumber As Short?,
                                 <FromRoute()> ByVal FromViewName As String) As ActionResult

            Dim DesignBoard As New AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner(Me.SecuritySession)

            DesignBoard.Load()

            ViewData("FromViewName") = FromViewName

            Return View(DesignBoard)

        End Function
        Public Function SelectBoard(<FromRoute()> ByVal JobNumber As Integer?,
                                    <FromRoute()> ByVal JobComponentNumber As Short?,
                                    <FromRoute()> ByVal FromViewName As String) As ActionResult

            Dim SbVM As New AdvantageFramework.ViewModels.ProjectManagement.Agile.SelectBoardViewModel

            If JobNumber IsNot Nothing AndAlso JobNumber > 0 Then SbVM.JobNumber = JobNumber
            If JobComponentNumber IsNot Nothing AndAlso JobComponentNumber > 0 Then SbVM.JobComponentNumber = JobComponentNumber

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim Boards As Generic.List(Of AdvantageFramework.Database.Entities.BoardHeader) = Nothing

                Boards = AdvantageFramework.Database.Procedures.BoardHeader.Load(DbContext).ToList

                If Boards IsNot Nothing Then

                    If SbVM.AvailableBoards Is Nothing Then SbVM.AvailableBoards = New List(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.SelectBoardViewModel.AvailableBoard)

                    Dim Board As AdvantageFramework.ViewModels.ProjectManagement.Agile.SelectBoardViewModel.AvailableBoard

                    Board = New AdvantageFramework.ViewModels.ProjectManagement.Agile.SelectBoardViewModel.AvailableBoard
                    Board.ID = -1
                    Board.Name = "[Please Select]"

                    SbVM.AvailableBoards.Add(Board)

                    For Each DbBoard As AdvantageFramework.Database.Entities.BoardHeader In Boards

                        Board = New AdvantageFramework.ViewModels.ProjectManagement.Agile.SelectBoardViewModel.AvailableBoard

                        Board.ID = DbBoard.ID
                        Board.Name = DbBoard.Name

                        SbVM.AvailableBoards.Add(Board)

                        Board = Nothing

                    Next

                End If

            End Using

            ViewData("FromViewName") = FromViewName
            ViewData("NewBoardURL") = Me.NewBoardURL("SelectBoard", JobNumber, JobComponentNumber)

            Return View(SbVM)

        End Function
        Public Function MyProjectBoard(<FromRoute()> ByVal EmployeeCode As String) As ActionResult


        End Function
        Public Function ProjectManagerBoard(<FromRoute()> ByVal EmployeeCode As String) As ActionResult


        End Function
        Public Function TaskManagerBoard() As ActionResult

            Dim ProjectBoardObj As AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard
            Dim JobViews As Generic.List(Of AdvantageFramework.Database.Views.JobView) = Nothing
            Dim AlertStates As Generic.List(Of AdvantageFramework.Database.Entities.AlertState) = Nothing
            Dim JobNumbers As Integer() = Nothing
            Dim AlertStateIDs As Integer() = Nothing

            ProjectBoardObj = New AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard(Me.SecuritySession)

            ProjectBoardObj.EmployeeCode = Me.SecuritySession.User.EmployeeCode
            ProjectBoardObj.Allowed = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.AllowedType.AlertsAndAssignments

            ProjectBoardObj.LoadDataBy = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.LoadBy.EmployeeCode
            ProjectBoardObj.ShowSwimLaneBy = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.SwimLaneKey.AlertAndAssignments

            ProjectBoardObj.LoadAlertsAndAssignments()

            JobNumbers = ProjectBoardObj.Data.Select(Function(d) d.JobNumber.GetValueOrDefault(0)).Distinct.ToArray
            AlertStateIDs = ProjectBoardObj.Data.Select(Function(d) d.AlertStateID.GetValueOrDefault(0)).Distinct.ToArray

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                JobViews = (From Item In AdvantageFramework.Database.Procedures.JobView.Load(DbContext)
                            Where JobNumbers.Contains(Item.JobNumber)
                            Select Item).ToList

                AlertStates = (From Item In AdvantageFramework.Database.Procedures.AlertState.Load(DbContext)
                               Where AlertStateIDs.Contains(Item.ID)
                               Select Item).ToList

            End Using

            ProjectBoardObj.Filters = New List(Of AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.Filter)

            ProjectBoardObj.Filters.Add(New AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.Filter With {
                                            .FilterType = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.FilterTypes.Assignee,
                                            .Watermark = "Select Assignee(s)",
                                            .Items = ProjectBoardObj.Data.GroupBy(Function(d) d.AssignedEmployeeCode).Select(Function(d) New With {.Code = d.Key, .Description = d.First.FullName}).OrderBy(Function(d) d.Description).ToList,
                                            .Field = "AssignedEmployeeCode",
                                            .Label = "Employees"
                                        })

            ProjectBoardObj.Filters.Add(New AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.Filter With {
                                            .FilterType = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.FilterTypes.Client,
                                            .Watermark = "Select Client(s)",
                                            .Items = JobViews.GroupBy(Function(d) d.ClientCode).Select(Function(d) New With {.Code = d.Key, .Description = d.First.ClientName}).OrderBy(Function(d) d.Description).ToList,
                                            .Field = "ClientCode",
                                            .Label = "Clients"
                                        })

            ProjectBoardObj.Filters.Add(New AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.Filter With {
                                            .FilterType = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.FilterTypes.JobComponent,
                                            .Watermark = "Select Job(s)",
                                            .Items = JobViews.Select(Function(d) New With {.ClientCode = d.ClientCode, .Code = d.JobNumber, .Description = AdvantageFramework.StringUtilities.PadWithCharacter(d.JobNumber, 6, "0", True) & " - " & d.JobDescription}).OrderByDescending(Function(d) d.Code).ToList,
                                            .Field = "JobNumber",
                                            .Label = "Jobs"
                                        })

            ProjectBoardObj.Filters.Add(New AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.Filter With {
                                            .FilterType = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.FilterTypes.AlertState,
                                            .Watermark = "Select Alert State(s)",
                                            .Items = AlertStates.Select(Function(d) New With {.Code = d.ID, .Description = d.Name}).OrderBy(Function(d) d.Description).ToList,
                                            .Field = "AlertStateID",
                                            .Label = "Alert States"
                                        })

            'ProjectBoardObj.Filters.Add(New AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.Filter With {
            '                                .FilterType = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.FilterTypes.AlertState,
            '                                .Watermark = "Select Alert State(s)",
            '                                .Items = AlertStates.Select(Function(d) New With {.Code = d.ID, .Description = d.Name}).OrderBy(Function(d) d.Description).ToList,
            '                                .Field = "AlertStateID",
            '                                .Label = "Alert States"
            '                            })

            Return View(ProjectBoardObj)

        End Function
        <HttpPost>
        Public Function UpdateCardPriority(ByVal Card As AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard) As JsonResult

            'objects
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Updated As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Card.AlertID)

                If Alert IsNot Nothing Then

                    Alert.PriorityLevel = Card.Priority

                    Updated = AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

                End If

            End Using

            Return Json(Updated)

        End Function
        Public Function GetBoardFilterEmployees(ByVal SprintID As Integer) As JsonResult

            'objects
            Dim Employees As IEnumerable = Nothing
            Dim AlertIDs As Integer?() = Nothing
            Dim CardAssignees As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.CardAssignee) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                AlertIDs = (From Item In AdvantageFramework.Database.Procedures.SprintDetail.LoadBySprintID(DbContext, SprintID)
                            Where Item.AlertID <> Nothing
                            Select Item.AlertID).ToArray

                If AlertIDs IsNot Nothing AndAlso AlertIDs.Count > 0 Then

                    CardAssignees = DbContext.Database.SqlQuery(Of AdvantageFramework.ProjectManagement.Agile.Classes.CardAssignee)(String.Format("SELECT * FROM dbo.V_AGILE_CARD_ASSIGNEES WHERE AlertID IN ({0})", String.Join(",", AlertIDs))).ToList

                End If

                If CardAssignees IsNot Nothing AndAlso CardAssignees.Count > 0 Then

                    Employees = (From Item In CardAssignees.GroupBy(Function(assignee) assignee.EmployeeCode)
                                 Where Item.Any(Function(assign) assign.IsCurrentNotify = True)
                                 Select New With {.Code = Item.First.EmployeeCode, .Name = Item.First.EmployeeFullName}).OrderBy(Function(assign) assign.Name).ToList

                End If

                If Employees Is Nothing Then

                    Employees = {}

                End If

            End Using

            Return Json(Employees, JsonRequestBehavior.AllowGet)

        End Function
        Public Function GetWorkItemFilterEmployees(ByVal AlertID As Integer) As JsonResult

            'objects
            Dim Employees As IEnumerable = Nothing
            Dim CardAssignees As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.CardAssignee) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                CardAssignees = DbContext.Database.SqlQuery(Of AdvantageFramework.ProjectManagement.Agile.Classes.CardAssignee)(String.Format("SELECT * FROM dbo.V_AGILE_CARD_ASSIGNEES WHERE AlertID = {0};", AlertID)).ToList

                If CardAssignees IsNot Nothing AndAlso CardAssignees.Count > 0 Then

                    Employees = (From Item In CardAssignees.GroupBy(Function(assignee) assignee.EmployeeCode)
                                 Where Item.Any(Function(assign) assign.IsCurrentNotify = True)
                                 Select New With {.Code = Item.First.EmployeeCode, .Name = Item.First.EmployeeFullName}).OrderBy(Function(assign) assign.Name).ToList

                End If

                If Employees Is Nothing Then

                    Employees = {}

                End If

            End Using

            Return Json(Employees, JsonRequestBehavior.AllowGet)

        End Function

#Region " Board Partial Views "

        Public Function _Board() As ActionResult

            Dim Employees As New Generic.List(Of AdvantageFramework.Database.Views.Employee)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

            End Using

            ViewData("Employees") = Employees
            Return PartialView()

        End Function

        Public Function _BoardHeader(<FromRoute()> ByVal JobNumber As Integer?,
                                     <FromRoute()> ByVal JobComponentNumber As Short?,
                                     <FromRoute()> ByVal FromViewName As String) As ActionResult

            Dim DesignBoard As New AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner(Me.SecuritySession)

            DesignBoard.Load()

            Return PartialView(DesignBoard)

        End Function

#End Region

#Region " API "

        Public Function GetJobsForBoard(ByVal DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest, ByVal BoardID As Integer) As JsonResult

            'objects
            Dim Jobs As IEnumerable = Nothing
            Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Jobs = AdvantageFramework.ProjectManagement.Agile.LoadJobsForBoard(DbContext, BoardID, Me.SecuritySession.UserCode)

                DataSourceResult = Jobs.ToDataSourceResult(DataSourceRequest)

            End Using

            Return Json(DataSourceResult, JsonRequestBehavior.AllowGet)

        End Function
        Public Function GetCurrentJobsForBoard(ByVal BoardID As Integer) As JsonResult

            'objects
            Dim Jobs As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Jobs = (From Item In AdvantageFramework.ProjectManagement.Agile.LoadJobsForBoard(DbContext, BoardID, Me.SecuritySession.UserCode)
                        Where Item.IsOnBoard = True
                        Select Item).ToList

            End Using

            Return Json(Jobs, JsonRequestBehavior.AllowGet)

        End Function

#End Region

#Region " Sprint Views "

        Public Function Sprints(<FromRoute()> ByVal BoardID As Integer?) As ActionResult

            Dim Boards As Generic.List(Of AdvantageFramework.Database.Entities.SprintHeader)

            Boards = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    Boards = AdvantageFramework.Database.Procedures.SprintHeader.Load(DbContext).ToList

                Catch ex As Exception
                    Boards = Nothing
                End Try

            End Using

            If Boards Is Nothing Then Boards = New List(Of AdvantageFramework.Database.Entities.SprintHeader)

            ViewData("NewSprintURL") = Me.NewSprintURL(0)

            Return View(Boards)


        End Function
        Public Function NewSprint(<FromRoute()> ByVal BoardID As Integer, <FromRoute()> ByVal SprintID As Integer?) As ActionResult

            Dim Sprint As New AdvantageFramework.ProjectManagement.Agile.Classes.Sprint(Me.SecuritySession)
            Dim Enabled As Boolean = True

            Sprint.BoardID = BoardID

            If SprintID Is Nothing Then SprintID = 0

            If SprintID = 0 Then

                Sprint.LoadForAdd()

                If Me.CanAdd() = False Then

                    Enabled = False

                End If

            Else

                Sprint.SprintID = SprintID
                Sprint.Load()

                If BoardID = 0 Then

                    BoardID = Sprint.BoardID

                End If

                If Me.CanUpdate() = False Then

                    Enabled = False

                End If

            End If

            ViewData("BoardID") = BoardID
            ViewData("SprintID") = SprintID
            ViewData("Enabled") = Enabled


            Return View(Sprint)

        End Function

        Public Function ProjectBoards(<FromRoute()> ByVal JobNumber As Integer?, <FromRoute()> ByVal JobComponentNumber As Short?) As ActionResult

            Dim Boards As Generic.List(Of AdvantageFramework.Database.Entities.SprintHeader)

            Boards = Nothing

            If JobNumber IsNot Nothing AndAlso JobComponentNumber IsNot Nothing Then

                ViewData("JobNumber") = JobNumber
                ViewData("JobComponentNumber") = JobComponentNumber

                Dim DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    Boards = AdvantageFramework.Database.Procedures.SprintHeader.LoadByJobAndComponentNumber(DbContext, JobNumber, JobComponentNumber).ToList

                Catch ex As Exception
                    Boards = Nothing
                End Try

            End If

            If Boards Is Nothing Then Boards = New List(Of AdvantageFramework.Database.Entities.SprintHeader)

            'Select Case Boards.Count
            '    Case 1

            '        Dim Board As New AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard(SecuritySession)

            '        For Each Sprint As AdvantageFramework.Database.Entities.SprintHeader In Boards

            '            Board.SprintID = Sprint.ID
            '            Exit For

            '        Next

            '        Board.LoadDataBy = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.LoadBy.SprintID
            '        Board.Load()

            '        If Board IsNot Nothing Then

            '            Return View("ProjectBoard", Board)

            '        Else

            '            Return View(Boards)

            '        End If

            '    Case Else

            '        Return View(Boards)

            'End Select
            ViewData("NewBoardURL") = Me.NewBoardURL("ProjectBoards", JobNumber, JobComponentNumber)

            Return View(Boards)

        End Function

        Public Function Sprint(<FromRoute()> ByVal SprintID As Integer) As ActionResult

            Dim ProjectBoardObj As AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard

            ProjectBoardObj = New AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard(Me.SecuritySession)

            ProjectBoardObj.SprintHeaderID = SprintID
            ProjectBoardObj.Allowed = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.AllowedType.TasksAndAssignments

            ProjectBoardObj.LoadDataBy = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.LoadBy.SprintID
            ProjectBoardObj.TimesheetActive = HasAccessToTimesheet(Me.SecuritySession)

            ProjectBoardObj.Load()

            ViewData("Title") = String.Format("{3} • {0} • Week of:  {1} • Number of weeks:  {2}", ProjectBoardObj.SprintHeader.Description,
                                              CType(ProjectBoardObj.SprintHeader.StartDate, Date).ToShortDateString, ProjectBoardObj.SprintHeader.NumberOfWeeks, ProjectBoardObj.Board.Name)
            ViewData("BoardID") = ProjectBoardObj.BoardID
            ViewData("SprintID") = SprintID

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim Sk As AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.SwimLaneKey = Nothing

                Try

                    System.Enum.TryParse(Of AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.SwimLaneKey)(Me._Controller.LoadSwimLaneOption(DbContext), Sk)
                    ProjectBoardObj.ShowSwimLaneBy = Sk

                Catch ex As Exception
                    Sk = Nothing
                End Try
                Try

                    Dim ErrorMessage As String = String.Empty
                    _Controller.CheckSprintForRemovedOrClosedJobs(DbContext, SprintID, ErrorMessage)

                Catch ex As Exception
                End Try

            End Using

            Me.CanAdd()
            Me.CanUpdate()
            Me.CanPrint()

            ''Dim BackgroundWork As New AdvantageFramework.ProjectManagement.Agile.Classes.WorkItemAsync(Me.SecuritySession)
            ''BackgroundWork.SprintHeaderID = SprintID
            ''BackgroundWork.CheckSprintEmployeeRecords()

            Return View(ProjectBoardObj)

        End Function
        Private Function HasAccessToTimesheet(ByRef SecuritySession As AdvantageFramework.Security.Session) As Boolean

            Dim HasAccess As Boolean = False
            Dim SessionKey As String = "HasAccessToTimesheet"

            If Session(SessionKey) Is Nothing Then

                Try

                    If MiscFN.IsClientPortal = False Then

                        HasAccess = AdvantageFramework.Security.DoesUserHaveAccessToModule(SecuritySession,
                                                                                           AdvantageFramework.Security.Modules.Employee_Timesheet.ToString,
                                                                                           SecuritySession.User)

                    End If

                Catch ex As Exception
                    HasAccess = False
                End Try

                Session(SessionKey) = HasAccess

            Else

                HasAccess = CType(Session(SessionKey), Boolean)

            End If

            Return HasAccess

        End Function

        Public Function ProjectBoard(<FromRoute()> ByVal SprintID As Integer?,
                                     <FromRoute()> ByVal JobNumber As Integer?,
                                     <FromRoute()> ByVal JobComponentNumber As Short?,
                                     <FromRoute()> ByVal IncludeType As Short?) As ActionResult

            Dim ProjectBoardObj As AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard

            ProjectBoardObj = New AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard(Me.SecuritySession)

            ProjectBoardObj.SprintHeaderID = SprintID
            ProjectBoardObj.JobNumber = JobNumber
            ProjectBoardObj.JobComponentNumber = JobComponentNumber
            ProjectBoardObj.TimesheetActive = HasAccessToTimesheet(Me.SecuritySession)

            If IncludeType Is Nothing Then

                ProjectBoardObj.Allowed = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.AllowedType.TasksAndAssignments

            Else

                ProjectBoardObj.Allowed = CType(IncludeType, AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.AllowedType)

            End If

            ProjectBoardObj.LoadDataBy = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.LoadBy.SprintID

            ProjectBoardObj.Load()

            Return View(ProjectBoardObj)

        End Function
        'Public Function ProjectBoard(<FromRoute()> ByVal SprintID As Integer?,
        '                             <FromRoute()> ByVal JobNumber As Integer?, <FromRoute()> ByVal JobComponentNumber As Short?,
        '                             <FromRoute()> ByVal IncludeType As Short?) As ActionResult

        '    Dim ProjectBoardObj As AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard

        '    ProjectBoardObj = New AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard(Me.SecuritySession)

        '    ProjectBoardObj.LoadDataBy = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.LoadBy.JobComponent
        '    ProjectBoardObj.JobNumber = JobNumber
        '    ProjectBoardObj.JobComponentNumber = JobComponentNumber

        '    If IncludeType Is Nothing Then

        '        ProjectBoardObj.Allowed = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.AllowedType.TasksAndAssignments

        '    Else

        '        ProjectBoardObj.Allowed = CType(IncludeType, AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.AllowedType)

        '    End If


        '    ProjectBoardObj.Load()

        '    Return View(ProjectBoardObj)

        'End Function
        Public Function EmployeeBoard(<FromRoute()> ByVal EmployeeCode As String) As ActionResult

            Dim ProjectBoardObj As AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard

            ProjectBoardObj = New AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard(Me.SecuritySession)

            ProjectBoardObj.EmployeeCode = EmployeeCode
            ProjectBoardObj.Allowed = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.AllowedType.TasksAndAssignments
            ProjectBoardObj.TimesheetActive = HasAccessToTimesheet(Me.SecuritySession)

            ProjectBoardObj.LoadDataBy = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.LoadBy.EmployeeCode

            ProjectBoardObj.Load()

            Return View(ProjectBoardObj)

        End Function


        Public Function TestView() As ActionResult

            'Dim AssignmentTemplates As Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate)
            'Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

            '    ''AssignmentTemplates = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadAllActive(DbContext).ToList
            '    'AssignmentTemplates = (From AlertAssignmentTemplate In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate).Include("AlertAssignmentTemplateEmployees").Include("AlertAssignmentTemplateStates").Include("JobComponents")
            '    '                       Where AlertAssignmentTemplate.IsActive Is Nothing OrElse AlertAssignmentTemplate.IsActive = True
            '    '                       Order By AlertAssignmentTemplate.Name
            '    '                       Select AlertAssignmentTemplate).ToList

            'End Using

            Return View()

        End Function
        Public Function Story(<FromRoute()> ByVal SprintID As Integer?,
                              <FromRoute()> ByVal JobNumber As Integer?, <FromRoute()> ByVal JobComponentNumber As Short?) As ActionResult

            Dim SprintHeader As AdvantageFramework.Database.Entities.SprintHeader

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                If SprintID Is Nothing Then

                    SprintHeader = New AdvantageFramework.Database.Entities.SprintHeader

                Else

                    SprintHeader = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintHeaderID(DbContext, SprintID)

                    If SprintHeader Is Nothing Then

                        SprintHeader = New AdvantageFramework.Database.Entities.SprintHeader

                    End If

                End If

            End Using

            Return View(SprintHeader)

        End Function


#End Region

#Region " Hours "

        <CustomRoute("~/ProjectManagement_Agile_NewWorkItemTimeDialogFromOldDashboard")>
        Public Function NewWorkItemTimeDialogFromOldDashboard(ByVal AlertID As Integer) As ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New AureliaModel

            AureliaModel.App = "modules/project-management/agile/new-work-item-time"
            AureliaModel.Parameters.Add("AlertID", AlertID)
            AureliaModel.Parameters.Add("IsOldDash", True)

            Return Aurelia(AureliaModel)

        End Function
        <CustomRoute("~/ProjectManagement_Agile_NewWorkItemTimeDialogFromOld")>
        Public Function NewWorkItemTimeDialogFromOld(ByVal AlertID As Integer) As ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New AureliaModel

            AureliaModel.App = "modules/project-management/agile/new-work-item-time"
            AureliaModel.Parameters.Add("AlertID", AlertID)
            AureliaModel.Parameters.Add("IsOldPage", True)

            Return Aurelia(AureliaModel)

        End Function
        <CustomRoute("~/ProjectManagement_Agile_NewWorkItemTimeDialog")>
        Public Function NewWorkItemTimeDialog(ByVal AlertID As Integer) As ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New AureliaModel

            AureliaModel.App = "modules/project-management/agile/new-work-item-time"
            AureliaModel.Parameters.Add("AlertID", AlertID)

            Return Aurelia(AureliaModel)

        End Function
        Public Function NewWorkItemTime(<FromRoute()> ByVal AlertID As Integer) As ActionResult

            Dim AlertTimeEntry As New AdvantageFramework.ViewModels.ProjectManagement.Agile.AlertTimeEntryViewModel
            Dim EmployeeCode As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                AlertTimeEntry.AlertID = AlertID

                EmployeeCode = Me.SecuritySession.User.EmployeeCode

                If String.IsNullOrWhiteSpace(EmployeeCode) = True Then

                    EmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = '{0}';", Me.SecuritySession.UserCode.ToUpper())).FirstOrDefault

                End If

                If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                    Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
                    Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                    Dim JobNumber As Integer = 0

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)
                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                    If Alert IsNot Nothing Then

                        If Alert.JobNumber IsNot Nothing Then JobNumber = Alert.JobNumber
                        AlertTimeEntry.Title = Alert.Subject

                    End If
                    If Employee IsNot Nothing Then

                        AlertTimeEntry.EmployeeDefaultFunctionCode = Employee.FunctionCode

                    End If

                    AlertTimeEntry.CommentRequired = AdvantageFramework.EmployeeTimesheet.CheckTimeCommentsRequired(DbContext, JobNumber, 0, 0)
                    AlertTimeEntry.Functions = AdvantageFramework.Database.Procedures.Function.LoadForEmployeeDirectTime(DbContext, EmployeeCode)
                    AlertTimeEntry.Date = Me.TimeZoneToday

                End If

            End Using

            Return View(AlertTimeEntry)

        End Function
        Public Function HoursByAlertID(<FromRoute()> ByVal SprintHeaderID As Integer,
                                       <FromRoute()> ByVal AlertID As Integer) As ActionResult

            Dim Hours As New AdvantageFramework.ProjectManagement.Agile.Classes.WeeklyHours(Me.SecuritySession)
            Dim HasWeeklyHours As Boolean = False

            Hours.SprintHeaderID = SprintHeaderID
            Hours.AlertID = AlertID

            Hours.Load()

            ViewData("SprintHeaderID") = SprintHeaderID
            ViewData("AlertID") = AlertID

            Dim CanUpdate As Boolean
            Dim SecurityModule As AdvantageFramework.Security.Modules = AdvantageFramework.Security.Methods.Modules.Desktop_Alerts

            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)
            End Using

            'If Alert IsNot Nothing Then
            '    If Alert.IsWorkItem = False Then
            '        CanUpdate = AdvantageFramework.Security.CanUserUpdateInModule(Me.SecuritySession, SecurityModule)
            '    Else
            '        CanUpdate = Me.LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit)
            '    End If
            'End If

            Dim AlertSecurity As AdvantageFramework.ViewModels.Desktop.AlertSecurityViewModel = Nothing
            Dim KeyName As String = "AlSec"

            If Alert.IsWorkItem = True AndAlso Alert.TaskSequenceNumber.GetValueOrDefault(-1) >= 0 Then

                KeyName = "PrjSec"

            End If

            If HttpContext.Session(KeyName) IsNot Nothing Then

                AlertSecurity = CType(HttpContext.Session(KeyName), AdvantageFramework.ViewModels.Desktop.AlertSecurityViewModel)

                CanUpdate = AlertSecurity.CanUpdate
            Else

                AlertSecurity = New AdvantageFramework.ViewModels.Desktop.AlertSecurityViewModel

                If KeyName = "PrjSec" Then

                    SecurityModule = AdvantageFramework.Security.Methods.Modules.ProjectManagement_ProjectSchedule

                End If

                AlertSecurity.CanAdd = AdvantageFramework.Security.CanUserAddInModule(Me.SecuritySession, SecurityModule)

                If KeyName = "AlSec" Then

                    AlertSecurity.CanUpdate = AdvantageFramework.Security.CanUserUpdateInModule(Me.SecuritySession, SecurityModule)

                Else

                    AlertSecurity.CanUpdate = Me.LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit)

                End If
                AlertSecurity.CanPrint = AdvantageFramework.Security.CanUserPrintInModule(Me.SecuritySession, SecurityModule)
                AlertSecurity.CanCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(Me.SecuritySession, SecurityModule)
                AlertSecurity.CanCustom2 = AdvantageFramework.Security.CanUserCustom2InModule(Me.SecuritySession, SecurityModule)

                HttpContext.Session(KeyName) = AlertSecurity

                CanUpdate = AlertSecurity.CanUpdate

            End If



            ViewData("CanUpdate") = CanUpdate

            If Hours IsNot Nothing Then

                ViewData("HasWeeklyHours") = Hours.HasWeeklyHours
                ViewData("HasStartDate") = Hours.HasStartDate
                ViewData("HasDueDate") = Hours.HasDueDate

            End If

            Return View(Hours)

        End Function

        <HttpGet>
        Public Function RefreshWeeklyHours(ByVal AlertID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim WeeklyHours As New AdvantageFramework.ProjectManagement.Agile.Classes.WeeklyHours(Me.SecuritySession)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                WeeklyHours.AlertID = AlertID
                WeeklyHours.Load()

            End Using

            Return MaxJson(WeeklyHours, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function CheckAndUpdateAlertEmployeesAndHours(ByVal AlertID As Integer, ByVal CreatePriorWeeks As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim Hours As New AdvantageFramework.ProjectManagement.Agile.Classes.WeeklyHours(Me.SecuritySession)

                Hours.AlertID = AlertID
                Hours.CheckAndUpdateAlertEmployeesAndHours(DbContext, CreatePriorWeeks)

                Success = Hours.Result.Success
                ErrorMessage = Hours.Result.Message

                If Success = True Then

                    Webvantage.SignalR.Classes.NotificationHub.RefreshAlertHours(DbContext, AlertID, Me.SecuritySession.UserCode, True)

                End If

            End Using

            ReturnObject = New With {.Success = Success, .ErrorMessage = ErrorMessage}

            Return Json(ReturnObject, JsonRequestBehavior.AllowGet)

        End Function

        <AcceptVerbs("POST")>
        Public Function UpdateEmployeeHours(ByVal AlertID As Integer, ByVal EmployeeCode As String, ByVal Hours As Decimal) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim list As System.Collections.Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel) = Nothing
            Dim HoursAllowed As Decimal = 0.0
            Dim HoursAllocated As Decimal = 0.0
            Dim HoursChanged As Boolean = False
            Dim TaskHoursOver As Decimal = 0.0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                    If Alert.AlertCategoryID <> 71 Then

                        Dim Assignee As AdvantageFramework.Database.Entities.AlertRecipient = Nothing

                        Assignee = AdvantageFramework.Database.Procedures.AlertRecipient.LoadAssigneeByAlertIDAndEmployeeCode(DbContext, AlertID, EmployeeCode)

                        If Assignee IsNot Nothing Then

                            Assignee.HoursAllowed = Hours

                            Success = AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, Assignee)

                        Else

                            Dim DismissedAssignee As AdvantageFramework.Database.Entities.AlertRecipientDismissed = Nothing

                            DismissedAssignee = AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadAssigneeByAlertIDAndEmployeeCode(DbContext, AlertID, EmployeeCode)

                            If DismissedAssignee IsNot Nothing Then

                                'Update dismissed or undismiss first?
                                DismissedAssignee.HoursAllowed = Hours

                                Success = AdvantageFramework.Database.Procedures.AlertRecipientDismissed.Update(DbContext, DismissedAssignee)

                            End If

                        End If

                    Else
                        ' task
                        Dim SQL As String = String.Format("UPDATE JOB_TRAFFIC_DET_EMPS SET HOURS_ALLOWED = {0} where ID in (
                                                    			select ID from JOB_TRAFFIC_DET_EMPS jtd
					                                                JOIN ALERT A ON A.JOB_NUMBER = jtd.JOB_NUMBER 
					                                                AND A.JOB_COMPONENT_NBR = jtd.JOB_COMPONENT_NBR 
					                                                AND A.TASK_SEQ_NBR = jtd.SEQ_NBR 
					                                                AND A.ALERT_ID = {1}
					                                                WHERE jtd.EMP_CODE = '{2}')", Hours, AlertID, EmployeeCode)

                        DbContext.Database.ExecuteSqlCommand(SQL)

                        Success = True

                    End If

                    If Success = True Then

                        Try

                            Dim AlertHours As AdvantageFramework.Controller.Desktop.AlertController.AlertHours = Nothing

                            Try

                                AlertHours = DbContext.Database.SqlQuery(Of AdvantageFramework.Controller.Desktop.AlertController.AlertHours) _
                                                                        (String.Format("EXEC [dbo].[advsp_alert_get_hours] {0};", AlertID)).SingleOrDefault

                            Catch ex As Exception
                                AlertHours = Nothing
                            End Try
                            If AlertHours IsNot Nothing Then

                                HoursAllowed = AlertHours.HoursAllowed
                                HoursAllocated = AlertHours.HoursAllocated

                            End If

                        Catch ex As Exception
                        End Try

                        'If HoursChanged = True Then

                        Webvantage.SignalR.Classes.NotificationHub.RefreshAlertHours(DbContext, AlertID, Me.SecuritySession.UserCode, True)

                        'End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                Success = False
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, New With {.HoursAllowed = FormatNumber(HoursAllowed, 2),
                                                                                                             .HoursAllocated = FormatNumber(HoursAllocated, 2),
                                                                                                             .Items = Nothing,
                                                                                                             .TaskHoursOver = TaskHoursOver}))

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateWorkItemHours(ByVal SprintEmployeeID As Integer, ByVal Hours As Decimal) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim list As System.Collections.Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel) = Nothing
            Dim HoursAllowed As Decimal = 0.0
            Dim HoursAllocated As Decimal = 0.0
            Dim HoursChanged As Boolean = False
            Dim HoursSum As Decimal = 0.0
            Dim TaskHoursOver As Decimal = 0.0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim SprintEmployee As AdvantageFramework.Database.Entities.SprintEmployee = Nothing

                    SprintEmployee = AdvantageFramework.Database.Procedures.SprintEmployee.LoadByID(DbContext, SprintEmployeeID)

                    If SprintEmployee IsNot Nothing Then

                        'Try

                        '    TaskHoursOver = DbContext.Database.SqlQuery(Of Decimal)(String.Format("EXEC [dbo].[advsp_agile_check_over_task_hours] {0}, {1};", SprintEmployee.ID, Hours)).SingleOrDefault

                        'Catch ex As Exception
                        '    TaskHoursOver = 0.0
                        'End Try

                        If TaskHoursOver = 0 Then

                            If SprintEmployee.Hours IsNot Nothing AndAlso SprintEmployee.Hours <> Hours Then

                                HoursChanged = True

                            End If
                            'If HoursChanged = True Then

                            SprintEmployee.Hours = Hours
                            Success = AdvantageFramework.Database.Procedures.SprintEmployee.Update(DbContext, SprintEmployee)

                            'End If

                            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, SprintEmployee.AlertID)

                            If Alert.AlertCategoryID = 71 Then

                                HoursSum = DbContext.Database.SqlQuery(Of Decimal)(String.Format("SELECT SUM(HOURS) FROM SPRINT_EMPLOYEE WHERE ALERT_ID = '{0}' AND EMP_CODE = '{1}';", SprintEmployee.AlertID, SprintEmployee.EmployeeCode)).FirstOrDefault

                                Dim SQL As String = String.Format("UPDATE JOB_TRAFFIC_DET_EMPS SET HOURS_ALLOWED = {0} where ID in (
                                                    			select ID from JOB_TRAFFIC_DET_EMPS jtd
					                                                JOIN ALERT A ON A.JOB_NUMBER = jtd.JOB_NUMBER 
					                                                AND A.JOB_COMPONENT_NBR = jtd.JOB_COMPONENT_NBR 
					                                                AND A.TASK_SEQ_NBR = jtd.SEQ_NBR 
					                                                AND A.ALERT_ID = {1}
					                                                WHERE jtd.EMP_CODE = '{2}')", HoursSum, SprintEmployee.AlertID, SprintEmployee.EmployeeCode)

                                DbContext.Database.ExecuteSqlCommand(SQL)

                                Success = True

                            End If

                            If Success = True Then

                                    Try

                                        DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_agile_update_workitemhours] {0};", SprintEmployee.AlertID))

                                    Catch ex As Exception
                                    End Try
                                    Try

                                        Dim AlertHours As AdvantageFramework.Controller.Desktop.AlertController.AlertHours = Nothing

                                        Try

                                            AlertHours = DbContext.Database.SqlQuery(Of AdvantageFramework.Controller.Desktop.AlertController.AlertHours) _
                                                                            (String.Format("EXEC [dbo].[advsp_alert_get_hours] {0};", SprintEmployee.AlertID)).SingleOrDefault

                                        Catch ex As Exception
                                            AlertHours = Nothing
                                        End Try
                                        If AlertHours IsNot Nothing Then

                                            HoursAllowed = AlertHours.HoursAllowed
                                            HoursAllocated = AlertHours.HoursAllocated

                                        End If

                                    Catch ex As Exception
                                    End Try

                                    If HoursChanged = True Then

                                        Webvantage.SignalR.Classes.NotificationHub.RefreshAlertHours(DbContext, SprintEmployee.AlertID, Me.SecuritySession.UserCode, True)

                                    End If

                                End If

                            Else

                                Success = False

                            Select Case TaskHoursOver
                                Case 1

                                    ErrorMessage = "One hour over allowed hours."

                                Case > 1

                                    ErrorMessage = String.Format("{0} hours over allowed hours.", FormatNumber(TaskHoursOver, 2))

                            End Select

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                Success = False
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, New With {.HoursAllowed = FormatNumber(HoursAllowed, 2),
                                                                                                             .HoursAllocated = FormatNumber(HoursAllocated, 2),
                                                                                                             .Items = Nothing,
                                                                                                             .TaskHoursOver = TaskHoursOver}))

        End Function
        <AcceptVerbs("POST")>
        Public Function SaveHoursToAlert(ByVal AlertID As Integer, ByVal EntryDate As Date, ByVal FunctionCode As String, ByVal Hours As Decimal, ByVal Comment As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0
            Dim EmployeeCode As String = String.Empty
            'Dim SomeReturnProperty As String

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    EmployeeCode = Me.SecuritySession.User.EmployeeCode
                    Try

                        If String.IsNullOrWhiteSpace(EmployeeCode) = True Then

                            EmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = '{0}';", Me.SecuritySession.UserCode.ToUpper())).FirstOrDefault

                        End If


                    Catch ex As Exception
                        EmployeeCode = String.Empty
                    End Try

                    If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                        Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                        If Alert IsNot Nothing AndAlso Alert.JobNumber IsNot Nothing AndAlso Alert.JobComponentNumber IsNot Nothing Then

                            EntryDate = New Date(EntryDate.Year, EntryDate.Month, EntryDate.Day)

                            AdvantageFramework.Database.Procedures.Generic.TimeZoneTodayForEmployee(DbContext, EmployeeCode)

                            Success = AdvantageFramework.EmployeeTimesheet.SaveTimesheetDay(Me.SecuritySession, DbContext, 0, 0, EmployeeCode, EntryDate, FunctionCode,
                                                                                            Hours, Alert.JobNumber, Alert.JobComponentNumber, "", "", Me.SecuritySession.UserCode, Comment, AlertID,
                                                                                            ErrorMessage)

                        End If

                    End If

                    If Success = True Then

                        'ReturnObject = New With {.SomeJsProperty = SomeReturnProperty}

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("POST")>
        Public Function DeleteWorkItemHours(ByVal AlertID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_agile_delete_weekly_hours] {0};", AlertID))
                        Success = True
                        ErrorMessage = ""

                    Catch ex As Exception
                        ErrorMessage = ex.Message.ToString
                        Success = False
                    End Try
                    If Success = True Then

                        Webvantage.SignalR.Classes.NotificationHub.RefreshAlertHours(DbContext, AlertID, Me.SecuritySession.UserCode, True)

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                Success = False
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateAssignmentStartDate(ByVal AlertID As Integer, ByVal StartDate As Date) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Try

                        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                        Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                        If Alert IsNot Nothing Then

                            StartDate = CType(StartDate.ToShortDateString, Date)
                            Alert.StartDate = StartDate

                            AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

                            If Alert.AlertLevel = "BRD" OrElse
                                (Alert.JobNumber IsNot Nothing AndAlso Alert.JobNumber > 0 AndAlso
                                Alert.JobComponentNumber IsNot Nothing AndAlso Alert.JobComponentNumber > 0 AndAlso
                                Alert.TaskSequenceNumber IsNot Nothing AndAlso Alert.TaskSequenceNumber > -1) Then

                                Dim Task As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

                                Task = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext,
                                                                                                                                                     Alert.JobNumber,
                                                                                                                                                     Alert.JobComponentNumber,
                                                                                                                                                     Alert.TaskSequenceNumber)

                                If Task IsNot Nothing Then

                                    Task.StartDate = StartDate

                                    AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, Task)

                                End If

                            End If

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message.ToString
                        Success = False
                    End Try

                    If Success = True Then

                        Webvantage.SignalR.Classes.NotificationHub.RefreshNewAlertView(DbContext, AlertID, 0, Me.SecuritySession.UserCode, "", True)

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                Success = False
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateAssignmentDueDate(ByVal AlertID As Integer, ByVal DueDate As Date) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Try

                        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                        Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                        If Alert IsNot Nothing Then

                            DueDate = CType(DueDate.ToShortDateString, Date)

                            Alert.DueDate = DueDate

                            AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

                            If Alert.AlertLevel = "BRD" OrElse
                                (Alert.JobNumber IsNot Nothing AndAlso Alert.JobNumber > 0 AndAlso
                                Alert.JobComponentNumber IsNot Nothing AndAlso Alert.JobComponentNumber > 0 AndAlso
                                Alert.TaskSequenceNumber IsNot Nothing AndAlso Alert.TaskSequenceNumber > -1) Then

                                Dim Task As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

                                Task = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext,
                                                                                                                                                     Alert.JobNumber,
                                                                                                                                                     Alert.JobComponentNumber,
                                                                                                                                                     Alert.TaskSequenceNumber)

                                If Task IsNot Nothing Then

                                    Task.DueDate = DueDate

                                    AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, Task)

                                End If

                            End If

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message.ToString
                        Success = False
                    End Try

                    If Success = True Then

                        Webvantage.SignalR.Classes.NotificationHub.RefreshNewAlertView(DbContext, AlertID, 0, Me.SecuritySession.UserCode, "", True)

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                Success = False
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function


#Region " Partial Views "

        Public Function _HoursGrid() As ActionResult

            Return PartialView()

        End Function

#End Region

#End Region

#Region " Backlog Manager Views "

        Public Function BacklogManager() As ActionResult

            Return View()

        End Function

#End Region

#End Region

#End Region

#Region " Methods "

#Region " Old Board Methods "

#Region " Board Creation "

        <AcceptVerbs("POST")>
        Public Function DesignReload(ByVal BoardID As Integer, ByVal AlertTemplateID As Integer?) As JsonResult

            Dim DesignBoard As New AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner(Me.SecuritySession)
            Dim ReturnObject As Object = Nothing

            Dim Cols As IEnumerable
            Dim Crds As IEnumerable

            DesignBoard.BoardHeaderID = BoardID
            If AlertTemplateID IsNot Nothing Then
                DesignBoard.FilterAlertTemplateID = AlertTemplateID
                DesignBoard.FilterStates = True
            End If
            DesignBoard.Load()

            Cols = DesignBoard.Columns
            Crds = DesignBoard.Cards

            ReturnObject = New With {.Columns = Cols, .Cards = Crds}

            Return Json(ReturnObject, JsonRequestBehavior.AllowGet)
            'Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(True, "", DesignBoard))

        End Function

        <AcceptVerbs("POST")>
        Public Function DesignMoveStateCard(ByVal BoardHeaderID As Integer, ByVal BoardColumnID As Integer,
                                            ByVal TargetBoardColumnID As Integer, ByVal StateID As Integer) As JsonResult

            Dim Moved As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim HasIdentifier As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim BoardDetail As AdvantageFramework.Database.Entities.BoardDetail = Nothing

                    BoardDetail = AdvantageFramework.Database.Procedures.BoardDetail.LoadByBoardHeaderIDandStateID(DbContext, BoardHeaderID, StateID)

                    If BoardDetail Is Nothing Then

                        If TargetBoardColumnID <> -3 Then

                            BoardDetail = New AdvantageFramework.Database.Entities.BoardDetail

                            BoardDetail.BoardHeaderID = BoardHeaderID
                            BoardDetail.BoardColumnID = TargetBoardColumnID
                            BoardDetail.AlertStateID = StateID

                            Moved = AdvantageFramework.Database.Procedures.BoardDetail.Insert(DbContext, BoardDetail)

                        End If
                    Else

                        If TargetBoardColumnID = -3 Then

                            Moved = AdvantageFramework.Database.Procedures.BoardDetail.Delete(DbContext, BoardDetail)

                        Else

                            BoardDetail.BoardColumnID = TargetBoardColumnID

                            Moved = AdvantageFramework.Database.Procedures.BoardDetail.Update(DbContext, BoardDetail)

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Moved, ErrorMessage, Nothing))

        End Function

        '<AcceptVerbs("POST")>
        'Public Function DesignMoveStateCard(ByVal BoardHeaderID As Integer, ByVal BoardColumnID As Integer,
        '                                    ByVal TargetBoardColumnID As Integer, ByVal StateID As Integer) As JsonResult

        '    Dim Moved As Boolean = False
        '    Dim ErrorMessage As String = String.Empty
        '    Dim HasIdentifier As Boolean = False

        '    Try

        '        Moved = Me.DesignMoveStateCardCrud(BoardHeaderID, BoardColumnID, TargetBoardColumnID, StateID, ErrorMessage)

        '    Catch ex As Exception
        '        ErrorMessage = ex.Message.ToString
        '    End Try

        '    Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Moved, ErrorMessage, Nothing))

        'End Function
        <AcceptVerbs("POST")>
        Public Function AddBoardHeader(ByVal AssignmentTemplateID As Integer,
                                       ByVal BoardName As String, ByVal BoardDescription As String,
                                       ByVal IsSequential As Boolean, ByVal ForceAllColumns As Boolean, ByVal IsActive As Boolean,
                                       ByVal TrackChanges As Boolean, ByVal EmailOnChange As Boolean) As JsonResult

            Dim Saved As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim AssignmentTemplate As AdvantageFramework.Database.Entities.AlertAssignmentTemplate = Nothing
            Dim IsUsingBasicBoard As Boolean = False
            Dim NewBoard As AdvantageFramework.Database.Entities.BoardHeader = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    'Try

                    If AssignmentTemplateID > 0 Then

                        AssignmentTemplate = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadByAlertAssignmentTemplateID(DbContext, AssignmentTemplateID)

                    End If

                    'Catch ex As Exception
                    '    AssignmentTemplate = Nothing
                    'End Try

                    'If AssignmentTemplate Is Nothing Then

                    '    Try

                    '        AssignmentTemplate = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadBasicBoardTemplate(DbContext)

                    '        If AssignmentTemplate IsNot Nothing Then

                    '            IsUsingBasicBoard = True
                    '            AssignmentTemplateID = AssignmentTemplate.ID

                    '        End If

                    '    Catch ex As Exception
                    '        AssignmentTemplate = Nothing
                    '    End Try

                    '    If AssignmentTemplate Is Nothing Then 'Use board as new assignment template?

                    '        AssignmentTemplate = New AdvantageFramework.Database.Entities.AlertAssignmentTemplate

                    '        AssignmentTemplate.Name = BoardName
                    '        AssignmentTemplate.IsActive = True
                    '        AssignmentTemplate.IsDigitalAsset = False

                    '        If AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.Insert(DbContext, AssignmentTemplate) = True Then

                    '            AssignmentTemplateID = AssignmentTemplate.ID

                    '        End If

                    '    End If

                    'End If

                    'If AssignmentTemplate IsNot Nothing Then

                    NewBoard = New AdvantageFramework.Database.Entities.BoardHeader

                    NewBoard.Name = BoardName
                    NewBoard.Description = BoardDescription

                    If AssignmentTemplateID > 0 Then

                        NewBoard.AlertTemplateID = AssignmentTemplateID

                    End If

                    NewBoard.IsSequential = IsSequential
                    NewBoard.ForceAllColumns = ForceAllColumns
                    NewBoard.CreatedDate = Now.Date
                    NewBoard.IsSystem = False
                    NewBoard.IsActive = IsActive
                    NewBoard.TrackChanges = TrackChanges
                    NewBoard.EmailOnChange = EmailOnChange

                    NewBoard.CreatedBy = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = '{0}';", Me.SecuritySession.UserCode.ToUpper())).SingleOrDefault.ToString

                    Saved = AdvantageFramework.Database.Procedures.BoardHeader.Insert(DbContext, NewBoard)

                    'If Saved = True AndAlso IsUsingBasicBoard = True Then

                    '    Dim BasicBoardStates As Generic.List(Of AdvantageFramework.Database.Entities.AlertState) = Nothing

                    '    BasicBoardStates = AdvantageFramework.Database.Procedures.AlertState.LoadByAlertAssignmentTemplateID(DbContext, AssignmentTemplateID).ToList

                    '    If BasicBoardStates IsNot Nothing AndAlso BasicBoardStates.Count > 0 Then

                    '        Dim NewBoardColumn As AdvantageFramework.Database.Entities.BoardColumn = Nothing
                    '        Dim NewBoardDetail As AdvantageFramework.Database.Entities.BoardDetail = Nothing
                    '        Dim i As Integer = 0

                    '        For Each AlertState As AdvantageFramework.Database.Entities.AlertState In BasicBoardStates

                    '            NewBoardColumn = New AdvantageFramework.Database.Entities.BoardColumn

                    '            NewBoardColumn.Name = AlertState.Name
                    '            NewBoardColumn.Description = AlertState.Name
                    '            NewBoardColumn.ToolTip = AlertState.Name
                    '            NewBoardColumn.SequenceNumber = i
                    '            NewBoardColumn.BoardHeaderID = NewBoard.ID
                    '            NewBoardColumn.IsSystem = False

                    '            If AdvantageFramework.Database.Procedures.BoardColumn.Insert(DbContext, NewBoardColumn) = True Then

                    '                Try

                    '                    NewBoardDetail = New AdvantageFramework.Database.Entities.BoardDetail

                    '                    NewBoardDetail.BoardHeaderID = NewBoard.ID
                    '                    NewBoardDetail.BoardColumnID = NewBoardColumn.ID
                    '                    NewBoardDetail.SequenceNumber = i
                    '                    NewBoardDetail.AlertStateID = AlertState.ID

                    '                    AdvantageFramework.Database.Procedures.BoardDetail.Insert(DbContext, NewBoardDetail)

                    '                    NewBoardDetail = Nothing

                    '                Catch ex As Exception
                    '                    NewBoardDetail = Nothing
                    '                End Try

                    '            End If

                    '            NewBoardColumn = Nothing

                    '            i += 1

                    '        Next

                    '    End If

                    'End If

                    'End If

                    If Saved = True AndAlso NewBoard IsNot Nothing Then

                        ReturnObject = New With {.BoardHeaderID = NewBoard.ID}

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Saved, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateBoardHeader(ByVal BoardHeaderID As Integer, ByVal BoardName As String, ByVal BoardDescription As String,
                                          ByVal AlertTemplateID As Integer?,
                                          ByVal IsSequential As Boolean, ByVal ForceAllColumns As Boolean, ByVal ExcludeTasks As Boolean, ByVal IsActive As Boolean,
                                          ByVal TrackChanges As Boolean, ByVal EmailOnChange As Boolean) As JsonResult

            Dim Saved As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim BoardHeader As AdvantageFramework.Database.Entities.BoardHeader = Nothing

                    BoardHeader = AdvantageFramework.Database.Procedures.BoardHeader.LoadByBoardID(DbContext, BoardHeaderID)

                    If BoardHeader IsNot Nothing Then

                        BoardHeader.Name = BoardName
                        BoardHeader.Description = BoardDescription
                        BoardHeader.IsSequential = IsSequential
                        BoardHeader.ForceAllColumns = ForceAllColumns
                        BoardHeader.LastModified = Now.Date
                        BoardHeader.AlertTemplateID = AlertTemplateID
                        BoardHeader.ExcludeTasks = ExcludeTasks
                        BoardHeader.IsActive = IsActive
                        BoardHeader.TrackChanges = TrackChanges
                        BoardHeader.EmailOnChange = EmailOnChange

                        Saved = AdvantageFramework.Database.Procedures.BoardHeader.Update(DbContext, BoardHeader)

                        If Saved = True Then

                            ReturnObject = New With {.BoardHeaderID = BoardHeader.ID}

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Saved, ErrorMessage, ReturnObject))

        End Function

        <AcceptVerbs("POST")>
        Public Function MoveColumn(ByVal BoardID As Integer, ByVal BoardColumnID As Integer, ByVal Direction As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim SomeReturnProperty As String

            Try

                If String.IsNullOrWhiteSpace(Direction) = True Then

                    Direction = "right"

                Else

                    Direction = Direction.Trim.ToLower

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim Columns As Generic.List(Of AdvantageFramework.Database.Entities.BoardColumn) = Nothing

                    Columns = AdvantageFramework.Database.Procedures.BoardColumn.LoadByBoardID(DbContext, BoardID).ToList

                    If Columns IsNot Nothing Then

                        Dim ColumnIndex As Integer = 0
                        Dim PreviousIndex As Integer = 0
                        Dim NextIndex As Integer = 0

                        Dim ColumnID As Integer = 0
                        Dim PreviousColumnID As Integer = 0
                        Dim NextColumnID As Integer = 0

                        Dim Indices As Integer()

                        Indices = (From Column In Columns
                                   Select Column.ID).ToArray

                        For i As Integer = 0 To Indices.Length - 1

                            If Indices(i) = BoardColumnID Then

                                Success = True

                                ColumnIndex = i
                                ColumnID = Indices(ColumnIndex)

                                If Direction = "right" Then

                                    NextIndex = ColumnIndex + 1
                                    If NextIndex > Indices.Length - 1 Then NextIndex = Indices.Length - 1
                                    NextColumnID = Indices(NextIndex)

                                    Indices(NextIndex) = ColumnID
                                    Indices(ColumnIndex) = NextColumnID

                                Else

                                    PreviousIndex = ColumnIndex - 1
                                    If PreviousIndex < 0 Then PreviousIndex = 0
                                    PreviousColumnID = Indices(PreviousIndex)

                                    Indices(PreviousIndex) = ColumnID
                                    Indices(ColumnIndex) = PreviousColumnID

                                End If

                                Exit For

                            End If

                        Next

                        If Success = True Then

                            Dim CurrentColumn As AdvantageFramework.Database.Entities.BoardColumn = Nothing

                            For u As Integer = 0 To Indices.Length - 1

                                CurrentColumn = AdvantageFramework.Database.Procedures.BoardColumn.LoadByID(DbContext, Indices(u))

                                If CurrentColumn IsNot Nothing Then

                                    CurrentColumn.SequenceNumber = u
                                    AdvantageFramework.Database.Procedures.BoardColumn.Update(DbContext, CurrentColumn)

                                    CurrentColumn = Nothing

                                End If

                            Next

                        End If

                    End If

                    If Success = True Then

                        ReturnObject = New With {.BoardColumnID = BoardColumnID}

                    End If

                End Using

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

        <AcceptVerbs("POST")>
        Public Function AddDesignColumn(ByVal BoardID As Integer, ByVal BoardColumnID As Integer,
                                        ByVal Direction As String, ByVal NewColumnName As String,
                                        ByVal AlertTemplateID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim NewColumnID As Integer = 0

            Try

                If String.IsNullOrWhiteSpace(Direction) = True Then

                    Direction = "right"

                Else

                    Direction = Direction.Trim.ToLower

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim BoardHeader As AdvantageFramework.Database.Entities.BoardHeader = Nothing
                    Dim NewBoardColumn As AdvantageFramework.Database.Entities.BoardColumn = Nothing

                    BoardHeader = AdvantageFramework.Database.Procedures.BoardHeader.LoadByBoardID(DbContext, BoardID)

                    If BoardHeader IsNot Nothing Then

                        NewBoardColumn = AdvantageFramework.Database.Procedures.BoardColumn.LoadByBoardHeaderIDAndColumnName(DbContext, BoardHeader.ID, NewColumnName)

                        If NewBoardColumn Is Nothing Then

                            NewBoardColumn = New AdvantageFramework.Database.Entities.BoardColumn

                            NewBoardColumn.BoardHeaderID = BoardID
                            NewBoardColumn.Name = NewColumnName
                            NewBoardColumn.IsSystem = False
                            NewBoardColumn.SequenceNumber = -1

                            Success = AdvantageFramework.Database.Procedures.BoardColumn.Insert(DbContext, NewBoardColumn)

                        Else

                            Success = True

                        End If

                        If Success = True AndAlso NewBoardColumn IsNot Nothing Then

                            Dim DesignCard As AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.DesignCard

                            DesignCard = AddStateToBoard(BoardHeader.ID, NewBoardColumn.ID, NewBoardColumn.Name, AlertTemplateID, ErrorMessage)

                            If DesignCard Is Nothing Then

                                Success = False

                            End If

                        End If

                    End If

                    If NewBoardColumn Is Nothing Then

                        ReturnObject = New With {.NewColumnID = 0, .NewColumn = Nothing}

                    Else

                        ReturnObject = New With {.NewColumnID = NewBoardColumn.ID, .NewColumn = NewBoardColumn}

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                ReturnObject = New With {.NewColumnID = 0, .NewColumn = Nothing}
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("POST")>
        Public Function AddDesignState(ByVal BoardHeaderID As Integer, ByVal BoardColumnID As Integer,
                                       ByVal StateName As String, ByVal AssignmentTemplateID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim DesignCard As AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.DesignCard

            DesignCard = AddStateToBoard(BoardHeaderID, BoardColumnID, StateName, AssignmentTemplateID, ErrorMessage)

            If DesignCard Is Nothing Then

                Success = False
                DesignCard = New AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.DesignCard

            Else

                Success = True

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, DesignCard))

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateStateName(ByVal StateID As Integer, ByVal StateName As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim State As AdvantageFramework.Database.Entities.AlertState = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    State = AdvantageFramework.Database.Procedures.AlertState.LoadByAlertStateID(DbContext, StateID)

                    If State IsNot Nothing Then

                        State.Name = StateName

                        Success = AdvantageFramework.Database.Procedures.AlertState.Update(DbContext, State)

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                Success = False
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function

        Private Function AddStateToBoard(ByVal BoardHeaderID As Integer, ByVal BoardColumnID As Integer,
                                         ByVal StateName As String, ByVal AssignmentTemplateID As Integer,
                                         ByRef ErrorMessage As String) As AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.DesignCard


            Dim Success As Boolean = False
            Dim DesignCard As New AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.DesignCard

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim BoardHeader As AdvantageFramework.Database.Entities.BoardHeader = Nothing
                    Dim AlertAssignmentTemplate As AdvantageFramework.Database.Entities.AlertAssignmentTemplate = Nothing
                    Dim BoardColumn As AdvantageFramework.Database.Entities.BoardColumn = Nothing
                    Dim AlertState As AdvantageFramework.Database.Entities.AlertState = Nothing
                    Dim BoardDetail As AdvantageFramework.Database.Entities.BoardDetail = Nothing
                    Dim AlertTemplateState As AdvantageFramework.Database.Entities.AlertAssignmentTemplateState = Nothing

                    BoardHeader = AdvantageFramework.Database.Procedures.BoardHeader.LoadByBoardID(DbContext, BoardHeaderID)

                    If BoardHeader IsNot Nothing Then

                        BoardColumn = AdvantageFramework.Database.Procedures.BoardColumn.LoadByBoardHeaderIDAndBoardColumnID(DbContext, BoardHeaderID, BoardColumnID)

                        If BoardColumn IsNot Nothing Then

                            AlertState = AdvantageFramework.Database.Procedures.AlertState.LoadByStateName(DbContext, StateName)

                            If AlertState Is Nothing Then

                                AlertState = New AdvantageFramework.Database.Entities.AlertState

                                AlertState.Name = StateName
                                AlertState.IsActive = True
                                AlertState.DefaultAlertCategoryID = 25

                                If AdvantageFramework.Database.Procedures.AlertState.Insert(DbContext, AlertState) = False Then

                                    AlertState = Nothing

                                End If

                            End If

                            If AlertState IsNot Nothing Then

                                BoardDetail = AdvantageFramework.Database.Procedures.BoardDetail.LoadByBoardHeaderIDandBoardColumnIDandAlertStateID(DbContext, BoardHeaderID, BoardColumnID, AlertState.ID)

                                If BoardDetail Is Nothing Then

                                    BoardDetail = New AdvantageFramework.Database.Entities.BoardDetail

                                    BoardDetail.BoardHeaderID = BoardHeader.ID
                                    BoardDetail.BoardColumnID = BoardColumn.ID
                                    BoardDetail.AlertStateID = AlertState.ID

                                    Success = AdvantageFramework.Database.Procedures.BoardDetail.Insert(DbContext, BoardDetail)

                                End If

                                If AssignmentTemplateID > 0 Then

                                    AlertAssignmentTemplate = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadByAlertAssignmentTemplateID(DbContext, AssignmentTemplateID)

                                End If

                                If AlertAssignmentTemplate IsNot Nothing Then

                                    AlertTemplateState = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext, AssignmentTemplateID, AlertState.ID)

                                    If AlertTemplateState Is Nothing Then

                                        AlertTemplateState = New AdvantageFramework.Database.Entities.AlertAssignmentTemplateState

                                        AlertTemplateState.AlertAssignmentTemplateID = AssignmentTemplateID
                                        AlertTemplateState.AlertStateID = AlertState.ID

                                        Success = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.Insert(DbContext, AlertTemplateState)

                                    End If

                                End If

                            End If

                        End If


                    End If

                    If Success = True Then

                        ErrorMessage = String.Empty

                        DesignCard.ID = BoardDetail.ID
                        DesignCard.BoardHeaderID = BoardHeader.ID
                        DesignCard.StateID = AlertState.ID
                        DesignCard.Title = AlertState.Name
                        DesignCard.Data = AlertState.Name

                    Else

                        DesignCard = Nothing

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                DesignCard = Nothing
            End Try

            Return DesignCard

        End Function

        <AcceptVerbs("POST")>
        Public Function DeleteColumn(ByVal BoardID As Integer, ByVal BoardColumnID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            'Dim SomeReturnProperty As String

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Try

                        Dim ColumnUseCount As Integer = 0

                        ColumnUseCount = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM BOARD_COL BC INNER JOIN BOARD_DTL BD ON BC.BOARD_HDR_ID = BD.BOARD_HDR_ID AND BC.ID = BD.BOARD_COL_ID INNER JOIN ALERT A ON A.BOARD_STATE_ID = BD.ALERT_STATE_ID INNER JOIN SPRINT_DTL SD ON A.ALERT_ID = SD.ALERT_ID WHERE BC.BOARD_HDR_ID = {0} AND BC.ID = {1};", BoardID, BoardColumnID)).SingleOrDefault

                        If ColumnUseCount = 0 Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM BOARD_DTL WHERE BOARD_HDR_ID = {0} AND BOARD_COL_ID = {1}; DELETE FROM BOARD_COL WHERE BOARD_HDR_ID = {0} AND ID = {1};", BoardID, BoardColumnID))
                            Success = True

                        Else

                            ErrorMessage = "Column in use and cannot be deleted"

                        End If

                    Catch ex As Exception
                        Success = False
                        ErrorMessage = ex.Message.ToString
                    End Try

                    'If Success = True Then

                    '    ReturnObject = New With {.SomeJsProperty = SomeReturnProperty}

                    'End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

        <AcceptVerbs("POST")>
        Public Function RenameColumn(ByVal BoardID As Integer, ByVal BoardColumnID As Integer, ByVal NewName As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim BoardColumn As AdvantageFramework.Database.Entities.BoardColumn = Nothing

                    BoardColumn = AdvantageFramework.Database.Procedures.BoardColumn.LoadByID(DbContext, BoardColumnID)

                    If BoardColumn IsNot Nothing Then

                        BoardColumn.Name = NewName

                        Success = AdvantageFramework.Database.Procedures.BoardColumn.Update(DbContext, BoardColumn)

                    End If

                    If Success = True Then

                        ReturnObject = New With {.BoardColumnID = BoardColumnID}

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

#End Region

        <AcceptVerbs("POST")>
        Public Function ResetDefaultProjectBoard(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult

            Dim Reset As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Reset = Me.DeleteDefaultSprintByJobAndComponentNumber(DbContext, JobNumber, JobComponentNumber)

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Reset, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("POST")>
        Public Function DeleteProjectBoard(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal BoardID As Integer) As JsonResult

            Dim Reset As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim BoardCount As Integer = 0
            Dim SingleBoardID As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Reset = Me.DeleteDefaultSprintByJobAndComponentNumber(DbContext, JobNumber, JobComponentNumber)

                    If Reset = True Then

                        Dim Boards As Generic.List(Of AdvantageFramework.Database.Entities.SprintHeader) = Nothing

                        Boards = AdvantageFramework.Database.Procedures.SprintHeader.LoadByJobAndComponentNumber(DbContext, JobNumber, JobComponentNumber).ToList

                        If Boards IsNot Nothing Then

                            BoardCount = Boards.Count

                            If BoardCount = 1 Then

                                For Each Board As AdvantageFramework.Database.Entities.SprintHeader In Boards

                                    SingleBoardID = Board.ID

                                Next

                            End If

                        End If

                    End If

                End Using

                ReturnObject = New With {.BoardCount = BoardCount, .SingleBoardID = SingleBoardID}

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Reset, ErrorMessage, ReturnObject))

        End Function

        <AcceptVerbs("POST")>
        Public Function CreateProjectBoard(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal BoardID As Integer, ByVal IncludeType As Short?,
                                           ByVal StartDate As String, ByVal Weeks As Integer?, ByVal Description As String) As JsonResult

            Dim Created As Boolean = True
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim Allowed As AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.AllowedType = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.AllowedType.TasksAndAssignments
            Dim SprintID As Integer = 0

            Try

                If IncludeType IsNot Nothing AndAlso IncludeType > 0 Then

                    Allowed = CType(IncludeType, AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.AllowedType)

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim SprintHeader As AdvantageFramework.Database.Entities.SprintHeader

                    Try

                        SprintHeader = New AdvantageFramework.Database.Entities.SprintHeader

                        SprintHeader.Description = Description
                        ' DUE TO CHANGE BY EC:  SprintHeader.BoardHeaderID = BoardID
                        SprintHeader.IsActive = True

                        If IsDate(StartDate) = False Then StartDate = Now.Date.ToShortDateString
                        SprintHeader.StartDate = CDate(StartDate)
                        If SprintHeader.StartDate IsNot Nothing Then

                            Dim dfi As DateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo
                            Dim cal As Calendar = dfi.Calendar

                            SprintHeader.StartDate = AdvantageFramework.DateUtilities.FirstDayOfWeek(SprintHeader.StartDate)
                            SprintHeader.StartWeekNumber = cal.GetWeekOfYear(SprintHeader.StartDate, dfi.CalendarWeekRule, DayOfWeek.Sunday)

                        End If

                        If Weeks Is Nothing Then Weeks = 1
                        SprintHeader.NumberOfWeeks = Weeks

                        If AdvantageFramework.Database.Procedures.SprintHeader.Insert(DbContext, SprintHeader) = True Then

                            SprintID = SprintHeader.ID
                            AdvantageFramework.ProjectManagement.Agile.LoadBoardTaskAssignmentCards(DbContext, SprintHeader.ID, Me.SecuritySession.UserCode, AdvantageFramework.ProjectManagement.Agile.Methods.BacklogSort.None)

                        End If

                    Catch ex As Exception
                        SprintID = Nothing
                    End Try

                End Using

            Catch ex As Exception
                Created = False
                ErrorMessage = ex.Message.ToString
            End Try

            If Created = True Then

                ReturnObject = New With {.SprintID = SprintID}

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Created, ErrorMessage, ReturnObject))

        End Function

        <AcceptVerbs("POST")>
        Public Function SaveNewTask(ByVal SprintHeaderID As Integer, ByVal BoardColumnID As Integer?,
                                    ByVal TaskCode As String, ByVal TaskDescription As String,
                                    ByVal EmployeeCode As String, ByVal Priority As Short, ByVal sStartDate As String, ByVal sEndDate As String,
                                    ByVal Week1 As Decimal?, ByVal Week2 As Decimal?) As JsonResult

            Dim Saved As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim SprintDetail As New AdvantageFramework.Database.Entities.SprintDetail

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim SprintHeader As AdvantageFramework.Database.Entities.SprintHeader = Nothing
                    Dim StartDate As Date?
                    Dim EndDate As Date?

                    If String.IsNullOrWhiteSpace(sStartDate) = False AndAlso IsDate(sStartDate) = True Then

                        StartDate = CDate(sStartDate)

                    End If
                    If String.IsNullOrWhiteSpace(sEndDate) = False AndAlso IsDate(sEndDate) = True Then

                        EndDate = CDate(sEndDate)

                    End If

                    SprintHeader = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintHeaderID(DbContext, SprintHeaderID)

                    If SprintHeader IsNot Nothing Then

                        '''If SprintHeader.JobNumber IsNot Nothing AndAlso SprintHeader.JobComponentNumber IsNot Nothing Then

                        '''    Dim Schedule As AdvantageFramework.Database.Entities.JobTraffic = Nothing

                        '''    Schedule = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, SprintHeader.JobNumber, SprintHeader.JobComponentNumber)

                        '''    If Schedule IsNot Nothing Then

                        '''        Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

                        '''        JobComponentTask = AdvantageFramework.ProjectSchedule.QuickAddTask(DbContext,
                        '''                                                                           SprintHeader.JobNumber,
                        '''                                                                           SprintHeader.JobComponentNumber,
                        '''                                                                           TaskCode,
                        '''                                                                           TaskDescription,
                        '''                                                                           Nothing,
                        '''                                                                           Nothing,
                        '''                                                                           Nothing)

                        '''        If JobComponentTask IsNot Nothing Then

                        '''            Dim TotalHours As Decimal = 0

                        '''            If Week1 IsNot Nothing Then TotalHours += Week1
                        '''            If Week2 IsNot Nothing Then TotalHours += Week2

                        '''            Try

                        '''                JobComponentTask.StartDate = CDate(Now.ToShortDateString)
                        '''                'If SprintHeader.DueDate IsNot Nothing Then JobComponentTask.DueDate = SprintHeader.DueDate
                        '''                JobComponentTask.Hours = TotalHours
                        '''                JobComponentTask.HoursAssigned = TotalHours
                        '''                AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask)

                        '''                If JobComponentTask.StartDate IsNot Nothing AndAlso JobComponentTask.DueDate IsNot Nothing Then

                        '''                    Try

                        '''                        Dim s As Date = JobComponentTask.StartDate
                        '''                        Dim d As Date = JobComponentTask.DueDate

                        '''                        JobComponentTask.Days = DateDiff(DateInterval.Day, s, d)

                        '''                    Catch ex As Exception
                        '''                    End Try

                        '''                End If

                        '''            Catch ex As Exception
                        '''            End Try

                        '''            Dim TaskEmployee As New AdvantageFramework.Database.Entities.JobComponentTaskEmployee

                        '''            TaskEmployee.JobNumber = SprintHeader.JobNumber
                        '''            TaskEmployee.JobComponentNumber = SprintHeader.JobComponentNumber
                        '''            TaskEmployee.SequenceNumber = JobComponentTask.SequenceNumber
                        '''            TaskEmployee.EmployeeCode = EmployeeCode
                        '''            TaskEmployee.Hours = TotalHours

                        '''            If AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Insert(DbContext, TaskEmployee) = True Then

                        '''                Dim Employee As AdvantageFramework.Database.Views.Employee

                        '''                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                        '''                If Employee IsNot Nothing Then

                        '''                    Dim EmployeePicture As AdvantageFramework.Database.Entities.EmployeePicture = Nothing

                        '''                    EmployeePicture = AdvantageFramework.Database.Procedures.EmployeePicture.LoadByEmployeeCode(DbContext, EmployeeCode)

                        '''                    SprintDetail.SprintHeaderID = SprintHeader.ID
                        '''                    ' DUE TO CHANGE BY EC:  SprintDetail.TaskSequenceNumber = JobComponentTask.SequenceNumber

                        '''                    'Try

                        '''                    '    SprintDetail.FullName = If(String.IsNullOrWhiteSpace(Employee.FirstName) = False, Employee.FirstName & " ", "") &
                        '''                    '        If(String.IsNullOrWhiteSpace(Employee.MiddleInitial) = False, Employee.MiddleInitial & ". ", "") &
                        '''                    '        If(String.IsNullOrWhiteSpace(Employee.LastName) = False, Employee.LastName, "")

                        '''                    'Catch ex As Exception
                        '''                    'End Try
                        '''                    'Try

                        '''                    '    If EmployeePicture IsNot Nothing And EmployeePicture.Image IsNot Nothing Then SprintDetail.RawPicture = EmployeePicture.Image

                        '''                    'Catch ex As Exception
                        '''                    'End Try

                        '''                    If AdvantageFramework.Database.Procedures.SprintDetail.Insert(DbContext, SprintDetail) = True Then

                        '''                        Saved = True

                        '''                        Dim SprintEmployee As AdvantageFramework.Database.Entities.SprintEmployee = Nothing

                        '''                        If Week1 IsNot Nothing Then

                        '''                            SprintEmployee = New AdvantageFramework.Database.Entities.SprintEmployee

                        '''                            SprintEmployee.SprintDetailID = SprintDetail.ID
                        '''                            SprintEmployee.Hours = Week1
                        '''                            ''SprintEmployee.StartDate = JobComponentTask.StartDate

                        '''                            AdvantageFramework.Database.Procedures.SprintEmployee.Insert(DbContext, SprintEmployee)

                        '''                        End If
                        '''                        If Week2 IsNot Nothing Then

                        '''                            SprintEmployee = Nothing
                        '''                            SprintEmployee = New AdvantageFramework.Database.Entities.SprintEmployee

                        '''                            SprintEmployee.SprintDetailID = SprintDetail.ID
                        '''                            SprintEmployee.Hours = Week2
                        '''                            'SprintEmployee.StartDate = JobComponentTask.StartDate

                        '''                            AdvantageFramework.Database.Procedures.SprintEmployee.Insert(DbContext, SprintEmployee)

                        '''                        End If

                        '''                    End If

                        '''                End If

                        '''            End If

                        '''        End If

                        '''    End If

                        '''End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Saved, ErrorMessage, SprintDetail))

        End Function

#End Region

#Region " Board Methods "

        <AcceptVerbs("POST")>
        Public Function LoadBoardDesignerList() As ActionResult

            Return Json(LoadBoardList(), JsonRequestBehavior.AllowGet)

        End Function
        Private Function LoadBoardList() As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.BoardMaintenanceViewModel)

            Dim BoardsList As New Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.BoardMaintenanceViewModel)

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim List As Generic.List(Of AdvantageFramework.Database.Entities.BoardHeader) = Nothing

                    List = AdvantageFramework.Database.Procedures.BoardHeader.Load(DbContext).ToList

                    If List IsNot Nothing Then

                        Dim Board As AdvantageFramework.ViewModels.ProjectManagement.Agile.BoardMaintenanceViewModel = Nothing

                        Try

                            For Each Item As AdvantageFramework.Database.Entities.BoardHeader In List

                                Board = New AdvantageFramework.ViewModels.ProjectManagement.Agile.BoardMaintenanceViewModel

                                Board.ID = Item.ID
                                Board.Name = Item.Name
                                Board.Description = Item.Description
                                Board.CreatedBy = Item.CreatedBy
                                Board.CreatedDate = Item.CreatedDate
                                Board.LastModified = Item.LastModified
                                Board.IsSystem = Item.IsSystem
                                Board.IsSequential = Item.IsSequential
                                Board.ForceAllColumns = Item.ForceAllColumns
                                Board.SwimLaneID = Item.SwimLaneID
                                Board.AlertTemplateID = Item.AlertTemplateID
                                If Item.IsActive IsNot Nothing AndAlso Item.IsActive = False Then
                                    Board.IsActive = False
                                Else
                                    Board.IsActive = True
                                End If
                                BoardsList.Add(Board)

                                Board = Nothing

                            Next

                        Catch ex As Exception
                            Board = Nothing
                        End Try

                    End If

                End Using

            Catch ex As Exception
                BoardsList = Nothing
            End Try

            If BoardsList Is Nothing Then BoardsList = New List(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.BoardMaintenanceViewModel)

            Return BoardsList

        End Function


        <AcceptVerbs("POST")>
        Public Function SetBoardActive(ByVal BoardHeaderID As Integer, ByVal IsActive As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim SomeReturnProperty As String

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim BoardHeader As AdvantageFramework.Database.Entities.BoardHeader = Nothing

                    BoardHeader = AdvantageFramework.Database.Procedures.BoardHeader.LoadByBoardID(DbContext, BoardHeaderID)

                    If BoardHeader IsNot Nothing Then

                        BoardHeader.IsActive = IsActive

                        Success = AdvantageFramework.Database.Procedures.BoardHeader.Update(DbContext, BoardHeader)

                    End If
                    If Success = True Then

                        'ReturnObject = New With {.SomeJsProperty = SomeReturnProperty}

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

#End Region
#Region " Agile Board Methods "

        <AcceptVerbs("POST")>
        Public Function SaveAddJobToBoardsData(ByVal JobNumber As Integer,
                                               ByVal JobComponentNumber As Short,
                                               ByVal Updates As Generic.List(Of AddJobToBoardUpdate)) As JsonResult

            Dim Success As Boolean = True
            Dim ErrorMessage As String = String.Empty
            Dim HasChanges As Boolean = False
            Dim ErrorMessages As Generic.List(Of String)

            If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        If Updates IsNot Nothing AndAlso Updates.Count > 0 Then

                            Dim BoardJob As AdvantageFramework.Database.Entities.BoardJob = Nothing

                            For Each Item As AddJobToBoardUpdate In Updates

                                BoardJob = AdvantageFramework.Database.Procedures.BoardJob.LoadByBoardAndJobAndComponentNumber(DbContext,
                                                                                                                               Item.BoardID,
                                                                                                                               JobNumber, JobComponentNumber)

                                If Item.IsChecked = True Then

                                    If BoardJob Is Nothing Then

                                        If Me._Controller.AddJobToBoard(DbContext, Item.BoardID, JobNumber, JobComponentNumber, ErrorMessage) = False Then

                                            If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                                ErrorMessages.Add(ErrorMessage)
                                                ErrorMessage = String.Empty

                                            End If

                                        End If

                                    End If

                                Else

                                    If BoardJob IsNot Nothing Then

                                        If Me._Controller.RemoveJobFromBoard(DbContext, Item.BoardID, JobNumber, JobComponentNumber, ErrorMessage) = False Then

                                            If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                                ErrorMessages.Add(ErrorMessage)
                                                ErrorMessage = String.Empty

                                            End If

                                        End If

                                    End If

                                End If

                                BoardJob = Nothing

                            Next

                        End If

                    End Using

                Catch ex As Exception
                    Success = False
                    ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                End Try

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, New With {.HasChanges = HasChanges,
                                                                                                             .ErrorMessages = ErrorMessages}))

        End Function
        Public Function GetBoardsForAJob() As JsonResult

        End Function

        <AcceptVerbs("POST")>
        Public Function RemoveJobFromBoard(ByVal BoardID As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = _Controller.RemoveJobFromBoard(DbContext, BoardID, JobNumber, JobComponentNumber, ErrorMessage)

                    If Success = True Then

                        ''Webvantage.SignalR.Classes.NotificationHub.RefreshDashboardWorkItems(DbContext)

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("POST")>
        Public Function AddJobToBoard(ByVal BoardID As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim BoardJob As AdvantageFramework.Database.Entities.BoardJob = Nothing
            Dim BoardJobObject As AdvantageFramework.ProjectManagement.Agile.Classes.BoardJob = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    If Me._Controller.AddJobToBoard(DbContext, BoardID, JobNumber, JobComponentNumber, ErrorMessage) = True Then

                        Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
                        Dim JobLog As AdvantageFramework.Database.Entities.Job = Nothing

                        JobLog = (From Job In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Job).Include("Client")
                                  Where Job.Number = JobNumber
                                  Select Job).SingleOrDefault
                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext,
                                                                                                                                JobNumber,
                                                                                                                                JobComponentNumber)

                        If JobLog IsNot Nothing AndAlso JobComponent IsNot Nothing Then

                            BoardJobObject = New AdvantageFramework.ProjectManagement.Agile.Classes.BoardJob

                            BoardJobObject.JobNumber = JobNumber
                            BoardJobObject.JobComponentNumber = JobComponentNumber
                            BoardJobObject.Key = JobNumber.ToString & "," & JobComponentNumber.ToString
                            BoardJobObject.Description = JobNumber.ToString.PadLeft(6, "0") &
                                                         "/" & JobComponentNumber.ToString.PadLeft(3, "0") &
                                                         " - " & JobComponent.Description
                            BoardJobObject.Client = JobLog.Client.Name
                            BoardJobObject.ClientCode = JobLog.ClientCode
                            BoardJobObject.DivisionCode = JobLog.DivisionCode
                            BoardJobObject.ProductCode = JobLog.ProductCode
                            BoardJobObject.IsOnBoard = True

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try
            If BoardJobObject IsNot Nothing Then

                Success = True

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, BoardJobObject))

        End Function
        <AcceptVerbs("POST")>
        Public Function AddJobsToBoard(ByVal BoardID As Integer, ByVal Jobs As AdvantageFramework.ProjectManagement.Agile.Classes.BoardJob()) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim BoardJob As AdvantageFramework.Database.Entities.BoardJob = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    For Each Job In Jobs

                        BoardJob = AdvantageFramework.Database.Procedures.BoardJob.LoadByBoardAndJobAndComponentNumber(DbContext, BoardID, Job.JobNumber, Job.JobComponentNumber)

                        If BoardJob Is Nothing Then

                            BoardJob = New AdvantageFramework.Database.Entities.BoardJob

                            BoardJob.BoardID = BoardID
                            BoardJob.JobNumber = Job.JobNumber
                            BoardJob.JobComponentNumber = Job.JobComponentNumber

                            If AdvantageFramework.Database.Procedures.BoardJob.Insert(DbContext, BoardJob) Then

                                If Success = False Then Success = True

                            End If

                        End If

                    Next

                    ''Webvantage.SignalR.Classes.NotificationHub.RefreshDashboardWorkItems(DbContext)

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function

        <AcceptVerbs("POST")>
        Public Function AddAgileBoard(ByVal BoardID As Integer, ByVal BoardName As String, ByVal BoardDescription As String, ByVal OfficeCode As String,
                                      ByVal BoardHeaderID As Integer, ByVal BoardOwnerEmployeeCode As String, ByVal SelectedJobs As String, ByVal IncludeAllJobs As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim IsEdit As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim SelectedJobsList As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardJob)

                    SelectedJobsList = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardJob))(SelectedJobs)

                    Dim Board As AdvantageFramework.Database.Entities.Board = Nothing

                    If BoardID = 0 Then

                        Board = New AdvantageFramework.Database.Entities.Board

                    Else

                        Board = AdvantageFramework.Database.Procedures.Board.LoadByBoardID(DbContext, BoardID)
                        IsEdit = True

                    End If

                    If Board IsNot Nothing Then

                        Board.Name = BoardName
                        Board.Description = BoardDescription
                        Board.OfficeCode = OfficeCode
                        Board.BoardHeaderID = BoardHeaderID
                        Board.BoardOwnerEmployeeCode = BoardOwnerEmployeeCode
                        Board.IncludeAllJobs = IncludeAllJobs

                        If IsEdit = False Then

                            Board.CreatedByUserCode = Me.SecuritySession.UserCode
                            Board.CreatedDate = CType(Now, DateTime)

                            Success = AdvantageFramework.Database.Procedures.Board.Insert(DbContext, Board)

                        Else

                            Success = AdvantageFramework.Database.Procedures.Board.Update(DbContext, Board)

                        End If

                    End If

                    If Success = True Then

                        Dim BoardJob As AdvantageFramework.Database.Entities.BoardJob

                        If SelectedJobsList IsNot Nothing AndAlso SelectedJobsList.Count > 0 Then

                            'If IsEdit = True Then

                            '    AdvantageFramework.Database.Procedures.BoardJob.DeleteAllByBoardID(DbContext, BoardID)

                            'End If
                            For Each SelectedJob As AdvantageFramework.ProjectManagement.Agile.Classes.BoardJob In SelectedJobsList

                                BoardJob = Nothing
                                BoardJob = AdvantageFramework.Database.Procedures.BoardJob.LoadByBoardAndJobAndComponentNumber(DbContext, Board.ID, SelectedJob.JobNumber, SelectedJob.JobComponentNumber) 'only allow if job not on another board

                                If BoardJob Is Nothing Then

                                    BoardJob = New AdvantageFramework.Database.Entities.BoardJob

                                    BoardJob.BoardID = Board.ID
                                    BoardJob.JobNumber = SelectedJob.JobNumber
                                    BoardJob.JobComponentNumber = SelectedJob.JobComponentNumber

                                    AdvantageFramework.Database.Procedures.BoardJob.Insert(DbContext, BoardJob)

                                End If

                            Next

                        Else

                            'If IsEdit = True Then

                            '    AdvantageFramework.Database.Procedures.BoardJob.DeleteAllByBoardID(DbContext, BoardID)

                            'End If

                        End If

                    End If

                    If Success = True Then

                        ''Webvantage.SignalR.Classes.NotificationHub.RefreshDashboardWorkItems(DbContext)

                        ReturnObject = New With {.BoardID = Board.ID,
                                                 .BoardURL = Me.BoardURL(Board.ID)}

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("POST")>
        Public Function DeleteAgileBoard(ByVal BoardID As Integer) As ActionResult

            Dim Success As Boolean = True
            Dim ErrorMessage As String = String.Empty
            Dim qs As New AdvantageFramework.Web.QueryString
            Dim Boards As Generic.List(Of Webvantage.Controllers.ProjectManagement.AgileController.BoardDisplay)
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0

            Try

                qs = qs.FromCurrent

                JobNumber = qs.JobNumber
                JobComponentNumber = qs.JobComponentNumber

            Catch ex As Exception
            End Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    Dim Board As AdvantageFramework.Database.Entities.Board = Nothing

                    Board = AdvantageFramework.Database.Procedures.Board.LoadByBoardID(DbContext, BoardID)

                    If Board IsNot Nothing Then

                        Dim Sprints As Generic.List(Of AdvantageFramework.Database.Entities.SprintHeader) = Nothing

                        Sprints = AdvantageFramework.Database.Procedures.SprintHeader.LoadByBoardID(DbContext, BoardID).ToList

                        If Sprints IsNot Nothing Then

                            For Each Sprint As AdvantageFramework.Database.Entities.SprintHeader In Sprints

                                Try

                                    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_agile_delete_sprint] {0};", Sprint.ID))

                                Catch ex As Exception
                                    Success = False
                                End Try

                            Next

                        End If

                        If Success = True Then

                            Success = AdvantageFramework.Database.Procedures.Board.Delete(DbContext, Board)

                        End If
                        If Success = True Then

                            ''Webvantage.SignalR.Classes.NotificationHub.RefreshDashboardWorkItems(DbContext)
                            Me.ClearBackLogSequenceNumber(DbContext, BoardID)

                        End If

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message.ToString
                End Try

                Try

                    Boards = DbContext.Database.SqlQuery(Of Webvantage.Controllers.ProjectManagement.AgileController.BoardDisplay)(String.Format("EXEC [dbo].[advsp_agile_load_agile_boards] {0}, {1}, 0, '{2}';",
                                                                                                                                                 JobNumber, JobComponentNumber, Me.SecuritySession.UserCode)).ToList

                Catch ex As Exception
                    Boards = Nothing
                End Try

            End Using

            If Boards Is Nothing Then Boards = New List(Of BoardDisplay)

            ViewData("NewAgileBoardURL") = Me.NewAgileBoardURL

            Return Json(Boards, JsonRequestBehavior.AllowGet)

        End Function

        Private Function ClearBackLogSequenceNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BoardID As Integer) As Boolean

            Dim Cleared As Boolean = False

            Try

                Dim SQL As String = String.Format("UPDATE ALERT SET BACKLOG_SEQ_NBR = NULL, BOARD_STATE_ID = NULL FROM ALERT A INNER JOIN BOARD_JOB BJ ON A.JOB_NUMBER = BJ.JOB_NUMBER AND A.JOB_COMPONENT_NBR = BJ.JOB_COMPONENT_NBR WHERE BJ.BOARD_ID = {0} AND A.IS_WORK_ITEM = 1 AND NOT A.BACKLOG_SEQ_NBR IS NULL;", BoardID)

                DbContext.Database.ExecuteSqlCommand(SQL)

            Catch ex As Exception
                Cleared = False
            Finally
                ClearBackLogSequenceNumber = Cleared
            End Try


        End Function
        Private Function LoadBoardView(ByVal BoardID As Integer, ByVal IncludeCompleted As Boolean) As BoardView

            Dim BoardView As New BoardView
            Dim SprintHeaders As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.SprintHeaderViewModel)
            Dim Board As AdvantageFramework.Database.Entities.Board = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Try

                        Board = AdvantageFramework.Database.Procedures.Board.LoadByBoardID(DbContext, BoardID)

                    Catch ex As Exception
                        Board = Nothing
                    End Try

                    If Board Is Nothing Then Board = New AdvantageFramework.Database.Entities.Board

                    BoardView.Header = Board

                    Try

                        BoardView.Orphans = DbContext.Database.SqlQuery(Of SimpleOrphan)(String.Format("SELECT SD.ID AS SprintDetailID, A.ALERT_ID AS AlertID, A.[SUBJECT] AS Description FROM SPRINT_DTL SD INNER JOIN ALERT A ON SD.ALERT_ID = A.ALERT_ID WHERE SD.BACKLOG_BOARD_ID = {0} AND (A.ASSIGN_COMPLETED IS NULL OR A.ASSIGN_COMPLETED = 0);", BoardID)).ToList

                    Catch ex As Exception
                    End Try

                    Try

                        SprintHeaders = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.SprintHeaderViewModel)(String.Format("EXEC [dbo].[advsp_agile_load_sprints] {0}", BoardID)).ToList

                    Catch ex As Exception
                        SprintHeaders = Nothing
                    End Try

                End Using

                If SprintHeaders IsNot Nothing Then

                    If BoardView.Sprints Is Nothing Then BoardView.Sprints = New List(Of SimpleSprintHeader)

                    Dim ss As SimpleSprintHeader = Nothing
                    Dim CannotAccessNonActiveSprint As Boolean = NoAccessToNonActiveSprint()
                    Dim CanView As Boolean = False

                    For Each SprintHeader As AdvantageFramework.ViewModels.ProjectManagement.Agile.SprintHeaderViewModel In SprintHeaders

                        Try

                            If CannotAccessNonActiveSprint = True AndAlso SprintHeader.IsActive IsNot Nothing AndAlso SprintHeader.IsActive = False Then

                                CanView = False

                            Else

                                CanView = True

                            End If

                        Catch ex As Exception
                            CanView = True
                        End Try

                        If CanView = True Then

                            If IncludeCompleted = True OrElse (IncludeCompleted = False AndAlso (SprintHeader.IsComplete Is Nothing OrElse SprintHeader.IsComplete = False)) Then

                                ss = New SimpleSprintHeader

                                ss.ID = SprintHeader.ID
                                ss.Description = SprintHeader.Description
                                ss.Comments = SprintHeader.Comments
                                ss.BoardID = SprintHeader.BoardID
                                ss.SequenceNumber = SprintHeader.SequenceNumber
                                ss.StartDate = SprintHeader.StartDate
                                ss.StartWeekNumber = SprintHeader.StartWeekNumber
                                ss.NumberOfWeeks = SprintHeader.NumberOfWeeks
                                ss.IsActive = SprintHeader.IsActive
                                ss.IsComplete = SprintHeader.IsComplete
                                ss.CreatedByUserCode = SprintHeader.CreatedByUserCode
                                ss.CreatedDate = SprintHeader.CreatedDate
                                If SprintHeader.StartDate IsNot Nothing Then ss.StartDateAsString = CType(SprintHeader.StartDate, Date).ToShortDateString
                                ss.ItemCount = SprintHeader.ItemCount

                                BoardView.Sprints.Add(ss)

                                ss = Nothing

                            End If

                        End If

                    Next

                End If

            Catch ex As Exception
                BoardView.Sprints = Nothing
            End Try

            If BoardView Is Nothing Then BoardView = New BoardView
            If BoardView.Sprints Is Nothing Then BoardView.Sprints = New List(Of SimpleSprintHeader)
            If BoardView.Orphans Is Nothing Then BoardView.Orphans = New List(Of SimpleOrphan)

            Return BoardView

        End Function

        <HttpPost>
        Public Function InitSelectBoardJobs(DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest, ByVal BoardID As Integer, ByVal ExcludeJobsOnBoard As Boolean?, ByVal FilterString As String) As JsonResult

            Dim ErrorMessage As String = String.Empty
            Dim BoardJobs As IEnumerable(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardJob) = Nothing 'Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardJob) = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    BoardJobs = AdvantageFramework.ProjectManagement.Agile.LoadJobsForBoard(DbContext, BoardID, Me.SecuritySession.UserCode)

                End Using

                If ExcludeJobsOnBoard.GetValueOrDefault(False) = True Then

                    BoardJobs = (From Item In BoardJobs
                                 Where Item.IsOnBoard = False
                                 Select Item).ToList

                End If

                If Not String.IsNullOrWhiteSpace(FilterString) Then

                    BoardJobs = (From Item In BoardJobs
                                 Where If(String.IsNullOrEmpty(Item.Description), "", Item.Description).ToUpper().Contains(FilterString.Trim.ToUpper()) OrElse
                                       If(String.IsNullOrEmpty(Item.Client), "", Item.Client).ToUpper().Contains(FilterString.Trim.ToUpper()) OrElse
                                       If(String.IsNullOrEmpty(Item.DivisionCode), "", Item.DivisionCode).ToUpper().Contains(FilterString.Trim.ToUpper()) OrElse
                                       If(String.IsNullOrEmpty(Item.ProductCode), "", Item.ProductCode).ToUpper().Contains(FilterString.Trim.ToUpper()) OrElse
                                       If(String.IsNullOrEmpty(Item.SalesClassDescription), "", Item.SalesClassDescription).ToUpper().Contains(FilterString.Trim.ToUpper()) OrElse
                                       If(String.IsNullOrEmpty(Item.JobTypeDescription), "", Item.JobTypeDescription).ToUpper().Contains(FilterString.Trim.ToUpper()) OrElse
                                       If(String.IsNullOrEmpty(Item.AccountExecutiveName), "", Item.AccountExecutiveName).ToUpper().Contains(FilterString.Trim.ToUpper()) OrElse
                                       If(String.IsNullOrEmpty(Item.ManagerName), "", Item.ManagerName).ToUpper().Contains(FilterString.Trim.ToUpper())
                                 Select Item).ToList

                End If

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return MaxJson(BoardJobs.ToDataSourceResult(DataSourceRequest), JsonRequestBehavior.AllowGet)

        End Function

#End Region

#Region " Sprint Methods "


        <AcceptVerbs("POST")>
        Public Function CheckSprintForRemovedOrClosedJobs(ByVal SprintID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = _Controller.CheckSprintForRemovedOrClosedJobs(DbContext, SprintID, ErrorMessage)

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                Success = False
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

        <AcceptVerbs("POST")>
        Public Function ReorderSprintByDueDate(ByVal SprintID As Integer, ByVal ReorderBacklog As Boolean, ByVal ReorderBoard As Boolean) As JsonResult

            Dim Success As Boolean = True
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            If ReorderBacklog = True OrElse ReorderBoard = True Then

                Try

                    Dim ProjectBoardObj As AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard

                    ProjectBoardObj = New AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard(Me.SecuritySession)

                    ProjectBoardObj.SprintHeaderID = SprintID
                    ProjectBoardObj.Allowed = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.AllowedType.TasksAndAssignments
                    ProjectBoardObj.TimesheetActive = HasAccessToTimesheet(Me.SecuritySession)

                    ProjectBoardObj.LoadDataBy = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.LoadBy.SprintID

                    ProjectBoardObj.Load()

                    If ProjectBoardObj.Data IsNot Nothing AndAlso ProjectBoardObj.Data.Count > 0 Then

                        Dim AlertIDs As List(Of Integer?)

                        If ReorderBacklog = True AndAlso ReorderBoard = True Then

                            AlertIDs = (From Entity In ProjectBoardObj.Data
                                        Where Entity.AlertID IsNot Nothing
                                        Select Entity.AlertID).ToList

                        ElseIf ReorderBacklog = True AndAlso ReorderBoard = False Then

                            AlertIDs = (From Entity In ProjectBoardObj.Data
                                        Where Entity.AlertID IsNot Nothing And Entity.BoardColumnID = -1
                                        Select Entity.AlertID).ToList

                        ElseIf ReorderBacklog = False AndAlso ReorderBoard = True Then

                            AlertIDs = (From Entity In ProjectBoardObj.Data
                                        Where Entity.AlertID IsNot Nothing And Entity.BoardColumnID <> -1
                                        Select Entity.AlertID).ToList

                        End If

                        If AlertIDs IsNot Nothing AndAlso AlertIDs.Count > 0 Then

                            Dim Values As String = String.Join(",", AlertIDs.ToArray)

                            If String.IsNullOrWhiteSpace(Values) = False Then

                                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                                    Dim SQL = String.Format("UPDATE ALERT SET BACKLOG_SEQ_NBR = NULL WHERE ALERT_ID IN ({0});UPDATE SPRINT_DTL SET SEQ_NBR = NULL WHERE ALERT_ID IN ({0}) AND SPRINT_HDR_ID = {1};", Values, SprintID)

                                    DbContext.Database.ExecuteSqlCommand(SQL)

                                End Using

                            End If

                        End If

                    End If

                    ErrorMessage = String.Empty
                    Success = True

                Catch ex As Exception
                    ErrorMessage = ex.Message.ToString
                    Success = False
                End Try

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))


            ''Dim Success As Boolean = False
            ''Dim ErrorMessage As String = String.Empty
            ''Dim ReturnObject As Object = Nothing
            '''Dim SomeReturnProperty As String

            ''Try

            ''    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

            ''        Try

            ''            DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_agile_sprint_reorder_by_due_date] {0}, '{1}', {2}, {3};",
            ''                                                               SprintID,
            ''                                                               Me.SecuritySession.UserCode,
            ''                                                               If(ReorderBacklog = True, 1, 0),
            ''                                                               If(ReorderBoard = True, 1, 0)))

            ''            Success = True

            ''        Catch ex As Exception
            ''            Success = False
            ''            ErrorMessage = ex.Message.ToString
            ''        End Try
            ''        If Success = True Then

            ''            'ReturnObject = New With {.SomeJsProperty = SomeReturnProperty}
            ''            ''Webvantage.SignalR.Classes.NotificationHub.RefreshSprint(DbContext, SprintID, True)

            ''        End If

            ''    End Using

            ''Catch ex As Exception
            ''    ErrorMessage = ex.Message.ToString
            ''End Try

            ''Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

        <AcceptVerbs("POST")>
        Public Function ReopenSprint(ByVal SprintID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim SomeReturnProperty As String

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim SprintHeader As AdvantageFramework.Database.Entities.SprintHeader = Nothing

                    SprintHeader = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintHeaderID(DbContext, SprintID)

                    If SprintHeader IsNot Nothing Then

                        SprintHeader.IsComplete = False
                        SprintHeader.CompletedDate = Nothing

                        Success = AdvantageFramework.Database.Procedures.SprintHeader.Update(DbContext, SprintHeader)

                    End If

                    If Success = True Then

                        ReturnObject = New With {.SprintHeaderID = SprintHeader.ID}
                        ''Webvantage.SignalR.Classes.NotificationHub.RefreshSprint(DbContext, SprintID, True)

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

        <AcceptVerbs("POST")>
        Public Function CompleteSprint(ByVal SprintID As Integer, ByVal ActivateNext As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim NextSprintID As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim SprintHeader As AdvantageFramework.Database.Entities.SprintHeader = Nothing

                    SprintHeader = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintHeaderID(DbContext, SprintID)

                    If SprintHeader IsNot Nothing Then

                        DbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC [dbo].[advsp_agile_complete_sprint] {0}, {1}", SprintID, If(ActivateNext = True, 1, 0))).SingleOrDefault
                        Success = True

                    End If

                    If Success = True Then

                        ''Webvantage.SignalR.Classes.NotificationHub.RefreshSprint(DbContext, SprintID, True)
                        ReturnObject = New With {.NextSprintID = NextSprintID}

                    End If

                End Using

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("POST")>
        Public Function StopSprint(ByVal SprintID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim SprintHeader As AdvantageFramework.Database.Entities.SprintHeader = Nothing

                    SprintHeader = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintHeaderID(DbContext, SprintID)

                    If SprintHeader IsNot Nothing Then

                        SprintHeader.IsActive = False

                        Success = AdvantageFramework.Database.Procedures.SprintHeader.Update(DbContext, SprintHeader)

                    End If

                    If Success = True Then

                        ReturnObject = New With {.SprintID = SprintID}
                        ''Webvantage.SignalR.Classes.NotificationHub.RefreshSprint(DbContext, SprintID, True)

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("POST")>
        Public Function StartSprint(ByVal SprintID As Integer, ByVal IncludeSprintList As Boolean, ByVal IncludeCompleted As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim BoardView As New BoardView
            Dim BoardID As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim SprintHeader As AdvantageFramework.Database.Entities.SprintHeader = Nothing

                    SprintHeader = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintHeaderID(DbContext, SprintID)

                    If SprintHeader IsNot Nothing Then

                        If SprintHeader.IsActive IsNot Nothing AndAlso SprintHeader.IsActive = True Then

                            ErrorMessage = "Sprint already started"

                        Else

                            BoardID = SprintHeader.BoardID

                            Dim ActiveSprints As Generic.List(Of AdvantageFramework.Database.Entities.SprintHeader) = Nothing

                            ActiveSprints = AdvantageFramework.Database.Procedures.SprintHeader.LoadActiveByBoardID(DbContext, SprintHeader.BoardID).ToList

                            If ActiveSprints IsNot Nothing Then

                                For Each Sprint As AdvantageFramework.Database.Entities.SprintHeader In ActiveSprints

                                    If Sprint.ID <> SprintHeader.ID Then

                                        StopSprint(Sprint.ID)

                                    End If

                                Next

                            End If

                            SprintHeader.IsActive = True
                            Success = AdvantageFramework.Database.Procedures.SprintHeader.Update(DbContext, SprintHeader)

                        End If

                    End If

                    If Success = True Then

                        BoardView = LoadBoardView(BoardID, IncludeCompleted)
                        ''Webvantage.SignalR.Classes.NotificationHub.RefreshSprint(DbContext, SprintID, True)

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, BoardView.Sprints))

        End Function

        'Public Function LoadSprintData(ByVal value As Syncfusion.JavaScript.DataManager) As JsonResult

        '    Dim ErrorMessage As String = String.Empty
        '    Dim Results As New DataResult
        '    Dim SprintID As Integer = 0

        '    If Request.QueryString("SprintID") IsNot Nothing Then

        '        SprintID = Request.QueryString("SprintID")

        '    End If

        '    Try

        '        Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

        '            Dim Cards As List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard) = Nothing

        '            Cards = AdvantageFramework.ProjectManagement.Agile.LoadBoardTaskAssignmentCards(DbContext, SprintID, Me.SecuritySession.UserCode)

        '            Results.result = Cards
        '            Results.count = Cards.Count

        '        End Using

        '    Catch ex As Exception
        '        ErrorMessage = ex.Message.ToString
        '    End Try

        '    Return Json(Results, JsonRequestBehavior.AllowGet)

        'End Function
        Public Function CrudSprintData(ByVal changed As List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard),
                                       ByVal added As List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard),
                                       ByVal deleted As List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard)) As ActionResult

            Try

                Dim ErrorMessage As String = String.Empty
                Dim Results As New DataResult
                Dim SprintID As Integer = 0
                Dim ReOrderSQL As New System.Text.StringBuilder
                Dim HasReOrder As Boolean = False

                If Request.QueryString("SprintID") IsNot Nothing Then

                    SprintID = Request.QueryString("SprintID")

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    If changed IsNot Nothing AndAlso changed.Count > 0 Then

                        Dim SprintDetail As AdvantageFramework.Database.Entities.SprintDetail = Nothing
                        Dim CurrentAlertBoardStateID As Integer = 0
                        Dim CurrentBoardStateID As Integer = 0
                        Dim TargetBoardStateID As Integer = 0
                        Dim SprintDetailCreated As Boolean = False
                        Dim SkipReorder As Boolean = False
                        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                        For Each TaskCard As AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard In changed

                            If SprintID = 0 AndAlso TaskCard.SprintHeaderID IsNot Nothing Then

                                SprintID = TaskCard.SprintHeaderID

                            End If

                            SprintDetail = Nothing
                            CurrentAlertBoardStateID = 0
                            CurrentBoardStateID = 0
                            SprintDetailCreated = False

                            If TaskCard.BoardColumnID IsNot Nothing Then

                                CurrentBoardStateID = TaskCard.CurrentBoardStateID

                            End If
                            If TaskCard.BoardStateID IsNot Nothing Then

                                TargetBoardStateID = TaskCard.BoardStateID

                            End If

                            If (TaskCard.SprintDetailID Is Nothing OrElse TaskCard.SprintDetailID <= 0) AndAlso TaskCard.BoardStateID > 0 Then

                                SprintDetail = AdvantageFramework.Database.Procedures.SprintDetail.LoadBySprintIDAlertID(DbContext, SprintID, TaskCard.AlertID)

                                If SprintDetail Is Nothing Then

                                    SprintDetail = New AdvantageFramework.Database.Entities.SprintDetail

                                    SprintDetail.SprintHeaderID = SprintID
                                    SprintDetail.AlertID = TaskCard.AlertID

                                    If AdvantageFramework.Database.Procedures.SprintDetail.Insert(DbContext, SprintDetail) = True Then

                                        SprintDetailCreated = True
                                        TaskCard.SprintDetailID = SprintDetail.ID

                                    End If

                                Else

                                    TaskCard.SprintDetailID = SprintDetail.ID

                                End If

                            End If

                            'Move item
                            If CurrentBoardStateID <> TargetBoardStateID Then

                                Try

                                    If SprintDetail Is Nothing Then

                                        SprintDetail = AdvantageFramework.Database.Procedures.SprintDetail.LoadBySprintDetailID(DbContext, TaskCard.SprintDetailID)

                                    End If
                                    If SprintDetail.AlertID IsNot Nothing AndAlso SprintDetail.AlertID > 0 Then

                                        Try

                                            CurrentAlertBoardStateID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT CAST(ISNULL(BOARD_STATE_ID, 0) AS INT) FROM ALERT WITH(NOLOCK) WHERE ALERT_ID = {0};",
                                                                                                                                 SprintDetail.AlertID)).SingleOrDefault

                                        Catch ex As Exception
                                            CurrentAlertBoardStateID = 0
                                        End Try

                                    End If

                                    'move item
                                    If (CurrentAlertBoardStateID <> TargetBoardStateID) OrElse (CurrentBoardStateID = -2) Then

                                        If AdvantageFramework.ProjectManagement.Agile.MoveBoardItem(Me.SecuritySession, TargetBoardStateID, SprintDetail, CurrentBoardStateID) = True Then

                                            If SprintDetail IsNot Nothing AndAlso SprintDetail.AlertID IsNot Nothing Then

                                                SignalR.Classes.NotificationHub.NotifyRecipientsAll(DbContext, SprintDetail.AlertID)
                                                'SignalR.Classes.NotificationHub.RefreshSprint(DbContext, SprintDetail.SprintHeaderID, True)

                                            End If

                                        End If

                                    End If

                                Catch ex As Exception
                                End Try

                            End If

                            'Reorder item exclusions
                            If TargetBoardStateID = -1 AndAlso Me.GetSprintBacklogIsSorted(SprintID) = True Then

                                SkipReorder = True

                            End If
                            If TargetBoardStateID = -2 Then

                                SkipReorder = True

                            End If

                            'Reorder item
                            If SkipReorder = False Then

                                If TaskCard.SprintDetailID IsNot Nothing AndAlso TaskCard.SprintDetailID > 0 AndAlso TargetBoardStateID > 0 Then

                                    ReOrderSQL.Append(String.Format("UPDATE SPRINT_DTL SET SEQ_NBR = {0} WHERE ID = {1};", If(TaskCard.SequenceNumber AndAlso TaskCard.SequenceNumber > 0, TaskCard.SequenceNumber.ToString, "NULL"), TaskCard.SprintDetailID))
                                    HasReOrder = True

                                End If
                                If TargetBoardStateID = -1 Then

                                    ReOrderSQL.Append(String.Format("UPDATE ALERT SET BACKLOG_SEQ_NBR = {0} WHERE ALERT_ID = {1};", If(TaskCard.SequenceNumber AndAlso TaskCard.SequenceNumber > 0, TaskCard.SequenceNumber.ToString, "NULL"), TaskCard.AlertID))
                                    HasReOrder = True

                                End If

                            End If

                        Next

                        If HasReOrder = True Then

                            Try

                                DbContext.Database.ExecuteSqlCommand(ReOrderSQL.ToString)

                            Catch ex As Exception
                            End Try

                        End If

                    End If

                    SignalR.Classes.NotificationHub.RefreshSprint(DbContext, SprintID, False)

                    Dim Cards As List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard) = Nothing

                    'Cards = AdvantageFramework.ProjectManagement.Agile.LoadBoardTaskAssignmentCards(DbContext, SprintID, Me.SecuritySession.UserCode, AdvantageFramework.ProjectManagement.Agile.Methods.BacklogSort.None)
                    Cards = New List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard)
                    Return MaxJson(Cards, JsonRequestBehavior.AllowGet)

                End Using

            Catch ex As Exception
            End Try

        End Function

        Public Function CrudDesignBoardData(ByVal changed As List(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.DesignCard),
                                            ByVal added As List(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.DesignCard),
                                            ByVal deleted As List(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.DesignCard)) As ActionResult

            Dim DesignBoard As New AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner(Me.SecuritySession)
            Dim BoardHeaderID As Integer = 0
            Dim ErrorMessage As String = String.Empty

            Try

                Dim Results As New DataResult
                Dim BoardDetail As AdvantageFramework.Database.Entities.BoardDetail
                Dim Modified As Boolean = False

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    If changed IsNot Nothing AndAlso changed.Count > 0 Then

                        For Each DesignCard As AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.DesignCard In changed

                            If BoardHeaderID = 0 Then BoardHeaderID = DesignCard.BoardHeaderID

                            BoardDetail = Nothing

                            BoardDetail = AdvantageFramework.Database.Procedures.BoardDetail.LoadByBoardHeaderIDandBoardColumnIDandAlertStateID(DbContext, DesignCard.BoardHeaderID, DesignCard.BoardColumnID, DesignCard.StateID)

                            If BoardDetail IsNot Nothing Then

                                BoardDetail.SequenceNumber = DesignCard.SequenceNumber

                                If AdvantageFramework.Database.Procedures.BoardDetail.Update(DbContext, BoardDetail) = True Then

                                    If Modified = False Then Modified = True

                                End If
                                If BoardDetail.BoardColumnID <> DesignCard.BoardColumnID Then

                                    If DesignMoveStateCardCrud(BoardDetail.BoardHeaderID, BoardDetail.BoardColumnID, DesignCard.BoardColumnID, BoardDetail.AlertStateID, ErrorMessage) = True Then

                                        If Modified = False Then Modified = True

                                    End If

                                End If

                            End If

                        Next

                    End If

                End Using

            Catch ex As Exception
            End Try

            Dim qs As New AdvantageFramework.Web.QueryString
            Dim DesignCards As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.DesignCard) = Nothing

            qs = qs.FromCurrent
            DesignCards = LoadDesignCards(qs.BoardHeaderID, qs.AlertTemplateID, ErrorMessage)

            Return Json(DesignCards, JsonRequestBehavior.AllowGet)

        End Function

        Private Function DesignMoveStateCardCrud(ByVal BoardHeaderID As Integer, ByVal BoardColumnID As Integer,
                                             ByVal TargetBoardColumnID As Integer, ByVal StateID As Integer,
                                             ByRef ErrorMessage As String) As Boolean

            Dim Moved As Boolean = False
            Dim HasIdentifier As Boolean = False
            ErrorMessage = String.Empty

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim BoardDetail As AdvantageFramework.Database.Entities.BoardDetail = Nothing

                    BoardDetail = AdvantageFramework.Database.Procedures.BoardDetail.LoadByBoardHeaderIDandStateID(DbContext, BoardHeaderID, StateID)

                    If BoardDetail Is Nothing Then

                        If TargetBoardColumnID <> -3 Then

                            BoardDetail = New AdvantageFramework.Database.Entities.BoardDetail

                            BoardDetail.BoardHeaderID = BoardHeaderID
                            BoardDetail.BoardColumnID = TargetBoardColumnID
                            BoardDetail.AlertStateID = StateID

                            Moved = AdvantageFramework.Database.Procedures.BoardDetail.Insert(DbContext, BoardDetail)

                        End If
                    Else

                        If TargetBoardColumnID = -3 Then

                            Moved = AdvantageFramework.Database.Procedures.BoardDetail.Delete(DbContext, BoardDetail)

                        Else

                            BoardDetail.BoardColumnID = TargetBoardColumnID

                            Moved = AdvantageFramework.Database.Procedures.BoardDetail.Update(DbContext, BoardDetail)

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Moved
            'Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Moved, ErrorMessage, Nothing))

        End Function

        <AcceptVerbs("POST")>
        Public Function AddSprint(ByVal SprintName As String, ByVal SprintDescription As String,
                                  ByVal BoardID As Integer,
                                  ByVal StartDate As Date?, ByVal NumberOfWeeks As Integer?,
                                  ByVal TrackChanges As Boolean?, ByVal EmailOnChange As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim SprintID As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim Sprint As New AdvantageFramework.Database.Entities.SprintHeader

                    Sprint.Description = SprintName
                    Sprint.Comments = SprintDescription
                    Sprint.BoardID = BoardID
                    Sprint.SequenceNumber = 0
                    Sprint.TrackChanges = TrackChanges
                    Sprint.EmailOnChange = EmailOnChange
                    Try

                        Sprint.NumberOfWeeks = NumberOfWeeks

                    Catch ex As Exception
                        Sprint.NumberOfWeeks = 1
                    End Try

                    Try

                        If StartDate Is Nothing Then

                            StartDate = Now.Date

                        End If

                        Sprint.StartDate = CDate(StartDate)

                        If Sprint.StartDate IsNot Nothing Then

                            Dim dfi As DateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo
                            Dim cal As Calendar = dfi.Calendar

                            Sprint.StartDate = AdvantageFramework.DateUtilities.FirstDayOfWeek(Sprint.StartDate)
                            Sprint.StartWeekNumber = cal.GetWeekOfYear(Sprint.StartDate, dfi.CalendarWeekRule, DayOfWeek.Sunday)

                        End If

                    Catch ex As Exception
                    End Try

                    Sprint.IsActive = False
                    Sprint.CreatedByUserCode = Me.SecuritySession.UserCode
                    Sprint.CreatedDate = CType(Now, DateTime)

                    Success = AdvantageFramework.Database.Procedures.SprintHeader.Insert(DbContext, Sprint)

                    If Success = True Then

                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_agile_move_orphans_to_sprint] {0}, {1};", Sprint.ID, Sprint.BoardID))

                        Catch ex As Exception
                        End Try

                        ReturnObject = New With {.SprintID = Sprint.ID,
                                                 .SprintURL = Me.SprintURL(Sprint.ID)}

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("POST")>
        Public Function EditSprint(ByVal SprintID As Integer, ByVal SprintName As String, ByVal SprintDescription As String,
                                   ByVal StartDate As Date?, ByVal NumberOfWeeks As Integer?, ByVal BoardID As Integer?,
                                   ByVal TrackChanges As Boolean?, ByVal EmailOnChange As Boolean?) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim Sprint As AdvantageFramework.Database.Entities.SprintHeader = Nothing

                    Sprint = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintHeaderID(DbContext, SprintID)

                    If Sprint.TrackChanges Is Nothing Then Sprint.TrackChanges = False
                    If Sprint.EmailOnChange Is Nothing Then Sprint.EmailOnChange = False

                    Sprint.Description = SprintName
                    Sprint.Comments = SprintDescription
                    Sprint.TrackChanges = TrackChanges
                    Sprint.EmailOnChange = EmailOnChange
                    'Sprint.BoardID = BoardID
                    'Sprint.SequenceNumber = 0

                    If NumberOfWeeks Is Nothing Then NumberOfWeeks = 1
                    Try

                        Sprint.NumberOfWeeks = NumberOfWeeks

                    Catch ex As Exception
                        Sprint.NumberOfWeeks = 1
                    End Try

                    Try

                        If StartDate Is Nothing Then StartDate = Now.Date

                        Sprint.StartDate = CDate(StartDate)

                        If Sprint.StartDate IsNot Nothing Then

                            Dim dfi As DateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo
                            Dim cal As Calendar = dfi.Calendar

                            Sprint.StartDate = AdvantageFramework.DateUtilities.FirstDayOfWeek(Sprint.StartDate)
                            Sprint.StartWeekNumber = cal.GetWeekOfYear(Sprint.StartDate, dfi.CalendarWeekRule, DayOfWeek.Sunday)

                        End If

                    Catch ex As Exception
                    End Try

                    Success = AdvantageFramework.Database.Procedures.SprintHeader.Update(DbContext, Sprint)

                    If Success = True Then

                        ReturnObject = New With {.SprintID = Sprint.ID,
                                                 .SprintURL = Me.SprintURL(Sprint.ID)}

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

        <HttpPost()>
        Public Function SaveNewSprintHeader(ByVal Model As AdvantageFramework.Database.Entities.SprintHeader) As ActionResult

            Dim Saved As Boolean = False
            Dim Message As String = ""
            Dim ProjectBoard As AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard

            Try

                ''''If Model IsNot Nothing AndAlso Model.JobNumber IsNot Nothing AndAlso Model.JobComponentNumber IsNot Nothing Then

                ''''    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                ''''        Dim SprintHeader As New AdvantageFramework.Database.Entities.SprintHeader

                ''''        'SprintHeader.BoardID = 1
                ''''        'SprintHeader.Story = Model.Story
                ''''        'SprintHeader.StartDate = Model.StartDate
                ''''        'SprintHeader.DueDate = Model.DueDate
                ''''        'SprintHeader.JobNumber = Model.JobNumber
                ''''        'SprintHeader.JobComponentNumber = Model.JobComponentNumber
                ''''        'SprintHeader.IsSystem = False

                ''''        Saved = AdvantageFramework.Database.Procedures.SprintHeader.Insert(DbContext, SprintHeader)

                ''''        If Saved = True AndAlso SprintHeader.ID > 0 Then

                ''''            ProjectBoard = New AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard(Me.SecuritySession)

                ''''            ProjectBoard.SprintHeaderID = SprintHeader.ID
                ''''            ProjectBoard.LoadDataBy = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.LoadBy.SprintID
                ''''            ProjectBoard.Load()

                ''''        End If

                ''''    End Using

                ''''End If

            Catch ex As Exception
                Message = ex.Message
                Saved = False
            End Try

            Return View("ProjectBoard", ProjectBoard)

        End Function

        <AcceptVerbs("POST")>
        Public Function ResetProjectBoard(ByVal SprintID As Integer) As JsonResult

            Dim Reset As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim SomeReturnProperty As String

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_agile_reset_sprint] {0}, '{1}';",
                                                                           SprintID, Me.SecuritySession.UserCode))
                        Reset = True

                    Catch ex As Exception
                        Reset = False
                        ErrorMessage = ex.Message.ToString
                    End Try

                    If Reset = True Then

                        ReturnObject = New With {.SomeJsProperty = SomeReturnProperty}

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Reset, ErrorMessage, ReturnObject))

        End Function

        <AcceptVerbs("POST")>
        Public Function DeleteSprintBySprintID(ByVal SprintID As Integer, ByVal IncludeCompleted As Boolean) As ActionResult

            Dim Deleted As Boolean = True
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim BoardView As New BoardView
            Dim BoardID As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim Sprint As AdvantageFramework.Database.Entities.SprintHeader

                Sprint = Nothing
                Sprint = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintHeaderID(DbContext, SprintID)

                If Sprint IsNot Nothing Then

                    BoardID = Sprint.BoardID

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_agile_delete_sprint] {0};", SprintID))

                    Catch ex As Exception
                        Deleted = False
                        ErrorMessage = ex.Message.ToString
                    End Try

                    If Deleted = True Then


                    End If

                End If

            End Using

            BoardView = LoadBoardView(BoardID, IncludeCompleted)

            Return Json(BoardView.Sprints, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("POST")>
        Public Function FilterBoardView(ByVal BoardID As Integer, ByVal IncludeCompleted As Boolean) As ActionResult

            Dim BoardView As New BoardView

            BoardView = LoadBoardView(BoardID, IncludeCompleted)

            Return Json(BoardView.Sprints, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("GET")>
        Public Function TaskEmployees() As JsonResult

            Dim Employees As IEnumerable = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Employees = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                             Select EmployeeCode = Entity.Code,
                                    FullName = Entity.FirstName & " " & Entity.LastName).ToList


                Return Json(Employees, JsonRequestBehavior.AllowGet)

            End Using

        End Function
        <AcceptVerbs("POST")>
        Public Function BookmarkSprint(ByVal SprintID As Integer, ByVal Employees As String()) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim Emps As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim SprintHeader As AdvantageFramework.Database.Entities.SprintHeader = Nothing

                    SprintHeader = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintHeaderID(DbContext, SprintID)

                    If SprintHeader IsNot Nothing Then

                        Dim Board As AdvantageFramework.Database.Entities.Board = Nothing

                        Board = AdvantageFramework.Database.Procedures.Board.LoadBySprintID(DbContext, SprintID)

                        If Board IsNot Nothing Then

                            Dim Bookmark As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark = Nothing
                            Dim BookmarkMethods As AdvantageFramework.Web.Presentation.Bookmarks.Methods = Nothing

                            BookmarkMethods = New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                            Bookmark = New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark

                            Bookmark.BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_Agile_Sprint
                            Bookmark.UserCode = Me.SecuritySession.UserCode

                            If Employees IsNot Nothing AndAlso Employees.Count > 0 Then
                                Emps = String.Concat(Employees)
                            End If

                            Bookmark.PageURL = "ProjectManagement/Agile/Sprint/" & SprintID.ToString & "?emps=" & Emps

                            Bookmark.Name = String.Format(Board.Name)

                            If SprintHeader.Description.ToLower.StartsWith("sprint") = False Then

                                Bookmark.Description = String.Format("Sprint:  {0}", SprintHeader.Description)

                            Else

                                Bookmark.Description = SprintHeader.Description

                            End If

                            Success = BookmarkMethods.SaveBookmark(Bookmark, ErrorMessage)

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(New With {.Success = Success, .Message = ErrorMessage})

        End Function
        <AcceptVerbs("POST")>
        Public Function BookmarkBoard(ByVal BoardID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim Board As AdvantageFramework.Database.Entities.Board = Nothing

                    Board = AdvantageFramework.Database.Procedures.Board.LoadByBoardID(DbContext, BoardID)

                    If Board IsNot Nothing Then

                        Dim Bookmark As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark = Nothing
                        Dim BookmarkMethods As AdvantageFramework.Web.Presentation.Bookmarks.Methods = Nothing

                        BookmarkMethods = New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                        Bookmark = New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark

                        Bookmark.BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_Agile_Board
                        Bookmark.UserCode = Me.SecuritySession.UserCode

                        Bookmark.PageURL = "ProjectManagement/Agile/AgileBoard/" & BoardID.ToString

                        Bookmark.Name = String.Format(Board.Name)
                        Bookmark.Description = Board.Description

                        Success = BookmarkMethods.SaveBookmark(Bookmark, ErrorMessage)

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(New With {.Success = Success, .Message = ErrorMessage})

        End Function
        <AcceptVerbs("POST")>
        Public Function BookmarkMainBoard(ByVal BoardID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    'Dim Board As AdvantageFramework.Database.Entities.Board = Nothing

                    'Board = AdvantageFramework.Database.Procedures.Board.LoadByBoardID(DbContext, BoardID)

                    'If Board IsNot Nothing Then

                    Dim Bookmark As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark = Nothing
                    Dim BookmarkMethods As AdvantageFramework.Web.Presentation.Bookmarks.Methods = Nothing

                    BookmarkMethods = New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                    Bookmark = New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark

                    Bookmark.BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_Agile
                    Bookmark.UserCode = Me.SecuritySession.UserCode

                    Bookmark.PageURL = "ProjectManagement/Agile/AgileBoards"

                    Bookmark.Name = "Boards"
                    Bookmark.Description = "Boards"

                    Success = BookmarkMethods.SaveBookmark(Bookmark, ErrorMessage)

                    'End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(New With {.Success = Success, .Message = ErrorMessage})

        End Function

        <AcceptVerbs("GET")>
        Public Function GetSwimLaneCollapseSetting() As JsonResult

            Dim Collapse As Boolean = False
            If System.Web.HttpContext.Current.Session(SwimlaneCollapseSettingSessionKey) Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Try

                        Collapse = _Controller.LoadSwimLaneCollapseOption(DbContext)

                    Catch ex As Exception
                        Collapse = False
                    End Try

                End Using

                System.Web.HttpContext.Current.Session(SwimlaneCollapseSettingSessionKey) = Collapse

            Else

                Collapse = CType(System.Web.HttpContext.Current.Session(SwimlaneCollapseSettingSessionKey), Boolean)

            End If

            Return Json(Collapse, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("POST")>
        Public Function SaveSwimLaneCollapseSetting(ByVal Collapse As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                System.Web.HttpContext.Current.Session(SwimlaneCollapseSettingSessionKey) = Collapse

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = _Controller.SaveSwimLaneCollapseOption(DbContext, Collapse)

                    If Success = True Then


                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("GET")>
        Public Function GetSwimLaneBySetting() As JsonResult

            Dim SettingValue As String = "None"
            If System.Web.HttpContext.Current.Session(SwimlaneBySessionKey) Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Try

                        SettingValue = _Controller.LoadSwimLaneOption(DbContext)

                    Catch ex As Exception
                        SettingValue = "None"
                    End Try

                End Using

                System.Web.HttpContext.Current.Session(SwimlaneBySessionKey) = SettingValue

            Else

                SettingValue = System.Web.HttpContext.Current.Session(SwimlaneBySessionKey)

            End If

            Return Json(SettingValue, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("POST")>
        Public Function SaveSwimLaneBySetting(ByVal SettingValue As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                System.Web.HttpContext.Current.Session(SwimlaneBySessionKey) = SettingValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = _Controller.SaveSwimLaneOption(DbContext, SettingValue)

                    If Success = True Then


                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("GET")>
        Public Function GetFilterCardSetting() As JsonResult

            Dim SettingValue As String = ""
            If System.Web.HttpContext.Current.Session(FilterCardSessionKey) Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Try

                        SettingValue = _Controller.LoadFilterCardOption(DbContext)

                    Catch ex As Exception
                        SettingValue = ""
                    End Try

                End Using

                System.Web.HttpContext.Current.Session(FilterCardSessionKey) = SettingValue

            Else

                SettingValue = System.Web.HttpContext.Current.Session(FilterCardSessionKey)

            End If

            Return Json(SettingValue, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("POST")>
        Public Function SaveFilterCardSetting(ByVal SettingValue As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                System.Web.HttpContext.Current.Session(FilterCardSessionKey) = SettingValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = _Controller.SaveFilterCardOption(DbContext, SettingValue)

                    If Success = True Then


                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("GET")>
        Public Function GetFilterOnlyBacklogSetting() As JsonResult

            Dim Backlog As Boolean = False
            If System.Web.HttpContext.Current.Session(FilterCardOnlyBacklogSessionKey) Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Try

                        Backlog = _Controller.LoadFilterOnlyBacklogOption(DbContext)

                    Catch ex As Exception
                        Backlog = False
                    End Try

                End Using

                System.Web.HttpContext.Current.Session(FilterCardOnlyBacklogSessionKey) = Backlog

            Else

                Backlog = CType(System.Web.HttpContext.Current.Session(FilterCardOnlyBacklogSessionKey), Boolean)

            End If

            Return Json(Backlog, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("POST")>
        Public Function SaveFilterOnlyBacklogSetting(ByVal Backlog As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                System.Web.HttpContext.Current.Session(FilterCardOnlyBacklogSessionKey) = Backlog

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = _Controller.SaveFilterOnlyBacklogOption(DbContext, Backlog)

                    If Success = True Then


                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("GET")>
        Public Function GetFilterEmployeeSetting() As JsonResult

            Dim SettingValue As String = ""
            If System.Web.HttpContext.Current.Session(FilterEmployeeSessionKey) Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Try

                        SettingValue = _Controller.LoadFilterEmployeeOption(DbContext)

                    Catch ex As Exception
                        SettingValue = ""
                    End Try

                End Using

                System.Web.HttpContext.Current.Session(FilterEmployeeSessionKey) = SettingValue

            Else

                SettingValue = System.Web.HttpContext.Current.Session(FilterEmployeeSessionKey)

            End If

            Return Json(SettingValue, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("POST")>
        Public Function SaveFilterEmployeeSetting(ByVal SettingValue As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                System.Web.HttpContext.Current.Session(FilterEmployeeSessionKey) = SettingValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = _Controller.SaveFilterEmployeeOption(DbContext, SettingValue)

                    If Success = True Then


                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("GET")>
        Public Function GetFilterEmployeeBacklogSetting() As JsonResult

            Dim Backlog As Boolean = False
            If System.Web.HttpContext.Current.Session(FilterEmployeeBacklogSessionKey) Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Try

                        Backlog = _Controller.LoadFilterEmployeeBacklogOption(DbContext)

                    Catch ex As Exception
                        Backlog = False
                    End Try

                End Using

                System.Web.HttpContext.Current.Session(FilterEmployeeBacklogSessionKey) = Backlog

            Else

                Backlog = CType(System.Web.HttpContext.Current.Session(FilterEmployeeBacklogSessionKey), Boolean)

            End If

            Return Json(Backlog, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("POST")>
        Public Function SaveFilterEmployeeBacklogSetting(ByVal Backlog As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                System.Web.HttpContext.Current.Session(FilterEmployeeBacklogSessionKey) = Backlog

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = _Controller.SaveFilterEmployeeBacklogOption(DbContext, Backlog)

                    If Success = True Then


                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("GET")>
        Public Function GetFilterBacklogSortSetting() As JsonResult

            Dim SettingValue As String = "0"
            If System.Web.HttpContext.Current.Session(FilterBacklogSortSessionKey) Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Try

                        SettingValue = _Controller.LoadFilterBacklogSortOption(DbContext)

                    Catch ex As Exception
                        SettingValue = "0"
                    End Try

                End Using

                System.Web.HttpContext.Current.Session(FilterBacklogSortSessionKey) = SettingValue

            Else

                SettingValue = System.Web.HttpContext.Current.Session(FilterBacklogSortSessionKey)

            End If

            Return Json(SettingValue, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("POST")>
        Public Function SaveFilterBacklogSort(ByVal SettingValue As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                System.Web.HttpContext.Current.Session(FilterBacklogSortSessionKey) = SettingValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = _Controller.SaveFilterBacklogSortOption(DbContext, SettingValue)

                    If Success = True Then


                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("GET")>
        Public Function GetFilterBacklogSortTypeSetting() As JsonResult

            Dim SettingValue As String = "modified"
            If System.Web.HttpContext.Current.Session(FilterBacklogSortTypeSessionKey) Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Try

                        SettingValue = _Controller.LoadFilterBacklogSortTypeOption(DbContext)

                    Catch ex As Exception
                        SettingValue = "modified"
                    End Try

                End Using

                System.Web.HttpContext.Current.Session(FilterBacklogSortTypeSessionKey) = SettingValue

            Else

                SettingValue = System.Web.HttpContext.Current.Session(FilterBacklogSortTypeSessionKey)

            End If

            Return Json(SettingValue, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("POST")>
        Public Function SaveFilterBacklogSortTypeSetting(ByVal SettingValue As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                System.Web.HttpContext.Current.Session(FilterBacklogSortTypeSessionKey) = SettingValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = _Controller.SaveFilterBacklogSortTypeOption(DbContext, SettingValue)

                    If Success = True Then


                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function



        Private Function DeleteDefaultSprintByJobAndComponentNumber(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                    ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Boolean

            Try

                Dim SprintID As Integer = 0
                Dim Success As Boolean = False

                'SprintID = (From Entity In AdvantageFramework.Database.Procedures.SprintHeader.LoadByJobAndComponentNumber(DbContext, JobNumber, JobComponentNumber)
                '            Where Entity.BoardHeaderID = 1
                '            Select Entity.ID).SingleOrDefault

                If SprintID > 0 Then

                    Try

                        DeleteSprintBySprintID(SprintID, True)

                    Catch ex As Exception

                    End Try

                End If

                Return Success

            Catch ex As Exception
                Return False
            End Try

        End Function

#End Region

#Region " Card Methods "

        <AcceptVerbs("GET", "POST")>
        Public Function LoadCardEdit(ByVal AlertID As Integer, ByVal SprintDetailID As Integer) As ActionResult

            Dim Results As New CardEditResult

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim CardIsTrueAssignment As Boolean = False
                Dim SprintHeader As AdvantageFramework.Database.Entities.SprintHeader = Nothing
                Dim SprintDetail As AdvantageFramework.Database.Entities.SprintDetail = Nothing
                Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                SprintDetail = AdvantageFramework.Database.Procedures.SprintDetail.LoadBySprintDetailID(DbContext, SprintDetailID)
                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                If Alert IsNot Nothing Then

                    If (Alert.IsWorkItem Is Nothing OrElse Alert.IsWorkItem = 0) AndAlso (Alert.AlertAssignmentTemplateID IsNot Nothing AndAlso Alert.AlertAssignmentTemplateID > 0) Then

                        CardIsTrueAssignment = True

                    End If
                    If Alert.PriorityLevel IsNot Nothing Then

                        Results.SelectedPriority = Alert.PriorityLevel

                    End If
                    If String.IsNullOrWhiteSpace(Alert.AssignedEmployeeEmployeeCode) = False Then

                        Results.AssigneeEmployeeCode = Alert.AssignedEmployeeEmployeeCode

                    End If
                    If Alert.AlertCategoryID > 0 Then

                        Results.SelectedType = Alert.AlertCategoryID

                    End If
                    If Alert.AlertStateID IsNot Nothing AndAlso Alert.AlertStateID > 0 Then

                        Results.SelectedStateID = Alert.AlertStateID

                    End If

                End If

                If SprintDetail IsNot Nothing Then

                    SprintHeader = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintHeaderID(DbContext, SprintDetail.SprintHeaderID)

                End If

                'My Picutre
                Try
                    Dim EmployeePicture As AdvantageFramework.Database.Entities.EmployeePicture = Nothing

                    EmployeePicture = AdvantageFramework.Database.Procedures.EmployeePicture.LoadByEmployeeCode(DbContext, Me.CurrentEmployeeCode)

                    If EmployeePicture IsNot Nothing AndAlso EmployeePicture.Image IsNot Nothing Then

                        Results.MyPictureSrc = String.Format("data:{0};base64,{1}", "image/jpeg", Convert.ToBase64String(EmployeePicture.Image))

                    End If

                Catch ex As Exception
                End Try

                'Comments
                Try

                    Dim CardComments As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.CardDetail.Comment) = Nothing

                    CardComments = DbContext.Database.SqlQuery(Of AdvantageFramework.ProjectManagement.Agile.Classes.CardDetail.Comment)(String.Format("EXEC [dbo].[advsp_agile_load_card_comments] {0}", AlertID)).ToList

                    If CardComments IsNot Nothing Then

                        For Each Comment As AdvantageFramework.ProjectManagement.Agile.Classes.CardDetail.Comment In CardComments

                            If Comment.CommentDate IsNot Nothing Then

                                Comment.CommentDateString = String.Format("{0:g}", Comment.CommentDate)

                            End If
                            If Comment.EmployeePicture IsNot Nothing AndAlso Comment.EmployeePicture.Length > 0 Then

                                Comment.EmployeePictureURL = String.Format("data:{0};base64,{1}", "image/jpeg", Convert.ToBase64String(Comment.EmployeePicture))

                            End If

                        Next

                    Else

                        CardComments = New List(Of AdvantageFramework.ProjectManagement.Agile.Classes.CardDetail.Comment)

                    End If

                    Results.Comments = CardComments
                    Results.CommentCount = CardComments.Count

                Catch ex As Exception
                End Try

                'Employees
                Try

                    Results.Employees = LoadEmployeeSimple(DbContext, "", "", "", 0, 0, 0, False, False, False, True)

                Catch ex As Exception
                End Try

                'Status
                Try

                    Results.Statuses = (From AlertCategory In DbContext.AlertCategories
                                        Where AlertCategory.AlertTypeID = 6 Or AlertCategory.AlertTypeID = 16
                                        Order By AlertCategory.AlertTypeID Descending, AlertCategory.Description
                                        Select AlertCategory.ID, AlertCategory.Description).ToList

                Catch ex As Exception
                End Try

                'States
                Try

                    If SprintHeader IsNot Nothing Then

                        ' DUE TO CHANGE BY EC:  
                        'Results.States = (From AlertState In DbContext.AlertStates
                        '                  Join BoardDetail In DbContext.BoardDetails On AlertState.ID Equals BoardDetail.AlertStateID
                        '                  Where BoardDetail.BoardHeaderID = SprintHeader.BoardHeaderID
                        '                  Select AlertState.ID, AlertState.Name).ToList

                    End If

                Catch ex As Exception
                End Try

                'Weeks
                Try

                    If SprintHeader IsNot Nothing AndAlso SprintHeader.NumberOfWeeks IsNot Nothing Then

                        Results.NumberOfWeeks = SprintHeader.NumberOfWeeks

                    End If

                Catch ex As Exception
                End Try

            End Using

            Return Json(Results, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("GET", "POST")>
        Public Function LoadCardNew(ByVal SprintHeaderID As Integer, ByVal BoardColumnID As Integer) As ActionResult

            Dim Results As New CardNewResult

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim ThisJobNumber As Integer = 0
                Dim ThisJobComponentNumber As Short = 0
                Dim SprintHeader As AdvantageFramework.Database.Entities.SprintHeader = Nothing

                SprintHeader = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintHeaderID(DbContext, SprintHeaderID)

                'Job based
                Try

                    If SprintHeader IsNot Nothing Then

                        ''''If SprintHeader.JobNumber IsNot Nothing Then ThisJobNumber = SprintHeader.JobNumber
                        ''''If SprintHeader.JobComponentNumber IsNot Nothing Then ThisJobComponentNumber = SprintHeader.JobComponentNumber

                        If ThisJobNumber > 0 AndAlso ThisJobComponentNumber > 0 Then

                            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

                            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, ThisJobNumber, ThisJobComponentNumber)

                            If JobComponent IsNot Nothing Then

                                Try

                                    Results.Tasks = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumber(DbContext, ThisJobNumber, ThisJobComponentNumber)
                                                     Select Entity.JobNumber, Entity.JobComponentNumber, Entity.SequenceNumber, Entity.FuctionCode, Entity.Description).ToList

                                Catch ex As Exception
                                End Try
                                Try

                                    Results.Versions = (From Entity In AdvantageFramework.Database.Procedures.SoftwareVersion.LoadByJobAndComponent(DbContext, ThisJobNumber, ThisJobComponentNumber)
                                                        Select Entity.ID, Entity.Name).ToList

                                Catch ex As Exception
                                End Try

                            End If

                        End If

                    End If

                Catch ex As Exception
                End Try

                'Employees
                Try

                    Results.Employees = LoadEmployeeSimple(DbContext, "", "", "", 0, 0, 0, False, False, False, True)

                Catch ex As Exception
                End Try

                'Status
                Try

                    Results.Statuses = (From AlertCategory In DbContext.AlertCategories
                                        Where AlertCategory.AlertTypeID = 6 Or AlertCategory.AlertTypeID = 16
                                        Order By AlertCategory.AlertTypeID Descending, AlertCategory.Description
                                        Select AlertCategory.ID, AlertCategory.Description).ToList

                Catch ex As Exception
                End Try

                'Hours by week
                Try

                    If SprintHeader IsNot Nothing AndAlso SprintHeader.NumberOfWeeks IsNot Nothing AndAlso SprintHeader.NumberOfWeeks > 0 Then

                        Dim HoursList As New Generic.List(Of SimpleWeeklyHours)
                        Dim WeeklyHours As SimpleWeeklyHours

                        For i As Integer = 0 To SprintHeader.NumberOfWeeks - 1

                            WeeklyHours = New SimpleWeeklyHours
                            WeeklyHours.WeekNumber = i + 1

                            WeeklyHours = Nothing

                        Next

                    End If

                Catch ex As Exception
                End Try

            End Using

            Return Json(Results, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("GET", "POST")>
        Public Function LoadEmployeeHours(ByVal EmployeeCode As String, ByVal SprintDetailID As Integer) As ActionResult

            Dim Results As New EmployeeHoursResult

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim SprintHeader As AdvantageFramework.Database.Entities.SprintHeader = Nothing
                Dim SprintDetail As AdvantageFramework.Database.Entities.SprintDetail = Nothing
                Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

                SprintDetail = AdvantageFramework.Database.Procedures.SprintDetail.LoadBySprintDetailID(DbContext, SprintDetailID)

                If SprintDetail IsNot Nothing Then

                    SprintHeader = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintHeaderID(DbContext, SprintDetail.SprintHeaderID)

                    If SprintHeader IsNot Nothing Then

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                        If Employee IsNot Nothing Then

                            Results.TotalWorkingHoursForDuration = IIf(Employee.SundayHours IsNot Nothing, Employee.SundayHours, 0) +
                                                                   IIf(Employee.MondayHours IsNot Nothing, Employee.MondayHours, 0) +
                                                                   IIf(Employee.TuesdayHours IsNot Nothing, Employee.TuesdayHours, 0) +
                                                                   IIf(Employee.WednesdayHours IsNot Nothing, Employee.WednesdayHours, 0) +
                                                                   IIf(Employee.ThursdayHours IsNot Nothing, Employee.ThursdayHours, 0) +
                                                                   IIf(Employee.FridayHours IsNot Nothing, Employee.FridayHours, 0) +
                                                                   IIf(Employee.SaturdayHours IsNot Nothing, Employee.SaturdayHours, 0)

                            If SprintHeader.NumberOfWeeks IsNot Nothing AndAlso SprintHeader.NumberOfWeeks > 1 Then

                                Results.TotalWorkingHoursForDuration = Results.TotalWorkingHoursForDuration * SprintHeader.NumberOfWeeks

                            End If

                            Results.TotalHoursUsed = 5

                            Results.TotalHoursAvailable = Results.TotalWorkingHoursForDuration - Results.TotalHoursUsed

                        End If

                    End If

                End If

            End Using

            Return Json(Results, JsonRequestBehavior.AllowGet)

        End Function

#End Region

#Region " Hours "

        <AcceptVerbs("POST")>
        Public Function FilterHoursGrid(ByVal SprintHeaderID As Integer, ByVal AlertID As Integer,
                                        ByVal ShowPast As Boolean, ByVal ShowFuture As Boolean,
                                        ByVal EmployeeCodes As String(), ByVal HasWeeklyHours As Boolean, ByVal ShowAvailability As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim SomeReturnProperty As String
            Dim Hours As New AdvantageFramework.ProjectManagement.Agile.Classes.WeeklyHours(Me.SecuritySession)

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Hours.SprintHeaderID = SprintHeaderID
                    Hours.AlertID = AlertID
                    Hours.ShowPastWeeksSetting = ShowPast
                    Hours.ShowFutureWeeksSetting = ShowFuture
                    Hours.ShowAvailability = ShowAvailability

                    Hours.Load()

                    'if we are looking for weekly hours but there are none clear the employee hours that were loaded by the load methiod
                    If Hours.HasWeeklyHours = False AndAlso HasWeeklyHours = True Then
                        Hours.WorkItemHours = New List(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel)
                    End If

                    If Hours IsNot Nothing Then

                        If Hours.WorkItemHours IsNot Nothing AndAlso Hours.WorkItemHours.Count > 0 AndAlso
                            EmployeeCodes IsNot Nothing AndAlso EmployeeCodes.Count > 0 Then

                            Hours.WorkItemHours = (From Entity In Hours.WorkItemHours
                                                   Where EmployeeCodes.Contains(Entity.EmployeeCode)
                                                   Select Entity).ToList

                        End If

                        Success = True

                    End If
                    If Success = True Then

                        ReturnObject = New With {.Hours = Hours.WorkItemHours}

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            If Hours IsNot Nothing Then

                ViewData("HasWeeklyHours") = Hours.HasWeeklyHours

                ViewData("HasStartDate") = Hours.HasStartDate
                ViewData("HasDueDate") = Hours.HasDueDate

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

#End Region

#Region " Helpers "

        Private Function GetSprintBacklogIsSorted(ByVal SprintID As Boolean) As Boolean

            Dim Key As String = String.Format("SBLIS_{0}_{1}", SprintID, Me.SecuritySession.UserCode)

            If Session(Key) IsNot Nothing Then

                Return CType(Session(Key), Boolean)

            Else

                Return False

            End If

        End Function
        Private Sub SetSprintBacklogIsSorted(ByVal SprintID As Boolean, ByVal BacklogSort As Short?)

            Dim Key As String = String.Format("SBLIS_{0}_{1}", SprintID, Me.SecuritySession.UserCode)

            If BacklogSort Is Nothing OrElse BacklogSort = 0 Then

                Session(Key) = False

            Else

                Session(Key) = True

            End If

        End Sub

        <AcceptVerbs("POST")>
        Public Function MarkTaskTempComplete(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TaskSequenceNumber As Short, ByVal SprintID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim MarkedTempComplete As Boolean = False

            Try

                Dim Psc As New AdvantageFramework.Controller.ProjectManagement.ProjectScheduleController(Me.SecuritySession)

                Success = Psc.MarkTaskTempComplete(JobNumber, JobComponentNumber, TaskSequenceNumber, Me.CurrentEmployeeCode, MarkedTempComplete)
                ReturnObject = New With {.MarkedTempComplete = MarkedTempComplete}

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message.ToString
            End Try

            If Success = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    ''Webvantage.SignalR.Classes.NotificationHub.RefreshSprint(DbContext, SprintID, False)

                End Using

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function


        <AcceptVerbs("POST", "GET")>
        Public Function GetStateIDFromColumn(ByVal BoardHeaderID As Integer, ByVal BoardColumnID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim StateID As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim BoardDetail As AdvantageFramework.Database.Entities.BoardDetail = Nothing

                    Try

                        BoardDetail = AdvantageFramework.Database.Procedures.BoardDetail.LoadByBoardHeaderIDandBoardColumnID(DbContext, BoardHeaderID, BoardColumnID)

                    Catch ex As Exception
                        BoardDetail = Nothing
                    End Try

                    If BoardDetail Is Nothing Then

                        BoardDetail = AdvantageFramework.Database.Procedures.BoardDetail.LoadFirstStateByBoardHeaderIDandBoardColumnID(DbContext, BoardHeaderID, BoardColumnID)

                    End If

                    If BoardDetail IsNot Nothing Then

                        Success = True
                        StateID = BoardDetail.AlertStateID

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, StateID))

        End Function
        <AcceptVerbs("POST")>
        Public Function GetClientCodeFromName(ByVal ClientName As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim ClientCode As String = String.Empty

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

                    Client = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Client)
                              Where Entity.Name = ClientName And Entity.IsActive = 1
                              Select Entity).FirstOrDefault

                    If Client IsNot Nothing Then

                        ClientCode = Client.Code
                        Success = True

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ClientCode))

        End Function

        '<AcceptVerbs("POST")>
        'Public Function RefreshSprint(ByVal SprintID As Integer) As JsonResult

        '    Dim Success As Boolean = False
        '    Dim ErrorMessage As String = String.Empty
        '    Dim ReturnObject As Object = Nothing
        '    'Dim SomeReturnProperty As String

        '    Try

        '        SignalR.Classes.NotificationHub.RefreshSprint(SprintID, Me.SecuritySession.UserCode)
        '        Success = True

        '    Catch ex As Exception
        '        ErrorMessage = ex.Message.ToString
        '    End Try

        '    Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        'End Function

        Public Function BoardURL(ByVal BoardID As Integer) As String

            Dim TheURL As String = String.Format("{0}://{1}{2}{3}/{4}", Request.Url.Scheme,
                                                                        Request.Url.Authority,
                                                                        Url.Content("~"),
                                                                        Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute & "AgileBoard",
                                                                        BoardID.ToString)


            Return TheURL

        End Function
        Public Function EditAgileBoardURL(ByVal BoardID As Integer) As String

            Dim TheURL As String = String.Format("{0}://{1}{2}{3}/{4}", Request.Url.Scheme,
                                                                        Request.Url.Authority,
                                                                        Url.Content("~"),
                                                                        Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute & "NewAgileBoard",
                                                                        BoardID)


            Return TheURL

        End Function
        Public Function NewAgileBoardURL() As String

            Dim TheURL As String = String.Format("{0}://{1}{2}{3}", Request.Url.Scheme,
                                                                    Request.Url.Authority,
                                                                    Url.Content("~"),
                                                                    Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute & "NewAgileBoard")


            Return TheURL

        End Function

        Private Function SprintURL(ByVal SprintID As Integer) As String

            Dim TheURL As String = String.Format("{0}://{1}{2}{3}/{4}", Request.Url.Scheme,
                                                                        Request.Url.Authority,
                                                                        Url.Content("~"),
                                                                        Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute & "Sprint",
                                                                        SprintID.ToString)


            Return TheURL

        End Function
        Private Function NewSprintURL(ByVal BoardID As Integer) As String

            Dim TheURL As String = String.Format("{0}://{1}{2}{3}/{4}/0", Request.Url.Scheme,
                                                                          Request.Url.Authority,
                                                                          Url.Content("~"),
                                                                          Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute & "NewSprint",
                                                                          BoardID.ToString)


            Return TheURL

        End Function
        Private Function EditSprintURL(ByVal BoardID As Integer) As String

            Dim TheURL As String = String.Format("{0}://{1}{2}{3}/{4}", Request.Url.Scheme,
                                                                        Request.Url.Authority,
                                                                        Url.Content("~"),
                                                                        Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute & "NewSprint",
                                                                        BoardID.ToString)


            Return TheURL

        End Function

        Public Function NewBoardURL(ByVal ViewName As String, ByVal JobNumber As Integer?, ByVal JobComponentNumber As Short?) As String

            Dim TheURL As String = String.Format("{0}://{1}{2}{3}/{4}/{5}/{6}", Request.Url.Scheme,
                                                                                Request.Url.Authority,
                                                                                Url.Content("~"),
                                                                                Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute & "NewBoard",
                                                                                IIf(JobNumber Is Nothing, 0, JobNumber),
                                                                                IIf(JobComponentNumber Is Nothing, 0, JobComponentNumber),
                                                                                IIf(String.IsNullOrWhiteSpace(ViewName), "", ViewName))


            Return TheURL

        End Function

        Private Function LoadEmployeeSimple(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal EmployeeCode As String,
                                            ByVal DepartmentTeamCode As String,
                                            ByVal EmailGroupCode As String,
                                            ByVal JobNumber As Integer,
                                            ByVal JobComponentNumber As Short,
                                            ByVal TaskSequenceNumber As Short,
                                            ByVal IsLookingUpAccountExecutive As Boolean,
                                            ByVal FilterByTaskRoles As Boolean,
                                            ByVal FilterByJobEmailGroup As Boolean,
                                            ByVal OnlyShowActive As Boolean) As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeSimple)

            Try

                Dim SqlParameterUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 10)
                Dim SqlParameterEmployeeCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                Dim SqlParameterDepartmentTeamCode As New System.Data.SqlClient.SqlParameter("@DP_TM_CODE", SqlDbType.VarChar, 6)
                Dim SqlParameterEmailGroupCode As New System.Data.SqlClient.SqlParameter("@EMAIL_GR_CODE", SqlDbType.VarChar, 50)
                Dim SqlParameterJobNumber As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                Dim SqlParameterJobComponentNumber As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                Dim SqlParameterTaskSequenceNumber As New System.Data.SqlClient.SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                Dim SqlParameterIsLookingUpAccountExecutive As New System.Data.SqlClient.SqlParameter("@IS_AE", SqlDbType.Bit)
                Dim SqlParameterFilterByTaskRoles As New System.Data.SqlClient.SqlParameter("@IS_ROLE", SqlDbType.Bit)
                Dim SqlParameterFilterByJobEmailGroup As New System.Data.SqlClient.SqlParameter("@IS_EMAIL_GROUP", SqlDbType.Bit)
                Dim SqlParameterOnlyShowActive As New System.Data.SqlClient.SqlParameter("@ONLY_ACTIVE", SqlDbType.Bit)

                SqlParameterUserCode.Value = Me.SecuritySession.UserCode
                If EmployeeCode = "" Then

                    SqlParameterEmployeeCode.Value = System.DBNull.Value

                Else

                    SqlParameterEmployeeCode.Value = EmployeeCode

                End If
                If DepartmentTeamCode = "" Then

                    SqlParameterDepartmentTeamCode.Value = System.DBNull.Value

                Else

                    SqlParameterDepartmentTeamCode.Value = DepartmentTeamCode

                End If
                If EmailGroupCode = "" Then

                    SqlParameterEmailGroupCode.Value = System.DBNull.Value

                Else

                    SqlParameterEmailGroupCode.Value = EmailGroupCode

                End If
                If JobNumber = 0 Then

                    SqlParameterJobNumber.Value = System.DBNull.Value

                Else

                    SqlParameterJobNumber.Value = JobNumber

                End If
                If JobComponentNumber = 0 Then

                    SqlParameterJobComponentNumber.Value = System.DBNull.Value

                Else

                    SqlParameterJobComponentNumber.Value = JobComponentNumber

                End If
                If TaskSequenceNumber = -1 Then

                    SqlParameterTaskSequenceNumber.Value = System.DBNull.Value

                Else

                    SqlParameterTaskSequenceNumber.Value = TaskSequenceNumber

                End If

                SqlParameterIsLookingUpAccountExecutive.Value = IsLookingUpAccountExecutive
                SqlParameterFilterByTaskRoles.Value = FilterByTaskRoles
                SqlParameterFilterByJobEmailGroup.Value = FilterByJobEmailGroup
                SqlParameterOnlyShowActive.Value = OnlyShowActive

                LoadEmployeeSimple = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Entities.EmployeeSimple)("EXEC advsp_load_employee_simple @USER_CODE, @EMP_CODE, @DP_TM_CODE, @EMAIL_GR_CODE, @JOB_NUMBER, @JOB_COMPONENT_NBR, @SEQ_NBR, @IS_AE, @IS_ROLE, @IS_EMAIL_GROUP, @ONLY_ACTIVE",
                                                                                                                         SqlParameterUserCode,
                                                                                                                         SqlParameterEmployeeCode,
                                                                                                                         SqlParameterDepartmentTeamCode,
                                                                                                                         SqlParameterEmailGroupCode,
                                                                                                                         SqlParameterJobNumber,
                                                                                                                         SqlParameterJobComponentNumber,
                                                                                                                         SqlParameterTaskSequenceNumber,
                                                                                                                         SqlParameterIsLookingUpAccountExecutive,
                                                                                                                         SqlParameterFilterByTaskRoles,
                                                                                                                         SqlParameterFilterByJobEmailGroup,
                                                                                                                         SqlParameterOnlyShowActive).ToList


            Catch ex As Exception
                Return Nothing
            End Try

        End Function

#End Region

#Region " Sprint Dashboard "

        <HttpGet>
        Public Function GetDashboard(SprintID As Integer) As JsonResult

            Return Json(New With {.DashboardName = "Sample Dashboard"}, JsonRequestBehavior.AllowGet)

        End Function

#End Region

#Region " NewWorkItemTime "

        <HttpGet>
        Public Function InitNewWorkItemTime(ByVal AlertID As Integer) As JsonResult

            Dim AlertTimeEntry As New AdvantageFramework.ViewModels.ProjectManagement.Agile.AlertTimeEntryViewModel
            Dim EmployeeCode As String = String.Empty
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0
            Dim TaskSequenceNumber As Short = -1
            Dim EmployeeDefaultFunctionCode As String = String.Empty

            AlertTimeEntry.AlertID = AlertID

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                If String.IsNullOrWhiteSpace(EmployeeCode) = True Then

                    EmployeeCode = Me.CurrentEmployeeCode

                End If
                If String.IsNullOrWhiteSpace(EmployeeCode) = True Then

                    EmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = '{0}';", Me.SecuritySession.UserCode.ToUpper())).FirstOrDefault

                End If
                If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)
                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                    If Alert IsNot Nothing Then

                        If Alert.JobNumber IsNot Nothing Then

                            JobNumber = Alert.JobNumber

                        End If
                        If Alert.JobComponentNumber IsNot Nothing Then

                            JobComponentNumber = Alert.JobComponentNumber

                        End If
                        If Alert.TaskSequenceNumber IsNot Nothing Then

                            TaskSequenceNumber = Alert.TaskSequenceNumber

                        End If

                        AlertTimeEntry.Title = Alert.Subject

                    End If
                    If Employee IsNot Nothing Then

                        AlertTimeEntry.EmployeeDefaultFunctionCode = Employee.FunctionCode
                        EmployeeDefaultFunctionCode = Employee.FunctionCode

                    End If

                    Dim LimitFunctionsByBillingRate As Boolean = False
                    Dim BillingRestrictedFunctionCodes As Generic.List(Of String) = Nothing
                    Dim IsTaskFunction As Boolean = False

                    If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                        Dim Task As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
                        Dim ClientCode As String = String.Empty

                        Try

                            If TaskSequenceNumber > -1 Then

                                Task = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, JobNumber, JobComponentNumber, TaskSequenceNumber)

                            End If

                        Catch ex As Exception
                            Task = Nothing
                        End Try
                        Try

                            ClientCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT CL_CODE FROM JOB_LOG WHERE JOB_NUMBER = {0};", JobNumber)).SingleOrDefault

                        Catch ex As Exception
                            ClientCode = String.Empty
                        End Try
                        If String.IsNullOrWhiteSpace(ClientCode) = False Then

                            Try

                                LimitFunctionsByBillingRate = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CAST(ISNULL(LIMIT_TIME_FUNCTIONS_TO_BILLING_HIERARCHY, 0) AS BIT) FROM CLIENT WHERE CL_CODE = '{0}';", ClientCode)).SingleOrDefault

                            Catch ex As Exception
                                LimitFunctionsByBillingRate = False
                            End Try

                        End If
                        If LimitFunctionsByBillingRate = False Then

                            If Task IsNot Nothing AndAlso Task.FuctionCode IsNot Nothing Then

                                AlertTimeEntry.EmployeeDefaultFunctionCode = Task.FuctionCode
                                IsTaskFunction = True

                            End If

                        Else

                            Try

                                BillingRestrictedFunctionCodes = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT FNC_CODE FROM BILLING_RATE WHERE CL_CODE = '{0}' AND NOT FNC_CODE IS NULL;", ClientCode)).ToList

                            Catch ex As Exception
                                BillingRestrictedFunctionCodes = Nothing
                            End Try

                            If BillingRestrictedFunctionCodes Is Nothing Then BillingRestrictedFunctionCodes = New List(Of String)

                            If BillingRestrictedFunctionCodes IsNot Nothing AndAlso
                                Task IsNot Nothing AndAlso Task.FuctionCode IsNot Nothing AndAlso
                                BillingRestrictedFunctionCodes.Contains(Task.FuctionCode) = True Then

                                AlertTimeEntry.EmployeeDefaultFunctionCode = Task.FuctionCode

                            End If

                        End If

                    End If
                    If LimitFunctionsByBillingRate = False Then

                        AlertTimeEntry.Functions = AdvantageFramework.Database.Procedures.Function.LoadForEmployeeDirectTime(DbContext, EmployeeCode)

                    Else

                        AlertTimeEntry.Functions = (From Entity In DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Procedures.Function.Methods.DirectTimeFunction)(String.Format("EXEC [dbo].[usp_wv_dd_GetFunctions_ByEmpCode] '{0}', 0, NULL;", EmployeeCode))
                                                    Where BillingRestrictedFunctionCodes.Contains(Entity.Code)
                                                    Select New With {.Code = Entity.Code,
                                                                     .Description = Entity.DescriptionOnly}).ToList

                    End If
                    Try

                        If AlertTimeEntry.Functions IsNot Nothing Then

                            Dim FnCount As Integer = 0

                            Try

                                FnCount = (From Entity In AlertTimeEntry.Functions
                                           Where Entity.Code = AlertTimeEntry.EmployeeDefaultFunctionCode).Count

                            Catch ex As Exception
                                FnCount = 0
                            End Try

                            If FnCount = 0 Then

                                AlertTimeEntry.EmployeeDefaultFunctionCode = EmployeeDefaultFunctionCode

                            End If

                        End If


                    Catch ex As Exception
                    End Try

                    AlertTimeEntry.CommentRequired = AdvantageFramework.EmployeeTimesheet.CheckTimeCommentsRequired(DbContext, JobNumber, 0, 0)
                    AlertTimeEntry.Date = CType(Me.TimeZoneToday, DateTime)

                End If

            End Using

            Return Json(AlertTimeEntry, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("GET", "POST")>
        Public Function CheckIfPostPeriodIsAvailable(ByVal EntryDate As Date) As JsonResult

            Dim Success As Boolean = True
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim PostPeriodIsAvailable As Boolean = True

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    EntryDate = New Date(EntryDate.Year, EntryDate.Month, EntryDate.Day)

                    PostPeriodIsAvailable = AdvantageFramework.EmployeeTimesheet.CheckIfPostPeriodIsAvailable(DbContext, EntryDate)

                    If PostPeriodIsAvailable = False Then

                        Success = False
                        ErrorMessage = "Post period for this day is closed."

                    End If

                    ReturnObject = New With {.PostPeriodIsAvailable = PostPeriodIsAvailable.ToString.ToLower}

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(ReturnObject, JsonRequestBehavior.AllowGet)

        End Function

        <AcceptVerbs("POST")>
        Public Function SaveShowPastWeeksSetting(ByVal Checked As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Dim WeeklyHours = New AdvantageFramework.ProjectManagement.Agile.Classes.WeeklyHours(Me.SecuritySession)
                WeeklyHours.SaveShowPastWeeksSetting(Checked)
                Success = True

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("POST")>
        Public Function SaveShowFutureWeeksSetting(ByVal Checked As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Dim WeeklyHours = New AdvantageFramework.ProjectManagement.Agile.Classes.WeeklyHours(Me.SecuritySession)
                WeeklyHours.SaveShowFutureWeeksSetting(Checked)
                Success = True

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("POST")>
        Public Function SaveGroupEmployeesSetting(ByVal Checked As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Dim WeeklyHours = New AdvantageFramework.ProjectManagement.Agile.Classes.WeeklyHours(Me.SecuritySession)
                WeeklyHours.SaveGroupEmployeesSetting(Checked)
                Success = True

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("POST")>
        Public Function SaveGroupWeeksSetting(ByVal Checked As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Dim WeeklyHours = New AdvantageFramework.ProjectManagement.Agile.Classes.WeeklyHours(Me.SecuritySession)
                WeeklyHours.SaveGroupWeeksSetting(Checked)
                Success = True

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("POST")>
        Public Function SaveCreatePriorWeeksSetting(ByVal Checked As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Dim WeeklyHours = New AdvantageFramework.ProjectManagement.Agile.Classes.WeeklyHours(Me.SecuritySession)
                WeeklyHours.SaveCreatePriorWeeksSetting(Checked)
                Success = True

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function

#End Region

#Region " Permissions "

        Private Function CanAdd() As Boolean

            Dim CanUser As Boolean = AdvantageFramework.Security.CanUserAddInModule(Me.SecuritySession,
                                                                                    AdvantageFramework.Security.Modules.ProjectManagement_Boards.ToString)
            ViewData("CanAdd") = CanUser
            Return CanUser

        End Function
        Private Function CanUpdate() As Boolean

            Dim CanUser As Boolean = AdvantageFramework.Security.CanUserUpdateInModule(Me.SecuritySession,
                                                                                       AdvantageFramework.Security.Modules.ProjectManagement_Boards.ToString)
            ViewData("CanUpdate") = CanUser
            Return CanUser

        End Function
        Private Function CanPrint() As Boolean

            Dim CanUser As Boolean = AdvantageFramework.Security.CanUserPrintInModule(Me.SecuritySession,
                                                                                      AdvantageFramework.Security.Modules.ProjectManagement_Boards.ToString)
            ViewData("CanPrint") = CanUser
            Return CanUser

        End Function
        Private Function NoAccessToNonActiveSprint() As Boolean 'Custom1 permission

            Dim CanUser As Boolean = AdvantageFramework.Security.CanUserCustom1InModule(Me.SecuritySession,
                                                                                        AdvantageFramework.Security.Modules.ProjectManagement_Boards.ToString)
            ViewData("NoAccessToNonActiveSprint") = CanUser
            Return CanUser

        End Function

#End Region

#End Region

#Region " POCO's "

        <Serializable()>
        Public Class BoardDisplay


#Region " Constants "



#End Region

#Region " Enum "

            Public Enum Properties

                ID
                Name
                Description
                BoardOwnerEmployeeCode
                BoardHeaderID
                OfficeCode
                CreatedByUserCode
                CreatedDate
                CompletedDate
                IsActive
                BoardOwnerFullName
                OfficeName
                SprintCount
                JobIsOnBoard

            End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

            Public Property ID As Integer
            Public Property Name As String
            Public Property Description As String
            Public Property BoardOwnerEmployeeCode As String
            Public Property BoardHeaderID As Integer?
            Public Property OfficeCode As String
            Public Property CreatedByUserCode As String
            Public Property CreatedDate As DateTime?
            Public Property CompletedDate As DateTime?
            Public Property IsActive As Boolean?
            Public Property BoardOwnerFullName As String
            Public Property OfficeName As String
            Public Property SprintCount As Integer? = 0
            Public Property JobIsOnBoard As Boolean? = False

#End Region

#Region " Methods "

            Sub New()

            End Sub
            Sub New(ByVal ID As Integer, ByVal Name As String, ByVal Description As String, ByVal BoardOwnerEmployeeCode As String,
                    ByVal BoardHeaderID As Integer?, ByVal OfficeCode As String, ByVal CreatedByUserCode As String, ByVal CreatedDate As DateTime?,
                    ByVal CompletedDate As DateTime?, ByVal IsActive As Boolean?, ByVal BoardOwnerFullName As String)

                Me.ID = ID
                Me.Name = Name
                Me.Description = Description
                Me.BoardOwnerEmployeeCode = BoardOwnerEmployeeCode
                Me.BoardHeaderID = BoardHeaderID
                Me.OfficeCode = OfficeCode
                Me.CreatedByUserCode = CreatedByUserCode
                Me.CreatedDate = CreatedDate
                Me.CompletedDate = CompletedDate
                Me.IsActive = IsActive
                Me.BoardOwnerFullName = BoardOwnerFullName

            End Sub

#End Region

        End Class
        <Serializable()> Public Class CardEditResult

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

            Public Property Comments As IEnumerable
            Public Property Employees As IEnumerable
            Public Property Statuses As IEnumerable
            Public Property WeeklyHours As IEnumerable
            Public Property States As IEnumerable

            Public Property MyPictureSrc As String = String.Empty
            Public Property HoursAllowed As Decimal = 0.0
            Public Property CommentCount As Integer = 0

            Public Property SelectedStateID As Integer = 0
            Public Property SelectedType As Integer = 0
            Public Property SelectedPriority As Integer = 3
            Public Property NumberOfWeeks As Integer = 0

            Public Property AssigneeEmployeeCode As String = String.Empty


#End Region

#Region " Methods "

            Sub New()

            End Sub

#End Region

        End Class
        <Serializable()> Public Class CardNewResult

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

            Public Property Employees As IEnumerable
            Public Property Statuses As IEnumerable
            Public Property Tasks As IEnumerable
            Public Property Versions As IEnumerable
            Public Property Builds As IEnumerable

#End Region

#Region " Methods "

            Sub New()

            End Sub

#End Region

        End Class
        <Serializable()> Public Class EmployeeHoursResult

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

            Public Property TotalWorkingHoursForDuration As Decimal
            Public Property TotalHoursAvailable As Decimal
            Public Property TotalHoursUsed As Decimal

#End Region

#Region " Methods "

            Sub New()

            End Sub

#End Region

        End Class
        <Serializable()> Public Class SimpleEmployee

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

            Public Property EmployeeCode As String
            Public Property FullName As String
            Public Property EmployeePicture As Byte()
            Public Property EmployeePictureURL As String

#End Region

#Region " Methods "

            Sub New()

            End Sub

#End Region

        End Class
        <Serializable()> Public Class SimpleStatus

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

            Public Property ID As Integer
            Public Property Name As String

#End Region

#Region " Methods "

            Sub New()

            End Sub

#End Region

        End Class
        <Serializable()> Public Class SimpleTaskList

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

            Public Property JobNumber As Integer = 0
            Public Property JobComponentNumber As Short = 0
            Public Property TaskSequenceNumber As Short = -1
            Public Property FunctionCode As String = String.Empty
            Public Property Description As String = String.Empty

#End Region

#Region " Properties "



#End Region

#Region " Methods "

            Sub New()

            End Sub

#End Region

        End Class
        <Serializable()> Public Class SimpleWeeklyHours

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

            Public Property WeekStart As Date
            Public Property WeekEnd As Date
            Public Property WeekNumber As Integer
            Public Property Hours As Decimal

#End Region

#Region " Properties "



#End Region

#Region " Methods "

            Sub New()

            End Sub

#End Region

        End Class
        <Serializable()> Public Class BoardView

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

            Public Property Header As AdvantageFramework.Database.Entities.Board
            Public Property Sprints As New Generic.List(Of Webvantage.Controllers.ProjectManagement.AgileController.SimpleSprintHeader)
            Public Property Orphans As New Generic.List(Of Webvantage.Controllers.ProjectManagement.AgileController.SimpleOrphan)

#End Region

#Region " Methods "

            Sub New()

            End Sub

#End Region

        End Class
        <Serializable()>
        Public Class SimpleSprintHeader

#Region " Constants "



#End Region

#Region " Enum "

            Public Enum Properties

                ID
                Description
                Comment
                BoardID
                SequenceNumber
                StartDate
                StartWeekNumber
                NumberOfWeeks
                IsActive
                IsComplete
                CreateUser
                CreateDate

                SprintDetails

            End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

            Public Property ID As Integer
            Public Property Description As String
            Public Property Comments As String
            Public Property BoardID As Integer?
            Public Property SequenceNumber As Short?
            Public Property StartDate As DateTime?
            Public Property StartWeekNumber As Integer?
            Public Property NumberOfWeeks As Integer?
            Public Property CreatedByUserCode As String
            Public Property CreatedDate As DateTime?
            Public Property IsActive As Boolean?
            Public Property IsComplete As Boolean?
            Public Property StartDateAsString As String
            Public Property ItemCount As Integer?

#End Region

#Region " Methods "

            Sub New()

            End Sub

#End Region

        End Class
        <Serializable()>
        Public Class SimpleOrphan

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

            Public Property SprintDetailID As Integer
            Public Property AlertID As Integer
            Public Property Description As String

#End Region

#Region " Methods "

            Sub New()

            End Sub

#End Region

        End Class
        <Serializable()>
        Public Class DataResult

            Public Property result As IEnumerable
            Public Property count As Integer

            Sub New()

            End Sub

        End Class
        <Serializable()>
        Public Class AddJobToBoardUpdate
            Public Property BoardID As Integer = 0
            Public Property IsChecked As Boolean = False
            Sub New()

            End Sub
        End Class

#End Region

    End Class

End Namespace
