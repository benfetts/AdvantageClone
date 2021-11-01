Public Class AngularGantt
    Inherits Webvantage.BaseChildPage

    Public JobNumber As Integer = 0
    Public JobComponentNumber As Integer = 0
    Public ReadJobsFromSession As Boolean = False


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim JobCompArray As String() = Nothing
        Dim JobCompPairList As String() = Nothing
        Dim ParseResult As Integer = 0

        If IsNumeric(Request.QueryString("JobNum")) AndAlso Integer.TryParse(Request.QueryString("JobNum"), ParseResult) Then
            Me.JobNumber = ParseResult
        End If

        If IsNumeric(Request.QueryString("JobComp")) AndAlso Integer.TryParse(Request.QueryString("JobComp"), ParseResult) Then
            Me.JobComponentNumber = ParseResult
        End If

        If IsNumeric(Request.QueryString("j")) AndAlso Integer.TryParse(Request.QueryString("j"), ParseResult) Then
            Me.JobNumber = ParseResult
        End If

        If IsNumeric(Request.QueryString("jc")) AndAlso Integer.TryParse(Request.QueryString("jc"), ParseResult) Then
            Me.JobComponentNumber = ParseResult
        End If

        If Request.QueryString("jcs") <> "" Then
            Session("TrafficScheduleMVJobs") = Request.QueryString("jcs")
        End If

        If Request.QueryString("from") IsNot Nothing Then
            Me.ReadJobsFromSession = Not Request.QueryString("from") = "ps"
        End If

        HiddenFieldCalledFrom.Value = Request.QueryString("from")

        If Me.ReadJobsFromSession Then

            JobCompArray = Session("TrafficScheduleMVJobs").ToString.Split("|").Where(Function(JobComp) Not [String].IsNullOrWhiteSpace(JobComp)).ToArray

        Else

            JobCompArray = {Me.JobNumber.ToString & "," & Me.JobComponentNumber.ToString}

        End If

        Dim jcs As String
        For Each jc In JobCompArray

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If jc <> "" Then
                    Dim job() As String = jc.Split(",")
                    If AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumber(DbContext, job(0), job(1)).Count() > 0 Then
                        jcs += job(0) & "," & job(1) & "|"
                    End If
                End If

            End Using

        Next

        JobCompArray = jcs.Split("|").Where(Function(JobComp) Not [String].IsNullOrWhiteSpace(JobComp)).ToArray

        JobCompPairList = (From JobComp In JobCompArray _
                           Select [JobNum] = JobComp.Split(",")(0), _
                                  [JobCompNum] = JobComp.Split(",")(1)).Select(Function(JobComp) [String].Format("{{ JobNumber: {0}, JobComponentNumber: {1}, JobDescription: '', IsRelatedJob: false }}", JobComp.JobNum, JobComp.JobCompNum)).ToArray

        Me.MyUnityContextMenu.JobNumber = Me.JobNumber
        Me.MyUnityContextMenu.JobComponentNumber = Me.JobComponentNumber

        Dim templateStringBuilder As New System.Text.StringBuilder()

        templateStringBuilder.AppendLine("$(document).ready(function () {{")
        templateStringBuilder.AppendLine("var ganttScope = angular.element($('#content')).scope();")
        templateStringBuilder.AppendLine("ganttScope.InitialJobComponentPairs = [" & [String].Join(",", JobCompPairList) & "];")
        templateStringBuilder.AppendLine("ganttScope.$apply();")
        templateStringBuilder.AppendLine("ganttScope.init();")
        templateStringBuilder.AppendLine("}});")

        Page.ClientScript.RegisterStartupScript(Me.GetType(), "InitializeJobInfo", templateStringBuilder.ToString(), True)
        Me.Title = "Gantt"
        Session("TrafficScheduleMVJobs") = ""
    End Sub

End Class
