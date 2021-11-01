Namespace Reporting.Database.Classes

    <Serializable>
    Public Class MediaBroadcastWorksheetPostBuyDRWReport

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
            CanadianVendorType
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
            EstimatedGRP
            EstimatedRtg
            EstimatedGrossImpressions
            EstimatedImpressions
            ActualGRP
            ActualRtg
            ActualGrossImpressions
            ActualImpressions
            NielsenTVStationCode
            NCCTVSyscodeID
            StationName
            NielsenMarketNumber
            DemographicDescription
            RatingsIndex
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
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(CustomColumnCaption:="Vendor Type")>
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
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(CustomColumnCaption:="Est GRP")>
        Public Property EstimatedGRP As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(CustomColumnCaption:="Est Rtg")>
        Public Property EstimatedRtg As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f1", CustomColumnCaption:="Est GImps (000)")>
        Public Property EstimatedGrossImpressions As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f1", CustomColumnCaption:="Est Imps (000)")>
        Public Property EstimatedImpressions As Nullable(Of Decimal)
        'Public Property DetailEstimateFull As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(CustomColumnCaption:="Act GRP")>
        Public Property ActualGRP As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(CustomColumnCaption:="Act Rtg")>
        Public Property ActualRtg As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f1", CustomColumnCaption:="Act GImps (000)")>
        Public Property ActualGrossImpressions As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f1", CustomColumnCaption:="Act Imps (000)")>
        Public Property ActualImpressions As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property NielsenTVStationCode As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property NCCTVSyscodeID As Nullable(Of Integer)
        Public Property StationName As String
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property NielsenMarketNumber As Integer
        Public Property DemographicDescription As String
        Public Property RatingsIndex As Integer
        Public Property ImpressionsIndex As Integer
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
        Public Property DetailRatingsIndex As Integer
        Public Property DetailImpressionsIndex As Integer
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
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailEstimateFull As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailEstimateImpressionsFull As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailEstimateRatingFull As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailEstimateGrossImpressionsFull As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailEstimateGrossImpression As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailActualGrossImpression As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Sub New(MediaBroadcastWorksheetPostBuyReport As MediaBroadcastWorksheetPostBuyReport)

            Me.ID = MediaBroadcastWorksheetPostBuyReport.ID
            Me.ClientName = MediaBroadcastWorksheetPostBuyReport.ClientName
            Me.DivisionName = MediaBroadcastWorksheetPostBuyReport.DivisionName
            Me.ProductDescription = MediaBroadcastWorksheetPostBuyReport.ProductDescription
            Me.MediaBroadcastWorksheetName = MediaBroadcastWorksheetPostBuyReport.MediaBroadcastWorksheetName
            Me.MarketName = MediaBroadcastWorksheetPostBuyReport.MarketName
            Me.VendorCode = MediaBroadcastWorksheetPostBuyReport.VendorCode
            Me.VendorName = MediaBroadcastWorksheetPostBuyReport.VendorName
            Me.CanadianVendorType = MediaBroadcastWorksheetPostBuyReport.CanadianVendorType
            Me.FlightDates = MediaBroadcastWorksheetPostBuyReport.FlightDates
            Me.PostBook = MediaBroadcastWorksheetPostBuyReport.PostBook
            Me.LineNumber = MediaBroadcastWorksheetPostBuyReport.LineNumber
            Me.MakeGoodNumber = MediaBroadcastWorksheetPostBuyReport.MakeGoodNumber
            Me.LineMinDate = MediaBroadcastWorksheetPostBuyReport.LineMinDate
            Me.LineMaxDate = MediaBroadcastWorksheetPostBuyReport.LineMaxDate
            Me.Days = MediaBroadcastWorksheetPostBuyReport.Days
            Me.Time = MediaBroadcastWorksheetPostBuyReport.Time
            Me.Program = MediaBroadcastWorksheetPostBuyReport.Program
            Me.Daypart = MediaBroadcastWorksheetPostBuyReport.Daypart
            Me.Len = MediaBroadcastWorksheetPostBuyReport.Len
            Me.OrdSpots = MediaBroadcastWorksheetPostBuyReport.OrdSpots
            Me.ActualSpots = MediaBroadcastWorksheetPostBuyReport.ActualSpots
            Me.Cost = MediaBroadcastWorksheetPostBuyReport.Cost

            Me.EstimatedGRP = 0
            Me.EstimatedRtg = 0
            Me.EstimatedGrossImpressions = 0
            Me.EstimatedImpressions = 0
            Me.ActualGRP = 0
            Me.ActualRtg = 0
            Me.ActualGrossImpressions = 0
            Me.ActualImpressions = 0

            Me.NielsenTVStationCode = MediaBroadcastWorksheetPostBuyReport.NielsenTVStationCode
            Me.NCCTVSyscodeID = MediaBroadcastWorksheetPostBuyReport.NCCTVSyscodeID
            Me.StationName = MediaBroadcastWorksheetPostBuyReport.StationName
            Me.NielsenMarketNumber = MediaBroadcastWorksheetPostBuyReport.NielsenMarketNumber
            Me.DemographicDescription = MediaBroadcastWorksheetPostBuyReport.DemographicDescription
            Me.GeographyName = MediaBroadcastWorksheetPostBuyReport.GeographyName
            Me.MediaBroadcastWorksheetMarketDetailID = MediaBroadcastWorksheetPostBuyReport.MediaBroadcastWorksheetMarketDetailID
            Me.DetailID = MediaBroadcastWorksheetPostBuyReport.DetailID
            Me.DetailLineDate = MediaBroadcastWorksheetPostBuyReport.DetailLineDate
            Me.DetailDayOfWeek = MediaBroadcastWorksheetPostBuyReport.DetailDayOfWeek
            Me.DetailTime = MediaBroadcastWorksheetPostBuyReport.DetailTime
            Me.DetailProgram = MediaBroadcastWorksheetPostBuyReport.DetailProgram
            Me.DetailDaypart = MediaBroadcastWorksheetPostBuyReport.DetailDaypart
            Me.DetailLen = MediaBroadcastWorksheetPostBuyReport.DetailLen
            Me.DetailCost = MediaBroadcastWorksheetPostBuyReport.DetailCost
            Me.DetailEstimateFull = MediaBroadcastWorksheetPostBuyReport.DetailEstimateFull
            Me.DetailEstimateImpressionsFull = MediaBroadcastWorksheetPostBuyReport.DetailEstimateImpressionsFull
            Me.DetailEstimateGrossImpressionsFull = MediaBroadcastWorksheetPostBuyReport.DetailEstimateGrossImpressionsFull
            Me.DetailEstimateGrossImpression = MediaBroadcastWorksheetPostBuyReport.DetailEstimateGrossImpression
            Me.DetailEstimateRatingFull = MediaBroadcastWorksheetPostBuyReport.DetailEstimateRatingFull
            Me.DetailActualRating = MediaBroadcastWorksheetPostBuyReport.DetailActualRating
            Me.DetailEstimateRating = MediaBroadcastWorksheetPostBuyReport.DetailEstimateRating
            Me.DetailActualImpression = MediaBroadcastWorksheetPostBuyReport.DetailActualImpression
            Me.DetailEstimateImpression = MediaBroadcastWorksheetPostBuyReport.DetailEstimateImpression
            Me.DetailActualGrossImpression = MediaBroadcastWorksheetPostBuyReport.DetailActualGrossImpression
            Me.BookName = MediaBroadcastWorksheetPostBuyReport.BookName
            Me.BookID = MediaBroadcastWorksheetPostBuyReport.BookID
            Me.OverridePost = MediaBroadcastWorksheetPostBuyReport.OverridePost
            Me.OverridePostImpressions = MediaBroadcastWorksheetPostBuyReport.OverridePostImpressions
            Me.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetPostBuyReport.MediaBroadcastWorksheetMarketID
            Me.ReportedDates = MediaBroadcastWorksheetPostBuyReport.ReportedDates
            Me.RatingsServiceID = MediaBroadcastWorksheetPostBuyReport.RatingsServiceID
            Me.Bookend = MediaBroadcastWorksheetPostBuyReport.Bookend
            Me.AddedValue = MediaBroadcastWorksheetPostBuyReport.AddedValue
            Me.RatingSource = MediaBroadcastWorksheetPostBuyReport.RatingSource
            Me.CableNetworkID = MediaBroadcastWorksheetPostBuyReport.CableNetworkID
            Me.APNetworkID = MediaBroadcastWorksheetPostBuyReport.APNetworkID
            Me.AdNumber = MediaBroadcastWorksheetPostBuyReport.AdNumber

            RefreshIndexes()

        End Sub
        Public Sub RefreshIndexes()

            If Me.EstimatedRtg.GetValueOrDefault(0) = 0 Then

                Me.RatingsIndex = 0

            Else

                Me.RatingsIndex = FormatNumber(Me.ActualRtg.GetValueOrDefault(0) / Me.EstimatedRtg.GetValueOrDefault(0) * 100, 0)

            End If

            If Me.EstimatedImpressions.GetValueOrDefault(0) = 0 Then

                Me.ImpressionsIndex = 0

            Else

                Me.ImpressionsIndex = FormatNumber(Me.ActualImpressions.GetValueOrDefault(0) / Me.EstimatedImpressions.GetValueOrDefault(0) * 100, 0)

            End If

            If Me.DetailEstimateRating.GetValueOrDefault(0) = 0 Then

                Me.DetailRatingsIndex = 0

            Else

                Me.DetailRatingsIndex = FormatNumber(Me.DetailActualRating.GetValueOrDefault(0) / Me.DetailEstimateRating.GetValueOrDefault(0) * 100, 0)

            End If

            If Me.DetailEstimateImpression.GetValueOrDefault(0) = 0 Then

                Me.DetailImpressionsIndex = 0

            Else

                Me.DetailImpressionsIndex = FormatNumber(Me.DetailActualImpression.GetValueOrDefault(0) / Me.DetailEstimateImpression.GetValueOrDefault(0) * 100, 0)

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
