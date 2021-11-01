Namespace ViewModels.Maintenance.ProjectSchedule

    Public Class StatusSetupViewModel

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
        Public Property Statuses As Generic.List(Of AdvantageFramework.Database.Entities.Status)
        Public ReadOnly Property HasASelectedStatus As Boolean
            Get
                HasASelectedStatus = SelectedStatuses IsNot Nothing AndAlso SelectedStatuses.Count > 0
            End Get
        End Property
        Public Property IsNewRow As Boolean
        Public Property SelectedStatuses As Generic.List(Of AdvantageFramework.Database.Entities.Status)

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

