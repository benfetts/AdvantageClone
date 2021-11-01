Public Class JobStatus
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "



#End Region
#Region " Page "

    Private Sub JobStatus_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        Me._JobNumber = qs.JobNumber
        Me._JobComponentNumber = qs.JobComponentNumber

        Me.MyUnityContextMenu.JobNumber = Me._JobNumber
        Me.MyUnityContextMenu.JobComponentNumber = Me._JobComponentNumber

    End Sub
    Private Sub JobStatus_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.LoadData()

        End If

        If Me.IsClientPortal = True Then
            Me.DivAssignmentCard.Visible = False
            Me.DivTasksCard.Visible = False
            Me.DivEstimateApprovalCard.Visible = False
            Me.DivQvACard.Visible = False
            Me.DivBillingApprovalCard.Visible = False
        End If


    End Sub

#End Region

    Private Sub LoadData()

        Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

            Dim uc As New UserTheme()
            uc.Load()

            Dim BgColor As String = uc.Settings.SimpleLayoutBackgroundColor

            Dim js As New AdvantageFramework.Database.Classes.JobStatus
            js = AdvantageFramework.Database.Procedures.JobStatus.LoadByJobAndComponentNumber(DbContext, Me._JobNumber, Me._JobComponentNumber, HttpContext.Current.Session("UserCode"))

            If js IsNot Nothing Then

                'sb.Append(Me.AddCardContent("", js))
                Dim sb As New System.Text.StringBuilder

                Dim Office As String = String.Empty
                Dim Client As String = String.Empty
                Dim Division As String = String.Empty
                Dim Product As String = String.Empty
                Dim AccountExecutive As String = String.Empty
                Dim SalesClass As String = String.Empty
                Dim ProcessControl As String = String.Empty
                Dim JobType As String = String.Empty

                AdvantageFramework.ProjectManagement.LoadJobTemplateLabelsByJobComponent(DbContext, Me._JobNumber, Me._JobComponentNumber, Office, Client, Division,
                                                                                         Product, AccountExecutive, SalesClass, ProcessControl, JobType)

                'Details
                sb.Append(Me.AddCardContent(Office, If(js.Office, "")))
                sb.Append(Me.AddCardContent(Client, js.Client))
                sb.Append(Me.AddCardContent(Division, js.Division))
                sb.Append(Me.AddCardContent(Product, js.Product))
                sb.Append(Me.AddCardContent("", ""))
                sb.Append(Me.AddCardContent("Billable?", If(js.JobIsBillable, "Yes", "No")))
                sb.Append(Me.AddCardContent(ProcessControl, If(js.JobProcessControl, "")))
                Me.LiteralDetails.Text = sb.ToString()
                sb.Clear()

                'People
                sb.Append(Me.AddCardContent(AccountExecutive, If(js.AccountExecutiveFullName, "")))
                'sb.Append(Me.AddCardContent("Manager", If(js.ScheduleManagerFullName, "")))
                sb.Append(Me.AddCardContent("", ""))
                sb.Append(Me.AddCardContent(If(js.Assignment1Label, "Assignment "), If(js.Assignment1FullName, "")))
                sb.Append(Me.AddCardContent(If(js.Assignment2Label, "Assignment "), If(js.Assignment2FullName, "")))
                sb.Append(Me.AddCardContent(If(js.Assignment3Label, "Assignment "), If(js.Assignment3FullName, "")))
                sb.Append(Me.AddCardContent(If(js.Assignment4Label, "Assignment "), If(js.Assignment4FullName, "")))
                sb.Append(Me.AddCardContent(If(js.Assignment5Label, "Assignment "), If(js.Assignment5FullName, "")))

                Me.LiteralPeople.Text = sb.ToString()
                sb.Clear()

                'Alerts
                sb.Append(Me.AddCardContent("Last", If(js.LastAlertSubject, ""), True))
                sb.Append(Me.AddCardContent("Date", If(js.LastAlertDate, ""), , , True))
                sb.Append(Me.AddCardContent("", ""))
                sb.Append(Me.AddCardContent("Total", CType(js.TotalAlertCount, Integer), , , True))
                sb.Append(Me.AddCardContent("Open", CType(js.OpenAlertCount, Integer), , , True))
                Dim AlertsProgressBar As New AdvantageFramework.Web.Presentation.Controls.ProgressIndicator()
                AlertsProgressBar.Color = BgColor
                If js.TotalAlertCount > 0 Then
                    AlertsProgressBar.Value = ((js.TotalAlertCount - js.OpenAlertCount) / js.TotalAlertCount) * 100
                End If
                AlertsProgressBar.Max = 100
                AlertsProgressBar.Width = 200
                AlertsProgressBar.MarginTop = 5
                AlertsProgressBar.ToolTip = AlertsProgressBar.Value & "%"
                If AlertsProgressBar.Value = 100 Then AlertsProgressBar.Color = AlertsProgressBar.Green
                sb.Append(Me.AddCardContent("% Complete", AlertsProgressBar.DrawHTML, False, True))

                Me.LiteralAlerts.Text = sb.ToString()
                sb.Clear()

                'Assignments
                sb.Append(Me.AddCardContent("Last", If(js.LastAssignmentSubject, ""), True))
                sb.Append(Me.AddCardContent("Date", If(js.LastAssignmentDate, ""), , , True))
                sb.Append(Me.AddCardContent("", ""))
                sb.Append(Me.AddCardContent("Total", CType(js.TotalAssignmentCount, Integer), , , True))
                sb.Append(Me.AddCardContent("Open", CType(js.OpenAssignmentCount, Integer), , , True))
                Dim AssignmentsProgressBar As New AdvantageFramework.Web.Presentation.Controls.ProgressIndicator()
                AssignmentsProgressBar.Color = BgColor
                If js.TotalAssignmentCount > 0 Then
                    AssignmentsProgressBar.Value = ((js.TotalAssignmentCount - js.OpenAssignmentCount) / js.TotalAssignmentCount) * 100
                End If
                AssignmentsProgressBar.Max = 100
                AssignmentsProgressBar.Width = 200
                AssignmentsProgressBar.MarginTop = 5
                AssignmentsProgressBar.ToolTip = AssignmentsProgressBar.Value & "%"
                If AssignmentsProgressBar.Value = 100 Then AssignmentsProgressBar.Color = AssignmentsProgressBar.Green
                sb.Append(Me.AddCardContent("% Complete", AssignmentsProgressBar.DrawHTML, False, True))

                Me.LiteralAssignments.Text = sb.ToString()
                sb.Clear()

                'Schedule
                If js.ScheduleStatusCode IsNot Nothing Then sb.Append(Me.AddCardContent("Status", js.ScheduleStatusCode & " - " & js.ScheduleStatusDescription))
                sb.Append(Me.AddCardContent("Comments", If(js.ScheduleComments, ""), True))
                sb.Append(Me.AddCardContent("Start", If(js.ScheduleStartDate, ""), , , True))
                sb.Append(Me.AddCardContent("Due", If(js.ScheduleDueDate, ""), , , True))
                sb.Append(Me.AddCardContent("Projected Hours", String.Format("{0:0.00}", js.ProjectedHours), , , True))
                sb.Append(Me.AddCardContent("Actual Hours", String.Format("{0:0.00}", js.ActualHours), , , True))
                sb.Append(Me.AddCardContent("Remaining Hours", String.Format("{0:0.00}", js.ProjectedHours - js.ActualHours), , , True))
                Dim ScheduleProgressBar As New AdvantageFramework.Web.Presentation.Controls.ProgressIndicator()
                ScheduleProgressBar.Color = BgColor
                If js.ProjectedHours > 0 Then
                    ScheduleProgressBar.Value = (js.ActualHours / js.ProjectedHours) * 100
                End If
                If js.ActualHours > js.ProjectedHours Then
                    ScheduleProgressBar.Color = ScheduleProgressBar.Red
                    ScheduleProgressBar.Value = ScheduleProgressBar.Max
                Else
                    ScheduleProgressBar.Color = ScheduleProgressBar.Green
                End If
                ScheduleProgressBar.Max = 100
                ScheduleProgressBar.Width = 200
                ScheduleProgressBar.MarginTop = 5
                ScheduleProgressBar.ToolTip = ScheduleProgressBar.Value & "%"
                sb.Append(Me.AddCardContent("% Complete", ScheduleProgressBar.DrawHTML, False, True))

                Me.LiteralSchedule.Text = sb.ToString()
                sb.Clear()

                'Tasks
                sb.Append(Me.AddCardContent("Total", CType(js.TotalTasksCount, Integer), , , True))
                sb.Append(Me.AddCardContent("Open", CType(js.OpenTasksCount, Integer), , , True))
                Dim TaskProgressBar As New AdvantageFramework.Web.Presentation.Controls.ProgressIndicator()
                TaskProgressBar.Color = BgColor
                If js.TotalTasksCount > 0 Then
                    TaskProgressBar.Value = ((js.TotalTasksCount - js.OpenTasksCount) / js.TotalTasksCount) * 100
                End If
                TaskProgressBar.Max = 100
                TaskProgressBar.Width = 200
                TaskProgressBar.MarginTop = 5
                TaskProgressBar.ToolTip = TaskProgressBar.Value & "%"
                If TaskProgressBar.Value = 100 Then TaskProgressBar.Color = TaskProgressBar.Green
                sb.Append(Me.AddCardContent("% Complete", TaskProgressBar.DrawHTML, False, True))

                sb.Append(Me.AddCardContent("", ""))
                sb.Append(Me.AddCardContent("Task Hours Unassigned", String.Format("{0:0.00}", js.TaskHoursUnassigned), , , True))


                Me.LiteralTasks.Text = sb.ToString()
                sb.Clear()

                'Estimate Approval
                sb.Append(Me.AddCardContent("Approved Estimate required?", If(js.ApprovedEstimateRequired, "Yes", "No")))

                sb.Append("<br/>")

                sb.Append(Me.AddCardContent("Client", If(js.EstimateApprovalStatusClient, "")))
                sb.Append(Me.AddCardContent("Client Date", If(js.EstimateApprovalStatusClientDate, ""), , , True))
                sb.Append(Me.AddCardContent("Client Comment", If(js.EstimateApprovalStatusClientComment, ""), True))

                sb.Append("<br/>")

                sb.Append(Me.AddCardContent("Internal", If(js.EstimateApprovalStatusInternal, "")))
                sb.Append(Me.AddCardContent("Internal Date", If(js.EstimateApprovalStatusInternalDate, ""), , , True))
                sb.Append(Me.AddCardContent("Internal Comment", If(js.EstimateApprovalStatusInternalComment, ""), True))

                Me.LiteralEstimate.Text = sb.ToString()
                sb.Clear()

                'QvA
                sb.Append(Me.AddCardContent("Quoted Hrs.", String.Format("{0:0.00}", js.QuotedHours), , , True))
                sb.Append(Me.AddCardContent("Actual Hrs.", String.Format("{0:0.00}", js.ActualHours), , , True))
                sb.Append(Me.AddCardContent("Remaining", String.Format("{0:0.00}", js.RemainingHours), , , True))

                Dim QvAHoursProgressBar As New AdvantageFramework.Web.Presentation.Controls.ProgressIndicator()
                QvAHoursProgressBar.Color = BgColor
                If js.QuotedHours > 0 Then
                    QvAHoursProgressBar.Value = (js.ActualHours / js.QuotedHours) * 100
                End If
                QvAHoursProgressBar.Max = 100
                QvAHoursProgressBar.Width = 200
                QvAHoursProgressBar.MarginTop = 5
                QvAHoursProgressBar.ToolTip = QvAHoursProgressBar.Value & "%"
                If js.ActualHours > js.QuotedHours Then
                    QvAHoursProgressBar.Color = QvAHoursProgressBar.Red
                    QvAHoursProgressBar.Value = QvAHoursProgressBar.Max
                Else
                    QvAHoursProgressBar.Color = QvAHoursProgressBar.Green
                End If
                sb.Append(Me.AddCardContent("% Complete", QvAHoursProgressBar.DrawHTML, False, True))

                sb.Append("<br/>")

                sb.Append(Me.AddCardContent("Quoted Amt.", FormatCurrency(js.QuotedDollars), , , True))
                sb.Append(Me.AddCardContent("Actual Amt.", FormatCurrency(js.ActualDollars), , , True))
                sb.Append(Me.AddCardContent("Remaining", FormatCurrency(js.RemainingDollars), , , True))

                Dim QvAAmountProgressBar As New AdvantageFramework.Web.Presentation.Controls.ProgressIndicator()
                QvAAmountProgressBar.Color = BgColor
                If js.QuotedDollars > 0 Then
                    QvAAmountProgressBar.Value = CType((js.ActualDollars / js.QuotedDollars) * 100, Integer)
                End If
                QvAAmountProgressBar.Max = 100
                QvAAmountProgressBar.Width = 200
                QvAAmountProgressBar.MarginTop = 5
                QvAAmountProgressBar.ToolTip = QvAAmountProgressBar.Value & "%"
                If js.ActualDollars > js.QuotedDollars Then
                    QvAAmountProgressBar.Color = QvAAmountProgressBar.Red
                    QvAAmountProgressBar.Value = QvAAmountProgressBar.Max
                Else
                    QvAAmountProgressBar.Color = QvAAmountProgressBar.Green
                End If
                sb.Append(Me.AddCardContent("% Used", QvAAmountProgressBar.DrawHTML, False, True))

                Me.LiteralQvA.Text = sb.ToString()
                sb.Clear()

                'Billing Approval
                sb.Append(Me.AddCardContent("Process Control", If(js.JobProcessControl, "")))
                sb.Append(Me.AddCardContent("Billing Approval Batch", If(js.BatchText, "")))
                sb.Append(Me.AddCardContent("Batch Created By", If(js.BatchCreatedByUser, "")))
                sb.Append(Me.AddCardContent("Batch Date", If(js.BatchDate IsNot Nothing, CType(js.BatchDate, Date).ToShortDateString, "")))
                sb.Append(Me.AddCardContent("Selected for Billing By", If(js.BillingUser, "")))
                sb.Append(Me.AddCardContent("Advance Bill?", If(js.ABFlagText, "")))

                Me.LiteralBillingApproval.Text = sb.ToString()
                sb.Clear()

            End If

        End Using

    End Sub

#End Region

End Class
