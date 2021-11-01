Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports System.Drawing

Public Class arptJobTrafficSchedule
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
        'Dim duedate As DateTime = Convert.ToDateTime(Me.txtDueDate.Text)
        If Me.txtDueDate.Text <> "" Then
            Me.txtDueDate.Text = CDate(Me.txtDueDate.Text).ToShortDateString
        End If
        'Dim startdate As DateTime = Convert.ToDateTime(Me.txtStartDate.Text)
        If Me.txtStartDate.Text <> "" Then
            Me.txtStartDate.Text = CDate(Me.txtStartDate.Text).ToShortDateString
        End If
        If Me.txtStartDate.Text = "1/1/1900" Then
            Me.txtStartDate.Text = ""
        End If
        If Me.txtDueDate.Text = "1/1/1900" Then
            Me.txtDueDate.Text = ""
        End If
        'Me.txtAssigned.Text = Me.txtFName.Text & " " & Me.txtMName.Text & " " & Me.txtLName.Text
        If DueDateOnly = True Then
            Me.txtStartDate.Text = ""
        End If
        If Me.MilestoneOnly = True And Me.lblMilestone.Text = "0" Then
            Me.txtTask.Text = ""
            Me.txtDueDate.Text = ""
            Me.txtAssigned.Text = ""
        ElseIf Me.lblMilestone.Text = "1" And Me.MilestoneOnly = False Then
            Me.txtTask.Text = Me.txtTask.Text & "*"
        End If
        If Me.EmployeeAssigned = False Then
            Me.txtAssigned.Visible = False
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
        If Me.ScheduleComment = True Then
            Me.txtComments.Text = "Comments:"
        Else
            Me.txtComments.Text = ""
            Me.txtScheduleComments.Text = ""
        End If
    End Sub

    
    Public CultureCode As String = "en-US"
    Private Sub arptJobTrafficSchedule_ReportStart(sender As Object, e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)

    End Sub
End Class
