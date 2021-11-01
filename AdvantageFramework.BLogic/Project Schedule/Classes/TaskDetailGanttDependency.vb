Imports Kendo.Mvc.UI

Namespace ProjectSchedule.Classes

    Public Class TaskDetailGanttDependency
        Implements IGanttDependency

        Public Property Type As DependencyType Implements IGanttDependency.Type

        Public Property ID As Integer
        Public Property PredecessorID As Short

        Public Property SuccessorID As Short

    End Class

End Namespace
