Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class arptCompletedTask 
    Public dtData As DataTable
    Public title As String
    Public dateoption As String
    Public strUserID As String
    Public CultureCode As String = "en-US"
    Private Sub arptCompletedTask_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        Me.DataSource = dtData
    End Sub

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Try
            Me.txtCompleted.Text = Me.txtCompleted.Text.Replace("12:00:00 AM", "").Trim
            If dateoption = "origcomp" Then
                Me.txtDueDate.Text = Me.txtJobDueDate.Text
            End If
            If dateoption = "duecomp" Then
                Me.txtDueDate.Text = Me.txtJobRevDate.Text
            End If
            Me.txtDueDate.Text = Me.txtDueDate.Text.Replace("12:00:00 AM", "").Trim

            If Me.txtDueDate.Text <> "" And Me.txtCompleted.Text <> "" Then
                If Me.txtDueDate.Text.Trim = Me.txtCompleted.Text.Trim Then
                    Me.txtEarlyLate.Text = "0"
                Else
                    Dim earlylate As TimeSpan = CDate(Me.txtCompleted.Text).Subtract(CDate(Me.txtDueDate.Text))
                    Me.txtEarlyLate.Text = earlylate.Days.ToString
                    'Me.txtEarlyLate.Text = earlylate.TotalDays.ToString
                    If CInt(Me.txtEarlyLate.Text) > 0 Then
                        Me.txtEarlyLate.Text = "+" & Me.txtEarlyLate.Text
                    End If
                End If
            ElseIf (Me.txtDueDate.Text <> "" And Me.txtCompleted.Text = "") Or (Me.txtDueDate.Text = "" And Me.txtCompleted.Text <> "") Then
                Me.txtEarlyLate.Text = ""
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader2.Format
        Try
            Me.txtJobComp.Text = Me.txtJobNumber.Text & " - " & Me.txtJobDesc.Text & " / " & Me.txtJobCompNumber.Text & " - " & Me.txtJobCompDesc.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        'Me.rptTitle.Text = title 'This is in report header, not page header
    End Sub

    Private Sub PageFooter1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter1.BeforePrint
        lbluser.Text = Me.strUserID
    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        Me.rptTitle.Text = title
    End Sub
End Class
