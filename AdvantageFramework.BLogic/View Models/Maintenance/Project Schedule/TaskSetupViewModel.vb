Namespace ViewModels.Maintenance.ProjectSchedule

    Public Class TaskSetupViewModel

        'Public Event SelectionChanged()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property CancelEnabled As Boolean
        Public Property DeleteEnabled As Boolean
        Public Property Tasks As Generic.List(Of AdvantageFramework.Database.Entities.Task)
        Public ReadOnly Property HasASelectedTask As Boolean
            Get
                HasASelectedTask = SelectedTasks IsNot Nothing AndAlso SelectedTasks.Count > 0
            End Get
        End Property
        Public Property IsNewRow As Boolean
        Public Property SelectedTasks As Generic.List(Of AdvantageFramework.Database.Entities.Task)

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

