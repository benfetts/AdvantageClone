Namespace ViewModels.Maintenance.Accounting

    Public Class VendorMarketsViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SaveEnabled As Boolean
        Public Property CancelEnabled As Boolean

        Public Property IsNewRow As Boolean
        Public ReadOnly Property MarketDeleteEnabled As Boolean
            Get
                If Me.IsNewRow OrElse (Me.SelectedVendorMarket IsNot Nothing AndAlso Me.SelectedVendorMarket.MarketCode = MarketCode) Then
                    MarketDeleteEnabled = False
                Else
                    MarketDeleteEnabled = True
                End If
            End Get
        End Property

        Public Property MarketCancelEnabled As Boolean
        Public Property MarketMoveUpEnabled As Boolean
        Public Property MarketMoveDownEnabled As Boolean

        Public Property VendorCode As String
        Public Property Vendor As AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Vendor

        Public Property VendorMarkets As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorMarket)
        Public Property SelectedVendorMarket As AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorMarket

        Public ReadOnly Property HasASelectedVendorMarket As Boolean
            Get
                HasASelectedVendorMarket = (Me.SelectedVendorMarket IsNot Nothing)
            End Get
        End Property

        Public Property Markets As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Market)

        Public Property MarketCode As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.SaveEnabled = True
            Me.CancelEnabled = True

            Me.IsNewRow = False
            Me.MarketCancelEnabled = False
            Me.MarketMoveUpEnabled = False
            Me.MarketMoveDownEnabled = False

            Me.VendorCode = 0
            Me.Vendor = Nothing

            Me.VendorMarkets = Nothing
            Me.SelectedVendorMarket = Nothing

            Me.Markets = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Market)

            Me.MarketCode = String.Empty

        End Sub

#End Region

    End Class

End Namespace

