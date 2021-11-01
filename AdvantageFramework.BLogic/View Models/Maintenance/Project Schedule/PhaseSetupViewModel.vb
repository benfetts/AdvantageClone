Namespace ViewModels.Maintenance.ProjectSchedule

    Public Class PhaseSetupViewModel

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
        Public Property Phases As Generic.List(Of AdvantageFramework.Database.Entities.Phase)
        Public ReadOnly Property HasASelectedPhase As Boolean
            Get
                HasASelectedPhase = SelectedPhases IsNot Nothing AndAlso SelectedPhases.Count > 0
            End Get
        End Property
        Public Property IsNewRow As Boolean
        Public Property SelectedPhases As Generic.List(Of AdvantageFramework.Database.Entities.Phase)

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

