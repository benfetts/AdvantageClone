Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetMarketSubmarketsAddMarketGroupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property OKEnabled As Boolean
        Public Property CancelEnabled As Boolean

        Public Property MediaBroadcastWorksheetMarketID As Integer

        Public Property MarketGroups As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup)

#End Region

#Region " Methods "

        Public Sub New()

            Me.OKEnabled = True
            Me.CancelEnabled = True

            Me.MediaBroadcastWorksheetMarketID = 0

            Me.MarketGroups = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup)

        End Sub

#End Region

    End Class

End Namespace
