Imports Webvantage.wvTimeSheet
Imports System.Data.SqlClient

Partial Public Class MobileTaskDetail
    Inherits MobileBase
    Dim JobNo As Integer
    Dim JobComp As Integer
    Dim SeqNo As Integer
    Dim EmpCode As String = ""
    Dim type As String
    Public comments As String
    Protected PageTitle As System.Web.UI.HtmlControls.HtmlGenericControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            LoadTask()
            Me.comments = Request.QueryString("Comments")
        End If
    End Sub
    Private Sub lbBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        MiscFN.ResponseRedirect("~/mobile/MobileTasks.aspx")
    End Sub
    Private Sub lbLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Me.SignOut()
    End Sub

    Private Sub lbComments_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbComments.Click
        JobNo = CInt(Request.Params("JobNo"))
        JobComp = CInt(Request.Params("JobComp"))
        SeqNo = CInt(Request.Params("SeqNo"))
        EmpCode = Request.QueryString("EmpCode")
        If Request.QueryString("FromPage") = "TimesheetCopyFrom" Then
            Session("TimesheetTaskComments") = "1"
        End If
        MiscFN.ResponseRedirect("MobileTaskComments.aspx?JobNo=" & JobNo & "&JobComp=" & JobComp & "&SeqNo=" & SeqNo & "&Comments=1" & "&EmplCode=" & EmpCode)
    End Sub
    Private Sub lbMarkNotCompleted_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbMarkNotCompleted.Click
        JobNo = CInt(Request.Params("JobNo"))
        JobComp = CInt(Request.Params("JobComp"))
        SeqNo = CInt(Request.Params("SeqNo"))
        EmpCode = Request.QueryString("EmpCode")

        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))

        'If oTasks.MarkNotCompleted(JobNo, JobComp, SeqNo, EmpCode) = True Then
        '    Me.lbMarkCompleted.Visible = True
        '    Me.lbMarkNotCompleted.Visible = False
        'End If
        Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using sc As New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, sc, JobNo, JobComp, SeqNo, EmpCode, Nothing) = True Then

                    Me.lbMarkCompleted.Visible = True
                    Me.lbMarkNotCompleted.Visible = False

                End If

            End Using

        End Using

        dlTask.DataSource = oTasks.GetTask(JobNo, JobComp, SeqNo, EmpCode)
        dlTask.DataBind()

        If Request.QueryString("FromPage") = "TimesheetCopyFrom" Then
            Session("TimesheetTask") = "1"
        Else
            Session("TimesheetTask") = ""
        End If

        MiscFN.ResponseRedirect("~/Mobile/MobileTasks.aspx")

    End Sub
    Private Sub lbAddTime_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbAddTime.Click
        JobNo = CInt(Request.Params("JobNo"))
        JobComp = CInt(Request.Params("JobComp"))
        SeqNo = CInt(Request.Params("SeqNo"))
        EmpCode = Request.QueryString("EmpCode")
        If Request.QueryString("FromPage") = "TimesheetCopyFrom" Then
            Session("TimesheetTaskQuickAdd") = "1"
        End If
        MiscFN.ResponseRedirect("~/Mobile/MobileTimesheetQA.aspx?JobNum=" & JobNo & "&JobComp=" & JobComp & "&Seq=" & SeqNo & "&TaskEmp=" & EmpCode)
    End Sub
    Private Sub lblMarkCompleted_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbMarkCompleted.Click
        JobNo = CInt(Request.Params("JobNo"))
        JobComp = CInt(Request.Params("JobComp"))
        SeqNo = CInt(Request.Params("SeqNo"))
        EmpCode = Request.QueryString("EmpCode")

        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))

        'If oTasks.MarkCompleted(JobNo, JobComp, SeqNo, EmpCode, Today.Date) = True Then
        '    Me.lbMarkCompleted.Visible = False
        '    Me.lbMarkNotCompleted.Visible = True
        'End If
        Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using sc As New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, sc, JobNo, JobComp, SeqNo, EmpCode, CType(Now, DateTime)) = True Then

                    Me.lbMarkCompleted.Visible = False
                    Me.lbMarkNotCompleted.Visible = True

                End If

            End Using

        End Using

        dlTask.DataSource = oTasks.GetTask(JobNo, JobComp, SeqNo, EmpCode)
        dlTask.DataBind()

        If Request.QueryString("FromPage") = "TimesheetCopyFrom" Then
            Session("TimesheetTask") = "1"
        Else
            Session("TimesheetTask") = ""
        End If
        MiscFN.ResponseRedirect("~/Mobile/MobileTasks.aspx")
    End Sub
    Private Sub LoadTask()
        JobNo = CInt(Request.Params("JobNo"))
        JobComp = CInt(Request.Params("JobComp"))
        SeqNo = CInt(Request.Params("SeqNo"))
        EmpCode = Request.QueryString("EmpCode")

        type = Request.QueryString("type")

        If EmpCode = "" Or type = "timeline" Then
            Me.lbMarkCompleted.Enabled = False
            Me.lbMarkNotCompleted.Enabled = False
            Me.lbComments.Enabled = False
            Me.lbAddTime.Enabled = False
            Me.lbMarkNotCompleted.Visible = False
        End If

        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))

        Try

            Dim IsTempComplete As Boolean = False
            Dim TempCompleteDate As Date
            Dim IDontKnowWhyTheTableIsLikeThis As New Date(1900, 1, 1)
            Dim dr As SqlDataReader

            dr = oTasks.GetTask(JobNo, JobComp, SeqNo, Me.EmpCode)

            Do While dr.Read

                If IsDate(dr.GetValue(dr.GetOrdinal("TempCompDate"))) = True Then

                    TempCompleteDate = dr.GetValue(dr.GetOrdinal("TempCompDate"))

                    If TempCompleteDate > IDontKnowWhyTheTableIsLikeThis Then

                        IsTempComplete = True
                        Exit Do

                    End If

                End If

            Loop

            dr.Close()

            Me.lbMarkNotCompleted.Visible = IsTempComplete
            Me.lbMarkCompleted.Visible = Not IsTempComplete

        Catch ex As Exception

            Response.Write(ex.Message.ToString())

            Me.lbMarkCompleted.Visible = False
            Me.lbMarkNotCompleted.Visible = False

        End Try

        If EmpCode.Trim = "..." Then

            EmpCode = ""

        End If

        dlTask.DataSource = oTasks.GetTask(JobNo, JobComp, SeqNo, EmpCode)
        dlTask.DataBind()

        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Me.lbAddTime.Enabled = myVal.ValidateJobIsOpen(JobNo, JobComp)

        If Me.lbAddTime.Enabled = True Then
            Me.lbAddTime.Enabled = myVal.ValidateJobCompIsEditable(JobNo, JobComp)
        End If
        If Me.lbAddTime.Enabled = True Then
            Me.lbAddTime.Enabled = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_Timesheet, False))
        End If
        If Me.lbAddTime.Enabled = True Then
            Dim ots As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
            If ots.UserLimited(Session("UserCode")) = True Then
                If Session("EmpCode").ToString.Trim <> EmpCode.Trim Then
                    Me.lbAddTime.Enabled = False
                End If
            End If
        End If
        If EmpCode = "" Then
            Me.lbAddTime.Enabled = False
        End If
    End Sub

    Public Function ShowTaskStatus(ByVal TaskStatus As String) As String
        Select Case TaskStatus.ToUpper
            Case "P"
                Return "Projected"
            Case "A"
                Return "Active"
            Case Else
                Return "Projected"
        End Select
    End Function

End Class
