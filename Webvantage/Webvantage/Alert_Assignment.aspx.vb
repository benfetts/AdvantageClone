Public Class Alert_Assignment
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Private Property AlertID As Integer = 0

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub ButtonSendAssignment_Click(sender As Object, e As EventArgs) Handles ButtonSendAssignment.Click

        If Me.AlertAssignmentInfo.SaveAssignment() = False AndAlso Me.AlertAssignmentInfo.ErrorMessage.Trim() <> "" Then

            Me.ShowMessage(Me.AlertAssignmentInfo.ErrorMessage)

        Else

            'Me.CloseThisWindowAndRefreshCaller("Alert_Inbox.aspx")
            Me.RefreshAlertWindows()

        End If

    End Sub

#End Region
#Region " Page "

    Private Sub Alert_Assignment_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString()
        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
        Dim IsRouted As Boolean = False

        qs = qs.FromCurrent()

        Try

            Try

                AlertID = qs.AlertID

            Catch ex As Exception
                AlertID = 0
            End Try
            If AlertID = 0 Then

                Try

                    If Request.QueryString("AlertId") IsNot Nothing Then

                        AlertID = CType(Request.QueryString("AlertId"), Integer)

                    End If

                Catch ex As Exception
                    AlertID = 0
                End Try

            End If
            If AlertID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                    If Alert IsNot Nothing Then

                        If Alert.AlertAssignmentTemplateID IsNot Nothing AndAlso Alert.AlertAssignmentTemplateID > 0 Then

                            IsRouted = True

                        End If

                    End If

                End Using

            End If

        Catch ex As Exception
            IsRouted = False
        End Try
        If IsRouted = True Then

            DivYes.Visible = True
            DivNo.Visible = False

            Try

                With Me.AlertAssignmentInfo

                    .AlertId = AlertID
                    If .AlertId = 0 Then
                        .AlertId = Request.QueryString("AlertId")
                    End If
                    .WorkflowTemplateComboBox.Enabled = False
                    .ShowSaveButton = False
                    .ShowCommentTextbox = True

                End With

            Catch ex As Exception
            End Try

            Try

                Dim alrt As New cAlerts()
                Me.ButtonSendAssignment.Enabled = Not alrt.AssignmentIsCompleted(AlertID)

            Catch ex As Exception
            End Try

        Else

            DivYes.Visible = False
            DivNo.Visible = True

        End If

    End Sub

#End Region

#End Region



End Class
