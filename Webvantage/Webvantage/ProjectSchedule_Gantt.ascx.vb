Public Class ProjectSchedule_Gantt
    Inherits Webvantage.BaseContentUserControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

#End Region
#Region " Page "

#End Region

    Public Sub LoadData()
        Dim GanttTaskRepo As New Repositories.GanttTaskRepository(TryCast(HttpContext.Current.Session("Security_Session"), AdvantageFramework.Security.Session))

        Me.RadGanttSchedule.DataSource = GanttTaskRepo.All(Me.JobNumber, Me.JobComponentNumber) ' ScheduleTaskList
        Me.RadGanttSchedule.DataBind()

    End Sub

#End Region

End Class