Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetMarketGoalsCopyFromViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing
        Public Property CopyToWorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket = Nothing
        Public Property CopyFromMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketGoalsCopy)

        Public ReadOnly Property CopyEnabled As Boolean
            Get
                CopyEnabled = Me.HasASelectedWorksheetMarket
            End Get
        End Property

        Public ReadOnly Property HasASelectedWorksheetMarket As Boolean
            Get
                HasASelectedWorksheetMarket = (Me.CopyFromMarkets IsNot Nothing AndAlso Me.CopyFromMarkets.Any(Function(Entity) Entity.Selected = True))
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.Worksheet = Nothing
            Me.CopyToWorksheetMarket = Nothing

            Me.CopyFromMarkets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketGoalsCopy)

        End Sub

#End Region

    End Class

End Namespace
