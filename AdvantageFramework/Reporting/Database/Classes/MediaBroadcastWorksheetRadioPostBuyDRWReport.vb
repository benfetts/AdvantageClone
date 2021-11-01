Namespace Reporting.Database.Classes

    <Serializable>
    Public Class MediaBroadcastWorksheetRadioPostBuyDRWReport

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
            Daypart
            Len
            OrdSpots
            ActualSpots
            Cost
            Estimate
            Actual
            NielsenRadioStationComboID
            StationName
            NielsenMarketNumber
            DemographicDescription
            RatingIndex
            GeographyEthnicity
            MediaBroadcastWorksheetMarketDetailID
            DetailID
            DetailLineDate
            DetailDayOfWeek
            DetailDays
            DetailTime
            DetailDaypart
            DetailLen
            DetailCost
            DetailEstimate
            DetailActual
            DetailIndex
            DetailBook
            OverridePost
            OverridePostImpression
            MediaBroadcastWorksheetMarketID
            ReportedDates
            RatingsServiceID
            Bookend
            AddedValue
            RatingSource
            BookName
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
        Public Property Daypart As String
        Public Property Len As Short
        Public Property OrdSpots As Integer
        Public Property ActualSpots As Integer
        Public Property Cost As Decimal
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(CustomColumnCaption:="Est GRP")>
        Public Property EstimatedGRP As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(CustomColumnCaption:="Est Rtg")>
        Public Property EstimatedRtg As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f0", CustomColumnCaption:="Est Gross AQH (00)")>
        Public Property EstimatedGrossImpression As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f0", CustomColumnCaption:="Est AQH (00)")>
        Public Property EstimatedImpression As Nullable(Of Decimal)
        'Public Property DetailEstimateFull As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(CustomColumnCaption:="Act GRP")>
        Public Property ActualGRP As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(CustomColumnCaption:="Act Rtg")>
        Public Property ActualRtg As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f0", CustomColumnCaption:="Act Gross AQH (00)")>
        Public Property ActualGrossImpression As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f0", CustomColumnCaption:="Act AQH (00)")>
        Public Property ActualImpression As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property NielsenRadioStationComboID As Nullable(Of Integer)
        Public Property StationName As String
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property NielsenMarketNumber As Integer
        Public Property DemographicDescription As String
        Public Property RatingsIndex As Integer
        Public Property ImpressionIndex As Integer
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property GeographyEthnicity As String
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
        Public Property DetailDaypart As String
        Public Property DetailLen As Nullable(Of Short)
        Public Property DetailCost As Nullable(Of Decimal)
        Public Property DetailRatingsIndex As Integer
        Public Property DetailImpressionIndex As Integer
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
        Public Property DetailBook As String
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailNielsenRadioPeriodID As Integer
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property BookName As String
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property OverridePost As Boolean
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property OverridePostAQH As Boolean
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetMarketID As Integer
        Public Property ReportedDates() As String
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property ExternalRadioSource As AdvantageFramework.Nielsen.Database.Entities.RadioSource
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public ReadOnly Property RatingsServiceSourceName As String
            Get

                If ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                    RatingsServiceSourceName = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen.ToString

                ElseIf ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                    RatingsServiceSourceName = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan.ToString

                ElseIf ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.NielsenCounty Then

                    RatingsServiceSourceName = AdvantageFramework.Nielsen.Database.Entities.RadioSource.NielsenCounty.ToString

                Else

                    RatingsServiceSourceName = String.Empty

                End If

            End Get
        End Property
        Public Property Bookend() As Boolean
        Public Property AddedValue() As Boolean
        Public Property RatingSource() As String
        Public Property AdNumber() As String
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailEstimateFull As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailEstimateImpressionFull As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailEstimateRatingFull As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailEstimateGrossImpressionFull As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailEstimateGrossImpression As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DetailActualGrossImpression As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Sub New(MediaBroadcastWorksheetRadioPostBuyReport As MediaBroadcastWorksheetRadioPostBuyReport)

            Me.ID = MediaBroadcastWorksheetRadioPostBuyReport.ID
            Me.ClientName = MediaBroadcastWorksheetRadioPostBuyReport.ClientName
            Me.DivisionName = MediaBroadcastWorksheetRadioPostBuyReport.DivisionName
            Me.ProductDescription = MediaBroadcastWorksheetRadioPostBuyReport.ProductDescription
            Me.MediaBroadcastWorksheetName = MediaBroadcastWorksheetRadioPostBuyReport.MediaBroadcastWorksheetName
            Me.MarketName = MediaBroadcastWorksheetRadioPostBuyReport.MarketName
            Me.VendorCode = MediaBroadcastWorksheetRadioPostBuyReport.VendorCode
            Me.VendorName = MediaBroadcastWorksheetRadioPostBuyReport.VendorName
            Me.CanadianVendorType = MediaBroadcastWorksheetRadioPostBuyReport.CanadianVendorType
            Me.FlightDates = MediaBroadcastWorksheetRadioPostBuyReport.FlightDates
            Me.PostBook = MediaBroadcastWorksheetRadioPostBuyReport.PostBook
            Me.LineNumber = MediaBroadcastWorksheetRadioPostBuyReport.LineNumber
            Me.MakeGoodNumber = MediaBroadcastWorksheetRadioPostBuyReport.MakeGoodNumber
            Me.LineMinDate = MediaBroadcastWorksheetRadioPostBuyReport.LineMinDate
            Me.LineMaxDate = MediaBroadcastWorksheetRadioPostBuyReport.LineMaxDate
            Me.Days = MediaBroadcastWorksheetRadioPostBuyReport.Days
            Me.Time = MediaBroadcastWorksheetRadioPostBuyReport.Time
            Me.Daypart = MediaBroadcastWorksheetRadioPostBuyReport.Daypart
            Me.Len = MediaBroadcastWorksheetRadioPostBuyReport.Len
            Me.OrdSpots = MediaBroadcastWorksheetRadioPostBuyReport.OrdSpots
            Me.ActualSpots = MediaBroadcastWorksheetRadioPostBuyReport.ActualSpots
            Me.Cost = MediaBroadcastWorksheetRadioPostBuyReport.Cost

            Me.EstimatedGRP = 0
            Me.EstimatedRtg = 0
            Me.EstimatedGrossImpression = 0
            Me.EstimatedImpression = 0
            Me.ActualGRP = 0
            Me.ActualRtg = 0
            Me.ActualGrossImpression = 0
            Me.ActualImpression = 0

            Me.NielsenRadioStationComboID = MediaBroadcastWorksheetRadioPostBuyReport.NielsenRadioStationComboID
            Me.StationName = MediaBroadcastWorksheetRadioPostBuyReport.StationName
            Me.NielsenMarketNumber = MediaBroadcastWorksheetRadioPostBuyReport.NielsenMarketNumber
            Me.DemographicDescription = MediaBroadcastWorksheetRadioPostBuyReport.DemographicDescription
            Me.GeographyEthnicity = MediaBroadcastWorksheetRadioPostBuyReport.GeographyEthnicity
            Me.MediaBroadcastWorksheetMarketDetailID = MediaBroadcastWorksheetRadioPostBuyReport.MediaBroadcastWorksheetMarketDetailID
            Me.DetailID = MediaBroadcastWorksheetRadioPostBuyReport.DetailID
            Me.DetailLineDate = MediaBroadcastWorksheetRadioPostBuyReport.DetailLineDate
            Me.DetailDayOfWeek = MediaBroadcastWorksheetRadioPostBuyReport.DetailDayOfWeek
            Me.DetailTime = MediaBroadcastWorksheetRadioPostBuyReport.DetailTime
            Me.DetailDaypart = MediaBroadcastWorksheetRadioPostBuyReport.DetailDaypart
            Me.DetailLen = MediaBroadcastWorksheetRadioPostBuyReport.DetailLen
            Me.DetailCost = MediaBroadcastWorksheetRadioPostBuyReport.DetailCost
            Me.DetailEstimateFull = MediaBroadcastWorksheetRadioPostBuyReport.DetailEstimateFull
            Me.DetailEstimateImpressionFull = MediaBroadcastWorksheetRadioPostBuyReport.DetailEstimateImpressionFull
            Me.DetailEstimateGrossImpressionFull = MediaBroadcastWorksheetRadioPostBuyReport.DetailEstimateGrossImpressionFull
            Me.DetailEstimateGrossImpression = MediaBroadcastWorksheetRadioPostBuyReport.DetailEstimateGrossImpression
            Me.DetailEstimateRatingFull = MediaBroadcastWorksheetRadioPostBuyReport.DetailEstimateRatingFull
            Me.DetailActualRating = MediaBroadcastWorksheetRadioPostBuyReport.DetailActualRating
            Me.DetailEstimateRating = MediaBroadcastWorksheetRadioPostBuyReport.DetailEstimateRating
            Me.DetailActualImpression = MediaBroadcastWorksheetRadioPostBuyReport.DetailActualImpression
            Me.DetailEstimateImpression = MediaBroadcastWorksheetRadioPostBuyReport.DetailEstimateImpression
            Me.DetailActualGrossImpression = MediaBroadcastWorksheetRadioPostBuyReport.DetailActualGrossImpression
            Me.DetailBook = MediaBroadcastWorksheetRadioPostBuyReport.DetailBook
            Me.DetailNielsenRadioPeriodID = MediaBroadcastWorksheetRadioPostBuyReport.DetailNielsenRadioPeriodID
            Me.BookName = MediaBroadcastWorksheetRadioPostBuyReport.BookName
            Me.OverridePost = MediaBroadcastWorksheetRadioPostBuyReport.OverridePost
            Me.OverridePostAQH = MediaBroadcastWorksheetRadioPostBuyReport.OverridePostAQH
            Me.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetRadioPostBuyReport.MediaBroadcastWorksheetMarketID
            Me.ReportedDates = MediaBroadcastWorksheetRadioPostBuyReport.ReportedDates
            Me.ExternalRadioSource = MediaBroadcastWorksheetRadioPostBuyReport.ExternalRadioSource
            Me.Bookend = MediaBroadcastWorksheetRadioPostBuyReport.Bookend
            Me.AddedValue = MediaBroadcastWorksheetRadioPostBuyReport.AddedValue
            Me.RatingSource = MediaBroadcastWorksheetRadioPostBuyReport.RatingSource
            Me.AdNumber = MediaBroadcastWorksheetRadioPostBuyReport.AdNumber

            RefreshIndexes()

        End Sub
        Public Sub RefreshIndexes()

            If Me.EstimatedRtg.GetValueOrDefault(0) = 0 Then

                Me.RatingsIndex = 0

            Else

                Me.RatingsIndex = FormatNumber(Me.ActualRtg.GetValueOrDefault(0) / Me.EstimatedRtg.GetValueOrDefault(0) * 100, 0)

            End If

            If Me.EstimatedImpression.GetValueOrDefault(0) = 0 Then

                Me.ImpressionIndex = 0

            Else

                Me.ImpressionIndex = FormatNumber(Me.ActualImpression.GetValueOrDefault(0) / Me.EstimatedImpression.GetValueOrDefault(0) * 100, 0)

            End If

            If Me.DetailEstimateRating.GetValueOrDefault(0) = 0 Then

                Me.DetailRatingsIndex = 0

            Else

                Me.DetailRatingsIndex = FormatNumber(Me.DetailActualRating.GetValueOrDefault(0) / Me.DetailEstimateRating.GetValueOrDefault(0) * 100, 0)

            End If

            If Me.DetailEstimateImpression.GetValueOrDefault(0) = 0 Then

                Me.DetailImpressionIndex = 0

            Else

                Me.DetailImpressionIndex = FormatNumber(Me.DetailActualImpression.GetValueOrDefault(0) / Me.DetailEstimateImpression.GetValueOrDefault(0) * 100, 0)

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
