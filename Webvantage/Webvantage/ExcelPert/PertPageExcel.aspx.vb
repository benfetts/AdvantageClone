Imports System.Text
Imports System.Collections.Generic

Partial Public Class PertPageExcel
    Inherits System.Web.UI.Page

    Private ClientCode As String = ""
    Private DivisionCode As String = ""
    Private ProductCode As String = ""
    Private JobNumber As Integer = 0
    Private JobCompNumber As Integer = 0
    Private EmpCode As String = ""
    Private ManagerCode As String = ""
    Private TaskCode As String = ""
    Private AccountExecCode As String = ""
    Private RoleCode As String = ""
    Private CutOffDate As String = ""
    Private IncludeCompletedTasks As Boolean = True
    Private IncludeOnlyPendingTasks As Boolean = False
    Private ExcludeProjectedTasks As Boolean = False
    Private IncludeCompletedSchedules As Boolean = True
    Private MilestonesOnly As Boolean = False
    Private TrafficStatusCode As String = ""

    Private UsingATaskLevelFilter As Boolean = False
    Private CampaignCode As String = ""
    Private TaskPhaseFilter As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetQSVars()
        Dim pp As New PertProject
        With pp
            .ClCode = Me.ClientCode
            .DivCode = Me.DivisionCode
            .PrdCode = Me.ProductCode
            .JobNumber = Me.JobNumber
            .JobComponentNbr = Me.JobCompNumber
            .EmpCode = Me.EmpCode
            .ManagerCode = Me.ManagerCode
            .TaskCode = Me.TaskCode
            .AccountExecCode = Me.AccountExecCode
            .RoleCode = Me.RoleCode
            .CutOffDate = Me.CutOffDate
            .IncludeCompletedTasks = Me.IncludeCompletedTasks
            .IncludeOnlyPendingTasks = Me.IncludeOnlyPendingTasks
            .ExcludeProjectedTasks = Me.ExcludeProjectedTasks
            .IncludeCompletedSchedules = Me.IncludeCompletedSchedules
            .CampaignCode = Me.CampaignCode
            .TaskPhaseFilter = Me.TaskPhaseFilter
            .MilestonesOnly = Me.MilestonesOnly
            .TrafficStatusCode = Me.TrafficStatusCode
            PertLabel.Text = .GetAll()
        End With
        With Response
            .Clear()
            .Buffer = True
            .ContentType = "application/vnd.ms-excel"
            .AddHeader("content-disposition", "attachment;filename=ProjectPert.xls")
            .Charset = ""
        End With
        Me.EnableViewState = False
    End Sub

    Private Sub SetQSVars()
        If Not Request.QueryString("c") = Nothing Then
            Me.ClientCode = Request.QueryString("c").ToString()
        End If
        If Not Request.QueryString("d") = Nothing Then
            Me.DivisionCode = Request.QueryString("d").ToString()
        End If
        If Not Request.QueryString("p") = Nothing Then
            Me.ProductCode = Request.QueryString("p").ToString()
        End If
        If Not Request.QueryString("j") = Nothing Then
            Me.JobNumber = CType(Request.QueryString("j").ToString(), Integer)
        End If
        If Not Request.QueryString("jc") = Nothing Then
            Me.JobCompNumber = CType(Request.QueryString("jc").ToString(), Integer)
        End If
        If Not Request.QueryString("mgr") = Nothing Then
            Me.ManagerCode = Request.QueryString("mgr").ToString()
        End If
        If Not Request.QueryString("ae") = Nothing Then
            Me.AccountExecCode = Request.QueryString("ae").ToString()
        End If
        If Not Request.QueryString("ics") = Nothing Then
            Me.IncludeCompletedSchedules = CType(Request.QueryString("ics").ToString(), Boolean)
        End If
        If Not Request.QueryString("emp") = Nothing Then
            Me.EmpCode = Request.QueryString("emp").ToString()
            If Me.EmpCode.Trim <> "" Then
                Me.UsingATaskLevelFilter = True
            End If
        End If
        If Not Request.QueryString("tsk") = Nothing Then
            Me.TaskCode = Request.QueryString("tsk").ToString()
            If Me.TaskCode.Trim <> "" Then
                Me.UsingATaskLevelFilter = True
            End If
        End If
        If Not Request.QueryString("rl") = Nothing Then
            Me.RoleCode = Request.QueryString("rl").ToString()
            If Me.RoleCode.Trim <> "" Then
                Me.UsingATaskLevelFilter = True
            End If
        End If
        If Not Request.QueryString("cod") = Nothing Then
            Me.CutOffDate = Request.QueryString("cod").ToString()
            If Me.CutOffDate.Trim <> "" Then
                Me.UsingATaskLevelFilter = True
            End If
        End If
        If Not Request.QueryString("ict") = Nothing Then
            Me.IncludeCompletedTasks = CType(Request.QueryString("ict").ToString(), Boolean)
            If Me.IncludeCompletedTasks = True Then
                Me.UsingATaskLevelFilter = True
            End If
        End If
        If Not Request.QueryString("pnd") = Nothing Then
            Me.IncludeOnlyPendingTasks = CType(Request.QueryString("pnd").ToString(), Boolean)
            If Me.IncludeOnlyPendingTasks = True Then
                Me.UsingATaskLevelFilter = True
            End If
        End If
        If Not Request.QueryString("prj") = Nothing Then
            Me.ExcludeProjectedTasks = CType(Request.QueryString("prj").ToString(), Boolean)
            If Me.ExcludeProjectedTasks = True Then
                Me.UsingATaskLevelFilter = True
            End If
        End If
        If Not Request.QueryString("ci") = Nothing Then
            Me.CampaignCode = Request.QueryString("ci").ToString()
        End If
        If Not Request.QueryString("pf") = Nothing Then
            Me.TaskPhaseFilter = Request.QueryString("pf").ToString()
        End If
        If Not Request.QueryString("mso") = Nothing Then
            Me.MilestonesOnly = CType(Request.QueryString("mso").ToString(), Boolean)
        End If
        If Not Request.QueryString("ts") = Nothing Then
            Me.TrafficStatusCode = Request.QueryString("ts").ToString()
        End If

    End Sub

    Public Function RendorMultiJobPSExcel(ByVal client As String, ByVal division As String, ByVal product As String, ByVal job As Integer, ByVal comp As Integer, _
                                          ByVal empcode As String, ByVal manager As String, ByVal task As String, ByVal acctexec As String, ByVal role As String, _
                                          ByVal cutoffdate As String, ByVal includeCompTasks As Boolean, ByVal includeOnlyPending As Boolean, ByVal excludeProjected As Boolean, _
                                          ByVal includecompleted As Boolean, ByVal campaign As String, ByVal phasefilter As String, ByVal milestone As Boolean, ByVal status As String)
        Try
            'Me.SetQSVars()
            Dim strExcel As String
            Dim pp As New PertProject
            With pp
                .ClCode = client
                .DivCode = division
                .PrdCode = product
                .JobNumber = job
                .JobComponentNbr = comp
                .EmpCode = empcode
                .ManagerCode = manager
                .TaskCode = task
                .AccountExecCode = acctexec
                .RoleCode = role
                .CutOffDate = cutoffdate
                .IncludeCompletedTasks = includeCompTasks
                .IncludeOnlyPendingTasks = includeOnlyPending
                .ExcludeProjectedTasks = excludeProjected
                .IncludeCompletedSchedules = includecompleted
                .CampaignCode = campaign
                .TaskPhaseFilter = phasefilter
                .MilestonesOnly = milestone
                .TrafficStatusCode = status
                strExcel = .GetAll(1)
            End With
            Return strExcel
        Catch ex As Exception

        End Try
    End Function



End Class