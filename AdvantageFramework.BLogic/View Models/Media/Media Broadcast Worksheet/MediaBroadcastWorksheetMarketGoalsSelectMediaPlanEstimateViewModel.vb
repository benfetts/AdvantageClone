Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing
        Public Property WorksheetMarketGoalsMediaPlanEstimates As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketGoalsMediaPlanEstimate)

        Public ReadOnly Property SelectEnabled As Boolean
            Get
                SelectEnabled = Me.HasASelectedEstimate
            End Get
        End Property

        Public ReadOnly Property HasASelectedEstimate As Boolean
            Get
                HasASelectedEstimate = (Me.WorksheetMarketGoalsMediaPlanEstimates IsNot Nothing AndAlso Me.WorksheetMarketGoalsMediaPlanEstimates.Any(Function(Entity) Entity.Selected = True))
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.Worksheet = Nothing

            Me.WorksheetMarketGoalsMediaPlanEstimates = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketGoalsMediaPlanEstimate)

        End Sub

#End Region

    End Class

End Namespace
