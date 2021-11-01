Namespace Reporting.Database.Classes

    <Serializable>
    Public Class MarketScheduleWeeklyDetailReport

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
            LineNumber
            MakeGoodNumber
            FormattedLineNumber
            LineMinDate
            LineMaxDate
            LineDate
            Days
            Time
            Program
            Daypart
            Len
            OrdSpots
            ActualSpots
            Cost
            Estimate
            Actual
            NielsenTVStationCode
            NCCTVSyscodeID
            StationName
            NielsenMarketNumber
            DemographicDescription
            Index
            GeographyName
            MediaBroadcastWorksheetMarketDetailID
            OverridePost
            MediaBroadcastWorksheetMarketID
            ReportedDates
            RatingsServiceID
            Bookend
            AddedValue
            RatingSource
            GIMPRaw
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

        Public Property WeekOf As Date
        Public ReadOnly Property Mon As Short
            Get
                Mon = WeekOf.Day
            End Get
        End Property
        Public ReadOnly Property Tue As Short
            Get
                Tue = WeekOf.AddDays(1).Day
            End Get
        End Property
        Public ReadOnly Property Wed As Short
            Get
                Wed = WeekOf.AddDays(2).Day
            End Get
        End Property
        Public ReadOnly Property Thu As Short
            Get
                Thu = WeekOf.AddDays(3).Day
            End Get
        End Property
        Public ReadOnly Property Fri As Short
            Get
                Fri = WeekOf.AddDays(4).Day
            End Get
        End Property
        Public ReadOnly Property Sat As Short
            Get
                Sat = WeekOf.AddDays(5).Day
            End Get
        End Property
        Public ReadOnly Property Sun As Short
            Get
                Sun = WeekOf.AddDays(6).Day
            End Get
        End Property

        Public Property Days As String

        Public Property Time As String

        Public ReadOnly Property DaysTime As String
            Get
                DaysTime = Me.Days & Space(1) & Me.Time
            End Get
        End Property

        Public Property Program As String

        Public Property Monday As String
        Public Property Tuesday As String
        Public Property Wednesday As String
        Public Property Thursday As String
        Public Property Friday As String
        Public Property Saturday As String
        Public Property Sunday As String

        Public Property Rate As Nullable(Of Decimal)
        Public Property Rating As Decimal
        Public Property Impressions As Decimal
        Public Property ImpressionsRaw As Int64

        Public ReadOnly Property GRP As Decimal
            Get
                GRP = FormatNumber(Me.Rating * Me.Spots, 2)
            End Get
        End Property
        Public ReadOnly Property CPP As Decimal
            Get
                If GRP = 0 Then
                    CPP = 0.00
                Else
                    CPP = FormatNumber(Me.TotalCost / GRP, 2)
                End If
            End Get
        End Property
        Public ReadOnly Property CPM As Decimal
            Get
                If Me.GIMPRaw = 0 Then
                    CPM = 0.00
                Else
                    If Me.MediaType = "T" Then
                        CPM = FormatNumber(Me.TotalCost / Me.GIMPRaw * 1000, 2)
                    Else
                        CPM = FormatNumber(Me.TotalCost / Me.GIMPRaw * 1000, 2)
                    End If
                End If
            End Get
        End Property
        Public ReadOnly Property GIMPRaw As Decimal
            Get
                GIMPRaw = FormatNumber(Me.ImpressionsRaw * Me.Spots, 1)
            End Get
        End Property
        Public ReadOnly Property TotalCost As Decimal
            Get
                TotalCost = FormatNumber(Me.Spots * Me.Rate, 2)
            End Get
        End Property

        Public Property Daypart As String

        Public Property Len As Short

        Public Property Spots As Nullable(Of Integer)

        Public Property Cost As Decimal

        Public Property NielsenTVStationCode As Nullable(Of Integer)

        Public Property NCCTVSyscodeID As Nullable(Of Integer)

        Public Property StationName As String

        Public Property NielsenMarketNumber As Integer

        Public Property DemographicDescription As String

        Public Property MediaBroadcastWorksheetMarketDetailID As Integer

        Public Property MediaBroadcastWorksheetMarketID As Integer

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

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
