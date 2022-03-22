Option Strict On

Namespace ViewModels.Media

    Public Class ComscorePrecacheViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Markets As Generic.List(Of AdvantageFramework.DTO.Media.ComscorePrecache.Market)
        Public Property MarketStations As Generic.List(Of AdvantageFramework.DTO.Media.ComscorePrecache.Station)
        Public Property MarketBooks As Generic.List(Of AdvantageFramework.DTO.Media.ComscorePrecache.Book)
        Public Property MarketDemographics As Generic.List(Of AdvantageFramework.DTO.Media.ComscorePrecache.Demographic)
        Public Property MarketCached As Generic.List(Of AdvantageFramework.DTO.Media.ComscorePrecache.Cache)

        Public Property SelectedMarket As AdvantageFramework.DTO.Media.ComscorePrecache.Market

#End Region

#Region " Methods "

        Public Sub New()

            Me.Markets = New Generic.List(Of AdvantageFramework.DTO.Media.ComscorePrecache.Market)
            Me.MarketStations = New Generic.List(Of AdvantageFramework.DTO.Media.ComscorePrecache.Station)
            Me.MarketBooks = New Generic.List(Of AdvantageFramework.DTO.Media.ComscorePrecache.Book)
            Me.MarketDemographics = New Generic.List(Of AdvantageFramework.DTO.Media.ComscorePrecache.Demographic)
            Me.MarketCached = New Generic.List(Of AdvantageFramework.DTO.Media.ComscorePrecache.Cache)

        End Sub

#End Region

    End Class

End Namespace
