Namespace Reporting.Database.Classes

    <Serializable>
    Public Class MediaBroadcastWorksheetCriteria

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaBroadcastWorksheetID
            MediaBroadcastWorksheetName
            MediaBroadcastWorksheetDateTypeID
            MediaBroadcastWorksheetMarketID
            StartDate
            EndDate
            MediaTypeCode
            MarketCode
            MarketDescription
            IsCable
            IsGross
            VendorCode
            VendorName
            SecondaryMediaDemoID
            SecondaryMediaCode
            SecondaryMediaDescription
        End Enum

#End Region

#Region " Variables "

#End Region

#Region " Properties "

        Public Property MediaBroadcastWorksheetID As Integer
        Public Property MediaBroadcastWorksheetName As String
        Public Property MediaBroadcastWorksheetDateTypeID As Integer
        Public Property MediaBroadcastWorksheetMarketID As Integer
        Public Property StartDate As Date
        Public Property EndDate As Date
        Public Property MediaTypeCode As String
        Public Property MarketCode As String
        Public Property MarketDescription As String
        Public Property IsCable As Boolean
        Public Property IsGross As Boolean
        Public Property VendorCode As String
        Public Property VendorName As String
        Public Property SecondaryMediaDemoID As Nullable(Of Integer)
        Public Property SecondaryMediaCode As String
        Public Property SecondaryMediaDescription As String


#End Region

#Region " Methods "


#End Region

    End Class

End Namespace
