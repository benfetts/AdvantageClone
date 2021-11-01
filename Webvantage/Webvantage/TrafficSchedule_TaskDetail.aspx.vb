Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Webvantage.wvTimeSheet
Imports eWorld
Imports System.Text
Imports System.Drawing
Imports AdvantageFramework.AlertSystem.Classes
Imports Telerik.Web.UI

Public Class TrafficSchedule_TaskDetail
    Inherits Webvantage.BaseChildPage

#Region " Constants "


#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private JobNumber As Integer = 0
    Private JobComponentNumber As Integer = 0
    Private SequenceNumber As Integer = -1
    Private AlertID As Integer = 0
    Private SprintID As Integer = 0

#End Region

#Region " Properties "


#End Region

#Region " Methods "

#Region " Page Methods "

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        'Any new pages in Aurelia or MVC that need to point to a task detail should go directly to Desktop_AlertView by the AlertID!
        'Do not link to this page any more!!!!!

        If Request.QueryString("AlertID") IsNot Nothing Then Me.AlertID = Request.QueryString("AlertID")

        If Request.QueryString("JobNum") IsNot Nothing Then Me.JobNumber = Request.QueryString("JobNum")
        If Request.QueryString("JobComp") IsNot Nothing Then Me.JobComponentNumber = Request.QueryString("JobComp")
        If Request.QueryString("SeqNum") IsNot Nothing Then Me.SequenceNumber = Request.QueryString("SeqNum")

        If Request.QueryString("JobNumber") IsNot Nothing Then Me.JobNumber = Request.QueryString("JobNumber")
        If Request.QueryString("JobComponentNumber") IsNot Nothing Then Me.JobComponentNumber = Request.QueryString("JobComponentNumber")
        If Request.QueryString("SequenceNumber") IsNot Nothing Then Me.SequenceNumber = Request.QueryString("SequenceNumber")
        If Request.QueryString("TaskSequenceNumber") IsNot Nothing Then Me.SequenceNumber = Request.QueryString("TaskSequenceNumber")

        'Clean up old querystring names by letting clean qs class override
        If Me.CurrentQuerystring.JobNumber > 0 Then Me.JobNumber = Me.CurrentQuerystring.JobNumber
        If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.JobComponentNumber = Me.CurrentQuerystring.JobComponentNumber
        If Me.CurrentQuerystring.TaskSequenceNumber > 0 Then Me.SequenceNumber = Me.CurrentQuerystring.TaskSequenceNumber

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    AlertID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT TOP 1 ALERT_ID FROM ALERT WHERE (ALERT_LEVEL = 'BRD' OR ALERT_CAT_ID = 71) AND JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND TASK_SEQ_NBR = {2};",
                                                                                     Me.JobNumber, Me.JobComponentNumber, Me.SequenceNumber)).SingleOrDefault

                Catch ex As Exception
                    AlertID = 0
                End Try

                If AlertID = 0 Then

                    Try

                        AlertID = DbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC [dbo].[advsp_agile_add_assignment_from_task] {0}, {1}, {2}, '{3}';",
                                                                                         Me.JobNumber, Me.JobComponentNumber, Me.SequenceNumber, Me.SecuritySession.UserCode)).SingleOrDefault

                    Catch ex As Exception
                        AlertID = 0
                    End Try

                End If

                If AlertID > 0 Then

                    Try

                        SprintID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT TOP 1 SPRINT_HDR_ID FROM SPRINT_DTL WHERE ALERT_ID = {0} ORDER BY SPRINT_HDR_ID DESC;", AlertID)).SingleOrDefault

                    Catch ex As Exception
                        SprintID = 0
                    End Try

                    Dim QsViewDetails As New AdvantageFramework.Web.QueryString

                    QsViewDetails.Page = "Desktop_AlertView"
                    QsViewDetails.Add("AlertID", AlertID.ToString)
                    QsViewDetails.Add("SprintID", SprintID.ToString)

                    MiscFN.ResponseRedirect(QsViewDetails.ToString(True), True)

                End If

            End Using

        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region " Event Handlers "

#End Region

#End Region

End Class
