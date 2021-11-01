Namespace ViewModels.Maintenance

    Public Class ClientOrderDetailViewModel
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ClientOrder As DTO.ClientOrder
        Public Property ClientOrderMarkets As Generic.List(Of DTO.ClientOrderMarket)
        Public Property ClientOrderStates As Generic.List(Of DTO.ClientOrderState)

        Public Property RepositoryAvailableMarkets As Generic.List(Of DTO.NielsenMarket)
        Public Property SelectedClientOrderMarket As DTO.ClientOrderMarket

        Public Property MarketIsNewRow As Boolean
        Public Property MarketCancelEnabled As Boolean
        Public Property MarketDeleteEnabled As Boolean

        Public Property RepositoryAvailableStates As Generic.List(Of DTO.State)
        Public Property SelectedClientOrderState As DTO.ClientOrderState

        Public Property StateIsNewRow As Boolean
        Public Property StateCancelEnabled As Boolean
        Public Property StateDeleteEnabled As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            RepositoryAvailableMarkets = New Generic.List(Of DTO.NielsenMarket)
            RepositoryAvailableStates = New Generic.List(Of DTO.State)

        End Sub

#End Region

    End Class

End Namespace

