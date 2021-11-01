Imports Kendo.Mvc.UI

Namespace ProjectSchedule.Classes
    Public Class TaskDetailGantt
        Implements IGanttTask

        Public Property ID As Integer
        Public Property Title As String

        Public Property TaskDescription As String Implements IGanttTask.Title

        Public Property TaskStartDate As Date Implements IGanttTask.Start

        Public Property JobRevisedDate As Date Implements IGanttTask.End

        Public Property PercentComplete As Decimal Implements IGanttTask.PercentComplete

        Public Property Summary As Boolean Implements IGanttTask.Summary

        Public Property Expanded As Boolean Implements IGanttTask.Expanded

        Public Property GridOrder As Integer Implements IGanttTask.OrderId

        Public Property SequenceNumber As Integer

        Public Property ParentTaskSequenceNumber As Integer?

        Public Property HasChildren As Boolean

        Public Property PredecessorLevelNotation As String

        Public Property JobDays As Short

    End Class
End Namespace
