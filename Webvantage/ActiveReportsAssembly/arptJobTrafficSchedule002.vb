Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports System.Drawing

Public Class arptJobTrafficSchedule002
    Public DueDateOnly As Boolean
    Public MilestoneOnly As Boolean
    Public EmployeeAssigned As Boolean
    Public ScheduleComment As Boolean
    Public dtTS As DataTable
    Public imgPath As String
    Public Sub New()
        InitializeComponent()
    End Sub 'New

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim duedate As DateTime
        If Me.txtDueDate.Text <> "" Then
            duedate = Convert.ToDateTime(Me.txtDueDate.Text)
        End If
        If Me.txtDueDate.Text <> "" Then
            Me.txtDueDate.Text = CDate(Me.txtDueDate.Text).ToShortDateString
        End If
        If Me.txtDueDate.Text = "1/1/1900" Then
            Me.txtDueDate.Text = ""
        End If
        'Me.txtAssigned.Text = Me.txtFName.Text & " " & Me.txtMName.Text & " " & Me.txtLName.Text
        Me.txtDay.Text = duedate.DayOfWeek.ToString.Substring(0, 3).ToUpper
        If Me.MilestoneOnly = True And Me.lblMilestone.Text = "0" Then
            Me.txtDay.Text = ""
            Me.txtDueDate.Text = ""
            Me.txtDescription.Text = ""
        ElseIf Me.lblMilestone.Text = "1" And Me.MilestoneOnly = False Then
            ' Me.txtDay.Text = Me.txtDay.Text & "*"
        End If
        If Me.MilestoneOnly = True Then
            Me.lblAsterik.Visible = False
        End If
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        If DueDateOnly = True Then
            Me.txtStartDatelbl.Text = ""
        End If
        If DueDateOnly = True And Me.EmployeeAssigned = False Then
            Me.lblAssigned.Text = ""
        End If
        If Me.MilestoneOnly = True And Me.EmployeeAssigned = False Then
            Me.lblAssigned.Text = ""
        End If
        If Me.MilestoneOnly = False And Me.EmployeeAssigned = False And Me.DueDateOnly = False Then
            Me.lblAssigned.Text = ""
        End If
    End Sub


    Public CultureCode As String = "en-US"
    Private Sub arptJobTrafficSchedule002_ReportStart(sender As Object, e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)

    End Sub
End Class
