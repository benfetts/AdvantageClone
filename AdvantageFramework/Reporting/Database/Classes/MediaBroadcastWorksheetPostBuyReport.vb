Namespace Reporting.Database.Classes

    <Serializable>
    Public Class MediaBroadcastWorksheetPostBuyReport

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
            PostBook
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
            DetailID
            DetailLineDate
            DetailDayOfWeek
            DetailDays
            DetailTime
            DetailProgram
            DetailDaypart
            DetailLen
            DetailCost
            DetailEstimate
            DetailActual
            DetailIndex
            OverridePost
            OverridePostImpressions
            MediaBroadcastWorksheetMarketID
            ReportedDates
            RatingsServiceID
            Bookend
            AddedValue
            RatingSource
            CableNetworkID
            APNetworkID
            AdNumber
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
        Public Property CanadianVendorType As String

        Public Property FlightDates() As String

        Public Property PostBook() As String

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

        Public Property Len As Short

        Public Property OrdSpots As Integer

        Public Property ActualSpots As Integer

        Public Property Cost As Decimal

        Public Property Estimate As Decimal

        Public Property Actual As Decimal

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property NielsenTVStationCode As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property NCCTVSyscodeID As Nullable(Of Integer)

        Public Property StationName As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property NielsenMarketNumber As Integer

        Public Property DemographicDescription As String

        Public ReadOnly Property Index As Integer
            Get
                If Me.Estimate = 0 Then

                    Index = 0

                Else

                    Index = FormatNumber(Me.Actual / Me.Estimate * 100, 0)

                End If
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property GeographyName As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetMarketDetailID As Integer

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailID As Nullable(Of Integer)

        Public Property DetailLineDate As Nullable(Of Date)

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailDayOfWeek As Nullable(Of Short)

        Public ReadOnly Property DetailDays As String
            Get
                Dim ReturnDay As String = String.Empty

                Select Case Me.DetailDayOfWeek

                    Case System.DayOfWeek.Monday
                        ReturnDay = "M"

                    Case System.DayOfWeek.Tuesday
                        ReturnDay = "TU"

                    Case System.DayOfWeek.Wednesday
                        ReturnDay = "W"

                    Case System.DayOfWeek.Thursday
                        ReturnDay = "TH"

                    Case System.DayOfWeek.Friday
                        ReturnDay = "F"

                    Case System.DayOfWeek.Saturday
                        ReturnDay = "SA"

                    Case 7
                        ReturnDay = "SU"

                End Select

                DetailDays = ReturnDay
            End Get
        End Property

        Public Property DetailTime As String

        Public Property DetailProgram As String

        Public Property DetailDaypart As String

        Public Property DetailLen As Nullable(Of Short)

        Public Property DetailCost As Nullable(Of Decimal)

        Public Property DetailEstimate As Nullable(Of Decimal)

        Public Property DetailEstimateFull As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailEstimateImpressionsFull As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailEstimateRatingFull As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailEstimateGrossImpressionsFull As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailEstimateGrossImpression As Nullable(Of Decimal)

        Public Property DetailActual As Nullable(Of Decimal)

        Public ReadOnly Property DetailIndex As Integer
            Get
                If Me.DetailEstimate.GetValueOrDefault(0) = 0 Then

                    DetailIndex = 0

                Else

                    DetailIndex = FormatNumber(Me.DetailActual.GetValueOrDefault(0) / Me.DetailEstimate.GetValueOrDefault(0) * 100, 0)

                End If
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailActualRating As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailEstimateRating As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public ReadOnly Property DetailActualRatingIndex As Integer
            Get
                If Me.DetailEstimateRating.GetValueOrDefault(0) = 0 Then

                    DetailActualRatingIndex = 0

                Else

                    DetailActualRatingIndex = FormatNumber(Me.DetailActualRating.GetValueOrDefault(0) / Me.DetailEstimateRating.GetValueOrDefault(0) * 100, 0)

                End If
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailActualImpression As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailEstimateImpression As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public ReadOnly Property DetailActualImpressionIndex As Integer
            Get
                If Me.DetailEstimateImpression.GetValueOrDefault(0) = 0 Then

                    DetailActualImpressionIndex = 0

                Else

                    DetailActualImpressionIndex = FormatNumber(Me.DetailActualImpression.GetValueOrDefault(0) / Me.DetailEstimateImpression.GetValueOrDefault(0) * 100, 0)

                End If
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailActualGrossImpression As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property BookName As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property BookID As Integer

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property OverridePost As Boolean

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property OverridePostImpressions As Boolean

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

        Public Property CableNetworkID() As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(CustomColumnCaption:="AP Network ID")>
        Public Property APNetworkID() As String
        Public Property AdNumber() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
