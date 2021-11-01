Imports Webvantage.cGlobals
Public Class Calendar_AppointmentCheck
    Inherits Webvantage.BaseChildPage

    Public RandomClass As New Random()

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    If Page.IsPostBack = False Then
                        If Request.QueryString("state") = "edit" Then
                            Me.Page.Title = "Editing a recurring appointment"
                        End If
                        If Request.QueryString("state") = "delete" Then
                            Me.Page.Title = "Deleting a recurring appointment"
                            Me.RadioButtonOccurence.Text = "Delete only this occurrence."
                            Me.RadioButtonSeries.Text = "Delete the series."
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try

    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        Try
            Dim task As AdvantageFramework.Database.Entities.EmployeeNonTask
            Dim tasklist As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeNonTask) = Nothing
            If Request.QueryString("state") = "edit" Then
                If Me.RadioButtonOccurence.Checked = True Then
                    Me.CloseThisWindowAndOpenNewWindow("Calendar_NewActivity.aspx?TaskNo=" & Request.QueryString("TaskNo") & "&state=occurrence")
                End If
                If Me.RadioButtonSeries.Checked = True Then
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        task = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, Request.QueryString("TaskNo"))
                        If Not task.RecurrenceParent Is Nothing Then
                            Me.CloseThisWindowAndOpenNewWindow("Calendar_NewActivity.aspx?TaskNo=" & task.RecurrenceParent.ToString & "&state=master")
                        Else
                            Me.CloseThisWindowAndOpenNewWindow("Calendar_NewActivity.aspx?TaskNo=" & Request.QueryString("TaskNo") & "&state=master")
                        End If
                    End Using
                End If
            End If
            If Request.QueryString("state") = "delete" Then
                If Me.RadioButtonOccurence.Checked = True Then
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        task = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, Request.QueryString("TaskNo"))
                        If AdvantageFramework.Database.Procedures.EmployeeNonTask.Delete(DbContext, task) Then
                            AdvantageFramework.Database.Procedures.EmployeeNonTask.Delete(DbContext, task)
                        End If
                    End Using
                End If
                If Me.RadioButtonSeries.Checked = True Then
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        task = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, Request.QueryString("TaskNo"))
                        If Not task.RecurrenceParent Is Nothing Then
                            tasklist = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByRecurrenceParentID(DbContext, task.RecurrenceParent).ToList
                            For Each task In tasklist
                                AdvantageFramework.Database.Procedures.EmployeeNonTask.DeleteByNonTaskId(DbContext, task.ID)
                            Next
                            AdvantageFramework.Database.Procedures.EmployeeNonTask.DeleteByNonTaskId(DbContext, task.RecurrenceParent)
                        Else
                            tasklist = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByRecurrenceParentID(DbContext, task.ID).ToList
                            For Each task In tasklist
                                AdvantageFramework.Database.Procedures.EmployeeNonTask.DeleteByNonTaskId(DbContext, task.ID)
                            Next
                            AdvantageFramework.Database.Procedures.EmployeeNonTask.DeleteByNonTaskId(DbContext, task.ID)
                        End If
                    End Using
                End If
                Me.CloseThisWindowAndRefreshCaller("Calendar_MonthView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Try
            Me.CloseThisWindowAndRefreshCaller("Calendar_MonthView.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class