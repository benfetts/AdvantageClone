Public Class EmployeeTimeForecast_SchedulerPrint
    Inherits System.Web.UI.Page

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "



#Region "  Form Event Handlers "

    Protected Sub EmployeeTimeForecast_SchedulerPrint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim SchedulerBitmapMemoryStream As System.IO.MemoryStream = Nothing

        Try

            If Session("SchedulerBitmapMemoryStream") IsNot Nothing Then

                If TypeOf Session("SchedulerBitmapMemoryStream") Is System.IO.MemoryStream Then

                    SchedulerBitmapMemoryStream = Session("SchedulerBitmapMemoryStream")

                    RadBinaryImageScreenShot.DataValue = SchedulerBitmapMemoryStream.ToArray

                End If

            End If

        Catch ex As Exception
            SchedulerBitmapMemoryStream = Nothing
        Finally

            If SchedulerBitmapMemoryStream IsNot Nothing Then

                SchedulerBitmapMemoryStream.Close()
                SchedulerBitmapMemoryStream.Dispose()
                SchedulerBitmapMemoryStream = Nothing

            End If

            Session("SchedulerBitmapMemoryStream") = Nothing

        End Try

        'Try

        '    If Request.QueryString("Database") IsNot Nothing Then

        '        Database = CType(Request.QueryString("Database"), String)

        '    End If

        'Catch ex As Exception
        '    Database = ""
        'End Try

        'ConnectionString = AdvantageFramework.Database.CreateConnectionString(Server, Database, True)

        'Using DbContext = _Session.DbContext(ConnectionString, "TEST")

        '    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, 143)

        '    If Job IsNot Nothing Then

        '        LabelClient.Text = Job.Client.Name
        '        LabelJob.Text = Job.ToString(True)

        '        Me.Title = "Job Schedule - " & Job.ToString(True)

        '        'RadSchedulerJobSchedule.DayStartTime = System.TimeSpan.Parse("08:00:00")
        '        'RadSchedulerJobSchedule.DayEndTime = System.TimeSpan.Parse("20:00:00")
        '        'RadSchedulerJobSchedule.WorkDayStartTime = System.TimeSpan.Parse("08:00:00")
        '        'RadSchedulerJobSchedule.WorkDayEndTime = System.TimeSpan.Parse("20:00:00")

        '        ''RadSchedulerJobSchedule.SelectedView = Session("SchedulerViewType")

        '        ''If RadSchedulerJobSchedule.SelectedView <> Telerik.Web.UI.SchedulerViewType.TimelineView Then

        '        ''    RadSchedulerJobSchedule.SelectedDate = Session("SchedulerSelectedDate")
        '        ''    RadSchedulerJobSchedule.MonthView.ReadOnly = True
        '        ''    RadSchedulerJobSchedule.DayView.ReadOnly = True
        '        ''    RadSchedulerJobSchedule.WeekView.ReadOnly = True

        '        ''Else

        '        ''    RadSchedulerJobSchedule.SelectedDate = Session("SchedulerSelectedDate")
        '        ''    RadSchedulerJobSchedule.TimelineView.SlotDuration = System.TimeSpan.Parse("1.00:00:00")
        '        ''    RadSchedulerJobSchedule.TimelineView.TimeLabelSpan = 1
        '        ''    RadSchedulerJobSchedule.TimelineView.ColumnHeaderDateFormat = "MM/dd/yyyy"
        '        ''    RadSchedulerJobSchedule.TimelineView.ReadOnly = True
        '        ''    RadSchedulerJobSchedule.TimelineView.NumberOfSlots = System.Math.Abs(DateDiff(DateInterval.Day, RadSchedulerJobSchedule.SelectedDate, _
        '        ''                                                                                  Session("SchedulerEndDate")))

        '        ''End If

        '        JobComponentTasksList = New Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTask)

        '        For Each JobComponent In Job.JobComponents.ToList

        '            For Each JobComponentTask In JobComponent.JobComponentTasks.ToList

        '                If JobComponentTask.StartDate IsNot Nothing AndAlso JobComponentTask.StartDate.HasValue AndAlso _
        '                    JobComponentTask.DueDate IsNot Nothing AndAlso JobComponentTask.DueDate.HasValue Then

        '                    JobComponentTasksList.Add(JobComponentTask)

        '                End If

        '            Next

        '        Next

        '        RadSchedulerJobSchedule.DataSource = JobComponentTasksList
        '        RadSchedulerJobSchedule.DataBind()

        '    End If

        'End Using

    End Sub

#End Region

#Region "  Control Event Handlers "


#End Region

#End Region

End Class