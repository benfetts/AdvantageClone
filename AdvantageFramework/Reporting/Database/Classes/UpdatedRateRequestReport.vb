Namespace Reporting.Database.Classes

    <Serializable>
    Public Class UpdatedRateRequestReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientName
            DivisionName
            ProductDescription
            MediaBroadcastWorksheetName
            MarketName
            VendorCode
            VendorName
            FlightDates
            Days
            Time
            DaysTime
            Program
            Rate
            Daypart
            Len
            NielsenTVStationCode
            NCCTVSyscodeID
            StationName
            NielsenMarketNumber
            ReportedDates
            RatingsServiceID
            RatingSource
            MediaType
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ClientName As String

        Public Property DivisionName As String

        Public Property ProductDescription As String

        Public Property MediaBroadcastWorksheetName As String

        Public Property MarketName As String

        Public Property VendorCode As String

        Public Property VendorName As String

        Public Property FlightDates As String

        Public Property Days As String

        Public Property Time As String

        Public ReadOnly Property DaysTime As String
            Get
                DaysTime = Me.Days & Space(1) & Me.Time
            End Get
        End Property

        Public Property Program As String

        Public Property Rate As Nullable(Of Decimal)

        Public Property PrimaryRating As Decimal
        Public Property SecondaryRating As Decimal

        Public Property PrimaryImpressions As Decimal
        Public Property SecondaryImpressions As Decimal

        Public Property PrimaryCPP As Decimal
        Public Property SecondaryCPP As Decimal

        Public Property PrimaryCPM As Decimal
        Public Property SecondaryCPM As Decimal

        Public Property Daypart As String

        Public Property Len As Short

        Public Property NielsenTVStationCode As Nullable(Of Integer)

        Public Property NCCTVSyscodeID As Nullable(Of Integer)

        Public Property StationName As String

        Public Property NielsenMarketNumber As Integer

        Public Property PrimaryDemographicDescription As String
        Public Property SecondaryDemographicDescription As String

        Public Property RatingsServiceID As AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID

        Public Property RatingSource As String

        Public Property SharebookID As Nullable(Of Integer)

        Public Property HPUTbookID As Nullable(Of Integer)

        Public Property MediaType As String

        Public Property StartHour As Short

        Public Property EndHour As Short

        Public Property RadioPeriod1 As Nullable(Of Integer)
        Public Property RadioPeriod2 As Nullable(Of Integer)
        Public Property RadioPeriod3 As Nullable(Of Integer)
        Public Property RadioPeriod4 As Nullable(Of Integer)
        Public Property RadioPeriod5 As Nullable(Of Integer)

        Public Property ShowRatingsCPP As Boolean

        Public ReadOnly Property PrimaryRatingImpression As Decimal
            Get
                If Me.ShowRatingsCPP Then
                    PrimaryRatingImpression = Me.PrimaryRating
                Else
                    PrimaryRatingImpression = Me.PrimaryImpressions
                End If
            End Get
        End Property
        Public ReadOnly Property SecondaryRatingImpression As Decimal
            Get
                If Me.ShowRatingsCPP Then
                    SecondaryRatingImpression = Me.SecondaryRating
                Else
                    SecondaryRatingImpression = Me.SecondaryImpressions
                End If
            End Get
        End Property

        Public ReadOnly Property PrimaryCPPCPM As Decimal
            Get
                If Me.ShowRatingsCPP Then
                    PrimaryCPPCPM = Me.PrimaryCPP
                Else
                    PrimaryCPPCPM = Me.PrimaryCPM
                End If
            End Get
        End Property
        Public ReadOnly Property SecondaryCPPCPM As Decimal
            Get
                If Me.ShowRatingsCPP Then
                    SecondaryCPPCPM = Me.SecondaryCPP
                Else
                    SecondaryCPPCPM = Me.SecondaryCPM
                End If
            End Get
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
