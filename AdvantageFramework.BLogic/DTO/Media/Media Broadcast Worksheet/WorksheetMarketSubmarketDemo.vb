Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class WorksheetMarketSubmarketDemo
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaBroadcastWorksheetMarketSubmarketID
            MediaBroadcastWorksheetMarketID
            MarketCode
            Market
            Order
            MediaDemographicID
            IsPrimaryDemo
            ColumnName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property MediaBroadcastWorksheetMarketSubmarketID As Integer
        Public Property MediaBroadcastWorksheetMarketID As Integer
        Public Property MarketCode As String
        Public Property Market As String
        Public Property Order As Integer
        Public Property MediaDemographicID As Integer
        Public Property IsPrimaryDemo As Boolean
        Public ReadOnly Property ColumnName As String
            Get
                ColumnName = String.Format(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SubmarketColumnNameTemplate, Me.Order, Me.MediaBroadcastWorksheetMarketSubmarketID, Me.MediaDemographicID)
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.MediaBroadcastWorksheetMarketSubmarketID = 0
            Me.MediaBroadcastWorksheetMarketID = 0
            Me.MarketCode = Nothing
            Me.Market = String.Empty
            Me.Order = 0
            Me.MediaDemographicID = 0
            Me.IsPrimaryDemo = False

        End Sub
        Public Sub New(MediaBroadcastWorksheetMarketSubmarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketSubmarket, MediaDemographicID As Integer, IsPrimaryDemo As Boolean)

            Me.MediaBroadcastWorksheetMarketSubmarketID = MediaBroadcastWorksheetMarketSubmarket.ID
            Me.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketSubmarket.MediaBroadcastWorksheetMarketID
            Me.MarketCode = MediaBroadcastWorksheetMarketSubmarket.MarketCode
            Me.Market = If(MediaBroadcastWorksheetMarketSubmarket.Market IsNot Nothing, MediaBroadcastWorksheetMarketSubmarket.Market.Description, String.Empty)
            Me.Order = MediaBroadcastWorksheetMarketSubmarket.Order
            Me.MediaDemographicID = MediaDemographicID
            Me.IsPrimaryDemo = IsPrimaryDemo

        End Sub
        Public Sub New(WorksheetMarketSubmarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket, MediaDemographicID As Integer, IsPrimaryDemo As Boolean)

            Me.MediaBroadcastWorksheetMarketSubmarketID = WorksheetMarketSubmarket.ID
            Me.MediaBroadcastWorksheetMarketID = WorksheetMarketSubmarket.MediaBroadcastWorksheetMarketID
            Me.MarketCode = WorksheetMarketSubmarket.MarketCode
            Me.Market = WorksheetMarketSubmarket.Market
            Me.Order = WorksheetMarketSubmarket.Order
            Me.MediaDemographicID = MediaDemographicID
            Me.IsPrimaryDemo = IsPrimaryDemo

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ColumnName

        End Function

#End Region

    End Class

End Namespace
