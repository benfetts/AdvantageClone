Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Partial Public Class taskComments
    Inherits Webvantage.BaseChildPage
    Public JobNumber As Integer = 0
    Public JobCompNumber As Integer = 0
    Public SeqNum As Integer = 0
    Public EmpCode As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        If Not Me.IsPostBack Then
            'Dim CancelScript As String = "javascript:CallFunctionOnParentPage('HidePopUpWindows');return false;"
            Me.JobNumber = Request.QueryString("JobNo")
            Me.JobCompNumber = Request.QueryString("JobComp")
            Me.SeqNum = Request.QueryString("SeqNo")
            Me.EmpCode = Request.QueryString("EmplCode")

            If Me.EmpCode = "" Then
                Me.EmpCode = Session("EmpCode")
            End If

            Dim t As New cTasks(Session("ConnString"))
            Me.TextAreaComment.Value = t.GetTaskComment(Me.JobNumber, Me.JobCompNumber, Me.SeqNum, Me.EmpCode)

            Try
                Dim dr As SqlDataReader
                Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
                'dr = oTasks.GetTask(Me.JobNumber, Me.JobCompNumber, Me.SeqNum, Session("EmpCode"))
                dr = oTasks.GetTask(Me.JobNumber, Me.JobCompNumber, Me.SeqNum, Me.EmpCode)
                Do While dr.Read
                    If IsDBNull(dr(12)) = False AndAlso IsDate(dr(12)) = True Then
                        Me.chkMarkNotCompleted.Visible = True
                        Me.chkMarkCompleted.Visible = False
                        Me.chkMarkCompleted.Checked = False
                    Else
                        Me.chkMarkCompleted.Visible = True
                        Me.chkMarkCompleted.Checked = True
                        Me.chkMarkNotCompleted.Visible = False
                        Me.chkMarkNotCompleted.Checked = False
                    End If
                Loop
                dr.Close()
            Catch ex As Exception
                Me.chkMarkCompleted.Visible = True
                Me.chkMarkCompleted.Checked = True
                Me.chkMarkNotCompleted.Visible = False
                Me.chkMarkNotCompleted.Checked = False
            End Try
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            Me.JobNumber = Request.QueryString("JobNo")
            Me.JobCompNumber = Request.QueryString("JobComp")
            Me.SeqNum = Request.QueryString("SeqNo")

            Me.EmpCode = Request.QueryString("EmplCode")

            If Me.EmpCode = "" Then
                Me.EmpCode = Session("EmpCode")
            End If
            'Dim oTask As New JOB_TRAFFIC_DET(Session("ConnString"))
            'If oTask.LoadByPrimaryKey(Me.JobCompNumber, Me.JobNumber, Me.SeqNum) Then
            '    With oTask
            '        .COMPLETED_COMMENTS = Me.txtComments.Text
            '        .Save()
            '    End With
            'End If
            Dim t As New cTasks(Session("ConnString"))
            't.SaveTaskComment(Me.JobNumber, Me.JobCompNumber, Me.SeqNum, Session("EmpCode"), Me.txtComments.Text)
            t.SaveTaskComment(Me.JobNumber, Me.JobCompNumber, Me.SeqNum, Me.EmpCode, Me.TextAreaComment.Value)

            'If Me.chkMarkCompleted.Checked = True Then
            '    Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
            '    'If oTasks.MarkCompleted(Me.JobNumber, Me.JobCompNumber, Me.SeqNum, Session("EmpCode"), Today.Date) = False Then
            '    If oTasks.MarkCompleted(Me.JobNumber, Me.JobCompNumber, Me.SeqNum, Me.EmpCode, Today.Date) = False Then
            '        Me.ShowMessage("Mark Completed Failed!")
            '        Exit Sub
            '    End If
            'End If

            'If Me.chkMarkNotCompleted.Checked = True Then
            '    Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
            '    If oTasks.MarkNotCompleted(Me.JobNumber, Me.JobCompNumber, Me.SeqNum, Me.EmpCode) = False Then
            '        Me.ShowMessage("Mark Not Completed Failed!")
            '        Exit Sub
            '    End If
            'End If
            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using sc As New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If Me.chkMarkCompleted.Checked = True Then

                        AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, sc, Me.JobNumber, Me.JobCompNumber, SeqNum, Me.EmpCode, CType(Now, DateTime))

                    ElseIf Me.chkMarkNotCompleted.Checked = True Then

                        AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, sc, Me.JobNumber, Me.JobCompNumber, SeqNum, Me.EmpCode, Nothing)

                    End If

                End Using

            End Using


            'If Session("TimesheetTaskComments") = "1" Then
            '    Session("TimesheetTaskComments") = ""
            '    Session("TimesheetTask") = "1"
            'Else
            '    Session("TimesheetTask") = ""
            'End If

            'If Session("TimesheetTask") <> "1" Then
            '    Dim cScript As String
            '    cScript = "<script language='javascript'> window.opener.location=window.opener.location; </script>"
            '    RegisterStartupScript("parentwindow", cScript)
            'End If

            'Dim cScript2 As String
            'cScript2 = "<script>window.close();</script>"
            'RegisterStartupScript("page58", cScript2)

            Try
                If Me.CallingPage = "task.aspx" Then
                    Me.CloseThisWindowAndRefreshCaller(Me.CallingPage)
                Else
                    Me.CloseThisWindow()
                End If
            Catch ex As Exception
                Me.CloseThisWindow()
            End Try

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Me.CloseThisWindow()
    End Sub

End Class
