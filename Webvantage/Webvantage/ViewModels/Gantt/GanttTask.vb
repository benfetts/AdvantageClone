Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace ViewModels.Gantt
    Public Class GanttTask
#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

#End Region

#Region " Properties "
        Public Property IsPhase As Boolean = False
        Public Property DispersedHours As Decimal = 0
        Public Property PostedHours As Decimal = 0
        Public Property ID As Integer
        Public Property Title As String
        Public Property ParentID As Integer?
        Public Property OrderID As Integer
        Public Property Start As DateTime?
        Public Property [End] As DateTime?
        Public Property PercentComplete As Decimal
        Public Property Summary As Boolean
        Public Property Expanded As Boolean
        Public Property StartMissing As Boolean = False
        Public Property EndMissing As Boolean = False
        Public Property AssignedEmployees As String
#End Region

#Region " Methods "
        Public Sub New()

        End Sub

        Public Sub New(ProjectScheduleItem As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)
            Me.End = ProjectScheduleItem.JobRevisedDate.GetValueOrDefault()
            Me.Expanded = True
            Me.ID = ProjectScheduleItem.ID

            If ProjectScheduleItem.GridOrder.HasValue Then

                Me.OrderID = ProjectScheduleItem.GridOrder

            Else

                Me.OrderID = ProjectScheduleItem.SequenceNumber

            End If

            Me.PercentComplete = ProjectScheduleItem.PercentComplete * 0.01
            Me.Start = ProjectScheduleItem.TaskStartDate
            Me.Summary = False
            Me.Title = ProjectScheduleItem.TaskDescription
            Me.DispersedHours = ProjectScheduleItem.DispersedHours
            Me.PostedHours = ProjectScheduleItem.PostedHours
        End Sub
#End Region



    End Class
End Namespace

