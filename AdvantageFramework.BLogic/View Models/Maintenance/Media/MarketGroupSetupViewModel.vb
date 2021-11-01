Namespace ViewModels.Maintenance.Media

    Public Class MarketGroupSetupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AddEnabled As Boolean
        Public Property UpdateEnabled As Boolean
        Public Property DeleteEnabled As Boolean
        Public Property ExportEnabled As Boolean

        Public Property AddMarketsEnabled As Boolean
        Public Property DeleteMarketsEnabled As Boolean
        Public Property MoveUpMarketEnabled As Boolean
        Public Property MoveDownMarketEnabled As Boolean

        Public Property MarketGroups As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup)

        Public Property SelectedMarketGroup As AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup
        Public Property MarketGroupMarkets As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroupMarket)
        Public Property SelectedMarketGroupMarkets As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroupMarket)

        'Public Property Markets As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market)
        Public Property Countries As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Country)


#End Region

#Region " Methods "

        Public Sub New()

            Me.AddEnabled = True
            Me.UpdateEnabled = False
            Me.DeleteEnabled = False
            Me.ExportEnabled = True

            Me.AddMarketsEnabled = False
            Me.DeleteMarketsEnabled = False
            Me.MoveUpMarketEnabled = False
            Me.MoveDownMarketEnabled = False

            Me.MarketGroups = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup)

            Me.SelectedMarketGroup = Nothing
            Me.MarketGroupMarkets = Nothing
            Me.SelectedMarketGroupMarkets = Nothing

            'Me.Markets = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market)
            Me.Countries = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Country)

        End Sub

#End Region

    End Class

End Namespace

