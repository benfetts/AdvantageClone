Imports Telerik.Web.UI

Public Class TrafficSchedule_ConfirmCompleteAlert
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing

#End Region

#Region " Properties "

    Protected ReadOnly Property EmployeeCode As String
        Get

            Return HttpContext.Current.Session("EmpCode")

        End Get
    End Property
    Protected ReadOnly Property IsTempComplete As Boolean
        Get

            Return Me.CurrentQuerystring.GetValue("IsTempComplete") = "1"

        End Get
    End Property
    Protected ReadOnly Property AlertID As Integer
        Get

            Return Me.CurrentQuerystring.AlertID

        End Get
    End Property
    Protected ReadOnly Property ForceComplete As Boolean
        Get

            'objects
            Dim CompleteAssignment As Boolean = False

            Try

                CompleteAssignment = CBool(Request.QueryString("complete"))

            Catch ex As Exception
                CompleteAssignment = False
            End Try

            Return CompleteAssignment

        End Get
    End Property
    Protected ReadOnly Property DbContext As AdvantageFramework.Database.DbContext
        Get

            If _DbContext Is Nothing Then

                _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            End If

            Return _DbContext

        End Get
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub ButtonYes_Click(sender As Object, e As EventArgs) Handles ButtonYes.Click

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim a As AdvantageFramework.Database.Entities.Alert = Nothing
            a = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

            If a IsNot Nothing Then

                Dim EmployeeDismissingIsAssignee As Boolean = False

                If AdvantageFramework.AlertSystem.IsAlertAnAlertAssignment(a) = True Then

                    Dim CurrentAssigneeEmployeeCode As String = String.Empty
                    CurrentAssigneeEmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(ASSIGNED_EMP_CODE, '') FROM ALERT WITH(NOLOCK) WHERE ALERT_ID = {0};", a.ID)).FirstOrDefault

                    EmployeeDismissingIsAssignee = CurrentAssigneeEmployeeCode = EmployeeCode

                End If

                If Me.IsTempComplete = False Then

                    If AdvantageFramework.AlertSystem.IsAlertAnAlertAssignment(a) = False Then

                        Using sc As New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, sc, a.JobNumber, a.JobComponentNumber, a.TaskSequenceNumber, EmployeeCode, CType(Now, DateTime))

                        End Using

                    Else

                        If EmployeeDismissingIsAssignee = True Then

                            AdvantageFramework.ProjectSchedule.MarkAllEmployeesTempComplete(DbContext, a.JobNumber, a.JobComponentNumber, a.TaskSequenceNumber)

                        End If

                    End If

                    AdvantageFramework.ProjectSchedule.CompleteTaskFromAlertOrAssignment(DbContext, a.JobNumber, a.JobComponentNumber, a.TaskSequenceNumber, EmployeeCode, IsClientPortal)

                Else

                    If AdvantageFramework.AlertSystem.IsAlertAnAlertAssignment(a) = False Then

                        Using sc As New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, sc, a.JobNumber, a.JobComponentNumber, a.TaskSequenceNumber, EmployeeCode, CType(Now, DateTime))

                        End Using

                    Else

                        If EmployeeDismissingIsAssignee = True Then

                            AdvantageFramework.ProjectSchedule.MarkAllEmployeesTempComplete(DbContext, a.JobNumber, a.JobComponentNumber, a.TaskSequenceNumber)

                        End If

                    End If

                End If

            End If

        End Using

        Me.RefreshAlertWindows(True, True, False)

    End Sub
    Private Sub ButtonNo_Click(sender As Object, e As EventArgs) Handles ButtonNo.Click

        Me.RefreshAlertWindows(True, True, False)

    End Sub

#End Region
#Region " Page "

    Private Sub TrafficSchedule_ConfirmCompleteAlert_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
        Dim AgencySettingValue As Short = Nothing

        If Not Me.IsPostBack Then

            If Me.AlertID > 0 Then

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                If Alert IsNot Nothing Then

                    If Alert.AlertLevel = "PST" Then

                        If Me.IsTempComplete = False Then

                            LabelMessage.Text = AdvantageFramework.ProjectSchedule.DismissOrCompleteAlertConfirmationMessage(Me.ForceComplete)

                        Else

                            LabelMessage.Text = AdvantageFramework.ProjectSchedule.TempCompleteAlertConfirmationMessage(Me.ForceComplete)

                        End If

                    End If

                End If

            End If

            If String.IsNullOrWhiteSpace(LabelMessage.Text) Then

                Me.CloseThisWindow()

            End If

        End If

    End Sub


#End Region

#End Region

End Class
