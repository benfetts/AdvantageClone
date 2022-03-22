Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class ReachFreqDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            MediaTypeCode

            MediaBroadCastWorksheetID

            'To filter for market report
            MediaBroadCastWorksheetMarketID

            'To filter for station Report
            MarketDescription
            VendorCode
            VendorNielsenTVStationCode
            CableNetworkNielsenTVStationCode

            'To filter for weekly report
            BroadcastYear
            BroadcastQuarter
            BroadcastWeekOfQuarter
            BroadCastWeekKey

            LineNumber
            Spots
            DetailDate
            SharebookNielsenTVBookID
            VendorRadioStationComboID
            NeilsenRadioPeriodID1
            NeilsenRadioPeriodID2
            IsCable
            OnHold
            VendorIsComboRadioStation

            PrimaryBuyImpressions
            PrimaryCumeImpressions
            PrimaryCume
            PrimaryUniverse
            PrimaryRating
            PrimaryBookRating
            PrimaryAQH
            PrimaryAHQRating
            PrimaryBookAHQRating
            PrimaryGRP
            PrimaryReach

            SecondaryBuyImpressions
            SecondaryCumeImpressions
            SecondaryCume
            SecondaryUniverse
            SecondaryRating
            SecondaryBookRating
            SecondaryAQH
            SecondaryAQHRating
            SecondaryBookAQHRating
            SecondaryGRP
            SecondaryReach


        End Enum

#End Region

#Region " Variables "

#End Region

#Region " Properties "

        Public Property MediaTypeCode As String

        Public Property MediaBroadCastWorksheetID As Nullable(Of Integer)

        'To filter for market report
        Public Property MediaBroadCastWorksheetMarketID As Nullable(Of Integer)

        'To filter for station Report
        Public Property MarketDescription As String
        Public Property VendorCode As String
        Public Property VendorNielsenTVStationCode As Nullable(Of Integer)
        Public Property CableNetworkNielsenTVStationCode As Nullable(Of Integer)

        'To filter for weekly report
        Public Property BroadcastYear As Nullable(Of Integer)
        Public Property BroadcastQuarter As Nullable(Of Integer)
        Public Property BroadcastWeekOfQuarter As Nullable(Of Integer)
        Public Property BroadCastWeekKey As Nullable(Of Integer)
        Public Property LineNumber As Nullable(Of Integer)
        Public Property Spots As Nullable(Of Integer)
        Public Property DetailDate As Nullable(Of Date)
        Public Property SharebookNielsenTVBookID As Nullable(Of Integer)
        Public Property VendorRadioStationComboID As Nullable(Of Integer)
        Public Property NeilsenRadioPeriodID1 As Nullable(Of Integer)
        Public Property NeilsenRadioPeriodID2 As Nullable(Of Integer)
        Public Property IsCable As Boolean
        Public Property OnHold As Boolean
        Public Property VendorIsComboRadioStation As Boolean

        Public Property PrimaryBuyImpressions As Nullable(Of Long)
        Public Property PrimaryCumeImpressions As Nullable(Of Long)
        Public Property PrimaryCume As Nullable(Of Long)
        Public Property PrimaryUniverse As Nullable(Of Long)

        Public Property PrimaryRating As Nullable(Of Decimal)
        Public Property PrimaryBookRating As Nullable(Of Decimal)
        Public Property PrimaryAQH As Nullable(Of Long)
        Public Property PrimaryAQHRating As Nullable(Of Decimal)
        Public Property PrimaryBookAQHRating As Nullable(Of Decimal)
        Public Property PrimaryGRP As Nullable(Of Decimal)
        Public Property PrimaryReach As Nullable(Of Decimal)

        Public Property SecondaryBuyImpressions As Nullable(Of Long)
        Public Property SecondaryCumeImpressions As Nullable(Of Long)
        Public Property SecondaryCume As Nullable(Of Long)
        Public Property SecondaryUniverse As Nullable(Of Long)
        Public Property SecondaryRating As Nullable(Of Decimal)
        Public Property SecondaryBookRating As Nullable(Of Decimal)
        Public Property SecondaryAQH As Nullable(Of Long)
        Public Property SecondaryAQHRating As Nullable(Of Decimal)
        Public Property SecondaryBookAQHRating As Nullable(Of Decimal)
        Public Property SecondaryGRP As Nullable(Of Decimal)
        Public Property SecondaryReach As Nullable(Of Decimal)


#End Region

#Region " Methods "


#End Region

    End Class

End Namespace

