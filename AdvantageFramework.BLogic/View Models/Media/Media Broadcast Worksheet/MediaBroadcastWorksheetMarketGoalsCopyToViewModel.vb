Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetMarketGoalsCopyToViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing
        Public Property CopyFromWorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket = Nothing
        Public Property CopyToMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketGoalsCopy)

        Public ReadOnly Property CopyEnabled As Boolean
            Get
                CopyEnabled = Me.HasASelectedWorksheetMarket
            End Get
        End Property

        Public ReadOnly Property HasASelectedWorksheetMarket As Boolean
            Get
                HasASelectedWorksheetMarket = (Me.CopyToMarkets IsNot Nothing AndAlso Me.CopyToMarkets.Any(Function(Entity) Entity.Selected = True))
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.Worksheet = Nothing
            Me.CopyFromWorksheetMarket = Nothing

            Me.CopyToMarkets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketGoalsCopy)

        End Sub

#End Region

    End Class

End Namespace
