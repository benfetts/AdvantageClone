Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports System.Data.SqlClient

Partial Public Class MobileTaskComments
    Inherits MobileBase
    Public JobNumber As Integer = 0
    Public JobCompNumber As Integer = 0
    Public SeqNum As Integer = 0
    Public EmpCode As String



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.JobNumber = Request.QueryString("JobNo")
            Me.JobCompNumber = Request.QueryString("JobComp")
            Me.SeqNum = Request.QueryString("SeqNo")
            Me.EmpCode = Request.QueryString("EmplCode")

            If Me.EmpCode = "" Then
                Me.EmpCode = Session("EmpCode")
            End If

        
            Dim t As New cTasks(Session("ConnString"))
            Me.txtComments.Text = t.GetTaskComment(Me.JobNumber, Me.JobCompNumber, Me.SeqNum, Me.EmpCode)

            Try
                Dim IsTempComplete As Boolean = False
                Dim TempCompleteDate As Date
                Dim IDontKnowWhyTheTableIsLikeThis As New Date(1900, 1, 1)

                Dim dr As SqlDataReader
                Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
                dr = oTasks.GetTask(Me.JobNumber, Me.JobCompNumber, Me.SeqNum, Me.EmpCode)
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

                If IsTempComplete = True Then

                    Me.chkMarkNotCompleted.Visible = True
                    Me.chkMarkCompleted.Visible = False
                    Me.chkMarkCompleted.Checked = False

                Else

                    Me.chkMarkCompleted.Visible = True
                    Me.chkMarkCompleted.Checked = True
                    Me.chkMarkNotCompleted.Visible = False
                    Me.chkMarkNotCompleted.Checked = False

                End If

            Catch ex As Exception

                Response.Write(ex.Message.ToString())

                Me.chkMarkCompleted.Visible = False
                Me.chkMarkCompleted.Checked = False
                Me.chkMarkNotCompleted.Visible = False
                Me.chkMarkNotCompleted.Checked = False

            End Try

        End If
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            Me.JobNumber = Request.QueryString("JobNo")
            Me.JobCompNumber = Request.QueryString("JobComp")
            Me.SeqNum = Request.QueryString("SeqNo")

            Me.EmpCode = Request.QueryString("EmplCode")

            If Me.EmpCode = "" Then
                Me.EmpCode = Session("EmpCode")
            End If
            
            Dim t As New cTasks(Session("ConnString"))

            t.SaveTaskComment(Me.JobNumber, Me.JobCompNumber, Me.SeqNum, Me.EmpCode, Me.txtComments.Text)

            'If Me.chkMarkCompleted.Checked = True Then
            '    Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))

            '    If oTasks.MarkCompleted(Me.JobNumber, Me.JobCompNumber, Me.SeqNum, Me.EmpCode, Today.Date) = False Then
            '        Me.lblMsg1.Text = "Mark Completed Failed!"
            '        Exit Sub
            '    End If
            'End If

            'If Me.chkMarkNotCompleted.Checked = True Then
            '    Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
            '    If oTasks.MarkNotCompleted(Me.JobNumber, Me.JobCompNumber, Me.SeqNum, Me.EmpCode) = False Then
            '        Me.lblMsg1.Text = "Mark Not Completed Failed!"
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

            If Session("TimesheetTaskComments") = "1" Then
                Session("TimesheetTaskComments") = ""
                Session("TimesheetTask") = "1"
            Else
                Session("TimesheetTask") = ""
            End If
            MiscFN.ResponseRedirect("~/Mobile/MobileTasks.aspx")
            'If Session("TimesheetTask") <> "1" Then
            '    Dim cScript As String
            '    cScript = "<script language='javascript'> window.opener.location=window.opener.location; </script>"
            '    RegisterStartupScript("parentwindow", cScript)
            'End If

            'Dim cScript2 As String
            'cScript2 = "<script>window.close();</script>"
            'RegisterStartupScript("page58", cScript2)

        Catch ex As Exception
            Response.Write(ex.Message.ToString())
        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        MiscFN.ResponseRedirect("~/Mobile/MobileTasks.aspx")
    End Sub
    Private Sub lbBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        MiscFN.ResponseRedirect("~/mobile/MobileTasks.aspx")
    End Sub
    Private Sub lbLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Me.SignOut()
    End Sub
End Class
