Namespace Reporting.Database.Classes

    <Serializable>
    Public Class MediaBroadcastWorksheetPreBuyReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientName
            DivisionName
            ProductDescription
            MediaBroadcastWorksheetName
            MarketName
            VendorCode
            VendorName
            FlightDates
            PreBuyShareBook
            PreBuyHPUTBook
            LineNumber
            MakeGoodNumber 
            LineMinDate
            LineMaxDate
            LineDate
            Days
            Time
            Program
            Daypart
            DaypartDescription
            Len
            OrdSpots
            Cost
            SpotEstimate
            SpotUpdatedEstimate
            TotalEstimate
            TotalUpdatedEstimate
            NielsenTVStationCode
            NCCTVSyscodeID
            StationName
            NielsenMarketNumber
            DemographicDescription
            Index
            GeographyName
            MediaBroadcastWorksheetMarketDetailID
            MediaBroadcastWorksheetMarketID
            ReportedDates
            RatingsServiceID
            Bookend
            AddedValue
            RatingSource
            ScheduleShareBookID
            ScheduleShareBook
            ScheduleHPUTBookID
            ScheduleHPUTBook
            ScheduleBooks
            PreBuyBooks
            CableNetworkID
            Quarter
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of System.Guid)

        Public Property ClientName() As String

        Public Property DivisionName() As String

        Public Property ProductDescription() As String

        Public Property MediaBroadcastWorksheetName() As String

        Public Property MarketName() As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property VendorCode() As String
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property VendorName() As String

        Public Property FlightDates() As String

        Public Property PreBuyShareBook() As String

        Public Property PreBuyHPUTBook() As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property LineNumber As Integer

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property MakeGoodNumber As Integer

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(CustomColumnCaption:="Line Number")>
        Public ReadOnly Property FormattedLineNumber As String
            Get
                FormattedLineNumber = Me.LineNumber.ToString & IIf(Me.MakeGoodNumber <> 0, "-" & Me.MakeGoodNumber.ToString, "")
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property LineMinDate As Date
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property LineMaxDate As Date

        Public ReadOnly Property LineDate As String
            Get
                If Me.LineMinDate.Year = Me.LineMaxDate.Year Then
                    LineDate = Me.LineMinDate.Month & "/" & Me.LineMinDate.Day & "-" & Me.LineMaxDate.ToString("M/d/yy")
                Else
                    LineDate = Me.LineMinDate.ToString("M/d/yy") & "-" & Me.LineMaxDate.ToString("M/d/yy")
                End If
            End Get
        End Property

        Public Property Days As String

        Public Property Time As String

        Public Property Program As String

        Public Property Daypart As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DaypartDescription As String

        Public Property Len As Short

        Public Property OrdSpots As Integer

        Public Property Cost As Decimal

        Public Property SpotEstimate As Decimal

        Public Property SpotUpdatedEstimate As Decimal

        Public ReadOnly Property TotalEstimate As Decimal
            Get
                TotalEstimate = FormatNumber(Me.OrdSpots * Me.SpotEstimate, 2)
            End Get
        End Property

        Public ReadOnly Property TotalUpdatedEstimate As Decimal
            Get
                TotalUpdatedEstimate = FormatNumber(Me.OrdSpots * Me.SpotUpdatedEstimate, 2)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property NielsenTVStationCode As Integer?

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property NCCTVSyscodeID As Integer?

        Public Property StationName As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property NielsenMarketNumber As Integer

        Public Property DemographicDescription As String

        Public ReadOnly Property Index As Integer
            Get
                If Me.TotalEstimate = 0 Then

                    Index = 0

                Else

                    Index = FormatNumber(Me.TotalUpdatedEstimate / Me.TotalEstimate * 100, 0)

                End If
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property GeographyName As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetMarketDetailID As Integer

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetMarketID As Integer

        Public Property ReportedDates() As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property RatingsServiceID As AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public ReadOnly Property RatingsServiceSourceName As String
            Get
                If RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen Then
                    RatingsServiceSourceName = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen.ToString
                ElseIf RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then
                    RatingsServiceSourceName = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore.ToString
                Else
                    RatingsServiceSourceName = String.Empty
                End If
            End Get
        End Property

        Public Property Bookend() As Boolean

        Public Property AddedValue() As Boolean

        Public Property RatingSource() As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property ScheduleShareBookID As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property ScheduleShareBook() As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property ScheduleHPUTBookID As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property ScheduleHPUTBook() As String

        Public ReadOnly Property ScheduleBooks() As String
            Get
                If String.IsNullOrWhiteSpace(Me.ScheduleShareBook) AndAlso String.IsNullOrWhiteSpace(Me.ScheduleHPUTBook) Then
                    ScheduleBooks = ""
                Else
                    ScheduleBooks = Me.ScheduleShareBook & " / " & Me.ScheduleHPUTBook
                End If
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public ReadOnly Property PreBuyBooks() As String
            Get
                If String.IsNullOrWhiteSpace(Me.PreBuyShareBook) AndAlso String.IsNullOrWhiteSpace(Me.PreBuyHPUTBook) Then
                    PreBuyBooks = ""
                Else
                    PreBuyBooks = Me.PreBuyShareBook & " / " & Me.PreBuyHPUTBook
                End If
            End Get
        End Property

        Public Property CableNetworkID() As String

        Public Property Quarter() As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property OverridePost As Boolean
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property OverridePostImpressions As Boolean
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property BookID As Integer

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
