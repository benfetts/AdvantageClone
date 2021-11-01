Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports AdvantageFramework.Database.Entities
Imports Kendo.Mvc.Extensions
Imports Newtonsoft.Json
Imports Webvantage.ViewModels

Namespace Controllers.Utilities

    Public Class ApplicationActionsController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Utilities/ApplicationActions/"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        <AcceptVerbs("POST")>
        Public Function SortTaskCard(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TaskSequenceNumber As Short,
                                        ByVal EventTaskID As Integer, ByVal NewPosition As Integer) As String

            Dim UserCode As String = SecuritySession.UserCode
            Dim EmployeeCode As String = CurrentEmployeeCode
            Dim ConnectionString As String = SecuritySession.ConnectionString

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_card_user_sort_tasks] '{0}', '{1}', {2}, {3}, {4}, {5}, {6}, 0;",
                                                     UserCode, EmployeeCode, JobNumber, JobComponentNumber, TaskSequenceNumber, EventTaskID, NewPosition))

                End Using

                Return ""

            Catch ex As Exception

                Return ex.Message.ToString()

            End Try

        End Function
        <AcceptVerbs("POST")>
        Public Function SortTaskList(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TaskSequenceNumber As Short,
                                                  ByVal EventTaskID As Integer, ByVal NewPosition As Integer, ByVal EmployeeCode As String) As String

            Dim UserCode As String = SecuritySession.UserCode
            Dim ConnectionString As String = SecuritySession.ConnectionString

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_card_user_sort_tasks] '{0}', '{1}', {2}, {3}, {4}, {5}, {6}, 0;",
                                           UserCode, EmployeeCode, JobNumber, JobComponentNumber, TaskSequenceNumber, EventTaskID, NewPosition))

                End Using

                Return ""

            Catch ex As Exception

                Return ex.Message.ToString()

            End Try

        End Function

        <AcceptVerbs("POST")>
        Public Function SortAlertAssignmentCard(ByVal AlertId As Integer, ByVal NewPosition As Integer) As String

            Dim UserCode As String = SecuritySession.UserCode
            Dim EmployeeCode As String = CurrentEmployeeCode
            Dim ConnectionString As String = SecuritySession.ConnectionString

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_card_user_sort_alerts] '{0}', {1}, {2};",
                                                     EmployeeCode, AlertId, NewPosition))

                End Using

                Return ""

            Catch ex As Exception

                Return ex.Message.ToString()

            End Try

        End Function
        <AcceptVerbs("POST")>
        Public Function SortAlertAssignmentList(ByVal AlertId As Integer, ByVal NewPosition As Integer, ByVal EmployeeCode As String) As String

            Dim UserCode As String = SecuritySession.UserCode
            Dim ConnectionString As String = SecuritySession.ConnectionString

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_card_user_sort_alerts] '{0}', {1}, {2};",
                                                     EmployeeCode, AlertId, NewPosition))

                End Using

                Return ""

            Catch ex As Exception

                Return ex.Message.ToString()

            End Try

        End Function

        <AcceptVerbs("POST")>
        Public Function UpdateAlertAssignmentTaskCount() As JsonResult

            Dim ReturnObject As Object = Nothing

            Try

                Dim AssignmentCount As Integer = 0
                Dim AlertCount As Integer = 0
                Dim ReviewCount As Integer = 0
                Dim TaskCount As Integer = 0

                AssignmentCount = UpdateAssignmentCount()
                AlertCount = UpdateAlertCount()
                ReviewCount = UpdateReviewCount()
                TaskCount = UpdateTaskCount()

                ReturnObject = New With {.AssignmentCount = AssignmentCount,
                                         .AlertCount = AlertCount,
                                         .ReviewCount = ReviewCount,
                                         .TaskCount = TaskCount}

            Catch ex As Exception
                ReturnObject = Nothing
            End Try

            If ReturnObject Is Nothing Then ReturnObject = False

            Return Json(ReturnObject)

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateAssignmentCount() As Integer

            Dim a As New cAlerts()
            Dim AssignmentCount As Integer = 0

            Try

                If SecuritySession.Application = AdvantageFramework.Security.Methods.Application.Webvantage = True OrElse MiscFN.IsClientPortal = False Then

                    'a.LoadAlerts(CurrentEmployeeCode, "inbox", "", "", "", "", "", "", "", 0, 0, 0, 0, "", "", "", "", 0, 0, "", "", 0, "myalertassignments",
                    '             0, "", False, False, 0, "", "", "", "", 0, 0, True, AssignmentCount, False, False, "")

                End If

            Catch ex As Exception
                AssignmentCount = -1
            End Try

            Return AssignmentCount

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateAlertCount() As Integer

            Dim a As New cAlerts()
            Dim AlertCount As Integer = 0

            Try

                If SecuritySession.Application = AdvantageFramework.Security.Methods.Application.Client_Portal = True OrElse MiscFN.IsClientPortal = True Then

                    If SecuritySession.ClientPortalUser IsNot Nothing Then

                        a.LoadAlertsCP(SecuritySession.ClientPortalUser.ClientContactID, "inbox", "", "", "", "", "", "", "", 0, 0, 0, 0, "", "", "", "", 0, 0, "", "", "myalerts",
                                       0, "", False, False, 0, "", "", 0, True, AlertCount, False, "")

                    End If

                Else

                    'a.LoadAlerts(CurrentEmployeeCode, "inbox", "", "", "", "", "", "", "", 0, 0, 0, 0, "", "", "", "", 0, 0, "", "", 0, "myalerts",
                    '             0, "", False, False, 0, "", "", "", "", 0, 0, True, AlertCount, False, True, "")

                End If

            Catch ex As Exception
                AlertCount = -1
            End Try

            Return AlertCount

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateReviewCount() As Integer

            Dim a As New cAlerts()
            Dim ReviewCount As Integer = 0
            Try

                If cApplication.IsProofingToolActive(SecuritySession) = True Then

                    If SecuritySession.Application = AdvantageFramework.Security.Methods.Application.Client_Portal = True OrElse MiscFN.IsClientPortal = True Then

                        If SecuritySession.ClientPortalUser IsNot Nothing Then

                            a.LoadAlertsCP(SecuritySession.ClientPortalUser.ClientContactID, "inbox", "", "", "", "", "", "", "", 0, 0, 0, 0, "", "", "", "", 0, 0, "", "", "myreviews",
                                           0, "", False, False, 0, "", "", 0, True, ReviewCount, False, "")

                        End If


                    Else

                        'a.LoadAlerts(CurrentEmployeeCode, "inbox", "", "", "", "", "", "", "", 0, 0, 0, 0, "", "", "", "", 0, 0, "", "", 0, "myreviews",
                        '             0, "", False, False, 0, "", "", "", "", 0, 0, True, ReviewCount, False, False, "")

                    End If

                End If

            Catch ex As Exception
                ReviewCount = -1
            End Try

            Return ReviewCount

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateTaskCount() As Integer

            Try

                Dim TaskCount As Integer = 0
                Dim ClientContactID = 0
                Dim otask As cTasks = New cTasks(SecuritySession.ConnectionString)
                Dim oDO As cDesktopObjects = New cDesktopObjects(SecuritySession.ConnectionString)
                Dim dt As New DataTable
                Dim TaskType As String = ""
                Dim TaskShow As String = "All"
                Dim SearchValue As String = ""

                Try

                    TaskType = otask.getAppVars(SecuritySession.UserCode, "MyTasks", "ddType")

                Catch ex As Exception
                    TaskType = ""
                End Try

                Select Case (TaskType.ToUpper)
                    Case "PROJECTED"

                        TaskType = "P"

                    Case "ACTIVE"

                        TaskType = "A"

                    Case "H"

                        TaskType = "H"

                    Case "L"

                        TaskType = "L"

                    Case "EVENT_TASKS"

                        TaskType = "E"

                    Case "ALL"

                        TaskType = ""

                    Case Else

                        TaskType = ""

                End Select

                Try

                    TaskShow = otask.getAppVars(SecuritySession.UserCode, "MyTasks", "ddTaskShow")

                Catch ex As Exception
                    TaskShow = ""
                End Try

                If String.IsNullOrWhiteSpace(TaskShow) Then TaskShow = "All"

                Try

                    SearchValue = otask.getAppVars(SecuritySession.UserCode, "MyTasks", "sSearch")

                Catch ex As Exception
                    SearchValue = ""
                End Try

                Try

                    If SecuritySession.ClientPortalUser IsNot Nothing Then

                        ClientContactID = SecuritySession.ClientPortalUser.ClientContactID

                    End If

                Catch ex As Exception
                    ClientContactID = 0
                End Try
                Dim Sort As String = ""

                TaskCount = oDO.GetTasks(SecuritySession.UserCode, CStr(CurrentEmployeeCode), Today(), TaskType, TaskShow, SearchValue,
                                 MiscFN.IsClientPortal, ClientContactID, Sort).Rows.Count

                Return TaskCount

            Catch ex As Exception
                Return -1
            End Try

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateHoursCount() As JsonResult

            Dim ReturnObject As Object = Nothing

            Dim LegacyDesktopObjects As New cDesktopObjects(SecuritySession.ConnectionString)
            Dim LegacyTimesheetClass As Webvantage.wvTimeSheet.cTimeSheet = New Webvantage.wvTimeSheet.cTimeSheet(SecuritySession.ConnectionString)
            Dim TimesheetDataTable As New DataTable

            Dim HoursToday As Double = 0.0
            Dim HoursThisWeek As Double = 0.0
            Dim HasMissingOrDeniedTime As Boolean = False

            TimesheetDataTable = LegacyDesktopObjects.GetTimesheetDTO(CurrentEmployeeCode)

            If TimesheetDataTable IsNot Nothing Then

                Try

                    For i As Integer = 0 To TimesheetDataTable.Rows.Count - 1

                        If CType(TimesheetDataTable.Rows(i)("DayDisplay"), Date).ToShortDateString = cEmployee.TimeZoneToday.ToShortDateString Then

                            HoursToday = CType(TimesheetDataTable.Rows(i)("Hours"), Double)
                            Exit For

                        End If

                    Next

                    HoursThisWeek = TimesheetDataTable.Compute("Sum(Hours)", "")

                Catch ex As Exception
                End Try

            End If

            Try

                HasMissingOrDeniedTime = LegacyTimesheetClass.HasMissingOrDeniedTime()

            Catch ex As Exception
                HasMissingOrDeniedTime = False
            End Try

            HoursToday = FormatNumber(HoursToday, 2)
            HoursThisWeek = FormatNumber(HoursThisWeek, 2)

            ReturnObject = New With {.HoursToday = HoursToday,
                                     .HoursThisWeek = HoursThisWeek,
                                     .HasMissingOrDeniedTime = HasMissingOrDeniedTime}

            Return Json(ReturnObject)

        End Function
        <AcceptVerbs("POST")>
        Public Function CheckForBookmarks() As JsonResult

            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim UserBookmarks As Generic.List(Of AdvantageFramework.Web.Presentation.Bookmarks.Bookmark)
            Dim HasBookmarks As Boolean = False

            UserBookmarks = BmMethods.GetBookmarks(Session("UserCode"))

            If Not UserBookmarks Is Nothing Then

                HasBookmarks = UserBookmarks.Count > 0

            End If

            Return Json(HasBookmarks)

        End Function

        Public Function Index() As ActionResult

            Return View()

        End Function

#End Region

        <MvcCodeRouting.Web.Mvc.CustomRoute("~/SessionTimeout")>
        Public Function SessionTimeout() As ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New Webvantage.ViewModels.AureliaModel

            AureliaModel.App = "modules/utilities/session-timeout"

            Return Aurelia(AureliaModel)

        End Function

        <MvcCodeRouting.Web.Mvc.CustomRoute("~/App_SignIn")>
        Public Function AppSignIn() As ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New Webvantage.ViewModels.AureliaModel

            AureliaModel.App = "modules/utilities/sign-in"

            Return Aurelia(AureliaModel)

        End Function


    End Class

End Namespace
