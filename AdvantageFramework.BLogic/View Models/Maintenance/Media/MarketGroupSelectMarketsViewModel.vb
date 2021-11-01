Namespace ViewModels.Maintenance.Media

    Public Class MarketGroupSelectMarketsViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SelectEnabled As Boolean
        Public Property CancelEnabled As Boolean

        Public Property MarketGroupID As Integer
        Public Property MarketGroup As AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup
        Public Property MarketGroupMarkets As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroupMarket)

        Public Property Markets As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market)

#End Region

#Region " Methods "

        Public Sub New()

            Me.SelectEnabled = False
            Me.CancelEnabled = False

            Me.MarketGroupID = 0
            Me.MarketGroup = Nothing
            Me.MarketGroupMarkets = Nothing

            Me.Markets = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market)

        End Sub

#End Region

    End Class

End Namespace

